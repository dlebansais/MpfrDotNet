namespace Test
{
    using Interop.Mpfr;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpfrDotNet;
    using MpirDotNet;

    [TestClass]
    public class MiscArithmetic
    {
        [TestMethod]
        public void Abs()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("-22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("-2.225098325034502799228928E+25", AsString);

            using mpfr_t b = a.Abs();
            AsString = b.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t c = -b;

            AsString = c.ToString();
            Assert.AreEqual("-2.225098325034502799228928E+25", AsString);
        }

        [TestMethod]
        public void EuclieanNorm()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("8650279350142877.30794528793012596741");
            AsString = a.ToString();
            Assert.AreEqual("8.650279350142877E+15", AsString);

            using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("2.22987435987982725E+15", AsString);

            using mpfr_t c = mpfr_t.EuclideanNorm(a, b);

            AsString = c.ToString();
            Assert.AreEqual("8.933066242693924E+15", AsString);
        }

        [TestMethod]
        public void Factorial()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            ulong a = 222501UL;

            using mpfr_t b = new();
            mpfr.fac_ui(b, a, mpfr_rnd_t.MPFR_RNDN);

            AsString = b.ToString();
            Assert.AreEqual("6.7030370457971507477756421807177227647562122526821094E+1093158", AsString);

            using mpz_t c = new();
            mpz.fac_ui(c, a);

            AsString = c.ToString().Substring(0, 15);
            Assert.AreEqual("670303704579715", AsString);
        }
    }
}
