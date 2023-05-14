namespace TestRational;

using System;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Misc
{
    [Test]
    public void Create()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = new mpq_t(a);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t c = new(a.GetNumerator());
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        using mpq_t d = new(30UL, 10);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("30/10"));

        using mpq_t e = new(30UL, 10, true);
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("3"));

        using mpq_t f = new(-30L, 10);
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-30/10"));

        using mpq_t g = new(-30L, 10, true);
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("-3"));

        using mpq_t h = new(0.25);
        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("1/4"));

        using mpz_t n0 = new mpz_t("222509832503450298345029835740293845720");
        using mpz_t d0 = new mpz_t("115756986668303657898962467957");
        using mpq_t q0 = new mpq_t(n0, d0);
        AsString = q0.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpf_t ft = new(0.25);
        using mpq_t i = new(ft);
        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("1/4"));
    }

    [Test]
    public void Array()
    {
        string AsString;
        int ArrayLength = 10;

        mpq_t[] TestArray = mpq_t.CreateArray(ArrayLength);

        Assert.That(TestArray.Length, Is.EqualTo(ArrayLength));

        foreach (mpq_t Item in TestArray)
        {
            AsString = Item.ToString();
            Assert.That(AsString, Is.EqualTo("0"));
        }

        mpq_t.ClearArray(TestArray);

        foreach (mpq_t Item in TestArray)
            Item.Dispose();

        Assert.Throws<ArgumentException>(() => mpq_t.CreateArray(0xFFFF));

        mpq_t[] LargeArray = new mpq_t[0xFFFF];
        Assert.Throws<ArgumentException>(() => mpq_t.ClearArray(LargeArray));
    }

    [Test]
    public void Sign()
    {
        using mpq_t a = new mpq_t(2);

        bool IsPositive = a.Sign > 0;
        Assert.That(IsPositive, Is.True);

        using mpq_t b = new mpq_t(-2);

        bool IsNegative = b.Sign < 0;
        Assert.That(IsNegative, Is.True);

        using mpq_t c = new mpq_t();

        bool HasNoSign = c.Sign == 0;
        Assert.That(HasNoSign, Is.True);
    }

    [Test]
    public void Swap()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        mpq_t.Swap(a, b);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539/590872612825179551336102196593"));

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));
    }

    [Test]
    public void Conversion()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        double d = (double)a;
        Assert.That(d, Is.EqualTo(1922215141.4587355));
    }
}
