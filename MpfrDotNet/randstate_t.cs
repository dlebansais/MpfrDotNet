namespace MpirDotNet
{
    using System;
    using static NativeMethods;

    public class randstate_t : IDisposable
    {
        #region Init
        public static randstate_t Create(RngAlgorithm algorithm = RngAlgorithm.Default, params object[] parameters)
        {
            return new randstate_t(algorithm, parameters);
        }

        public randstate_t()
        {
            mp_randinit_default(ref Value);
        }

        public randstate_t(randstate_t other)
        {
            mp_randinit_set(ref Value, ref other.Value);
        }

        private randstate_t(RngAlgorithm algorithm, object[] parameters)
        {
            switch (algorithm)
            {
                default:
                case RngAlgorithm.Default:
                    mp_randinit_default(ref Value);
                    break;

                case RngAlgorithm.MersenneTwister:
                    mp_randinit_mt(ref Value);
                    break;

                case RngAlgorithm.LinearCongruential:
                    if (parameters.Length == 3 && parameters[0] is mpz_t a && parameters[1] is uint c && parameters[2] is ulong m2exp)
                        mp_randinit_lc_2exp(ref Value, ref a.Value, c, (mp_bitcnt_t)m2exp);
                    else if (parameters.Length == 1 && parameters[0] is ulong size)
                        mp_randinit_lc_2exp_size(ref Value, (mp_bitcnt_t)size);
                    else
                        throw new ArgumentException();
                    break;
            }
        }

        internal __gmp_randstate_t Value;
        #endregion

        #region Implementation of IDisposable
        /// <summary>
        /// Called when an object should release its resources.
        /// </summary>
        /// <param name="isDisposing">Indicates if resources must be disposed now.</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!IsDisposed)
            {
                IsDisposed = true;

                if (isDisposing)
                    DisposeNow();
            }
        }

        /// <summary>
        /// Called when an object should release its resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Settings"/> class.
        /// </summary>
        ~randstate_t()
        {
            Dispose(false);
        }

        /// <summary>
        /// True after <see cref="Dispose(bool)"/> has been invoked.
        /// </summary>
        private bool IsDisposed;

        /// <summary>
        /// Disposes of every reference that must be cleaned up.
        /// </summary>
        private void DisposeNow()
        {
            mp_randclear(ref Value);
        }
        #endregion
    }
}
