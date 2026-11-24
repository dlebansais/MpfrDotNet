namespace TestInteger;

using System;
using System.Runtime.CompilerServices;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Random
{
    [Test]
    public void UniformExp()
    {
        using randstate_t state = new();
        using mpz_t a = new();

        ulong n = 60;

        mpz.urandomb(a, state, n);

        string AsString0 = a.ToString();

        mpz.urandomb(a, state, n);

        string AsString1 = a.ToString();
        Assert.That(AsString0, Is.Not.EqualTo(AsString1));
    }

    [Test]
    public void UniformMax()
    {
        bool IsPositive;
        bool IsLesserThan;

        using randstate_t state = new();
        using mpz_t a = new();
        using mpz_t b = new("622288097498926496141095869268883999563096063592498055290460");

        mpz.urandomm(a, state, b);

        string AsString0 = a.ToString();
        IsPositive = a >= 0;
        IsLesserThan = a < b;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(IsPositive, Is.True);
        Assert.That(IsLesserThan, Is.True);

        mpz.urandomm(a, state, b);
        IsPositive = a >= 0;
        IsLesserThan = a < b;

        Assert.That(IsPositive, Is.True);
        Assert.That(IsLesserThan, Is.True);

        string AsString1 = a.ToString();
        Assert.That(AsString0, Is.Not.EqualTo(AsString1));

        ulong c = 100;
        ulong RandomNumber = gmp.urandomm_ui(state, c);
        IsLesserThan = RandomNumber < c;

        Assert.That(IsLesserThan, Is.True);

        Assert.That(AsString0, Is.Not.EqualTo(AsString1));
    }

    [Test]
    public void NonUniformExp()
    {
        using randstate_t state = new();
        using mpz_t a = new();

        ulong n = 60;

        mpz.rrandomb(a, state, n);

        string AsString0 = a.ToString();

        mpz.rrandomb(a, state, n);

        string AsString1 = a.ToString();
        Assert.That(AsString0, Is.Not.EqualTo(AsString1));
    }

    [Test]
    public void Create()
    {
        using randstate_t state0 = randstate_t.Create(RngAlgorithm.MersenneTwister);
        using randstate_t state1 = randstate_t.Create(RngAlgorithm.LinearCongruential, 10UL);

        using mpz_t a = new(10);
        using randstate_t state2 = randstate_t.Create(RngAlgorithm.LinearCongruential, a, 10UL, 10UL);
        using randstate_t state3 = new(state2);

        using randstate_t state4 = randstate_t.Create(RngAlgorithm.Default);

        Assert.Throws<ArgumentException>(() => { using (randstate_t state = randstate_t.Create(RngAlgorithm.LinearCongruential)) { }; });
        Assert.Throws<ArgumentException>(() => { using (randstate_t state = randstate_t.Create(RngAlgorithm.LinearCongruential, -10L)) { }; });
        Assert.Throws<ArgumentException>(() => { using (randstate_t state = randstate_t.Create(RngAlgorithm.LinearCongruential, -10L, -10L, -10L)) { }; });
        Assert.Throws<ArgumentException>(() => { using (randstate_t state = randstate_t.Create(RngAlgorithm.LinearCongruential, a, -10L, -10L)) { }; });
        Assert.Throws<ArgumentException>(() => { using (randstate_t state = randstate_t.Create(RngAlgorithm.LinearCongruential, a, 10UL, -10L)) { }; });
    }

    [Test]
    public void Seed()
    {
        using randstate_t state = new();
        using mpz_t a = new(10);

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
        Assert.That(IsLesserThan, Is.True);

        Result = gmp.urandomm_ui(state, n);

        IsLesserThan = Result < n;
        Assert.That(IsLesserThan, Is.True);
    }

    [Test]
    public void Finalizer()
    {
        CreateUnreachableForFinalizer();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void CreateUnreachableForFinalizer()
    {
        randstate_t Disposed = randstate_t.Create(RngAlgorithm.MersenneTwister);
        Disposed.Dispose();
        Disposed.Dispose();

        // This object is not disposed: its finalizer must release it.
        _ = randstate_t.Create(RngAlgorithm.MersenneTwister);
    }
}
