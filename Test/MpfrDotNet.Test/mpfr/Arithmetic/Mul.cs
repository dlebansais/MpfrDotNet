namespace Test;

using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Mul
{
    [Test]
    public void BasicMul()
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

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("4.96168970320598825787795593145394036119E+40"));

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("4.96168970320598825787795593145394036119E+40"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void MulULong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        ulong b = 8720124937520142L;

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.940313539256766794436594145729730728591E+41"));

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1.940313539256766794436594145729730728591E+41"));

        using mpfr_t e = c / a;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("8.720124937520142E+15"));

        using mpfr_t f = d / a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void MulLong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        long b = -8720124937520142L;

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-1.940313539256766794436594145729730728591E+41"));

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-1.940313539256766794436594145729730728591E+41"));

        using mpfr_t e = c / a;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        using mpfr_t f = d / a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void MulDouble()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        double b = 2229874359879827.30594288574029879874539;

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("4.961689703205988133399534573118501812429E+40"));

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("4.961689703205988133399534573118501812429E+40"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void MulInteger()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpz_t b = new mpz_t("8720124937520142");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("8720124937520142"));

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.940313539256766794436594145729730728591E+41"));

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1.940313539256766794436594145729730728591E+41"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void MulRational()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("8.397224030205635424110897549404061902283E+33"));

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("8.397224030205635424110897549404061902283E+33"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
