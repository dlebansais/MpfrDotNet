namespace TestFloating;

using System;
using System.Runtime.InteropServices;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Random
{
    [Test]
    public void UniformExp()
    {
        using randstate_t state = new();
        using mpf_t a = new();

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
        using mpf_t a = new();

        ulong n = 60;
        int exp = 10;

        // mpf_rrandomb exists in MPIR, used on Windows, but not in GMP.
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Assert.That(() => mpf.rrandomb(a, state, n, exp), Throws.TypeOf<PlatformNotSupportedException>().With.Message.EqualTo("mpf_rrandomb is only available with MPIR, on Windows."));
            return;
        }

        mpf.rrandomb(a, state, n, exp);

        string AsString0 = a.ToString();

        mpf.rrandomb(a, state, n, exp);

        string AsString1 = a.ToString();
        Assert.That(AsString0, Is.Not.EqualTo(AsString1));
    }
}
