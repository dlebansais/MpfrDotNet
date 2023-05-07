namespace TestInteger.Arithmetic;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Abs
{
    [Test]
    public void BasicAbs()
    {
        string AsString;

        using mpz_t a = new mpz_t("222987435987982730594288574029879874539");
        AsString = a.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        using mpz_t b = new mpz_t("-445497268491433028939318409770173720259");
        AsString = b.ToString();
        Assert.AreEqual("-445497268491433028939318409770173720259", AsString);

        using mpz_t c = new();
        mpz.abs(c, a);

        AsString = c.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        using mpz_t d = new();
        mpz.abs(d, b);

        AsString = d.ToString();
        Assert.AreEqual("445497268491433028939318409770173720259", AsString);
    }

    [Test]
    public void AbsOperator()
    {
        string AsString;

        using mpz_t a = new mpz_t("222987435987982730594288574029879874539");
        AsString = a.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        using mpz_t b = new mpz_t("-445497268491433028939318409770173720259");
        AsString = b.ToString();
        Assert.AreEqual("-445497268491433028939318409770173720259", AsString);

        using mpz_t c = a.Abs();

        AsString = c.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        using mpz_t d = b.Abs();

        AsString = d.ToString();
        Assert.AreEqual("445497268491433028939318409770173720259", AsString);
    }
}
