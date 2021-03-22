namespace TestFloating
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class Misc
    {
        [TestMethod]
        public void Create()
        {
            string AsString;

            using mpf_t a = new mpf_t();
            AsString = a.ToString();
            Assert.AreEqual("0", AsString);

            Assert.IsTrue(a.IsInteger);
            Assert.IsTrue(a.Sign == 0);

            ulong DefaultPrecision = mpf.get_default_prec();
            Assert.AreEqual(DefaultPrecision, 64UL);
            Assert.AreEqual(a.Precision, DefaultPrecision);

            using mpf_t b = new mpf_t(10U);
            AsString = b.ToString();
            Assert.AreEqual("1E+1", AsString);

            Assert.AreEqual((uint)b, 10U);

            using mpf_t c = new mpf_t(-10);
            AsString = c.ToString();
            Assert.AreEqual("-1E+1", AsString);

            Assert.AreEqual((int)c, -10);

            using mpf_t d = new mpf_t(10U, DefaultPrecision);
            AsString = d.ToString();
            Assert.AreEqual("1E+1", AsString);

            using mpf_t e = new mpf_t(-10, DefaultPrecision);
            AsString = e.ToString();
            Assert.AreEqual("-1E+1", AsString);

            using mpf_t f = new mpf_t(50.2);
            AsString = f.ToString();
            Assert.AreEqual("5.02000000000000028422E+1", AsString);

            Assert.AreEqual((double)f, 50.2);

            using mpf_t g = new mpf_t(50.2, DefaultPrecision + 64);
            AsString = g.ToString();
            Assert.AreEqual("5.02000000000000028421709430404007434845E+1", AsString);

            Assert.AreEqual(g.Precision, DefaultPrecision + 64);

            using mpf_t h = new mpf_t("2225098325034502983450298.3574029384572");
            AsString = h.ToString();
            Assert.AreEqual("2.22509832503450298345E+24", AsString);

            using mpf_t i = new mpf_t("2225098325034502983450298.3574029384572", 10, 200);
            AsString = i.ToString();
            Assert.AreEqual("2.2250983250345029834502983574029384572E+24", AsString);

            using mpf_t j = new mpf_t(i);
            AsString = j.ToString();
            Assert.AreEqual("2.2250983250345029834502983574029384572E+24", AsString);

            using mpf_t k = new mpf_t(i, true);
            AsString = k.ToString();
            Assert.AreEqual("2.22509832503450298345E+24", AsString);

            using mpf_t l = -k;
            AsString = l.ToString();
            Assert.AreEqual("-2.22509832503450298345E+24", AsString);

            using mpf_t m = l.Abs();
            AsString = m.ToString();
            Assert.AreEqual("2.22509832503450298345E+24", AsString);

            using mpf_t p = new mpf_t("68719476735");
            AsString = p.ToString();
            Assert.AreEqual("6.8719476735E+10", AsString);
            ulong UlongCast = (ulong)p;
            Assert.AreEqual(UlongCast, 68719476735UL);

            using mpf_t q = new mpf_t("2147483647");
            AsString = q.ToString();
            Assert.AreEqual("2.147483647E+9", AsString);
            uint UintCast = (uint)q;
            Assert.AreEqual(UintCast, 2147483647U);
        }

        [TestMethod]
        public void Precision()
        {
            ulong DefaultPrecision;

            DefaultPrecision = mpf_t.DefaultPrecision;
            Assert.IsTrue(DefaultPrecision == 64);

            mpf_t.DefaultPrecision = 128;

            DefaultPrecision = mpf_t.DefaultPrecision;
            Assert.IsTrue(DefaultPrecision == 128);

            mpf_t.DefaultPrecision = 0x7FFFFFFF;

            DefaultPrecision = mpf_t.DefaultPrecision;
            Assert.IsTrue(DefaultPrecision >= 0x7FFFFFFF);

            mpf_t.DefaultPrecision = 0xFFFFFFFF;

            DefaultPrecision = mpf_t.DefaultPrecision;
            Assert.IsTrue(DefaultPrecision >= 0xFFFFFFFF);

            mpf_t.DefaultPrecision = 0x1FFFFFFFF;

            DefaultPrecision = mpf_t.DefaultPrecision;
            Assert.IsTrue(DefaultPrecision >= 0x1FFFFFFFF);

            mpf_t.DefaultPrecision = 64;
        }

        [TestMethod]
        public void Rounding()
        {
            string AsString;

            using mpf_t a = new mpf_t("2983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.983574029384572E+3", AsString);

            using mpf_t b = a.Ceil();
            AsString = b.ToString();
            Assert.AreEqual("2.984E+3", AsString);

            using mpf_t c = a.Floor();
            AsString = c.ToString();
            Assert.AreEqual("2.983E+3", AsString);

            using mpf_t d = a.Trunc();
            AsString = d.ToString();
            Assert.AreEqual("2.983E+3", AsString);
        }
    }
}
