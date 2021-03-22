namespace MpirDotNet
{
    using System;
    using System.Numerics;
    using System.Text;
    using static NativeMethods;

    public class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
    {
        #region Constants
        public const int DefaultBase = 10;
        #endregion

        #region Predefined Values
        public static mpz_t NegativeTen { get; } = new mpz_t(-10);
        public static mpz_t NegativeThree { get; } = new mpz_t(-3);
        public static mpz_t NegativeTwo { get; } = new mpz_t(-2);
        public static mpz_t NegativeOne { get; } = new mpz_t(-1);
        public static mpz_t Zero { get; } = new mpz_t(0);
        public static mpz_t One { get; } = new mpz_t(1);
        public static mpz_t Two { get; } = new mpz_t(2);
        public static mpz_t Three { get; } = new mpz_t(3);
        public static mpz_t Ten { get; } = new mpz_t(10);
        #endregion

        #region Init
        // Initializes a new mpz_t to 0.
        public mpz_t()
        {
            mpz_init(ref Value);
        }

        // Initializes a new mpz_t to the same value as op.
        public mpz_t(mpz_t op)
        {
            mpz_init_set(ref Value, ref op.Value);
        }

        // Initializes a new mpz_t to the unsigned int op.
        public mpz_t(uint op)
        {
            mpz_init_set_ui(ref Value, op);
        }

        // Initializes a new mpz_t to the int op.
        public mpz_t(int op)
        {
            mpz_init_set_si(ref Value, op);
        }

        // Initializes a new mpz_t to the unsigned long op.
        public mpz_t(ulong op)
        {
            mpz_init_set_ux(ref Value, (uintmax_t)op);
        }

        // Initializes a new mpz_t to the long op.
        public mpz_t(long op)
        {
            mpz_init_set_sx(ref Value, op);
        }

        // Initializes a new mpz_t to the double op.
        public mpz_t(double op)
        {
            mpz_init_set_d(ref Value, op);
        }

        // Initializes a new mpz_t to string s, parsed as an integer in the specified base.
        public mpz_t(string s, uint strBase)
        {
            int Success = mpz_init_set_str(ref Value, s, strBase);
            if (Success != 0)
                throw new ArgumentException();
        }

        // Initializes a new mpz_t to string s, parsed as an integer in base 10.
        public mpz_t(string s)
            : this(s, DefaultBase)
        {
        }

        // Initializes a new mpz_t to the BigInteger op.
        public mpz_t(BigInteger op)
            : this(op.ToByteArray())
        {
        }

        // Initializes a new mpz_t to using MPIR mpz_init2. Only use if you need to
        // avoid reallocations.
        public mpz_t(bitcount_t size)
        {
            mpz_init2(ref Value, (mp_bitcnt_t)size.Count);
        }

        // Initializes a new mpz_t to the integer in the byte array bytes.
        public mpz_t(byte[] bytes)
            : this()
        {
            mpz_import(ref Value, bytes.LongLength, 0, sizeof(byte), 0, 0, bytes);
        }

        internal mpz_t(__mpz_t value)
        {
            mpz_init_set(ref Value, ref value);
        }

        internal __mpz_t Value;
        #endregion

        #region Conversions
        // Export to the value to a byte array.
        public byte[] ToByteArray()
        {
            long SizeInBits = mpz_sizeinbase(ref Value, 2);
            byte[] Result = new byte[(SizeInBits + 7) / 8];

            long countp;
            mpz_export(Result, out countp, 0, sizeof(byte), 0, 0, ref Value);

            return Result;
        }

        public override string ToString()
        {
            return ToString(DefaultBase);
        }

        public string ToString(int resultbase)
        {
            int SizeInDigits = (int)mpz_sizeinbase(ref Value, (uint)resultbase);

            StringBuilder Data = new StringBuilder(SizeInDigits + 2);
            mpz_get_str(Data, resultbase, ref Value);

            string Result = Data.ToString();
            return Result;
        }

        public static implicit operator mpz_t(byte value)
        {
            return new mpz_t((uint)value);
        }

        public static implicit operator mpz_t(int value)
        {
            return new mpz_t(value);
        }

        public static implicit operator mpz_t(uint value)
        {
            return new mpz_t(value);
        }

        public static implicit operator mpz_t(short value)
        {
            return new mpz_t(value);
        }

        public static implicit operator mpz_t(ushort value)
        {
            return new mpz_t(value);
        }

        public static implicit operator mpz_t(long value)
        {
            return new mpz_t(value);
        }

        public static implicit operator mpz_t(ulong value)
        {
            return new mpz_t(value);
        }

        public static implicit operator mpz_t(float value)
        {
            return new mpz_t((double)value);
        }

        public static implicit operator mpz_t(double value)
        {
            return new mpz_t(value);
        }

        public static implicit operator mpz_t(BigInteger value)
        {
            return new mpz_t(value);
        }

        public static explicit operator byte(mpz_t value)
        {
            return (byte)(uint)value;
        }

        public static explicit operator int(mpz_t value)
        {
            return mpz_get_si(ref value.Value);
        }

        public static explicit operator uint(mpz_t value)
        {
            return mpz_get_ui(ref value.Value);
        }

        public static explicit operator short(mpz_t value)
        {
            return (short)(int)value;
        }

        public static explicit operator ushort(mpz_t value)
        {
            return (ushort)(uint)value;
        }

        public static explicit operator long(mpz_t value)
        {
            byte[] Bytes = new byte[8];

            mpz_import(ref value.Value, Bytes.LongLength, 0, sizeof(byte), 0, 0, Bytes);
            long Int64Result = BitConverter.ToInt64(Bytes, 0);

            return Int64Result;
        }

        public static explicit operator ulong(mpz_t value)
        {
            byte[] Bytes = new byte[8];

            mpz_import(ref value.Value, Bytes.LongLength, 0, sizeof(byte), 0, 0, Bytes);
            ulong UInt64Result = BitConverter.ToUInt64(Bytes, 0);

            return UInt64Result;
        }

        public static explicit operator float(mpz_t value)
        {
            return (float)(double)value;
        }

        public static explicit operator double(mpz_t value)
        {
            return mpz_get_d(ref value.Value);
        }

        public static explicit operator BigInteger(mpz_t value)
        {
            byte[] Bytes = value.ToByteArray();
            return new BigInteger(Bytes);
        }
        #endregion

        #region Operators
        public static mpz_t operator +(mpz_t x, mpz_t y)
        {
            mpz_t z = new();

            mpz_add(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpz_t operator +(mpz_t x, int y)
        {
            mpz_t z = new();

            if (y >= 0)
                mpz_add_ui(ref z.Value, ref x.Value, (uint)y);
            else
                mpz_sub_ui(ref z.Value, ref x.Value, (uint)(-y));

            return z;
        }

        public static mpz_t operator +(int x, mpz_t y)
        {
            mpz_t z = new();

            if (x >= 0)
                mpz_add_ui(ref z.Value, ref y.Value, (uint)x);
            else
                mpz_sub_ui(ref z.Value, ref y.Value, (uint)(-x));

            return z;
        }

        public static mpz_t operator +(mpz_t x, uint y)
        {
            mpz_t z = new mpz_t();

            mpz_add_ui(ref z.Value, ref x.Value, y);

            return z;
        }

        public static mpz_t operator +(uint x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_add_ui(ref z.Value, ref y.Value, x);

            return z;
        }

        public static mpz_t operator ++(mpz_t x)
        {
            using mpz_t z = new mpz_t();

            mpz_add_ui(ref z.Value, ref x.Value, 1);
            mpz_set(ref x.Value, ref z.Value);

            return x;
        }

        public static mpz_t operator -(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_sub(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpz_t operator -(int x, mpz_t y)
        {
            if (x >= 0)
            {
                mpz_t z = new mpz_t();

                mpz_ui_sub(ref z.Value, (uint)x, ref y.Value);

                return z;
            }
            else
            {
                mpz_t z = new mpz_t();

                mpz_add_ui(ref z.Value, ref y.Value, (uint)(-x));
                mpz_neg(ref z.Value, ref z.Value);

                return z;
            }
        }

        public static mpz_t operator -(mpz_t x, int y)
        {
            mpz_t z = new mpz_t();

            if (y >= 0)
                mpz_sub_ui(ref z.Value, ref x.Value, (uint)y);
            else
                mpz_add_ui(ref z.Value, ref x.Value, (uint)(-y));

            return z;
        }

        public static mpz_t operator -(uint x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_ui_sub(ref z.Value, x, ref y.Value);

            return z;
        }

        public static mpz_t operator -(mpz_t x, uint y)
        {
            mpz_t z = new mpz_t();

            mpz_sub_ui(ref z.Value, ref x.Value, y);

            return z;
        }

        public static mpz_t operator --(mpz_t x)
        {
            using mpz_t z = new mpz_t();

            mpz_sub_ui(ref z.Value, ref x.Value, 1);
            mpz_set(ref x.Value, ref z.Value);

            return x;
        }

        public static mpz_t operator *(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_mul(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpz_t operator *(int x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_mul_si(ref z.Value, ref y.Value, x);

            return z;
        }

        public static mpz_t operator *(mpz_t x, int y)
        {
            mpz_t z = new mpz_t();

            mpz_mul_si(ref z.Value, ref x.Value, y);

            return z;
        }

        public static mpz_t operator *(uint x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_mul_ui(ref z.Value, ref y.Value, x);

            return z;
        }

        public static mpz_t operator *(mpz_t x, uint y)
        {
            mpz_t z = new mpz_t();

            mpz_mul_ui(ref z.Value, ref x.Value, y);

            return z;
        }

        public static mpz_t operator <<(mpz_t x, int count)
        {
            mpz_t z = new mpz_t();

            if (count >= 0)
                mpz_mul_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

            return z;
        }

        public static mpz_t operator >>(mpz_t x, int count)
        {
            mpz_t z = new mpz_t();

            if (count >= 0)
                mpz_tdiv_q_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

            return z;
        }

        public static mpz_t operator -(mpz_t x)
        {
            mpz_t z = new mpz_t();

            mpz_neg(ref z.Value, ref x.Value);

            return z;
        }

        public static mpz_t operator /(mpz_t x, mpz_t y)
        {
            mpz_t quotient = new mpz_t();

            mpz_tdiv_q(ref quotient.Value, ref x.Value, ref y.Value);

            return quotient;
        }

        public static mpz_t operator /(mpz_t x, int y)
        {
            if (y >= 0)
            {
                mpz_t quotient = new mpz_t();

                mpz_tdiv_q_ui(ref quotient.Value, ref x.Value, (uint)y);

                return quotient;
            }
            else
            {
                mpz_t quotient = new mpz_t();

                mpz_tdiv_q_ui(ref quotient.Value, ref x.Value, (uint)(-y));
                mpz_neg(ref quotient.Value, ref quotient.Value);

                return quotient;
            }
        }

        public static mpz_t operator /(mpz_t x, uint y)
        {
            mpz_t quotient = new mpz_t();

            mpz_tdiv_q_ui(ref quotient.Value, ref x.Value, y);

            return quotient;
        }

        public static mpz_t operator %(mpz_t x, mpz_t mod)
        {
            mpz_t z = new mpz_t();

            mpz_mod(ref z.Value, ref x.Value, ref mod.Value);

            return z;
        }

        public static mpz_t operator %(mpz_t x, int mod)
        {
            if (mod < 0)
                throw new ArgumentOutOfRangeException(nameof(mod));

            mpz_t z = new mpz_t();

            mpz_fdiv_r_ui(ref z.Value, ref x.Value, (uint)mod);

            return z;
        }

        public static mpz_t operator %(mpz_t x, uint mod)
        {
            mpz_t z = new mpz_t();

            mpz_fdiv_r_ui(ref z.Value, ref x.Value, mod);

            return z;
        }

        public static bool operator <(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(int x, mpz_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpz_t x, int y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(uint x, mpz_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpz_t x, uint y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary < y;
        }

        public static bool operator <(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x < Temporary;
        }

        public static bool operator <(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary < y;
        }

        public static bool operator <(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x < Temporary;
        }

        public static bool operator <(float x, mpz_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpz_t x, float y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(double x, mpz_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpz_t x, double y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <=(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(int x, mpz_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpz_t x, int y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(uint x, mpz_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpz_t x, uint y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary <= y;
        }

        public static bool operator <=(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x <= Temporary;
        }

        public static bool operator <=(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary <= y;
        }

        public static bool operator <=(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x <= Temporary;
        }

        public static bool operator <=(float x, mpz_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpz_t x, float y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(double x, mpz_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpz_t x, double y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator >(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(int x, mpz_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpz_t x, int y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(uint x, mpz_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpz_t x, uint y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary > y;
        }

        public static bool operator >(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x > Temporary;
        }

        public static bool operator >(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary > y;
        }

        public static bool operator >(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x > Temporary;
        }

        public static bool operator >(float x, mpz_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpz_t x, float y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(double x, mpz_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpz_t x, double y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >=(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(int x, mpz_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpz_t x, int y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(uint x, mpz_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpz_t x, uint y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary >= y;
        }

        public static bool operator >=(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x >= Temporary;
        }

        public static bool operator >=(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return Temporary >= y;
        }

        public static bool operator >=(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x >= Temporary;
        }

        public static bool operator >=(float x, mpz_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpz_t x, float y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(double x, mpz_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpz_t x, double y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static mpz_t operator &(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_and(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpz_t operator |(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_ior(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpz_t operator ^(mpz_t x, mpz_t y)
        {
            mpz_t z = new mpz_t();

            mpz_xor(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpz_t operator ~(mpz_t x)
        {
            mpz_t z = new mpz_t();

            mpz_com(ref z.Value, ref x.Value);

            return z;
        }

        public static bool operator ==(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(int x, mpz_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpz_t x, int y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(uint x, mpz_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpz_t x, uint y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return y.CompareTo(Temporary) == 0;
        }

        public static bool operator ==(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x.CompareTo(Temporary) == 0;
        }

        public static bool operator ==(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return y.CompareTo(Temporary) == 0;
        }

        public static bool operator ==(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x.CompareTo(Temporary) == 0;
        }

        public static bool operator ==(float x, mpz_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpz_t x, float y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(double x, mpz_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpz_t x, double y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator !=(mpz_t x, mpz_t y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(int x, mpz_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpz_t x, int y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(uint x, mpz_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpz_t x, uint y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(long x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return y.CompareTo(Temporary) != 0;
        }

        public static bool operator !=(mpz_t x, long y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x.CompareTo(Temporary) != 0;
        }

        public static bool operator !=(ulong x, mpz_t y)
        {
            using mpz_t Temporary = new mpz_t(x);
            return y.CompareTo(Temporary) != 0;
        }

        public static bool operator !=(mpz_t x, ulong y)
        {
            using mpz_t Temporary = new mpz_t(y);
            return x.CompareTo(Temporary) != 0;
        }

        public static bool operator !=(float x, mpz_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpz_t x, float y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(double x, mpz_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpz_t x, double y)
        {
            return x.CompareTo(y) != 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj is mpz_t other)
                return CompareTo(other) != 0;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Convert.ToBase64String(ToByteArray()).GetHashCode();
        }
        #endregion

        #region Basic Arithmetic
        public mpz_t Abs()
        {
            mpz_t z = new mpz_t();

            mpz_abs(ref z.Value, ref Value);

            return z;
        }

        public int Sign
        {
            get { return mpz_sgn(ref Value); }
        }

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

        public mpz_t Quotient(uint y, Rounding rounding = Rounding.TowardZero)
        {
            mpz_t quotient = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_q_ui(ref quotient.Value, ref Value, y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_q_ui(ref quotient.Value, ref Value, y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_q_ui(ref quotient.Value, ref Value, y);
                    break;
            }

            return quotient;
        }

        public mpz_t Remainder(uint y, Rounding rounding = Rounding.TowardZero)
        {
            mpz_t remainder = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_r_ui(ref remainder.Value, ref Value, y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_r_ui(ref remainder.Value, ref Value, y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_r_ui(ref remainder.Value, ref Value, y);
                    break;
            }

            return remainder;
        }

        public static void Divide(mpz_t x, uint y, out mpz_t quotient, out mpz_t remainder, Rounding rounding = Rounding.TowardZero)
        {
            quotient = new mpz_t();
            remainder = new mpz_t();

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    mpz_tdiv_qr_ui(ref quotient.Value, ref remainder.Value, ref x.Value, y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    mpz_cdiv_qr_ui(ref quotient.Value, ref remainder.Value, ref x.Value, y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    mpz_fdiv_qr_ui(ref quotient.Value, ref remainder.Value, ref x.Value, y);
                    break;
            }
        }

        public uint AbsRemainder(uint y, Rounding rounding = Rounding.TowardZero)
        {
            uint remainder;

            switch (rounding)
            {
                default:
                case Rounding.TowardZero:
                    remainder = mpz_tdiv_ui(ref Value, y);
                    break;

                case Rounding.TowardPositiveInfinity:
                    remainder = mpz_cdiv_ui(ref Value, y);
                    break;

                case Rounding.TowardNegativeInfinity:
                    remainder = mpz_fdiv_ui(ref Value, y);
                    break;
            }

            return remainder;
        }

        public mpz_t RightShift(uint y, Rounding rounding = Rounding.TowardZero)
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

        public mpz_t RightShiftRemainder(uint y, Rounding rounding = Rounding.TowardZero)
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

        public mpz_t DivExact(mpz_t y)
        {
            mpz_t quotient = new mpz_t();

            mpz_divexact(ref quotient.Value, ref Value, ref y.Value);

            return quotient;
        }

        public mpz_t DivExact(uint y)
        {
            mpz_t quotient = new mpz_t();

            mpz_divexact_ui(ref quotient.Value, ref Value, y);

            return quotient;
        }

        public bool IsDivisible(mpz_t y)
        {
            return mpz_divisible_p(ref Value, ref y.Value) != 0;
        }

        public bool IsDivisible(uint y)
        {
            return mpz_divisible_ui_p(ref Value, y) != 0;
        }

        public bool IsDivisibleByPowerOfTwo(uint y)
        {
            return mpz_divisible_2exp_p(ref Value, (mp_bitcnt_t)y) != 0;
        }

        public bool IsCongruent(mpz_t c, mpz_t d)
        {
            return mpz_congruent_p(ref Value, ref c.Value, ref d.Value) != 0;
        }

        public bool IsCongruent(uint c, uint d)
        {
            return mpz_congruent_ui_p(ref Value, c, d) != 0;
        }

        public bool IsCongruentPowerOfTwo(mpz_t c, int d)
        {
            return mpz_congruent_2exp_p(ref Value, ref c.Value, (mp_bitcnt_t)(ulong)d) != 0;
        }

        public mpz_t PowerMod(mpz_t exp, mpz_t mod)
        {
            mpz_t Result = new mpz_t();

            mpz_powm(ref Result.Value, ref Value, ref exp.Value, ref mod.Value);

            return Result;
        }

        public mpz_t PowerMod(uint exp, mpz_t mod)
        {
            mpz_t Result = new mpz_t();

            mpz_powm_ui(ref Result.Value, ref Value, exp, ref mod.Value);

            return Result;
        }

        public mpz_t Pow(uint exp)
        {
            mpz_t Result = new mpz_t();

            mpz_pow_ui(ref Result.Value, ref Value, exp);

            return Result;
        }

        public bool IsRootExact(uint n)
        {
            using mpz_t Result = new mpz_t();

            return mpz_root(ref Result.Value, ref Value, n) != 0;
        }

        public mpz_t NthRoot(uint n)
        {
            mpz_t Result = new mpz_t();

            mpz_nthroot(ref Result.Value, ref Value, n);

            return Result;
        }

        public static void NthRoot(mpz_t x, uint n, out mpz_t root, out mpz_t remainder)
        {
            root = new mpz_t();
            remainder = new mpz_t();

            mpz_rootrem(ref root.Value, ref remainder.Value, ref x.Value, n);
        }

        public mpz_t Sqrt()
        {
            mpz_t Result = new mpz_t();

            mpz_sqrt(ref Result.Value, ref Value);

            return Result;
        }

        public static void SqrtRemainder(mpz_t x, out mpz_t root, out mpz_t remainder)
        {
            root = new mpz_t();
            remainder = new mpz_t();

            mpz_sqrtrem(ref root.Value, ref remainder.Value, ref x.Value);
        }

        public bool IsPerfectPower()
        {
            return mpz_perfect_power_p(ref Value) != 0;
        }

        public bool IsPerfectSquare()
        {
            return mpz_perfect_square_p(ref Value) != 0;
        }
        #endregion

        #region Comparison
        public int CompareTo(mpz_t? other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            else
                return mpz_cmp(ref Value, ref other.Value);
        }

        public int CompareTo(int other)
        {
            return mpz_cmp_si(ref Value, other);
        }

        public int CompareTo(uint other)
        {
            return mpz_cmp_ui(ref Value, other);
        }

        public int CompareTo(float other)
        {
            return mpz_cmp_d(ref Value, (double)other);
        }

        public int CompareTo(double other)
        {
            return mpz_cmp_d(ref Value, other);
        }
        #endregion

        #region Bitwise
        public void SetBit(ulong index)
        {
            mpz_setbit(ref Value, (mp_bitcnt_t)index);
        }

        public void ClearBit(ulong index)
        {
            mpz_clrbit(ref Value, (mp_bitcnt_t)index);
        }

        public void ComplementBit(ulong index)
        {
            mpz_combit(ref Value, (mp_bitcnt_t)index);
        }

        public void ChangeBit(ulong index, bool isSet)
        {
            if (isSet)
                mpz_setbit(ref Value, (mp_bitcnt_t)index);
            else
                mpz_clrbit(ref Value, (mp_bitcnt_t)index);
        }

        public bool GetBit(ulong index)
        {
            return mpz_tstbit(ref Value, (mp_bitcnt_t)index) != 0;
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

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Settings"/> class.
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
        public bool Equals(mpz_t? other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            else
                return mpz_cmp(ref Value, ref other.Value) == 0;
        }

        bool IEquatable<mpz_t>.Equals(mpz_t? other)
        {
            return this.Equals(other);
        }
        #endregion

        #region Implementation of ICloneable
        public object Clone()
        {
            return new mpz_t(this);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
        #endregion

        #region Implementation of IConvertible
        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        bool IConvertible.ToBoolean(IFormatProvider? provider)
        {
            return this.ToBoolean(provider);
        }

        public byte ToByte(IFormatProvider? provider)
        {
            return (byte)this;
        }

        byte IConvertible.ToByte(IFormatProvider? provider)
        {
            return this.ToByte(provider);
        }

        public char ToChar(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        char IConvertible.ToChar(IFormatProvider? provider)
        {
            return this.ToChar(provider);
        }

        public DateTime ToDateTime(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        DateTime IConvertible.ToDateTime(IFormatProvider? provider)
        {
            return this.ToDateTime(provider);
        }

        public decimal ToDecimal(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        decimal IConvertible.ToDecimal(IFormatProvider? provider)
        {
            return this.ToDecimal(provider);
        }

        public double ToDouble(IFormatProvider? provider)
        {
            return (double)this;
        }

        double IConvertible.ToDouble(IFormatProvider? provider)
        {
            return this.ToDouble(provider);
        }

        public short ToInt16(IFormatProvider? provider)
        {
            return (short)this;
        }

        short IConvertible.ToInt16(IFormatProvider? provider)
        {
            return this.ToInt16(provider);
        }

        public int ToInt32(IFormatProvider? provider)
        {
            return (int)this;
        }

        int IConvertible.ToInt32(IFormatProvider? provider)
        {
            return this.ToInt32(provider);
        }

        public long ToInt64(IFormatProvider? provider)
        {
            return (long)this;
        }

        long IConvertible.ToInt64(IFormatProvider? provider)
        {
            return this.ToInt64(provider);
        }

        public sbyte ToSByte(IFormatProvider? provider)
        {
            return (sbyte)this;
        }

        sbyte IConvertible.ToSByte(IFormatProvider? provider)
        {
            return this.ToSByte(provider);
        }

        public float ToSingle(IFormatProvider? provider)
        {
            return (float)this;
        }

        float IConvertible.ToSingle(IFormatProvider? provider)
        {
            return this.ToSingle(provider);
        }

        public string ToString(IFormatProvider? provider)
        {
            return this.ToString();
        }

        string IConvertible.ToString(IFormatProvider? provider)
        {
            return this.ToString(provider);
        }

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

        object IConvertible.ToType(Type targetType, IFormatProvider? provider)
        {
            return this.ToType(targetType, provider);
        }

        public ushort ToUInt16(IFormatProvider? provider)
        {
            return this.ToUInt16(provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider? provider)
        {
            return (ushort)this;
        }

        public uint ToUInt32(IFormatProvider? provider)
        {
            return (uint)this;
        }

        uint IConvertible.ToUInt32(IFormatProvider? provider)
        {
            return this.ToUInt32(provider);
        }

        public ulong ToUInt64(IFormatProvider? provider)
        {
            return (ulong)this;
        }

        ulong IConvertible.ToUInt64(IFormatProvider? provider)
        {
            return this.ToUInt64(provider);
        }
        #endregion

        #region Implementation of IComparable
        public int CompareTo(object? obj)
        {
            if (obj is mpz_t other)
                return CompareTo(other);
            else
                throw new ArgumentException();
        }

        int IComparable.CompareTo(object? obj)
        {
            return this.CompareTo(obj);
        }
        #endregion
    }
}
