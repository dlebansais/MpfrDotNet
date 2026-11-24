namespace TestInteger;

using MpirDotNet;
using System;
using System.IO;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class Fit
{
    [Test]
    public void FitULong()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new("FFFFFFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("FFFFFFFF"));

        IsFitting = mpz.fits_ulong_p(a);
        Assert.That(IsFitting, Is.True);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_ulong_p(b);
        Assert.That(IsFitting, Is.False);
    }

    [Test]
    public void FitLong()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new("7FFFFFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("7FFFFFFF"));

        IsFitting = mpz.fits_slong_p(a);
        Assert.That(IsFitting, Is.True);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_slong_p(b);
        Assert.That(IsFitting, Is.False);

        using mpz_t c = -b;

        IsFitting = mpz.fits_slong_p(c);
        Assert.That(IsFitting, Is.True);

        using mpz_t d = c - 1;

        IsFitting = mpz.fits_slong_p(d);
        Assert.That(IsFitting, Is.False);
    }

    [Test]
    public void FitUInt()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new("FFFFFFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("FFFFFFFF"));

        IsFitting = mpz.fits_uint_p(a);
        Assert.That(IsFitting, Is.True);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_uint_p(b);
        Assert.That(IsFitting, Is.False);
    }

    [Test]
    public void FitInt()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new("7FFFFFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("7FFFFFFF"));

        IsFitting = mpz.fits_sint_p(a);
        Assert.That(IsFitting, Is.True);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_sint_p(b);
        Assert.That(IsFitting, Is.False);

        using mpz_t c = -b;

        IsFitting = mpz.fits_sint_p(c);
        Assert.That(IsFitting, Is.True);

        using mpz_t d = c - 1;

        IsFitting = mpz.fits_sint_p(d);
        Assert.That(IsFitting, Is.False);
    }

    [Test]
    public void FitUShort()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new("FFFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("FFFF"));

        IsFitting = mpz.fits_ushort_p(a);
        Assert.That(IsFitting, Is.True);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_ushort_p(b);
        Assert.That(IsFitting, Is.False);
    }

    [Test]
    public void FitShort()
    {
        string AsString;
        bool IsFitting;

        using mpz_t a = new("7FFF", 16);
        AsString = a.ToString(16).ToUpper();
        Assert.That(AsString, Is.EqualTo("7FFF"));

        IsFitting = mpz.fits_sshort_p(a);
        Assert.That(IsFitting, Is.True);

        using mpz_t b = a + 1;

        IsFitting = mpz.fits_sshort_p(b);
        Assert.That(IsFitting, Is.False);

        using mpz_t c = -b;

        IsFitting = mpz.fits_sshort_p(c);
        Assert.That(IsFitting, Is.True);

        using mpz_t d = c - 1;

        IsFitting = mpz.fits_sshort_p(d);
        Assert.That(IsFitting, Is.False);
    }

    [Test]
    public void OddEvent()
    {
        string AsString;
        bool IsEven;
        bool IsOdd;

        using mpz_t a = new("222509832503450298345029835740293845720", 16);
        AsString = a.ToString(16).ToUpper();
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        IsEven = mpz.even_p(a);
        IsOdd = mpz.odd_p(a);

        Assert.That(IsEven, Is.True);
        Assert.That(IsOdd, Is.False);

        using mpz_t b = a + 1;

        IsEven = mpz.even_p(b);
        IsOdd = mpz.odd_p(b);

        Assert.That(IsEven, Is.False);
        Assert.That(IsOdd, Is.True);

        using mpz_t c = new(0);

        IsEven = mpz.even_p(c);
        IsOdd = mpz.odd_p(c);

        Assert.That(IsEven, Is.True);
        Assert.That(IsOdd, Is.False);
    }
}
