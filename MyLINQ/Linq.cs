using System;
using System.Collections.Generic;
using System.Text;

namespace MyLINQ
{
    public static class Linq
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var finalResult = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    finalResult.Add(item);
                }
            }
            return finalResult;
        }
        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }
    }
}
