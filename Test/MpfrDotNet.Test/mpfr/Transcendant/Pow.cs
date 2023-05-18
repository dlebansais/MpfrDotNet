namespace Test;

using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Pow
{
    [Test]
    public void Sqrt()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.Sqrt();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("4.717094789205007043527205627045288848603E+12"));

        using mpfr_t c = b.Sqr();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345029835740293845721E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Cbrt()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.Cbrt();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.812654594315172487036307712641538948028E+8"));

        using mpfr_t c = b * b;
        using mpfr_t d = c * b;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void NthRoot()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 2048;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.That(AsString, Is.EqualTo("2.225098325034502983...E+25"));

        ulong root = 5040625102UL;
        root >>= 1;

        using mpfr_t b = a.NthRoot(root);
        AsString = b.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("1.000000023157615543...E+0"));

        using mpfr_t c = b.Sqrt();
        AsString = c.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("1.000000011578807704...E+0"));

        using mpfr_t d = a.NthRoot(root << 1);
        AsString = d.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("1.000000011578807704...E+0"));

        using mpfr_t e = b.Pow(root);
        AsString = e.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.That(AsString, Is.EqualTo("2.225098325034502983...E+25"));

        using mpfr_t f = c.Pow(root << 1);
        AsString = f.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.That(AsString, Is.EqualTo("2.225098325034502983...E+25"));

        using mpfr_t g = d.Pow(root << 1);
        AsString = g.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.That(AsString, Is.EqualTo("2.225098325034502983...E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void SqrtULong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 2048;

        ulong a = 5040625102UL;

        using mpfr_t b = new();

        mpfr.sqrt_ui(b, a, mpfr_rnd_t.MPFR_RNDN);
        AsString = b.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("7.099735982415120765...E+4"));

        using mpfr_t c = new mpfr_t(a);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("5.040625102E+9"));

        using mpfr_t d = c.Sqrt();
        AsString = d.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("7.099735982415120765...E+4"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void BasicPow()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new mpfr_t("22298.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229830594288574029879874538999999999999E+4"));

        using mpfr_t c = a.Pow(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("8.860427075804841086921307254602509939657E+565202"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void PowULong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 2048;

        using mpfr_t a = new mpfr_t("22250983250.3450298345029835740293845720");
        AsString = a.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.That(AsString, Is.EqualTo("2.225098325034502983...E+10"));

        using mpfr_t a2 = 1 / a;
        using mpfr_t a3 = 1 + a2;

        ulong b = 5040625102L;

        using mpfr_t c = a3.Pow(b >> 1);
        AsString = c.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("1.1199314396039264372253958740...E+0"));

        using mpfr_t d = a3.Pow(b);
        AsString = d.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("1.2542464294133231291486886786...E+0"));

        using mpfr_t e = c * c;
        AsString = e.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("1.2542464294133231291486886786...E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void PowLong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 2048;

        using mpfr_t a = new mpfr_t("22250983250.3450298345029835740293845720");
        AsString = a.ToString();
        AsString = AsString.Substring(0, 20) + "..." + AsString.Substring(AsString.Length - 4);
        Assert.That(AsString, Is.EqualTo("2.225098325034502983...E+10"));

        using mpfr_t a2 = 1 / a;
        using mpfr_t a3 = 1 + a2;

        long b = 5040625102L;

        using mpfr_t c = a3.Pow(b >> 1);
        AsString = c.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("1.1199314396039264372253958740...E+0"));

        using mpfr_t d = a3.Pow(b);
        AsString = d.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("1.2542464294133231291486886786...E+0"));

        using mpfr_t e = c * c;
        AsString = e.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("1.2542464294133231291486886786...E+0"));

        using mpfr_t f = a3.Pow(-b);
        AsString = f.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("7.9729148638497816923324220753...E-1"));

        using mpfr_t g = a3.Pow(-(b >> 1));
        AsString = g.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("8.9291180213108291585559055960...E-1"));

        using mpfr_t h = g * g;
        AsString = h.ToString();
        AsString = AsString.Substring(0, 30) + "..." + AsString.Substring(AsString.Length - 3);
        Assert.That(AsString, Is.EqualTo("7.9729148638497816923324220753...E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void PowZ()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpz_t b = new mpz_t("22298");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("22298"));

        using mpfr_t c = a.Pow(b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.558165173948259812979840463318544184612E+565195"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ULongPowULong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        ulong a = 986301247803256UL;
        ulong b = 22298UL;

        using mpfr_t c = mpfr_t.Pow(a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.664845452825850936819295875058386156888E+334336"));

        using mpfr_t d = a;
        using mpfr_t e = d.Log();
        using mpfr_t f = c.Log();
        using mpfr_t g = f / e;
        using mpfr_t h = g.Round();

        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298E+4"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ULongPow()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        ulong a = 986301247803256UL;

        using mpfr_t b = new mpfr_t("22298.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229830594288574029879874538999999999999E+4"));

        using mpfr_t c = mpfr_t.Pow(a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.030344809876350203541585290243287544579E+334341"));

        using mpfr_t d = a;
        using mpfr_t e = d.Log();
        using mpfr_t f = c.Log();
        using mpfr_t g = f / e;
        using mpfr_t h = g.Round();

        AsString = h.ToString();
        Assert.That(AsString, Is.EqualTo("2.2298E+4"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ZetaULong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 0x1000;

        ulong a = 9614UL;

        using mpfr_t b = new();

        mpfr.zeta_ui(b, a, mpfr_rnd_t.MPFR_RNDN);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1E+0"));

        using mpfr_t c = new mpfr_t(a);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9.614E+3"));

        using mpfr_t d = new mpfr_t();
        mpfr.zeta(d, c, mpfr_rnd_t.MPFR_RNDN);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1E+0"));

        a >>= 2;

        using mpfr_t e = new();

        mpfr.zeta_ui(e, a, mpfr_rnd_t.MPFR_RNDN);
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("1.0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004216192384269752499388183905909712823552642472824239075504792703958562564023290864441301683499099853726894121946926963705140966533654951001922295014517202082976217185316426058545481925677071116916958195665160734511399965054937114136812129052643766741774425574908878224372933084124251265937150011630578024374122923532652081364759190101789053513561211740924256788399012839376279329676442267188676974826779527249449821889791076109977807650903889202489952099756921652401124040677007076487320775503555557461569013299E+0"));

        using mpfr_t f = new mpfr_t(a);
        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("2.403E+3"));

        using mpfr_t g = new mpfr_t();
        mpfr.zeta(g, f, mpfr_rnd_t.MPFR_RNDN);

        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("1.0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004216192384269752499388183905909712823552642472824239075504792703958562564023290864441301683499099853726894121946926963705140966533654951001922295014517202082976217185316426058545481925677071116916958195665160734511399965054937114136812129052643766741774425574908878224372933084124251265937150011630578024374122923532652081364759190101789053513561211740924256788399012839376279329676442267188676974826779527249449821889791076109977807650903889202489952099756921652401124040677007076487320775503555557461569013299E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void RecSqrt()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.RecSqrt();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.119948919170510130626963473996738318074E-13"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
