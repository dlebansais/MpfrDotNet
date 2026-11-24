namespace MpirDotNet;

using System;

/// <summary>
/// Checks the arrays passed to functions that process several values.
/// </summary>
internal static class ArrayArgument
{
    /// <summary>
    /// Checks that an array and all its items are not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    /// <param name="array">The array.</param>
    /// <param name="paramName">The name of the parameter that holds the array.</param>
    /// <exception cref="ArgumentNullException"><paramref name="array"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="array"/> contains a <see langword="null"/> item.</exception>
    public static void CheckItems<T>(T[] array, string paramName)
        where T : class
    {
        if (array is null)
            throw new ArgumentNullException(paramName);

        foreach (T Item in array)
            if (Item is null)
                throw new ArgumentException("The array cannot contain a null item.", paramName);
    }
}
