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

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982725E+15", AsString);

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.AreEqual("4.9616897032059879565970564633632694075392E+40", AsString);

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.AreEqual("4.9616897032059879565970564633632694075392E+40", AsString);
    }

    [Test]
    public void MulULong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.2250983250345029834502983574029384571986156515777111053466796875E+25", AsString);

        ulong b = 8720124937520142L;

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.AreEqual("1.94031353925676679443659414572973072859136E+41", AsString);

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.AreEqual("1.94031353925676679443659414572973072859136E+41", AsString);

        using mpfr_t e = c / a;

        AsString = e.ToString();
        Assert.AreEqual("8.720124937520142E+15", AsString);

        using mpfr_t f = d / a;

        AsString = f.ToString();
        Assert.AreEqual("8.720124937520142E+15", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void MulLong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.2250983250345029834502983574029384571986156515777111053466796875E+25", AsString);

        long b = -8720124937520142L;

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.AreEqual("-1.94031353925676679443659414572973072859136E+41", AsString);

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.AreEqual("-1.94031353925676679443659414572973072859136E+41", AsString);

        using mpfr_t e = c / a;

        AsString = e.ToString();
        Assert.AreEqual("-8.720124937520142E+15", AsString);

        using mpfr_t f = d / a;

        AsString = f.ToString();
        Assert.AreEqual("-8.720124937520142E+15", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void MulDouble()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        double b = 2229874359879827.30594288574029879874539;

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.AreEqual("4.9616897032059879565970564633632694075392E+40", AsString);

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.AreEqual("4.9616897032059879565970564633632694075392E+40", AsString);
    }

    [Test]
    public void MulInteger()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpz_t b = new mpz_t("8720124937520142");
        AsString = b.ToString();
        Assert.AreEqual("8720124937520142", AsString);

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.AreEqual("1.94031353925676656800475953694860722044928E+41", AsString);

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.AreEqual("1.94031353925676656800475953694860722044928E+41", AsString);
    }

    [Test]
    public void MulRational()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

        using mpfr_t c = a * b;

        AsString = c.ToString();
        Assert.AreEqual("8.397224030205634932062496799850496E+33", AsString);

        using mpfr_t d = b * a;

        AsString = d.ToString();
        Assert.AreEqual("8.397224030205634932062496799850496E+33", AsString);
    }
}
