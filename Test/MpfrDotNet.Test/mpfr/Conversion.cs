namespace Test;

using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;
using System.Numerics;

[TestFixture]
public class Conversion
{
    [Test]
    public void BasicConversion()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = (byte)1;
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1E+0"));
        Assert.That((byte)a, Is.EqualTo(1));

        using mpfr_t b = 2;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2E+0"));
        Assert.That((int)b, Is.EqualTo(2));

        using mpfr_t c = 3U;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("3E+0"));
        Assert.That((uint)c, Is.EqualTo(3U));

        using mpfr_t d = -8720124937520142L;
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));
        Assert.That((long)d, Is.EqualTo(-8720124937520142L));

        using mpfr_t e = 8720124937520142UL;
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("8.720124937520142E+15"));
        Assert.That((ulong)e, Is.EqualTo(8720124937520142UL));

        using mpfr_t f = (short)6;
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("6E+0"));
        Assert.That((short)f, Is.EqualTo((short)6));

        using mpfr_t g = (ushort)7;
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("7E+0"));
        Assert.That((ushort)g, Is.EqualTo((ushort)7));

        using mpfr_t h = 8.5F;
        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("8.5E+0"));
        Assert.That((float)h, Is.EqualTo(8.5F));

        using mpfr_t i = 16.5;
        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("1.65E+1"));
        Assert.That((double)i, Is.EqualTo(16.5));

        BigInteger bj = new BigInteger(898989898989898989);
        using mpfr_t j = bj;
        AsString = j.ToString();
        Assert.That(AsString, Is.EqualTo("8.98989898989898989E+17"));
        Assert.That((BigInteger)j, Is.EqualTo(bj));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void WithExponent()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        double d;
        int e;

        using mpfr_t a = 16.5;
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1.65E+1"));

        mpfr_t.ToDoubleAndExponent(a, out d, out e);

        Assert.That(d, Is.EqualTo(0.515625));
        Assert.That(e, Is.EqualTo(5));

        using mpz_t z1 = mpfr_t.ToIntegerAndExponent(a, out e);
        AsString = z1.ToString();
        Assert.That(AsString, Is.EqualTo("175458095443608895223302531957005484032"));
        Assert.That(e, Is.EqualTo(-123));

        using mpfr_t b = -16.5;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-1.65E+1"));

        mpfr_t.ToDoubleAndExponent(b, out d, out e);

        Assert.That(d, Is.EqualTo(-0.515625));
        Assert.That(e, Is.EqualTo(5));

        using mpz_t z2 = mpfr_t.ToIntegerAndExponent(b, out e);
        AsString = z2.ToString();
        Assert.That(AsString, Is.EqualTo("-175458095443608895223302531957005484032"));
        Assert.That(e, Is.EqualTo(-123));

        using mpfr_t c = 0.046875;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("4.6875E-2"));

        mpfr_t.ToDoubleAndExponent(c, out d, out e);

        Assert.That(d, Is.EqualTo(0.75));
        Assert.That(e, Is.EqualTo(-4));

        using mpz_t z3 = mpfr_t.ToIntegerAndExponent(c, out e);
        AsString = z3.ToString();
        Assert.That(AsString, Is.EqualTo("255211775190703847597530955573826158592"));
        Assert.That(e, Is.EqualTo(-132));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ToIntegralFractional()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        int e;

        using mpfr_t a = 16.5;
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1.65E+1"));

        using mpfr_t b = mpfr_t.ToIntegralFractional(a, out e);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("5.15625E-1"));
        Assert.That(e, Is.EqualTo(5));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
