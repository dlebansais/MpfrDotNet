namespace Test;

using MpfrDotNet;
using NUnit.Framework;

[TestFixture]
public class Trigonometric
{
    [Test]
    public void Cos()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Cos();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-9.079472501177879498271610243432053594179E-1"));

        using mpfr_t c = b.Acos();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.70915592260758647692528676655900576839E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Sin()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Sin();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-4.190844676238276069768382288073121644393E-1"));

        using mpfr_t c = b.Asin();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-4.324367309822067615373566167204971158037E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Tan()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Tan();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("4.615735854362241866517393293698696684614E-1"));

        using mpfr_t c = b.Atan();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("4.324367309822067615373566167204971158022E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void SinCos()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        mpfr_t.SinCos(a, out mpfr_t sin, out mpfr_t cos);

        using mpfr_t b = cos;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-9.079472501177879498271610243432053594179E-1"));

        using mpfr_t c = sin;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-4.190844676238276069768382288073121644393E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Sec()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Sec();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-1.101385570439549270829012639515128148667E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Csc()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Csc();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-2.386153812070184356266291123615644797779E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Cot()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Cot();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.166501792027200858761011184195144509108E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Atan2()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = mpfr_t.Atan2(a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.570796326694681975465174851185767828407E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Cosh()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Cosh();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.784401725279305237497215665629380184179E+1"));

        using mpfr_t c = b.Acosh();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Sinh()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Sinh();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.781597462161349487888726682341782577203E+1"));

        using mpfr_t c = b.Asinh();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Tanh()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Tanh();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("9.984284575170331615981558376475473220348E-1"));

        using mpfr_t c = b.Atanh();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572000000000000000000000000118E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void SinhCosh()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        mpfr_t.SinhCosh(a, out mpfr_t sinh, out mpfr_t cosh);

        using mpfr_t b = cosh;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.784401725279305237497215665629380184179E+1"));

        using mpfr_t c = sinh;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.781597462161349487888726682341782577203E+1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Sech()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Sech();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("5.60411921728821471020075640543898860873E-2"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Csch()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Csch();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("5.61294019125312100079274659688414336651E-2"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Coth()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Coth();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.001574016116162261862392347641586139753E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ConstLog2()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = mpfr_t.Log2();
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("6.931471805599453094172321214581765680748E-1"));

        using mpfr_t b = mpfr_t.Log2(mpfr_t.DefaultPrecision + 64);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("6.9314718055994530941723212145817656807550013436025525412075E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ConstPi()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = mpfr_t.Pi();
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.141592653589793238462643383279502884195E+0"));

        using mpfr_t b = mpfr_t.Pi(mpfr_t.DefaultPrecision + 64);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("3.1415926535897932384626433832795028841971693993751058209749E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ConstEuler()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = mpfr_t.Euler();
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("5.772156649015328606065120900824024310432E-1"));

        using mpfr_t b = mpfr_t.Euler(mpfr_t.DefaultPrecision + 64);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("5.7721566490153286060651209008240243104215933593992359880576E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ConstCatalan()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = mpfr_t.Catalan();
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("9.159655941772190150546035149323841107734E-1"));

        using mpfr_t b = mpfr_t.Catalan(mpfr_t.DefaultPrecision + 64);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("9.1596559417721901505460351493238411077414937428167213426656E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
