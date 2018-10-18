using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryCacheSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleMemoryCache cacheTest = new SimpleMemoryCache();
            cacheTest.SetObject("hw", "hello world");
            cacheTest.SetObject("temp", "temp value");
            Console.WriteLine("hw value is " + cacheTest.GetObject<string>("hw"));
            Console.WriteLine("temp value is " + cacheTest.GetObject<string>("temp"));
            Thread.Sleep(2000);
            Console.WriteLine("hw value is " + cacheTest.GetObject<string>("hw"));
            Console.WriteLine("temp value is " + cacheTest.GetObject<string>("temp"));
            cacheTest.Remove("temp");
            Thread.Sleep(3000);
            Console.WriteLine("temp value is " + cacheTest.GetObject<string>("temp"));
            Thread.Sleep(6000);
            Console.WriteLine("hw value is " + cacheTest.GetObject<string>("hw"));
            Thread.Sleep(20000);
            Console.WriteLine("hw value is " + cacheTest.GetObject<string>("hw"));

            Console.ReadLine();
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
