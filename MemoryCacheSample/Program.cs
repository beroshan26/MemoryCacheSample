using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCacheSample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class SimpleMemoryCache
    {
        private MemoryCache _memCache = new MemoryCache("CacheTest");

        public T GetObject<T>(string key) where T : class
        {
            return _memCache.Get(key) as T;
        }

        public void SetObject<T>(string key, T value) where T:class
        {
            CacheItemPolicy policy = new CacheItemPolicy() {SlidingExpiration = TimeSpan.FromSeconds(10) };
            _memCache.Set(key, value, policy);
        }

        public void Remove(string key)
        {
            _memCache.Remove(key);
        }
    }
}
