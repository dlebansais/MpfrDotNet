namespace TestInteger.Arithmetic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class SubtractProduct
    {
        [TestMethod]
        public void BasicSubtractProduct()
        {
            string AsString;

            using mpz_t a = new mpz_t("98750293847520938457029384572093480498357");
            AsString = a.ToString();
            Assert.AreEqual("98750293847520938457029384572093480498357", AsString);

            using mpz_t b = new mpz_t("23094582093845093574093845093485039450934");
            AsString = b.ToString();
            Assert.AreEqual("23094582093845093574093845093485039450934", AsString);

            using mpz_t c = new mpz_t("394580293847502987609283945873594873409587");
            AsString = c.ToString();
            Assert.AreEqual("394580293847502987609283945873594873409587", AsString);

            mpz.submul(a, b, c);
            AsString = a.ToString();
            Assert.AreEqual("-9112666988874677841199955832262586145147830205230375090322356322089362221491205901", AsString);
        }

        [TestMethod]
        public void SubProductUint()
        {
            string AsString;

            using mpz_t a = new mpz_t("98750293847520938457029384572093480498357");
            AsString = a.ToString();
            Assert.AreEqual("98750293847520938457029384572093480498357", AsString);

            using mpz_t b = new mpz_t("23094582093845093574093845093485039450934");
            AsString = b.ToString();
            Assert.AreEqual("23094582093845093574093845093485039450934", AsString);

            uint Two = 2;

            mpz.submul_ui(a, b, Two);
            AsString = a.ToString();
            Assert.AreEqual("52561129659830751308841694385123401596489", AsString);
        }
    }
}
