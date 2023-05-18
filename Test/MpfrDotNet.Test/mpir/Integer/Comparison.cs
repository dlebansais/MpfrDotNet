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
        Assert.IsTrue(IsGreaterThan);

        double f = 50.0F;

        IsGreaterThan = a > f;
        Assert.IsTrue(IsGreaterThan);

        double d = 50.0;

        IsGreaterThan = a > d;
        Assert.IsTrue(IsGreaterThan);

        int n = 50;

        IsGreaterThan = a > n;
        Assert.IsTrue(IsGreaterThan);

        uint p = 50U;

        IsGreaterThan = a > p;
        Assert.IsTrue(IsGreaterThan);

        long l = 50L;

        IsGreaterThan = a > l;
        Assert.IsTrue(IsGreaterThan);

        ulong ul = 50UL;

        IsGreaterThan = a > ul;
        Assert.IsTrue(IsGreaterThan);
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
        Assert.IsTrue(IsGreaterThan);

        double f = 50.0F;

        IsGreaterThan = a >= f;
        Assert.IsTrue(IsGreaterThan);

        double d = 50.0;

        IsGreaterThan = a >= d;
        Assert.IsTrue(IsGreaterThan);

        int n = 50;

        IsGreaterThan = a >= n;
        Assert.IsTrue(IsGreaterThan);

        uint p = 50U;

        IsGreaterThan = a >= p;
        Assert.IsTrue(IsGreaterThan);

        long l = 50L;

        IsGreaterThan = a >= l;
        Assert.IsTrue(IsGreaterThan);

        ulong ul = 50UL;

        IsGreaterThan = a >= ul;
        Assert.IsTrue(IsGreaterThan);
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

        double f = 50.0F;

        IsLesserThan = a < f;
        Assert.That(IsLesserThan, Is.False);

        double d = 50.0;

        IsLesserThan = a < d;
        Assert.That(IsLesserThan, Is.False);

        int n = 50;

        IsLesserThan = a < n;
        Assert.That(IsLesserThan, Is.False);

        uint p = 50U;

        IsLesserThan = a < p;
        Assert.That(IsLesserThan, Is.False);

        long l = 50L;

        IsLesserThan = a < l;
        Assert.That(IsLesserThan, Is.False);

        ulong ul = 50UL;

        IsLesserThan = a < ul;
        Assert.That(IsLesserThan, Is.False);
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

        double f = 50.0F;

        IsLesserThan = a <= f;
        Assert.That(IsLesserThan, Is.False);

        double d = 50.0;

        IsLesserThan = a <= d;
        Assert.That(IsLesserThan, Is.False);

        int n = 50;

        IsLesserThan = a <= n;
        Assert.That(IsLesserThan, Is.False);

        uint p = 50U;

        IsLesserThan = a <= p;
        Assert.That(IsLesserThan, Is.False);

        long l = 50L;

        IsLesserThan = a <= l;
        Assert.That(IsLesserThan, Is.False);

        ulong ul = 50UL;

        IsLesserThan = a <= ul;
        Assert.That(IsLesserThan, Is.False);
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
        Assert.IsTrue(IsGreaterThan);

        double d = 50.0;

        IsGreaterThan = mpz.cmpabs_d(a, d) > 0;
        Assert.IsTrue(IsGreaterThan);

        uint p = 50U;

        IsGreaterThan = mpz.cmpabs_ui(a, p) > 0;
        Assert.IsTrue(IsGreaterThan);
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

        mpz_t? Instance = b;

        IsGreaterThan = a.CompareTo(Instance) > 0;
        Assert.That(IsGreaterThan, Is.True);

        Instance = null;
        Assert.Throws<ArgumentNullException>(() => a.CompareTo(Instance));
    }

    [Test]
    public void EqualTo()
    {
        string AsString;
        bool IsEqualTo;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

        using mpz_t c = a;

        IsEqualTo = a == c;
        Assert.That(IsEqualTo, Is.True);

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
