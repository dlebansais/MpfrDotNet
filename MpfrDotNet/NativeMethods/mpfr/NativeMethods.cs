namespace MpfrDotNet.mpfr
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        [DllImport("kernel32")]
        private extern static IntPtr LoadLibrary(string libraryName);

        [DllImport("kernel32", CharSet = CharSet.Ansi)]
        private extern static IntPtr GetProcAddress(IntPtr hwnd, string procedureName);

        private static IntPtr GetMpfrPointer(string name)
        {
            if (hMpfrLib == IntPtr.Zero)
            {
                Assembly Current = Assembly.GetExecutingAssembly();
                string Location = Current.Location;
                string LibraryLocation = Path.Combine(Path.GetDirectoryName(Location), "mpfr.dll");
                hMpfrLib = LoadLibrary(LibraryLocation);

                if (hMpfrLib == IntPtr.Zero)
                    throw new ArgumentException($"File {LibraryLocation} not found or not loaded");

                InitializePrecision();
            }

            string FunctionName = $"{name}";
            IntPtr Result = GetProcAddress(hMpfrLib, FunctionName);

            if (Result == IntPtr.Zero)
                throw new ArgumentException($"Method {FunctionName} not found", nameof(name));

            return Result;
        }

        private static IntPtr hMpfrLib = IntPtr.Zero;
    }
}
