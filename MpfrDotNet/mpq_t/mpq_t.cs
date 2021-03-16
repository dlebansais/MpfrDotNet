namespace MpirDotNet
{
    using System;
    using System.Text;
    using static NativeMethods;

    public class mpq_t : IDisposable, IEquatable<mpq_t>, ICloneable, IConvertible, IComparable, IComparable<mpq_t>
    {
        #region Init
        /// Initializes a new mpq_t to 0.
        public mpq_t()
        {
            mpq_init(ref Value);
        }

        public mpq_t(mpq_t other)
        {
            mpq_init(ref Value);
            mpq_set(ref Value, ref other.Value);
        }

        public mpq_t(mpf_t other)
        {
            mpq_init(ref Value);
            mpq_set_f(ref Value, ref other.Value);
        }

        public mpq_t(mpz_t other)
        {
            mpq_init(ref Value);
            mpq_set_z(ref Value, ref other.Value);
        }

        public mpq_t(uint n, uint d, bool canonicalize = false)
        {
            mpq_init(ref Value);
            mpq_set_ui(ref Value, n, d);

            if (canonicalize)
                mpq_canonicalize(ref Value);
        }

        public mpq_t(int n, uint d, bool canonicalize = false)
        {
            mpq_init(ref Value);
            mpq_set_si(ref Value, n, d);

            if (canonicalize)
                mpq_canonicalize(ref Value);
        }

        public mpq_t(double op)
        {
            mpq_init(ref Value);
            mpq_set_d(ref Value, op);
        }

        public mpq_t(mpz_t numerator, mpz_t denominator, bool canonicalize = false)
        {
            mpq_init(ref Value);
            mpq_set_num(ref Value, ref numerator.Value);
            mpq_set_den(ref Value, ref denominator.Value);

            if (canonicalize)
                mpq_canonicalize(ref Value);
        }

        public mpq_t(string s, bool canonicalize = false) : this(s, mpz_t.DefaultBase, canonicalize)
        {
        }

        public mpq_t(string s, int strBase, bool canonicalize = false)
        {
            mpq_init(ref Value);

            int Success = mpq_set_str(ref Value, s, strBase);
            if (Success != 0)
                throw new ArgumentException();

            if (canonicalize)
                mpq_canonicalize(ref Value);
        }

        internal __mpq_t Value;
        #endregion

        #region Conversions
        public override string ToString()
        {
            return ToString(mpz_t.DefaultBase);
        }

        public string ToString(int resultbase)
        {
            using mpz_t Numerator = new();
            mpq_get_num(ref Numerator.Value, ref Value);

            using mpz_t Denominator = new();
            mpq_get_den(ref Denominator.Value, ref Value);

            int SizeInDigits = (int)mpz_sizeinbase(ref Numerator.Value, (uint)resultbase) + (int)mpz_sizeinbase(ref Denominator.Value, (uint)resultbase);

            StringBuilder Data = new StringBuilder(SizeInDigits + 3);
            mpq_get_str(Data, resultbase, ref Value);

            string Result = Data.ToString();
            return Result;
        }

        public static implicit operator mpq_t(float value)
        {
            return new mpq_t((double)value);
        }

        public static implicit operator mpq_t(double value)
        {
            return new mpq_t(value);
        }

        public static explicit operator float(mpq_t value)
        {
            return (float)(double)value;
        }

        public static explicit operator double(mpq_t value)
        {
            return mpq_get_d(ref value.Value);
        }
        #endregion

        #region Operators
        public static mpq_t operator +(mpq_t x, mpq_t y)
        {
            mpq_t z = new mpq_t();

            mpq_add(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpq_t operator -(mpq_t x, mpq_t y)
        {
            mpq_t z = new mpq_t();

            mpq_sub(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpq_t operator *(mpq_t x, mpq_t y)
        {
            mpq_t z = new mpq_t();

            mpq_mul(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static mpq_t operator <<(mpq_t x, int count)
        {
            mpq_t z = new mpq_t();

            if (count >= 0)
                mpq_mul_2exp(ref z.Value, ref x.Value, (ulong)count);

            return z;
        }

        public static mpq_t operator >>(mpq_t x, int count)
        {
            mpq_t z = new mpq_t();

            if (count >= 0)
                mpq_div_2exp(ref z.Value, ref x.Value, (ulong)count);

            return z;
        }

        public static mpq_t operator -(mpq_t x)
        {
            mpq_t z = new mpq_t();

            mpq_neg(ref z.Value, ref x.Value);

            return z;
        }

        public static mpq_t operator /(mpq_t x, mpq_t y)
        {
            mpq_t z = new mpq_t();

            mpq_div(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        public static bool operator <(mpq_t x, mpq_t y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator <=(mpq_t x, mpq_t y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator >(mpq_t x, mpq_t y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator >=(mpq_t x, mpq_t y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator ==(mpq_t x, mpq_t y)
        {
            return x.IsEqualTo(y);
        }

        public static bool operator !=(mpq_t x, mpq_t y)
        {
            return !x.IsEqualTo(y);
        }

        public override bool Equals(object obj)
        {
            if (obj is mpq_t other)
                return IsEqualTo(other);
            else
                return false;
        }

        public override int GetHashCode()
        {
            using mpz_t Numerator = new();
            mpq_get_num(ref Numerator.Value, ref Value);

            using mpz_t Denominator = new();
            mpq_get_den(ref Denominator.Value, ref Value);

            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }
        #endregion

        #region Basic Arithmetic
        public mpq_t Abs()
        {
            mpq_t z = new mpq_t();

            mpq_abs(ref z.Value, ref Value);

            return z;
        }

        public mpq_t Inverse()
        {
            mpq_t z = new mpq_t();

            mpq_inv(ref z.Value, ref Value);

            return z;
        }
        #endregion

        #region Comparison
        public int CompareTo(mpq_t other)
        {
            return mpq_cmp(ref Value, ref other.Value);
        }

        public bool IsEqualTo(mpq_t other)
        {
            return mpq_equal(ref Value, ref other.Value) != 0;
        }
        #endregion

        #region Miscellaneous
        public void Canonicalize()
        {
            mpq_canonicalize(ref Value);
        }

        public int Sign
        {
            get { return mpq_sgn(ref Value); }
        }

        public mpz_t GetNumerator()
        {
            return new mpz_t(Value.Numerator);
        }

        public void SetNumerator(mpz_t numerator)
        {
            mpq_set_num(ref Value, ref numerator.Value);
        }

        public mpz_t GetDenominator()
        {
            return new mpz_t(Value.Denominator);
        }

        public void SetDenominator(mpz_t denominator)
        {
            mpq_set_den(ref Value, ref denominator.Value);
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
        ~mpq_t()
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
            mpq_clear(ref Value);
        }
        #endregion

        #region Implementation of IEquatable<mpq_t>
        public bool Equals(mpq_t other)
        {
            return mpq_cmp(ref Value, ref other.Value) == 0;
        }

        bool IEquatable<mpq_t>.Equals(mpq_t other)
        {
            return this.Equals(other);
        }
        #endregion

        #region Implementation of ICloneable
        public object Clone()
        {
            return new mpq_t(this);
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

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return this.ToBoolean(provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return (byte)this;
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return this.ToByte(provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return this.ToChar(provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return this.ToDateTime(provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return this.ToDecimal(provider);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return (double)this;
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return this.ToDouble(provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return (short)this;
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return this.ToInt16(provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return (int)this;
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return this.ToInt32(provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return (long)this;
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return this.ToInt64(provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return (sbyte)this;
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return this.ToSByte(provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return (float)this;
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return this.ToSingle(provider);
        }

        public string ToString(IFormatProvider provider)
        {
            return this.ToString();
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return this.ToString(provider);
        }

        public object ToType(Type targetType, IFormatProvider provider)
        {
            if (targetType == typeof(mpq_t))
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

        object IConvertible.ToType(Type targetType, IFormatProvider provider)
        {
            return this.ToType(targetType, provider);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return this.ToUInt16(provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return (ushort)this;
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return (uint)this;
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return this.ToUInt32(provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return (ulong)this;
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return this.ToUInt64(provider);
        }
        #endregion

        #region Implementation of IComparable
        public int CompareTo(object obj)
        {
            if (obj is mpq_t other)
                return CompareTo(other);
            else
                throw new ArgumentException();
        }

        int IComparable.CompareTo(object obj)
        {
            return this.CompareTo(obj);
        }
        #endregion
    }
}
