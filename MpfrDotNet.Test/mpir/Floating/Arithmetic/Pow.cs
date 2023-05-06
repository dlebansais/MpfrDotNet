namespace TestFloating;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;

[TestClass]
public class Pow
{
    [TestMethod]
    public void BasicPow()
    {
        string AsString;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.22509832503450298345E+25", AsString);

        uint b = 89;

        using mpf_t c = a.Pow(b);

        AsString = c.ToString();
        Assert.AreEqual("8.20501550859436020769E+2255", AsString);
    }
}
