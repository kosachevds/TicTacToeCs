using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeCs
{
    public static class Utils
    {
        public static TItem FindWithMax<TItem, TRef>(IEnumerable<TItem> items, Func<TItem, TRef> func)
            where TRef : IComparable
        {
            return FindWithComparingResult(items, func, 1);
        }

        public static TItem FindWithMin<TItem, TRef>(IEnumerable<TItem> items, Func<TItem, TRef> func)
            where TRef : IComparable
        {
            return FindWithComparingResult(items, func, -1);
        }

        private static TItem FindWithComparingResult<TItem, TRef>(IEnumerable<TItem> items, Func<TItem, TRef> func, int comparingResult)
            where TRef : IComparable
        {
            var result = items.First();
            var resultValue = func(result);
            foreach (var item in items.Skip(1))
            {
                var itemValue = func(item);
                if (itemValue.CompareTo(resultValue) == comparingResult)
                {
                    result = item;
                    resultValue = itemValue;
                }
            }
            return result;
        }
    }
}