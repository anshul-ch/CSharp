using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class CacheItem<T>
    {
        public T Value { get; set; }
        public DateTime Expiry { get; set; }
    }

    public class AdvancedCache<TKey, TValue>
    {
        private readonly int capacity;
        private readonly Dictionary<TKey, CacheItem<TValue>> store = new Dictionary<TKey, CacheItem<TValue>>();
        private readonly LinkedList<TKey> usage = new LinkedList<TKey>();

        public AdvancedCache(int capacity)
        {
            this.capacity = capacity;
        }

        public void Set(TKey key, TValue value, int ttlSeconds)
        {
            if (store.ContainsKey(key))
            {
                usage.Remove(key);
            }
            else if (store.Count >= capacity)
            {
                var lru = usage.First.Value;
                usage.RemoveFirst();
                store.Remove(lru);
            }

            store[key] = new CacheItem<TValue>
            {
                Value = value,
                Expiry = DateTime.Now.AddSeconds(ttlSeconds)
            };
            usage.AddLast(key);
        }

        public TValue Get(TKey key)
        {
            if (!store.ContainsKey(key)) return default;

            var item = store[key];
            if (DateTime.Now > item.Expiry)
            {
                store.Remove(key);
                usage.Remove(key);
                return default;
            }

            usage.Remove(key);
            usage.AddLast(key);
            return item.Value;
        }
    }

    [TestFixture]
    public class AdvancedCacheTests
    {
        [Test]
        public void LeastRecentlyUsedIsEvicted()
        {
            var cache = new AdvancedCache<int, string>(2);
            cache.Set(1, "A", 60);
            cache.Set(2, "B", 60);
            cache.Get(1);
            cache.Set(3, "C", 60);

            Assert.That(cache.Get(2), Is.Null);
            Assert.That(cache.Get(1), Is.EqualTo("A"));
        }
    }

    class Cache_Techniques
    {
        static void Main() { }
    }
}
