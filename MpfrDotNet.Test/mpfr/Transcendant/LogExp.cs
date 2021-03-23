namespace Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpfrDotNet;

    [TestClass]
    public class LogExp
    {
        [TestMethod]
        public void BasicLog()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = a.Log();
            AsString = b.ToString();
            Assert.AreEqual("5.836442843051969475709483958780765533447265625E+1", AsString);

            using mpfr_t c = b.Exp();

            AsString = c.ToString();
            Assert.AreEqual("2.225098325034504946712576E+25", AsString);
        }

        [TestMethod]
        public void Log2()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = a.Log2();
            AsString = b.ToString();
            Assert.AreEqual("8.4202071461029589727331767790019512176513671875E+1", AsString);

            using mpfr_t c = b.Exp2();

            AsString = c.ToString();
            Assert.AreEqual("2.2250983250345053762093056E+25", AsString);
        }

        [TestMethod]
        public void Log10()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = a.Log10();
            AsString = b.ToString();
            Assert.AreEqual("2.5347349206811973232333912164904177188873291015625E+1", AsString);

            using mpfr_t c = b.Exp10();
            
            AsString = c.ToString();
            Assert.AreEqual("2.2250983250345109596667904E+25", AsString);
        }

        [TestMethod]
        public void LogULong()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            ulong DefaultPrecision = mpfr_t.DefaultPrecision;
            mpfr_t.DefaultPrecision = 2048;

            uint a = 3466500406U;

            using mpfr_t b = mpfr_t.Log(a);
            using mpfr_t c = b * 10000000;
            using mpfr_t d = c.Round();

            AsString = d.ToString();
            Assert.AreEqual("2.19664114E+8", AsString);

            using mpfr_t e = b.Exp();
            using mpfr_t f = e.Round();

            AsString = f.ToString();
            Assert.AreEqual("3.466500406E+9", AsString);

            mpfr_t.DefaultPrecision = DefaultPrecision;
        }

        [TestMethod]
        public void Log1p()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = a.Log1p();
            AsString = b.ToString();
            Assert.AreEqual("5.836442843051969475709483958780765533447265625E+1", AsString);

            using mpfr_t c = b.Expm1();

            AsString = c.ToString();
            Assert.AreEqual("2.225098325034504946712576E+25", AsString);
        }
    }
}
