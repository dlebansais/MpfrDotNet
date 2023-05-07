namespace TestRational;

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

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

        IsGreaterThan = a > b;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = mpq.cmp_ui(a, 1922215141, 1) > 0;
        Assert.IsTrue(IsGreaterThan);
    }

    [Test]
    public void LesserThan()
    {
        string AsString;
        bool IsLesserThan;

        using mpq_t a = new mpq_t("-222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.AreEqual("-222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

        IsLesserThan = a < b;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = mpq.cmp_si(a, -1922215141, 1) < 0;
        Assert.IsTrue(IsLesserThan);
    }

    [Test]
    public void IsEqual()
    {
        string AsString;
        bool IsEqualTo;
        bool IsDifferentThan;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

        using mpq_t c = a;

        IsEqualTo = a == c;
        Assert.IsTrue(IsEqualTo);

        IsDifferentThan = a != b;
        Assert.IsTrue(IsDifferentThan);
    }
}
