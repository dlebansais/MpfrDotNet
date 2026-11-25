MpfrDotNet Changes to the MPIR Sources
--------------------------------------

The Windows build of MPIR has 64-bit mpir_ui, mpir_si and limbs, while long is
32-bit with MSVC. A few places in the MPIR sources kept a 64-bit value in an
unsigned long or a long, and gave wrong results, or an access violation, for
values beyond 2^31 or 2^32. They are marked with "MpfrDotNet" comments, and
must be applied again when MPIR is updated:

1. gmp-impl.h and mpn/generic/get_d.c: the exponent of mpn_get_d is an mpir_si
   instead of a long. Operands of more than 2^25 limbs were taken as an
   overflow, and the exponents of large mpf and mpq values wrapped.
2. mpf/get_d.c, mpf/get_d_2exp.c and mpq/get_d.c: the exponents they pass to
   mpn_get_d are mpir_si.
3. mpz/n_pow_ui.c: the count of trailing zero bits of the result is an mpir_ui
   (mpz_pow_ui(2, 2^32) gave 1).
4. mpz/kronsz.c: a is cast to mpir_ui when b is even, as when b is odd.
5. mpz/bin_ui.c: k is swapped through an mpir_ui.
6. mpz/bin_uiui.c: mpz_goetgheluck_bin_uiui takes mpir_ui arguments.
7. mpz/remove.c: the count for a factor of 2 is an mp_bitcnt_t.
8. mpz/gcd_ui.c: the result is compared with GMP_UI_MAX instead of ULONG_MAX.

mpz_get_d_2exp and mpf_get_d_2exp still return their exponent in a long, as
their prototypes say: MpfrDotNet computes it in C# instead.

The tests in Test/MpfrDotNet.Test/NativeLongLimits.cs check these cases.
