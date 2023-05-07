namespace TestInteger.Arithmetic.Divide;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Remainder
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

        using mpz_t c = a.Remainder(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("114368714235760586972822754176083531704767"));

        using mpz_t d = a.Remainder(b, Rounding.TowardZero);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("114368714235760586972822754176083531704767"));
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

        using mpz_t c = a.Remainder(b, Rounding.TowardPositiveInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-280211579611742400636461191697511341704820"));
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

        using mpz_t c = a.Remainder(b, Rounding.TowardNegativeInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-280211579611742400636461191697511341704820"));
    }

    [Test]
    public void UintTowardZero()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 17835;

        using mpz_t c = a.Remainder(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("16785"));

        using mpz_t d = a.Remainder(b, Rounding.TowardZero);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("16785"));
    }

    [Test]
    public void UintTowardPositiveInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 17835;

        using mpz_t c = a.Remainder(b, Rounding.TowardPositiveInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-16785"));
    }

    [Test]
    public void UintTowardNegativeInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 17835;

        using mpz_t c = a.Remainder(b, Rounding.TowardNegativeInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1050"));
    }

    [Test]
    public void FastUintTowardZero()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        ulong b = 17835;

        ulong c = a.AbsRemainder(b);

        Assert.That(c, Is.EqualTo(16785U));

        ulong d = a.AbsRemainder(b, Rounding.TowardZero);

        Assert.That(d, Is.EqualTo(16785U));
    }

    [Test]
    public void FastUintTowardPositiveInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        ulong b = 17835;

        ulong c = a.AbsRemainder(b, Rounding.TowardPositiveInfinity);

        Assert.That(c, Is.EqualTo(16785U));
    }

    [Test]
    public void FastUintTowardNegativeInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        ulong b = 17835;

        ulong c = a.AbsRemainder(b, Rounding.TowardNegativeInfinity);

        AsString = c.ToString();
        Assert.That(c, Is.EqualTo(1050U));
    }
}
