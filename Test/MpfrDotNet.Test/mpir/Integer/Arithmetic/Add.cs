namespace TestInteger.Arithmetic;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Add
{
    [Test]
    public void GenericAdd()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        using mpz_t b = new mpz_t("222987435987982730594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539"));

        using mpz_t c = new();
        mpz.add(c, a, b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("445497268491433028939318409770173720259"));
    }

    [Test]
    public void AddOperator()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        using mpz_t b = new mpz_t("222987435987982730594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222987435987982730594288574029879874539"));

        using mpz_t c = a + b;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("445497268491433028939318409770173720259"));
    }

    [Test]
    public void AddUint()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        using mpz_t b = new();
        mpz.add_ui(b, a, 1);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845721"));
    }

    [Test]
    public void AddIntOperator1()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        int One = 1;

        using mpz_t b = One + a;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845721"));
    }

    [Test]
    public void AddIntOperator2()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        int Two = 2;

        using mpz_t b = a + Two;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845722"));
    }

    [Test]
    public void AddIntOperator3()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        int MinusOne = -1;

        using mpz_t b = MinusOne + a;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845719"));
    }

    [Test]
    public void AddIntOperator4()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        int MinusTwo = -2;

        using mpz_t b = a + MinusTwo;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845718"));
    }

    [Test]
    public void AddUIntOperator1()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        uint One = 1;

        using mpz_t b = One + a;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845721"));
    }

    [Test]
    public void AddUIntOperator2()
    {
        string AsString;

        using var a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        uint Two = 2;

        using mpz_t b = a + Two;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845722"));
    }

    [Test]
    public void AddUlong()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        ulong ul = 64200154000UL;

        using mpz_t b = a + ul;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835804493999720"));

        using mpz_t c = ul + a;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835804493999720"));
    }

    [Test]
    public void AddLong()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        long l = -64200154000L;

        using mpz_t b = a + l;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835676093691720"));

        using mpz_t c = l + a;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835676093691720"));
    }

    [Test]
    public void IncrementOperator()
    {
        string AsString;

        mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        a++;

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845721"));

        using (mpz_t clear = a)
        { 
        }
    }
}
