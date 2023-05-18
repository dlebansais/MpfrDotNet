namespace TestInteger;

using MpirDotNet;
using System.Text;
using NUnit.Framework;
using System;
using System.Numerics;

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
    public void Create()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        Assert.Throws<ArgumentException>(() => { using (mpz_t x = new mpz_t("Foo")) { }; });

        byte nb = 20;
        using mpz_t b = new mpz_t(nb);

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("20"));
        Assert.That((byte)b, Is.EqualTo(nb));

        int ni = -20;
        using mpz_t c = new mpz_t(ni);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-20"));
        Assert.That((int)c, Is.EqualTo(ni));

        uint nui = 20;
        using mpz_t d = new mpz_t(nui);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("20"));
        Assert.That((uint)d, Is.EqualTo(nui));

        long nl = -20L;
        using mpz_t e = new mpz_t(nl);

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-20"));
        Assert.That((long)e, Is.EqualTo(nl));

        ulong nul = 20UL;
        using mpz_t f = new mpz_t(nul);

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("20"));
        Assert.That((ulong)f, Is.EqualTo(nul));

        short ns = -20;
        using mpz_t g = new mpz_t(ns);

        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("-20"));
        Assert.That((short)g, Is.EqualTo(ns));

        ushort nus = 20;
        using mpz_t h = new mpz_t(nus);

        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("20"));
        Assert.That((ushort)h, Is.EqualTo(nus));

        float nf = 20.0F;
        using mpz_t i = new mpz_t(nf);

        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("20"));
        Assert.That((float)i, Is.EqualTo(nf));

        double nd = 20.0;
        using mpz_t j = new mpz_t(nd);

        AsString = j.ToString();
        Assert.That(AsString, Is.EqualTo("20"));
        Assert.That((double)j, Is.EqualTo(nd));

        BigInteger big = new(20);
        using mpz_t k = new mpz_t(big);

        AsString = k.ToString();
        Assert.That(AsString, Is.EqualTo("20"));
        Assert.That((BigInteger)k, Is.EqualTo(big));

        using mpz_t l = new mpz_t(new bitcount_t(10UL));

        AsString = l.ToString();
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

    [Test]
    public void Complement()
    {
        using mpz_t a = new mpz_t(2);

        a.ComplementBit(1);

        string AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("0"));
    }

    [Test]
    public void Clone()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        using mpz_t b = (mpz_t)a.Clone();

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        ICloneable Cloneable = a;

        using mpz_t c = (mpz_t)Cloneable.Clone();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));
    }

    [Test]
    public void Convertible()
    {
        string AsString;

        using mpz_t a = new mpz_t("2983");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2983"));

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

        using mpz_t a = new mpz_t("2983");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2983"));

        mpz_t b = (mpz_t)a.ToType(typeof(mpz_t), null);
        Assert.That(b, Is.EqualTo(a));

        IConvertible Convertible = a;
        mpz_t c = (mpz_t)Convertible.ToType(typeof(mpz_t), null);
        Assert.That(c, Is.EqualTo(a));

        mpz_t d = (mpz_t)a.ToType(typeof(object), null);
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
}
