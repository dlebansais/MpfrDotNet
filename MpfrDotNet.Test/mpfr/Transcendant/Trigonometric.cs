namespace Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpfrDotNet;

    [TestClass]
    public class Trigonometric
    {
        [TestMethod]
        public void Cos()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Cos();
            AsString = b.ToString();
            Assert.AreEqual("-9.0794725011778798506867360629257746040821075439453125E-1", AsString);

            using mpfr_t c = b.Acos();

            AsString = c.ToString();
            Assert.AreEqual("2.70915592260758675280385432415641844272613525390625E+0", AsString);
        }

        [TestMethod]
        public void Sin()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Sin();
            AsString = b.ToString();
            Assert.AreEqual("-4.1908446762382756123344051957246847450733184814453125E-1", AsString);

            using mpfr_t c = b.Asin();

            AsString = c.ToString();
            Assert.AreEqual("-4.3243673098220669626101653193472884595394134521484375E-1", AsString);
        }

        [TestMethod]
        public void Tan()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Tan();
            AsString = b.ToString();
            Assert.AreEqual("4.6157358543622412083706763041845988482236862182617188E-1", AsString);

            using mpfr_t c = b.Atan();

            AsString = c.ToString();
            Assert.AreEqual("4.3243673098220669626101653193472884595394134521484375E-1", AsString);
        }

        [TestMethod]
        public void SinCos()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            mpfr_t.SinCos(a, out mpfr_t sin, out mpfr_t cos);

            using mpfr_t b = cos;
            AsString = b.ToString();
            Assert.AreEqual("-9.0794725011778798506867360629257746040821075439453125E-1", AsString);

            using mpfr_t c = sin;
            AsString = c.ToString();
            Assert.AreEqual("-4.1908446762382756123344051957246847450733184814453125E-1", AsString);
        }

        [TestMethod]
        public void Sec()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Sec();
            AsString = b.ToString();
            Assert.AreEqual("-1.1013855704395492107749987553688697516918182373046875E+0", AsString);
        }

        [TestMethod]
        public void Csc()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Csc();
            AsString = b.ToString();
            Assert.AreEqual("-2.38615381207018462106361766927875578403472900390625E+0", AsString);
        }

        [TestMethod]
        public void Cot()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Cot();
            AsString = b.ToString();
            Assert.AreEqual("2.166501792027201389601032133214175701141357421875E+0", AsString);
        }

        [TestMethod]
        public void Atan2()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("2.225098325034502799228928E+25", AsString);

            using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
            AsString = b.ToString();
            Assert.AreEqual("2.22987435987982725E+15", AsString);

            using mpfr_t c = mpfr_t.Atan2(a, b);

            AsString = c.ToString();
            Assert.AreEqual("1.570796326694682054636587054119445383548736572265625E+0", AsString);
        }

        [TestMethod]
        public void Cosh()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Cosh();
            AsString = b.ToString();
            Assert.AreEqual("1.78440172527930513979299576021730899810791015625E+1", AsString);

            using mpfr_t c = b.Acosh();

            AsString = c.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);
        }

        [TestMethod]
        public void Sinh()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Sinh();
            AsString = b.ToString();
            Assert.AreEqual("1.7815974621613491990501643158495426177978515625E+1", AsString);

            using mpfr_t c = b.Asinh();

            AsString = c.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);
        }

        [TestMethod]
        public void Tanh()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Tanh();
            AsString = b.ToString();
            Assert.AreEqual("9.9842845751703312995317673994577489793300628662109375E-1", AsString);

            using mpfr_t c = b.Atanh();

            AsString = c.ToString();
            Assert.AreEqual("3.574029384571989709229455911554396152496337890625E+0", AsString);
        }

        [TestMethod]
        public void SinhCosh()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            mpfr_t.SinhCosh(a, out mpfr_t sinh, out mpfr_t cosh);

            using mpfr_t b = cosh;
            AsString = b.ToString();
            Assert.AreEqual("1.78440172527930513979299576021730899810791015625E+1", AsString);

            using mpfr_t c = sinh;
            AsString = c.ToString();
            Assert.AreEqual("1.7815974621613491990501643158495426177978515625E+1", AsString);
        }

        [TestMethod]
        public void Sech()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Sech();
            AsString = b.ToString();
            Assert.AreEqual("5.6041192172882149657997530312059097923338413238525391E-2", AsString);
        }

        [TestMethod]
        public void Csch()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Csch();
            AsString = b.ToString();
            Assert.AreEqual("5.6129401912531212692769599925668444484472274780273438E-2", AsString);
        }

        [TestMethod]
        public void Coth()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = new mpfr_t("3.5740293845720");
            AsString = a.ToString();
            Assert.AreEqual("3.574029384571999923281282462994568049907684326171875E+0", AsString);

            using mpfr_t b = a.Coth();
            AsString = b.ToString();
            Assert.AreEqual("1.001574016116162368916775449179112911224365234375E+0", AsString);
        }

        [TestMethod]
        public void ConstLog2()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = mpfr_t.Log2();
            AsString = a.ToString();
            Assert.AreEqual("6.9314718055994528622676398299518041312694549560546875E-1", AsString);

            using mpfr_t b = mpfr_t.Log2(mpfr_t.DefaultPrecision + 64);
            AsString = b.ToString();
            Assert.AreEqual("6.93147180559945309417232121458176569065108532699728376733410947687121425315852352166956507062423042953014373779296875E-1", AsString);
        }

        [TestMethod]
        public void ConstPi()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = mpfr_t.Pi();
            AsString = a.ToString();
            Assert.AreEqual("3.141592653589793115997963468544185161590576171875E+0", AsString);

            using mpfr_t b = mpfr_t.Pi(mpfr_t.DefaultPrecision + 64);
            AsString = b.ToString();
            Assert.AreEqual("3.14159265358979323846264338327950289377556531749908822580340146112066264556805794683214116957969963550567626953125E+0", AsString);
        }

        [TestMethod]
        public void ConstEuler()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = mpfr_t.Euler();
            AsString = a.ToString();
            Assert.AreEqual("5.7721566490153286554942724251304753124713897705078125E-1", AsString);

            using mpfr_t b = mpfr_t.Euler(mpfr_t.DefaultPrecision + 64);
            AsString = b.ToString();
            Assert.AreEqual("5.77215664901532860606512090082402428530621434441228847789596873230597389695280263754995075942133553326129913330078125E-1", AsString);
        }

        [TestMethod]
        public void ConstCatalan()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = mpfr_t.Catalan();
            AsString = a.ToString();
            Assert.AreEqual("9.1596559417721901130704509341740049421787261962890625E-1", AsString);

            using mpfr_t b = mpfr_t.Catalan(mpfr_t.DefaultPrecision + 64);
            AsString = b.ToString();
            Assert.AreEqual("9.1596559417721901505460351493238411019155914571203689209019668714241590068599052631981294325669296085834503173828125E-1", AsString);
        }
    }
}
