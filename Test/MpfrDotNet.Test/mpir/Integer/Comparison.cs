namespace TestInteger;

using MpirDotNet;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class Comparison
{
    [Test]
    public void GreaterThan()
    {
        string AsString;
        bool IsGreaterThan;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

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

    [Test]
    public void CompareAbs()
    {
        string AsString;
        bool IsGreaterThan;

        using mpz_t a = new mpz_t("-622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

        IsGreaterThan = mpz.cmpabs(a, b) > 0;
        Assert.IsTrue(IsGreaterThan);

        double d = 50.0;

        IsGreaterThan = mpz.cmpabs_d(a, d) > 0;
        Assert.IsTrue(IsGreaterThan);

        uint p = 50U;

        IsGreaterThan = mpz.cmpabs_ui(a, p) > 0;
        Assert.IsTrue(IsGreaterThan);
    }

    [Test]
    public void Sign()
    {
        string AsString;
        bool IsNegative;

        using mpz_t a = new mpz_t("-622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-622288097498926496141095869268883999563096063592498055290461"));

        IsNegative = mpz.sgn(a) < 0;
        Assert.IsTrue(IsNegative);
    }
}
