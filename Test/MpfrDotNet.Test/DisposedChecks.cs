namespace Test;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// Every public member of the number types must throw ObjectDisposedException when one of its operands, or the instance
// itself, is disposed: the native memory is released, and using it would read or write freed memory. The members are
// found by reflection, so a member added later is tested too.
[TestFixture]
internal class DisposedChecks
{
    private const int ThisPosition = -1;

    private static readonly Type[] NumberTypes = [typeof(mpz_t), typeof(mpq_t), typeof(mpf_t), typeof(mpfr_t)];

    // Members that do not use the native number, or that must stay callable after Dispose.
    private static readonly HashSet<string> Exclusions =
    [
        "Dispose",
        "ClearArray",
        "get_Rounding",
        "set_Rounding",
        "get_LastTernaryResult",
        "get_IsCacheInitialized",
    ];

    private static IEnumerable<TestCaseData> DisposedOperandCases()
    {
        foreach (Type NumberType in NumberTypes)
        {
            foreach (MethodBase Member in GetMembers(NumberType))
            {
                bool IsInstance = Member is MethodInfo { IsStatic: false };

                List<int> Positions = [];

                if (IsInstance)
                    Positions.Add(ThisPosition);

                ParameterInfo[] Parameters = Member.GetParameters();
                for (int i = 0; i < Parameters.Length; i++)
                    if (!Parameters[i].IsOut && IsNumberOperand(Parameters[i].ParameterType))
                        Positions.Add(i);

                foreach (int Position in Positions)
                {
                    yield return CreateCase(NumberType, Member, Position, isOthersNull: false);

                    // The same call with null for the other operands that accept it: a member must not skip the check of
                    // the disposed operand because another operand is null.
                    if (Parameters.Where((p, i) => i != Position && IsNullableOperand(p)).Any())
                        yield return CreateCase(NumberType, Member, Position, isOthersNull: true);
                }
            }
        }
    }

    [TestCaseSource(nameof(DisposedOperandCases))]
    public void TestDisposedOperand(Type numberType, MethodBase member, int position, bool isOthersNull)
    {
        List<IDisposable> Created = [];

        try
        {
            object? Instance = null;
            Type? DisposedType = position == ThisPosition ? numberType : ElementType(member.GetParameters()[position].ParameterType);

            if (member is MethodInfo { IsStatic: false })
                Instance = CreateNumber(numberType, isDisposed: position == ThisPosition, Created);

            object?[] Arguments = member.GetParameters()
                .Select((p, i) => isOthersNull && i != position && IsNullableOperand(p) ? null : CreateArgument(p, isDisposed: i == position, numberType, Created))
                .ToArray();

            Assert.That(() => Invoke(member, Instance, Arguments), Throws.TypeOf<ObjectDisposedException>().With.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(DisposedType!.Name));
        }
        finally
        {
            foreach (IDisposable Item in Created)
                Item.Dispose();
        }
    }

