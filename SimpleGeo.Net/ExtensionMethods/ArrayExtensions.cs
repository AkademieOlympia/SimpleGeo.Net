// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayExtensions.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines Extension Methods for the Array (object[]) type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net.ExtensionMethods
{
    using System;

    /// <summary>
    /// Defines Extension Methods for the Array (object[]) type.
    /// </summary>
    internal static class ArrayExtensions
    {
        /// <summary>
        /// Gets the value at the specified position in the multidimensional System.Array. The indexes are specified as an array of 32-bit integers.
        /// </summary>
        /// <typeparam name="T">The Type to convert the value to.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="indices">A one-dimensional array of 32-bit integers that represent the indexes specifying the position of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the one-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static T TryGetValue<T>(this Array value, params int[] indices) where T : class
        {
            try
            {
                return (T)value.GetValue(indices);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the value at the specified position in the multidimensional System.Array. The indexes are specified as an array of 32-bit integers.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="indices">A one-dimensional array of 32-bit integers that represent the indexes specifying the position of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the one-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static object TryGetValue(this Array value, params int[] indices)
        {
            return value.TryGetValue<object>(indices);
        }

        /// <summary>
        /// Gets the value at the specified position in the multidimensional System.Array. The indexes are specified as an array of 64-bit integers.
        /// </summary>
        /// <typeparam name="T">The Type to convert the value to.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="indices">A one-dimensional array of 64-bit integers that represent the indexes specifying the position of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the one-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static T TryGetValue<T>(this Array value, params long[] indices) where T : class
        {
            try
            {
                return (T)value.GetValue(indices);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the value at the specified position in the multidimensional System.Array. The indexes are specified as an array of 64-bit integers.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="indices">A one-dimensional array of 64-bit integers that represent the indexes specifying the position of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the one-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static object TryGetValue(this Array value, params long[] indices)
        {
            return value.TryGetValue<object>(indices);
        }

        /// <summary>
        /// Gets the value at the specified position in the one-dimensional System.Array. The index is specified as a 32-bit integer.
        /// </summary>
        /// <typeparam name="T">The Type to convert the value to.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="index">A 32-bit integer that represents the position of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the one-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static T TryGetValue<T>(this Array value, int index) where T : class
        {
            try
            {
                return (T)value.GetValue(index);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the value at the specified position in the one-dimensional System.Array. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="index">A 32-bit integer that represents the position of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the one-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static object TryGetValue(this Array value, int index)
        {
            return value.TryGetValue<object>(index);
        }

        /// <summary>
        /// Gets the value at the specified position in the two-dimensional System.Array. The index is specified as a 32-bit integer.
        /// </summary>
        /// <typeparam name="T">The Type to convert the value to.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="index1">A 32-bit integer that represents the first-dimension index of the System.Array element to get.</param>
        /// <param name="index2">A 32-bit integer that represents the second-dimension index of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the two-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static T TryGetValue<T>(this Array value, int index1, int index2) where T : class
        {
            try
            {
                return (T)value.GetValue(index1, index2);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the value at the specified position in the two-dimensional System.Array. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="index1">A 32-bit integer that represents the first-dimension index of the System.Array element to get.</param>
        /// <param name="index2">A 32-bit integer that represents the second-dimension index of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the two-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static object TryGetValue(this Array value, int index1, int index2)
        {
            return value.TryGetValue<object>(index1, index2);
        }

        /// <summary>
        /// Gets the value at the specified position in the three-dimensional System.Array. The index is specified as a 32-bit integer.
        /// </summary>
        /// <typeparam name="T">The Type to convert the value to.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="index1">A 32-bit integer that represents the first-dimension index of the System.Array element to get.</param>
        /// <param name="index2">A 32-bit integer that represents the second-dimension index of the System.Array element to get.</param>
        /// <param name="index3">A 32-bit integer that represents the third-dimension index of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the two-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static T TryGetValue<T>(this Array value, int index1, int index2, int index3) where T : class
        {
            try
            {
                return (T)value.GetValue(index1, index2, index3);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the value at the specified position in the three-dimensional System.Array. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="index1">A 32-bit integer that represents the first-dimension index of the System.Array element to get.</param>
        /// <param name="index2">index2: A 32-bit integer that represents the second-dimension index of the System.Array element to get.</param>
        /// <param name="index3">A 32-bit integer that represents the third-dimension index of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the two-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static object TryGetValue(this Array value, int index1, int index2, int index3)
        {
            return value.TryGetValue<object>(index1, index2, index3);
        }

        /// <summary>
        /// Gets the value at the specified position in the one-dimensional System.Array. The index is specified as a 64-bit integer.
        /// </summary>
        /// <typeparam name="T">The Type to convert the value to.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="index">A 64-bit integer that represents the position of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the one-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static T TryGetValue<T>(this Array value, long index) where T : class
        {
            try
            {
                return (T)value.GetValue(index);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the value at the specified position in the one-dimensional System.Array. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="index">A 32-bit integer that represents the position of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the one-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static object TryGetValue(this Array value, long index)
        {
            return value.TryGetValue<object>(index);
        }

        /// <summary>
        /// Gets the value at the specified position in the two-dimensional System.Array. The index is specified as a 64-bit integer.
        /// </summary>
        /// <typeparam name="T">The Type to convert the value to.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="index1">A 64-bit integer that represents the first-dimension index of the System.Array element to get.</param>
        /// <param name="index2">A 64-bit integer that represents the second-dimension index of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the two-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static T TryGetValue<T>(this Array value, long index1, long index2) where T : class
        {
            try
            {
                return (T)value.GetValue(index1, index2);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the value at the specified position in the two-dimensional System.Array. The index is specified as a 64-bit integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="index1">A 64-bit integer that represents the first-dimension index of the System.Array element to get.</param>
        /// <param name="index2">A 64-bit integer that represents the second-dimension index of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the two-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static object TryGetValue(this Array value, long index1, long index2)
        {
            return value.TryGetValue<object>(index1, index2);
        }

        /// <summary>
        /// Gets the value at the specified position in the three-dimensional System.Array. The index is specified as a 64-bit integer.
        /// </summary>
        /// <typeparam name="T">The Type to convert the value to.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="index1">A 64-bit integer that represents the first-dimension index of the System.Array element to get.</param>
        /// <param name="index2">A 64-bit integer that represents the second-dimension index of the System.Array element to get.</param>
        /// <param name="index3">A 64-bit integer that represents the third-dimension index of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the two-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static T TryGetValue<T>(this Array value, long index1, long index2, long index3) where T : class
        {
            try
            {
                return (T)value.GetValue(index1, index2, index3);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the value at the specified position in the three-dimensional System.Array. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="index1">A 32-bit integer that represents the first-dimension index of the System.Array element to get.</param>
        /// <param name="index2">index2: A 32-bit integer that represents the second-dimension index of the System.Array element to get.</param>
        /// <param name="index3">A 32-bit integer that represents the third-dimension index of the System.Array element to get.</param>
        /// <returns>The value at the specified position in the two-dimensional System.Array, otherwise <c>null</c>.</returns>
        internal static object TryGetValue(this Array value, long index1, long index2, long index3)
        {
            return value.TryGetValue<object>(index1, index2, index3);
        }
    }
}
