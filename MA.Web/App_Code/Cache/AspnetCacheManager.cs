using System;
using System.Web;
using MagentoComunication.Cache;

namespace Cache
{
    /// <summary>
    /// Summary description for CacheManager
    /// </summary>
    public class AspnetCacheManager: ICacheManager
    {
  
        public void Add(string key, object value)
        {
            HttpContext.Current.Cache[key] = value;
        }

        public bool Contains(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            return (HttpContext.Current.Cache[key] != null) ? (T)HttpContext.Current.Cache[key] : default(T);
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