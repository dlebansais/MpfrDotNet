namespace TestInteger;

using MpirDotNet;
using System.Text;
using NUnit.Framework;
using Interop.Mpir;

[TestFixture]
public class NumberTheoretic
{
    [Test]
    public void ProbablePrime()
    {
        string AsString;
        bool IsProbablePrime;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using randstate_t state = new randstate_t();

        IsProbablePrime = mpz.probable_prime_p(a, state, 10, 0);
        Assert.IsTrue(IsProbablePrime);

        using mpz_t b = a * 2;

        IsProbablePrime = mpz.probable_prime_p(b, state, 10, 0);
        Assert.IsFalse(IsProbablePrime);
    }

    [Test]
    public void LikelyPrime()
    {
        string AsString;
        bool IsLikelyPrime;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using randstate_t state = new randstate_t();

        IsLikelyPrime = mpz.likely_prime_p(a, state, 0);
        Assert.IsTrue(IsLikelyPrime);

        using mpz_t b = a * 2;

        IsLikelyPrime = mpz.likely_prime_p(b, state, 0);
        Assert.IsFalse(IsLikelyPrime);
    }

    [Test]
    public void NextPrimeCandidate()
    {
        string AsString;

        using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290460"));

        using randstate_t state = new randstate_t();

        using mpz_t b = new();
        mpz.next_prime_candidate(b, a, state);

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));
    }

    [Test]
    public void Gcd()
    {
        string AsString;

        using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));

        using mpz_t b = a * 39;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1167168693521660173095485671632988269022343558906853"));

        using mpz_t c = a * 41;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1227023498317642746074741347101346641792720151671307"));

        using mpz_t d = new();
        mpz.gcd(d, b, c);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));
    }

    [Test]
    public void UintGcd()
    {
        string AsString;

        using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));

        ulong c = 80;

        using mpz_t b = a * c;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2394192191839302919170227018734334910815063710578160"));

        using mpz_t d = new();
        ulong Gcd = mpz.gcd_ui(d, b, c);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("80"));
        Assert.That(Gcd, Is.EqualTo(80U));
    }

    [Test]
    public void GcdExt()
    {
        string AsString;

        using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));

        using mpz_t b = a * 39;
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1167168693521660173095485671632988269022343558906853"));

        using mpz_t c = a * 41;
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1227023498317642746074741347101346641792720151671307"));

        using mpz_t d = new();
        using mpz_t s = new();
        using mpz_t t = new();
        mpz.gcdext(d, s, t, b, c);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));

        AsString = s.ToString();
        Assert.That(AsString, Is.EqualTo("20"));

        AsString = t.ToString();
        Assert.That(AsString, Is.EqualTo("-19"));

        using mpz_t g = (b * s) + (c * t);
        AsString = g.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));
    }

    [Test]
    public void Lcm()
    {
        string AsString;

        using mpz_t a = new mpz_t("1167168693521660173095485671632988269022343558906853");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1167168693521660173095485671632988269022343558906853"));

        using mpz_t b = new mpz_t("1227023498317642746074741347101346641792720151671307");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1227023498317642746074741347101346641792720151671307"));

        using mpz_t c = new();
        mpz.lcm(c, a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("47853916434388067096914912536952519029916085915180973"));
    }

    [Test]
    public void UintLcm()
    {
        string AsString;

        using mpz_t a = new mpz_t("1167168693521660173095485671632988269022343558906853");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1167168693521660173095485671632988269022343558906853"));

        uint b = 79;

        using mpz_t c = new();
        mpz.lcm_ui(c, a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("92206326788211153674543368059006073252765141153641387"));
    }

    [Test]
    public void Invert()
    {
        string AsString;

        using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));

        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("622288097498926496141095869268883999563096063592498055290461"));

        using mpz_t c = new();
        mpz.invert(c, a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("219611828940796023289647350941411224882377833088800895212581"));

        using mpz_t d = (c * a) % b;
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1"));
    }

    [Test]
    public void Jacobi()
    {
        string AsString;

        using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("9288562863495827364985273645298367452"));

        using mpz_t b = new mpz_t("876428957629387610928574612341");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("876428957629387610928574612341"));

        int JacobiSymbol = mpz.jacobi(a, b);

        Assert.That(JacobiSymbol, Is.EqualTo(-1));
    }

    [Test]
    public void Legendre()
    {
        string AsString;

        using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("9288562863495827364985273645298367452"));

        using mpz_t b = new mpz_t("876428957629387610928574612341");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("876428957629387610928574612341"));

        int LegendreSymbol = mpz.legendre(a, b);

        Assert.That(LegendreSymbol, Is.EqualTo(-1));
    }

    [Test]
    public void Kronecker()
    {
        string AsString;

        using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("9288562863495827364985273645298367452"));

        using mpz_t b = new mpz_t("876428957629387610928574612341");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("876428957629387610928574612341"));

        int KroneckerSymbol = mpz.kronecker(a, b);

        Assert.That(KroneckerSymbol, Is.EqualTo(-1));
    }

    [Test]
    public void KroneckerInt()
    {
        string AsString;

        using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("9288562863495827364985273645298367452"));

        int b = 2;

        int JacobiSymbol = mpz.kronecker_si(a, b);

        Assert.That(JacobiSymbol, Is.EqualTo(0));
    }

    [Test]
    public void IntKronecker()
    {
        string AsString;

        using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("9288562863495827364985273645298367452"));

        int b = 2;

        int JacobiSymbol = mpz.si_kronecker(b, a);

        Assert.That(JacobiSymbol, Is.EqualTo(0));
    }

    [Test]
    public void KroneckerUInt()
    {
        string AsString;

        using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));

        uint b = 2;

        int JacobiSymbol = mpz.ui_kronecker(b, a);

        Assert.That(JacobiSymbol, Is.EqualTo(-1));
    }

    [Test]
    public void UIntKronecker()
    {
        string AsString;

        using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));

        uint b = 2;

        int JacobiSymbol = mpz.kronecker_ui(a, b);

        Assert.That(JacobiSymbol, Is.EqualTo(-1));
    }

    [Test]
    public void Remove()
    {
        string AsString;

        using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("9288562863495827364985273645298367452"));

        using mpz_t b = new mpz_t("29927402397991286489627837734179186385188296382227");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("29927402397991286489627837734179186385188296382227"));

        using mpz_t c = a * b * b;

        using mpz_t d = new();
        ulong Count = mpz.remove(d, c, b);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("9288562863495827364985273645298367452"));
        Assert.That(Count, Is.EqualTo(2UL));
    }

    [Test]
    public void Factorial()
    {
        string AsString;

        ulong n = 30;

        using mpz_t a = new();
        mpz.fac_ui(a, n);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("265252859812191058636308480000000"));

        using mpz_t b = new();
        mpz.fac_ui2(b, n);

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("42849873690624000"));

        ulong p = 10;

        using mpz_t c = new();
        mpz.mfac_uiui(c, n, p);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("6000"));
    }

    [Test]
    public void Primorial()
    {
        string AsString;

        NativeMethods.unsignedlongint AsULongInt = (NativeMethods.unsignedlongint)30UL;
        ulong n = (ulong)AsULongInt;

        using mpz_t a = new();
        mpz.primorial_ui(a, n);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("6469693230"));
    }

    [Test]
    public void Binomial()
    {
        string AsString;

        using mpz_t a = new mpz_t("95424793124934570246014589630147");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("95424793124934570246014589630147"));

        uint n = 3;

        using mpz_t b = new();
        mpz.bin_ui(b, a, n);

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("144821296422149208181035087357372515507071340810124253195368587593141396132717093865187545453665"));

        uint p = 81;

        using mpz_t c = new();
        mpz.bin_uiui(c, p, n);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("85320"));
    }

    [Test]
    public void Fibonacci()
    {
        string AsString;

        uint n = 80;

        using mpz_t a = new();
        mpz.fib_ui(a, n);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("23416728348467685"));

        using mpz_t b = new();
        mpz.fib2_ui(a, b, n);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("23416728348467685"));

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("14472334024676221"));
    }

    [Test]
    public void LucasNumber()
    {
        string AsString;

        uint n = 80;

        using mpz_t a = new();
        mpz.lucnum_ui(a, n);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("52361396397820127"));

        using mpz_t b = new();
        mpz.lucnum2_ui(a, b, n);

        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("52361396397820127"));

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("32361122672259149"));
    }
}
