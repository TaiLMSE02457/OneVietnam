using System;
using System.Runtime.Caching;

namespace Unities
{
    public class CacheBase
    {
        public static CacheBase Instance = new CacheBase();

        private static MemoryCache _cache;
        public CacheBase()
        {
            _cache = new MemoryCache("defaultCache");
        }
        /// <summary>
        /// Cache with expired time
        /// </summary>
        /// <param name="cacheName"></param>
        /// <param name="cacheItem">the item need to cache</param>
        /// <param name="expiredTime">Cache time by seconds</param>
        /// <returns></returns>
        public bool Add(string cacheName, object cacheItem, int expiredTime)
        {
            try
            {
                return _cache.Add(cacheName, cacheItem, DateTime.Now.AddSeconds(expiredTime));
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Add Cache without removing
        /// </summary>
        /// <param name="cacheName"></param>
        /// <param name="cacheItem"></param>
        /// <returns></returns>
        public bool Add(string cacheName, object cacheItem)
        {
            try
            {
                var cachePolicy = new CacheItemPolicy();
                cachePolicy.Priority = CacheItemPriority.NotRemovable;
                return _cache.Add(cacheName, cacheItem, cachePolicy);
            }
            catch (Exception ex)
            {
                return false;                
            }
        }

        /// <summary>
        /// Remove a cache by name
        /// </summary>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        public bool Remove(string cacheName)
        {
            try
            {
                _cache.Remove(cacheName);
                return true;
            }
            catch (Exception ex)
            {
                return false;                
            }
        }
        /// <summary>
        /// Remove all caches
        /// </summary>
        /// <returns></returns>
        public bool RemoveAll()
        {
            try
            {
                _cache.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }

        public object GetCache(string cacheName)
        {
            try
            {
                return _cache.Get(cacheName);
            }
            catch (Exception ex)
            {
                return null;                
            }
        }
    }
}
