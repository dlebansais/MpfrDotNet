namespace TestRational;

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

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        IsGreaterThan = a > b;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = mpq.cmp_ui(a, 1922215141, 1) > 0;
        Assert.IsTrue(IsGreaterThan);

        using mpz_t c = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        IsGreaterThan = a > c;
        Assert.That(IsGreaterThan, Is.False);
    }

    [Test]
    public void GreaterThanOrEqual()
    {
        string AsString;
        bool IsGreaterThan;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        IsGreaterThan = a >= b;
        Assert.IsTrue(IsGreaterThan);

        IsGreaterThan = mpq.cmp_ui(a, 1922215141, 1) > 0;
        Assert.IsTrue(IsGreaterThan);

        using mpz_t c = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        IsGreaterThan = a >= c;
        Assert.That(IsGreaterThan, Is.False);
    }

    [Test]
    public void LesserThan()
    {
        string AsString;
        bool IsLesserThan;

        using mpq_t a = new mpq_t("-222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        IsLesserThan = a < b;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = mpq.cmp_si(a, -1922215141, 1) < 0;
        Assert.IsTrue(IsLesserThan);

        using mpz_t c = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        IsLesserThan = a < c;
        Assert.That(IsLesserThan, Is.True);
    }

    [Test]
    public void LesserThanOrEqual()
    {
        string AsString;
        bool IsLesserThan;

        using mpq_t a = new mpq_t("-222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        IsLesserThan = a <= b;
        Assert.IsTrue(IsLesserThan);

        IsLesserThan = mpq.cmp_si(a, -1922215141, 1) < 0;
        Assert.IsTrue(IsLesserThan);

        using mpz_t c = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        IsLesserThan = a <= c;
        Assert.That(IsLesserThan, Is.True);
    }

    [Test]
    public void IsEqual()
    {
        string AsString;
        bool IsEqualTo;
        bool IsDifferentThan;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        using mpq_t c = a;

        IsEqualTo = a == c;
        Assert.IsTrue(IsEqualTo);

        IsDifferentThan = a != b;
        Assert.IsTrue(IsDifferentThan);

        using mpz_t d = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        IsEqualTo = a == d;
        Assert.That(IsEqualTo, Is.False);

        IsDifferentThan = a != d;
        Assert.That(IsDifferentThan, Is.True);

        IsEqualTo = a.Equals(d);
        Assert.That(IsEqualTo, Is.False);

        mpq_t? Instance = null;
        Assert.Throws<ArgumentNullException>(() => a.Equals(Instance));

        IEquatable<mpq_t> Equatable = a;

        IsEqualTo = Equatable.Equals(d);
        Assert.That(IsEqualTo, Is.False);

        object? Object = c;

        IsEqualTo = a.Equals(Object);
        Assert.That(IsEqualTo, Is.True);

        Object = null;

        IsEqualTo = a.Equals(Object);
        Assert.That(IsEqualTo, Is.False);

        _ = a.GetHashCode();
    }

    [Test]
    public void CompareTo()
    {
        string AsString;
        bool IsLesserThan;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        IsLesserThan = a.CompareTo(b) > 0;
        Assert.That(IsLesserThan, Is.True);

        using mpq_t? c = null;
        Assert.Throws<ArgumentNullException>(() => _ = a.CompareTo(c));

        object? Instance = b;

        IsLesserThan = a.CompareTo(Instance) > 0;
        Assert.That(IsLesserThan, Is.True);

        IComparable Comparable = a;

        IsLesserThan = Comparable.CompareTo(Instance) > 0;
        Assert.That(IsLesserThan, Is.True);

        Instance = null;
        Assert.Throws<ArgumentException>(() => _ = a.CompareTo(Instance));
    }
}
