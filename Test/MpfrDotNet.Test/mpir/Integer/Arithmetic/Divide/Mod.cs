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
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("394580293847502987609283945873594873409587"));

        using mpz_t c = a % b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("114368714235760586972822754176083531704767"));
    }

    [Test]
    public void IntMod()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        int b = 5486219;

        using mpz_t c = a % b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1573091"));
    }

    [Test]
    public void UIntMod()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 5486219;

        using mpz_t c = a % b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1573091"));
    }
}