    [Test]
    public void TestDisposeTwiceAndClearArray()
    {
        mpz_t Integer = new(1);
        mpq_t Rational = new(1UL, 2UL);
        mpf_t Float = new(1.5);
        mpfr_t Mpfr = new(1.5);
        mpq_t[] Rationals = [new(1UL, 2UL), new(1UL, 3UL)];
        mpfr_t[] Mpfrs = [new(1.5), new(2.5)];
        Rationals[0].Dispose();
        Mpfrs[0].Dispose();

        Integer.Dispose();
        Rational.Dispose();
        Float.Dispose();
        Mpfr.Dispose();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Integer.Dispose, Throws.Nothing);
        Assert.That(Rational.Dispose, Throws.Nothing);
        Assert.That(Float.Dispose, Throws.Nothing);
        Assert.That(Mpfr.Dispose, Throws.Nothing);
        Assert.That(() => mpq_t.ClearArray(Rationals), Throws.Nothing);
        Assert.That(() => mpfr_t.ClearArray(Mpfrs), Throws.Nothing);
    }

    [Test]
    public void TestDisposedNumberComparedWithNull()
    {
        mpz_t Integer = new(1);
        mpq_t Rational = new(1UL, 2UL);
        mpf_t Float = new(1.5);
        mpfr_t Mpfr = new(1.5);
        object NullObject = Sample.CreateNull<object>();
        mpz_t NullInteger = Sample.CreateNull<mpz_t>();
        mpfr_t NullMpfr = Sample.CreateNull<mpfr_t>();
        Integer.Dispose();
        Rational.Dispose();
        Float.Dispose();
        Mpfr.Dispose();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Integer.Equals(NullObject), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Integer.CompareTo(NullObject), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Integer < NullInteger, Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => NullInteger == Integer, Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Rational.Equals(NullObject), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Rational.CompareTo(NullObject), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Float.Equals(NullObject), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Float.CompareTo(NullObject), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Mpfr.Equals(NullObject), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Mpfr.Equals(NullMpfr), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Mpfr.CompareTo(NullObject), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Mpfr.CompareTo(NullMpfr), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Mpfr > NullInteger, Throws.TypeOf<ObjectDisposedException>());
    }

    [Test]
    public void TestOtherOperandsStayUsable()
    {
        using mpz_t Kept = new(5);
        mpz_t Disposed = new(3);
        Disposed.Dispose();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Kept + Disposed, Throws.TypeOf<ObjectDisposedException>());
        Assert.That(Kept.ToString(), Is.EqualTo("5"));
    }

    [Test]
    public void TestFailedConversionReleasesTheNumber()
    {
        mpz_t Integer = new(1);
        mpq_t Rational = new(1UL, 2UL);
        mpf_t Float = new(1.5);
        mpfr_t Mpfr = new(1.5);
        Integer.Dispose();
        Rational.Dispose();
        Float.Dispose();
        Mpfr.Dispose();

        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        using (IDisposable Scope = Assert.EnterMultipleScope())
        {
            Assert.That(() => new mpfr_t(Integer), Throws.TypeOf<ObjectDisposedException>());
            Assert.That(() => new mpfr_t(Integer, 3L), Throws.TypeOf<ObjectDisposedException>());
            Assert.That(() => new mpfr_t(Rational), Throws.TypeOf<ObjectDisposedException>());
            Assert.That(() => new mpfr_t(Float), Throws.TypeOf<ObjectDisposedException>());
            Assert.That(() => new mpfr_t(Mpfr), Throws.TypeOf<ObjectDisposedException>());
        }

        // The numbers allocated by the chained constructor are released before the exception leaves the constructor.
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }

    private static IEnumerable<MethodBase> GetMembers(Type numberType)
    {
        const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;

        foreach (ConstructorInfo Constructor in numberType.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
            if (Constructor.GetParameters().Any(p => !p.IsOut && IsNumberOperand(p.ParameterType)))
                yield return Constructor;

        foreach (MethodInfo Method in numberType.GetMethods(Flags))
        {
            // Explicit interface implementations are private, with the interface in their name.
            bool IsExplicitImplementation = Method.IsPrivate && Method.Name.Contains('.');

            if (!Method.IsPublic && !IsExplicitImplementation)
                continue;

            string ShortName = Method.Name[(Method.Name.LastIndexOf('.') + 1)..];
            if (Exclusions.Contains(ShortName))
                continue;

            if (Method.IsStatic && !Method.GetParameters().Any(p => !p.IsOut && IsNumberOperand(p.ParameterType)))
                continue;

            yield return Method;
        }
    }

    private static TestCaseData CreateCase(Type numberType, MethodBase member, int position, bool isOthersNull)
    {
        string Parameters = string.Join(", ", member.GetParameters().Select(p => p.ParameterType.Name));
        string Operand = position == ThisPosition ? "this" : member.GetParameters()[position].Name!;
        string Others = isOthersNull ? " and the others null" : string.Empty;

        return new TestCaseData(numberType, member, position, isOthersNull).SetName($"{numberType.Name}.{member.Name}({Parameters}) with {Operand} disposed{Others}");
    }

    // A parameter declared nullable, of a number type or object. Nullability annotations can only be read on .NET 6 and later.
    private static bool IsNullableOperand(ParameterInfo parameter)
    {
#if NET6_0_OR_GREATER
        bool IsOperandType = IsNumberOperand(parameter.ParameterType) || parameter.ParameterType == typeof(object);
        return !parameter.IsOut && IsOperandType && new NullabilityInfoContext().Create(parameter).ReadState == NullabilityState.Nullable;
#else
        return false;
#endif
    }

    private static bool IsNumberOperand(Type type) => NumberTypes.Contains(ElementType(type));

    private static Type ElementType(Type type)
    {
        Type Result = type.IsByRef ? type.GetElementType()! : type;
        return Result.IsArray ? Result.GetElementType()! : Result;
    }

    private static object CreateNumber(Type type, bool isDisposed, List<IDisposable> created)
    {
        IDisposable Number = type.Name switch
        {
            nameof(mpz_t) => new mpz_t(7),
            nameof(mpq_t) => new mpq_t(1UL, 2UL),
            nameof(mpf_t) => new mpf_t(1.5),
            _ => new mpfr_t(1.5),
        };

        created.Add(Number);

        if (isDisposed)
            Number.Dispose();

        return Number;
    }

    private static object? CreateArgument(ParameterInfo parameter, bool isDisposed, Type numberType, List<IDisposable> created)
    {
        if (parameter.IsOut)
            return null;

        Type Type = parameter.ParameterType.IsByRef ? parameter.ParameterType.GetElementType()! : parameter.ParameterType;

        if (Type.IsArray && IsNumberOperand(Type))
        {
            Array Items = Array.CreateInstance(Type.GetElementType()!, 1);
            Items.SetValue(CreateNumber(Type.GetElementType()!, isDisposed, created), 0);
            return Items;
        }

        if (IsNumberOperand(Type))
            return CreateNumber(Type, isDisposed, created);

        if (Type == typeof(object))
            return CreateNumber(numberType, isDisposed: false, created);

        if (Type == typeof(randstate_t))
        {
            randstate_t State = new();
            created.Add(State);
            return State;
        }

        if (Type.IsEnum)
            return Enum.GetValues(Type).GetValue(0);

        return Type switch
        {
            _ when Type == typeof(int) => 10,
            _ when Type == typeof(uint) => 10U,
            _ when Type == typeof(long) => 2L,
            _ when Type == typeof(ulong) => 2UL,
            _ when Type == typeof(short) => (short)2,
            _ when Type == typeof(ushort) => (ushort)2,
            _ when Type == typeof(sbyte) => (sbyte)2,
            _ when Type == typeof(byte) => (byte)2,
            _ when Type == typeof(double) => 1.5,
            _ when Type == typeof(float) => 1.5f,
            _ when Type == typeof(decimal) => 1.5m,
            _ when Type == typeof(bool) => false,
            _ when Type == typeof(string) => "1",
            _ when Type == typeof(byte[]) => new byte[] { 1 },
            _ when Type == typeof(BigInteger) => BigInteger.One,
            _ when Type == typeof(bitcount_t) => new bitcount_t(64),
            _ when Type == typeof(StringBuilder) => new StringBuilder(),
            _ when Type == typeof(IFormatProvider) => null,
            _ when Type == typeof(Type) => typeof(object),
            _ => throw new InvalidOperationException($"No test value for a parameter of type {Type}."),
        };
    }

    private static void Invoke(MethodBase member, object? instance, object?[] arguments)
    {
        try
        {
            object? Result = member is ConstructorInfo Constructor ? Constructor.Invoke(arguments) : member.Invoke(instance, arguments);

            // A member that does not throw returns a number that must be released.
            if (Result is IDisposable Disposable && !ReferenceEquals(Result, instance))
                Disposable.Dispose();
        }
        catch (TargetInvocationException args) when (args.InnerException is not null)
        {
            throw args.InnerException;
        }
    }
}
