namespace TestInteger;

using MpirDotNet;
using System.IO;
using System.Text;
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class IO
{
    [Test]
    public void Out()
    {
        string AsString;

        using mpz_t a = new("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using MemoryStream Stream = new();
        using (StreamWriter Writer = new(Stream, Encoding.Default, 0x1000, leaveOpen: true))
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => mpz.out_str(Writer, 1, a));
            Assert.Throws<ArgumentOutOfRangeException>(() => mpz.out_str(Writer, 100, a));

            int Length = (int)mpz.out_str(Writer, 10, a);

            Assert.That(AsString, Has.Length.EqualTo(Length));
        }

        Stream.Seek(0, SeekOrigin.Begin);

        using StreamReader Reader = new(Stream);
        string Content = Reader.ReadToEnd();

        Assert.That(AsString, Is.EqualTo(Content));
    }

    [TestCase(2, "111")]
    [TestCase(10, "7")]
    [TestCase(62, "7")]
    public void OutSmallValue(int strBase, string expected)
    {
        using mpz_t a = new(7);
        using MemoryStream Stream = new();
        long Length;

        using (StreamWriter Writer = new(Stream, Encoding.Default, 0x1000, leaveOpen: true))
        {
            Length = mpz.out_str(Writer, strBase, a);
        }

        Stream.Seek(0, SeekOrigin.Begin);

        using StreamReader Reader = new(Stream);
        string Content = Reader.ReadToEnd();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Content, Is.EqualTo(expected));
        Assert.That(Length, Is.EqualTo(expected.Length));
    }

    [Test]
    public void In()
    {
        string AsString;

        using mpz_t a = new("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using MemoryStream Stream = new();
        using (StreamWriter Writer = new(Stream, Encoding.Default, 0x1000, leaveOpen: true))
        {
            Writer.Write(AsString);
        }

        Stream.Seek(0, SeekOrigin.Begin);

        using StreamReader Reader = new(Stream);
        using mpz_t b = new();
        int Length = (int)mpz.inp_str(b, Reader, 10);

        Assert.That(AsString, Has.Length.EqualTo(Length));

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));
    }

    [Test]
    public void OutRaw()
    {
        using mpz_t a = new("622288097498926496141095869268883999563096063592498055290461");
        byte[] Magnitude = a.ToByteArray();
        Array.Reverse(Magnitude);

        using MemoryStream Stream = new();
        long Length;

        using (BinaryWriter Writer = new(Stream, Encoding.Default, leaveOpen: true))
        {
            Length = mpz.out_raw(Writer, a);
        }

        byte[] Content = Stream.ToArray();

        // The value has 199 bits: a 4-byte big-endian size of 25, then 25 bytes, most significant first.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Length, Is.EqualTo(29L));
        Assert.That(Content.Take(4), Is.EqualTo(new byte[] { 0, 0, 0, 25 }));
        Assert.That(Content.Skip(4), Is.EqualTo(Magnitude));
    }

    [Test]
    public void InRaw()
    {
        // -0x0102 in the format of mpz_out_raw: a size of -2, then the bytes of 0x0102.
        byte[] Content = [0xFF, 0xFF, 0xFF, 0xFE, 0x01, 0x02];

        using MemoryStream Stream = new(Content);
        using BinaryReader Reader = new(Stream);
        using mpz_t b = new();
        long Length = mpz.inp_raw(b, Reader);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Length, Is.EqualTo(6L));
        Assert.That(b.ToString(), Is.EqualTo("-258"));
    }

    [TestCase("622288097498926496141095869268883999563096063592498055290461")]
    [TestCase("-622288097498926496141095869268883999563096063592498055290461")]
    [TestCase("0")]
    [TestCase("-1")]
    public void RawRoundTrip(string value)
    {
        const string Second = "12345";

        using mpz_t a = new(value);
        using mpz_t Next = new(Second);
        using MemoryStream Stream = new();

        using (BinaryWriter Writer = new(Stream, Encoding.Default, leaveOpen: true))
        {
            _ = mpz.out_raw(Writer, a);
            _ = mpz.out_raw(Writer, Next);
        }

        Stream.Seek(0, SeekOrigin.Begin);

        using BinaryReader Reader = new(Stream);
        using mpz_t b = new(99);
        using mpz_t c = new();
        _ = mpz.inp_raw(b, Reader);
        _ = mpz.inp_raw(c, Reader);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(b.ToString(), Is.EqualTo(value));
        Assert.That(c.ToString(), Is.EqualTo(Second));
    }

    [Test]
    public void InRawTruncated()
    {
        byte[] ShortHeader = [0, 0];
        byte[] ShortMagnitude = [0, 0, 0, 3, 1, 2];
        byte[] MinimumSize = [0x80, 0, 0, 0];

        using mpz_t a = new();
        using MemoryStream ShortHeaderStream = new(ShortHeader);
        using BinaryReader ShortHeaderReader = new(ShortHeaderStream);
        using MemoryStream ShortMagnitudeStream = new(ShortMagnitude);
        using BinaryReader ShortMagnitudeReader = new(ShortMagnitudeStream);
        using MemoryStream MinimumSizeStream = new(MinimumSize);
        using BinaryReader MinimumSizeReader = new(MinimumSizeStream);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpz.inp_raw(a, ShortHeaderReader), Is.Zero);
        Assert.That(mpz.inp_raw(a, ShortMagnitudeReader), Is.Zero);
        Assert.That(mpz.inp_raw(a, MinimumSizeReader), Is.Zero);
    }
}
