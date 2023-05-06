namespace TestInteger;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;
using System.Text;

[TestClass]
public class Bitwise
{
    [TestMethod]
    public void And()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", AsString);

        using mpz_t b = new mpz_t("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF", 16);
        AsString = b.ToString(16).ToUpper();
        Assert.AreEqual("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF", AsString);

        using mpz_t c = a & b;
        AsString = c.ToString(16).ToUpper();
        Assert.AreEqual("100000000000000000123456789ABCDEF0123456789ABCDEF", AsString);
    }

    [TestMethod]
    public void Or()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", AsString);

        using mpz_t b = new mpz_t("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF", 16);
        AsString = b.ToString(16).ToUpper();
        Assert.AreEqual("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF", AsString);

        using mpz_t c = a | b;
        AsString = c.ToString(16).ToUpper();
        Assert.AreEqual("10123456789ABCDEF0123456789ABCDEFFFFFFFFFFFFFFFFF", AsString);
    }

    [TestMethod]
    public void Xor()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", AsString);

        using mpz_t b = new mpz_t("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF", 16);
        AsString = b.ToString(16).ToUpper();
        Assert.AreEqual("100000000000000000123456789ABCDEFFFFFFFFFFFFFFFFF", AsString);

        using mpz_t c = a ^ b;
        AsString = c.ToString(16).ToUpper();
        Assert.AreEqual("123456789ABCDEF0000000000000000FEDCBA9876543210", AsString);
    }

    [TestMethod]
    public void Not()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", AsString);

        using mpz_t c = ~a;
        AsString = c.ToString(16).ToUpper();
        Assert.AreEqual("-10123456789ABCDEF0123456789ABCDEF0123456789ABCDF0", AsString);

        using mpz_t d = -a - 1;
        AsString = d.ToString(16).ToUpper();
        Assert.AreEqual("-10123456789ABCDEF0123456789ABCDEF0123456789ABCDF0", AsString);
    }

    [TestMethod]
    public void PopCount()
    {
        string AsString;

        using mpz_t a = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", AsString);

        ulong Count = mpz.popcount(a);

        Assert.AreEqual(Count, 97UL);
    }

    [TestMethod]
    public void HammingDistance()
    {
        string AsString;

        using mpz_t a = new mpz_t("1ABCDE08984948281360922385394772450147012613851354F03", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("1ABCDE08984948281360922385394772450147012613851354F03", AsString);

        using mpz_t b = new mpz_t("1ABCDEF8984948281360922345394772450147012613851354303", 16);
        AsString = b.ToString(16).ToUpper();
        Assert.AreEqual("1ABCDEF8984948281360922345394772450147012613851354303", AsString);

        ulong Count = mpz.hamdist(a, b);

        Assert.AreEqual(Count, 8UL);
    }

    [TestMethod]
    public void Scan0()
    {
        string AsString;
        ulong Scan;

        using mpz_t a = new mpz_t("A0000000000000000000800000000001", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("A0000000000000000000800000000001", AsString);

        Scan = mpz.scan0(a, 0);
        Assert.AreEqual(Scan, 1UL);

        Scan = mpz.scan0(a, 1UL);
        Assert.AreEqual(Scan, 1UL);

        Scan = mpz.scan0(a, 9UL);
        Assert.AreEqual(Scan, 9UL);

        Scan = mpz.scan0(a, 127UL);
        Assert.AreEqual(Scan, 128UL);

        Scan = mpz.scan1(a, 0);
        Assert.AreEqual(Scan, 0UL);

        Scan = mpz.scan1(a, 1UL);
        Assert.AreEqual(Scan, 47UL);

        Scan = mpz.scan1(a, 47UL);
        Assert.AreEqual(Scan, 47UL);

        Scan = mpz.scan1(a, 48UL);
        Assert.AreEqual(Scan, 125UL);
    }

    [TestMethod]
    public void SetBit()
    {
        string AsString;

        using mpz_t a = new mpz_t("A0000000000000000000200000000001", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("A0000000000000000000200000000001", AsString);

        a.SetBit(47);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("A0000000000000000000A00000000001", AsString);

        a.SetBit(47);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("A0000000000000000000A00000000001", AsString);

        a.ClearBit(45);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("A0000000000000000000800000000001", AsString);

        a.ClearBit(45);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("A0000000000000000000800000000001", AsString);

        a.ClearBit(131);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("A0000000000000000000800000000001", AsString);

        a.SetBit(131);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("8A0000000000000000000800000000001", AsString);
    }

    [TestMethod]
    public void GetBit()
    {
        string AsString;
        bool IsBitSet;

        using mpz_t a = new mpz_t("A000000000000000000200000000001", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("A000000000000000000200000000001", AsString);

        IsBitSet = a.GetBit(45);
        Assert.IsTrue(IsBitSet);

        IsBitSet = a.GetBit(46);
        Assert.IsFalse(IsBitSet);
    }
}
