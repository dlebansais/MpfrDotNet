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

    [Test]
    public void ToRational()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpfr_t b = new mpfr_t(a);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.922215141458735700317777668394096349265E+9"));

        using mpq_t c = mpfr_t.ToRational(b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("19036696701859040601814679603844175557/9903520314283042199192993792"));

        using mpfr_t d = new mpfr_t(c);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.922215141458735700317777668394096349265E+9"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ToFloatingPoint()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpf_t a = new mpf_t("1.922215141458735700317777668394096349264532710024993989646213167488131290383535088039934635162353515625E+9");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1.92221514145873570032E+9"));

        using mpfr_t b = new mpfr_t(a);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.922215141458735700317777668394096349265E+9"));

        using mpf_t c = mpfr_t.ToFloatingPoint(b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.92221514145873570032E+9"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Fits()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new("18446744073709551616");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1.8446744073709551616E+19"));

        Assert.That(a.FitsUnsignedLong, Is.False);
        Assert.That(a.FitsSignedLong, Is.False);
        Assert.That(a.FitsUnsignedInt, Is.False);
        Assert.That(a.FitsSignedInt, Is.False);
        Assert.That(a.FitsUnsignedShort, Is.False);
        Assert.That(a.FitsSignedShort, Is.False);

        using mpfr_t b = new("18446744073709551615");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.8446744073709551615E+19"));

        Assert.That(b.FitsUnsignedLong, Is.True);
        Assert.That(b.FitsSignedLong, Is.False);
        Assert.That(b.FitsUnsignedInt, Is.False);
        Assert.That(b.FitsSignedInt, Is.False);
        Assert.That(b.FitsUnsignedShort, Is.False);
        Assert.That(b.FitsSignedShort, Is.False);

        using mpfr_t c = new("9223372036854775808");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9.223372036854775808E+18"));

        Assert.That(c.FitsUnsignedLong, Is.True);
        Assert.That(c.FitsSignedLong, Is.False);
        Assert.That(c.FitsUnsignedInt, Is.False);
        Assert.That(c.FitsSignedInt, Is.False);
        Assert.That(c.FitsUnsignedShort, Is.False);
        Assert.That(c.FitsSignedShort, Is.False);

        using mpfr_t d = new("-9223372036854775808");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-9.223372036854775808E+18"));

        Assert.That(d.FitsUnsignedLong, Is.False);
        Assert.That(d.FitsSignedLong, Is.True);
        Assert.That(d.FitsUnsignedInt, Is.False);
        Assert.That(d.FitsSignedInt, Is.False);
        Assert.That(d.FitsUnsignedShort, Is.False);
        Assert.That(d.FitsSignedShort, Is.False);

        using mpfr_t e = new("9223372036854775807");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("9.223372036854775807E+18"));

        Assert.That(e.FitsUnsignedLong, Is.True);
        Assert.That(e.FitsSignedLong, Is.True);
        Assert.That(e.FitsUnsignedInt, Is.False);
        Assert.That(e.FitsSignedInt, Is.False);
        Assert.That(e.FitsUnsignedShort, Is.False);
        Assert.That(e.FitsSignedShort, Is.False);

        using mpfr_t f = new("4294967296");
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("4.294967296E+9"));

        Assert.That(f.FitsUnsignedLong, Is.True);
        Assert.That(f.FitsSignedLong, Is.True);
        Assert.That(f.FitsUnsignedInt, Is.False);
        Assert.That(f.FitsSignedInt, Is.False);
        Assert.That(f.FitsUnsignedShort, Is.False);
        Assert.That(f.FitsSignedShort, Is.False);

        using mpfr_t g = new("4294967295");
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("4.294967295E+9"));

        Assert.That(g.FitsUnsignedLong, Is.True);
        Assert.That(g.FitsSignedLong, Is.True);
        Assert.That(g.FitsUnsignedInt, Is.True);
        Assert.That(g.FitsSignedInt, Is.False);
        Assert.That(g.FitsUnsignedShort, Is.False);
        Assert.That(g.FitsSignedShort, Is.False);

        using mpfr_t h = new("2147483648");
        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("2.147483648E+9"));

        Assert.That(h.FitsUnsignedLong, Is.True);
        Assert.That(h.FitsSignedLong, Is.True);
        Assert.That(h.FitsUnsignedInt, Is.True);
        Assert.That(h.FitsSignedInt, Is.False);
        Assert.That(h.FitsUnsignedShort, Is.False);
        Assert.That(h.FitsSignedShort, Is.False);

        using mpfr_t i = new("-2147483648");
        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("-2.147483648E+9"));

        Assert.That(i.FitsUnsignedLong, Is.False);
        Assert.That(i.FitsSignedLong, Is.True);
        Assert.That(i.FitsUnsignedInt, Is.False);
        Assert.That(i.FitsSignedInt, Is.True);
        Assert.That(i.FitsUnsignedShort, Is.False);
        Assert.That(i.FitsSignedShort, Is.False);

        using mpfr_t j = new("2147483647");
        AsString = j.ToString();
        Assert.That(AsString, Is.EqualTo("2.147483647E+9"));

        Assert.That(j.FitsUnsignedLong, Is.True);
        Assert.That(j.FitsSignedLong, Is.True);
        Assert.That(j.FitsUnsignedInt, Is.True);
        Assert.That(j.FitsSignedInt, Is.True);
        Assert.That(j.FitsUnsignedShort, Is.False);
        Assert.That(j.FitsSignedShort, Is.False);

        using mpfr_t k = new("65536");
        AsString = k.ToString();
        Assert.That(AsString, Is.EqualTo("6.5536E+4"));

        Assert.That(k.FitsUnsignedLong, Is.True);
        Assert.That(k.FitsSignedLong, Is.True);
        Assert.That(k.FitsUnsignedInt, Is.True);
        Assert.That(k.FitsSignedInt, Is.True);
        Assert.That(k.FitsUnsignedShort, Is.False);
        Assert.That(k.FitsSignedShort, Is.False);

        using mpfr_t l = new("65535");
        AsString = l.ToString();
        Assert.That(AsString, Is.EqualTo("6.5535E+4"));

        Assert.That(l.FitsUnsignedLong, Is.True);
        Assert.That(l.FitsSignedLong, Is.True);
        Assert.That(l.FitsUnsignedInt, Is.True);
        Assert.That(l.FitsSignedInt, Is.True);
        Assert.That(l.FitsUnsignedShort, Is.True);
        Assert.That(l.FitsSignedShort, Is.False);

        using mpfr_t m = new("32768");
        AsString = m.ToString();
        Assert.That(AsString, Is.EqualTo("3.2768E+4"));

        Assert.That(m.FitsUnsignedLong, Is.True);
        Assert.That(m.FitsSignedLong, Is.True);
        Assert.That(m.FitsUnsignedInt, Is.True);
        Assert.That(m.FitsSignedInt, Is.True);
        Assert.That(m.FitsUnsignedShort, Is.True);
        Assert.That(m.FitsSignedShort, Is.False);

        using mpfr_t n = new("-32768");
        AsString = n.ToString();
        Assert.That(AsString, Is.EqualTo("-3.2768E+4"));

        Assert.That(n.FitsUnsignedLong, Is.False);
        Assert.That(n.FitsSignedLong, Is.True);
        Assert.That(n.FitsUnsignedInt, Is.False);
        Assert.That(n.FitsSignedInt, Is.True);
        Assert.That(n.FitsUnsignedShort, Is.False);
        Assert.That(n.FitsSignedShort, Is.True);

        using mpfr_t o = new("32767");
        AsString = o.ToString();
        Assert.That(AsString, Is.EqualTo("3.2767E+4"));

        Assert.That(o.FitsUnsignedLong, Is.True);
        Assert.That(o.FitsSignedLong, Is.True);
        Assert.That(o.FitsUnsignedInt, Is.True);
        Assert.That(o.FitsSignedInt, Is.True);
        Assert.That(o.FitsUnsignedShort, Is.True);
        Assert.That(o.FitsSignedShort, Is.True);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
