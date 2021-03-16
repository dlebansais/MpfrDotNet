namespace Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpfrDotNet.mpfr;
    using MpirDotNet;

    [TestClass]
    public class Div
    {
        [TestMethod]
        public void BasicDiv()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("2.22987435987982725E+15", AsString);

            using mpfr_t c = a / b;

            AsString = c.ToString();
            Assert.AreEqual("9.9785815966529083251953125E+9", AsString);

            using mpfr_t d = b / a;

            AsString = d.ToString();
            Assert.AreEqual("1.0021464376614685245922416240006258374151126844253668E-10", AsString);
        }

        [TestMethod]
        public void DivULong()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            ulong b = 8720124937520142UL;

            using mpfr_t c = a / b;

            AsString = c.ToString();
            Assert.AreEqual("1.7157797586666184E+16", AsString);

            using mpfr_t d = b / a;

            AsString = d.ToString();
            Assert.AreEqual("5.8282538592081811994898800165654616210395441114767295E-17", AsString);
        }

        [TestMethod]
        public void DivLong()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            ulong b = 8720124937520142L;

            using mpfr_t c = a / b;

            AsString = c.ToString();
            Assert.AreEqual("1.7157797586666184E+16", AsString);

            using mpfr_t d = b / a;

            AsString = d.ToString();
            Assert.AreEqual("5.8282538592081811994898800165654616210395441114767295E-17", AsString);
        }

        [TestMethod]
        public void DivDouble()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            double b = 2229874359879827.30594288574029879874539;

            using mpfr_t c = a / b;

            AsString = c.ToString();
            Assert.AreEqual("9.9785815966529083251953125E+9", AsString);

            using mpfr_t d = b / a;

            AsString = d.ToString();
            Assert.AreEqual("1.0021464376614685245922416240006258374151126844253668E-10", AsString);
        }

        [TestMethod]
        public void DivInteger()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpz_t b = new mpz_t("8720124937520142");
            AsString = b.ToString();
            Assert.AreEqual("8720124937520142", AsString);

            using mpfr_t c = a / b;

            AsString = c.ToString();
            Assert.AreEqual("2.55168170293129253387451171875E+9", AsString);

            using mpfr_t d = b / a;

            AsString = d.ToString();
            Assert.AreEqual("3.9189840913591654520212402637048803438757360595445789E-10", AsString);
        }

        [TestMethod]
        public void DivRational()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpq_t b = new mpq_t("222987435987982730594288574029879874539/590872612825179551336102196593");
            AsString = b.ToString();
            Assert.AreEqual("222987435987982730594288574029879874539/590872612825179551336102196593", AsString);

            using mpfr_t c = a / b;

            AsString = c.ToString();
            Assert.AreEqual("5.896070580303556E+16", AsString);

            using mpfr_t d = b / a;

            AsString = d.ToString();
            Assert.AreEqual("1.6960448257532824537824129696119695088406899340441325E-17", AsString);
        }
    }
}
