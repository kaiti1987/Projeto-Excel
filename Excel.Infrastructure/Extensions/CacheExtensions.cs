using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Excel.Infrastructure.Extensions
{
    internal static class CacheExtensions
    {
        internal static void AddCache<T>(this ObjectCache cache, string cacheKey, IEnumerable<T> operation)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
            cache.Add(cacheKey, operation, cacheItemPolicy);
        }
    }
}
