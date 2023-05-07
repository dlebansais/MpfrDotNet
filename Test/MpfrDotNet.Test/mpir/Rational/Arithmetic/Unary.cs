namespace TestRational;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Unary
{
    [Test]
    public void Abs()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = a.Abs();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t c = new mpq_t("-222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t d = c.Abs();
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));
    }

    [Test]
    public void Neg()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = -a;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t c = -b;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));
    }

    [Test]
    public void Inverse()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = a.Inverse();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("115756986668303657898962467957/222509832503450298345029835740293845720"));

        using mpq_t c = b.Inverse();
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));
    }
}
