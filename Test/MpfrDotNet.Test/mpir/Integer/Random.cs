namespace TestInteger;

using MpirDotNet;
using System.IO;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class Random
{
    [Test]
    public void UniformExp()
    {
        using randstate_t state = new();
        using mpz_t a = new mpz_t();

        ulong n = 60;

        mpz.urandomb(a, state, n);

        string AsString0 = a.ToString();

        mpz.urandomb(a, state, n);

        string AsString1 = a.ToString();
        Assert.AreNotEqual(AsString0, AsString1);
    }

    [Test]
    public void UniformMax()
    {
        bool IsPositive;
        bool IsLesserThan;

        using randstate_t state = new();
        using mpz_t a = new mpz_t();
        using mpz_t b = new mpz_t("622288097498926496141095869268883999563096063592498055290460");

        mpz.urandomm(a, state, b);

        string AsString0 = a.ToString();
        IsPositive = a >= 0;
        IsLesserThan = a < b;

        Assert.IsTrue(IsPositive);
        Assert.IsTrue(IsLesserThan);

        mpz.urandomm(a, state, b);
        IsPositive = a >= 0;
        IsLesserThan = a < b;

        Assert.IsTrue(IsPositive);
        Assert.IsTrue(IsLesserThan);

        string AsString1 = a.ToString();
        Assert.AreNotEqual(AsString0, AsString1);

        ulong c = 100;
        ulong RandomNumber = gmp.urandomm_ui(state, c);
        IsLesserThan = RandomNumber < c;

        Assert.IsTrue(IsLesserThan);

        Assert.AreNotEqual(AsString0, AsString1);
    }

    [Test]
    public void NonUniformExp()
    {
        using randstate_t state = new();
        using mpz_t a = new mpz_t();

        ulong n = 60;

        mpz.rrandomb(a, state, n);

        string AsString0 = a.ToString();

        mpz.rrandomb(a, state, n);

        string AsString1 = a.ToString();
        Assert.AreNotEqual(AsString0, AsString1);
    }

    [Test]
    public void Create()
    {
        using randstate_t state0 = randstate_t.Create(RngAlgorithm.MersenneTwister);
        using randstate_t state1 = randstate_t.Create(RngAlgorithm.LinearCongruential, 10UL);

        using mpz_t a = new mpz_t(10);
        using randstate_t state2 = randstate_t.Create(RngAlgorithm.LinearCongruential, a, 10UL, 10UL);
        using randstate_t state3 = new randstate_t(state2);
    }

    [Test]
    public void Seed()
    {
        using randstate_t state = new();
        using mpz_t a = new mpz_t(10);

        gmp.randseed(state, a);
        gmp.randseed_ui(state, 10);
    }

    [Test]
    public void Misc()
    {
        ulong Result;
        bool IsLesserThan;

        using randstate_t state = new();
        ulong n = 10;

        Result = gmp.urandomb_ui(state, n);

        IsLesserThan = Result < (1UL << (int)n);
        Assert.IsTrue(IsLesserThan);

        Result = gmp.urandomm_ui(state, n);

        IsLesserThan = Result < n;
        Assert.IsTrue(IsLesserThan);
    }
}
