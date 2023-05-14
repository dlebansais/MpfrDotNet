namespace TestInteger;

using MpirDotNet;
using System.Text;
using NUnit.Framework;
using System;

[TestFixture]
public class Misc
{
    [Test]
    public void Init2()
    {
        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");

        mpz.init2(a, 20);

        string AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("0"));
    }

    [Test]
    public void Array()
    {
        string AsString;
        int ArrayLength = 10;

        mpz_t[] TestArray = mpz_t.CreateArray(ArrayLength);

        Assert.That(TestArray.Length, Is.EqualTo(ArrayLength));

        foreach (mpz_t Item in TestArray)
        {
            AsString = Item.ToString();
            Assert.That(AsString, Is.EqualTo("0"));
        }

        foreach (mpz_t Item in TestArray)
            Item.Dispose();

        Assert.Throws<ArgumentException>(() => mpz_t.CreateArray(0xFFFF));
    }

    [Test]
    public void Realloc2()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");

        mpz.realloc2(a, 2000);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        mpz.realloc2(a, 20);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("0"));
    }

    [Test]
    public void Set()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        mpz.set_ui(a, 2000);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2000"));

        mpz.set_si(a, -1000);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-1000"));

        mpz.set_ux(a, 1099511627557UL);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1099511627557"));

        mpz.set_sx(a, -2597542236477880L);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-2597542236477880"));

        mpz.set_d(a, -45487.0);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-45487"));

        using mpq_t q = new mpq_t(50, 1);
        mpz.set_q(a, q);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("50"));

        using mpf_t f = new mpf_t(-80);
        mpz.set_f(a, f);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-80"));

        mpz.set_str(a, "445497268491433028939318409770173720259", 10);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("445497268491433028939318409770173720259"));

        mpz.set_str(a, "FF", 16);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("255"));

        using mpz_t b = new mpz_t("222509832503450298345029835740293845720");

        mpz.swap(a, b);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));
    }

    [Test]
    public void InitSet()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        using mpz_t b = new mpz_t(a);

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        using mpz_t c = new mpz_t(20U);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("20"));

        using mpz_t d = new mpz_t(-20);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-20"));

        using mpz_t e = new mpz_t(1099511627557);

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("1099511627557"));

        using mpz_t f = new mpz_t(-2597542236477880L);

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-2597542236477880"));

        using mpz_t g = new mpz_t(896.0);

        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("896"));

        using mpz_t h = new mpz_t("FF", 16);

        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("255"));

        using mpz_t i = new mpz_t(20UL);

        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("20"));
    }

    [Test]
    public void Get()
    {
        using mpz_t a = new mpz_t();

        mpz.set_ui(a, 2000U);
        Assert.That(mpz.get_ui(a), Is.EqualTo(2000U));

        mpz.set_si(a, -1000);
        Assert.That(mpz.get_si(a), Is.EqualTo(-1000));

        mpz.set_ux(a, 1099511627557UL);
        Assert.That(mpz.get_ux(a), Is.EqualTo(1099511627557UL));

        mpz.set_sx(a, -2597542236477880L);
        Assert.That(mpz.get_sx(a), Is.EqualTo(-2597542236477880L));

        mpz.set_d(a, -45487.0);
        Assert.That(mpz.get_d(a), Is.EqualTo(-45487.0));

        mpz.get_d_2exp(a, out double d, out long exp);
        Assert.That(d, Is.EqualTo(-0.6940765380859375));
        Assert.That(exp, Is.EqualTo(16L));

        StringBuilder str = new();
        mpz.get_str(str, 10, a);

        string AsString = str.ToString();
        Assert.That(AsString, Is.EqualTo("-45487"));
    }
}
