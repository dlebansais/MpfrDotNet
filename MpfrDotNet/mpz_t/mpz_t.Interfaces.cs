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

            // Native memory is not managed by the garbage collector, so the finalizer releases it as well.
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
    /// Throws if a number has been disposed, since its native memory is then released.
    /// </summary>
    /// <param name="value">The number, or <see langword="null"/>, which is left to the caller to check.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    internal static void ThrowIfDisposed(mpz_t? value)
    {
        if (value is not null && value.IsDisposed)
            throw new ObjectDisposedException(nameof(mpz_t));
    }

    /// <summary>
    /// Disposes of every reference that must be cleaned up.
    /// </summary>
    private void DisposeNow()
    {
        // A constructor that throws before initializing the number leaves no native memory to release.
        if (Value.Limbs != IntPtr.Zero)
            mpz.clear(this);
    }
    #endregion

    #region Implementation of IEquatable<mpz_t>
    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    public bool Equals(mpz_t? other)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(other);

        return other is not null && mpz.cmp(this, other) == 0;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    bool IEquatable<mpz_t>.Equals(mpz_t? other)
    {
        return this.Equals(other);
    }
    #endregion

    #region Implementation of ICloneable
    /// <summary>
    /// Creates a copy of the object.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public object Clone()
    {
        return new mpz_t(this);
    }

    /// <summary>
    /// Creates a copy of the object.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    object ICloneable.Clone()
    {
        return this.Clone();
    }
    #endregion

    #region Implementation of IConvertible
    /// <summary>
    /// Returns the <see cref="TypeCode"/> for this instance.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    TypeCode IConvertible.GetTypeCode()
    {
        ThrowIfDisposed(this);

        return TypeCode.Object;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="bool"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
#pragma warning disable CA1822
    public bool ToBoolean(IFormatProvider? provider)
#pragma warning restore CA1822
    {
        ThrowIfDisposed(this);

        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="bool"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    bool IConvertible.ToBoolean(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="byte"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public byte ToByte(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return (byte)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="byte"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    byte IConvertible.ToByte(IFormatProvider? provider)
    {
        return ToByte(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="char"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
#pragma warning disable CA1822
    public char ToChar(IFormatProvider? provider)
#pragma warning restore CA1822
    {
        ThrowIfDisposed(this);

        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="char"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    char IConvertible.ToChar(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
#pragma warning disable CA1822
    public DateTime ToDateTime(IFormatProvider? provider)
#pragma warning restore CA1822
    {
        ThrowIfDisposed(this);

        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    DateTime IConvertible.ToDateTime(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="decimal"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
#pragma warning disable CA1822
    public decimal ToDecimal(IFormatProvider? provider)
#pragma warning restore CA1822
    {
        ThrowIfDisposed(this);

        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="decimal"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    decimal IConvertible.ToDecimal(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="double"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public double ToDouble(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return (double)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="double"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    double IConvertible.ToDouble(IFormatProvider? provider)
    {
        return ToDouble(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="short"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public short ToInt16(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return (short)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="short"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    short IConvertible.ToInt16(IFormatProvider? provider)
    {
        return ToInt16(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="int"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int ToInt32(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return (int)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="int"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    int IConvertible.ToInt32(IFormatProvider? provider)
    {
        return ToInt32(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="long"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public long ToInt64(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return (long)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="long"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    long IConvertible.ToInt64(IFormatProvider? provider)
    {
        return ToInt64(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="sbyte"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public sbyte ToSByte(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return checked((sbyte)(short)this);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="sbyte"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    sbyte IConvertible.ToSByte(IFormatProvider? provider)
    {
        return ToSByte(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="float"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public float ToSingle(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return (float)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="float"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    float IConvertible.ToSingle(IFormatProvider? provider)
    {
        return ToSingle(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="string"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public string ToString(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return ToString();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="string"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    string IConvertible.ToString(IFormatProvider? provider)
    {
        return ToString(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an object of the specified type.
    /// </summary>
    /// <param name="targetType">The type to which the value of this instance is converted.</param>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public object ToType(Type targetType, IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

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
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    object IConvertible.ToType(Type targetType, IFormatProvider? provider)
    {
        return ToType(targetType, provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="ushort"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public ushort ToUInt16(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return (ushort)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="ushort"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    ushort IConvertible.ToUInt16(IFormatProvider? provider)
    {
        return ToUInt16(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="uint"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public uint ToUInt32(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return (uint)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="uint"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    uint IConvertible.ToUInt32(IFormatProvider? provider)
    {
        return ToUInt32(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="ulong"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public ulong ToUInt64(IFormatProvider? provider)
    {
        ThrowIfDisposed(this);

        return (ulong)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="ulong"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    ulong IConvertible.ToUInt64(IFormatProvider? provider)
    {
        return ToUInt64(provider);
    }
    #endregion

    #region Implementation of IComparable
    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns>A positive value if <paramref name="obj"/> is <see langword="null"/>, as with other .NET types.</returns>
    /// <exception cref="ArgumentException"><paramref name="obj"/> is not an <see cref="mpz_t"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(object? obj)
    {
        ThrowIfDisposed(this);

        if (obj is null)
            return 1;
        else if (obj is mpz_t other)
            return CompareTo(other);
        else
            throw new ArgumentException("Invalid comparison with an object of a different type.", nameof(obj));
    }

    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    int IComparable.CompareTo(object? obj)
    {
        return CompareTo(obj);
    }
    #endregion
}
