namespace Test;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MpfrDotNet;
using NUnit.Framework;

[TestFixture]
public class Misc
{
    [Test]
    public void Version()
    {
        string AsString;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        AsString = mpfr.get_version();

        // Elsewhere than on Windows, MPFR is the system library, with its own version and build options.
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Assert.That(AsString, Does.StartWith("4."));
            return;
        }

        Assert.That(AsString, Is.EqualTo("4.2.1-dev"));

        AsString = mpfr.get_patches();
        Assert.That(AsString, Is.EqualTo(""));

        Assert.That(mpfr.buildopt_tls_p(), Is.True);
        Assert.That(mpfr.buildopt_float128_p(), Is.False);
        Assert.That(mpfr.buildopt_decimal_p(), Is.False);
        Assert.That(mpfr.buildopt_gmpinternals_p(), Is.True);
        Assert.That(mpfr.buildopt_sharedcache_p(), Is.False);

        AsString = mpfr.buildopt_tune_case();
        Assert.That(AsString, Is.EqualTo("src/x86_64/corei5/mparam.h"));
    }

    [Test]
    public void MiscNext()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        using mpfr_t a = new();
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("@NaN@"));

        using mpfr_t b = mpfr_t.Infinite();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("@Inf@"));

        mpfr.nexttoward(b, a);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("@NaN@"));

        mpfr.nextabove(b);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("@NaN@"));

        mpfr.nextbelow(b);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("@NaN@"));
    }

    [Test]
    public void MinMax()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = mpfr_t.Min(a, b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t d = mpfr_t.Max(a, b);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Precision()
    {
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        Assert.That(mpfr_t.DefaultPrecisionInit, Is.EqualTo(53));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t x = new(0);

        Assert.That(x.MinPrecision, Is.EqualTo(1));
        Assert.That(x.MaxPrecision, Is.EqualTo(Sample.IsWindows ? 0x7FFFFEFFUL : 0x7FFFFFFFFFFFFEFFUL));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Swap()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t x = new("-22250983250345029834502983.5740293845720");
        AsString = x.ToString();
        Assert.That(AsString, Is.EqualTo("-2.225098325034502983450298357402938457199E+25"));

        using mpfr_t y = new("2229874359879827.30594288574029879874539");
        AsString = y.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        mpfr_t.Swap(x, y);

        AsString = x.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        AsString = y.ToString();
        Assert.That(AsString, Is.EqualTo("-2.225098325034502983450298357402938457199E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ToFormattedString()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t x = new("22250983250345029834502983.5740293845720");
        AsString = x.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        string Result;

        Result = x.ToFormattedString("%Rf");
        Assert.That(Result, Is.EqualTo("22250983250345029834502983.574029"));

        Result = x.ToFormattedString(10, "%Rf");
        Assert.That(Result, Is.EqualTo("222509832"));

        // The 33 characters fit exactly in a buffer of 34, with the terminating null character, but not in a buffer of 33.
        Result = x.ToFormattedString(34, "%Rf");
        Assert.That(Result, Is.EqualTo("22250983250345029834502983.574029"));

        Result = x.ToFormattedString(33, "%Rf");
        Assert.That(Result, Is.EqualTo("22250983250345029834502983.57402"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Finalizer()
    {
        // Objects left undisposed by other tests are finalized first, so that they don't change the count below.
        GC.Collect();
        GC.WaitForPendingFinalizers();
        ulong CountBefore = mpfr_t.LiveObjectCount();

        CreateUnreachableForFinalizer();
        ulong CountWithObject = mpfr_t.LiveObjectCount();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        ulong CountAfter = mpfr_t.LiveObjectCount();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(CountWithObject, Is.EqualTo(CountBefore + 1));
        Assert.That(CountAfter, Is.EqualTo(CountBefore));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void CreateUnreachableForFinalizer()
    {
        // The object is not disposed: its finalizer must release it.
        _ = new mpfr_t("22250983250345029834502983.5740293845720");
    }
}
