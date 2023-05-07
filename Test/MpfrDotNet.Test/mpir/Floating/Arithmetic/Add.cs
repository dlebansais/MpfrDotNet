namespace TestFloating;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Add
{
    [Test]
    public void BasicAdd()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982730594E+15", AsString);

        using mpf_t c = new();
        mpf.add(c, a, b);

        AsString = c.ToString();
        Assert.AreEqual("2.22509832525749041944E+25", AsString);
    }

    [Test]
    public void AddOperator()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982730594E+15", AsString);

        using mpf_t c = a + b;

        AsString = c.ToString();
        Assert.AreEqual("2.22509832525749041944E+25", AsString);
    }

    [Test]
    public void AddUint()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        uint b = 98873014;

        using mpf_t c = a + b;

        AsString = c.ToString();
        Assert.AreEqual("2.22509832503450299334E+25", AsString);
    }

    [Test]
    public void AddIntPositive()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        int b = 98873014;

        using mpf_t c = a + b;

        AsString = c.ToString();
        Assert.AreEqual("2.22509832503450299334E+25", AsString);
    }

    [Test]
    public void AddIntNegative()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        int b = -98873014;

        using mpf_t c = a + b;

        AsString = c.ToString();
        Assert.AreEqual("2.22509832503450297356E+25", AsString);
    }
}
