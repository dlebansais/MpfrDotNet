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

            ulong a = 2225098325034502UL;

            using mpfr_t b = mpfr_t.Log(a);
            AsString = b.ToString();
            Assert.AreEqual("1.9593251069248712070702822529710829257965087890625E+1", AsString);

            using mpfr_t c = b.Exp();

            AsString = c.ToString();
            Assert.AreEqual("3.23028485999999523162841796875E+8", AsString);
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
