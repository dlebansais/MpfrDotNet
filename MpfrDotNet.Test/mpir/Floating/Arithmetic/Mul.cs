namespace TestFloating
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class Mul
    {
        [TestMethod]
        public void BasicMul()
        {
            string AsString;

            using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.22509832503450298345E+25", AsString);

            using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("2.22987435987982730594E+15", AsString);

            using mpf_t c = new();
            mpf.mul(c, a, b);

            AsString = c.ToString();
            Assert.AreEqual("4.96168970320598825788E+40", AsString);
        }

        [TestMethod]
        public void MulOperator()
        {
            string AsString;

            using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.22509832503450298345E+25", AsString);

            using mpf_t b = new mpf_t("2229874359879827.30594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("2.22987435987982730594E+15", AsString);

            using mpf_t c = a * b;

            AsString = c.ToString();
            Assert.AreEqual("4.96168970320598825788E+40", AsString);
        }

        [TestMethod]
        public void MulUint()
        {
            string AsString;

            using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.22509832503450298345E+25", AsString);

            uint b = 98873014;

            using mpf_t c = a * b;

            AsString = c.ToString();
            Assert.AreEqual("2.20002177842512963966E+33", AsString);
        }

        [TestMethod]
        public void MulIntPositive()
        {
            string AsString;

            using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.22509832503450298345E+25", AsString);

            int b = 98873014;

            using mpf_t c = a * b;

            AsString = c.ToString();
            Assert.AreEqual("2.20002177842512963966E+33", AsString);
        }

        [TestMethod]
        public void MulIntNegative()
        {
            string AsString;

            using mpf_t a = new mpf_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.22509832503450298345E+25", AsString);

            int b = -98873014;

            using mpf_t c = a * b;

            AsString = c.ToString();
            Assert.AreEqual("-2.20002177842512963966E+33", AsString);
        }
    }
}
