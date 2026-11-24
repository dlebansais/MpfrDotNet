namespace Test;

using System;
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

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new("22298.125");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298125E+4"));

        IsGreaterThan = a > b;
        Assert.That(IsGreaterThan, Is.True);

        Assert.That(mpfr_t.Compare(a, a), Is.Zero);
        Assert.That(mpfr_t.Compare(a, b), Is.EqualTo(1));
        Assert.That(mpfr_t.Compare(b, a), Is.EqualTo(-1));

        IsGreaterThan = b > a;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = a > 8720124937520142UL;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = a > 8720124937520143UL;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = 8720124937520142UL > a;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = 8720124937520143UL > a;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = a > 8720124937520142L;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = a > 8720124937520143L;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = 8720124937520142L > a;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = 8720124937520143L > a;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = a > 8720124937520142.1;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = 8720124937520142.9 > a;
        Assert.That(IsGreaterThan, Is.True);

        using mpz_t c = new("1720124937520142");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1720124937520142"));

        IsGreaterThan = a > c;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = c > a;
        Assert.That(IsGreaterThan, Is.False);

        using mpq_t d = new("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsGreaterThan = a > d;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = d > a;
        Assert.That(IsGreaterThan, Is.False);

        using mpf_t e = new("8720124937520142.1");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201421E+15"));

        IsGreaterThan = a > e;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = e > a;
        Assert.That(IsGreaterThan, Is.False);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void GreaterEqual()
    {
        string AsString;
        bool IsGreaterThan;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        IsGreaterThan = a >= b;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = b >= a;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = a >= 1UL;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = 1UL >= a;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = a >= 1L;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = 1L >= a;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = a >= 1.0;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = 1.0 >= a;
        Assert.That(IsGreaterThan, Is.False);

        using mpz_t c = new("222509832503450298345029");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsGreaterThan = a >= c;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = c >= a;
        Assert.That(IsGreaterThan, Is.False);

        using mpq_t d = new("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsGreaterThan = a >= d;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = d >= a;
        Assert.That(IsGreaterThan, Is.False);

        using mpf_t e = new("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsGreaterThan = a >= e;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = e >= a;
        Assert.That(IsGreaterThan, Is.False);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void LesserThan()
    {
        string AsString;
        bool IsLesserThan;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        IsLesserThan = a < b;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = b < a;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = a < 1UL;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = 1UL < a;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = a < 1L;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = 1L < a;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = a < 1.0;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = 1.0 < a;
        Assert.That(IsLesserThan, Is.True);

        using mpz_t c = new("222509832503450298345029");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsLesserThan = a < c;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = c < a;
        Assert.That(IsLesserThan, Is.True);

        using mpq_t d = new("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsLesserThan = a < d;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = d < a;
        Assert.That(IsLesserThan, Is.True);

        using mpf_t e = new("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsLesserThan = a < e;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = e < a;
        Assert.That(IsLesserThan, Is.True);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void LesserEqual()
    {
        string AsString;
        bool IsLesserThan;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        IsLesserThan = a <= b;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = b <= a;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = a <= 1UL;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = 1UL <= a;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = a <= 1L;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = 1L <= a;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = a <= 1.0;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = 1.0 <= a;
        Assert.That(IsLesserThan, Is.True);

        using mpz_t c = new("222509832503450298345029");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsLesserThan = a <= c;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = c <= a;
        Assert.That(IsLesserThan, Is.True);

        using mpq_t d = new("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsLesserThan = a <= d;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = d <= a;
        Assert.That(IsLesserThan, Is.True);

        using mpf_t e = new("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsLesserThan = a <= e;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = e <= a;
        Assert.That(IsLesserThan, Is.True);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Equal()
    {
        string AsString;
        bool IsEqualTo;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        IsEqualTo = a == b;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = b == a;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = a == 1UL;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = 1UL == a;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = a == 1L;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = 1L == a;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = a == 1.0;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = 1.0 == a;
        Assert.That(IsEqualTo, Is.False);

        using mpz_t c = new("222509832503450298345029");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsEqualTo = a == c;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = c == a;
        Assert.That(IsEqualTo, Is.False);

        using mpq_t d = new("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsEqualTo = a == d;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = d == a;
        Assert.That(IsEqualTo, Is.False);

        using mpf_t e = new("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsEqualTo = a == e;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = e == a;
        Assert.That(IsEqualTo, Is.False);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Equals()
    {
        string AsString;
        bool IsEqualTo;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new(1);
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1E+0"));

        using mpfr_t b = new(2);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2E+0"));

        IsEqualTo = a.Equals(b);
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = a.Equals(null);
        Assert.That(IsEqualTo, Is.False);

        int HashCode = b.GetHashCode();

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Different()
    {
        string AsString;
        bool IsEqualTo;

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        IsEqualTo = a != b;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = b != a;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = a != 1UL;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = 1UL != a;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = a != 1L;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = 1L != a;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = a != 1.0;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = 1.0 != a;
        Assert.That(IsEqualTo, Is.True);

        using mpz_t c = new("222509832503450298345029");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029"));

        IsEqualTo = a != c;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = c != a;
        Assert.That(IsEqualTo, Is.True);

        using mpq_t d = new("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        IsEqualTo = a != d;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = d != a;
        Assert.That(IsEqualTo, Is.True);

        using mpf_t e = new("222583250345029834502983.5");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("2.22583250345029834503E+23"));

        IsEqualTo = a != e;
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = e != a;
        Assert.That(IsEqualTo, Is.True);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Compare()
    {
        string AsString;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new("22298.125");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298125E+4"));

        Assert.That(mpfr_t.Compare(a, a), Is.Zero);
        Assert.That(mpfr_t.Compare(a, b), Is.EqualTo(1));
        Assert.That(mpfr_t.Compare(b, a), Is.EqualTo(-1));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void CompareAbs()
    {
        string AsString;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new("22298.125");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298125E+4"));

        using mpfr_t c = new("-8720124937520142.5");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-8.7201249375201425E+15"));

        using mpfr_t d = new("-22298.125");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-2.2298125E+4"));

        Assert.That(mpfr_t.CompareAbs(a, a), Is.Zero);
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

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new("22298.125");
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

        using mpz_t z1 = new("8720124937520142");
        AsString = z1.ToString();
        Assert.That(AsString, Is.EqualTo("8720124937520142"));

        using mpz_t z2 = new("8720124937520143");
        AsString = z2.ToString();
        Assert.That(AsString, Is.EqualTo("8720124937520143"));

        Assert.That(a.CompareTo(z1), Is.EqualTo(1));
        Assert.That(a.CompareTo(z2), Is.EqualTo(-1));

        using mpq_t q1 = new("100935446151795644800/11575");
        AsString = q1.ToString();
        Assert.That(AsString, Is.EqualTo("100935446151795644800/11575"));

        using mpq_t q2 = new("100935446151795654067/11575");
        AsString = q2.ToString();
        Assert.That(AsString, Is.EqualTo("100935446151795654067/11575"));

        Assert.That(a.CompareTo(q1), Is.EqualTo(1));
        Assert.That(a.CompareTo(q2), Is.EqualTo(-1));

        using mpf_t f1 = new("8720124937520142.1");
        AsString = f1.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201421E+15"));

        using mpf_t f2 = new("8720124937520142.9");
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

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new("22298.125");
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

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("8720124937520142.5");
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

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("8720124937520142.5");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.7201249375201425E+15"));

        using mpfr_t b = new("8720124937520143.5");
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

        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("35060493914120386");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.5060493914120386E+16"));

        using mpfr_t b = new("8765123478530096.5");
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

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("16");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1.6E+1"));

        using mpfr_t b = new("17");
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
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(a.IsNan, Is.True);
        Assert.That(a.IsInf, Is.False);
        Assert.That(a.IsZero, Is.False);
        Assert.That(a.IsNumber, Is.False);
        Assert.That(a.IsRegular, Is.False);

        using mpfr_t b = mpfr_t.Infinite();
        Assert.That(b.IsInf, Is.True);
        Assert.That(b.IsNan, Is.False);
        Assert.That(b.IsZero, Is.False);
        Assert.That(b.IsNumber, Is.False);
        Assert.That(b.IsRegular, Is.False);
        Assert.That(b.Sign, Is.Positive);

        using mpfr_t c = mpfr_t.Infinite(-1);
        Assert.That(c.IsInf, Is.True);
        Assert.That(c.IsNan, Is.False);
        Assert.That(c.IsZero, Is.False);
        Assert.That(c.IsNumber, Is.False);
        Assert.That(c.IsRegular, Is.False);
        Assert.That(c.Sign, Is.Negative);

        using mpfr_t d = mpfr_t.Zero();
        Assert.That(d.IsZero, Is.True);
        Assert.That(d.IsNan, Is.False);
        Assert.That(d.IsInf, Is.False);
        Assert.That(d.IsNumber, Is.True);
        Assert.That(d.IsRegular, Is.False);
        Assert.That(d.Sign, Is.Zero);

        using mpfr_t e = mpfr_t.Zero(-1);
        Assert.That(e.IsZero, Is.True);
        Assert.That(e.IsNan, Is.False);
        Assert.That(e.IsInf, Is.False);
        Assert.That(e.IsNumber, Is.True);
        Assert.That(e.IsRegular, Is.False);
        Assert.That(e.Sign, Is.Zero);

        using mpfr_t f = new(1.0);
        Assert.That(f.IsZero, Is.False);
        Assert.That(f.IsNan, Is.False);
        Assert.That(f.IsInf, Is.False);
        Assert.That(f.IsNumber, Is.True);
        Assert.That(f.IsRegular, Is.True);
        Assert.That(f.Sign, Is.Positive);

        using mpfr_t g = new(-1.0);
        Assert.That(g.IsZero, Is.False);
        Assert.That(g.IsNan, Is.False);
        Assert.That(g.IsInf, Is.False);
        Assert.That(g.IsNumber, Is.True);
        Assert.That(g.IsRegular, Is.True);
        Assert.That(g.Sign, Is.Negative);
    }
}
