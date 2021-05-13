namespace MpirDotNet
{
    using System;
    using System.Numerics;
    using System.Text;
    using static Interop.Mpir.NativeMethods;

    /// <summary>
    /// Arbitrary precision integer.
    /// </summary>
    public class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
    {
        #region Constants
        /// <summary>
        /// The default base for digits.
        /// </summary>
        public const int DefaultBase = 10;
        #endregion

        #region Predefined Values
        /// <summary>
        /// Gets the value -10.
        /// </summary>
        public static mpz_t NegativeTen { get; } = new mpz_t(-10);

        /// <summary>
        /// Gets the value -3.
        /// </summary>
        public static mpz_t NegativeThree { get; } = new mpz_t(-3);

        /// <summary>
        /// Gets the value -2.
        /// </summary>
        public static mpz_t NegativeTwo { get; } = new mpz_t(-2);

        /// <summary>
        /// Gets the value -1.
        /// </summary>
        public static mpz_t NegativeOne { get; } = new mpz_t(-1);

        /// <summary>
        /// Gets the value 0.
        /// </summary>
        public static mpz_t Zero { get; } = new mpz_t(0);

        /// <summary>
        /// Gets the value 1.
        /// </summary>
        public static mpz_t One { get; } = new mpz_t(1);

        /// <summary>
        /// Gets the value 2.
        /// </summary>
        public static mpz_t Two { get; } = new mpz_t(2);

        /// <summary>
        /// Gets the value 3.
        /// </summary>
        public static mpz_t Three { get; } = new mpz_t(3);

        /// <summary>
        /// Gets the value 10.
        /// </summary>
        public static mpz_t Ten { get; } = new mpz_t(10);
        #endregion

        #region Init
        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        public mpz_t()
        {
            mpz_init(ref Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="other">The other number.</param>
        public mpz_t(mpz_t other)
        {
            mpz_init_set(ref Value, ref other.Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        public mpz_t(uint op)
        {
            mpz_init_set_ui(ref Value, (mpir_ui)op);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        public mpz_t(int op)
        {
            mpz_init_set_si(ref Value, (mpir_si)op);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        public mpz_t(ulong op)
        {
            mpz_init_set_ux(ref Value, (uintmax_t)op);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        public mpz_t(long op)
        {
            mpz_init_set_sx(ref Value, (intmax_t)op);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        public mpz_t(double op)
        {
            mpz_init_set_d(ref Value, op);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="text">The number text.</param>
        public mpz_t(string text)
            : this(text, DefaultBase)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="text">The number text.</param>
        /// <param name="strBase">The digit base.</param>
        public mpz_t(string text, uint strBase)
        {
            int Success = mpz_init_set_str(ref Value, text, strBase);
            if (Success != 0)
                throw new ArgumentException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        public mpz_t(BigInteger op)
            : this(op.ToByteArray())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="size">The count of bits.</param>
        public mpz_t(bitcount_t size)
        {
            mpz_init2(ref Value, (mp_bitcnt_t)size.Count);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="bytes">The number raw bytes.</param>
        public mpz_t(byte[] bytes)
            : this()
        {
            mpz_import(ref Value, (size_t)(ulong)bytes.LongLength, 0, (size_t)sizeof(byte), 0, (size_t)0UL, bytes);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpz_t"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal mpz_t(__mpz_t value)
        {
            mpz_init_set(ref Value, ref value);
        }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
        internal __mpz_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
        #endregion

        #region Conversions
        /// <summary>
        /// Gets the number bytes.
        /// </summary>
        public byte[] ToByteArray()
        {
            ulong SizeInBits = (ulong)mpz_sizeinbase(ref Value, 2);
            byte[] Result = new byte[(SizeInBits + 7) / 8];

            size_t countp;
            mpz_export(Result, out countp, 0, (size_t)sizeof(byte), 0, (size_t)0UL, ref Value);

            return Result;
        }

        /// <summary>
        /// Returns a string that represents the number value.
        /// </summary>
        /// <returns>The number value.</returns>
        public override string ToString()
        {
            return ToString(DefaultBase);
        }

        /// <summary>
        /// Returns a string that represents the number value.
        /// </summary>
        /// <param name="resultbase">The digit base used in the result.</param>
        /// <returns>The number value.</returns>
        public string ToString(int resultbase)
        {
            ulong SizeInDigits = (ulong)mpz_sizeinbase(ref Value, (uint)resultbase);

            StringBuilder Data = new StringBuilder((int)(SizeInDigits + 2));
            mpz_get_str(Data, resultbase, ref Value);

            string Result = Data.ToString();
            return Result;
        }

        /// <summary>
        /// Converts from a <see cref="byte"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(byte value)
        {
            return new mpz_t((uint)value);
        }

        /// <summary>
        /// Converts from a <see cref="int"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(int value)
        {
            return new mpz_t(value);
        }

        /// <summary>
        /// Converts from a <see cref="uint"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(uint value)
        {
            return new mpz_t(value);
        }

        /// <summary>
        /// Converts from a <see cref="short"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(short value)
        {
            return new mpz_t(value);
        }

        /// <summary>
        /// Converts from a <see cref="ushort"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(ushort value)
        {
            return new mpz_t(value);
        }

        /// <summary>
        /// Converts from a <see cref="long"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(long value)
        {
            return new mpz_t(value);
        }

        /// <summary>
        /// Converts from a <see cref="ulong"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(ulong value)
        {
            return new mpz_t(value);
        }

        /// <summary>
        /// Converts from a <see cref="float"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(float value)
        {
            return new mpz_t((double)value);
        }

        /// <summary>
        /// Converts from a <see cref="double"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(double value)
        {
            return new mpz_t(value);
        }

        /// <summary>
        /// Converts from a <see cref="BigInteger"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpz_t(BigInteger value)
        {
            return new mpz_t(value);
        }

        /// <summary>
        /// Converts to a <see cref="byte"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator byte(mpz_t value)
        {
            return (byte)(uint)value;
        }

        /// <summary>
        /// Converts to a <see cref="int"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator int(mpz_t value)
        {
            return (int)(long)mpz_get_si(ref value.Value);
        }

        /// <summary>
        /// Converts to a <see cref="uint"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator uint(mpz_t value)
        {
            return (uint)(ulong)mpz_get_ui(ref value.Value);
        }

        /// <summary>
        /// Converts to a <see cref="short"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator short(mpz_t value)
        {
            return (short)(int)value;
        }

        /// <summary>
        /// Converts to a <see cref="ushort"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator ushort(mpz_t value)
        {
            return (ushort)(uint)value;
        }

        /// <summary>
        /// Converts to a <see cref="long"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator long(mpz_t value)
        {
            byte[] Bytes = new byte[8];

            mpz_import(ref value.Value, (size_t)(ulong)Bytes.LongLength, 0, (size_t)sizeof(byte), 0, (size_t)0UL, Bytes);
            long Int64Result = BitConverter.ToInt64(Bytes, 0);

            return Int64Result;
        }

        /// <summary>
        /// Converts to a <see cref="ulong"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator ulong(mpz_t value)
        {
            byte[] Bytes = new byte[8];

            mpz_import(ref value.Value, (size_t)(ulong)Bytes.LongLength, 0, (size_t)sizeof(byte), 0, (size_t)0UL, Bytes);
            ulong UInt64Result = BitConverter.ToUInt64(Bytes, 0);

            return UInt64Result;
        }

        /// <summary>
        /// Converts to a <see cref="float"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator float(mpz_t value)
        {
            return (float)(double)value;
        }

        /// <summary>
        /// Converts to a <see cref="double"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator double(mpz_t value)
        {
            return mpz_get_d(ref value.Value);
        }

        /// <summary>
        /// Converts to a <see cref="BigInteger"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator BigInteger(mpz_t value)
        {
            byte[] Bytes = value.ToByteArray();
            return new BigInteger(Bytes);
        }
        #endregion

        #region Operators
        /// <summary>
        /// Adds two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator +(mpz_t x, mpz_t y)
        {
            mpz_t z = new();

            mpz_add(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Adds two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator +(mpz_t x, long y)
        {
            mpz_t z = new();

            if (y >= 0)
                mpz_add_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)y);
            else
                mpz_sub_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)-y);

            return z;
        }

        /// <summary>
        /// Adds two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator +(long x, mpz_t y)
        {
            mpz_t z = new();

            if (x >= 0)
                mpz_add_ui(ref z.Value, ref y.Value, (mpir_ui)(ulong)x);
            else
                mpz_sub_ui(ref z.Value, ref y.Value, (mpir_ui)(ulong)-x);

            return z;
        }

        /// <summary>
        /// Adds two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator +(mpz_t x, ulong y)
        {
            mpz_t z = new mpz_t();

            mpz_add_ui(ref z.Value, ref x.Value, (mpir_ui)y);

            return z;
        }

        /// <summary>
        /// Adds two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator +(ulong x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_add_ui(ref z.Value, ref y.Value, (mpir_ui)x);

            return z;
        }

        /// <summary>
        /// Increments an operand.
        /// </summary>
        /// <param name="x">The operand.</param>
        public static mpz_t operator ++(mpz_t x)
        {
            using mpz_t z = new mpz_t();

            mpz_add_ui(ref z.Value, ref x.Value, (mpir_ui)1UL);
            mpz_set(ref x.Value, ref z.Value);

            return x;
        }

        /// <summary>
        /// Subtracts two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator -(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_sub(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Subtracts two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator -(long x, mpz_t y)
        {
            if (x >= 0)
            {
                mpz_t z = new mpz_t();

                mpz_ui_sub(ref z.Value, (mpir_ui)(ulong)x, ref y.Value);

                return z;
            }
            else
            {
                mpz_t z = new mpz_t();

                mpz_add_ui(ref z.Value, ref y.Value, (mpir_ui)(ulong)-x);
                mpz_neg(ref z.Value, ref z.Value);

                return z;
            }
        }

        /// <summary>
        /// Subtracts two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator -(mpz_t x, long y)
        {
            mpz_t z = new mpz_t();

            if (y >= 0)
                mpz_sub_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)y);
            else
                mpz_add_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)-y);

            return z;
        }

        /// <summary>
        /// Subtracts two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator -(ulong x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_ui_sub(ref z.Value, (mpir_ui)x, ref y.Value);

            return z;
        }

        /// <summary>
        /// Subtracts two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator -(mpz_t x, ulong y)
        {
            mpz_t z = new mpz_t();

            mpz_sub_ui(ref z.Value, ref x.Value, (mpir_ui)y);

            return z;
        }

        /// <summary>
        /// Decrements an operand.
        /// </summary>
        /// <param name="x">The operand.</param>
        public static mpz_t operator --(mpz_t x)
        {
            using mpz_t z = new mpz_t();

            mpz_sub_ui(ref z.Value, ref x.Value, (mpir_ui)1UL);
            mpz_set(ref x.Value, ref z.Value);

            return x;
        }

        /// <summary>
        /// Multiplies two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator *(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_mul(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Multiplies two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator *(long x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_mul_si(ref z.Value, ref y.Value, (mpir_si)x);

            return z;
        }

        /// <summary>
        /// Multiplies two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator *(mpz_t x, long y)
        {
            mpz_t z = new mpz_t();

            mpz_mul_si(ref z.Value, ref x.Value, (mpir_si)y);

            return z;
        }

        /// <summary>
        /// Multiplies two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator *(ulong x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_mul_ui(ref z.Value, ref y.Value, (mpir_ui)x);

            return z;
        }

        /// <summary>
        /// Multiplies two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator *(mpz_t x, ulong y)
        {
            mpz_t z = new mpz_t();

            mpz_mul_ui(ref z.Value, ref x.Value, (mpir_ui)y);

            return z;
        }

        /// <summary>
        /// Shifts an operand to the left.
        /// </summary>
        /// <param name="x">The operand.</param>
        /// <param name="count">The number of bits to shift.</param>
        public static mpz_t operator <<(mpz_t x, int count)
        {
            mpz_t z = new mpz_t();

            if (count >= 0)
                mpz_mul_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

            return z;
        }

        /// <summary>
        /// Shifts an operand to the right.
        /// </summary>
        /// <param name="x">The operand.</param>
        /// <param name="count">The number of bits to shift.</param>
        public static mpz_t operator >>(mpz_t x, int count)
        {
            mpz_t z = new mpz_t();

            if (count >= 0)
                mpz_tdiv_q_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

            return z;
        }

        /// <summary>
        /// Negates an operand.
        /// </summary>
        /// <param name="x">The operand.</param>
        public static mpz_t operator -(mpz_t x)
        {
            mpz_t z = new mpz_t();

            mpz_neg(ref z.Value, ref x.Value);

            return z;
        }

        /// <summary>
        /// Divides two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator /(mpz_t x, mpz_t y)
        {
            mpz_t quotient = new mpz_t();

            mpz_tdiv_q(ref quotient.Value, ref x.Value, ref y.Value);

            return quotient;
        }

        /// <summary>
        /// Divides two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator /(mpz_t x, long y)
        {
            if (y >= 0)
            {
                mpz_t quotient = new mpz_t();

                mpz_tdiv_q_ui(ref quotient.Value, ref x.Value, (mpir_ui)(ulong)y);

                return quotient;
            }
            else
            {
                mpz_t quotient = new mpz_t();

                mpz_tdiv_q_ui(ref quotient.Value, ref x.Value, (mpir_ui)(ulong)-y);
                mpz_neg(ref quotient.Value, ref quotient.Value);

                return quotient;
            }
        }

        /// <summary>
        /// Divides two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator /(mpz_t x, ulong y)
        {
            mpz_t quotient = new mpz_t();

            mpz_tdiv_q_ui(ref quotient.Value, ref x.Value, (mpir_ui)y);

            return quotient;
        }

        /// <summary>
        /// Gets the modulo of an operand.
        /// </summary>
        /// <param name="x">The operand.</param>
        /// <param name="mod">The modulo.</param>
        public static mpz_t operator %(mpz_t x, mpz_t mod)
        {
            mpz_t z = new mpz_t();

            mpz_mod(ref z.Value, ref x.Value, ref mod.Value);

            return z;
        }

        /// <summary>
        /// Gets the modulo of an operand.
        /// </summary>
        /// <param name="x">The operand.</param>
        /// <param name="mod">The modulo.</param>
        public static mpz_t operator %(mpz_t x, long mod)
        {
            if (mod < 0)
                throw new ArgumentOutOfRangeException(nameof(mod));

            mpz_t z = new mpz_t();

            mpz_fdiv_r_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)mod);

            return z;
        }

        /// <summary>
        /// Gets the modulo of an operand.
        /// </summary>
        /// <param name="x">The operand.</param>
        /// <param name="mod">The modulo.</param>
        public static mpz_t operator %(mpz_t x, ulong mod)
        {
            mpz_t z = new mpz_t();

            mpz_fdiv_r_ui(ref z.Value, ref x.Value, (mpir_ui)mod);

            return z;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(int x, mpz_t y)
        {
            return y.CompareTo(x) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(mpz_t x, int y)
        {
            return x.CompareTo(y) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(uint x, mpz_t y)
        {
            return y.CompareTo(x) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(mpz_t x, uint y)
        {
            return x.CompareTo(y) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary < y;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x < Temporary;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary < y;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x < Temporary;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(float x, mpz_t y)
        {
            return y.CompareTo(x) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(mpz_t x, float y)
        {
            return x.CompareTo(y) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(double x, mpz_t y)
        {
            return y.CompareTo(x) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(mpz_t x, double y)
        {
            return x.CompareTo(y) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(int x, mpz_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(mpz_t x, int y)
        {
            return x.CompareTo(y) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(uint x, mpz_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(mpz_t x, uint y)
        {
            return x.CompareTo(y) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary <= y;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x <= Temporary;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary <= y;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x <= Temporary;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(float x, mpz_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(mpz_t x, float y)
        {
            return x.CompareTo(y) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(double x, mpz_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(mpz_t x, double y)
        {
            return x.CompareTo(y) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(int x, mpz_t y)
        {
            return y.CompareTo(x) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(mpz_t x, int y)
        {
            return x.CompareTo(y) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(uint x, mpz_t y)
        {
            return y.CompareTo(x) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(mpz_t x, uint y)
        {
            return x.CompareTo(y) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary > y;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x > Temporary;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary > y;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x > Temporary;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(float x, mpz_t y)
        {
            return y.CompareTo(x) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(mpz_t x, float y)
        {
            return x.CompareTo(y) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(double x, mpz_t y)
        {
            return y.CompareTo(x) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(mpz_t x, double y)
        {
            return x.CompareTo(y) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(int x, mpz_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(mpz_t x, int y)
        {
            return x.CompareTo(y) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(uint x, mpz_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(mpz_t x, uint y)
        {
            return x.CompareTo(y) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary >= y;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x >= Temporary;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary >= y;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x >= Temporary;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(float x, mpz_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(mpz_t x, float y)
        {
            return x.CompareTo(y) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(double x, mpz_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(mpz_t x, double y)
        {
            return x.CompareTo(y) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(int x, mpz_t y)
        {
            return y.CompareTo(x) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(mpz_t x, int y)
        {
            return x.CompareTo(y) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(uint x, mpz_t y)
        {
            return y.CompareTo(x) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(mpz_t x, uint y)
        {
            return x.CompareTo(y) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return y.CompareTo(Temporary) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x.CompareTo(Temporary) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return y.CompareTo(Temporary) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x.CompareTo(Temporary) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(float x, mpz_t y)
        {
            return y.CompareTo(x) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(mpz_t x, float y)
        {
            return x.CompareTo(y) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(double x, mpz_t y)
        {
            return y.CompareTo(x) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(mpz_t x, double y)
        {
            return x.CompareTo(y) == 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(int x, mpz_t y)
        {
            return y.CompareTo(x) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(mpz_t x, int y)
        {
            return x.CompareTo(y) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(uint x, mpz_t y)
        {
            return y.CompareTo(x) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(mpz_t x, uint y)
        {
            return x.CompareTo(y) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return y.CompareTo(Temporary) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x.CompareTo(Temporary) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return y.CompareTo(Temporary) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x.CompareTo(Temporary) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(float x, mpz_t y)
        {
            return y.CompareTo(x) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(mpz_t x, float y)
        {
            return x.CompareTo(y) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(double x, mpz_t y)
        {
            return y.CompareTo(x) != 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(mpz_t x, double y)
        {
            return x.CompareTo(y) != 0;
        }

        /// <summary>
        /// Gets the bitwise and of two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator &(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_and(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Gets the bitwise or of two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator |(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_ior(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Gets the bitwise xor of two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpz_t operator ^(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_xor(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Gets the two's-complement of an operand.
        /// </summary>
        /// <param name="x">The operand.</param>
        public static mpz_t operator ~(mpz_t x)
        {
            mpz_t z = new mpz_t();

            mpz_com(ref z.Value, ref x.Value);

            return z;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object..</param>
        public override bool Equals(object? obj)
        {
            if (obj is mpz_t other)
                return CompareTo(other) != 0;
            else
                return false;
        }

        /// <summary>
        /// Gets the hash of the object.
        /// </summary>
        public override int GetHashCode()
        {
            return Convert.ToBase64String(ToByteArray()).GetHashCode();
        }
        #endregion

        #region Basic Arithmetic
        /// <summary>
        /// Gets the absolute value of the number.
        /// </summary>
        public mpz_t Abs()
        {
            mpz_t z = new mpz_t();

            mpz_abs(ref z.Value, ref Value);

            return z;
        }

        /// <summary>
        /// Gets the sign.
        /// </summary>
        public int Sign
        {
            get { return mpz_sgn(ref Value); }
        }

        /// <summary>
        /// Divides the number by another with rounding.
        /// </summary>
        /// <param name="y">The other number.</param>
        /// <param name="rounding">The rounding.</param>
        public mpz_t Quotient(mpz_t y, Rounding rounding = Rounding.TowardZero)
        {
            mpz_t quotient = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_q(ref quotient.Value, ref Value, ref y.Value);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_q(ref quotient.Value, ref Value, ref y.Value);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_q(ref quotient.Value, ref Value, ref y.Value);
                    break;
            }

            return quotient;
        }

        /// <summary>
        /// Gets the remainder of the division of the number by another with rounding.
        /// </summary>
        /// <param name="y">The other number.</param>
        /// <param name="rounding">The rounding.</param>
        public mpz_t Remainder(mpz_t y, Rounding rounding = Rounding.TowardZero)
        {
            mpz_t remainder = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_r(ref remainder.Value, ref Value, ref y.Value);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_r(ref remainder.Value, ref Value, ref y.Value);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_r(ref remainder.Value, ref Value, ref y.Value);
                    break;
            }

            return remainder;
        }

        /// <summary>
        /// Divides two operands with rounding.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        /// <param name="quotient">The quotient.</param>
        /// <param name="remainder">The remainder.</param>
        /// <param name="rounding">The rounding.</param>
        public static void Divide(mpz_t x, mpz_t y, out mpz_t quotient, out mpz_t remainder, Rounding rounding = Rounding.TowardZero)
        {
            quotient = new mpz_t();
            remainder = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_qr(ref quotient.Value, ref remainder.Value, ref x.Value, ref y.Value);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_qr(ref quotient.Value, ref remainder.Value, ref x.Value, ref y.Value);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_qr(ref quotient.Value, ref remainder.Value, ref x.Value, ref y.Value);
                    break;
            }
        }

        /// <summary>
        /// Divides the number by another with rounding.
        /// </summary>
        /// <param name="y">The other number.</param>
        /// <param name="rounding">The rounding.</param>
        public mpz_t Quotient(ulong y, Rounding rounding = Rounding.TowardZero)
        {
            mpz_t quotient = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_q_ui(ref quotient.Value, ref Value, (mpir_ui)y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_q_ui(ref quotient.Value, ref Value, (mpir_ui)y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_q_ui(ref quotient.Value, ref Value, (mpir_ui)y);
                    break;
            }

            return quotient;
        }

        /// <summary>
        /// Gets the remainder of the division of the number by another with rounding.
        /// </summary>
        /// <param name="y">The other number.</param>
        /// <param name="rounding">The rounding.</param>
        public mpz_t Remainder(ulong y, Rounding rounding = Rounding.TowardZero)
        {
            mpz_t remainder = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_r_ui(ref remainder.Value, ref Value, (mpir_ui)y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_r_ui(ref remainder.Value, ref Value, (mpir_ui)y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_r_ui(ref remainder.Value, ref Value, (mpir_ui)y);
                    break;
            }

            return remainder;
        }

        /// <summary>
        /// Divides two operands with rounding.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        /// <param name="quotient">The quotient.</param>
        /// <param name="remainder">The remainder.</param>
        /// <param name="rounding">The rounding.</param>
        public static void Divide(mpz_t x, ulong y, out mpz_t quotient, out mpz_t remainder, Rounding rounding = Rounding.TowardZero)
        {
            quotient = new mpz_t();
            remainder = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_qr_ui(ref quotient.Value, ref remainder.Value, ref x.Value, (mpir_ui)y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_qr_ui(ref quotient.Value, ref remainder.Value, ref x.Value, (mpir_ui)y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_qr_ui(ref quotient.Value, ref remainder.Value, ref x.Value, (mpir_ui)y);
                    break;
            }
        }

        /// <summary>
        /// Gets the absolute remainder of the division of the number by another with rounding.
        /// </summary>
        /// <param name="y">The other number.</param>
        /// <param name="rounding">The rounding.</param>
        public ulong AbsRemainder(ulong y, Rounding rounding = Rounding.TowardZero)
        {
            ulong remainder;

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    remainder = (ulong)mpz_tdiv_ui(ref Value, (mpir_ui)y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    remainder = (ulong)mpz_cdiv_ui(ref Value, (mpir_ui)y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    remainder = (ulong)mpz_fdiv_ui(ref Value, (mpir_ui)y);
                    break;
            }

            return remainder;
        }

        /// <summary>
        /// Gets the right shift of the number by another with rounding.
        /// </summary>
        /// <param name="y">The other number.</param>
        /// <param name="rounding">The rounding.</param>
        public mpz_t RightShift(ulong y, Rounding rounding = Rounding.TowardZero)
        {
            mpz_t quotient = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_q_2exp(ref quotient.Value, ref Value, (mp_bitcnt_t)y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_q_2exp(ref quotient.Value, ref Value, (mp_bitcnt_t)y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_q_2exp(ref quotient.Value, ref Value, (mp_bitcnt_t)y);
                    break;
            }

            return quotient;
        }

        /// <summary>
        /// Gets the remainder of the right shift of the number by another with rounding.
        /// </summary>
        /// <param name="y">The other number.</param>
        /// <param name="rounding">The rounding.</param>
        public mpz_t RightShiftRemainder(ulong y, Rounding rounding = Rounding.TowardZero)
        {
            mpz_t remainder = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_r_2exp(ref remainder.Value, ref Value, (mp_bitcnt_t)y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_r_2exp(ref remainder.Value, ref Value, (mp_bitcnt_t)y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_r_2exp(ref remainder.Value, ref Value, (mp_bitcnt_t)y);
                    break;
            }

            return remainder;
        }

        /// <summary>
        /// See http://mpir.org/mpir-3.0.0.pdf.
        /// </summary>
        /// <param name="y">The divider.</param>
        public mpz_t DivExact(mpz_t y)
        {
            mpz_t quotient = new mpz_t();

            mpz_divexact(ref quotient.Value, ref Value, ref y.Value);

            return quotient;
        }

        /// <summary>
        /// See http://mpir.org/mpir-3.0.0.pdf.
        /// </summary>
        /// <param name="y">The divider.</param>
        public mpz_t DivExact(ulong y)
        {
            mpz_t quotient = new mpz_t();

            mpz_divexact_ui(ref quotient.Value, ref Value, (mpir_ui)y);

            return quotient;
        }

        /// <summary>
        /// Gets a value indicating whether the number can be exactly divided by another.
        /// </summary>
        /// <param name="y">The divider.</param>
        public bool IsDivisible(mpz_t y)
        {
            return mpz_divisible_p(ref Value, ref y.Value) != 0;
        }

        /// <summary>
        /// Gets a value indicating whether the number can be exactly divided by another.
        /// </summary>
        /// <param name="y">The divider.</param>
        public bool IsDivisible(ulong y)
        {
            return mpz_divisible_ui_p(ref Value, (mpir_ui)y) != 0;
        }

        /// <summary>
        /// Gets a value indicating whether the number can be exactly divided by the power of two of another.
        /// </summary>
        /// <param name="y">The power.</param>
        public bool IsDivisibleByPowerOfTwo(ulong y)
        {
            return mpz_divisible_2exp_p(ref Value, (mp_bitcnt_t)y) != 0;
        }

        /// <summary>
        /// See http://mpir.org/mpir-3.0.0.pdf.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        public bool IsCongruent(mpz_t c, mpz_t d)
        {
            return mpz_congruent_p(ref Value, ref c.Value, ref d.Value) != 0;
        }

        /// <summary>
        /// See http://mpir.org/mpir-3.0.0.pdf.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        public bool IsCongruent(ulong c, ulong d)
        {
            return mpz_congruent_ui_p(ref Value, (mpir_ui)c, (mpir_ui)d) != 0;
        }

        /// <summary>
        /// See http://mpir.org/mpir-3.0.0.pdf.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        public bool IsCongruentPowerOfTwo(mpz_t c, long d)
        {
            return mpz_congruent_2exp_p(ref Value, ref c.Value, (mp_bitcnt_t)(ulong)d) != 0;
        }

        /// <summary>
        /// Gets the modulo of the number with a power of two.
        /// </summary>
        /// <param name="exp">The power.</param>
        /// <param name="mod">The modulo.</param>
        public mpz_t PowerMod(mpz_t exp, mpz_t mod)
        {
            mpz_t Result = new mpz_t();

            mpz_powm(ref Result.Value, ref Value, ref exp.Value, ref mod.Value);

            return Result;
        }

        /// <summary>
        /// Gets the modulo of the number with a power of two.
        /// </summary>
        /// <param name="exp">The power.</param>
        /// <param name="mod">The modulo.</param>
        public mpz_t PowerMod(ulong exp, mpz_t mod)
        {
            mpz_t Result = new mpz_t();

            mpz_powm_ui(ref Result.Value, ref Value, (mpir_ui)exp, ref mod.Value);

            return Result;
        }

        /// <summary>
        /// Gets the value of the number to a power.
        /// </summary>
        /// <param name="exp">The power.</param>
        public mpz_t Pow(ulong exp)
        {
            mpz_t Result = new mpz_t();

            mpz_pow_ui(ref Result.Value, ref Value, (mpir_ui)exp);

            return Result;
        }

        /// <summary>
        /// Gets a value indicating whether the number is an exact root.
        /// </summary>
        /// <param name="n">The root number.</param>
        public bool IsRootExact(ulong n)
        {
            using mpz_t Result = new mpz_t();

            return mpz_root(ref Result.Value, ref Value, (mpir_ui)n) != 0;
        }

        /// <summary>
        /// Gets the root of the number.
        /// </summary>
        /// <param name="n">The root.</param>
        public mpz_t NthRoot(ulong n)
        {
            mpz_t Result = new mpz_t();

            mpz_nthroot(ref Result.Value, ref Value, (mpir_ui)n);

            return Result;
        }

        /// <summary>
        /// Gets the nth root of a number.
        /// </summary>
        /// <param name="x">The number.</param>
        /// <param name="n">The nth.</param>
        /// <param name="root">The root.</param>
        /// <param name="remainder">The remainder.</param>
        public static void NthRoot(mpz_t x, ulong n, out mpz_t root, out mpz_t remainder)
        {
            root = new mpz_t();
            remainder = new mpz_t();

            mpz_rootrem(ref root.Value, ref remainder.Value, ref x.Value, (mpir_ui)n);
        }

        /// <summary>
        /// Gets the square root.
        /// </summary>
        public mpz_t Sqrt()
        {
            mpz_t Result = new mpz_t();

            mpz_sqrt(ref Result.Value, ref Value);

            return Result;
        }

        /// <summary>
        /// Gets the square root of a number.
        /// </summary>
        /// <param name="x">The number.</param>
        /// <param name="root">The root.</param>
        /// <param name="remainder">The remainder.</param>
        public static void SqrtRemainder(mpz_t x, out mpz_t root, out mpz_t remainder)
        {
            root = new mpz_t();
            remainder = new mpz_t();

            mpz_sqrtrem(ref root.Value, ref remainder.Value, ref x.Value);
        }

        /// <summary>
        /// Gets a value indicating whether the number is an exact power.
        /// </summary>
        public bool IsPerfectPower()
        {
            return mpz_perfect_power_p(ref Value) != 0;
        }

        /// <summary>
        /// Gets a value indicating whether the number is an exact square.
        /// </summary>
        public bool IsPerfectSquare()
        {
            return mpz_perfect_square_p(ref Value) != 0;
        }
        #endregion

        #region Comparison
        /// <summary>
        /// Compares with another number.
        /// </summary>
        /// <param name="other">The other number.</param>
        public int CompareTo(mpz_t? other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            else
                return mpz_cmp(ref Value, ref other.Value);
        }

        /// <summary>
        /// Compares with another number.
        /// </summary>
        /// <param name="other">The other number.</param>
        public int CompareTo(long other)
        {
            return mpz_cmp_si(ref Value, (mpir_si)other);
        }

        /// <summary>
        /// Compares with another number.
        /// </summary>
        /// <param name="other">The other number.</param>
        public int CompareTo(ulong other)
        {
            return mpz_cmp_ui(ref Value, (mpir_ui)other);
        }

        /// <summary>
        /// Compares with another number.
        /// </summary>
        /// <param name="other">The other number.</param>
        public int CompareTo(float other)
        {
            return mpz_cmp_d(ref Value, other);
        }

        /// <summary>
        /// Compares with another number.
        /// </summary>
        /// <param name="other">The other number.</param>
        public int CompareTo(double other)
        {
            return mpz_cmp_d(ref Value, other);
        }
        #endregion

        #region Bitwise
        /// <summary>
        /// Gets a specific bit.
        /// </summary>
        /// <param name="index">The bit index.</param>
        public bool GetBit(ulong index)
        {
            return mpz_tstbit(ref Value, (mp_bitcnt_t)index) != 0;
        }

        /// <summary>
        /// Sets a specific bit.
        /// </summary>
        /// <param name="index">The bit index.</param>
        public void SetBit(ulong index)
        {
            mpz_setbit(ref Value, (mp_bitcnt_t)index);
        }

        /// <summary>
        /// Clears a specific bit.
        /// </summary>
        /// <param name="index">The bit index.</param>
        public void ClearBit(ulong index)
        {
            mpz_clrbit(ref Value, (mp_bitcnt_t)index);
        }

        /// <summary>
        /// Toggles a specific bit.
        /// </summary>
        /// <param name="index">The bit index.</param>
        public void ComplementBit(ulong index)
        {
            mpz_combit(ref Value, (mp_bitcnt_t)index);
        }

        /// <summary>
        /// Changes a specific bit.
        /// </summary>
        /// <param name="index">The bit index.</param>
        /// <param name="isSet">The bit value.</param>
        public void ChangeBit(ulong index, bool isSet)
        {
            if (isSet)
                mpz_setbit(ref Value, (mp_bitcnt_t)index);
            else
                mpz_clrbit(ref Value, (mp_bitcnt_t)index);
        }
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
        /// Called when an object should release its resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="mpz_t"/> class.
        /// </summary>
        ~mpz_t()
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
            mpz_clear(ref Value);
        }
        #endregion

        #region Implementation of IEquatable<mpz_t>
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        public bool Equals(mpz_t? other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            else
                return mpz_cmp(ref Value, ref other.Value) == 0;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        bool IEquatable<mpz_t>.Equals(mpz_t? other)
        {
            return this.Equals(other);
        }
        #endregion

        #region Implementation of ICloneable
        /// <summary>
        /// Creates a copy of the object.
        /// </summary>
        public object Clone()
        {
            return new mpz_t(this);
        }

        /// <summary>
        /// Creates a copy of the object.
        /// </summary>
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        #endregion

        #region Implementation of IConvertible
        /// <summary>
        /// Returns the <see cref="TypeCode"/> for this instance.
        /// </summary>
        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="bool"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public bool ToBoolean(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="bool"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        bool IConvertible.ToBoolean(IFormatProvider? provider)
        {
            return this.ToBoolean(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="byte"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public byte ToByte(IFormatProvider? provider)
        {
            return (byte)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="byte"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        byte IConvertible.ToByte(IFormatProvider? provider)
        {
            return this.ToByte(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="char"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public char ToChar(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="char"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        char IConvertible.ToChar(IFormatProvider? provider)
        {
            return this.ToChar(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public DateTime ToDateTime(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        DateTime IConvertible.ToDateTime(IFormatProvider? provider)
        {
            return this.ToDateTime(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="decimal"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public decimal ToDecimal(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="decimal"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        decimal IConvertible.ToDecimal(IFormatProvider? provider)
        {
            return this.ToDecimal(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="double"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public double ToDouble(IFormatProvider? provider)
        {
            return (double)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="double"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        double IConvertible.ToDouble(IFormatProvider? provider)
        {
            return this.ToDouble(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="short"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public short ToInt16(IFormatProvider? provider)
        {
            return (short)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="short"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        short IConvertible.ToInt16(IFormatProvider? provider)
        {
            return this.ToInt16(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="int"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public int ToInt32(IFormatProvider? provider)
        {
            return (int)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="int"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        int IConvertible.ToInt32(IFormatProvider? provider)
        {
            return this.ToInt32(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="long"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public long ToInt64(IFormatProvider? provider)
        {
            return (long)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="long"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        long IConvertible.ToInt64(IFormatProvider? provider)
        {
            return this.ToInt64(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="sbyte"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public sbyte ToSByte(IFormatProvider? provider)
        {
            return (sbyte)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="sbyte"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        sbyte IConvertible.ToSByte(IFormatProvider? provider)
        {
            return this.ToSByte(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="float"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public float ToSingle(IFormatProvider? provider)
        {
            return (float)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="float"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        float IConvertible.ToSingle(IFormatProvider? provider)
        {
            return this.ToSingle(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="string"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public string ToString(IFormatProvider? provider)
        {
            return this.ToString();
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="string"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        string IConvertible.ToString(IFormatProvider? provider)
        {
            return this.ToString(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an object of the specified type.
        /// </summary>
        /// <param name="targetType">The type to which the value of this instance is converted.</param>
        /// <param name="provider">Culture-specific formatting information.</param>
        public object ToType(Type targetType, IFormatProvider? provider)
        {
            if (targetType == typeof(mpz_t))
                return this;

            IConvertible value = this;

            if (targetType == typeof(sbyte))
                return value.ToSByte(provider);
            else if (targetType == typeof(byte))
                return value.ToByte(provider);
            else if (targetType == typeof(short))
                return value.ToInt16(provider);
            else if (targetType == typeof(ushort))
                return value.ToUInt16(provider);
            else if (targetType == typeof(int))
                return value.ToInt32(provider);
            else if (targetType == typeof(uint))
                return value.ToUInt32(provider);
            else if (targetType == typeof(long))
                return value.ToInt64(provider);
            else if (targetType == typeof(ulong))
                return value.ToUInt64(provider);
            else if (targetType == typeof(float))
                return value.ToSingle(provider);
            else if (targetType == typeof(double))
                return value.ToDouble(provider);
            else if (targetType == typeof(decimal))
                return value.ToDecimal(provider);
            else if (targetType == typeof(string))
                return value.ToString(provider);
            else if (targetType == typeof(object))
                return value;
            else
                throw new InvalidCastException();
        }

        /// <summary>
        /// Converts the value of this instance to an object of the specified type.
        /// </summary>
        /// <param name="targetType">The type to which the value of this instance is converted.</param>
        /// <param name="provider">Culture-specific formatting information.</param>
        object IConvertible.ToType(Type targetType, IFormatProvider? provider)
        {
            return this.ToType(targetType, provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="ushort"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public ushort ToUInt16(IFormatProvider? provider)
        {
            return this.ToUInt16(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="ushort"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        ushort IConvertible.ToUInt16(IFormatProvider? provider)
        {
            return (ushort)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="uint"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public uint ToUInt32(IFormatProvider? provider)
        {
            return (uint)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="uint"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        uint IConvertible.ToUInt32(IFormatProvider? provider)
        {
            return this.ToUInt32(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="ulong"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public ulong ToUInt64(IFormatProvider? provider)
        {
            return (ulong)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="ulong"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        ulong IConvertible.ToUInt64(IFormatProvider? provider)
        {
            return this.ToUInt64(provider);
        }
        #endregion

        #region Implementation of IComparable
        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        public int CompareTo(object? obj)
        {
            if (obj is mpz_t other)
                return CompareTo(other);
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        int IComparable.CompareTo(object? obj)
        {
            return this.CompareTo(obj);
        }
        #endregion
    }
}
