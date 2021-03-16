namespace TestInteger.Arithmetic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class Power
    {
        [TestMethod]
        public void BasicPower()
        {
            string AsString;

            using mpz_t a = new mpz_t("9785412309485720938412983404349");
            AsString = a.ToString();
            Assert.AreEqual("9785412309485720938412983404349", AsString);

            uint b = 4;

            mpz_t d = new();
            mpz.pow_ui(d, a, b);

            AsString = d.ToString();
            Assert.AreEqual("9168884832199547717402442404668238841010784738902226284286664833331445628675177089723224507720724521226586825967635414667601", AsString);
        }

        [TestMethod]
        public void PowerOperator()
        {
            string AsString;

            using mpz_t a = new mpz_t("9785412309485720938412983404349");
            AsString = a.ToString();
            Assert.AreEqual("9785412309485720938412983404349", AsString);

            uint b = 4;

            mpz_t d = a.Pow(b);

            AsString = d.ToString();
            Assert.AreEqual("9168884832199547717402442404668238841010784738902226284286664833331445628675177089723224507720724521226586825967635414667601", AsString);
        }

        [TestMethod]
        public void PowerModUint()
        {
            string AsString;

            uint a = 60;
            uint b = 60;

            mpz_t d = new();
            mpz.ui_pow_ui(d, a, b);

            AsString = d.ToString();
            Assert.AreEqual("48873677980689257489322752273774603865660850176000000000000000000000000000000000000000000000000000000000000", AsString);
        }
    }
}
