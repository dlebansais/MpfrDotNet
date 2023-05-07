namespace TestFloating;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Div
{
    [Test]
    public void BasicDiv()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        using mpf_t c = new();
        mpf.div(c, a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9.97858159665290867233E+9"));
    }

    [Test]
    public void DivOperator()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        using mpf_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9.97858159665290867233E+9"));
    }

    [Test]
    public void DivUint()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        uint b = 98873014;

        using mpf_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.25046070208247417587E+17"));
    }

    [Test]
    public void UintDiv()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        uint b = 98873014;

        using mpf_t c = b / a;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("4.44353460193570762729E-18"));
    }

    [Test]
    public void DivIntPositive()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        int b = 98873014;

        using mpf_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.25046070208247417587E+17"));
    }

    [Test]
    public void DivIntNegative()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        int b = -98873014;

        using mpf_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-2.25046070208247417587E+17"));
    }
}
