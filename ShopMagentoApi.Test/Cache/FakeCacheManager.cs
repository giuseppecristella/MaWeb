using System;
using MagentoComunication.Cache;

namespace ShopMagentoApi.Test
{
  public class FakeCacheManager : ICacheManager
  {
    public void Add(string key, object value)
    {
      throw new NotImplementedException();
    }

    public bool Contains(string key)
    {
      return false;
    }

    public int Count()
    {
      throw new NotImplementedException();
    }

    public T Get<T>(string key)
    {
      throw new NotImplementedException();
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