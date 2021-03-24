namespace MpfrDotNet
{
    using System;
    using MpirDotNet;
    using static Interop.Mpfr.NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        #region Add
        public static mpfr_t operator +(mpfr_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_add(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator +(mpfr_t x, ulong y)
        {
            mpfr_t z = new();

            mpfr_add_ui(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator +(ulong x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_add_ui(ref z.Value, ref y.Value, x, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator +(mpfr_t x, long y)
        {
            mpfr_t z = new();

            mpfr_add_si(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator +(long x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_add_si(ref z.Value, ref y.Value, x, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator +(mpfr_t x, double y)
        {
            mpfr_t z = new();

            mpfr_add_d(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator +(double x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_add_d(ref z.Value, ref y.Value, x, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator +(mpfr_t x, mpz_t y)
        {
            mpfr_t z = new();

            mpfr_add_z(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator +(mpz_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_add_z(ref z.Value, ref y.Value, ref x.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator +(mpfr_t x, mpq_t y)
        {
            mpfr_t z = new();

            mpfr_add_q(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator +(mpq_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_add_q(ref z.Value, ref y.Value, ref x.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }
        #endregion

        #region Sub
        public static mpfr_t operator -(mpfr_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_sub(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator -(mpfr_t x, ulong y)
        {
            mpfr_t z = new();

            mpfr_sub_ui(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator -(ulong x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_ui_sub(ref z.Value, x, ref y.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator -(mpfr_t x, long y)
        {
            mpfr_t z = new();

            mpfr_sub_si(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator -(long x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_si_sub(ref z.Value, x, ref y.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator -(mpfr_t x, double y)
        {
            mpfr_t z = new();

            mpfr_sub_d(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator -(double x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_d_sub(ref z.Value, x, ref y.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator -(mpfr_t x, mpz_t y)
        {
            mpfr_t z = new();

            mpfr_sub_z(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator -(mpz_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_z_sub(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator -(mpfr_t x, mpq_t y)
        {
            mpfr_t z = new();

            mpfr_sub_q(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator -(mpq_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_sub_q(ref z.Value, ref y.Value, ref x.Value, (__mpfr_rnd_t)y.Rounding);
            mpfr_neg(ref z.Value, ref z.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }
        #endregion

        #region Mul
        public static mpfr_t operator *(mpfr_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_mul(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator *(mpfr_t x, ulong y)
        {
            mpfr_t z = new();

            mpfr_mul_ui(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator *(ulong x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_mul_ui(ref z.Value, ref y.Value, x, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator *(mpfr_t x, long y)
        {
            mpfr_t z = new();

            mpfr_mul_si(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator *(long x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_mul_si(ref z.Value, ref y.Value, x, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator *(mpfr_t x, double y)
        {
            mpfr_t z = new();

            mpfr_mul_d(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator *(double x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_mul_d(ref z.Value, ref y.Value, x, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator *(mpfr_t x, mpz_t y)
        {
            mpfr_t z = new();

            mpfr_mul_z(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator *(mpz_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_mul_z(ref z.Value, ref y.Value, ref x.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator *(mpfr_t x, mpq_t y)
        {
            mpfr_t z = new();

            mpfr_mul_q(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator *(mpq_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_mul_q(ref z.Value, ref y.Value, ref x.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }
        #endregion

        #region Div
        public static mpfr_t operator /(mpfr_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_div(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator /(mpfr_t x, ulong y)
        {
            mpfr_t z = new();

            mpfr_div_ui(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator /(ulong x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_ui_div(ref z.Value, x, ref y.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator /(mpfr_t x, long y)
        {
            mpfr_t z = new();

            mpfr_div_si(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator /(long x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_si_div(ref z.Value, x, ref y.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator /(mpfr_t x, double y)
        {
            mpfr_t z = new();

            mpfr_div_d(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator /(double x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_d_div(ref z.Value, x, ref y.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator /(mpfr_t x, mpz_t y)
        {
            mpfr_t z = new();

            mpfr_div_z(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator /(mpz_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_div_z(ref z.Value, ref y.Value, ref x.Value, (__mpfr_rnd_t)y.Rounding);
            mpfr_ui_div(ref z.Value, 1, ref z.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }

        public static mpfr_t operator /(mpfr_t x, mpq_t y)
        {
            mpfr_t z = new();

            mpfr_div_q(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        public static mpfr_t operator /(mpq_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_div_q(ref z.Value, ref y.Value, ref x.Value, (__mpfr_rnd_t)y.Rounding);
            mpfr_ui_div(ref z.Value, 1, ref z.Value, (__mpfr_rnd_t)y.Rounding);

            return z;
        }
        #endregion

        #region Misc
        public static mpfr_t operator -(mpfr_t x)
        {
            mpfr_t z = new();

            mpfr_neg(ref z.Value, ref x.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }
        #endregion

        #region Comparison
        public static bool operator >(mpfr_t x, mpfr_t y)
        {
            return mpfr_greater_p(ref x.Value, ref y.Value) != 0;
        }

        public static bool operator >(mpfr_t x, ulong y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(ulong x, mpfr_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpfr_t x, long y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(long x, mpfr_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpfr_t x, double y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(double x, mpfr_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpfr_t x, mpz_t y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(mpz_t x, mpfr_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpfr_t x, mpq_t y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(mpq_t x, mpfr_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpfr_t x, mpf_t y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(mpf_t x, mpfr_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >=(mpfr_t x, mpfr_t y)
        {
            return mpfr_greaterequal_p(ref x.Value, ref y.Value) != 0;
        }

        public static bool operator >=(mpfr_t x, ulong y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(ulong x, mpfr_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpfr_t x, long y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(long x, mpfr_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpfr_t x, double y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(double x, mpfr_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpfr_t x, mpz_t y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(mpz_t x, mpfr_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpfr_t x, mpq_t y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(mpq_t x, mpfr_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpfr_t x, mpf_t y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(mpf_t x, mpfr_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator <(mpfr_t x, mpfr_t y)
        {
            return mpfr_less_p(ref x.Value, ref y.Value) != 0;
        }

        public static bool operator <(mpfr_t x, ulong y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(ulong x, mpfr_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpfr_t x, long y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(long x, mpfr_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpfr_t x, double y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(double x, mpfr_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpfr_t x, mpz_t y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(mpz_t x, mpfr_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpfr_t x, mpq_t y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(mpq_t x, mpfr_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpfr_t x, mpf_t y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(mpf_t x, mpfr_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <=(mpfr_t x, mpfr_t y)
        {
            return mpfr_lessequal_p(ref x.Value, ref y.Value) != 0;
        }

        public static bool operator <=(mpfr_t x, ulong y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(ulong x, mpfr_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpfr_t x, long y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(long x, mpfr_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpfr_t x, double y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(double x, mpfr_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpfr_t x, mpz_t y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(mpz_t x, mpfr_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpfr_t x, mpq_t y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(mpq_t x, mpfr_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpfr_t x, mpf_t y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(mpf_t x, mpfr_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator ==(mpfr_t x, mpfr_t y)
        {
            return mpfr_equal_p(ref x.Value, ref y.Value) != 0;
        }

        public static bool operator ==(mpfr_t x, ulong y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(ulong x, mpfr_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpfr_t x, long y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(long x, mpfr_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpfr_t x, double y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(double x, mpfr_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpfr_t x, mpz_t y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(mpz_t x, mpfr_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpfr_t x, mpq_t y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(mpq_t x, mpfr_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpfr_t x, mpf_t y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(mpf_t x, mpfr_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator !=(mpfr_t x, mpfr_t y)
        {
            return mpfr_equal_p(ref x.Value, ref y.Value) == 0;
        }

        public static bool operator !=(mpfr_t x, ulong y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(ulong x, mpfr_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpfr_t x, long y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(long x, mpfr_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpfr_t x, double y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(double x, mpfr_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpfr_t x, mpz_t y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(mpz_t x, mpfr_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpfr_t x, mpq_t y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(mpq_t x, mpfr_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpfr_t x, mpf_t y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(mpf_t x, mpfr_t y)
        {
            return y.CompareTo(x) != 0;
        }
        #endregion
    }
}
