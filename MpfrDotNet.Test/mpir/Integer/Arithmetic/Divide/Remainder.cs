namespace TestInteger.Arithmetic.Divide
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class Remainder
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

            using mpz_t c = a.Remainder(b);

            AsString = c.ToString();
            Assert.AreEqual("114368714235760586972822754176083531704767", AsString);

            using mpz_t d = a.Remainder(b, Rounding.TowardZero);

            AsString = d.ToString();
            Assert.AreEqual("114368714235760586972822754176083531704767", AsString);
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

            using mpz_t c = a.Remainder(b, Rounding.TowardPositiveInfinity);

            AsString = c.ToString();
            Assert.AreEqual("-280211579611742400636461191697511341704820", AsString);
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

            using mpz_t c = a.Remainder(b, Rounding.TowardNegativeInfinity);

            AsString = c.ToString();
            Assert.AreEqual("-280211579611742400636461191697511341704820", AsString);
        }

        [TestMethod]
        public void UintTowardZero()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            using mpz_t c = a.Remainder(b);

            AsString = c.ToString();
            Assert.AreEqual("16785", AsString);

            using mpz_t d = a.Remainder(b, Rounding.TowardZero);

            AsString = d.ToString();
            Assert.AreEqual("16785", AsString);
        }

        [TestMethod]
        public void UintTowardPositiveInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            using mpz_t c = a.Remainder(b, Rounding.TowardPositiveInfinity);

            AsString = c.ToString();
            Assert.AreEqual("-16785", AsString);
        }

        [TestMethod]
        public void UintTowardNegativeInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            using mpz_t c = a.Remainder(b, Rounding.TowardNegativeInfinity);

            AsString = c.ToString();
            Assert.AreEqual("1050", AsString);
        }

        [TestMethod]
        public void FastUintTowardZero()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            uint c = a.AbsRemainder(b);

            Assert.AreEqual(16785U, c);

            uint d = a.AbsRemainder(b, Rounding.TowardZero);

            Assert.AreEqual(16785U, d);
        }

        [TestMethod]
        public void FastUintTowardPositiveInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            uint c = a.AbsRemainder(b, Rounding.TowardPositiveInfinity);

            Assert.AreEqual(16785U, c);
        }

        [TestMethod]
        public void FastUintTowardNegativeInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            uint c = a.AbsRemainder(b, Rounding.TowardNegativeInfinity);

            AsString = c.ToString();
            Assert.AreEqual(1050U, c);
        }
    }
}
