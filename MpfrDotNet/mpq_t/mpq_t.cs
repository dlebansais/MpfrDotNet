namespace MpirDotNet
{
    using System;
    using System.Text;
    using static Interop.Mpir.NativeMethods;

    /// <summary>
    /// Arbitrary precision rational number.
    /// </summary>
    public class mpq_t : IDisposable, IEquatable<mpq_t>, ICloneable, IConvertible, IComparable, IComparable<mpq_t>
    {
        #region Init
        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        public mpq_t()
        {
            mpq_init(ref Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        /// <param name="other">The other instance.</param>
        public mpq_t(mpq_t other)
        {
            mpq_init(ref Value);
            mpq_set(ref Value, ref other.Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        /// <param name="source">The source instance.</param>
        public mpq_t(mpf_t source)
        {
            mpq_init(ref Value);
            mpq_set_f(ref Value, ref source.Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        /// <param name="source">The source instance.</param>
        public mpq_t(mpz_t source)
        {
            mpq_init(ref Value);
            mpq_set_z(ref Value, ref source.Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
        public mpq_t(ulong numerator, ulong denominator, bool canonicalize = false)
        {
            mpq_init(ref Value);
            mpq_set_ui(ref Value, (mpir_ui)numerator, (mpir_ui)denominator);

            if (canonicalize)
                mpq_canonicalize(ref Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
        public mpq_t(long numerator, ulong denominator, bool canonicalize = false)
        {
            mpq_init(ref Value);
            mpq_set_si(ref Value, (mpir_si)numerator, (mpir_ui)denominator);

            if (canonicalize)
                mpq_canonicalize(ref Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        /// <param name="op">The value.</param>
        public mpq_t(double op)
        {
            mpq_init(ref Value);
            mpq_set_d(ref Value, op);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
        public mpq_t(mpz_t numerator, mpz_t denominator, bool canonicalize = false)
        {
            mpq_init(ref Value);
            mpq_set_num(ref Value, ref numerator.Value);
            mpq_set_den(ref Value, ref denominator.Value);

            if (canonicalize)
                mpq_canonicalize(ref Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        /// <param name="text">The value text.</param>
        /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
        public mpq_t(string text, bool canonicalize = false)
            : this(text, mpz_t.DefaultBase, canonicalize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpq_t"/> class.
        /// </summary>
        /// <param name="text">The value text.</param>
        /// <param name="strBase">The digit base.</param>
        /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
        public mpq_t(string text, int strBase, bool canonicalize = false)
        {
            mpq_init(ref Value);

            int Success = mpq_set_str(ref Value, text, strBase);
            if (Success != 0)
                throw new ArgumentException();

            if (canonicalize)
                mpq_canonicalize(ref Value);
        }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
        internal __mpq_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
        #endregion

        #region Conversions
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return ToString(mpz_t.DefaultBase);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <param name="resultbase">The digit base.</param>
        public string ToString(int resultbase)
        {
            using mpz_t Numerator = new();
            mpq_get_num(ref Numerator.Value, ref Value);

            using mpz_t Denominator = new();
            mpq_get_den(ref Denominator.Value, ref Value);

            ulong SizeInDigits = (ulong)mpz_sizeinbase(ref Numerator.Value, (uint)resultbase) + (ulong)mpz_sizeinbase(ref Denominator.Value, (uint)resultbase);

            StringBuilder Data = new StringBuilder((int)(SizeInDigits + 3));
            mpq_get_str(Data, resultbase, ref Value);

            string Result = Data.ToString();
            return Result;
        }

        /// <summary>
        /// Converts from a <see cref="float"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpq_t(float value)
        {
            return new mpq_t((double)value);
        }

        /// <summary>
        /// Converts from a <see cref="double"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator mpq_t(double value)
        {
            return new mpq_t(value);
        }

        /// <summary>
        /// Converts to a <see cref="float"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator float(mpq_t value)
        {
            return (float)(double)value;
        }

        /// <summary>
        /// Converts to a <see cref="double"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator double(mpq_t value)
        {
            return mpq_get_d(ref value.Value);
        }
        #endregion

        #region Operators
        /// <summary>
        /// Adds two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpq_t operator +(mpq_t x, mpq_t y)
        {
            mpq_t z = new mpq_t();

            mpq_add(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Subtracts two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpq_t operator -(mpq_t x, mpq_t y)
        {
            mpq_t z = new mpq_t();

            mpq_sub(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Multiplies two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpq_t operator *(mpq_t x, mpq_t y)
        {
            mpq_t z = new mpq_t();

            mpq_mul(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Shifts a number to the left.
        /// </summary>
        /// <param name="x">The operand.</param>
        /// <param name="count">The number of bits to shift.</param>
        public static mpq_t operator <<(mpq_t x, int count)
        {
            mpq_t z = new mpq_t();

            if (count >= 0)
                mpq_mul_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

            return z;
        }

        /// <summary>
        /// Shifts a number to the right.
        /// </summary>
        /// <param name="x">The operand.</param>
        /// <param name="count">The number of bits to shift.</param>
        public static mpq_t operator >>(mpq_t x, int count)
        {
            mpq_t z = new mpq_t();

            if (count >= 0)
                mpq_div_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

            return z;
        }

        /// <summary>
        /// Negates a number.
        /// </summary>
        /// <param name="x">The number.</param>
        public static mpq_t operator -(mpq_t x)
        {
            mpq_t z = new mpq_t();

            mpq_neg(ref z.Value, ref x.Value);

            return z;
        }

        /// <summary>
        /// Divides two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpq_t operator /(mpq_t x, mpq_t y)
        {
            mpq_t z = new mpq_t();

            mpq_div(ref z.Value, ref x.Value, ref y.Value);

            return z;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <(mpq_t x, mpq_t y)
        {
            return x.CompareTo(y) < 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator <=(mpq_t x, mpq_t y)
        {
            return x.CompareTo(y) <= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >(mpq_t x, mpq_t y)
        {
            return x.CompareTo(y) > 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator >=(mpq_t x, mpq_t y)
        {
            return x.CompareTo(y) >= 0;
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator ==(mpq_t x, mpq_t y)
        {
            return x.IsEqualTo(y);
        }

        /// <summary>
        /// Compares two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool operator !=(mpq_t x, mpq_t y)
        {
            return !x.IsEqualTo(y);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object..</param>
        public override bool Equals(object? obj)
        {
            if (obj is mpq_t other)
                return IsEqualTo(other);
            else
                return false;
        }

        /// <summary>
        /// Gets the hash of the object.
        /// </summary>
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
        /// <summary>
        /// Gets the absolute value of the number.
        /// </summary>
        public mpq_t Abs()
        {
            mpq_t z = new mpq_t();

            mpq_abs(ref z.Value, ref Value);

            return z;
        }

        /// <summary>
        /// Gets the inverse of the number.
        /// </summary>
        public mpq_t Inverse()
        {
            mpq_t z = new mpq_t();

            mpq_inv(ref z.Value, ref Value);

            return z;
        }
        #endregion

        #region Comparison
        /// <summary>
        /// Compares with another number.
        /// </summary>
        /// <param name="other">The other number.</param>
        public int CompareTo(mpq_t? other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            else
                return mpq_cmp(ref Value, ref other.Value);
        }

        /// <summary>
        /// Compares with another number.
        /// </summary>
        /// <param name="other">The other number.</param>
        public bool IsEqualTo(mpq_t other)
        {
            return mpq_equal(ref Value, ref other.Value) != 0;
        }
        #endregion

        #region Miscellaneous
        /// <summary>
        /// Canonicalize the number.
        /// </summary>
        public void Canonicalize()
        {
            mpq_canonicalize(ref Value);
        }

        /// <summary>
        /// Gets the number sign.
        /// </summary>
        public int Sign
        {
            get { return mpq_sgn(ref Value); }
        }

        /// <summary>
        /// Gets the number numerator.
        /// </summary>
        public mpz_t GetNumerator()
        {
            return new mpz_t(Value.Numerator);
        }

        /// <summary>
        /// Sets the number numerator.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        public void SetNumerator(mpz_t numerator)
        {
            mpq_set_num(ref Value, ref numerator.Value);
        }

        /// <summary>
        /// Gets the number denominator.
        /// </summary>
        public mpz_t GetDenominator()
        {
            return new mpz_t(Value.Denominator);
        }

        /// <summary>
        /// Sets the number denominator.
        /// </summary>
        /// <param name="denominator">The denominator.</param>
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
        /// Finalizes an instance of the <see cref="mpq_t"/> class.
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
        /// <summary>
        /// Compares with another number.
        /// </summary>
        /// <param name="other">The other number.</param>
        public bool Equals(mpq_t? other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            else
                return mpq_cmp(ref Value, ref other.Value) == 0;
        }

        /// <summary>
        /// Compares with another number.
        /// </summary>
        /// <param name="other">The other number.</param>
        bool IEquatable<mpq_t>.Equals(mpq_t? other)
        {
            return this.Equals(other);
        }
        #endregion

        #region Implementation of ICloneable
        /// <summary>
        /// Gets a clone of the object.
        /// </summary>
        public object Clone()
        {
            return new mpq_t(this);
        }

        /// <summary>
        /// Gets a clone of the object.
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
        /// Converts the value of this instance to an equivalent <see cref="decimal"/> value.
        /// </summary>
        /// <param name="provider">Culture-specific formatting information.</param>
        public double ToDouble(IFormatProvider? provider)
        {
            return (double)this;
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="decimal"/> value.
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
            if (obj is mpq_t other)
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
