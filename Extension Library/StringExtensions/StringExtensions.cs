using System;
using System.Linq;

namespace Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Retrieves a slice from this instance. The substring starts at a specified
        /// character position and continues to the specified ending index.
        /// This inclusive for start index, exclusive for end index.
        /// </summary>
        /// <param name="source">The source string</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="endIndex">The ending character position of a substring in this instance. If it is less than zero, it will count back from the right side.</param>
        /// <returns>A string that is equivalent to the substring of length length that begins at startIndex and ends at endIndex in this instance, or System.String.Empty if startIndex is equal to the length of this instance and length is zero.</returns>
        public static string Slice(this string source, int startIndex, int endIndex)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "source or predicate is null.");
            }
            //Keep this for negative end support
            if (endIndex < 0)
            {
                endIndex = source.Length + endIndex;
            }
            //Calculate length
            int length = endIndex - startIndex;
            //Return Substring of length
            return source.Substring(startIndex, length);
        }

        /// <summary>
        /// Retrieves a slice from this instance. The substring starts at the right and take the length of characters of a string.
        /// </summary>
        /// <param name="source">The source string</param>
        /// <param name="length">The right most characters to return</param>
        /// <returns>A string that is equivalent to the substring of length length that begins at the right and count back to the length in this instance, or System.String.Empty if length equal to 0</returns>
        public static string Right(this string source, int length)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "source or predicate is null.");
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "length is less than zero.");
            }
            return source.Length > length ? source.Substring(source.Length - length, length) : source;
        }

        /// <summary>
        /// Retrieves a slice from this instance. The substring excluding exclusionLabel
        /// </summary>
        /// <param name="source">The source string</param>
        /// <param name="exclusionLabel">The label(s) to exclude from source string. Labels separate by |</param>
        /// <returns>A string excluding the exclusionLabel, or System.String.Empty if exclusionLabel equal to source</returns>
        public static string RemoveLable(this string source, string exclusionLabel)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "source or predicate is null.");
            }
            if (exclusionLabel == null)
            {
                throw new ArgumentNullException(nameof(exclusionLabel), "exclusion label is null.");
            }
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(exclusionLabel))
            {
                return source;
            }
            var exclusionLabels = exclusionLabel.Split('|');
            source = exclusionLabels.Aggregate(source, (current, label) => current.Replace(label, string.Empty));
            return source.Trim();
        }
    }
}
