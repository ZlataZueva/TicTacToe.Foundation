using System;
using System.Collections.Generic;

namespace Common.Extensions
{
    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
            {
                action(element);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<int, T> action)
        {
            var index = 0;
            foreach (var element in collection)
            {
                action(index++, element);
            }
        }
    }
}