namespace TestFloating;

using System;
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
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = b > a;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = mpf.cmp_ui(a, 1922215141) > 0;
        Assert.IsTrue(IsGreaterThan);

        double d = 2e25;

        IsGreaterThan = a > d;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = d > a;
        Assert.That(IsGreaterThan, Is.False);

        int e = -10;

        IsGreaterThan = a > e;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = e > a;
        Assert.That(IsGreaterThan, Is.False);

        uint f = 10;

        IsGreaterThan = a > f;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = f > a;
        Assert.That(IsGreaterThan, Is.False);

        float g = 2e25F;

        IsGreaterThan = a > g;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = g > a;
        Assert.That(IsGreaterThan, Is.False);

        ulong ul = 10UL;

        IsGreaterThan = a > ul;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = ul > a ;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = a.CompareTo(ul) > 0;
        Assert.That(IsGreaterThan, Is.True);
    }

    [Test]
    public void GreaterThanOrEqual()
    {
        string AsString;
        bool IsGreaterThan;

        using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        IsGreaterThan = a >= b;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = b >= a;
        Assert.That(IsGreaterThan, Is.False);

        IsGreaterThan = mpf.cmp_ui(a, 1922215141) > 0;
        Assert.IsTrue(IsGreaterThan);

        double d = 2e25;

        IsGreaterThan = a >= d;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = d >= a;
        Assert.That(IsGreaterThan, Is.False);

        int e = -10;

        IsGreaterThan = a >= e;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = e >= a;
        Assert.That(IsGreaterThan, Is.False);

        uint f = 10;

        IsGreaterThan = a >= f;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = f > a;
        Assert.That(IsGreaterThan, Is.False);

        float g = 2e25F;

        IsGreaterThan = a >= g;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = g >= a;
        Assert.That(IsGreaterThan, Is.False);

        ulong ul = 10UL;

        IsGreaterThan = a >= ul;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = ul >= a;
        Assert.That(IsGreaterThan, Is.False);
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
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b < a;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = mpf.cmp_si(a, -1922215141) < 0;
        Assert.IsTrue(IsLesserThan);

        double d = 2e5;

        IsLesserThan = d < b;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b < d;
        Assert.That(IsLesserThan, Is.False);

        int e = -10;

        IsLesserThan = e < b;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b < e;
        Assert.That(IsLesserThan, Is.False);

        ulong f = 10UL;

        IsLesserThan = f < b;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b < f;
        Assert.That(IsLesserThan, Is.False);

        float g = 2e5F;

        IsLesserThan = g < b;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b < g;
        Assert.That(IsLesserThan, Is.False);
    }

    [Test]
    public void LesserThanOrEqual()
    {
        string AsString;
        bool IsLesserThan;

        using mpf_t a = new mpf_t("-22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        IsLesserThan = a <= b;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b <= a;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = mpf.cmp_si(a, -1922215141) < 0;
        Assert.IsTrue(IsLesserThan);

        double d = 2e5;

        IsLesserThan = d <= b;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b <= d;
        Assert.That(IsLesserThan, Is.False);

        int e = -10;

        IsLesserThan = e <= b;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b <= e;
        Assert.That(IsLesserThan, Is.False);

        ulong f = 10UL;

        IsLesserThan = f <= b;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b <= f;
        Assert.That(IsLesserThan, Is.False);

        float g = 2e5F;

        IsLesserThan = g <= b;
        Assert.That(IsLesserThan, Is.True);

        IsLesserThan = b <= g;
        Assert.That(IsLesserThan, Is.False);
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
        Assert.That(IsEqualTo, Is.True);

        IsDifferentThan = a != b;
        Assert.That(IsDifferentThan, Is.True);

        IsEqualTo = mpf_t.EqualBits(a, c, 1);
        Assert.That(IsEqualTo, Is.True);

        ulong ul = 124UL;

        IsEqualTo = a == ul;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = ul == a;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != ul;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = ul != a;
        Assert.That(IsDifferentThan, Is.True);

        long l = 124L;

        IsEqualTo = a == l;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = l == a;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != l;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = l != a;
        Assert.That(IsDifferentThan, Is.True);

        float f = 124.0F;

        IsEqualTo = a == f;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = f == a;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != f;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = f != a;
        Assert.That(IsDifferentThan, Is.True);

        double d = 124.0;

        IsEqualTo = a == d;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = d == a;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != d;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = d != a;
        Assert.That(IsDifferentThan, Is.True);

        IsEqualTo = a.Equals(c);
        Assert.That(IsEqualTo, Is.True);

        object? Instance = c;

        IsEqualTo = a.Equals(Instance);
        Assert.That(IsEqualTo, Is.False);

        Instance = null;

        IsEqualTo = a.Equals(Instance);
        Assert.That(IsEqualTo, Is.False);

        Assert.Throws<ArgumentNullException>(() => a.Equals(null));
        Assert.Throws<ArgumentNullException>(() => a.CompareTo(null));

        IEquatable<mpf_t> Equatable = a;

        IsEqualTo = Equatable.Equals(c);
        Assert.That(IsEqualTo, Is.True);

        int HashCode = a.GetHashCode();

        using mpf_t diff = mpf_t.RelativeDifference(a, b);
        AsString = diff.ToString();
        Assert.That(AsString, Is.EqualTo("9.99999999899785356234E-1"));
    }

    [Test]
    public void CompareTo()
    {
        string AsString;
        bool IsLesserThan;

        using mpf_t a = new mpf_t("-22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-2.22509832503450298345E+25"));

        using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.22987435987982730594E+15"));

        object? Instance = b;

        IsLesserThan = a.CompareTo(Instance) < 0;
        Assert.That(IsLesserThan, Is.True);

        IComparable Comparable = a;

        IsLesserThan = Comparable.CompareTo(Instance) < 0;
        Assert.That(IsLesserThan, Is.True);

        Instance = null;
        Assert.Throws<ArgumentException>(() => a.CompareTo(Instance));
        Assert.Throws<ArgumentException>(() => Comparable.CompareTo(Instance));
    }
}
