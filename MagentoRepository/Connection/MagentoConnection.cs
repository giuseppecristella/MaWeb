using System;
using Ez.Newsletter.MagentoApi;
using MagentoComunication.Cache;
using MagentoRepository.Connection;
using ShopMagentoApi.Test;

/// <summary>
/// Classe Singleton per gestire i parametri di connessione alla Api di magento
/// NOTA: eliminare la dipendenza da HttpContext, ok wrapper CacheManager + iniettare dipendenza attraverso property
/// verificare inoltre la possibilità di usare una semplice classe statica al posto del singleton
/// VEDERE PATTERN CONNECTION - ES. connessione a db / verificare se ha senso fare una dispose
/// </summary>
public class MagentoConnection : IMagentoConnection
{
  // Singleton
  private static MagentoConnection instance = null;
  private static readonly object padlock = new object();
  private ICacheManager _cacheManager;

  MagentoConnection()
  {

  }

  public ICacheManager CacheManager
  {
    // Gestire un cache manager di default
    get { return _cacheManager ?? (_cacheManager = new FakeCacheManager()); }
    set { _cacheManager = value; }
  }

  public static MagentoConnection Instance
  {
    get
    {
      lock (padlock)
      {
        if (instance == null)
        {
          instance = new MagentoConnection();
        }
        return instance;
      }
    }
  }


  public string SessionId
  {
    get
    {
      return CacheManager.Contains("sessionId") ? _cacheManager.Get<string>("sessionId") : Connection.Login(url, userId, password);
    }
  }

  public string url { get; set; }
  public string userId { get; set; }
  public string password { get; set; }

}

public class CacheManager : ICacheManager
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