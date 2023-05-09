namespace Test;

using MpfrDotNet;
using NUnit.Framework;

[TestFixture]
public class Misc
{
    [Test]
    public void Version()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        AsString = mpfr.get_version();
        Assert.That(AsString, Is.EqualTo("4.2.1-dev"));

        AsString = mpfr.get_patches();
        Assert.That(AsString, Is.EqualTo(""));

        Assert.IsTrue(mpfr.buildopt_tls_p());
        Assert.IsFalse(mpfr.buildopt_float128_p());
        Assert.IsFalse(mpfr.buildopt_decimal_p());
        Assert.IsTrue(mpfr.buildopt_gmpinternals_p());
        Assert.IsFalse(mpfr.buildopt_sharedcache_p());

        AsString = mpfr.buildopt_tune_case();
        Assert.That(AsString, Is.EqualTo("src/x86_64/corei5/mparam.h"));
    }

    [Test]
    public void MiscNext()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

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

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
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
    public void Swap()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t x = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = x.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t y = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = y.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        mpfr_t.Swap(x, y);

        AsString = x.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        AsString = y.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ToFormattedString()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t x = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = x.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        string Result;

        Result = x.ToFormattedString("%Rf");
        Assert.That(Result, Is.EqualTo("22250983250345029834502983.574029"));

        Result = x.ToFormattedString(10, "%Rf");
        Assert.That(Result, Is.EqualTo("222509832"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
