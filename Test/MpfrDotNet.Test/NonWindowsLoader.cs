#if NETFRAMEWORK
namespace Test;

using System;
using System.Reflection;

internal class NonWindowsLoader : MarshalByRefObject
{
    public string LoadAsNonWindows()
    {
        // Runs in its own application domain, before Load is compiled: the JIT treats a static readonly field
        // of an initialized class as a constant, so the field must be changed before Load is first called.
        FieldInfo? IsWindowsField = typeof(Interop.NativeLibraryLoader).GetField("<IsWindows>k__BackingField", BindingFlags.Static | BindingFlags.NonPublic);
        if (IsWindowsField is null)
            return "The field behind IsWindows was not found.";

        IsWindowsField.SetValue(null, false);

        try
        {
            _ = Interop.NativeLibraryLoader.Load("mpfr.dll", "libmpfr.so.6");
            return "No exception was thrown.";
        }
        catch (PlatformNotSupportedException args)
        {
            return args.Message;
        }
    }
}
#endif
