namespace TestInteger.Arithmetic.Divide
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class Quotient
    {
        [TestMethod]
        public void TowardZero()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
            AsString = b.ToString();
            Assert.AreEqual("394580293847502987609283945873594873409587", AsString);

            using mpz_t c = a.Quotient(b);

            AsString = c.ToString();
            Assert.AreEqual("593169091750307653294", AsString);

            using mpz_t d = a.Quotient(b, Rounding.TowardZero);

            AsString = d.ToString();
            Assert.AreEqual("593169091750307653294", AsString);
        }

        [TestMethod]
        public void TowardPositiveInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
            AsString = b.ToString();
            Assert.AreEqual("394580293847502987609283945873594873409587", AsString);

            using mpz_t c = a.Quotient(b, Rounding.TowardPositiveInfinity);

            AsString = c.ToString();
            Assert.AreEqual("593169091750307653295", AsString);
        }

        [TestMethod]
        public void TowardNegativeInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            using mpz_t b = new mpz_t("-394580293847502987609283945873594873409587");
            AsString = b.ToString();
            Assert.AreEqual("-394580293847502987609283945873594873409587", AsString);

            using mpz_t c = a.Quotient(b, Rounding.TowardNegativeInfinity);

            AsString = c.ToString();
            Assert.AreEqual("-593169091750307653295", AsString);
        }

        [TestMethod]
        public void UintTowardZero()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            using mpz_t c = a.Quotient(b);

            AsString = c.ToString();
            Assert.AreEqual("13123231540459369447315643565110458612039422397376467955336", AsString);

            using mpz_t d = a.Quotient(b, Rounding.TowardZero);

            AsString = d.ToString();
            Assert.AreEqual("13123231540459369447315643565110458612039422397376467955336", AsString);
        }

        [TestMethod]
        public void UintTowardPositiveInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            using mpz_t c = a.Quotient(b, Rounding.TowardPositiveInfinity);

            AsString = c.ToString();
            Assert.AreEqual("-13123231540459369447315643565110458612039422397376467955336", AsString);
        }

        [TestMethod]
        public void UintTowardNegativeInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            using mpz_t c = a.Quotient(b, Rounding.TowardNegativeInfinity);

            AsString = c.ToString();
            Assert.AreEqual("-13123231540459369447315643565110458612039422397376467955337", AsString);
        }
    }
}
