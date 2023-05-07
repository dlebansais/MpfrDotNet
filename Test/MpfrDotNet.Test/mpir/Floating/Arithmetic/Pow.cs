namespace TestFloating;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Pow
{
    [Test]
    public void BasicPow()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        uint b = 89;

        using mpf_t c = a.Pow(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("8.20501550859436020769E+2255"));
    }
}
