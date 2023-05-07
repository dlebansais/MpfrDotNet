namespace TestFloating;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Mul
{
    [Test]
    public void BasicMul()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        using mpf_t c = new();
        mpf.mul(c, a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("4.96168970320598825788E+40"));
    }

    [Test]
    public void MulOperator()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        using mpf_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("4.96168970320598825788E+40"));
    }

    [Test]
    public void MulUint()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        uint b = 98873014;

        using mpf_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.20002177842512963966E+33"));
    }

    [Test]
    public void MulIntPositive()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        int b = 98873014;

        using mpf_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.20002177842512963966E+33"));
    }

    [Test]
    public void MulIntNegative()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        int b = -98873014;

        using mpf_t c = a * b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-2.20002177842512963966E+33"));
    }
}
