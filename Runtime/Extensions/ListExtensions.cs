using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Utilities.Extensions
{
    public static class ListExtensions
    {
        public static void ForEach<T>(this IList<T> list, Action<T> action)
        {
            for (var i = 0; i < list.Count; i++) action(list[i]);
        }

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var count = list.Count;
            while (count > 1)
            {
                count--;
                var index = Random.Range(0, count + 1);
                (list[index], list[count]) = (list[count], list[index]);
            }

            return list;
        }
    }
}