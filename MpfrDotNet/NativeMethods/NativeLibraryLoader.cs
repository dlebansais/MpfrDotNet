namespace Interop;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

/// <summary>
/// Loads the native GMP (MPIR on Windows) and MPFR libraries and finds their functions.
/// </summary>
internal static class NativeLibraryLoader
{
    /// <summary>
    /// Gets a value indicating whether the process runs on Windows, where the libraries are MPIR and a Windows build of MPFR.
    /// </summary>
    public static bool IsWindows { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    /// <summary>
    /// Loads a native library.
    /// </summary>
    /// <param name="windowsName">The name of the library on Windows.</param>
    /// <param name="linuxNames">The names of the library on Linux, from the most specific.</param>
    /// <returns>The handle of the loaded library.</returns>
    /// <exception cref="PlatformNotSupportedException">The process does not run on Windows, and the target framework of this assembly is older than .NET 6.</exception>
    /// <exception cref="DllNotFoundException">The library cannot be found or loaded.</exception>
    public static IntPtr Load(string windowsName, params string[] linuxNames)
    {
#if !NET6_0_OR_GREATER
        // Before .NET 6, a C long can only be declared with the size it has on Windows.
        if (!IsWindows)
            throw new PlatformNotSupportedException("Platforms other than Windows require .NET 6 or later.");
#endif

        string DirectoryName = GetAssemblyDirectory(Assembly.GetExecutingAssembly().Location);

        foreach (string Candidate in GetCandidates(IsWindows, DirectoryName, windowsName, linuxNames))
        {
            IntPtr Handle = TryLoad(Candidate);
            if (Handle != IntPtr.Zero)
                return Handle;
        }

        throw new DllNotFoundException(GetNotFoundMessage(IsWindows, windowsName, linuxNames));
    }

    /// <summary>
    /// Gets the address of a function exported by a native library.
    /// </summary>
    /// <param name="handle">The handle of the library.</param>
    /// <param name="name">The name of the function.</param>
    /// <returns>The address of the function, or <see cref="IntPtr.Zero"/> if the library does not export it.</returns>
    public static IntPtr GetExport(IntPtr handle, string name)
    {
#if NET6_0_OR_GREATER
        return NativeLibrary.TryGetExport(handle, name, out IntPtr Address) ? Address : IntPtr.Zero;
#else
        return GetProcAddress(handle, name);
#endif
    }

    /// <summary>
    /// Gets the paths to try, in order, to load a native library.
    /// </summary>
    /// <param name="isWindows"><see langword="true"/> to get the paths used on Windows, <see langword="false"/> for those used on Linux.</param>
    /// <param name="directoryName">The directory of this assembly, searched before the system search path.</param>
    /// <param name="windowsName">The name of the library on Windows.</param>
    /// <param name="linuxNames">The names of the library on Linux, from the most specific.</param>
    internal static List<string> GetCandidates(bool isWindows, string directoryName, string windowsName, string[] linuxNames)
    {
        List<string> Candidates = new();

        if (isWindows)
        {
            Candidates.Add(Path.Combine(directoryName, windowsName));
            Candidates.Add(Path.Combine(directoryName, "runtimes", "win-x64", "native", windowsName));
            Candidates.Add(windowsName);
        }
        else
        {
            Candidates.Add(Path.Combine(directoryName, linuxNames[0]));
            Candidates.AddRange(linuxNames);
        }

        return Candidates;
    }

    /// <summary>
    /// Gets the message of the exception thrown when a native library cannot be loaded.
    /// </summary>
    /// <param name="isWindows"><see langword="true"/> to get the message used on Windows, <see langword="false"/> for the one used on Linux.</param>
    /// <param name="windowsName">The name of the library on Windows.</param>
    /// <param name="linuxNames">The names of the library on Linux, from the most specific.</param>
    internal static string GetNotFoundMessage(bool isWindows, string windowsName, string[] linuxNames)
    {
        if (isWindows)
            return $"The native library '{windowsName}' cannot be found or loaded.";

        return $"The native library '{linuxNames[0]}' cannot be found or loaded. On Linux, install the GMP and MPFR libraries (for example, the libgmp10 and libmpfr6 packages).";
    }

    /// <summary>
    /// Gets the directory of an assembly from its location.
    /// </summary>
    /// <param name="location">The location of the assembly.</param>
    /// <returns>The directory of the assembly, or the base directory of the application when <paramref name="location"/> has no directory.</returns>
    internal static string GetAssemblyDirectory(string location)
    {
        // Location is empty when the assembly is loaded from memory or bundled in a single-file application.
        if (location.Length == 0)
            return AppContext.BaseDirectory;

        return Path.GetDirectoryName(location) ?? AppContext.BaseDirectory;
    }

#if NET6_0_OR_GREATER
    private static IntPtr TryLoad(string libraryPath)
        => NativeLibrary.TryLoad(libraryPath, out IntPtr Handle) ? Handle : IntPtr.Zero;
#else
    private static IntPtr TryLoad(string libraryPath)
        => LoadLibrary(libraryPath);

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern IntPtr LoadLibrary(string libraryName);

    [DllImport("kernel32", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    private static extern IntPtr GetProcAddress(IntPtr hwnd, [MarshalAs(UnmanagedType.LPStr)] string procedureName);
#endif
}
