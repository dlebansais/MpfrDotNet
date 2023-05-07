namespace TestInteger.Arithmetic;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class PowerMod
{
    [Test]
    public void BasicPowerMod()
    {
        string AsString;

        using mpz_t a = new mpz_t("2835698356928736487698769283645293409781234");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2835698356928736487698769283645293409781234"));

        using mpz_t b = new mpz_t("3");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("3"));

        using mpz_t c = new mpz_t("9786459872639458729387304958673243509870923452745892673402935742456");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9786459872639458729387304958673243509870923452745892673402935742456"));

        mpz_t d = new();
        mpz.powm(d, a, b, c);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("5346078446724436806099093819990997994355321605000165187447171753448"));
    }

    [Test]
    public void PowerModUint()
    {
        string AsString;

        using mpz_t a = new mpz_t("2835698356928736487698769283645293409781234");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2835698356928736487698769283645293409781234"));

        using mpz_t c = new mpz_t("9786459872639458729387304958673243509870923452745892673402935742456");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9786459872639458729387304958673243509870923452745892673402935742456"));

        mpz_t d = new();
        mpz.powm_ui(d, a, 3, c);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("5346078446724436806099093819990997994355321605000165187447171753448"));
    }
}
