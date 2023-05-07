namespace Test;

using MpfrDotNet;
using NUnit.Framework;

[TestFixture]
public class Misc
{
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

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982725E+15"));

        using mpfr_t c = mpfr_t.Min(a, b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982725E+15"));

        using mpfr_t d = mpfr_t.Max(a, b);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));
    }

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
}
