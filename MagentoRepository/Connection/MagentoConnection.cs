using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ez.Newsletter.MagentoApi;
using MagentoComunication;
using MagentoRepository.Connection;

/// <summary>
/// Classe Singleton per gestire i parametri di connessione alla Api di magento
/// NOTA: eliminare la dipendenza da HttpContext, ok wrapper CacheManager + iniettare dipendenza attraverso property
/// verificare inoltre la possibilità di usare una semplice classe statica al posto del singleton
/// </summary>
public class MagentoConnection: IMagentoConnection
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
    get { return _cacheManager ?? (_cacheManager = new CacheManager()); }
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
      string sessionId = "";
      if (!_cacheManager.Contains("sessionId"))
      {
        sessionId = Connection.Login(url, userId, password);
      }
      else
      {
        // from cache
      }
      return sessionId;
    }
  }

  public string url { get; set; }
  public string userId { get; set; }
  public string password { get; set; }

}

public class CacheManager : ICacheManager
{
  public bool Contains(string key)
  {
    return false;
  }
}