using System;
using System.Linq;

namespace Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Join multiple arrays and retuen a new array with elements from all arrays.
        /// </summary>
        /// <typeparam name="T">The type of the elements of array.</typeparam>
        /// <param name="sourceArray">The one-dimensional, zero-based System.Array to copy of.</param>
        /// <param name="arrays">Multiple of one-dimensional, zero-based System.Array to copy of.</param>
        /// <returns>A new array contains all elements from all arrays.</returns>
        public static T[] JoinArrays<T>(this T[] sourceArray, params T[][] arrays)
        {
            if (sourceArray == null || arrays == null)
            {
                throw new ArgumentNullException(nameof(sourceArray), "source or predicate is null.");
            }
            if (arrays == null)
            {
                throw new ArgumentNullException(nameof(arrays), "arrays is null.");
            }
            if (arrays.Any(i => i == null))
            {
                throw new ArgumentNullException(nameof(arrays), "arrays contains null.");
            }
            int sourceArrayLength = sourceArray.Length;
            var result = new T[sourceArrayLength + arrays.Sum(a => a.Length)];
            sourceArray.CopyTo(result, 0);
            int offset = sourceArrayLength;
            foreach (var array in arrays)
            {
                array.CopyTo(result, offset);
                offset += array.Length;
            }
            return result;
        }

        /// <summary>
        /// Join multiple arrays and retuen a new array with elements from all arrays
        /// </summary>
        /// <typeparam name="T">The type of the elements of array.</typeparam>
        /// <param name="arrays">Multiple of one-dimensional, zero-based System.Array to copy of.</param>
        /// <returns>A new array contains all elements from all arrays.</returns>
        public static T[] JoinArrays<T>(this T[][] arrays)
        {
            if (arrays == null)
            {
                throw new ArgumentNullException(nameof(arrays), "source or predicate is null.");
            }
            return new T[0].JoinArrays(arrays);
        }
    }
}
