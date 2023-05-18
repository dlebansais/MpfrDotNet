namespace TestInteger.Arithmetic.Divide;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Divide
{
    [Test]
    public void GenericDivide()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("394580293847502987609283945873594873409587"));

        using mpz_t c = new();
        mpz.tdiv_q(c, a, b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("593169091750307653294"));
    }

    [Test]
    public void DivOperator1()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("394580293847502987609283945873594873409587"));

        using mpz_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("593169091750307653294"));
    }

    [Test]
    public void IntDivOperator1()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        int Three = 3;

        using mpz_t c = a / Three;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("78017611508030951364291500994581676448574366152403101994478115"));
    }

    [Test]
    public void IntDivOperator2()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        int MinusThree = -3;

        using mpz_t c = a / MinusThree;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-78017611508030951364291500994581676448574366152403101994478115"));
    }

    [Test]
    public void UIntDivOperator()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        uint Three = 3;

        using mpz_t c = a / Three;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("78017611508030951364291500994581676448574366152403101994478115"));
    }

    [Test]
    public void TowardZero()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("394580293847502987609283945873594873409587"));

        mpz_t.Divide(a, b, out mpz_t q, out mpz_t r);

        AsString = q.ToString();
        Assert.That(AsString, Is.EqualTo("593169091750307653294"));
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("114368714235760586972822754176083531704767"));

        mpz_t.Divide(a, b, out q, out r, Rounding.TowardZero);

        AsString = q.ToString();
        Assert.That(AsString, Is.EqualTo("593169091750307653294"));
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("114368714235760586972822754176083531704767"));

        using mpz_t n = r + (q * b);

        AsString = n.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));
    }

    [Test]
    public void TowardPositiveInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("394580293847502987609283945873594873409587"));

        mpz_t.Divide(a, b, out mpz_t q, out mpz_t r, Rounding.TowardPositiveInfinity);

        AsString = q.ToString();
        Assert.That(AsString, Is.EqualTo("593169091750307653295"));
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("-280211579611742400636461191697511341704820"));

        using mpz_t n = r + (q * b);

        AsString = n.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));
    }

    [Test]
    public void TowardNegativeInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        using mpz_t b = new mpz_t("-394580293847502987609283945873594873409587");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-394580293847502987609283945873594873409587"));

        mpz_t.Divide(a, b, out mpz_t q, out mpz_t r, Rounding.TowardNegativeInfinity);

        AsString = q.ToString();
        Assert.That(AsString, Is.EqualTo("-593169091750307653295"));
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("-280211579611742400636461191697511341704820"));

        using mpz_t n = r + (q * b);

        AsString = n.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));
    }


    [Test]
    public void UintTowardZero()
    {
        string AsString;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 17835;

        mpz_t.Divide(a, b, out mpz_t q, out mpz_t r);

        AsString = q.ToString();
        Assert.That(AsString, Is.EqualTo("13123231540459369447315643565110458612039422397376467955336"));
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("16785"));

        mpz_t.Divide(a, b, out q, out r, Rounding.TowardZero);

        AsString = q.ToString();
        Assert.That(AsString, Is.EqualTo("13123231540459369447315643565110458612039422397376467955336"));
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("16785"));

        using mpz_t n = r + (q * b);

        AsString = n.ToString();
        Assert.That(AsString, Is.EqualTo("234052834524092854092874502983745029345723098457209305983434345"));
    }

    [Test]
    public void UintTowardPositiveInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 17835;

        mpz_t.Divide(a, b, out mpz_t q, out mpz_t r, Rounding.TowardPositiveInfinity);

        AsString = q.ToString();
        Assert.That(AsString, Is.EqualTo("-13123231540459369447315643565110458612039422397376467955336"));
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("-16785"));

        using mpz_t n = r + (q * b);

        AsString = n.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));
    }

    [Test]
    public void UintTowardNegativeInfinity()
    {
        string AsString;

        using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));

        uint b = 17835;

        mpz_t.Divide(a, b, out mpz_t q, out mpz_t r, Rounding.TowardNegativeInfinity);

        AsString = q.ToString();
        Assert.That(AsString, Is.EqualTo("-13123231540459369447315643565110458612039422397376467955337"));
        AsString = r.ToString();
        Assert.That(AsString, Is.EqualTo("1050"));

        using mpz_t n = r + (q * b);

        AsString = n.ToString();
        Assert.That(AsString, Is.EqualTo("-234052834524092854092874502983745029345723098457209305983434345"));
    }

    [Test]
    public void DivideUlong()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        ulong ul = 64200154000UL;

        using mpz_t b = a / ul;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("3465876927700988043502665674"));

        using mpz_t c = ul / a;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("0"));
    }

    [Test]
    public void DivideLong()
    {
        string AsString;

        using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("222509832503450298345029835740293845720"));

        long l = -64200154000L;

        using mpz_t b = a / l;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-3465876927700988043502665674"));

        using mpz_t c = l / a;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("0"));
    }
}
