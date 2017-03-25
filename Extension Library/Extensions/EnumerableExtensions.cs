using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Shuffling an sequence, randomizes its element order. It is using Fisher-Yates Shuffle algorithm.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="sequence">A sequence of T values to suffle of.</param>
        /// <returns>The suffle of the projected values.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence), "source or predicate is null.");
            }
            var result = sequence.ToArray();
            int dataLength = result.Length;
            if (dataLength == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }
            for (int index = 0; index < dataLength; index++)
            {
                int randomPoint = index + (int)(Random.NextDouble() * (dataLength - index));
                var tempData = result[randomPoint];
                result[randomPoint] = result[index];
                result[index] = tempData;
            }
            return result;
        }
    }
}
