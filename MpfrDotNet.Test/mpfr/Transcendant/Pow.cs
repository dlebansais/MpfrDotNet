namespace Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpfrDotNet;
    using MpirDotNet;

    [TestClass]
    public class Pow
    {
        [TestMethod]
        public void Sqrt()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = a.Sqrt();
            AsString = b.ToString();
            Assert.AreEqual("4.7170947892050068359375E+12", AsString);

            using mpfr_t c = b * b;

            AsString = c.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);
        }

        [TestMethod]
        public void Cbrt()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = a.Cbrt();
            AsString = b.ToString();
            Assert.AreEqual("2.8126545943151724338531494140625E+8", AsString);

            using mpfr_t c = b * b;
            using mpfr_t d = c * b;

            AsString = d.ToString();
            Assert.AreEqual("2.2250983250345032287256576E+25", AsString);
        }

        [TestMethod]
        public void NthRoot()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = a.NthRoot(4);
            AsString = b.ToString();
            Assert.AreEqual("2.1718873794939289800822734832763671875E+6", AsString);

            using mpfr_t c = b * b;
            using mpfr_t d = c * c;

            AsString = d.ToString();
            Assert.AreEqual("2.2250983250345019402354688E+25", AsString);
        }

        [TestMethod]
        public void BasicPow()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = new mpfr_t("22298.30594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("2.229830594288574138772673904895782470703125E+4", AsString);

            using mpfr_t c = a.Pow(b);

            AsString = c.ToString();
            Assert.AreEqual("8.8604270763516055878742474068479142491907987806803106E+565202", AsString);
        }

        [TestMethod]
        public void PowULong()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            ulong b = 2298UL;

            using mpfr_t c = a.Pow(b);

            AsString = c.ToString();
            Assert.AreEqual("1.6161335792074527542053905024123190293137783144925748E+58248", AsString);
        }

        [TestMethod]
        public void PowLong()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            long b = -298L;

            using mpfr_t c = a.Pow(b);

            AsString = c.ToString();
            Assert.AreEqual("3.0898426959440158607034270958290746619365141606450785E-7554", AsString);
        }

        [TestMethod]
        public void PowZ()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpz_t b = new mpz_t("22298");
            AsString = b.ToString();
            Assert.AreEqual("22298", AsString);

            using mpfr_t c = a.Pow(b);

            AsString = c.ToString();
            Assert.AreEqual("1.5581651739453832511769734040031532442192330006796866E+565195", AsString);
        }

        [TestMethod]
        public void ULongPowULong()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            ulong a = 986301247803256UL;
            ulong b = 2298UL;

            using mpfr_t c = mpfr_t.Pow(a, b);

            AsString = c.ToString();
            Assert.AreEqual("6.4829910177520683960833599314513372017595330570447944E+20271", AsString);
        }

        [TestMethod]
        public void ULongPow()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            ulong a = 986301247803256UL;

            using mpfr_t b = new mpfr_t("22298.30594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("2.229830594288574138772673904895782470703125E+4", AsString);

            using mpfr_t c = mpfr_t.Pow(a, b);

            AsString = c.ToString();
            Assert.AreEqual("3.566257951433289950338102319742678367693289979708027E+196704", AsString);
        }
    }
}
