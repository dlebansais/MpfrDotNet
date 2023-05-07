namespace TestInteger.Arithmetic;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class SubtractProduct
{
    [Test]
    public void BasicSubtractProduct()
    {
        string AsString;

        using mpz_t a = new mpz_t("98750293847520938457029384572093480498357");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("98750293847520938457029384572093480498357"));

        using mpz_t b = new mpz_t("23094582093845093574093845093485039450934");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("23094582093845093574093845093485039450934"));

        using mpz_t c = new mpz_t("394580293847502987609283945873594873409587");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("394580293847502987609283945873594873409587"));

        mpz.submul(a, b, c);
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-9112666988874677841199955832262586145147830205230375090322356322089362221491205901"));
    }

    [Test]
    public void SubProductUint()
    {
        string AsString;

        using mpz_t a = new mpz_t("98750293847520938457029384572093480498357");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("98750293847520938457029384572093480498357"));

        using mpz_t b = new mpz_t("23094582093845093574093845093485039450934");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("23094582093845093574093845093485039450934"));

        uint Two = 2;

        mpz.submul_ui(a, b, Two);
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("52561129659830751308841694385123401596489"));
    }
}
