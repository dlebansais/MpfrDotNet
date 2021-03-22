namespace MpirDotNet
{
    using System;
    using System.Text;
    using static NativeMethods;

    public class mpf_t : IDisposable, IEquatable<mpf_t>, ICloneable, IConvertible, IComparable, IComparable<mpf_t>
    {
        #region Init
        // Initializes a new mpf_t to 0.
        public mpf_t(ulong precision = ulong.MaxValue)
        {
            if (precision == ulong.MaxValue)
                mpf_init(ref Value);
            else
                mpf_init2(ref Value, (mp_bitcnt_t)precision);
        }

        public mpf_t(uint n, ulong precision = ulong.MaxValue)
        {
            if (precision == ulong.MaxValue)
                mpf_init_set_ui(ref Value, n);
            else
            {
                mpf_init2(ref Value, (mp_bitcnt_t)precision);
                mpf_set_ui(ref Value, n);
            }
        }

        public mpf_t(int n, ulong precision = ulong.MaxValue)
        {
            if (precision == ulong.MaxValue)
                mpf_init_set_si(ref Value, n);
            else
            {
                mpf_init2(ref Value, (mp_bitcnt_t)precision);
                mpf_set_si(ref Value, n);
            }
        }

        public mpf_t(double d, ulong precision = ulong.MaxValue)
        {
            if (precision == ulong.MaxValue)
                mpf_init_set_d(ref Value, d);
            else
            {
                mpf_init2(ref Value, (mp_bitcnt_t)precision);
                mpf_set_d(ref Value, d);
            }
        }

        public mpf_t(string s, ulong precision = ulong.MaxValue)
            : this(s, mpz_t.DefaultBase, precision)
        {
        }

        public mpf_t(string s, uint strBase, ulong precision = ulong.MaxValue)
        {
            int Success;

            if (precision == ulong.MaxValue)
                Success = mpf_init_set_str(ref Value, s, strBase);
            else
            {
                mpf_init2(ref Value, (mp_bitcnt_t)precision);
                Success = mpf_set_str(ref Value, s, strBase);
            }

            if (Success != 0)
                throw new ArgumentException();
        }

        public mpf_t(mpf_t other, bool useDefaultPrecision = false)
        {
            if (useDefaultPrecision)
            {
                mpf_init_set(ref Value, ref other.Value);
            }
            else
            {
                mpf_init2(ref Value, mpf_get_prec(ref other.Value));
                mpf_set(ref Value, ref other.Value);
            }
        }

        internal __mpf_t Value;
        #endregion

        #region Properties
        public static ulong DefaultPrecision
        {
            get
            {
                return (ulong)mpf_get_default_prec();
            }
            set
            {
                mpf_set_default_prec((mp_bitcnt_t)value);
            }
        }

        public ulong Precision
        {
            get
            {
                return (ulong)mpf_get_prec(ref Value);
            }
            set
            {
                mpf_set_prec(ref Value, (mp_bitcnt_t)value);
            }
        }

        public bool IsInteger
        {
            get
            {
                return mpf_integer_p(ref Value) != 0;
            }
        }
        #endregion

        #region Conversions
        public override string ToString()
        {
            return ToString(mpz_t.DefaultBase);
        }

        public string ToString(int resultbase)
        {
            ulong SizeInDigits = Precision;

            StringBuilder Data = new StringBuilder((int)(SizeInDigits + 2));

            mp_exp_t ExponentStruct;
            mpf_get_str(Data, out ExponentStruct, resultbase, (size_t)SizeInDigits, ref Value);
            int Exponent = (int)ExponentStruct;

            string Result = Data.ToString();

            if (Result.Length == 0)
                return "0";

            int FractionalIndex = Result[0] == '-' ? 2 : 1;
            string IntegerPart = Result.Substring(0, FractionalIndex);

            string FractionalPart = Result.Substring(FractionalIndex);
            if (FractionalPart.Length > 0)
                FractionalPart = "." + FractionalPart;

            string ExponentPart = (Exponent - 1).ToString();
            if (Exponent > 0)
                ExponentPart = "+" + ExponentPart;

            Result = $"{IntegerPart}{FractionalPart}E{ExponentPart}";

            return Result;
        }

        public static implicit operator mpf_t(uint value)
        {
            return new mpf_t(value);
        }

        public static implicit operator mpf_t(int value)
        {
            return new mpf_t(value);
        }

        public static implicit operator mpf_t(float value)
        {
            return new mpf_t((double)value);
        }

        public static implicit operator mpf_t(double value)
        {
            return new mpf_t(value);
        }

        public static explicit operator uint(mpf_t value)
        {
            return (uint)mpf_get_ui(ref value.Value);
        }

        public static explicit operator int(mpf_t value)
        {
            return (int)mpf_get_si(ref value.Value);
        }

        public static explicit operator ulong(mpf_t value)
        {
            return (ulong)mpf_get_ui(ref value.Value);
        }

        public static explicit operator long(mpf_t value)
        {
            return mpf_get_si(ref value.Value);
        }

        public static explicit operator float(mpf_t value)
        {
            return (float)(double)value;
        }

        public static explicit operator double(mpf_t value)
        {
            return mpf_get_d(ref value.Value);
        }
        #endregion

        #region Operators
        public static mpf_t operator +(mpf_t x, mpf_t y)
        {
            mpf_t z = new();

            mpf_add(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpf_t operator +(mpf_t x, int y)
        {
            mpf_t z = new();

            if (y >= 0)
                mpf_add_ui(ref z.Value, ref x.Value, (uint)y);
            else
                mpf_sub_ui(ref z.Value, ref x.Value, (uint)(-y));

            return z;
        }

        public static mpf_t operator +(int x, mpf_t y)
        {
            mpf_t z = new();

            if (x >= 0)
                mpf_add_ui(ref z.Value, ref y.Value, (uint)x);
            else
                mpf_sub_ui(ref z.Value, ref y.Value, (uint)(-x));

            return z;
        }

        public static mpf_t operator +(mpf_t x, uint y)
        {
            mpf_t z = new mpf_t();

            mpf_add_ui(ref z.Value, ref x.Value, y);

            return z;
        }

        public static mpf_t operator +(uint x, mpf_t y)
        {
            mpf_t z = new mpf_t();

            mpf_add_ui(ref z.Value, ref y.Value, x);

            return z;
        }

        public static mpf_t operator -(mpf_t x, mpf_t y)
        {
            mpf_t z = new mpf_t();

            mpf_sub(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpf_t operator -(int x, mpf_t y)
        {
            if (x >= 0)
            {
                mpf_t z = new mpf_t();

                mpf_ui_sub(ref z.Value, (uint)x, ref y.Value);

                return z;
            }
            else
            {
                mpf_t z = new mpf_t();

                mpf_add_ui(ref z.Value, ref y.Value, (uint)(-x));
                mpf_neg(ref z.Value, ref z.Value);

                return z;
            }
        }

        public static mpf_t operator -(mpf_t x, int y)
        {
            mpf_t z = new mpf_t();

            if (y >= 0)
                mpf_sub_ui(ref z.Value, ref x.Value, (uint)y);
            else
                mpf_add_ui(ref z.Value, ref x.Value, (uint)(-y));

            return z;
        }

        public static mpf_t operator -(uint x, mpf_t y)
        {
            mpf_t z = new mpf_t();

            mpf_ui_sub(ref z.Value, x, ref y.Value);

            return z;
        }

        public static mpf_t operator -(mpf_t x, uint y)
        {
            mpf_t z = new mpf_t();

            mpf_sub_ui(ref z.Value, ref x.Value, y);

            return z;
        }

        public static mpf_t operator *(mpf_t x, mpf_t y)
        {
            mpf_t z = new mpf_t();

            mpf_mul(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpf_t operator *(uint x, mpf_t y)
        {
            mpf_t z = new mpf_t();

            mpf_mul_ui(ref z.Value, ref y.Value, x);

            return z;
        }

        public static mpf_t operator *(mpf_t x, uint y)
        {
            mpf_t z = new mpf_t();

            mpf_mul_ui(ref z.Value, ref x.Value, y);

            return z;
        }

        public static mpf_t operator <<(mpf_t x, int count)
        {
            mpf_t z = new mpf_t();

            if (count >= 0)
                mpf_mul_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

            return z;
        }

        public static mpf_t operator >>(mpf_t x, int count)
        {
            mpf_t z = new mpf_t();

            if (count >= 0)
                mpf_div_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

            return z;
        }

        public static mpf_t operator -(mpf_t x)
        {
            mpf_t z = new mpf_t();

            mpf_neg(ref z.Value, ref x.Value);

            return z;
        }

        public static mpf_t operator /(mpf_t x, mpf_t y)
        {
            mpf_t quotient = new mpf_t();

            mpf_div(ref quotient.Value, ref x.Value, ref y.Value);

            return quotient;
        }

        public static mpf_t operator /(mpf_t x, uint y)
        {
            mpf_t quotient = new mpf_t();

            mpf_div_ui(ref quotient.Value, ref x.Value, y);

            return quotient;
        }

        public static mpf_t operator /(uint x, mpf_t y)
        {
            mpf_t quotient = new mpf_t();

            mpf_ui_div(ref quotient.Value, x, ref y.Value);

            return quotient;
        }

        public static bool operator <(mpf_t x, mpf_t y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(int x, mpf_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpf_t x, int y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(uint x, mpf_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpf_t x, uint y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(float x, mpf_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpf_t x, float y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <(double x, mpf_t y)
        {
            return y.CompareTo(x) > 0;
        }

        public static bool operator <(mpf_t x, double y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <=(mpf_t x, mpf_t y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(int x, mpf_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpf_t x, int y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(uint x, mpf_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpf_t x, uint y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(float x, mpf_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpf_t x, float y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator <=(double x, mpf_t y)
        {
            return y.CompareTo(x) >= 0;
        }

        public static bool operator <=(mpf_t x, double y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator >(mpf_t x, mpf_t y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(int x, mpf_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpf_t x, int y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(uint x, mpf_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpf_t x, uint y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(float x, mpf_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpf_t x, float y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >(double x, mpf_t y)
        {
            return y.CompareTo(x) < 0;
        }

        public static bool operator >(mpf_t x, double y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >=(mpf_t x, mpf_t y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(int x, mpf_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpf_t x, int y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(uint x, mpf_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpf_t x, uint y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(float x, mpf_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpf_t x, float y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator >=(double x, mpf_t y)
        {
            return y.CompareTo(x) <= 0;
        }

        public static bool operator >=(mpf_t x, double y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator ==(mpf_t x, mpf_t y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(int x, mpf_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpf_t x, int y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(uint x, mpf_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpf_t x, uint y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(float x, mpf_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpf_t x, float y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator ==(double x, mpf_t y)
        {
            return y.CompareTo(x) == 0;
        }

        public static bool operator ==(mpf_t x, double y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator !=(mpf_t x, mpf_t y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(int x, mpf_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpf_t x, int y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(uint x, mpf_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpf_t x, uint y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(float x, mpf_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpf_t x, float y)
        {
            return x.CompareTo(y) != 0;
        }

        public static bool operator !=(double x, mpf_t y)
        {
            return y.CompareTo(x) != 0;
        }

        public static bool operator !=(mpf_t x, double y)
        {
            return x.CompareTo(y) != 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj is mpf_t other)
                return CompareTo(other) != 0;
            else
                return false;
        }

        public override int GetHashCode()
        {
            ulong SizeInDigits = 5;
            StringBuilder Data = new StringBuilder((int)(SizeInDigits + 2));

            mp_exp_t ExponentStruct;
            mpf_get_str(Data, out ExponentStruct, mpz_t.DefaultBase, (size_t)SizeInDigits, ref Value);

            return Data.ToString().GetHashCode();
        }
        #endregion

        #region Basic Arithmetic
        public mpf_t Abs()
        {
            mpf_t z = new mpf_t();

            mpf_abs(ref z.Value, ref Value);

            return z;
        }

        public int Sign
        {
            get { return mpf_sgn(ref Value); }
        }

        public mpf_t Sqrt()
        {
            mpf_t Result = new mpf_t();

            mpf_sqrt(ref Result.Value, ref Value);

            return Result;
        }

        public mpf_t Pow(uint exp)
        {
            mpf_t Result = new mpf_t();

            mpf_pow_ui(ref Result.Value, ref Value, exp);

            return Result;
        }
        #endregion

        #region Comparison
        public int CompareTo(mpf_t? other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            else
                return mpf_cmp(ref Value, ref other.Value);
        }

        public int CompareTo(int other)
        {
            return mpf_cmp_si(ref Value, other);
        }

        public int CompareTo(uint other)
        {
            return mpf_cmp_ui(ref Value, other);
        }

        public int CompareTo(float other)
        {
            return mpf_cmp_d(ref Value, (double)other);
        }

        public int CompareTo(double other)
        {
            return mpf_cmp_d(ref Value, other);
        }
        #endregion

        #region Rounding
        public mpf_t Ceil()
        {
            mpf_t z = new mpf_t(Precision);

            mpf_ceil(ref z.Value, ref Value);

            return z;
        }

        public mpf_t Floor()
        {
            mpf_t z = new mpf_t(Precision);

            mpf_floor(ref z.Value, ref Value);

            return z;
        }

        public mpf_t Trunc()
        {
            mpf_t z = new mpf_t(Precision);

            mpf_trunc(ref z.Value, ref Value);

            return z;
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
        /// Finalizes an instance of the <see cref="Settings"/> class.
        /// </summary>
        ~mpf_t()
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
            mpf_clear(ref Value);
        }
        #endregion

        #region Implementation of IEquatable<mpf_t>
        public bool Equals(mpf_t? other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            else
                return mpf_cmp(ref Value, ref other.Value) == 0;
        }

        bool IEquatable<mpf_t>.Equals(mpf_t? other)
        {
            return this.Equals(other);
        }
        #endregion

        #region Implementation of ICloneable
        public object Clone()
        {
            return new mpf_t(this);
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
            return (byte)(int)this;
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
            return (short)(int)this;
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
            if (targetType == typeof(mpf_t))
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
            return (ushort)(uint)this;
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
            if (obj is mpf_t other)
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
