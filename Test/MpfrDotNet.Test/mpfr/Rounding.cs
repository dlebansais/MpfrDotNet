namespace Test;

using Interop.Mpfr;
using MpfrDotNet;
using NUnit.Framework;

[TestFixture]
public class Rounding
{
    [Test]
    public void BasicRounding()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t b = a.RoundToInteger(mpfr_rnd_t.MPFR_RNDZ);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t c = a.Ceil();
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t d = a.Floor();
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t e = a.Round();
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t f = a.RoundEven();
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t g = a.Trunc();
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));
    }

    [Test]
    public void Print()
    {
        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        string AsString = mpfr.print_rnd_mode(mpfr_rnd_t.MPFR_RNDZ);
        Assert.That(AsString, Is.EqualTo("MPFR_RNDZ"));
    }
}
