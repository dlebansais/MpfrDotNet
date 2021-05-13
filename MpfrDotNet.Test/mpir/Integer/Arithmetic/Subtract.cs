namespace TestInteger.Arithmetic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class Subtract
    {
        [TestMethod]
        public void GenericSub()
        {
            string AsString;

            using mpz_t a = new mpz_t("445497268491433028939318409770173720259");
            AsString = a.ToString();
            Assert.AreEqual("445497268491433028939318409770173720259", AsString);

            using mpz_t b = new mpz_t("222987435987982730594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("222987435987982730594288574029879874539", AsString);

            using mpz_t c = new();
            mpz.sub(c, a, b);
            AsString = c.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);
        }

        [TestMethod]
        public void SubOperator()
        {
            string AsString;

            using mpz_t a = new mpz_t("445497268491433028939318409770173720259");
            AsString = a.ToString();
            Assert.AreEqual("445497268491433028939318409770173720259", AsString);

            using mpz_t b = new mpz_t("222987435987982730594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("222987435987982730594288574029879874539", AsString);

            using mpz_t c = a - b;
            AsString = c.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);
        }

        [TestMethod]
        public void SubUint()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            using mpz_t b = new();
            mpz.sub_ui(b, a, 1);
            AsString = b.ToString();
            Assert.AreEqual("222509832503450298345029835740293845719", AsString);
        }

        [TestMethod]
        public void SubIntOperator1()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            int One = 1;

            using mpz_t b = One - a;
            AsString = b.ToString();
            Assert.AreEqual("-222509832503450298345029835740293845719", AsString);
        }

        [TestMethod]
        public void SubIntOperator2()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            int Two = 2;

            using mpz_t b = a - Two;
            AsString = b.ToString();
            Assert.AreEqual("222509832503450298345029835740293845718", AsString);
        }

        [TestMethod]
        public void SubIntOperator3()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            int MinusOne = -1;

            using mpz_t b = MinusOne - a;
            AsString = b.ToString();
            Assert.AreEqual("-222509832503450298345029835740293845721", AsString);
        }

        [TestMethod]
        public void SubIntOperator4()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            int MinusTwo = -2;

            using mpz_t b = a - MinusTwo;
            AsString = b.ToString();
            Assert.AreEqual("222509832503450298345029835740293845722", AsString);
        }

        [TestMethod]
        public void SubUIntOperator1()
        {
            string AsString;

            using mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            uint One = 1;

            using mpz_t b = One - a;
            AsString = b.ToString();
            Assert.AreEqual("-222509832503450298345029835740293845719", AsString);
        }

        [TestMethod]
        public void SubUIntOperator2()
        {
            string AsString;

            using var a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            uint Two = 2;

            using mpz_t b = a - Two;
            AsString = b.ToString();
            Assert.AreEqual("222509832503450298345029835740293845718", AsString);
        }

        [TestMethod]
        public void DecrementOperator()
        {
            string AsString;

            mpz_t a = new mpz_t("222509832503450298345029835740293845720");
            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845720", AsString);

            a--;

            AsString = a.ToString();
            Assert.AreEqual("222509832503450298345029835740293845719", AsString);

            using (mpz_t clear = a)
            {
            }
        }
    }
}
