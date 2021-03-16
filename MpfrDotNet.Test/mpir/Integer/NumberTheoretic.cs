namespace TestInteger
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;
    using System.Text;

    [TestClass]
    public class NumberTheoretic
    {
        [TestMethod]
        public void ProbablePrime()
        {
            string AsString;
            bool IsProbablePrime;

            using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
            AsString = a.ToString();
            Assert.AreEqual("622288097498926496141095869268883999563096063592498055290461", AsString);

            using randstate_t state = new randstate_t();

            IsProbablePrime = mpz.probable_prime_p(a, state, 10, 0);
            Assert.IsTrue(IsProbablePrime);

            using mpz_t b = a * 2;

            IsProbablePrime = mpz.probable_prime_p(b, state, 10, 0);
            Assert.IsFalse(IsProbablePrime);
        }

        [TestMethod]
        public void LikelyPrime()
        {
            string AsString;
            bool IsLikelyPrime;

            using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
            AsString = a.ToString();
            Assert.AreEqual("622288097498926496141095869268883999563096063592498055290461", AsString);

            using randstate_t state = new randstate_t();

            IsLikelyPrime = mpz.likely_prime_p(a, state, 0);
            Assert.IsTrue(IsLikelyPrime);

            using mpz_t b = a * 2;

            IsLikelyPrime = mpz.likely_prime_p(b, state, 0);
            Assert.IsFalse(IsLikelyPrime);
        }

        [TestMethod]
        public void NextPrimeCandidate()
        {
            string AsString;

            using mpz_t a = new mpz_t("622288097498926496141095869268883999563096063592498055290460");
            AsString = a.ToString();
            Assert.AreEqual("622288097498926496141095869268883999563096063592498055290460", AsString);

            using randstate_t state = new randstate_t();

            using mpz_t b = new();
            mpz.next_prime_candidate(b, a, state);

            AsString = b.ToString();
            Assert.AreEqual("622288097498926496141095869268883999563096063592498055290461", AsString);
        }

        [TestMethod]
        public void Gcd()
        {
            string AsString;

            using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
            AsString = a.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);

            using mpz_t b = a * 39;
            AsString = b.ToString();
            Assert.AreEqual("1167168693521660173095485671632988269022343558906853", AsString);

            using mpz_t c = a * 41;
            AsString = c.ToString();
            Assert.AreEqual("1227023498317642746074741347101346641792720151671307", AsString);

            using mpz_t d = new();
            mpz.gcd(d, b, c);

            AsString = d.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);
        }

        [TestMethod]
        public void UintGcd()
        {
            string AsString;

            using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
            AsString = a.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);

            uint c = 80;

            using mpz_t b = a * c;
            AsString = b.ToString();
            Assert.AreEqual("2394192191839302919170227018734334910815063710578160", AsString);

            using mpz_t d = new();
            uint Gcd = mpz.gcd_ui(d, b, c);

            AsString = d.ToString();
            Assert.AreEqual("80", AsString);
            Assert.AreEqual(80U, Gcd);
        }

        [TestMethod]
        public void GcdExt()
        {
            string AsString;

            using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
            AsString = a.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);

            using mpz_t b = a * 39;
            AsString = b.ToString();
            Assert.AreEqual("1167168693521660173095485671632988269022343558906853", AsString);

            using mpz_t c = a * 41;
            AsString = c.ToString();
            Assert.AreEqual("1227023498317642746074741347101346641792720151671307", AsString);

            using mpz_t d = new();
            using mpz_t s = new();
            using mpz_t t = new();
            mpz.gcdext(d, s, t, b, c);

            AsString = d.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);

            AsString = s.ToString();
            Assert.AreEqual("20", AsString);

            AsString = t.ToString();
            Assert.AreEqual("-19", AsString);

            using mpz_t g = (b * s) + (c * t);
            AsString = g.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);
        }

        [TestMethod]
        public void Lcm()
        {
            string AsString;

            using mpz_t a = new mpz_t("1167168693521660173095485671632988269022343558906853");
            AsString = a.ToString();
            Assert.AreEqual("1167168693521660173095485671632988269022343558906853", AsString);

            using mpz_t b = new mpz_t("1227023498317642746074741347101346641792720151671307");
            AsString = b.ToString();
            Assert.AreEqual("1227023498317642746074741347101346641792720151671307", AsString);

            using mpz_t c = new();
            mpz.lcm(c, a, b);

            AsString = c.ToString();
            Assert.AreEqual("47853916434388067096914912536952519029916085915180973", AsString);
        }

        [TestMethod]
        public void UintLcm()
        {
            string AsString;

            using mpz_t a = new mpz_t("1167168693521660173095485671632988269022343558906853");
            AsString = a.ToString();
            Assert.AreEqual("1167168693521660173095485671632988269022343558906853", AsString);

            uint b = 79;

            using mpz_t c = new();
            mpz.lcm_ui(c, a, b);

            AsString = c.ToString();
            Assert.AreEqual("92206326788211153674543368059006073252765141153641387", AsString);
        }

        [TestMethod]
        public void Invert()
        {
            string AsString;

            using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
            AsString = a.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);

            using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290461");
            AsString = b.ToString();
            Assert.AreEqual("622288097498926496141095869268883999563096063592498055290461", AsString);

            using mpz_t c = new();
            mpz.invert(c, a, b);

            AsString = c.ToString();
            Assert.AreEqual("219611828940796023289647350941411224882377833088800895212581", AsString);

            using mpz_t d = (c * a) % b;
            AsString = d.ToString();
            Assert.AreEqual("1", AsString);
        }

        [TestMethod]
        public void Jacobi()
        {
            string AsString;

            using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
            AsString = a.ToString();
            Assert.AreEqual("9288562863495827364985273645298367452", AsString);

            using mpz_t b = new mpz_t("876428957629387610928574612341");
            AsString = b.ToString();
            Assert.AreEqual("876428957629387610928574612341", AsString);

            int JacobiSymbol = mpz.jacobi(a, b);

            Assert.AreEqual(JacobiSymbol, -1);
        }

        [TestMethod]
        public void KroneckerInt()
        {
            string AsString;

            using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
            AsString = a.ToString();
            Assert.AreEqual("9288562863495827364985273645298367452", AsString);

            int b = 2;

            int JacobiSymbol = mpz.kronecker_si(a, b);

            Assert.AreEqual(JacobiSymbol, 0);
        }

        [TestMethod]
        public void IntKronecker()
        {
            string AsString;

            using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
            AsString = a.ToString();
            Assert.AreEqual("9288562863495827364985273645298367452", AsString);

            int b = 2;

            int JacobiSymbol = mpz.si_kronecker(b, a);

            Assert.AreEqual(JacobiSymbol, 0);
        }

        [TestMethod]
        public void KroneckerUInt()
        {
            string AsString;

            using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
            AsString = a.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);

            uint b = 2;

            int JacobiSymbol = mpz.ui_kronecker(b, a);

            Assert.AreEqual(JacobiSymbol, -1);
        }

        [TestMethod]
        public void UIntKronecker()
        {
            string AsString;

            using mpz_t a = new mpz_t("29927402397991286489627837734179186385188296382227");
            AsString = a.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);

            uint b = 2;

            int JacobiSymbol = mpz.kronecker_ui(a, b);

            Assert.AreEqual(JacobiSymbol, -1);
        }

        [TestMethod]
        public void Remove()
        {
            string AsString;

            using mpz_t a = new mpz_t("9288562863495827364985273645298367452");
            AsString = a.ToString();
            Assert.AreEqual("9288562863495827364985273645298367452", AsString);

            using mpz_t b = new mpz_t("29927402397991286489627837734179186385188296382227");
            AsString = b.ToString();
            Assert.AreEqual("29927402397991286489627837734179186385188296382227", AsString);

            using mpz_t c = a * b * b;

            using mpz_t d = new();
            ulong Count = mpz.remove(d, c, b);

            AsString = d.ToString();
            Assert.AreEqual("9288562863495827364985273645298367452", AsString);
            Assert.AreEqual(Count, 2UL);
        }

        [TestMethod]
        public void Factorial()
        {
            string AsString;

            ulong n = 30;

            using mpz_t a = new();
            mpz.fac_ui(a, n);

            AsString = a.ToString();
            Assert.AreEqual("265252859812191058636308480000000", AsString);

            using mpz_t b = new();
            mpz.fac_ui2(b, n);

            AsString = b.ToString();
            Assert.AreEqual("42849873690624000", AsString);

            ulong p = 10;

            using mpz_t c = new();
            mpz.mfac_uiui(c, n, p);

            AsString = c.ToString();
            Assert.AreEqual("6000", AsString);
        }

        [TestMethod]
        public void Primorial()
        {
            string AsString;

            ulong n = 30;

            using mpz_t a = new();
            mpz.primorial_ui(a, n);

            AsString = a.ToString();
            Assert.AreEqual("6469693230", AsString);
        }

        [TestMethod]
        public void Binomial()
        {
            string AsString;

            using mpz_t a = new mpz_t("95424793124934570246014589630147");
            AsString = a.ToString();
            Assert.AreEqual("95424793124934570246014589630147", AsString);

            uint n = 3;

            using mpz_t b = new();
            mpz.bin_ui(b, a, n);

            AsString = b.ToString();
            Assert.AreEqual("144821296422149208181035087357372515507071340810124253195368587593141396132717093865187545453665", AsString);

            uint p = 81;

            using mpz_t c = new();
            mpz.bin_uiui(c, p, n);

            AsString = c.ToString();
            Assert.AreEqual("85320", AsString);
        }

        [TestMethod]
        public void Fibonacci()
        {
            string AsString;

            uint n = 80;

            using mpz_t a = new();
            mpz.fib_ui(a, n);

            AsString = a.ToString();
            Assert.AreEqual("23416728348467685", AsString);

            using mpz_t b = new();
            mpz.fib2_ui(a, b, n);

            AsString = a.ToString();
            Assert.AreEqual("23416728348467685", AsString);

            AsString = b.ToString();
            Assert.AreEqual("14472334024676221", AsString);
        }

        [TestMethod]
        public void LucasNumber()
        {
            string AsString;

            uint n = 80;

            using mpz_t a = new();
            mpz.lucnum_ui(a, n);

            AsString = a.ToString();
            Assert.AreEqual("52361396397820127", AsString);

            using mpz_t b = new();
            mpz.lucnum2_ui(a, b, n);

            AsString = a.ToString();
            Assert.AreEqual("52361396397820127", AsString);

            AsString = b.ToString();
            Assert.AreEqual("32361122672259149", AsString);
        }
    }
}
