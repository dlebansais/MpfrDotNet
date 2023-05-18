namespace TestRational;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Conversion
{
    [Test]
    public void FloatingPoint()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = (mpq_t)1.0F;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1"));

        using mpq_t c = (mpq_t)1.0;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1"));

        float f = (float)b;
        Assert.That(f, Is.EqualTo(1.0F));

        double d = (double)c;
        Assert.That(d, Is.EqualTo(1.0));
    }
}
