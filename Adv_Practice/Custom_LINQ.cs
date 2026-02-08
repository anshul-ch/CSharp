using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;

namespace CSharp.Adv_Practice
{
    public static class CustomLinqExtensions
    {
        public static IEnumerable<T> WhereEx<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
                if (predicate(item))
                    yield return item;
        }

        public static IEnumerable<TResult> SelectEx<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (var item in source)
                yield return selector(item);
        }
    }

    [TestFixture]
    public class CustomLinq_Test
    {
        [Test]
        public void WhereAndSelect()
        {
            var nums = new[] { 1, 2, 3, 4 };
            var result = nums.WhereEx(n => n > 2).SelectEx(n => n * 2);
            CollectionAssert.AreEqual(new[] { 6, 8 }, result);
        }
    }

    class Custom_Linq
    {
        static void Main() { }
    }
}
