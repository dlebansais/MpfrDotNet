namespace TestFloating;

using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Random
{
    [Test]
    public void UniformExp()
    {
        using randstate_t state = new();
        using mpf_t a = new mpf_t();

        ulong n = 60;

        mpf.urandomb(a, state, n);

        string AsString0 = a.ToString();

        mpf.urandomb(a, state, n);

        string AsString1 = a.ToString();
        Assert.That(AsString0, Is.Not.EqualTo(AsString1));
    }

    [Test]
    public void NonUniformExp()
    {
        using randstate_t state = new();
        using mpf_t a = new mpf_t();

        ulong n = 60;
        int exp = 10;

        mpf.rrandomb(a, state, n, exp);

        string AsString0 = a.ToString();

        mpf.rrandomb(a, state, n, exp);

        string AsString1 = a.ToString();
        Assert.That(AsString0, Is.Not.EqualTo(AsString1));
    }
}
