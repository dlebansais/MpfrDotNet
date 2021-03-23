namespace Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpfrDotNet;
    using MpirDotNet;

    [TestClass]
    public class Add
    {
        [TestMethod]
        public void BasicAdd()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("2.22987435987982725E+15", AsString);

            using mpfr_t c = a + b;

            AsString = c.ToString();
            Assert.AreEqual("2.2250983252574901997928448E+25", AsString);

            using mpfr_t d = b + a;

            AsString = d.ToString();
            Assert.AreEqual("2.2250983252574901997928448E+25", AsString);
        }

        [TestMethod]
        public void AddULong()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            ulong DefaultPrecision = mpfr_t.DefaultPrecision;
            mpfr_t.DefaultPrecision = 128;

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.2250983250345029834502983574029384571986156515777111053466796875E+25", AsString);

            ulong b = 8720124937520142UL;

            using mpfr_t c = a + b;

            AsString = c.ToString();
            Assert.AreEqual("2.2250983259065154772023125574029384571986156515777111053466796875E+25", AsString);

            using mpfr_t d = b + a;

            AsString = d.ToString();
            Assert.AreEqual("2.2250983259065154772023125574029384571986156515777111053466796875E+25", AsString);

            using mpfr_t e = c - a;

            AsString = e.ToString();
            Assert.AreEqual("8.720124937520142E+15", AsString);

            mpfr_t.DefaultPrecision = DefaultPrecision;
        }

        [TestMethod]
        public void AddLong()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            ulong DefaultPrecision = mpfr_t.DefaultPrecision;
            mpfr_t.DefaultPrecision = 128;

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.2250983250345029834502983574029384571986156515777111053466796875E+25", AsString);

            long b = -8720124937520142L;

            using mpfr_t c = a + b;

            AsString = c.ToString();
            Assert.AreEqual("2.2250983241624904896982841574029384571986156515777111053466796875E+25", AsString);

            using mpfr_t d = b + a;

            AsString = d.ToString();
            Assert.AreEqual("2.2250983241624904896982841574029384571986156515777111053466796875E+25", AsString);

            using mpfr_t e = c - a;

            AsString = e.ToString();
            Assert.AreEqual("-8.720124937520142E+15", AsString);

            mpfr_t.DefaultPrecision = DefaultPrecision;
        }

        [TestMethod]
        public void AddDouble()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            double b = 2229874359879827.30594288574029879874539;

            using mpfr_t c = a + b;

            AsString = c.ToString();
            Assert.AreEqual("2.2250983252574901997928448E+25", AsString);

            using mpfr_t d = b + a;

            AsString = d.ToString();
            Assert.AreEqual("2.2250983252574901997928448E+25", AsString);
        }

        [TestMethod]
        public void AddInteger()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpz_t b = new mpz_t("8720124937520142");
            AsString = b.ToString();
            Assert.AreEqual("8720124937520142", AsString);

            using mpfr_t c = a + b;

            AsString = c.ToString();
            Assert.AreEqual("2.2250983259065151632965632E+25", AsString);

            using mpfr_t d = b + a;

            AsString = d.ToString();
            Assert.AreEqual("2.2250983259065151632965632E+25", AsString);
        }

        [TestMethod]
        public void AddRational()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
            AsString = b.ToString();
            Assert.AreEqual("222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

            using mpfr_t c = a + b;

            AsString = c.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t d = b + a;

            AsString = d.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);
        }
    }
}
