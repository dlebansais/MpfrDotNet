namespace TestInteger.Arithmetic;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Negate
{
    [Test]
    public void BasicNegate()
    {
        string AsString;

        using mpz_t a = new mpz_t("222987435987982730594288574029879874539");
        AsString = a.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        using mpz_t b = new();
        mpz.neg(b, a);

        AsString = b.ToString();
        Assert.AreEqual("-222987435987982730594288574029879874539", AsString);
    }

    [Test]
    public void NegateOperator()
    {
        string AsString;

        using mpz_t a = new mpz_t("222987435987982730594288574029879874539");
        AsString = a.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        using mpz_t b = -a;

        AsString = b.ToString();
        Assert.AreEqual("-222987435987982730594288574029879874539", AsString);
    }
}
