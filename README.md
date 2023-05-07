# MpfrDotNet
A binding of MPFR and MPIR (Multiple Precision Floating-Point and Integer) for .NET.

[![Build status](https://ci.appveyor.com/api/projects/status/4w46tqucudnkb1u3?svg=true)](https://ci.appveyor.com/project/dlebansais/MpfrDotNet) [![codecov](https://codecov.io/gh/dlebansais/MpfrDotNet/branch/master/graph/badge.svg?token=HMNSZ9X5U2)](https://codecov.io/gh/dlebansais/MpfrDotNet)

# Instructions
+ Install Visual Studio 2022.
+ Clone this repository locally.
+ Open `MpfrDotNet.sln` with Visual Studio 2022.
+ Select the `Debug` or `Release` build in the toolbar.
+ Rebuild the solution (F5 or from the *Build* / *Rebuild Solution* menu).

Resulting files are in the `MpfrDotNet\bin\x64` subdirectory:

+ mpfr.dll, for multiple precision floating-point support.
+ mpir.dll, for multiple precision integer and rational support.
+ The MpfrDotNet assembly.

# Package

This project is also available as a package. See the right pane of the project page for links.

The package includes: 

+ In the `MpfrDotNet` namespace.
  * `mpfr` static class with bindings to almost all functions listed in [the MPFR documentation](https://www.mpfr.org/mpfr-current/mpfr.pdf).
  * `mpfr_t` an implementation of a Multiple Precision Floating-Point type.
+ In the `MpirDotNet` namespace.
  * `mpir` static class with bindings to almost all functions listed in [the MPIR documentation](http://mpir.org/mpir-3.0.0.pdf).
  * `mpz_t` an implementation of a Multiple Precision Integer type.
  * `mpq_t` an implementation of a Multiple Precision Rational type.
  * `mpf_t` an implementation of a Multiple Precision Floating-Point type. This type has less features than the more complete `mpfr_t`. 

# Credits, Copyright, License...
See the Linux-style [README](mpfr/README) and [README](mpir/README).
