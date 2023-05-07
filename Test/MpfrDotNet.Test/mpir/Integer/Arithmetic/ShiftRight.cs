namespace TestInteger.Arithmetic;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class ShiftRight
{
    [Test]
    public void BasicShiftRight()
    {
        string AsString;

        using mpz_t a = new mpz_t("222987435987982730594288574029879874539");
        AsString = a.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        uint ShiftAmount = 40;

        using mpz_t b = new();
        mpz.tdiv_q_2exp(b, a, ShiftAmount);

        AsString = b.ToString();
        Assert.AreEqual("202805891593000279130400098", AsString);
    }

    [Test]
    public void ShiftRightOperator()
    {
        string AsString;

        using mpz_t a = new mpz_t("222987435987982730594288574029879874539");
        AsString = a.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539", AsString);

        int Count = 40;

        using mpz_t b = a >> Count;

        AsString = b.ToString();
        Assert.AreEqual("202805891593000279130400098", AsString);
    }
}
