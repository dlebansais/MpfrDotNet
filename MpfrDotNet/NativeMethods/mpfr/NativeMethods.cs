namespace Interop.Mpfr;

using System;
using System.Runtime.InteropServices;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
    internal static IntPtr GetMpfrPointer(string name)
    {
        IntPtr Result = NativeLibraryLoader.GetExport(GetMpfrLibrary(), name);

        if (Result == IntPtr.Zero)
            throw new ArgumentException($"Method '{name}' not found", nameof(name));

        return Result;
    }

    internal static IntPtr GetMpfrLibrary()
    {
        if (hMpfrLib == IntPtr.Zero)
        {
            // MPFR depends on GMP (MPIR on Windows), which is loaded first so that the system finds it.
            _ = Interop.Mpir.NativeMethods.GetMpirLibrary();

            hMpfrLib = NativeLibraryLoader.Load("mpfr.dll", "libmpfr.so.6", "libmpfr.so");
            InitializePrecision();
        }

        return hMpfrLib;
    }

    internal delegate void DymmyDelegate();
    internal static DymmyDelegate DummyPointer { get => Marshal.GetDelegateForFunctionPointer<DymmyDelegate>(GetMpfrPointer(string.Empty)); }

    private static IntPtr hMpfrLib;
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
