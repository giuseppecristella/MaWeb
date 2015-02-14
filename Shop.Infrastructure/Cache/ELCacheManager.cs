using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace Shop.Infrastructure.Cache
{
    /// <summary>
    /// Facade, interfaccia differente adattata
    /// </summary>
    public class ELCacheManager : ICacheManager
    {
        private static Microsoft.Practices.EnterpriseLibrary.Caching.ICacheManager _cacheManager;
        public ELCacheManager()
        {
            _cacheManager = CacheFactory.GetCacheManager();
        }

        public void Add(string key, object value 
        {
            _cacheManager.Add(key, value);
        }

        public bool Contains(string key)
        {
            return (_cacheManager.GetData(key) != null);
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            var value = _cacheManager.GetData(key);
            return (value != null) ? (T)value : default(T);
        }

        public T SafeGet<T>(string key, Func<T> getData)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}