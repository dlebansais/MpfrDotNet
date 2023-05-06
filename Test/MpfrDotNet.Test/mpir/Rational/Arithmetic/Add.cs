namespace TestRational;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;

[TestClass]
public class Add
{
    [TestMethod]
    public void AddCanonic()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

        using mpq_t c = new();
        mpq.add(c, a, b);

        AsString = c.ToString();
        Assert.AreEqual("157287319765466872798299859701022414376160801933389609744596419278783/68397633165470058274884361378645822467587248043012077070501", AsString);

        AsString = c.GetNumerator().ToString();
        Assert.AreEqual("157287319765466872798299859701022414376160801933389609744596419278783", AsString);

        AsString = c.GetDenominator().ToString();
        Assert.AreEqual("68397633165470058274884361378645822467587248043012077070501", AsString);

        using mpz_t Numerator = a.GetNumerator() * b.GetDenominator() + b.GetNumerator() * a.GetDenominator();

        AsString = Numerator.ToString();
        Assert.AreEqual("157287319765466872798299859701022414376160801933389609744596419278783", AsString);

        using mpz_t Denominator = a.GetDenominator() * b.GetDenominator();

        AsString = Denominator.ToString();
        Assert.AreEqual("68397633165470058274884361378645822467587248043012077070501", AsString);
    }

    [TestMethod]
    public void AddCanonicOperator()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

        using mpq_t c = a + b;

        AsString = c.ToString();
        Assert.AreEqual("157287319765466872798299859701022414376160801933389609744596419278783/68397633165470058274884361378645822467587248043012077070501", AsString);

        AsString = c.GetNumerator().ToString();
        Assert.AreEqual("157287319765466872798299859701022414376160801933389609744596419278783", AsString);

        AsString = c.GetDenominator().ToString();
        Assert.AreEqual("68397633165470058274884361378645822467587248043012077070501", AsString);

        using mpz_t Numerator = a.GetNumerator() * b.GetDenominator() + b.GetNumerator() * a.GetDenominator();

        AsString = Numerator.ToString();
        Assert.AreEqual("157287319765466872798299859701022414376160801933389609744596419278783", AsString);

        using mpz_t Denominator = a.GetDenominator() * b.GetDenominator();

        AsString = Denominator.ToString();
        Assert.AreEqual("68397633165470058274884361378645822467587248043012077070501", AsString);
    }

    [TestMethod]
    public void AddNonCanonicOperator()
    {
        string AsString;

        using mpz_t n0 = new mpz_t("222509832503450298345029835740293845720");
        using mpz_t d0 = new mpz_t("115756986668303657898962467957");

        using mpq_t a = new mpq_t(n0, d0);
        AsString = a.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        using mpz_t n1 = new mpz_t("222987435987982730594288574029879874539");
        using mpz_t d1 = new mpz_t("590872612825179551336102196593");

        using mpq_t b = new mpq_t(n1, d1);
        AsString = b.ToString();
        Assert.AreEqual("222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

        using mpz_t n2 = n0 * 2;
        using mpz_t d2 = d0 * 17;

        using mpq_t c = new mpq_t(n2, d2);
        AsString = c.ToString();
        Assert.AreEqual("445019665006900596690059671480587691440/1967868773361162184282361955269", AsString);

        c.Canonicalize();

        AsString = c.ToString();
        Assert.AreEqual("445019665006900596690059671480587691440/1967868773361162184282361955269", AsString);

        using mpz_t n3 = n1 * 2;
        using mpz_t d3 = d1 * 17;

        using mpq_t d = new mpq_t(n3, d3);
        AsString = d.ToString();
        Assert.AreEqual("445974871975965461188577148059759749078/10044834418028052372713737342081", AsString);

        d.Canonicalize();

        AsString = d.ToString();
        Assert.AreEqual("445974871975965461188577148059759749078/10044834418028052372713737342081", AsString);

        using mpq_t e = c + d;

        AsString = e.ToString();
        Assert.AreEqual("314574639530933745596599719402044828752321603866779219489192838557566/1162759763812990990673034143436978981948983216731205310198517", AsString);

        using mpz_t Numerator = c.GetNumerator() * d.GetDenominator() + d.GetNumerator() * c.GetDenominator();

        AsString = Numerator.ToString();
        Assert.AreNotEqual("314574639530933745596599719402044828752321603866779219489192838557566", AsString);
    }
}
