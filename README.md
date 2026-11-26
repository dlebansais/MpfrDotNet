# MpfrDotNet

A binding of MPFR and MPIR (Multiple Precision Floating-Point and Integer) for .NET.

This binding is up to date with version 4.2.1 of the [mpfr library](https://www.mpfr.org/mpfr-current/mpfr.html).

[![Build status](https://ci.appveyor.com/api/projects/status/4w46tqucudnkb1u3?svg=true)](https://ci.appveyor.com/project/dlebansais/MpfrDotNet)
[![codecov](https://codecov.io/gh/dlebansais/MpfrDotNet/branch/master/graph/badge.svg?token=HMNSZ9X5U2)](https://codecov.io/gh/dlebansais/MpfrDotNet)
[![NuGet](https://img.shields.io/nuget/v/dlebansais.MpfrDotNet.svg)](https://www.nuget.org/packages/dlebansais.MpfrDotNet)

# Instructions

+ Install Visual Studio 2026.
+ Clone this repository locally.
+ Open `MpfrDotNet.slnx` with Visual Studio 2026.
+ Select the `Debug` or `Release` build in the toolbar.
+ Rebuild the solution (F5 or from the *Build* / *Rebuild Solution* menu).

Resulting files are in the `MpfrDotNet\bin\x64` subdirectory:

+ mpfr.dll, for multiple precision floating-point support.
+ mpir.dll, for multiple precision integer and rational support.
+ The MpfrDotNet assembly.

# Package

This project is also available as a package. See the nuget badge at the top for a link. The package supports:
+ Windows and Linux.
+ The x64 platform only.

The package includes: 

+ In the `MpfrDotNet` namespace.
  * `mpfr` static class with bindings to almost all functions listed in [the MPFR documentation](https://www.mpfr.org/mpfr-current/mpfr.pdf).
  * `mpfr_t` an implementation of a Multiple Precision Floating-Point type.
+ In the `MpirDotNet` namespace.
  * `mpq`, `mpz`, `mpf` and `gmp`: static classes with bindings to almost all functions listed in [the MPIR documentation](http://mpir.org/mpir-3.0.0.pdf).
  * `mpz_t` an implementation of a Multiple Precision Integer type.
  * `mpq_t` an implementation of a Multiple Precision Rational type.
  * `mpf_t` an implementation of a Multiple Precision Floating-Point type. This type has less features than the more complete `mpfr_t`. 

On Linux, the package requires .NET 10, GMP and MPFR libraries must be installed separately (for example with `sudo apt install libgmp10 libmpfr6`), the integer types use GMP instead of MPIR, and `mpf.rrandomb` is not available.

# Credits, Copyright, License...

See the Linux-style [README](mpfr/README) and [README](mpir/README).
