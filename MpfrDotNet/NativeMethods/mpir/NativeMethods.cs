namespace Interop.Mpir;

using System;
using System.Runtime.InteropServices;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
    // On Windows the library is MPIR; elsewhere it is GMP, which lacks a few MPIR functions.
    internal static bool IsMpir => NativeLibraryLoader.IsWindows;

    internal static IntPtr GetMpirPointer(string name)
    {
        string FunctionName = $"__g{name}";
        IntPtr Result = NativeLibraryLoader.GetExport(GetMpirLibrary(), FunctionName);

        if (Result == IntPtr.Zero)
            throw new ArgumentException($"Method '{FunctionName}' not found", nameof(name));

        return Result;
    }

    internal static IntPtr GetMpirLibrary()
    {
        if (hMpirLib == IntPtr.Zero)
            hMpirLib = NativeLibraryLoader.Load("mpir.dll", "libgmp.so.10", "libgmp.so");

        return hMpirLib;
    }

    internal delegate void DymmyDelegate();
    internal static DymmyDelegate DummyPointer { get => Marshal.GetDelegateForFunctionPointer<DymmyDelegate>(GetMpirPointer(string.Empty)); }

    private static IntPtr hMpirLib;
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
