namespace Test;

using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Div
{
    [Test]
    public void BasicDiv()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982725E+15"));

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9.9785815966529083251953125E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1.0021464376614685245922416240006258374151126844253668E-10"));
    }

    [Test]
    public void DivULong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983574029384571986156515777111053466796875E+25"));

        ulong b = 8720124937520142UL;

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.55168170293129287651820888522797667870082767164318064415776446916817032928292974247597157955169677734375E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("3.9189840913591651536360094014194294134437352468214833671405939100202540497936908589735662571870483374003742670088623611945877201E-10"));

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("8.720124937520142E+15"));

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void DivLong()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983574029384571986156515777111053466796875E+25"));

        long b = -8720124937520142L;

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-2.55168170293129287651820888522797667870082767164318064415776446916817032928292974247597157955169677734375E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-3.9189840913591651536360094014194294134437352468214833671405939100202540497936908589735662571870483374003742670088623611945877201E-10"));

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void DivDouble()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        double b = 2229874359879827.30594288574029879874539;

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9.9785815966529083251953125E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1.0021464376614685245922416240006258374151126844253668E-10"));
    }

    [Test]
    public void DivInteger()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983574029384571986156515777111053466796875E+25"));

        using mpz_t b = new mpz_t("-8720124937520142");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-8720124937520142"));

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-2.55168170293129287651820888522797667870082767164318064415776446916817032928292974247597157955169677734375E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-3.9189840913591651536360094014194294134437352468214833671405939100202540497936908589735662571870483374003742670088623611945877201E-10"));

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void DivRational()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983574029384571986156515777111053466796875E+25"));

        using mpq_t b = new mpq_t("-222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-222987435987982730594288574029879874539/590872612825179551336102196593"));

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-5.8960705803035560895114797706756890241890293308767156954530719303875230252742767333984375E+16"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-1.6960448257532824963330331211823807141349784251806416314369913931833001298969603911424991542549574129508512989808951689388685259E-17"));

        using mpfr_t bF = new mpfr_t(b);
        AsString = bF.ToString();
        Assert.That(AsString, Is.EqualTo("-3.77386650096706435239638030739606963153305132554456961429446650350093273029727924949838779866695404052734375E+8"));

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-3.77386650096706435239638030739606963153305132554456961429446650350093273029727924949838779866695404052734375E+8"));

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-3.77386650096706435239638030739606963153305132554456961429446650350093273029727924949838779866695404052734375E+8"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
