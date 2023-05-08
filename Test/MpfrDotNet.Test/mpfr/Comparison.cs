namespace Test;

using MpfrDotNet;
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

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new mpfr_t("22298.125");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298125E+4"));

        IsGreaterThan = a > b;
        Assert.IsTrue(IsGreaterThan);

        Assert.That(mpfr_t.Compare(a, a), Is.EqualTo(0));
        Assert.That(mpfr_t.Compare(a, b), Is.EqualTo(1));
        Assert.That(mpfr_t.Compare(b, a), Is.EqualTo(-1));

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
        Assert.That(AsString, Is.EqualTo("1720124937520142"));

        IsGreaterThan = a > c;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = c > a;
        Assert.IsFalse(IsGreaterThan);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsGreaterThan = a > d;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = d > a;
        Assert.IsFalse(IsGreaterThan);

        using mpf_t e = new mpf_t("8720124937520142.1");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201421E+15"));

        IsGreaterThan = a > e;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = e > a;
        Assert.IsFalse(IsGreaterThan);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void GreaterEqual()
    {
        string AsString;
        bool IsGreaterThan;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982725E+15"));

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
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsGreaterThan = a >= c;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = c >= a;
        Assert.IsFalse(IsGreaterThan);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsGreaterThan = a >= d;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = d >= a;
        Assert.IsFalse(IsGreaterThan);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsGreaterThan = a >= e;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = e >= a;
        Assert.IsFalse(IsGreaterThan);
    }

    [Test]
    public void LesserThan()
    {
        string AsString;
        bool IsLesserThan;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982725E+15"));

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
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsLesserThan = a < c;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = c < a;
        Assert.IsTrue(IsLesserThan);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsLesserThan = a < d;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = d < a;
        Assert.IsTrue(IsLesserThan);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsLesserThan = a < e;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = e < a;
        Assert.IsTrue(IsLesserThan);
    }

    [Test]
    public void LesserEqual()
    {
        string AsString;
        bool IsLesserThan;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982725E+15"));

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
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsLesserThan = a <= c;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = c <= a;
        Assert.IsTrue(IsLesserThan);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsLesserThan = a <= d;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = d <= a;
        Assert.IsTrue(IsLesserThan);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsLesserThan = a <= e;
        Assert.IsFalse(IsLesserThan);

        IsLesserThan = e <= a;
        Assert.IsTrue(IsLesserThan);
    }

    [Test]
    public void Equal()
    {
        string AsString;
        bool IsEqualTo;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982725E+15"));

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
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsEqualTo = a == c;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = c == a;
        Assert.IsFalse(IsEqualTo);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsEqualTo = a == d;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = d == a;
        Assert.IsFalse(IsEqualTo);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsEqualTo = a == e;
        Assert.IsFalse(IsEqualTo);

        IsEqualTo = e == a;
        Assert.IsFalse(IsEqualTo);
    }

    [Test]
    public void Different()
    {
        string AsString;
        bool IsEqualTo;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502799228928E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982725E+15"));

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
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsEqualTo = a != c;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = c != a;
        Assert.IsTrue(IsEqualTo);

        using mpq_t d = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsEqualTo = a != d;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = d != a;
        Assert.IsTrue(IsEqualTo);

        using mpf_t e = new mpf_t("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsEqualTo = a != e;
        Assert.IsTrue(IsEqualTo);

        IsEqualTo = e != a;
        Assert.IsTrue(IsEqualTo);
    }

    [Test]
    public void Compare()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new mpfr_t("22298.125");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298125E+4"));

        Assert.That(mpfr_t.Compare(a, a), Is.EqualTo(0));
        Assert.That(mpfr_t.Compare(a, b), Is.EqualTo(1));
        Assert.That(mpfr_t.Compare(b, a), Is.EqualTo(-1));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void CompareAbs()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new mpfr_t("22298.125");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298125E+4"));

        using mpfr_t c = new mpfr_t("-8720124937520142.5");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-8.7201249375201425E+15"));

        using mpfr_t d = new mpfr_t("-22298.125");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-2.2298125E+4"));

        Assert.That(mpfr_t.CompareAbs(a, a), Is.EqualTo(0));
        Assert.That(mpfr_t.CompareAbs(a, b), Is.EqualTo(1));
        Assert.That(mpfr_t.CompareAbs(b, a), Is.EqualTo(-1));
        Assert.That(mpfr_t.CompareAbs(c, b), Is.EqualTo(1));
        Assert.That(mpfr_t.CompareAbs(b, c), Is.EqualTo(-1));
        Assert.That(mpfr_t.CompareAbs(a, d), Is.EqualTo(1));
        Assert.That(mpfr_t.CompareAbs(d, a), Is.EqualTo(-1));
        Assert.That(mpfr_t.CompareAbs(c, d), Is.EqualTo(1));
        Assert.That(mpfr_t.CompareAbs(d, c), Is.EqualTo(-1));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void CompareTo()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new mpfr_t("22298.125");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298125E+4"));

        Assert.That(a.CompareTo(b), Is.EqualTo(1));
        Assert.That(b.CompareTo(a), Is.EqualTo(-1));

        ulong ul1 = 8720124937520142UL;
        ulong ul2 = 8720124937520143UL;
        ulong ul3 = 136251952148752UL;
        ulong ul4 = 136251952148753UL;


        Assert.That(a.CompareTo(ul1), Is.EqualTo(1));
        Assert.That(a.CompareTo(ul2), Is.EqualTo(-1));
        Assert.That(a.CompareTo(ul3, 6), Is.EqualTo(1));
        Assert.That(a.CompareTo(ul4, 6), Is.EqualTo(-1));

        long l1 = 8720124937520142L;
        long l2 = 8720124937520143L;
        long l3 = 136251952148752L;
        long l4 = 136251952148753L;

        Assert.That(a.CompareTo(l1), Is.EqualTo(1));
        Assert.That(a.CompareTo(l2), Is.EqualTo(-1));
        Assert.That(a.CompareTo(l3, 6), Is.EqualTo(1));
        Assert.That(a.CompareTo(l4, 6), Is.EqualTo(-1));

        double d1 = 8720124937520142.1;
        double d2 = 8720124937520142.9;

        Assert.That(a.CompareTo(d1), Is.EqualTo(1));
        Assert.That(a.CompareTo(d2), Is.EqualTo(-1));

        using mpz_t z1 = new mpz_t("8720124937520142");
        AsString = z1.ToString();
        Assert.That(AsString, Is.EqualTo("8720124937520142"));

        using mpz_t z2 = new mpz_t("8720124937520143");
        AsString = z2.ToString();
        Assert.That(AsString, Is.EqualTo("8720124937520143"));

        Assert.That(a.CompareTo(z1), Is.EqualTo(1));
        Assert.That(a.CompareTo(z2), Is.EqualTo(-1));

        using mpq_t q1 = new mpq_t("100935446151795644800/11575");
        AsString = q1.ToString();
        Assert.That(AsString, Is.EqualTo("100935446151795644800/11575"));

        using mpq_t q2 = new mpq_t("100935446151795654067/11575");
        AsString = q2.ToString();
        Assert.That(AsString, Is.EqualTo("100935446151795654067/11575"));

        Assert.That(a.CompareTo(q1), Is.EqualTo(1));
        Assert.That(a.CompareTo(q2), Is.EqualTo(-1));

        using mpf_t f1 = new mpf_t("8720124937520142.1");
        AsString = f1.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201421E+15"));

        using mpf_t f2 = new mpf_t("8720124937520142.9");
        AsString = f2.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201429E+15"));

        Assert.That(a.CompareTo(f1), Is.EqualTo(1));
        Assert.That(a.CompareTo(f2), Is.EqualTo(-1));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void IsLesserOrGreater()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new mpfr_t("22298.125");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298125E+4"));

        Assert.That(mpfr_t.IsLesserOrGreater(a, a), Is.False);
        Assert.That(mpfr_t.IsLesserOrGreater(a, b), Is.True);
        Assert.That(mpfr_t.IsLesserOrGreater(b, a), Is.True);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void IsUnordered()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = mpfr_t.NaN();

        Assert.That(mpfr_t.IsUnordered(a, a), Is.False);
        Assert.That(mpfr_t.IsUnordered(b, b), Is.True);
        Assert.That(mpfr_t.IsUnordered(a, b), Is.True);
        Assert.That(mpfr_t.IsUnordered(b, a), Is.True);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void IsTotalOrdered()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new mpfr_t("8720124937520143.5");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201435E+15"));

        using mpfr_t c = mpfr_t.NaN(-1);
        using mpfr_t d = mpfr_t.NaN(+1);

        using mpfr_t e = mpfr_t.Zero(-1);
        using mpfr_t f = mpfr_t.Zero(+1);

        Assert.That(mpfr_t.IsTotalOrdered(a, a), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(a, b), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(b, a), Is.False);

        Assert.That(mpfr_t.IsTotalOrdered(c, c), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(c, d), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(d, c), Is.False);

        Assert.That(mpfr_t.IsTotalOrdered(e, e), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(e, f), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(f, e), Is.False);

        Assert.That(mpfr_t.IsTotalOrdered(c, a), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(c, b), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(a, d), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(b, d), Is.True);

        Assert.That(mpfr_t.IsTotalOrdered(c, e), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(c, f), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(e, d), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(f, d), Is.True);

        Assert.That(mpfr_t.IsTotalOrdered(e, a), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(f, a), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(e, b), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(f, b), Is.True);
        Assert.That(mpfr_t.IsTotalOrdered(a, e), Is.False);
        Assert.That(mpfr_t.IsTotalOrdered(b, e), Is.False);
        Assert.That(mpfr_t.IsTotalOrdered(a, f), Is.False);
        Assert.That(mpfr_t.IsTotalOrdered(b, f), Is.False);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void RelativeDifference()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("35060493914120386");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.5060493914120386E+16"));

        using mpfr_t b = new mpfr_t("8765123478530096.5");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("8.7651234785300965E+15"));

        using mpfr_t c = -a;
        using mpfr_t d = -b;

        using mpfr_t e = mpfr_t.RelativeDifference(a, b);
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("7.5E-1"));

        using mpfr_t f = mpfr_t.RelativeDifference(c, d);
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-7.5E-1"));

        using mpfr_t g = mpfr_t.RelativeDifference(b, a);
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("3E+0"));

        using mpfr_t h = mpfr_t.RelativeDifference(d, c);
        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("-3E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void IsEqualBits()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("16");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1.6E+1"));

        using mpfr_t b = new mpfr_t("17");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.7E+1"));

        Assert.That(mpfr_t.IsEqualBits(a, b, 4U), Is.True);
        Assert.That(mpfr_t.IsEqualBits(a, b, 5U), Is.False);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
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
