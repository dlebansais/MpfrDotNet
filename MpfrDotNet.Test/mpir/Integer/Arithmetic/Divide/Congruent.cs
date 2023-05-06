namespace TestInteger.Arithmetic.Divide;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpirDotNet;

[TestClass]
public class Congruent
{
    [TestMethod]
    public void BasicCongruent()
    {
        string AsString;
        bool IsCongruent;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305981001312");
        AsString = a.ToString();
        Assert.AreEqual("234052834524092854092874502983745029345723098457209305981001312", AsString);

        using mpz_t b = new mpz_t("2340528345240928540928745029837450293454373192");
        AsString = b.ToString();
        Assert.AreEqual("2340528345240928540928745029837450293454373192", AsString);

        using mpz_t c = new mpz_t("7879512");
        AsString = c.ToString();
        Assert.AreEqual("7879512", AsString);

        IsCongruent = a.IsCongruent(b, c);

        Assert.IsTrue(IsCongruent);

        using mpz_t d = new mpz_t("2340528345240928540928745029837450293454373193");
        AsString = d.ToString();
        Assert.AreEqual("2340528345240928540928745029837450293454373193", AsString);

        IsCongruent = d.IsCongruent(b, c);

        Assert.IsFalse(IsCongruent);
    }

    [TestMethod]
    public void UIntCongruent()
    {
        string AsString;
        bool IsCongruent;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305981001312");
        AsString = a.ToString();
        Assert.AreEqual("234052834524092854092874502983745029345723098457209305981001312", AsString);

        uint b = 7879512;
        uint c = 75;

        IsCongruent = a.IsCongruent(b, c);

        Assert.IsTrue(IsCongruent);

        using mpz_t d = new mpz_t("2340528345240928540928745029837450293454373193");
        AsString = d.ToString();
        Assert.AreEqual("2340528345240928540928745029837450293454373193", AsString);

        IsCongruent = d.IsCongruent(b, c);

        Assert.IsFalse(IsCongruent);
    }

    [TestMethod]
    public void PowerOfTwo()
    {
        string AsString;
        bool IsCongruent;

        using mpz_t a = new mpz_t("234052834524092854092874502983745029345723098457209305981001312");
        AsString = a.ToString();
        Assert.AreEqual("234052834524092854092874502983745029345723098457209305981001312", AsString);

        using mpz_t b = new mpz_t("2340528345240928540928745029837450293451169376");
        AsString = b.ToString();
        Assert.AreEqual("2340528345240928540928745029837450293451169376", AsString);

        int c = 25;
        uint p = 1U << c;
        
        using mpz_t x = a / p;
        using mpz_t y = b / p;
        using mpz_t x1 = x * p;
        using mpz_t y1 = y * p;
        using mpz_t x2 = a - x1;
        using mpz_t y2 = y1 + x2;

        IsCongruent = a.IsCongruentPowerOfTwo(b, c);

        Assert.IsTrue(IsCongruent);

        using mpz_t d = new mpz_t("2340528345240928540928745029837450293454373193");
        AsString = d.ToString();
        Assert.AreEqual("2340528345240928540928745029837450293454373193", AsString);

        IsCongruent = d.IsCongruentPowerOfTwo(b, c);

        Assert.IsFalse(IsCongruent);
    }
}
