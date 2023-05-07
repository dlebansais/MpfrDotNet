namespace TestInteger.Arithmetic.Divide;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Divisible
{
    [Test]
    public void BasicDivisible()
    {
        string AsString;
        bool IsDivisible;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305981001312");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305981001312"));

        using mpz_t b = new mpz_t("7879512");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("7879512"));

        IsDivisible = a.IsDivisible(b);

        Assert.IsTrue(IsDivisible);

        using mpz_t c = new mpz_t("234052834524092854092874502983745029345723098457209305981001313");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305981001313"));

        IsDivisible = c.IsDivisible(b);

        Assert.IsFalse(IsDivisible);
    }

    [Test]
    public void UIntDivisible()
    {
        string AsString;
        bool IsDivisible;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305981001312");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305981001312"));

        uint b = 7879512;

        IsDivisible = a.IsDivisible(b);

        Assert.IsTrue(IsDivisible);

        using mpz_t c = new mpz_t("234052834524092854092874502983745029345723098457209305981001313");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305981001313"));

        IsDivisible = c.IsDivisible(b);

        Assert.IsFalse(IsDivisible);
    }

    [Test]
    public void PowerOfTwo()
    {
        string AsString;
        bool IsPowerOfTwo;

        using mpz_t a = new mpz_t("1469173453763354882559192244087019945625587460526840817796261548873716634847271117995592099642442006254754691244256919552");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1469173453763354882559192244087019945625587460526840817796261548873716634847271117995592099642442006254754691244256919552"));

        uint b = 192;

        IsPowerOfTwo = a.IsDivisibleByPowerOfTwo(b);

        Assert.IsTrue(IsPowerOfTwo);

        using mpz_t c = new mpz_t("234052834524092854092874502983745029345723098457209305981001313");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305981001313"));

        IsPowerOfTwo = c.IsDivisibleByPowerOfTwo(b);

        Assert.IsFalse(IsPowerOfTwo);
    }
}
