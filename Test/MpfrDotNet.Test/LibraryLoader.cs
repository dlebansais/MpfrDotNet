namespace Test;

using System;
using System.Collections.Generic;
using System.IO;
using Interop;
using NUnit.Framework;

[TestFixture]
internal class LibraryLoader
{
    [Test]
    public void TestWindowsCandidates()
    {
        const string DirectoryName = "folder";
        const string WindowsName = "mpfr.dll";

        List<string> Candidates = NativeLibraryLoader.GetCandidates(isWindows: true, DirectoryName, WindowsName, ["libmpfr.so.6", "libmpfr.so"]);

        Assert.That(Candidates, Is.EqualTo(new List<string>
        {
            Path.Combine(DirectoryName, WindowsName),
            Path.Combine(DirectoryName, "runtimes", "win-x64", "native", WindowsName),
            WindowsName,
        }));
    }

    [Test]
    public void TestLinuxCandidates()
    {
        const string DirectoryName = "folder";
        const string SpecificName = "libmpfr.so.6";
        const string GenericName = "libmpfr.so";

        List<string> Candidates = NativeLibraryLoader.GetCandidates(isWindows: false, DirectoryName, "mpfr.dll", [SpecificName, GenericName]);

        Assert.That(Candidates, Is.EqualTo(new List<string>
        {
            Path.Combine(DirectoryName, SpecificName),
            SpecificName,
            GenericName,
        }));
    }

    [Test]
    public void TestNotFoundMessages()
    {
        string[] LinuxNames = ["libmpfr.so.6", "libmpfr.so"];

        string WindowsMessage = NativeLibraryLoader.GetNotFoundMessage(isWindows: true, "mpfr.dll", LinuxNames);
        string LinuxMessage = NativeLibraryLoader.GetNotFoundMessage(isWindows: false, "mpfr.dll", LinuxNames);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(WindowsMessage, Is.EqualTo("The native library 'mpfr.dll' cannot be found or loaded."));
        Assert.That(LinuxMessage, Is.EqualTo("The native library 'libmpfr.so.6' cannot be found or loaded. On Linux, install the GMP and MPFR libraries (for example, the libgmp10 and libmpfr6 packages)."));
    }

    [Test]
    public void TestAssemblyDirectory()
    {
        string Directory = Path.Combine(AppContext.BaseDirectory, "folder");
        string Location = Path.Combine(Directory, "MpfrDotNet.dll");

        // A root directory has no parent: Path.GetDirectoryName returns null.
        string Root = Path.GetPathRoot(AppContext.BaseDirectory) ?? string.Empty;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(NativeLibraryLoader.GetAssemblyDirectory(Location), Is.EqualTo(Directory));
        Assert.That(NativeLibraryLoader.GetAssemblyDirectory(string.Empty), Is.EqualTo(AppContext.BaseDirectory));
        Assert.That(NativeLibraryLoader.GetAssemblyDirectory(Root), Is.EqualTo(AppContext.BaseDirectory));
    }
}
