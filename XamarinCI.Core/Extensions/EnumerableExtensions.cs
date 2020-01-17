using System.Collections.Generic;
using System.Linq;

namespace XamarinCI.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> src)
        {
            return src == null || !src.Any();
        }
    }
}