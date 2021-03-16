namespace TestInteger.Arithmetic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class Multiply
    {
        [TestMethod]
        public void GenericMul()
        {
            string AsString;

            using mpz_t a = new mpz_t("90234098723098475098479385345098345");
            AsString = a.ToString();
            Assert.AreEqual("90234098723098475098479385345098345", AsString);

            using mpz_t b = new mpz_t("7859487359873459872354987610987897");
            AsString = b.ToString();
            Assert.AreEqual("7859487359873459872354987610987897", AsString);

            using mpz_t c = new();
            mpz.mul(c, a, b);
            AsString = c.ToString();
            Assert.AreEqual("709193758343766370701419953880162061353595657143399816050772069730465", AsString);
        }

        [TestMethod]
        public void MulOperator()
        {
            string AsString;

            using mpz_t a = new mpz_t("90234098723098475098479385345098345");
            AsString = a.ToString();
            Assert.AreEqual("90234098723098475098479385345098345", AsString);

            using mpz_t b = new mpz_t("7859487359873459872354987610987897");
            AsString = b.ToString();
            Assert.AreEqual("7859487359873459872354987610987897", AsString);

            using mpz_t c = a * b;
            AsString = c.ToString();
            Assert.AreEqual("709193758343766370701419953880162061353595657143399816050772069730465", AsString);
        }

        [TestMethod]
        public void MulIntOperator1()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            int Three = 3;

            using mpz_t b = Three * a;
            AsString = b.ToString();
            Assert.AreEqual("667529497510350895035089507220881537160", AsString);
        }

        [TestMethod]
        public void MulIntOperator2()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            int Two = 2;

            using mpz_t b = a * Two;
            AsString = b.ToString();
            Assert.AreEqual("445019665006900596690059671480587691440", AsString);
        }

        [TestMethod]
        public void MulIntOperator3()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            int MinusOne = -1;

            using mpz_t b = MinusOne * a;
            AsString = b.ToString();
            Assert.AreEqual("-222509832503450298345029835740293845720", AsString);
        }

        [TestMethod]
        public void MulIntOperator4()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            int MinusTwo = -2;

            using mpz_t b = a * MinusTwo;
            AsString = b.ToString();
            Assert.AreEqual("-445019665006900596690059671480587691440", AsString);
        }

        [TestMethod]
        public void MulUIntOperator1()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            uint Three = 3;

            using mpz_t b = Three * a;
            AsString = b.ToString();
            Assert.AreEqual("667529497510350895035089507220881537160", AsString);
        }

        [TestMethod]
        public void MulUIntOperator2()
        {
            string AsString;

            using var a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            uint Two = 2;

            using mpz_t b = a * Two;
            AsString = b.ToString();
            Assert.AreEqual("445019665006900596690059671480587691440", AsString);
        }
    }
}
