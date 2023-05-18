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
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539"));

        uint ShiftAmount = 40;

        using mpz_t b = new();
        mpz.tdiv_q_2exp(b, a, ShiftAmount);

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("202805891593000279130400098"));
    }

    [Test]
    public void ShiftRightOperator()
    {
        string AsString;

        using mpz_t a = new mpz_t("222987435987982730594288574029879874539");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539"));

        int Count = 40;

        using mpz_t b = a >> Count;

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("202805891593000279130400098"));

        using mpz_t c = a >> -Count;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("0"));
    }
}
