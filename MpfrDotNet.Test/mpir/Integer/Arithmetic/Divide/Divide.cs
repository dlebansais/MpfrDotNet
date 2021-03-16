namespace TestInteger.Arithmetic.Divide
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class Divide
    {
        [TestMethod]
        public void GenericDivide()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
            AsString = b.ToString();
            Assert.AreEqual("394580293847502987609283945873594873409587", AsString);

            using mpz_t c = new();
            mpz.tdiv_q(c, a, b);
            AsString = c.ToString();
            Assert.AreEqual("593169091750307653294", AsString);
        }

        [TestMethod]
        public void DivOperator1()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            using mpz_t b = new mpz_t("394580293847502987609283945873594873409587");
            AsString = b.ToString();
            Assert.AreEqual("394580293847502987609283945873594873409587", AsString);

            using mpz_t c = a / b;

            AsString = c.ToString();
            Assert.AreEqual("593169091750307653294", AsString);
        }

        [TestMethod]
        public void IntDivOperator1()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            int Three = 3;

            using mpz_t c = a / Three;

            AsString = c.ToString();
            Assert.AreEqual("78017611508030951364291500994581676448574366152403101994478115", AsString);
        }

        [TestMethod]
        public void IntDivOperator2()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            int MinusThree = -3;

            using mpz_t c = a / MinusThree;

            AsString = c.ToString();
            Assert.AreEqual("-78017611508030951364291500994581676448574366152403101994478115", AsString);
        }

        [TestMethod]
        public void UIntDivOperator()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint Three = 3;

            using mpz_t c = a / Three;

            AsString = c.ToString();
            Assert.AreEqual("78017611508030951364291500994581676448574366152403101994478115", AsString);
        }

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

            mpz_t.Divide(a, b, out mpz_t q, out mpz_t r);

            AsString = q.ToString();
            Assert.AreEqual("593169091750307653294", AsString);
            AsString = r.ToString();
            Assert.AreEqual("114368714235760586972822754176083531704767", AsString);

            mpz_t.Divide(a, b, out q, out r, Rounding.TowardZero);

            AsString = q.ToString();
            Assert.AreEqual("593169091750307653294", AsString);
            AsString = r.ToString();
            Assert.AreEqual("114368714235760586972822754176083531704767", AsString);

            using mpz_t n = r + (q * b);

            AsString = n.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);
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

            mpz_t.Divide(a, b, out mpz_t q, out mpz_t r, Rounding.TowardPositiveInfinity);

            AsString = q.ToString();
            Assert.AreEqual("593169091750307653295", AsString);
            AsString = r.ToString();
            Assert.AreEqual("-280211579611742400636461191697511341704820", AsString);

            using mpz_t n = r + (q * b);

            AsString = n.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);
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

            mpz_t.Divide(a, b, out mpz_t q, out mpz_t r, Rounding.TowardNegativeInfinity);

            AsString = q.ToString();
            Assert.AreEqual("-593169091750307653295", AsString);
            AsString = r.ToString();
            Assert.AreEqual("-280211579611742400636461191697511341704820", AsString);

            using mpz_t n = r + (q * b);

            AsString = n.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);
        }


        [TestMethod]
        public void UintTowardZero()
        {
            string AsString;

            using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            mpz_t.Divide(a, b, out mpz_t q, out mpz_t r);

            AsString = q.ToString();
            Assert.AreEqual("13123231540459369447315643565110458612039422397376467955336", AsString);
            AsString = r.ToString();
            Assert.AreEqual("16785", AsString);

            mpz_t.Divide(a, b, out q, out r, Rounding.TowardZero);

            AsString = q.ToString();
            Assert.AreEqual("13123231540459369447315643565110458612039422397376467955336", AsString);
            AsString = r.ToString();
            Assert.AreEqual("16785", AsString);

            using mpz_t n = r + (q * b);

            AsString = n.ToString();
            Assert.AreEqual("234052834524092854092874502983745029345723098457209305983434345", AsString);
        }

        [TestMethod]
        public void UintTowardPositiveInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            mpz_t.Divide(a, b, out mpz_t q, out mpz_t r, Rounding.TowardPositiveInfinity);

            AsString = q.ToString();
            Assert.AreEqual("-13123231540459369447315643565110458612039422397376467955336", AsString);
            AsString = r.ToString();
            Assert.AreEqual("-16785", AsString);

            using mpz_t n = r + (q * b);

            AsString = n.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);
        }

        [TestMethod]
        public void UintTowardNegativeInfinity()
        {
            string AsString;

            using mpz_t a = new mpz_t("-234052834524092854092874502983745029345723098457209305983434345");
            AsString = a.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);

            uint b = 17835;

            mpz_t.Divide(a, b, out mpz_t q, out mpz_t r, Rounding.TowardNegativeInfinity);

            AsString = q.ToString();
            Assert.AreEqual("-13123231540459369447315643565110458612039422397376467955337", AsString);
            AsString = r.ToString();
            Assert.AreEqual("1050", AsString);

            using mpz_t n = r + (q * b);

            AsString = n.ToString();
            Assert.AreEqual("-234052834524092854092874502983745029345723098457209305983434345", AsString);
        }
    }
}
