namespace TestInteger.Arithmetic.Divide
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class DivExact
    {
        [TestMethod]
        public void BasicDivExact()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305981001312");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305981001312", AsString);

            using mpz_t b = new mpz_t("7879512");
            AsString = b.ToString();
            Assert.AreEqual("7879512", AsString);

            using mpz_t c = a.DivExact(b);

            AsString = c.ToString();
            Assert.AreEqual("29703975896488621895984739027460714489136268649277938276", AsString);

            using mpz_t d = b * c;
            AsString = d.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305981001312", AsString);
        }

        [TestMethod]
        public void UIntDivExact()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305981001312");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305981001312", AsString);

            uint b = 7879512;

            using mpz_t c = a.DivExact(b);

            AsString = c.ToString();
            Assert.AreEqual("29703975896488621895984739027460714489136268649277938276", AsString);

            using mpz_t d = b * c;
            AsString = d.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305981001312", AsString);
        }
    }
}
