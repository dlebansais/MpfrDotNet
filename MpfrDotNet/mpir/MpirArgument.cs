namespace MpirDotNet;

using System;

/// <summary>
/// Checks arguments that would make GMP or MPIR raise an error. On Linux, GMP raises SIGFPE, which ends the process,
/// so these errors must be detected before the native call.
/// </summary>
internal static class MpirArgument
{
    /// <summary>
    /// The message of the exception thrown for a zero divisor.
    /// </summary>
    public const string ZeroDivisorMessage = "The divisor cannot be zero.";

    /// <summary>
    /// Checks that a divisor is not zero.
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero.</exception>
    public static void CheckDivisor(mpz_t divisor)
    {
        if (mpz.sgn(divisor) == 0)
            throw new DivideByZeroException(ZeroDivisorMessage);
    }

    /// <summary>
    /// Checks that a divisor is not zero.
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero.</exception>
    public static void CheckDivisor(ulong divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException(ZeroDivisorMessage);
    }

    /// <summary>
    /// Checks that a divisor is not zero.
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero.</exception>
    public static void CheckDivisor(mpq_t divisor)
    {
        if (mpq.sgn(divisor) == 0)
            throw new DivideByZeroException(ZeroDivisorMessage);
    }

    /// <summary>
    /// Checks that a divisor is not zero.
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero.</exception>
    public static void CheckDivisor(mpf_t divisor)
    {
        if (mpf.sgn(divisor) == 0)
            throw new DivideByZeroException(ZeroDivisorMessage);
    }

    /// <summary>
    /// Checks that the denominator of a rational number is not zero.
    /// </summary>
    /// <param name="rational">The rational number.</param>
    /// <exception cref="DivideByZeroException">The denominator of <paramref name="rational"/> is zero.</exception>
    public static void CheckDenominator(mpq_t rational)
    {
        // A size of zero means that the denominator is zero.
        if (rational.Value.Denominator.LimbCount == 0)
            throw new DivideByZeroException("The denominator cannot be zero.");
    }

    /// <summary>
    /// Checks that a number is not negative.
    /// </summary>
    /// <param name="op">The number.</param>
    /// <param name="paramName">The name of the parameter that holds the number.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="op"/> is negative.</exception>
    public static void CheckNotNegative(mpz_t op, string paramName)
    {
        if (mpz.sgn(op) < 0)
            throw new ArgumentOutOfRangeException(paramName, "The operand cannot be negative.");
    }

    /// <summary>
    /// Checks that a number is not negative.
    /// </summary>
    /// <param name="op">The number.</param>
    /// <param name="paramName">The name of the parameter that holds the number.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="op"/> is negative.</exception>
    public static void CheckNotNegative(mpf_t op, string paramName)
    {
        if (mpf.sgn(op) < 0)
            throw new ArgumentOutOfRangeException(paramName, "The operand cannot be negative.");
    }

    /// <summary>
    /// Checks that the root of a number can be computed.
    /// </summary>
    /// <param name="op">The number.</param>
    /// <param name="n">The root index.</param>
    /// <param name="opName">The name of the parameter that holds the number.</param>
    /// <param name="nName">The name of the parameter that holds the root index.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is zero, or <paramref name="n"/> is even and <paramref name="op"/> is negative.</exception>
    public static void CheckRoot(mpz_t op, ulong n, string opName, string nName)
    {
        if (n == 0)
            throw new ArgumentOutOfRangeException(nName, "The root index cannot be zero.");

        if (n % 2 == 0 && mpz.sgn(op) < 0)
            throw new ArgumentOutOfRangeException(opName, "An even root of a negative number cannot be computed.");
    }

    /// <summary>
    /// Checks that a modular power can be computed.
    /// </summary>
    /// <param name="opBase">The base.</param>
    /// <param name="exp">The exponent.</param>
    /// <param name="mod">The modulus.</param>
    /// <exception cref="DivideByZeroException"><paramref name="mod"/> is zero.</exception>
    /// <exception cref="ArithmeticException"><paramref name="exp"/> is negative and <paramref name="opBase"/> has no inverse modulo <paramref name="mod"/>.</exception>
    public static void CheckModularPower(mpz_t opBase, mpz_t exp, mpz_t mod)
    {
        CheckDivisor(mod);

        // A negative exponent needs the inverse of the base.
        if (mpz.sgn(exp) < 0)
        {
            using mpz_t Inverse = new();

            if (!mpz.invert(Inverse, opBase, mod))
                throw new ArithmeticException("The base has no inverse modulo the modulus, so it cannot be raised to a negative power.");
        }
    }
}
