namespace Interop.Mpfr;

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
#if NET7_0_OR_GREATER
    [LibraryImport("kernel32", EntryPoint = "LoadLibraryW", StringMarshalling = StringMarshalling.Utf16)]
    private static partial IntPtr LoadLibrary(string libraryName);
#else
    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern IntPtr LoadLibrary(string libraryName);
#endif

    [DllImport("kernel32", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    private static extern IntPtr GetProcAddress(IntPtr hwnd, [MarshalAs(UnmanagedType.LPStr)] string procedureName);

    internal static IntPtr GetMpfrPointer(string name)
    {
        LoadLibrary("mpir.dll", ref hMpirLib);

        if (LoadLibrary("mpfr.dll", ref hMpfrLib))
            InitializePrecision();

        IntPtr Result = GetProcAddress(hMpfrLib, name);

        if (Result == IntPtr.Zero)
            throw new ArgumentException($"Method '{name}' not found", nameof(name));

        return Result;
    }

    internal static bool LoadLibrary(string libraryName, ref IntPtr hLib)
    {
        if (hLib == IntPtr.Zero)
        {
            Assembly Current = Assembly.GetExecutingAssembly();
            string Location = Current.Location;
            string DirectoryName = Path.GetDirectoryName(Location)!;
            string LibraryLocation = Path.Combine(DirectoryName, libraryName);

            hLib = LoadLibrary(LibraryLocation);

            if (hLib == IntPtr.Zero)
                hLib = LoadLibrary(Path.Combine(DirectoryName, @"runtimes\win-x64\native", libraryName));

            if (hLib == IntPtr.Zero)
                hLib = LoadLibrary(libraryName);

            if (hLib == IntPtr.Zero)
                throw new ArgumentException($"File {LibraryLocation} not found or not loaded");

            return true;
        }

        return false;
    }

    internal delegate void DymmyDelegate();
    internal static DymmyDelegate DummyPointer { get => Marshal.GetDelegateForFunctionPointer<DymmyDelegate>(GetMpfrPointer(string.Empty)); }

    private static IntPtr hMpirLib = IntPtr.Zero;
    private static IntPtr hMpfrLib = IntPtr.Zero;
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented

