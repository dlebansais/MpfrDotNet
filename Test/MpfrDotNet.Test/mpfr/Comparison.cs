namespace Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpfrDotNet;
using MpirDotNet;

[TestClass]
public class Comparison
{
    [TestMethod]
    public void GreaterThan()
    {
        string AsString;
        bool IsGreaterThan;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8720124937520142.5");
        AsString = a.ToString();
        Assert.AreEqual("8.7201249375201425E+15", AsString);

        using mpfr_t b = new mpfr_t("22298.125");
        AsString = b.ToString();
        Assert.AreEqual("2.2298125E+4", AsString);

        IsGreaterThan = a > b;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = b > a;
        Assert.IsFalse(IsGreaterThan);

        IsGreaterThan = a > 8720124937520142UL;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = a > 8720124937520143UL;
        Assert.IsFalse(IsGreaterThan);

        IsGreaterThan = 8720124937520142UL > a;
        Assert.IsFalse(IsGreaterThan);

        IsGreaterThan = 8720124937520143UL > a;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = a > 8720124937520142L;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = a > 8720124937520143L;
        Assert.IsFalse(IsGreaterThan);

        IsGreaterThan = 8720124937520142L > a;
        Assert.IsFalse(IsGreaterThan);

        IsGreaterThan = 8720124937520143L > a;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = a > 8720124937520142.1;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = 8720124937520142.9 > a;
        Assert.IsTrue(IsGreaterThan);

        using mpz_t c = new mpz_t("1720124937520142");
        AsString = c.ToString();
        Assert.AreEqual("1720124937520142", AsString);

        IsGreaterThan = a > c;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = c > a;
        Assert.IsFalse(IsGreaterThan);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        IsGreaterThan = a > d;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = d > a;
        Assert.IsFalse(IsGreaterThan);

        using mpf_t e = new mpf_t("8720124937520142.1");
        AsString = e.ToString();
        Assert.AreEqual("8.7201249375201421E+15", AsString);

        IsGreaterThan = a > e;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = e > a;
        Assert.IsFalse(IsGreaterThan);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [TestMethod]
    public void GreaterEqual()
    {
        string AsString;
        bool IsGreaterThan;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982725E+15", AsString);

        IsGreaterThan = a >= b;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = b >= a;
        Assert.IsFalse(IsGreaterThan);

        IsGreaterThan = a >= 1UL;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = 1UL >= a;
        Assert.IsFalse(IsGreaterThan);

        IsGreaterThan = a >= 1L;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = 1L >= a;
        Assert.IsFalse(IsGreaterThan);

        IsGreaterThan = a >= 1.0;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = 1.0 >= a;
        Assert.IsFalse(IsGreaterThan);

        using mpz_t c = new mpz_t("222509832503450298345029");
        AsString = c.ToString();
        Assert.AreEqual("222509832503450298345029", AsString);

        IsGreaterThan = a >= c;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = c >= a;
        Assert.IsFalse(IsGreaterThan);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        IsGreaterThan = a >= d;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = d >= a;
        Assert.IsFalse(IsGreaterThan);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.AreEqual("2.22583250345029834503E+23", AsString);

        IsGreaterThan = a >= e;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = e >= a;
        Assert.IsFalse(IsGreaterThan);
    }

    [TestMethod]
    public void LesserThan()
    {
        string AsString;
        bool IsLesserThan;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982725E+15", AsString);

        IsLesserThan = a < b;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = b < a;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = a < 1UL;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = 1UL < a;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = a < 1L;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = 1L < a;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = a < 1.0;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = 1.0 < a;
        Assert.IsTrue(IsLesserThan);

        using mpz_t c = new mpz_t("222509832503450298345029");
        AsString = c.ToString();
        Assert.AreEqual("222509832503450298345029", AsString);

        IsLesserThan = a < c;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = c < a;
        Assert.IsTrue(IsLesserThan);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        IsLesserThan = a < d;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = d < a;
        Assert.IsTrue(IsLesserThan);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.AreEqual("2.22583250345029834503E+23", AsString);

        IsLesserThan = a < e;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = e < a;
        Assert.IsTrue(IsLesserThan);
    }

    [TestMethod]
    public void LesserEqual()
    {
        string AsString;
        bool IsLesserThan;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982725E+15", AsString);

        IsLesserThan = a <= b;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = b <= a;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = a <= 1UL;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = 1UL <= a;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = a <= 1L;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = 1L <= a;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = a <= 1.0;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = 1.0 <= a;
        Assert.IsTrue(IsLesserThan);

        using mpz_t c = new mpz_t("222509832503450298345029");
        AsString = c.ToString();
        Assert.AreEqual("222509832503450298345029", AsString);

        IsLesserThan = a <= c;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = c <= a;
        Assert.IsTrue(IsLesserThan);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        IsLesserThan = a <= d;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = d <= a;
        Assert.IsTrue(IsLesserThan);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.AreEqual("2.22583250345029834503E+23", AsString);

        IsLesserThan = a <= e;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = e <= a;
        Assert.IsTrue(IsLesserThan);
    }

    [TestMethod]
    public void Equal()
    {
        string AsString;
        bool IsEqualTo;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982725E+15", AsString);

        IsEqualTo = a == b;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = b == a;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = a == 1UL;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = 1UL == a;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = a == 1L;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = 1L == a;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = a == 1.0;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = 1.0 == a;
        Assert.IsFalse(IsEqualTo);

        using mpz_t c = new mpz_t("222509832503450298345029");
        AsString = c.ToString();
        Assert.AreEqual("222509832503450298345029", AsString);

        IsEqualTo = a == c;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = c == a;
        Assert.IsFalse(IsEqualTo);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        IsEqualTo = a == d;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = d == a;
        Assert.IsFalse(IsEqualTo);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.AreEqual("2.22583250345029834503E+23", AsString);

        IsEqualTo = a == e;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = e == a;
        Assert.IsFalse(IsEqualTo);
    }

    [TestMethod]
    public void Different()
    {
        string AsString;
        bool IsEqualTo;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.AreEqual("2.225098325034502799228928E+25", AsString);

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.AreEqual("2.22987435987982725E+15", AsString);

        IsEqualTo = a != b;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = b != a;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = a != 1UL;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = 1UL != a;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = a != 1L;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = 1L != a;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = a != 1.0;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = 1.0 != a;
        Assert.IsTrue(IsEqualTo);

        using mpz_t c = new mpz_t("222509832503450298345029");
        AsString = c.ToString();
        Assert.AreEqual("222509832503450298345029", AsString);

        IsEqualTo = a != c;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = c != a;
        Assert.IsTrue(IsEqualTo);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

        IsEqualTo = a != d;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = d != a;
        Assert.IsTrue(IsEqualTo);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.AreEqual("2.22583250345029834503E+23", AsString);

        IsEqualTo = a != e;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = e != a;
        Assert.IsTrue(IsEqualTo);
    }

    [TestMethod]
    public void Special()
    {
        using mpfr_t a = new();
        Assert.IsTrue(a.IsNan);
        Assert.IsFalse(a.IsInf);
        Assert.IsFalse(a.IsZero);
        Assert.IsFalse(a.IsNumber);
        Assert.IsFalse(a.IsRegular);

        using mpfr_t b = mpfr_t.Infinite();
        Assert.IsTrue(b.IsInf);
        Assert.IsFalse(b.IsNan);
        Assert.IsFalse(b.IsZero);
        Assert.IsFalse(b.IsNumber);
        Assert.IsFalse(b.IsRegular);
        Assert.IsTrue(b.Sign > 0);

        using mpfr_t c = mpfr_t.Infinite(-1);
        Assert.IsTrue(c.IsInf);
        Assert.IsFalse(c.IsNan);
        Assert.IsFalse(c.IsZero);
        Assert.IsFalse(c.IsNumber);
        Assert.IsFalse(c.IsRegular);
        Assert.IsTrue(c.Sign < 0);

        using mpfr_t d = mpfr_t.Zero();
        Assert.IsTrue(d.IsZero);
        Assert.IsFalse(d.IsNan);
        Assert.IsFalse(d.IsInf);
        Assert.IsTrue(d.IsNumber);
        Assert.IsFalse(d.IsRegular);
        Assert.IsTrue(d.Sign == 0);

        using mpfr_t e = mpfr_t.Zero(-1);
        Assert.IsTrue(e.IsZero);
        Assert.IsFalse(e.IsNan);
        Assert.IsFalse(e.IsInf);
        Assert.IsTrue(e.IsNumber);
        Assert.IsFalse(e.IsRegular);
        Assert.IsTrue(e.Sign == 0);

        using mpfr_t f = new mpfr_t(1.0);
        Assert.IsFalse(f.IsZero);
        Assert.IsFalse(f.IsNan);
        Assert.IsFalse(f.IsInf);
        Assert.IsTrue(f.IsNumber);
        Assert.IsTrue(f.IsRegular);
        Assert.IsTrue(f.Sign > 0);

        using mpfr_t g = new mpfr_t(-1.0);
        Assert.IsFalse(g.IsZero);
        Assert.IsFalse(g.IsNan);
        Assert.IsFalse(g.IsInf);
        Assert.IsTrue(g.IsNumber);
        Assert.IsTrue(g.IsRegular);
        Assert.IsTrue(g.Sign < 0);
    }
}
