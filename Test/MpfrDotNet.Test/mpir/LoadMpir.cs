namespace Test;

using System;
using Interop.Mpir;
using NUnit.Framework;

[TestFixture]
public class LoadMpir
{
    [Test]
    public void DummyLibrary()
    {
        IntPtr hLib = IntPtr.Zero;
        Assert.Throws<ArgumentException>(() => NativeMethods.LoadLibrary(string.Empty, ref hLib));
    }

    [Test]
    public void DummyPointer()
    {
        Assert.Throws<ArgumentException>(() => NativeMethods.DummyPointer());
    }
}
