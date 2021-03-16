namespace Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpfrDotNet;
    using MpirDotNet;

    [TestClass]
    public class Create
    {
        [TestMethod]
        public void CreateDefaultPrecision()
        {
            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            ulong DefaultPrecision = mpfr_t.DefaultPrecision;

            using mpfr_t a = new mpfr_t();
            Assert.AreEqual(a.Precision, DefaultPrecision);

            mpfr.init(a);
            Assert.AreEqual(a.Precision, DefaultPrecision);
        }

        [TestMethod]
        public void CreateCustomPrecision()
        {
            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            ulong DefaultPrecision = mpfr_t.DefaultPrecision;
            ulong CustomPrecision = DefaultPrecision + 64;

            using mpfr_t a = new mpfr_t();
            Assert.AreEqual(a.Precision, DefaultPrecision);

            mpfr.init(a);
            Assert.AreEqual(a.Precision, DefaultPrecision);

            a.Precision = CustomPrecision;
            Assert.AreEqual(a.Precision, CustomPrecision);

            using mpfr_t b = mpfr_t.Create(CustomPrecision);
            Assert.AreEqual(b.Precision, CustomPrecision);

            mpfr.init(b);
            Assert.AreEqual(b.Precision, DefaultPrecision);

            b.Precision = CustomPrecision;
            Assert.AreEqual(b.Precision, CustomPrecision);

            mpfr_t.DefaultPrecision = CustomPrecision;

            using mpfr_t c = new mpfr_t();
            Assert.AreEqual(c.Precision, CustomPrecision);

            mpfr.init(c);
            Assert.AreEqual(c.Precision, CustomPrecision);

            using mpfr_t d = mpfr_t.Create(DefaultPrecision);
            Assert.AreEqual(d.Precision, DefaultPrecision);

            mpfr.init(d);
            Assert.AreEqual(d.Precision, CustomPrecision);

            mpfr_t.DefaultPrecision = DefaultPrecision;

            using mpfr_t e = mpfr_t.Create(DefaultPrecision);
            Assert.AreEqual(e.Precision, DefaultPrecision);

            mpfr.init(e);
            Assert.AreEqual(e.Precision, DefaultPrecision);

            e.Precision = CustomPrecision;
            Assert.AreEqual(e.Precision, CustomPrecision);

            using mpfr_t f = new mpfr_t();
            Assert.AreEqual(f.Precision, DefaultPrecision);

            mpfr.init(f);
            Assert.AreEqual(f.Precision, DefaultPrecision);

            f.Precision = CustomPrecision;
            Assert.AreEqual(f.Precision, CustomPrecision);
        }

        [TestMethod]
        public void CreateFrom()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t NaN = new mpfr_t();
            AsString = NaN.ToString();
            Assert.AreEqual("@NaN@", AsString);

            using mpfr_t PositiveInfinite = mpfr_t.Infinite();
            AsString = PositiveInfinite.ToString();
            Assert.AreEqual("@Inf@", AsString);

            using mpfr_t NegativeInfinite = mpfr_t.Infinite(-1);
            AsString = NegativeInfinite.ToString();
            Assert.AreEqual("-@Inf@", AsString);

            using mpfr_t Zero = mpfr_t.Zero();
            AsString = Zero.ToString();
            Assert.AreEqual("0", AsString);

            using mpfr_t NegativeZero = mpfr_t.Zero(-1);
            AsString = NegativeZero.ToString();
            Assert.AreEqual("-0", AsString);

            using mpfr_t b = new mpfr_t(10);
            AsString = b.ToString();
            Assert.AreEqual("1E+1", AsString);

            using mpfr_t c = new mpfr_t(b);
            AsString = c.ToString();
            Assert.AreEqual("1E+1", AsString);

            using mpfr_t d = new mpfr_t(100UL);
            AsString = d.ToString();
            Assert.AreEqual("1E+2", AsString);

            using mpfr_t e = new mpfr_t(-100L);
            AsString = e.ToString();
            Assert.AreEqual("-1E+2", AsString);

            using mpfr_t f = new mpfr_t(100U);
            AsString = f.ToString();
            Assert.AreEqual("1E+2", AsString);

            using mpfr_t g = new mpfr_t(200.1F);
            AsString = g.ToString();
            Assert.AreEqual("2.00100006103515625E+2", AsString);

            using mpfr_t h = new mpfr_t(-200.1);
            AsString = h.ToString();
            Assert.AreEqual("-2.00099999999999994315658113919198513031005859375E+2", AsString);

            using mpz_t iz = new mpz_t("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", 16);
            AsString = iz.ToString(16).ToUpper();
            Assert.AreEqual("10123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", AsString);

            using mpfr_t i = new mpfr_t(iz);
            AsString = i.ToString();
            Assert.AreEqual("6.3049999653217328579866181421408313514338742205512312E+57", AsString);

            using mpq_t jq = new mpq_t("222509832503450298345029835740293845720/115756986668303657898962467957");
            AsString = jq.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720/115756986668303657898962467957", AsString);

            using mpfr_t j = new mpfr_t(jq);
            AsString = j.ToString();
            Assert.AreEqual("1.9222151414587357044219970703125E+9", AsString);

            using mpf_t kf = new mpf_t("22250983250345029834502983.5740293845720");
            AsString = kf.ToString();
            Assert.AreEqual("2.22509832503450298345E+25", AsString);

            using mpfr_t k = new mpfr_t(kf);
            AsString = k.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t l = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = l.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);
        }
    }
}
