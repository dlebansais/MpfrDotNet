namespace Test;

using System;
using Interop;
using Interop.Mpfr;
using NUnit.Framework;

[TestFixture]
public class LoadMpfr
{
    [Test]
    public void DummyLibrary()
    {
        const string Expected = "The native library 'missing.dll' cannot be found or loaded.";

        // On Linux, the message names the Linux library and ends with installation instructions.
        Assert.That(() => NativeLibraryLoader.Load("missing.dll", "libmissing.so"), NativeLibraryLoader.IsWindows
            ? Throws.TypeOf<DllNotFoundException>().With.Message.EqualTo(Expected)
            : Throws.TypeOf<DllNotFoundException>().With.Message.StartsWith("The native library 'libmissing.so' cannot be found or loaded."));
    }

    [Test]
    public void DummyPointer()
    {
        Assert.Throws<ArgumentException>(() => NativeMethods.DummyPointer());
    }
}
