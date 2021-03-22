namespace MpirDotNet
{
    public static class gmp
    {
        #region Initialization
        public static void randinit_default(randstate_t state)
        {
            NativeMethods.mp_randinit_default(ref state.Value);
        }

        public static void randinit_mt(randstate_t state)
        {
            NativeMethods.mp_randinit_mt(ref state.Value);
        }

        public static void randinit_lc_2exp(randstate_t state, mpz_t a, uint c, ulong m2exp)
        {
            NativeMethods.mp_randinit_lc_2exp(ref state.Value, ref a.Value, c, m2exp);
        }

        public static void randinit_lc_2exp_size(randstate_t state, ulong size)
        {
            NativeMethods.mp_randinit_lc_2exp_size(ref state.Value, size);
        }

        public static void randinit_set(randstate_t rop, randstate_t op)
        {
            NativeMethods.mp_randinit_set(ref rop.Value, ref op.Value);
        }

        public static void randclear(randstate_t state)
        {
            NativeMethods.mp_randclear(ref state.Value);
        }
        #endregion

        #region Seeding
        public static void randseed(randstate_t state, mpz_t seed)
        {
            NativeMethods.mp_randseed(ref state.Value, ref seed.Value);
        }

        public static void randseed_ui(randstate_t state, uint seed)
        {
            NativeMethods.mp_randseed_ui(ref state.Value, seed);
        }
        #endregion

        #region Miscellaneous
        public static uint urandomb_ui(randstate_t state, uint m2exp)
        {
            return NativeMethods.mp_urandomb_ui(ref state.Value, m2exp);
        }

        public static uint urandomm_ui(randstate_t state, uint n)
        {
            return NativeMethods.mp_urandomm_ui(ref state.Value, n);
        }
        #endregion
    }
}
