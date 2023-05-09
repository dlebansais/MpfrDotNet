namespace Test;

using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Add
{
    [Test]
    public void BasicAdd()
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

        using mpfr_t c = a + b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325257490419438281087997227031224E+25"));

        using mpfr_t d = b + a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325257490419438281087997227031224E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void AddULong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        ulong b = 8720124937520142UL;

        using mpfr_t c = a + b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325906515477202312557402938457199E+25"));

        using mpfr_t d = b + a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325906515477202312557402938457199E+25"));

        using mpfr_t e = c - a;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void AddLong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        long b = -8720124937520142L;

        using mpfr_t c = a + b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098324162490489698284157402938457199E+25"));

        using mpfr_t d = b + a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098324162490489698284157402938457199E+25"));

        using mpfr_t e = c - a;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void AddDouble()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        double b = 2229874359879827.30594288574029879874539;

        using mpfr_t c = a + b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325257490419438281082402938457199E+25"));

        using mpfr_t d = b + a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325257490419438281082402938457199E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void AddInteger()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpz_t b = new mpz_t("8720124937520142");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("8720124937520142"));

        using mpfr_t c = a + b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325906515477202312557402938457199E+25"));

        using mpfr_t d = b + a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325906515477202312557402938457199E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void AddRational()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        using mpfr_t c = a + b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034503021188963367073581981163E+25"));

        using mpfr_t d = b + a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034503021188963367073581981163E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
