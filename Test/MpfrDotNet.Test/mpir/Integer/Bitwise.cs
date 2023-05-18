namespace TestInteger;

using MpirDotNet;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class Bitwise
{
    [Test]
    public void And()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"));

        using mpz_t b = new mpz_t("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF", 16);
        AsString = b.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF"));

        using mpz_t c = a & b;
        AsString = c.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("100000000000000000123456789ABCDEF0123456789ABCDEF"));
    }

    [Test]
    public void Or()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"));

        using mpz_t b = new mpz_t("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF", 16);
        AsString = b.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF"));

        using mpz_t c = a | b;
        AsString = c.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("10123456789ABCDEF0123456789ABCDEFFFFFFFFFFFFFFFFF"));
    }

    [Test]
    public void Xor()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"));

        using mpz_t b = new mpz_t("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF", 16);
        AsString = b.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF"));

        using mpz_t c = a ^ b;
        AsString = c.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("123456789ABCDEF0000000000000000FEDCBA9876543210"));
    }

    [Test]
    public void Not()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"));

        using mpz_t c = ~a;
        AsString = c.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("-10123456789ABCDEF0123456789ABCDEF0123456789ABCDF0"));

        using mpz_t d = -a - 1;
        AsString = d.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("-10123456789ABCDEF0123456789ABCDEF0123456789ABCDF0"));
    }

    [Test]
    public void PopCount()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"));

        ulong Count = mpz.popcount(a);

        Assert.That(Count, Is.EqualTo(97UL));
    }

    [Test]
    public void HammingDistance()
    {
        string AsString;

        using mpz_t a = new mpz_t("1ABCDE08984948281360922385394772450147012613851354F03", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("1ABCDE08984948281360922385394772450147012613851354F03"));

        using mpz_t b = new mpz_t("1ABCDEF8984948281360922345394772450147012613851354303", 16);
        AsString = b.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("1ABCDEF8984948281360922345394772450147012613851354303"));

        ulong Count = mpz.hamdist(a, b);

        Assert.That(Count, Is.EqualTo(8UL));
    }

    [Test]
    public void Scan0()
    {
        string AsString;
        ulong Scan;

        using mpz_t a = new mpz_t("A0000000000000000000800000000001", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("A0000000000000000000800000000001"));

        Scan = mpz.scan0(a, 0);
        Assert.That(Scan, Is.EqualTo(1UL));

        Scan = mpz.scan0(a, 1UL);
        Assert.That(Scan, Is.EqualTo(1UL));

        Scan = mpz.scan0(a, 9UL);
        Assert.That(Scan, Is.EqualTo(9UL));

        Scan = mpz.scan0(a, 127UL);
        Assert.That(Scan, Is.EqualTo(128UL));

        Scan = mpz.scan1(a, 0);
        Assert.That(Scan, Is.EqualTo(0UL));

        Scan = mpz.scan1(a, 1UL);
        Assert.That(Scan, Is.EqualTo(47UL));

        Scan = mpz.scan1(a, 47UL);
        Assert.That(Scan, Is.EqualTo(47UL));

        Scan = mpz.scan1(a, 48UL);
        Assert.That(Scan, Is.EqualTo(125UL));
    }

    [Test]
    public void SetBit()
    {
        string AsString;

        using mpz_t a = new mpz_t("A0000000000000000000200000000001", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("A0000000000000000000200000000001"));

        a.SetBit(47);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("A0000000000000000000A00000000001"));

        a.SetBit(47);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("A0000000000000000000A00000000001"));

        a.ClearBit(45);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("A0000000000000000000800000000001"));

        a.ClearBit(45);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("A0000000000000000000800000000001"));

        a.ClearBit(131);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("A0000000000000000000800000000001"));

        a.SetBit(131);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("8A0000000000000000000800000000001"));

        a.ChangeBit(131, true);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("8A0000000000000000000800000000001"));

        a.ChangeBit(131, false);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("A0000000000000000000800000000001"));
    }

    [Test]
    public void GetBit()
    {
        string AsString;
        bool IsBitSet;

        using mpz_t a = new mpz_t("A000000000000000000200000000001", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("A000000000000000000200000000001"));

        IsBitSet = a.GetBit(45);
        Assert.IsTrue(IsBitSet);

        IsBitSet = a.GetBit(46);
        Assert.IsFalse(IsBitSet);
    }
}
