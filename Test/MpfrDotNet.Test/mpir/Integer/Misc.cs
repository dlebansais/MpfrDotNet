namespace TestInteger;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;
using System.Text;

[TestClass]
public class Misc
{
    [TestMethod]
    public void Init2()
    {
        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");

        mpz.init2(a, 20);

        string AsString = a.ToString();
        Assert.AreEqual("0", AsString);
    }

    [TestMethod]
    public void Realloc2()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");

        mpz.realloc2(a, 2000);

        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720", AsString);

        mpz.realloc2(a, 20);

        AsString = a.ToString();
        Assert.AreEqual("0", AsString);
    }

    [TestMethod]
    public void Set()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");

        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720", AsString);

        mpz.set_ui(a, 2000);

        AsString = a.ToString();
        Assert.AreEqual("2000", AsString);

        mpz.set_si(a, -1000);

        AsString = a.ToString();
        Assert.AreEqual("-1000", AsString);

        mpz.set_ux(a, 1099511627557UL);

        AsString = a.ToString();
        Assert.AreEqual("1099511627557", AsString);

        mpz.set_sx(a, -2597542236477880L);

        AsString = a.ToString();
        Assert.AreEqual("-2597542236477880", AsString);

        mpz.set_d(a, -45487.0);

        AsString = a.ToString();
        Assert.AreEqual("-45487", AsString);

        using mpq_t q = new mpq_t(50, 1);
        mpz.set_q(a, q);

        AsString = a.ToString();
        Assert.AreEqual("50", AsString);

        using mpf_t f = new mpf_t(-80);
        mpz.set_f(a, f);

        AsString = a.ToString();
        Assert.AreEqual("-80", AsString);

        mpz.set_str(a, "445497268491433028939318409770173720259", 10);

        AsString = a.ToString();
        Assert.AreEqual("445497268491433028939318409770173720259", AsString);

        mpz.set_str(a, "FF", 16);

        AsString = a.ToString();
        Assert.AreEqual("255", AsString);

        using mpz_t b = new mpz_t("222509832503450298345029835740293845720");

        mpz.swap(a, b);

        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720", AsString);
    }

    [TestMethod]
    public void InitSet()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");

        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720", AsString);

        using mpz_t b = new mpz_t(a);

        AsString = b.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720", AsString);

        using mpz_t c = new mpz_t(20U);

        AsString = c.ToString();
        Assert.AreEqual("20", AsString);

        using mpz_t d = new mpz_t(-20);

        AsString = d.ToString();
        Assert.AreEqual("-20", AsString);

        using mpz_t e = new mpz_t(1099511627557);

        AsString = e.ToString();
        Assert.AreEqual("1099511627557", AsString);

        using mpz_t f = new mpz_t(-2597542236477880L);

        AsString = f.ToString();
        Assert.AreEqual("-2597542236477880", AsString);

        using mpz_t g = new mpz_t(896.0);

        AsString = g.ToString();
        Assert.AreEqual("896", AsString);

        using mpz_t h = new mpz_t("FF", 16);

        AsString = h.ToString();
        Assert.AreEqual("255", AsString);
    }

    [TestMethod]
    public void Get()
    {
        using mpz_t a = new mpz_t();

        mpz.set_ui(a, 2000U);
        Assert.AreEqual(mpz.get_ui(a), 2000U);

        mpz.set_si(a, -1000);
        Assert.AreEqual(mpz.get_si(a), -1000);

        mpz.set_ux(a, 1099511627557UL);
        Assert.AreEqual(mpz.get_ux(a), 1099511627557UL);

        mpz.set_sx(a, -2597542236477880L);
        Assert.AreEqual(mpz.get_sx(a), -2597542236477880L);

        mpz.set_d(a, -45487.0);
        Assert.AreEqual(mpz.get_d(a), -45487.0);

        mpz.get_d_2exp(a, out double d, out long exp);
        Assert.AreEqual(d, -0.6940765380859375);
        Assert.AreEqual(exp, 16L);

        StringBuilder str = new();
        mpz.get_str(str, 10, a);

        string AsString = str.ToString();
        Assert.AreEqual("-45487", AsString);
    }
}
