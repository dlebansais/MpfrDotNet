namespace Test;

using System;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Random
{
    [Test]
    public void Uniform()
    {
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        using randstate_t state = new();

        using mpfr_t Zero = new(0);
        using mpfr_t One = new(1);

        using mpfr_t x = mpfr_t.UniformRandom(state);

        Assert.That(x, Is.GreaterThanOrEqualTo(Zero));
        Assert.That(x, Is.LessThanOrEqualTo(One));

        using mpfr_t y = mpfr_t.UniformRandom(state, mpfr_rnd_t.MPFR_RNDZ);

        Assert.That(y, Is.GreaterThanOrEqualTo(Zero));
        Assert.That(y, Is.LessThanOrEqualTo(One));
    }

    [Test]
    public void Gaussian()
    {
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        using randstate_t state = new();

        using mpfr_t x = mpfr_t.GaussianRandom(state);

        Assert.That(x.IsNan, Is.False);

        mpfr_t.GaussianRandom(state, out mpfr_t y, out mpfr_t z);

        Assert.That(y.IsNan, Is.False);
        Assert.That(z.IsNan, Is.False);

        y.Dispose();
        z.Dispose();
    }

    [Test]
    public void Exponential()
    {
        Assert.That(mpfr_t.LiveObjectCount(), Is.Zero);

        using randstate_t state = new();

        using mpfr_t x = mpfr_t.ExponentialRandom(state);

        Assert.That(x.IsNan, Is.False);
    }
}
