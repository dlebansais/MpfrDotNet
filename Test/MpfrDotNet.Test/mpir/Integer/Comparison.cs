namespace TestInteger;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;
using System.Text;

[TestClass]
public class Comparison
{
    [TestMethod]
    public void GreaterThan()
    {
        string AsString;
        bool IsGreaterThan;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.AreEqual("622288097498926496141095869268883999563096063592498055290461", AsString);

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.AreEqual("622288097498926496141095869268883999563096063592498055290460", AsString);

        IsGreaterThan = a > b;
        Assert.IsTrue(IsGreaterThan);

        double d = 50.0;

        IsGreaterThan = a > d;
        Assert.IsTrue(IsGreaterThan);

        int n = 50;

        IsGreaterThan = a > n;
        Assert.IsTrue(IsGreaterThan);

        uint p = 50U;

        IsGreaterThan = a > p;
        Assert.IsTrue(IsGreaterThan);
    }

    [TestMethod]
    public void CompareAbs()
    {
        string AsString;
        bool IsGreaterThan;

        using mpz_t a = new mpz_t("-622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.AreEqual("-622288097498926496141095869268883999563096063592498055290461", AsString);

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.AreEqual("622288097498926496141095869268883999563096063592498055290460", AsString);

        IsGreaterThan = mpz.cmpabs(a, b) > 0;
        Assert.IsTrue(IsGreaterThan);

        double d = 50.0;

        IsGreaterThan = mpz.cmpabs_d(a, d) > 0;
        Assert.IsTrue(IsGreaterThan);

        uint p = 50U;

        IsGreaterThan = mpz.cmpabs_ui(a, p) > 0;
        Assert.IsTrue(IsGreaterThan);
    }

    [TestMethod]
    public void Sign()
    {
        string AsString;
        bool IsNegative;

        using mpz_t a = new mpz_t("-622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.AreEqual("-622288097498926496141095869268883999563096063592498055290461", AsString);

        IsNegative = mpz.sgn(a) < 0;
        Assert.IsTrue(IsNegative);
    }
}
