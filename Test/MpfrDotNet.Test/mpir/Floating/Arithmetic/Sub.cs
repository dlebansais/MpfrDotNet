namespace TestFloating;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Sub
{
    [Test]
    public void BasicSub()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        using mpf_t c = new();
        mpf.sub(c, a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832481151554746E+25"));
    }

    [Test]
    public void SubOperator()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832481151554746E+25"));
    }

    [Test]
    public void SubUint()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        uint b = 98873014U;

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450297356E+25"));
    }

    [Test]
    public void UintSub()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        uint b = 98873014U;

        using mpf_t c = b - a;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-2.22509832503450297356E+25"));
    }

    [Test]
    public void SubIntPositive()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        int b = 98873014;

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450297356E+25"));
    }

    [Test]
    public void SubIntNegative()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        int b = -98873014;

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450299334E+25"));
    }

    [Test]
    public void SubUlong()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        ulong b = 98873014UL;

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450297356E+25"));

        using mpf_t d = b - a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-2.22509832503450297356E+25"));
    }

    [Test]
    public void SubLongPositive()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        long b = 98873014L;

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450297356E+25"));

        using mpf_t d = b - a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-2.22509832503450297356E+25"));
    }

    [Test]
    public void SubLongNegative()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        long b = -98873014L;

        using mpf_t c = a - b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450299334E+25"));

        using mpf_t d = b - a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-2.22509832503450299334E+25"));
    }
}
