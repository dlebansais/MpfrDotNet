namespace MpfrDotNet
{
    public enum mpfr_rnd_t
    {
        MPFR_RNDN=0,  /* round to nearest, with ties to even */
        MPFR_RNDZ,    /* round toward zero */
        MPFR_RNDU,    /* round toward +Inf */
        MPFR_RNDD,    /* round toward -Inf */
        MPFR_RNDA,    /* round away from zero */
        MPFR_RNDF,    /* faithful rounding */
        MPFR_RNDNA=-1 /* round to nearest, with ties away from zero (mpfr_round) */
    }
}
