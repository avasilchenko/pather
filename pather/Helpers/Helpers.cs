using System;
using System.Collections.Generic;

namespace pather.Helpers
{
    public static class Helpers
    {
        public static IEnumerable<int> AllIndexesOf(this string str, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", nameof(value));

            for (var index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index, StringComparison.InvariantCultureIgnoreCase);
                if (index == -1)
                    break;
                yield return index;
            }
        }
    }
}