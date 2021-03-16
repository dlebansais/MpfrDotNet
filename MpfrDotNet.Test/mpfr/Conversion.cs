namespace Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MpfrDotNet;
    using MpirDotNet;
    using System.Numerics;

    [TestClass]
    public class Conversion
    {
        [TestMethod]
        public void BasicConversion()
        {
            string AsString;

            Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

            using mpfr_t a = (byte)1;
            AsString = a.ToString();
            Assert.AreEqual("1E+0", AsString);
            Assert.AreEqual((byte)a, 1);

            using mpfr_t b = 2;
            AsString = b.ToString();
            Assert.AreEqual("2E+0", AsString);
            Assert.AreEqual((int)b, 2);

            using mpfr_t c = 3U;
            AsString = c.ToString();
            Assert.AreEqual("3E+0", AsString);
            Assert.AreEqual((uint)c, 3U);

            using mpfr_t d = 4L;
            AsString = d.ToString();
            Assert.AreEqual("4E+0", AsString);
            Assert.AreEqual((long)d, 4);

            using mpfr_t e = 5UL;
            AsString = e.ToString();
            Assert.AreEqual("5E+0", AsString);
            Assert.AreEqual((ulong)e, 5UL);

            using mpfr_t f = (short)6;
            AsString = f.ToString();
            Assert.AreEqual("6E+0", AsString);
            Assert.AreEqual((short)f, (short)6);

            using mpfr_t g = (ushort)7;
            AsString = g.ToString();
            Assert.AreEqual("7E+0", AsString);
            Assert.AreEqual((ushort)g, (ushort)7);

            using mpfr_t h = 8.5F;
            AsString = h.ToString();
            Assert.AreEqual("8.5E+0", AsString);
            Assert.AreEqual((float)h, 8.5F);

            using mpfr_t i = 16.5;
            AsString = i.ToString();
            Assert.AreEqual("1.65E+1", AsString);
            Assert.AreEqual((double)i, 16.5);

            BigInteger bj = new BigInteger(89);
            using mpfr_t j = bj;
            AsString = j.ToString();
            Assert.AreEqual("8.9E+1", AsString);
            Assert.AreEqual((BigInteger)j, bj);
        }
    }
}
