# MpfrDotNet

A binding of MPFR and MPIR (Multiple Precision Floating-Point and Integer) for .NET.

This binding is up to date with version 4.2.1 of the [mpfr library](https://www.mpfr.org/mpfr-current/mpfr.html).

The package supports:
+ Windows and Linux.
+ The x64 platform only.

On Linux, the package requires .NET 10, and the GMP and MPFR libraries, installed separately (for example with `sudo apt install libgmp10 libmpfr6`). The integer types use GMP instead of MPIR, and `mpf.rrandomb` is not available.
