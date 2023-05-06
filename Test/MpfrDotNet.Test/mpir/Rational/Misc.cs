namespace TestRational;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;

[TestClass]
public class Misc
{
    [TestMethod]
    public void Create()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        using mpq_t b = new mpq_t(a);
        AsString = b.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        using mpq_t c = new(a.GetNumerator());
        AsString = c.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720", AsString);

        using mpq_t d = new(30, 10);
        AsString = d.ToString();
        Assert.AreEqual("30/10", AsString);

        using mpq_t e = new(30, 10, true);
        AsString = e.ToString();
        Assert.AreEqual("3", AsString);

        using mpq_t f = new(-30, 10);
        AsString = f.ToString();
        Assert.AreEqual("-30/10", AsString);

        using mpq_t g = new(-30, 10, true);
        AsString = g.ToString();
        Assert.AreEqual("-3", AsString);

        using mpq_t h = new(0.25);
        AsString = h.ToString();
        Assert.AreEqual("1/4", AsString);

        using mpz_t n0 = new mpz_t("222509832503450298345029835740293845720");
        using mpz_t d0 = new mpz_t("115756986668303657898962467957");
        using mpq_t q0 = new mpq_t(n0, d0);
        AsString = q0.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);
    }
}
