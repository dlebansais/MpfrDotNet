namespace TestFloating;

using System;
using System.Text;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Misc
{
    [Test]
    public void Create()
    {
        string AsString;

        using mpf_t a = new mpf_t();
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("0"));

        Assert.IsTrue(a.IsInteger);
        Assert.IsTrue(a.Sign == 0);

        ulong DefaultPrecision = mpf.get_default_prec();
        Assert.That(DefaultPrecision, Is.EqualTo(64UL));
        Assert.That(DefaultPrecision, Is.EqualTo(a.Precision));

        using mpf_t b = new mpf_t(10U);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        Assert.That((uint)b, Is.EqualTo(10U));

        using mpf_t c = new mpf_t(-10);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-1E+1"));

        Assert.That((int)c, Is.EqualTo(-10));

        using mpf_t d = new mpf_t(10U, DefaultPrecision);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        using mpf_t e = new mpf_t(-10, DefaultPrecision);
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-1E+1"));

        using mpf_t f = new mpf_t(50.2);
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("5.02000000000000028422E+1"));

        Assert.That((double)f, Is.EqualTo(50.2));

        using mpf_t g = new mpf_t(50.2, DefaultPrecision + 64);
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("5.02000000000000028421709430404007434845E+1"));

        Assert.That(g.Precision, Is.EqualTo(DefaultPrecision + 64));

        using mpf_t h = new mpf_t("2225098325034502983450298.3574029384572");
        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+24"));

        using mpf_t i = new mpf_t("2225098325034502983450298.3574029384572", 10, 200);
        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983574029384572E+24"));

        using mpf_t j = new mpf_t(i);
        AsString = j.ToString();
        Assert.That(AsString, Is.EqualTo("2.2250983250345029834502983574029384572E+24"));

        using mpf_t k = new mpf_t(i, true);
        AsString = k.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+24"));

        using mpf_t l = -k;
        AsString = l.ToString();
        Assert.That(AsString, Is.EqualTo("-2.22509832503450298345E+24"));

        using mpf_t m = l.Abs();
        AsString = m.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345E+24"));

        using mpf_t p = new mpf_t("68719476735");
        AsString = p.ToString();
        Assert.That(AsString, Is.EqualTo("6.8719476735E+10"));
        ulong UlongCast = (ulong)p;
        Assert.That(UlongCast, Is.EqualTo(68719476735UL));

        using mpf_t q = new mpf_t("2147483647");
        AsString = q.ToString();
        Assert.That(AsString, Is.EqualTo("2.147483647E+9"));
        uint UintCast = (uint)q;
        Assert.That(UintCast, Is.EqualTo(2147483647U));

        using mpf_t r = new mpf_t(10UL, DefaultPrecision);
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        using mpf_t s = new mpf_t(10UL, ulong.MaxValue);
        AsString = s.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        Assert.Throws<ArgumentException>(() => { using (mpf_t x = new mpf_t("Foo")) { } });

        using mpz_t initZ = new mpz_t(20);
        using mpq_t initQ = new mpq_t(30);

        s.Set(initZ);
        AsString = s.ToString();
        Assert.That(AsString, Is.EqualTo("2E+1"));

        s.Set(initQ);
        AsString = s.ToString();
        Assert.That(AsString, Is.EqualTo("3E+1"));

        s.GetDoubleWithExponent(out double DoubleValue, out long ExponentValue);
        Assert.That(DoubleValue, Is.EqualTo(0.9375));
        Assert.That(ExponentValue, Is.EqualTo(5));

        Assert.Throws<NotImplementedException>(() => mpf.inits(new mpf_t[0]));
        Assert.Throws<NotImplementedException>(() => mpf.clears(new mpf_t[0]));
    }

    [Test]
    public void Operator()
    {
        string AsString;

        using mpf_t a = (mpf_t)10U;
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        int na = (int)a;
        Assert.That(na, Is.EqualTo(10));

        using mpf_t b = (mpf_t)10;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        uint nb = (uint)b;
        Assert.That(nb, Is.EqualTo(10));

        using mpf_t c = (mpf_t)10.0F;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        float fc = (float)c;
        Assert.That(fc, Is.EqualTo(10.0F));

        using mpf_t d = (mpf_t)10.0;
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        double dd = (double)d;
        Assert.That(dd, Is.EqualTo(10.0));

        using mpf_t e = (mpf_t)10UL;
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        ulong ne = (ulong)e;
        Assert.That(ne, Is.EqualTo(10UL));

        using mpf_t f = (mpf_t)10L;
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        long nf = (long)f;
        Assert.That(ne, Is.EqualTo(10L));
    }

    [Test]
    public void Precision()
    {
        ulong DefaultPrecision;

        DefaultPrecision = mpf_t.DefaultPrecision;
        Assert.IsTrue(DefaultPrecision == 64);

        mpf_t.DefaultPrecision = 128;

        DefaultPrecision = mpf_t.DefaultPrecision;
        Assert.IsTrue(DefaultPrecision == 128);

        mpf_t.DefaultPrecision = 0x7FFFFFFF;

        DefaultPrecision = mpf_t.DefaultPrecision;
        Assert.IsTrue(DefaultPrecision >= 0x7FFFFFFF);

        mpf_t.DefaultPrecision = 0xFFFFFFFF;

        DefaultPrecision = mpf_t.DefaultPrecision;
        Assert.IsTrue(DefaultPrecision >= 0xFFFFFFFF);

        mpf_t.DefaultPrecision = 0x1FFFFFFFF;

        DefaultPrecision = mpf_t.DefaultPrecision;
        Assert.IsTrue(DefaultPrecision >= 0x1FFFFFFFF);

        using mpf_t a = new mpf_t();

        ulong OldPrecision = a.Precision;
        ulong TestPrecision = 128;

        a.Precision = TestPrecision;
        Assert.That(a.Precision, Is.EqualTo(TestPrecision));

        a.SetPrecisionRaw(TestPrecision);
        Assert.That(a.Precision, Is.EqualTo(TestPrecision));

        a.Precision = OldPrecision;
        Assert.That(a.Precision, Is.EqualTo(OldPrecision));

        mpf_t.DefaultPrecision = 64;
    }

    [Test]
    public void Rounding()
    {
        string AsString;

        using mpf_t a = new mpf_t("2983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.983574029384572E+3"));

        using mpf_t b = a.Ceil();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.984E+3"));

        using mpf_t c = a.Floor();
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.983E+3"));

        using mpf_t d = a.Trunc();
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.983E+3"));
    }

    [Test]
    public void GetStr()
    {
        string AsString;

        using mpf_t a = new mpf_t("2983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.983574029384572E+3"));

        int Base = 10;
        ulong Digits = 20;
        StringBuilder Builder = new StringBuilder((int)(Digits + 2));
        mpf.get_str(Builder, out int Expptr, Base, Digits, a);
        string Str = Builder.ToString();

        Assert.That(Str, Is.EqualTo("2983574029384572"));
    }

    [Test]
    public void Clone()
    {
        string AsString;

        using mpf_t a = new mpf_t("2983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.983574029384572E+3"));

        using mpf_t b = (mpf_t)a.Clone();

        ICloneable Cloneable = a;

        using mpf_t c = (mpf_t)Cloneable.Clone();
    }

    [Test]
    public void Convertible()
    {
        string AsString;

        using mpf_t a = new mpf_t("2983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.983574029384572E+3"));

        IConvertible Convertible = a;
        TypeCode TypeCode = Convertible.GetTypeCode();

        Assert.Throws<InvalidCastException>(() => a.ToBoolean(null));
        Assert.Throws<InvalidCastException>(() => Convertible.ToBoolean(null));
        Assert.Throws<InvalidCastException>(() => a.ToChar(null));
        Assert.Throws<InvalidCastException>(() => Convertible.ToChar(null));
        Assert.Throws<InvalidCastException>(() => a.ToDateTime(null));
        Assert.Throws<InvalidCastException>(() => Convertible.ToDateTime(null));
        Assert.Throws<InvalidCastException>(() => a.ToDecimal(null));
        Assert.Throws<InvalidCastException>(() => Convertible.ToDecimal(null));

        float f1 = a.ToSingle(null);
        Assert.That(f1, Is.EqualTo((float)a));

        float f2 = Convertible.ToSingle(null);
        Assert.That(f2, Is.EqualTo((float)a));

        double d1 = a.ToDouble(null);
        Assert.That(d1, Is.EqualTo((double)a));

        double d2 = Convertible.ToDouble(null);
        Assert.That(d2, Is.EqualTo((double)a));

        sbyte b1 = a.ToSByte(null);
        Assert.That(b1, Is.EqualTo((sbyte)a));

        sbyte b2 = Convertible.ToSByte(null);
        Assert.That(b2, Is.EqualTo((sbyte)a));

        byte ub1 = a.ToByte(null);
        Assert.That(ub1, Is.EqualTo((byte)a));

        byte ub2 = Convertible.ToByte(null);
        Assert.That(ub2, Is.EqualTo((byte)a));

        short s1 = a.ToInt16(null);
        Assert.That(s1, Is.EqualTo((short)a));

        short s2 = Convertible.ToInt16(null);
        Assert.That(s2, Is.EqualTo((short)a));

        ushort us1 = a.ToUInt16(null);
        Assert.That(us1, Is.EqualTo((ushort)a));

        ushort us2 = Convertible.ToUInt16(null);
        Assert.That(us2, Is.EqualTo((ushort)a));

        int i1 = a.ToInt32(null);
        Assert.That(i1, Is.EqualTo((int)a));

        int i2 = Convertible.ToInt32(null);
        Assert.That(i2, Is.EqualTo((int)a));

        uint ui1 = a.ToUInt32(null);
        Assert.That(ui1, Is.EqualTo((uint)a));

        uint ui2 = Convertible.ToUInt32(null);
        Assert.That(ui2, Is.EqualTo((uint)a));

        long l1 = a.ToInt64(null);
        Assert.That(l1, Is.EqualTo((long)a));

        long l2 = Convertible.ToInt64(null);
        Assert.That(l2, Is.EqualTo((long)a));

        ulong ul1 = a.ToUInt64(null);
        Assert.That(ul1, Is.EqualTo((ulong)a));

        ulong ul2 = Convertible.ToUInt64(null);
        Assert.That(ul2, Is.EqualTo((ulong)a));

        string str1 = a.ToString(null);
        Assert.That(str1, Is.EqualTo(a.ToString()));

        string str2 = Convertible.ToString(null);
        Assert.That(str2, Is.EqualTo(a.ToString()));
    }

    [Test]
    public void ToType()
    {
        string AsString;

        using mpf_t a = new mpf_t("2983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.983574029384572E+3"));

        mpf_t b = (mpf_t)a.ToType(typeof(mpf_t), null);
        Assert.That(b, Is.EqualTo(a));

        IConvertible Convertible = a;
        mpf_t c = (mpf_t)Convertible.ToType(typeof(mpf_t), null);
        Assert.That(c, Is.EqualTo(a));

        mpf_t d = (mpf_t)a.ToType(typeof(object), null);
        Assert.That(d, Is.EqualTo(a));

        Assert.Throws<InvalidCastException>(() => a.ToType(typeof(bool), null));
        Assert.Throws<InvalidCastException>(() => a.ToType(typeof(char), null));
        Assert.Throws<InvalidCastException>(() => a.ToType(typeof(DateTime), null));
        Assert.Throws<InvalidCastException>(() => a.ToType(typeof(decimal), null));

        float f1 = (float)a.ToType(typeof(float), null);
        Assert.That(f1, Is.EqualTo((float)a));

        double d1 = (double)a.ToType(typeof(double), null);
        Assert.That(d1, Is.EqualTo((double)a));

        sbyte b1 = (sbyte)a.ToType(typeof(sbyte), null);
        Assert.That(b1, Is.EqualTo((sbyte)a));

        byte ub1 = (byte)a.ToType(typeof(byte), null);
        Assert.That(ub1, Is.EqualTo((byte)a));

        short s1 = (short)a.ToType(typeof(short), null);
        Assert.That(s1, Is.EqualTo((short)a));

        ushort us1 = (ushort)a.ToType(typeof(ushort), null);
        Assert.That(us1, Is.EqualTo((ushort)a));

        int i1 = (int)a.ToType(typeof(int), null);
        Assert.That(i1, Is.EqualTo((int)a));

        uint ui1 = (uint)a.ToType(typeof(uint), null);
        Assert.That(ui1, Is.EqualTo((uint)a));

        long l1 = (long)a.ToType(typeof(long), null);
        Assert.That(l1, Is.EqualTo((long)a));

        ulong ul1 = (ulong)a.ToType(typeof(ulong), null);
        Assert.That(ul1, Is.EqualTo((ulong)a));

        string str1 = (string)a.ToType(typeof(string), null);
        Assert.That(str1, Is.EqualTo(a.ToString()));

        Assert.Throws<InvalidCastException>(() => a.ToType(typeof(Misc), null));
    }

    [Test]
    public void Swap()
    {
        string AsString;

        using mpf_t x = new mpf_t("2983.5740293845720");
        AsString = x.ToString();
        Assert.That(AsString, Is.EqualTo("2.983574029384572E+3"));

        using mpf_t y = new mpf_t("68719476735");
        AsString = y.ToString();
        Assert.That(AsString, Is.EqualTo("6.8719476735E+10"));

        mpf_t.Swap(x, y);

        AsString = x.ToString();
        Assert.That(AsString, Is.EqualTo("6.8719476735E+10"));

        AsString = y.ToString();
        Assert.That(AsString, Is.EqualTo("2.983574029384572E+3"));
    }

    [Test]
    public void Fits()
    {
        string AsString;

        using mpf_t a = new("18446744073709551616");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1.8446744073709551616E+19"));

        Assert.That(a.FitsUnsignedLong, Is.False);
        Assert.That(a.FitsSignedLong, Is.False);
        Assert.That(a.FitsUnsignedInt, Is.False);
        Assert.That(a.FitsSignedInt, Is.False);
        Assert.That(a.FitsUnsignedShort, Is.False);
        Assert.That(a.FitsSignedShort, Is.False);

        using mpf_t b = new("18446744073709551615");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.8446744073709551615E+19"));

        Assert.That(b.FitsUnsignedLong, Is.True);
        Assert.That(b.FitsSignedLong, Is.False);
        Assert.That(b.FitsUnsignedInt, Is.False);
        Assert.That(b.FitsSignedInt, Is.False);
        Assert.That(b.FitsUnsignedShort, Is.False);
        Assert.That(b.FitsSignedShort, Is.False);

        using mpf_t c = new("9223372036854775808");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9.223372036854775808E+18"));

        Assert.That(c.FitsUnsignedLong, Is.True);
        Assert.That(c.FitsSignedLong, Is.False);
        Assert.That(c.FitsUnsignedInt, Is.False);
        Assert.That(c.FitsSignedInt, Is.False);
        Assert.That(c.FitsUnsignedShort, Is.False);
        Assert.That(c.FitsSignedShort, Is.False);

        using mpf_t d = new("-9223372036854775808");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-9.223372036854775808E+18"));

        Assert.That(d.FitsUnsignedLong, Is.False);
        Assert.That(d.FitsSignedLong, Is.True);
        Assert.That(d.FitsUnsignedInt, Is.False);
        Assert.That(d.FitsSignedInt, Is.False);
        Assert.That(d.FitsUnsignedShort, Is.False);
        Assert.That(d.FitsSignedShort, Is.False);

        using mpf_t e = new("9223372036854775807");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("9.223372036854775807E+18"));

        Assert.That(e.FitsUnsignedLong, Is.True);
        Assert.That(e.FitsSignedLong, Is.True);
        Assert.That(e.FitsUnsignedInt, Is.False);
        Assert.That(e.FitsSignedInt, Is.False);
        Assert.That(e.FitsUnsignedShort, Is.False);
        Assert.That(e.FitsSignedShort, Is.False);

        using mpf_t f = new("4294967296");
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("4.294967296E+9"));

        Assert.That(f.FitsUnsignedLong, Is.True);
        Assert.That(f.FitsSignedLong, Is.True);
        Assert.That(f.FitsUnsignedInt, Is.False);
        Assert.That(f.FitsSignedInt, Is.False);
        Assert.That(f.FitsUnsignedShort, Is.False);
        Assert.That(f.FitsSignedShort, Is.False);

        using mpf_t g = new("4294967295");
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("4.294967295E+9"));

        Assert.That(g.FitsUnsignedLong, Is.True);
        Assert.That(g.FitsSignedLong, Is.True);
        Assert.That(g.FitsUnsignedInt, Is.True);
        Assert.That(g.FitsSignedInt, Is.False);
        Assert.That(g.FitsUnsignedShort, Is.False);
        Assert.That(g.FitsSignedShort, Is.False);

        using mpf_t h = new("2147483648");
        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("2.147483648E+9"));

        Assert.That(h.FitsUnsignedLong, Is.True);
        Assert.That(h.FitsSignedLong, Is.True);
        Assert.That(h.FitsUnsignedInt, Is.True);
        Assert.That(h.FitsSignedInt, Is.False);
        Assert.That(h.FitsUnsignedShort, Is.False);
        Assert.That(h.FitsSignedShort, Is.False);

        using mpf_t i = new("-2147483648");
        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("-2.147483648E+9"));

        Assert.That(i.FitsUnsignedLong, Is.False);
        Assert.That(i.FitsSignedLong, Is.True);
        Assert.That(i.FitsUnsignedInt, Is.False);
        Assert.That(i.FitsSignedInt, Is.True);
        Assert.That(i.FitsUnsignedShort, Is.False);
        Assert.That(i.FitsSignedShort, Is.False);

        using mpf_t j = new("2147483647");
        AsString = j.ToString();
        Assert.That(AsString, Is.EqualTo("2.147483647E+9"));

        Assert.That(j.FitsUnsignedLong, Is.True);
        Assert.That(j.FitsSignedLong, Is.True);
        Assert.That(j.FitsUnsignedInt, Is.True);
        Assert.That(j.FitsSignedInt, Is.True);
        Assert.That(j.FitsUnsignedShort, Is.False);
        Assert.That(j.FitsSignedShort, Is.False);

        using mpf_t k = new("65536");
        AsString = k.ToString();
        Assert.That(AsString, Is.EqualTo("6.5536E+4"));

        Assert.That(k.FitsUnsignedLong, Is.True);
        Assert.That(k.FitsSignedLong, Is.True);
        Assert.That(k.FitsUnsignedInt, Is.True);
        Assert.That(k.FitsSignedInt, Is.True);
        Assert.That(k.FitsUnsignedShort, Is.False);
        Assert.That(k.FitsSignedShort, Is.False);

        using mpf_t l = new("65535");
        AsString = l.ToString();
        Assert.That(AsString, Is.EqualTo("6.5535E+4"));

        Assert.That(l.FitsUnsignedLong, Is.True);
        Assert.That(l.FitsSignedLong, Is.True);
        Assert.That(l.FitsUnsignedInt, Is.True);
        Assert.That(l.FitsSignedInt, Is.True);
        Assert.That(l.FitsUnsignedShort, Is.True);
        Assert.That(l.FitsSignedShort, Is.False);

        using mpf_t m = new("32768");
        AsString = m.ToString();
        Assert.That(AsString, Is.EqualTo("3.2768E+4"));

        Assert.That(m.FitsUnsignedLong, Is.True);
        Assert.That(m.FitsSignedLong, Is.True);
        Assert.That(m.FitsUnsignedInt, Is.True);
        Assert.That(m.FitsSignedInt, Is.True);
        Assert.That(m.FitsUnsignedShort, Is.True);
        Assert.That(m.FitsSignedShort, Is.False);

        using mpf_t n = new("-32768");
        AsString = n.ToString();
        Assert.That(AsString, Is.EqualTo("-3.2768E+4"));

        Assert.That(n.FitsUnsignedLong, Is.False);
        Assert.That(n.FitsSignedLong, Is.True);
        Assert.That(n.FitsUnsignedInt, Is.False);
        Assert.That(n.FitsSignedInt, Is.True);
        Assert.That(n.FitsUnsignedShort, Is.False);
        Assert.That(n.FitsSignedShort, Is.True);

        using mpf_t o = new("32767");
        AsString = o.ToString();
        Assert.That(AsString, Is.EqualTo("3.2767E+4"));

        Assert.That(o.FitsUnsignedLong, Is.True);
        Assert.That(o.FitsSignedLong, Is.True);
        Assert.That(o.FitsUnsignedInt, Is.True);
        Assert.That(o.FitsSignedInt, Is.True);
        Assert.That(o.FitsUnsignedShort, Is.True);
        Assert.That(o.FitsSignedShort, Is.True);
    }
}
