namespace TestInteger;

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

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

        IsGreaterThan = a > b;
        Assert.That(IsGreaterThan, Is.True);

        float f = 50.0F;

        IsGreaterThan = a > f;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = f > a;
        Assert.That(IsGreaterThan, Is.False);

        double d = 50.0;

        IsGreaterThan = a > d;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = d > a;
        Assert.That(IsGreaterThan, Is.False);

        int n = 50;

        IsGreaterThan = a > n;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = n > a;
        Assert.That(IsGreaterThan, Is.False);

        uint p = 50U;

        IsGreaterThan = a > p;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = p > a;
        Assert.That(IsGreaterThan, Is.False);

        long l = 50L;

        IsGreaterThan = a > l;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = l > a;
        Assert.That(IsGreaterThan, Is.False);

        ulong ul = 50UL;

        IsGreaterThan = a > ul;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = ul > a;
        Assert.That(IsGreaterThan, Is.False);
    }

    [Test]
    public void GreaterThanEqualTo()
    {
        string AsString;
        bool IsGreaterThan;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

        IsGreaterThan = a >= b;
        Assert.That(IsGreaterThan, Is.True);

        float f = 50.0F;

        IsGreaterThan = a >= f;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = f >= a;
        Assert.That(IsGreaterThan, Is.False);

        double d = 50.0;

        IsGreaterThan = a >= d;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = d >= a;
        Assert.That(IsGreaterThan, Is.False);

        int n = 50;

        IsGreaterThan = a >= n;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = n >= a;
        Assert.That(IsGreaterThan, Is.False);

        uint p = 50U;

        IsGreaterThan = a >= p;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = p >= a;
        Assert.That(IsGreaterThan, Is.False);

        long l = 50L;

        IsGreaterThan = a >= l;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = l >= a;
        Assert.That(IsGreaterThan, Is.False);

        ulong ul = 50UL;

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

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

        IsLesserThan = a < b;
        Assert.That(IsLesserThan, Is.False);

        float f = 50.0F;

        IsLesserThan = a < f;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = f < a;
        Assert.That(IsLesserThan, Is.True);

        double d = 50.0;

        IsLesserThan = a < d;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = d < a;
        Assert.That(IsLesserThan, Is.True);

        int n = 50;

        IsLesserThan = a < n;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = n < a;
        Assert.That(IsLesserThan, Is.True);

        uint p = 50U;

        IsLesserThan = a < p;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = p < a;
        Assert.That(IsLesserThan, Is.True);

        long l = 50L;

        IsLesserThan = a < l;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = l < a;
        Assert.That(IsLesserThan, Is.True);

        ulong ul = 50UL;

        IsLesserThan = a < ul;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = ul < a;
        Assert.That(IsLesserThan, Is.True);
    }

    [Test]
    public void LesserThanEqualTo()
    {
        string AsString;
        bool IsLesserThan;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

        IsLesserThan = a <= b;
        Assert.That(IsLesserThan, Is.False);

        float f = 50.0F;

        IsLesserThan = a <= f;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = f <= a;
        Assert.That(IsLesserThan, Is.True);

        double d = 50.0;

        IsLesserThan = a <= d;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = d <= a;
        Assert.That(IsLesserThan, Is.True);

        int n = 50;

        IsLesserThan = a <= n;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = n <= a;
        Assert.That(IsLesserThan, Is.True);

        uint p = 50U;

        IsLesserThan = a <= p;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = p <= a;
        Assert.That(IsLesserThan, Is.True);

        long l = 50L;

        IsLesserThan = a <= l;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = l <= a;
        Assert.That(IsLesserThan, Is.True);

        ulong ul = 50UL;

        IsLesserThan = a <= ul;
        Assert.That(IsLesserThan, Is.False);

        IsLesserThan = ul <= a;
        Assert.That(IsLesserThan, Is.True);
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
        Assert.That(IsGreaterThan, Is.True);

        double d = 50.0;

        IsGreaterThan = mpz.cmpabs_d(a, d) > 0;
        Assert.That(IsGreaterThan, Is.True);

        uint p = 50U;

        IsGreaterThan = mpz.cmpabs_ui(a, p) > 0;
        Assert.That(IsGreaterThan, Is.True);
    }

    [Test]
    public void Sign()
    {
        string AsString;

        using mpz_t a = new mpz_t("-622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-622288097498926496141095869268883999563096063592498055290461"));

        bool IsNegative = mpz.sgn(a) < 0;
        Assert.IsTrue(IsNegative);

        using mpz_t b = -a;

        bool IsPositive = mpz.sgn(b) > 0;
        Assert.IsTrue(IsPositive);

        using mpz_t c = new mpz_t();
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("0"));

        bool HasNoSign = mpz.sgn(c) == 0;
        Assert.IsTrue(HasNoSign);
    }

    [Test]
    public void CompareTo()
    {
        string AsString;
        bool IsGreaterThan;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

        IsGreaterThan = a.CompareTo(1.0F) > 0;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = a.CompareTo(1.0) > 0;
        Assert.That(IsGreaterThan, Is.True);

        mpz_t? Instance = b;

        IsGreaterThan = a.CompareTo(Instance) > 0;
        Assert.That(IsGreaterThan, Is.True);

        Instance = null;
        Assert.Throws<ArgumentNullException>(() => a.CompareTo(Instance));

        object? Object = b;
        IComparable Comparable = a;

        IsGreaterThan = a.CompareTo(Object) > 0;
        Assert.That(IsGreaterThan, Is.True);

        IsGreaterThan = Comparable.CompareTo(Object) > 0;
        Assert.That(IsGreaterThan, Is.True);

        Object = null;
        Assert.Throws<ArgumentException>(() => a.CompareTo(Object));
    }

    [Test]
    public void EqualTo()
    {
        string AsString;
        bool IsEqualTo;
        bool IsDifferentThan;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

        using mpz_t c = a;

        IsEqualTo = a == c;
        Assert.That(IsEqualTo, Is.True);

        float f = 50.0F;

        IsEqualTo = a == f;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo  = f == a;
        Assert.That(IsEqualTo , Is.False);

        IsDifferentThan = a != f;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = f != a;
        Assert.That(IsDifferentThan, Is.True);

        double d = 50.0;

        IsEqualTo = a == d;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = d == a;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != d;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = d != a;
        Assert.That(IsDifferentThan, Is.True);

        int n = 50;

        IsEqualTo = a == n;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = n == a;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != n;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = n != a;
        Assert.That(IsDifferentThan, Is.True);

        uint p = 50U;

        IsEqualTo = a == p;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = p == a;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != p;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = p != a;
        Assert.That(IsDifferentThan, Is.True);

        long l = 50L;

        IsEqualTo = a == l;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = l == a;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != l;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = l != a;
        Assert.That(IsDifferentThan, Is.True);

        ulong ul = 50UL;

        IsEqualTo = a == ul;
        Assert.That(IsEqualTo, Is.False);

        IsEqualTo = ul == a;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != ul;
        Assert.That(IsDifferentThan, Is.True);

        IsDifferentThan = ul != a;
        Assert.That(IsDifferentThan, Is.True);

        IEquatable<mpz_t> Equatable = a;

        mpz_t? Instance = c;

        IsEqualTo = a.Equals(Instance);
        Assert.That(IsEqualTo, Is.True);

        IsEqualTo = Equatable.Equals(Instance);
        Assert.That(IsEqualTo, Is.True);

        Instance = null;

        Assert.Throws<ArgumentNullException>(() => a.Equals(Instance));

        object? Object = c;

        IsEqualTo = a.Equals(Object);
        Assert.That(IsEqualTo, Is.True);

        Object = null;

        IsEqualTo = a.Equals(Object);
        Assert.That(IsEqualTo, Is.False);
    }
}
