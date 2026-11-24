namespace Test;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
internal class ComparisonOperators
{
    private static readonly string[] OperatorNameList =
    [
        "op_LessThan",
        "op_GreaterThan",
        "op_LessThanOrEqual",
        "op_GreaterThanOrEqual",
        "op_Equality",
        "op_Inequality",
    ];

    // Each type declares all six operators for each pair of operand types it supports.
    [TestCase(typeof(mpz_t), 78)]
    [TestCase(typeof(mpq_t), 12)]
    [TestCase(typeof(mpf_t), 54)]
    [TestCase(typeof(mpfr_t), 78)]
    public void TestComparisonOperators(Type declaringType, int expectedOverloadCount)
    {
        List<MethodInfo> OverloadList = [.. declaringType.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(IsComparisonOperator)];
        List<IDisposable> CreatedList = [];
        List<string> MismatchList = [];

        try
        {
            foreach (MethodInfo Overload in OverloadList)
                CheckOverload(Overload, CreatedList, MismatchList);
        }
        finally
        {
            foreach (IDisposable Item in CreatedList)
                Item.Dispose();
        }

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(OverloadList, Has.Count.EqualTo(expectedOverloadCount));
        Assert.That(MismatchList, Is.Empty);
    }

    private static bool IsComparisonOperator(MethodInfo method)
        => OperatorNameList.Contains(method.Name) && method.ReturnType == typeof(bool) && method.GetParameters().Length == 2;

    private static void CheckOverload(MethodInfo overload, List<IDisposable> createdList, List<string> mismatchList)
    {
        ParameterInfo[] Parameters = overload.GetParameters();
        List<(object? Value, double Number)> LeftList = GetSamples(Parameters[0].ParameterType, createdList);
        List<(object? Value, double Number)> RightList = GetSamples(Parameters[1].ParameterType, createdList);

        foreach ((object? Value, double Number) Left in LeftList)
        {
            foreach ((object? Value, double Number) Right in RightList)
            {
                bool Expected = GetExpected(overload.Name, Left, Right);
                bool Actual = overload.Invoke(null, [Left.Value, Right.Value]) is true;

                if (Actual != Expected)
                    mismatchList.Add($"{overload.Name}({Describe(Parameters[0].ParameterType, Left)}, {Describe(Parameters[1].ParameterType, Right)}) returned {Actual}");
            }
        }
    }

    // Values shared by all types, so that each pair of operands is less, equal and greater at least once.
    private static List<(object? Value, double Number)> GetSamples(Type type, List<IDisposable> createdList)
    {
        if (type == typeof(int))
            return [(1, 1.0), (2, 2.0)];
        if (type == typeof(uint))
            return [(1U, 1.0), (2U, 2.0)];
        if (type == typeof(long))
            return [(1L, 1.0), (2L, 2.0)];
        if (type == typeof(ulong))
            return [(1UL, 1.0), (2UL, 2.0)];
        if (type == typeof(float))
            return [(float.NaN, double.NaN), (1.0F, 1.0), (1.5F, 1.5), (2.0F, 2.0)];
        if (type == typeof(double))
            return [(double.NaN, double.NaN), (1.0, 1.0), (1.5, 1.5), (2.0, 2.0)];
        if (type == typeof(mpz_t))
            return [(null, 0.0), (Track(new mpz_t(1), createdList), 1.0), (Track(new mpz_t(2), createdList), 2.0)];
        if (type == typeof(mpq_t))
            return [(null, 0.0), (Track(new mpq_t(1UL, 1UL), createdList), 1.0), (Track(new mpq_t(3UL, 2UL), createdList), 1.5), (Track(new mpq_t(2UL, 1UL), createdList), 2.0)];
        if (type == typeof(mpf_t))
            return [(null, 0.0), (Track(new mpf_t(1.0), createdList), 1.0), (Track(new mpf_t(1.5), createdList), 1.5), (Track(new mpf_t(2.0), createdList), 2.0)];
        if (type == typeof(mpfr_t))
            return [(null, 0.0), (Track(new mpfr_t(double.NaN), createdList), double.NaN), (Track(new mpfr_t(1.0), createdList), 1.0), (Track(new mpfr_t(1.5), createdList), 1.5), (Track(new mpfr_t(2.0), createdList), 2.0)];

        throw new ArgumentException($"No sample for {type.Name}.", nameof(type));
    }

    private static T Track<T>(T item, List<IDisposable> createdList)
        where T : IDisposable
    {
        createdList.Add(item);
        return item;
    }

    // Null sorts before every other value, NaN included, and two nulls are equal. Otherwise, NaN is unordered:
    // every comparison with it is false, except for the inequality, which is true.
    private static bool GetExpected(string operatorName, (object? Value, double Number) left, (object? Value, double Number) right)
    {
        if (left.Value is null || right.Value is null)
        {
            int NullOrder = left.Value is null ? (right.Value is null ? 0 : -1) : 1;
            return ApplyOrder(operatorName, NullOrder);
        }

        if (double.IsNaN(left.Number) || double.IsNaN(right.Number))
            return operatorName == "op_Inequality";

        return ApplyOrder(operatorName, left.Number.CompareTo(right.Number));
    }

    private static bool ApplyOrder(string operatorName, int order)
        => operatorName switch
        {
            "op_LessThan" => order < 0,
            "op_GreaterThan" => order > 0,
            "op_LessThanOrEqual" => order <= 0,
            "op_GreaterThanOrEqual" => order >= 0,
            "op_Equality" => order == 0,
            _ => order != 0,
        };

    private static string Describe(Type type, (object? Value, double Number) operand)
        => operand.Value is null ? $"null {type.Name}" : $"{type.Name} {operand.Number.ToString(CultureInfo.InvariantCulture)}";
}
