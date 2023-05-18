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

        d.SetNumerator(40);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("40/10"));

        d.SetDenominator(20);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("40/20"));

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
        
        using mpq_t q1 = new mpq_t(n0, d0, canonicalize: true);
        AsString = q1.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpf_t ft = new(0.25);
        using mpq_t i = new(ft);
        AsString = i.ToString();
        Assert.That(AsString, Is.EqualTo("1/4"));

        using mpq_t r = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957", canonicalize: true);
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        Assert.Throws<ArgumentException>(() => { using mpq_t s = new("Foo") { }; });
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

    [Test]
    public void Clone()
    {
        string AsString;

        using mpq_t a = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720/115756986668303657898962467957"));

        using mpq_t b = (mpq_t)a.Clone();
        Assert.That(b, Is.EqualTo(a));

        ICloneable Cloneable = a;

        using mpq_t c = (mpq_t)Cloneable.Clone();
        Assert.That(c, Is.EqualTo(a));
    }

    [Test]
    public void Convertible()
    {
        string AsString;

        using mpq_t a = new mpq_t("2983/5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2983/5740293845720"));

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

        using mpq_t a = new mpq_t("2983/5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2983/5740293845720"));

        mpq_t b = (mpq_t)a.ToType(typeof(mpq_t), null);
        Assert.That(b, Is.EqualTo(a));

        IConvertible Convertible = a;
        mpq_t c = (mpq_t)Convertible.ToType(typeof(mpq_t), null);
        Assert.That(c, Is.EqualTo(a));

        mpq_t d = (mpq_t)a.ToType(typeof(object), null);
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
