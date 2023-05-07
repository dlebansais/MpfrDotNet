namespace TestInteger.Arithmetic.Divide;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class DivExact
{
    [Test]
    public void BasicDivExact()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305981001312");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305981001312"));

        using mpz_t b = new mpz_t("7879512");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("7879512"));

        using mpz_t c = a.DivExact(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("29703975896488621895984739027460714489136268649277938276"));

        using mpz_t d = b * c;
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305981001312"));
    }

    [Test]
    public void UIntDivExact()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305981001312");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305981001312"));

        uint b = 7879512;

        using mpz_t c = a.DivExact(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("29703975896488621895984739027460714489136268649277938276"));

        using mpz_t d = b * c;
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305981001312"));
    }
}
