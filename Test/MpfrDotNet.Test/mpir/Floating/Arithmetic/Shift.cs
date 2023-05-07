namespace TestFloating;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Shift
{
    [Test]
    public void LeftShift()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        int b = 50;

        using mpf_t c = a << b;

        AsString = c.ToString();
        Assert.AreEqual("2.50523799687202560686E+40", AsString);
    }

    [Test]
    public void RightShift()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        int b = 50;

        using mpf_t c = a >> b;

        AsString = c.ToString();
        Assert.AreEqual("1.97628431400654046208E+10", AsString);
    }
}
