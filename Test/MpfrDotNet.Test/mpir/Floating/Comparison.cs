namespace TestFloating;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Comparison
{
    [Test]
    public void GreaterThan()
    {
        string AsString;
        bool IsGreaterThan;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        IsGreaterThan = a > b;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = mpf.cmp_ui(a, 1922215141) > 0;
        Assert.IsTrue(IsGreaterThan);

        double d = 2e25;

        IsGreaterThan = a > d;
        Assert.IsTrue(IsGreaterThan);

        int e = -10;

        IsGreaterThan = a > e;
        Assert.IsTrue(IsGreaterThan);

        uint f = 10;

        IsGreaterThan = a > f;
        Assert.IsTrue(IsGreaterThan);

        float g = 2e25F;

        IsGreaterThan = a > g;
        Assert.IsTrue(IsGreaterThan);
    }

    [Test]
    public void LesserThan()
    {
        string AsString;
        bool IsLesserThan;

        using mpf_t a = new mpf_t("-22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        IsLesserThan = a < b;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = mpf.cmp_si(a, -1922215141) < 0;
        Assert.IsTrue(IsLesserThan);

        double d = 2e5;

        IsLesserThan = d < b;
        Assert.IsTrue(IsLesserThan);

        int e = -10;

        IsLesserThan = e < b;
        Assert.IsTrue(IsLesserThan);

        int f = -10;

        IsLesserThan = f < b;
        Assert.IsTrue(IsLesserThan);

        float g = 2e5F;

        IsLesserThan = g < b;
        Assert.IsTrue(IsLesserThan);
    }

    [Test]
    public void IsEqual()
    {
        string AsString;
        bool IsEqualTo;
        bool IsDifferentThan;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        using mpf_t c = a;

        IsEqualTo = a == c;
        Assert.IsTrue(IsEqualTo);

        IsDifferentThan = a != b;
        Assert.IsTrue(IsDifferentThan);
    }
}
