namespace Test;

using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Random
{
    [Test]
    public void Uniform()
    {
        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using randstate_t state = new randstate_t();

        using mpfr_t Zero = new(0);
        using mpfr_t One = new(1);

        using mpfr_t x = mpfr_t.UniformRandom(state);

        Assert.That(x >= Zero, Is.True);
        Assert.That(x <= One, Is.True);

        using mpfr_t y = mpfr_t.UniformRandom(state, mpfr_rnd_t.MPFR_RNDZ);

        Assert.That(y >= Zero, Is.True);
        Assert.That(y <= One, Is.True);
    }

    [Test]
    public void Gaussian()
    {
        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using randstate_t state = new randstate_t();

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
        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        using randstate_t state = new randstate_t();

        using mpfr_t x = mpfr_t.ExponentialRandom(state);

        Assert.That(x.IsNan, Is.False);
    }
}
