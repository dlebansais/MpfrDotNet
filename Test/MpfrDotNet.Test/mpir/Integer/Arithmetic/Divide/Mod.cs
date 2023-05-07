namespace TestInteger.Arithmetic.Divide;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Mod
{
    [Test]
    public void BasicMod()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

        using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.AreEqual("394580293847502987609283945873594873409587", AsString);

        using mpz_t c = a % b;

        AsString = c.ToString();
        Assert.AreEqual("114368714235760586972822754176083531704767", AsString);
    }

    [Test]
    public void IntMod()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

        int b = 5486219;

        using mpz_t c = a % b;

        AsString = c.ToString();
        Assert.AreEqual("1573091", AsString);
    }

    [Test]
    public void UIntMod()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

        uint b = 5486219;

        using mpz_t c = a % b;

        AsString = c.ToString();
        Assert.AreEqual("1573091", AsString);
    }
}
