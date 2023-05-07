namespace Test;

using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Create
{
    [Test]
    public void CreateDefaultPrecision()
    {
        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;

        using mpfr_t a = new mpfr_t();
        Assert.That(a.Precision, Is.EqualTo(DefaultPrecision));

        mpfr.init(a);
        Assert.That(a.Precision, Is.EqualTo(DefaultPrecision));
    }

    [Test]
    public void CreateCustomPrecision()
    {
        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        ulong CustomPrecision = DefaultPrecision + 64;

        using mpfr_t a = new mpfr_t();
        Assert.That(a.Precision, Is.EqualTo(DefaultPrecision));

        mpfr.init(a);
        Assert.That(a.Precision, Is.EqualTo(DefaultPrecision));

        a.Precision = CustomPrecision;
        Assert.That(a.Precision, Is.EqualTo(CustomPrecision));

        using mpfr_t b = mpfr_t.Create(CustomPrecision);
        Assert.That(b.Precision, Is.EqualTo(CustomPrecision));

        mpfr.init(b);
        Assert.That(b.Precision, Is.EqualTo(DefaultPrecision));

        b.Precision = CustomPrecision;
        Assert.That(b.Precision, Is.EqualTo(CustomPrecision));

        mpfr_t.DefaultPrecision = CustomPrecision;

        using mpfr_t c = new mpfr_t();
        Assert.That(c.Precision, Is.EqualTo(CustomPrecision));

        mpfr.init(c);
        Assert.That(c.Precision, Is.EqualTo(CustomPrecision));

        using mpfr_t d = mpfr_t.Create(DefaultPrecision);
        Assert.That(d.Precision, Is.EqualTo(DefaultPrecision));

        mpfr.init(d);
        Assert.That(d.Precision, Is.EqualTo(CustomPrecision));

        mpfr_t.DefaultPrecision = DefaultPrecision;

        using mpfr_t e = mpfr_t.Create(DefaultPrecision);
        Assert.That(e.Precision, Is.EqualTo(DefaultPrecision));

        mpfr.init(e);
        Assert.That(e.Precision, Is.EqualTo(DefaultPrecision));

        e.Precision = CustomPrecision;
        Assert.That(e.Precision, Is.EqualTo(CustomPrecision));

        using mpfr_t f = new mpfr_t();
        Assert.That(f.Precision, Is.EqualTo(DefaultPrecision));

        mpfr.init(f);
        Assert.That(f.Precision, Is.EqualTo(DefaultPrecision));

        f.Precision = CustomPrecision;
        Assert.That(f.Precision, Is.EqualTo(CustomPrecision));
    }

    [Test]
    public void CreateFrom()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t NaN = new mpfr_t();
        AsString = NaN.ToString();
        Assert.That(AsString, Is.EqualTo("@NaN@"));

        using mpfr_t PositiveInfinite = mpfr_t.Infinite();
        AsString = PositiveInfinite.ToString();
        Assert.That(AsString, Is.EqualTo("@Inf@"));

        using mpfr_t NegativeInfinite = mpfr_t.Infinite(-1);
        AsString = NegativeInfinite.ToString();
        Assert.That(AsString, Is.EqualTo("-@Inf@"));

        using mpfr_t Zero = mpfr_t.Zero();
        AsString = Zero.ToString();
        Assert.That(AsString, Is.EqualTo("0"));

        using mpfr_t NegativeZero = mpfr_t.Zero(-1);
        AsString = NegativeZero.ToString();
        Assert.That(AsString, Is.EqualTo("-0"));

        using mpfr_t b = new mpfr_t(10);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        using mpfr_t c = new mpfr_t(b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        using mpfr_t d = new mpfr_t(100UL);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1E+2"));

        using mpfr_t e = new mpfr_t(-100L);
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-1E+2"));

        using mpfr_t f = new mpfr_t(100U);
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("1E+2"));

        using mpfr_t g = new mpfr_t(200.1F);
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("2.00100006103515625E+2"));

        using mpfr_t h = new mpfr_t(-200.1);
        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("-2.00099999999999994315658113919198513031005859375E+2"));

        using mpz_t iz = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = iz.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"));

        using mpfr_t i = new mpfr_t(iz);
        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("6.3049999653217328579866181421408313514338742205512312E+57"));

        using mpq_t jq = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = jq.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpfr_t j = new mpfr_t(jq);
        AsString = j.ToString();
        Assert.That(AsString, Is.EqualTo("1.9222151414587357044219970703125E+9"));

        using mpf_t kf = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = kf.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpfr_t k = new mpfr_t(kf);
        AsString = k.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t l = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = l.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));
    }
}
