namespace TestInteger.Arithmetic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;

[TestClass]
public class PowerMod
{
    [TestMethod]
    public void BasicPowerMod()
    {
        string AsString;

        using mpz_t a = new mpz_t("2835698356928736487698769283645293409781234");
        AsString = a.ToString();
        Assert.AreEqual("2835698356928736487698769283645293409781234", AsString);

        using mpz_t b = new mpz_t("3");
        AsString = b.ToString();
        Assert.AreEqual("3", AsString);

        using mpz_t c = new mpz_t("9786459872639458729387304958673243509870923452745892673402935742456");
        AsString = c.ToString();
        Assert.AreEqual("9786459872639458729387304958673243509870923452745892673402935742456", AsString);

        mpz_t d = new();
        mpz.powm(d, a, b, c);

        AsString = d.ToString();
        Assert.AreEqual("5346078446724436806099093819990997994355321605000165187447171753448", AsString);
    }

    [TestMethod]
    public void PowerModUint()
    {
        string AsString;

        using mpz_t a = new mpz_t("2835698356928736487698769283645293409781234");
        AsString = a.ToString();
        Assert.AreEqual("2835698356928736487698769283645293409781234", AsString);

        using mpz_t c = new mpz_t("9786459872639458729387304958673243509870923452745892673402935742456");
        AsString = c.ToString();
        Assert.AreEqual("9786459872639458729387304958673243509870923452745892673402935742456", AsString);

        mpz_t d = new();
        mpz.powm_ui(d, a, 3, c);

        AsString = d.ToString();
        Assert.AreEqual("5346078446724436806099093819990997994355321605000165187447171753448", AsString);
    }
}
