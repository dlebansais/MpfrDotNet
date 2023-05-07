namespace TestInteger.Arithmetic;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class ShiftLeft
{
    [Test]
    public void BasicShiftLeft()
    {
        string AsString;

        using mpz_t a = new mpz_t("222987435987982730594288574029879874539");
        AsString = a.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        uint ShiftAmount = 40;

        using mpz_t b = new();
        mpz.mul_2exp(b, a, ShiftAmount);

        AsString = b.ToString();
        Assert.AreEqual("245177278716743494890303505880271100916118547595264", AsString);
    }

    [Test]
    public void ShiftLeftOperator()
    {
        string AsString;

        using mpz_t a = new mpz_t("222987435987982730594288574029879874539");
        AsString = a.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        int Count = 40;

        using mpz_t b = a << Count;

        AsString = b.ToString();
        Assert.AreEqual("245177278716743494890303505880271100916118547595264", AsString);
    }
}
