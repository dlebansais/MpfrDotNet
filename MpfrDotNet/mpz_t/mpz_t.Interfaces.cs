namespace MpirDotNet;

using System;
using System.Numerics;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision integer.
/// </summary>
public partial class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
{
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
