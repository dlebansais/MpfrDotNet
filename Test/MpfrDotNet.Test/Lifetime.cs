namespace Test;

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
internal class Lifetime
{
    [Test]
    public void TestMpfrDisposedOnAnotherThread()
    {
        ulong CountBefore = mpfr_t.LiveObjectCount();
        mpfr_t x = new(1);

        ulong WorkerCount = Task.Run(() =>
        {
            x.Dispose();
            return mpfr_t.LiveObjectCount();
        }).Result;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(WorkerCount, Is.Zero);
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(CountBefore));
    }

    [Test]
    public void TestMpfrClearArrayAfterDispose()
    {
        ulong CountBefore = mpfr_t.LiveObjectCount();
        mpfr_t[] Array = mpfr_t.CreateArray(3);

        Array[0].Dispose();
        mpfr_t.ClearArray(Array);
        mpfr_t.ClearArray(Array);

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(CountBefore));
    }

    [Test]
    public void TestMpqClearArrayAfterDispose()
    {
        mpq_t[] Array = mpq_t.CreateArray(3);

        Array[0].Dispose();
        mpq_t.ClearArray(Array);

        Assert.That(() => mpq_t.ClearArray(Array), Throws.Nothing);
    }

    [Test]
    public void TestClearArrayNull()
    {
        mpfr_t[] NullMpfrArray = Sample.CreateNull<mpfr_t[]>();
        mpq_t[] NullMpqArray = Sample.CreateNull<mpq_t[]>();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr_t.ClearArray(NullMpfrArray), Throws.ArgumentNullException);
        Assert.That(() => mpq_t.ClearArray(NullMpqArray), Throws.ArgumentNullException);
    }

    [Test]
    public void TestCreateWithPrecision()
    {
        using mpfr_t x = mpfr_t.Create(100);
        using mpfr_t Pi = mpfr_t.Pi(200);
        mpfr_t[] Array = mpfr_t.CreateArray(2, 80);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(x.Precision, Is.EqualTo(100UL));
        Assert.That(Pi.Precision, Is.EqualTo(200UL));
        Assert.That(Array[0].Precision, Is.EqualTo(80UL));
        Assert.That(Array[1].Precision, Is.EqualTo(80UL));

        mpfr_t.ClearArray(Array);
    }

    [Test]
    public void TestRandStateSizeTooLarge()
    {
        Assert.That(() => randstate_t.Create(RngAlgorithm.LinearCongruential, 200UL), Throws.InstanceOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The size must be 128 or less."));

        // The finalizer of the object that failed to initialize must not release a state that does not exist.
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    [Test]
    public void TestRandStateInvalidParameters()
    {
        Assert.That(() => randstate_t.Create(RngAlgorithm.LinearCongruential, "invalid"), Throws.ArgumentException.With.Message.StartsWith("Invalid combination of parameters for this algorithm."));

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    [Test]
    public void TestRandStateMaximumSize()
    {
        using randstate_t State = randstate_t.Create(RngAlgorithm.LinearCongruential, 128UL);

        Assert.That(State, Is.Not.Null);
    }

    [Test]
    public void TestInvalidStringConstructors()
    {
        ulong CountBefore = mpfr_t.LiveObjectCount();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => new mpz_t("1x", 10), Throws.ArgumentException.With.Message.EqualTo("The combination of 'text' and 'strBase' is invalid."));
        Assert.That(() => new mpq_t("1x", 10), Throws.ArgumentException.With.Message.EqualTo("The combination of 'text' and 'strBase' is invalid."));
        Assert.That(() => new mpf_t("1x", 10), Throws.ArgumentException.With.Message.EqualTo("The combination of 's' and 'strBase' is invalid."));
        Assert.That(() => new mpfr_t("1x"), Throws.ArgumentException.With.Message.EqualTo("The combination of 'str' and 'strbase' is invalid."));
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(CountBefore));
    }

    [Test]
    public void TestInputString()
    {
        const string Valid = "12345";
        const string Invalid = "12x45";

        using mpz_t x = new();

        long ValidLength = ReadInteger(x, Valid);
        string ValidResult = x.ToString();
        long InvalidLength = ReadInteger(x, Invalid);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(ValidLength, Is.EqualTo(Valid.Length));
        Assert.That(ValidResult, Is.EqualTo(Valid));
        Assert.That(InvalidLength, Is.Zero);
    }

    [Test]
    public void TestFinalizers()
    {
        CreateUnreachableNumbers();

        // The finalizers release native memory on the finalizer thread.
        Assert.That(() =>
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }, Throws.Nothing);
    }

    private static long ReadInteger(mpz_t rop, string text)
    {
        using MemoryStream Stream = new(Encoding.ASCII.GetBytes(text));
        using StreamReader Reader = new(Stream);

        return mpz.inp_str(rop, Reader, 10);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void CreateUnreachableNumbers()
    {
        for (int i = 0; i < 100; i++)
        {
            _ = new mpz_t(i);
            _ = new mpq_t(i, 3UL);
            _ = new mpf_t(i);
            _ = new mpfr_t(i);
            _ = mpfr_t.Pi(100);
        }
    }
}
