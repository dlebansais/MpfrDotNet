namespace TestInteger.Arithmetic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;

[TestClass]
public class Negate
{
    [TestMethod]
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

    [TestMethod]
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
