namespace TestFloating;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;

[TestClass]
public class Sub
{
    [TestMethod]
    public void BasicSub()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982730594E+15", AsString);

        using mpf_t c = new();
        mpf.sub(c, a, b);

        AsString = c.ToString();
        Assert.AreEqual("2.22509832481151554746E+25", AsString);
    }

    [TestMethod]
    public void SubOperator()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982730594E+15", AsString);

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.AreEqual("2.22509832481151554746E+25", AsString);
    }

    [TestMethod]
    public void SubUint()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        uint b = 98873014;

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.AreEqual("2.22509832503450297356E+25", AsString);
    }

    [TestMethod]
    public void UintSub()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        uint b = 98873014;

        using mpf_t c = b - a;

        AsString = c.ToString();
        Assert.AreEqual("-2.22509832503450297356E+25", AsString);
    }

    [TestMethod]
    public void SubIntPositive()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        int b = 98873014;

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.AreEqual("2.22509832503450297356E+25", AsString);
    }

    [TestMethod]
    public void SubIntNegative()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        int b = -98873014;

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.AreEqual("2.22509832503450299334E+25", AsString);
    }
}
