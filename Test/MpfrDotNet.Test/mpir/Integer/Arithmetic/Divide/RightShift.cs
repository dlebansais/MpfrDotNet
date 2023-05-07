namespace TestInteger.Arithmetic.Divide;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class RightShift
{
    [Test]
    public void ShiftTowardZero()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 40;

        using mpz_t c = a.RightShift(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("212869812934598352597162832338422076050595113390235"));

        using mpz_t d = a.RightShift(b, Rounding.TowardZero);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("212869812934598352597162832338422076050595113390235"));
    }

    [Test]
    public void ShiftTowardPositiveInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 40;

        using mpz_t c = a.RightShift(b, Rounding.TowardPositiveInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-212869812934598352597162832338422076050595113390235"));
    }

    [Test]
    public void ShiftTowardNegativeInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 40;

        using mpz_t c = a.RightShift(b, Rounding.TowardNegativeInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-212869812934598352597162832338422076050595113390236"));
    }

    [Test]
    public void ShiftRemainderTowardZero()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 40;

        using mpz_t c = a.RightShiftRemainder(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("727230266985"));

        using mpz_t d = a.RightShiftRemainder(b, Rounding.TowardZero);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("727230266985"));
    }

    [Test]
    public void ShiftRemainderTowardPositiveInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 40;

        using mpz_t c = a.RightShiftRemainder(b, Rounding.TowardPositiveInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-727230266985"));
    }

    [Test]
    public void ShiftRemainderTowardNegativeInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 40;

        using mpz_t c = a.RightShiftRemainder(b, Rounding.TowardNegativeInfinity);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("372281360791"));
    }
}
