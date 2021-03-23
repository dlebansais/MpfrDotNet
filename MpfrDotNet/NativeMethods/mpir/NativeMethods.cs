namespace Interop.Mpir
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        [DllImport("kernel32")]
        private static extern IntPtr LoadLibrary(string libraryName);

        [DllImport("kernel32", CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(IntPtr hwnd, string procedureName);

        private static IntPtr GetMpirPointer(string name)
        {
            if (hMpirLib == IntPtr.Zero)
            {
                Assembly Current = Assembly.GetExecutingAssembly();
                string Location = Current.Location;
                string DirectoryName = Path.GetDirectoryName(Location)!;
                string LibraryLocation = Path.Combine(DirectoryName, "mpir.dll");
                hMpirLib = LoadLibrary(LibraryLocation);

                if (hMpirLib == IntPtr.Zero)
                    throw new ArgumentException($"File {LibraryLocation} not found or not loaded");
            }

            string FunctionName = $"__g{name}";
            IntPtr Result = GetProcAddress(hMpirLib, FunctionName);

            if (Result == IntPtr.Zero)
                throw new ArgumentException($"Method {FunctionName} not found", nameof(name));

            return Result;
        }

        private static IntPtr hMpirLib = IntPtr.Zero;
    }
}
