namespace TestFloating;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Sqrt
{
    [Test]
    public void BasicSqrt()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = a.Sqrt();

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("4.71709478920500704353E+12"));
    }
}
