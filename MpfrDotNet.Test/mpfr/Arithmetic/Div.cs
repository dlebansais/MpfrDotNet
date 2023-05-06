namespace Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpfrDotNet;
using MpirDotNet;

[TestClass]
public class Div
{
    [TestMethod]
    public void BasicDiv()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982725E+15", AsString);

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.AreEqual("9.9785815966529083251953125E+9", AsString);

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.AreEqual("1.0021464376614685245922416240006258374151126844253668E-10", AsString);
    }

    [TestMethod]
    public void DivULong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.2250983250345029834502983574029384571986156515777111053466796875E+25", AsString);

        ulong b = 8720124937520142UL;

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.AreEqual("2.55168170293129287651820888522797667870082767164318064415776446916817032928292974247597157955169677734375E+9", AsString);

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.AreEqual("3.9189840913591651536360094014194294134437352468214833671405939100202540497936908589735662571870483374003742670088623611945877201E-10", AsString);

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.AreEqual("8.720124937520142E+15", AsString);

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.AreEqual("8.720124937520142E+15", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void DivLong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.2250983250345029834502983574029384571986156515777111053466796875E+25", AsString);

        long b = -8720124937520142L;

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.AreEqual("-2.55168170293129287651820888522797667870082767164318064415776446916817032928292974247597157955169677734375E+9", AsString);

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.AreEqual("-3.9189840913591651536360094014194294134437352468214833671405939100202540497936908589735662571870483374003742670088623611945877201E-10", AsString);

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.AreEqual("-8.720124937520142E+15", AsString);

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.AreEqual("-8.720124937520142E+15", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void DivDouble()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        double b = 2229874359879827.30594288574029879874539;

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.AreEqual("9.9785815966529083251953125E+9", AsString);

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.AreEqual("1.0021464376614685245922416240006258374151126844253668E-10", AsString);
    }

    [TestMethod]
    public void DivInteger()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.2250983250345029834502983574029384571986156515777111053466796875E+25", AsString);

        using mpz_t b = new mpz_t("-8720124937520142");
        AsString = b.ToString();
        Assert.AreEqual("-8720124937520142", AsString);

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.AreEqual("-2.55168170293129287651820888522797667870082767164318064415776446916817032928292974247597157955169677734375E+9", AsString);

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.AreEqual("-3.9189840913591651536360094014194294134437352468214833671405939100202540497936908589735662571870483374003742670088623611945877201E-10", AsString);

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.AreEqual("-8.720124937520142E+15", AsString);

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.AreEqual("-8.720124937520142E+15", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void DivRational()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.2250983250345029834502983574029384571986156515777111053466796875E+25", AsString);

        using mpq_t b = new mpq_t("-222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.AreEqual("-222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.AreEqual("-5.8960705803035560895114797706756890241890293308767156954530719303875230252742767333984375E+16", AsString);

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.AreEqual("-1.6960448257532824963330331211823807141349784251806416314369913931833001298969603911424991542549574129508512989808951689388685259E-17", AsString);

        using mpfr_t bF = new mpfr_t(b);
        AsString = bF.ToString();
        Assert.AreEqual("-3.77386650096706435239638030739606963153305132554456961429446650350093273029727924949838779866695404052734375E+8", AsString);

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.AreEqual("-3.77386650096706435239638030739606963153305132554456961429446650350093273029727924949838779866695404052734375E+8", AsString);

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.AreEqual("-3.77386650096706435239638030739606963153305132554456961429446650350093273029727924949838779866695404052734375E+8", AsString);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
