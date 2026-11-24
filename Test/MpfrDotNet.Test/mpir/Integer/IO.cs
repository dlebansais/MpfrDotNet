namespace TestInteger;

using MpirDotNet;
using System.IO;
using System.Text;
using NUnit.Framework;
using System;

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
        string AsString;

        using mpz_t a = new("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using MemoryStream Stream = new();
        int Length;

        using (BinaryWriter Writer = new(Stream, Encoding.Default, leaveOpen: true))
        {
            Length = (int)mpz.out_raw(Writer, a);
        }

        Stream.Seek(0, SeekOrigin.Begin);

        using BinaryReader Reader = new(Stream);
        byte[] Content = Reader.ReadBytes((int)Stream.Length);

        Assert.That(Content, Has.Length.EqualTo(Length));

        using mpz_t b = new(Content);

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));
    }

    [Test]
    public void InRaw()
    {
        string AsString;

        using mpz_t a = new("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using MemoryStream Stream = new();
        byte[] Content;

        using (BinaryWriter Writer = new(Stream, Encoding.Default, leaveOpen: true))
        {
            Content = a.ToByteArray();
            Writer.Write(Content);
        }

        Stream.Seek(0, SeekOrigin.Begin);

        using BinaryReader Reader = new(Stream);
        using mpz_t b = new();
        int Length = (int)mpz.inp_raw(b, Reader);

        Assert.That(Content, Has.Length.EqualTo(Length));

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));
    }
}
