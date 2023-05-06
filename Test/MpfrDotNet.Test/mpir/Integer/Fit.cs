namespace TestInteger;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;
using System.IO;
using System.Text;

[TestClass]
public class Fit
{
    [TestMethod]
    public void FitULong()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new mpz_t("FFFFFFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("FFFFFFFF", AsString);

        IsFitting = mpz.fits_ulong_p(a);
        Assert.IsTrue(IsFitting);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_ulong_p(b);
        Assert.IsFalse(IsFitting);
    }

    [TestMethod]
    public void FitLong()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new mpz_t("7FFFFFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("7FFFFFFF", AsString);

        IsFitting = mpz.fits_slong_p(a);
        Assert.IsTrue(IsFitting);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_slong_p(b);
        Assert.IsFalse(IsFitting);

        using mpz_t c = -b;

        IsFitting = mpz.fits_slong_p(c);
        Assert.IsTrue(IsFitting);

        using mpz_t d = c - 1;

        IsFitting = mpz.fits_slong_p(d);
        Assert.IsFalse(IsFitting);
    }

    [TestMethod]
    public void FitUInt()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new mpz_t("FFFFFFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("FFFFFFFF", AsString);

        IsFitting = mpz.fits_uint_p(a);
        Assert.IsTrue(IsFitting);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_uint_p(b);
        Assert.IsFalse(IsFitting);
    }

    [TestMethod]
    public void FitInt()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new mpz_t("7FFFFFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("7FFFFFFF", AsString);

        IsFitting = mpz.fits_sint_p(a);
        Assert.IsTrue(IsFitting);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_sint_p(b);
        Assert.IsFalse(IsFitting);

        using mpz_t c = -b;

        IsFitting = mpz.fits_sint_p(c);
        Assert.IsTrue(IsFitting);

        using mpz_t d = c - 1;

        IsFitting = mpz.fits_sint_p(d);
        Assert.IsFalse(IsFitting);
    }

    [TestMethod]
    public void FitUShort()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new mpz_t("FFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("FFFF", AsString);

        IsFitting = mpz.fits_ushort_p(a);
        Assert.IsTrue(IsFitting);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_ushort_p(b);
        Assert.IsFalse(IsFitting);
    }

    [TestMethod]
    public void FitShort()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new mpz_t("7FFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("7FFF", AsString);

        IsFitting = mpz.fits_sshort_p(a);
        Assert.IsTrue(IsFitting);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_sshort_p(b);
        Assert.IsFalse(IsFitting);

        using mpz_t c = -b;

        IsFitting = mpz.fits_sshort_p(c);
        Assert.IsTrue(IsFitting);

        using mpz_t d = c - 1;

        IsFitting = mpz.fits_sshort_p(d);
        Assert.IsFalse(IsFitting);
    }

    [TestMethod]
    public void OddEvent()
    {
        string AsString;
        bool IsEven;
        bool IsOdd;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.AreEqual("222509832503450298345029835740293845720", AsString);

        IsEven = mpz.even_p(a);
        IsOdd = mpz.odd_p(a);

        Assert.IsTrue(IsEven);
        Assert.IsFalse(IsOdd);

        using mpz_t b = a + 1;

        IsEven = mpz.even_p(b);
        IsOdd = mpz.odd_p(b);

        Assert.IsFalse(IsEven);
        Assert.IsTrue(IsOdd);
    }
}
