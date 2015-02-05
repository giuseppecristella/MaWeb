using System;
using System.Collections.Generic;

namespace Shop.Infrastructure.Cache
{
  public class FakeCacheManager : ICacheManager
  {
    private readonly Dictionary<string, object> cache;

    public FakeCacheManager()
    {
        cache = new Dictionary<string, object>();
    }

    public void Add(string key, object value)
    {
      cache.Add(key, value);
    }

    public bool Contains(string key)
    {
      return cache.ContainsKey(key);
    }

    public int Count()
    {
      return cache.Count;
    }

    public T Get<T>(string key)
    {
      return cache.ContainsKey(key) ? (T)cache[key] : default(T);
    }

    public T SafeGet<T>(string key, Func<T> getData)
    {
      throw new NotImplementedException();
    }

    public bool Remove(string key)
    {
      object output;
      return cache.Remove(key);
    }
  }
}