using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestDataFactory
{
    public static class Extensions
    {
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> enumerable, int times)
        {
            return Enumerable.Repeat(enumerable, times).SelectMany(x => x.Select(y => y));
        }

        public static string Fill(this string format, params object[] values)
        {
            return string.Format(format, values);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static string Capitalize(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }
    }
}