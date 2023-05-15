namespace Test;

using MpfrDotNet;
using NUnit.Framework;

[TestFixture]
public class Rounding
{
    [Test]
    public void DefaultRounding()
    {
        mpfr_rnd_t OldDefault = mpfr_t.DefaultRoundingMode;

        mpfr_t.DefaultRoundingMode = mpfr_rnd_t.MPFR_RNDZ;
        Assert.That(mpfr_t.DefaultRoundingMode, Is.EqualTo(mpfr_rnd_t.MPFR_RNDZ));

        mpfr_t.DefaultRoundingMode = OldDefault;
    }

    [Test]
    public void BasicRounding()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.RoundToInteger(mpfr_rnd_t.MPFR_RNDZ);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983E+25"));

        using mpfr_t c = a.Ceil();
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502984E+25"));

        using mpfr_t d = a.Floor();
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983E+25"));

        using mpfr_t e = a.Round();
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502984E+25"));

        using mpfr_t f = a.RoundEven();
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502984E+25"));

        using mpfr_t g = a.Trunc();
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983E+25"));

        using mpfr_t h = a.Ceil(mpfr_rnd_t.MPFR_RNDD);
        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502984E+25"));

        using mpfr_t i = a.Floor(mpfr_rnd_t.MPFR_RNDD);
        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983E+25"));

        using mpfr_t j = a.Round(mpfr_rnd_t.MPFR_RNDD);
        AsString = j.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502984E+25"));

        using mpfr_t k = a.RoundEven(mpfr_rnd_t.MPFR_RNDD);
        AsString = k.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502984E+25"));

        using mpfr_t l = a.Trunc(mpfr_rnd_t.MPFR_RNDD);
        AsString = l.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983E+25"));

        using mpfr_t m = a.Fractional(mpfr_rnd_t.MPFR_RNDD);
        AsString = m.ToString();
        Assert.That(AsString, Is.EqualTo("5.74029384571986156515777111053466796875E-1"));

        mpfr_t Integer;
        mpfr_t Fractional;
        a.IntegerAndFractional(out Integer, out Fractional);

        AsString = Integer.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983E+25"));

        AsString = Fractional.ToString();
        Assert.That(AsString, Is.EqualTo("5.74029384571986156515777111053466796875E-1"));

        Integer.Dispose();
        Fractional.Dispose();

        a.RoundWithPrecision(10, mpfr_rnd_t.MPFR_RNDN);
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.2252E+25"));

        bool CanRound = a.CanRound(2, mpfr_rnd_t.MPFR_RNDZ, mpfr_rnd_t.MPFR_RNDZ, DefaultPrecision);
        Assert.That(CanRound, Is.False);

        int MinSignificandPrecision = a.MinSignificandPrecision;
        Assert.That(MinSignificandPrecision, Is.EqualTo(10));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void FMod()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = mpfr_t.FMod(a, b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.455904307763042498752955870300976687446E+15"));

        ulong ui = 2229874359879827;
        long Quotient;

        using mpfr_t d = mpfr_t.FMod(a, ui);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1.455907360639091574029384571986156515777E+15"));

        using mpfr_t e = mpfr_t.FMod(a, b, out Quotient);
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("1.455904307763042498752955870300976687446E+15"));
        Assert.That(Quotient, Is.EqualTo(1388647004));

        using mpfr_t f = mpfr_t.Remainder(a, b);
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-7.739700521167848071899298699978220579464E+14"));

        using mpfr_t g = mpfr_t.Remainder(a, b, out Quotient);
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("-7.739700521167848071899298699978220579464E+14"));
        Assert.That(Quotient, Is.EqualTo(1388647005));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Print()
    {
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        string AsString = mpfr.print_rnd_mode(mpfr_rnd_t.MPFR_RNDZ);
        Assert.That(AsString, Is.EqualTo("MPFR_RNDZ"));
    }
}
