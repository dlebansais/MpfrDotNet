namespace TestInteger.Arithmetic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpirDotNet;

    [TestClass]
    public class Root
    {
        [TestMethod]
        public void RootExact()
        {
            string AsString;
            bool IsRootExact;

            using mpz_t a = new mpz_t("9785412309485720938412983404349");
            AsString = a.ToString();
            Assert.AreEqual("9785412309485720938412983404349", AsString);

            IsRootExact = a.IsRootExact(3);

            Assert.IsFalse(IsRootExact);

            mpz_t b = a * a * a;

            AsString = b.ToString();
            Assert.AreEqual("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549", AsString);

            IsRootExact = b.IsRootExact(3);

            Assert.IsTrue(IsRootExact);
        }

        [TestMethod]
        public void BasicRoot()
        {
            string AsString;

            using mpz_t a = new mpz_t("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549");
            AsString = a.ToString();
            Assert.AreEqual("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549", AsString);

            mpz_t b = a.NthRoot(3);

            AsString = b.ToString();
            Assert.AreEqual("9785412309485720938412983404349", AsString);
        }

        [TestMethod]
        public void RootRemainder()
        {
            string AsString;

            using mpz_t a = new mpz_t("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320559");
            AsString = a.ToString();
            Assert.AreEqual("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320559", AsString);

            mpz_t.NthRoot(a, 3, out mpz_t root, out mpz_t remainder);

            AsString = root.ToString();
            Assert.AreEqual("9785412309485720938412983404349", AsString);

            AsString = remainder.ToString();
            Assert.AreEqual("10", AsString);
        }

        [TestMethod]
        public void Sqrt()
        {
            string AsString;

            using mpz_t a = new mpz_t("95754294066634670780206802290671646680930214410991689632113801");
            AsString = a.ToString();
            Assert.AreEqual("95754294066634670780206802290671646680930214410991689632113801", AsString);

            mpz_t b = a.Sqrt();

            AsString = b.ToString();
            Assert.AreEqual("9785412309485720938412983404349", AsString);
        }

        [TestMethod]
        public void SqrtRemainder()
        {
            string AsString;

            using mpz_t a = new mpz_t("95754294066634670780206802290671646681077131756368025120369720");
            AsString = a.ToString();
            Assert.AreEqual("95754294066634670780206802290671646681077131756368025120369720", AsString);

            mpz_t.SqrtRemainder(a, out mpz_t root, out mpz_t remainder);

            AsString = root.ToString();
            Assert.AreEqual("9785412309485720938412983404349", AsString);

            AsString = remainder.ToString();
            Assert.AreEqual("146917345376335488255919", AsString);
        }

        [TestMethod]
        public void PerfectPower()
        {
            string AsString;

            using mpz_t a = new mpz_t("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549");
            AsString = a.ToString();
            Assert.AreEqual("936995247845762439229916837840025004943963737679442023171062337518037547173883302933966320549", AsString);

            bool IsPerfectPower = a.IsPerfectPower();

            Assert.IsTrue(IsPerfectPower);
        }

        [TestMethod]
        public void PerfectSquare()
        {
            string AsString;

            using mpz_t a = new mpz_t("95754294066634670780206802290671646680930214410991689632113801");
            AsString = a.ToString();
            Assert.AreEqual("95754294066634670780206802290671646680930214410991689632113801", AsString);

            bool IsPerfectSquare = a.IsPerfectSquare();

            Assert.IsTrue(IsPerfectSquare);
        }
    }
}
