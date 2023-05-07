namespace TestInteger.Arithmetic.Divide;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Quotient
{
    [Test]
    public void TowardZero()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("394580293847502987609283945873594873409587"));

        using mpz_t c = a.Quotient(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("593169091750307653294"));

        using mpz_t d = a.Quotient(b, Rounding.TowardZero);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("593169091750307653294"));
    }

    [Test]
    public void TowardPositiveInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("394580293847502987609283945873594873409587"));

        using mpz_t c = a.Quotient(b, Rounding.TowardPositiveInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("593169091750307653295"));
    }

    [Test]
    public void TowardNegativeInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        using mpz_t b = new mpz_t("-394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-394580293847502987609283945873594873409587"));

        using mpz_t c = a.Quotient(b, Rounding.TowardNegativeInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-593169091750307653295"));
    }

    [Test]
    public void UintTowardZero()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 17835;

        using mpz_t c = a.Quotient(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("13123231540459369447315643565110458612039422397376467955336"));

        using mpz_t d = a.Quotient(b, Rounding.TowardZero);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("13123231540459369447315643565110458612039422397376467955336"));
    }

    [Test]
    public void UintTowardPositiveInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 17835;

        using mpz_t c = a.Quotient(b, Rounding.TowardPositiveInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-13123231540459369447315643565110458612039422397376467955336"));
    }

    [Test]
    public void UintTowardNegativeInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 17835;

        using mpz_t c = a.Quotient(b, Rounding.TowardNegativeInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-13123231540459369447315643565110458612039422397376467955337"));
    }
}
