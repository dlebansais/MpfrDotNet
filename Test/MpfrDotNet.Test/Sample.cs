namespace Test;

using System.Runtime.InteropServices;

internal static class Sample
{
    // On Windows, the native libraries are MPIR and a Windows build of MPFR, and a C long is 32-bit.
    // Elsewhere, they are the system GMP and MPFR, and a C long is 64-bit.
    public static bool IsWindows { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    public static T CreateNull<T>()
        where T : class
        => null!;
}
