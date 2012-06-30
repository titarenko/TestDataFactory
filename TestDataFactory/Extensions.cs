using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestDataFactory
{
    /// <summary>
    /// Contains set of uncategorized extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Repeats the specified enumerable given number times.
        /// </summary>
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> enumerable, int times)
        {
            return Enumerable.Repeat(enumerable, times).SelectMany(x => x.Select(y => y));
        }

        /// <summary>
        /// Convenient way of doing string.Format.
        /// </summary>
        public static string Fill(this string format, params object[] values)
        {
            return string.Format(format, values);
        }

        /// <summary>
        /// Enables .ForEach() on <see cref="IEnumerable{T}"/>.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        /// <summary>
        /// Converts specified string to title case.
        /// </summary>
        public static string ToTileCase(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }
    }
}