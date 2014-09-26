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

  // Nota ha senso gestire la cache solo se vogliamo generare un nuovo sessionId ciclicamente allo scadere di un timeout
  public string SessionId
  {
    get
    {
      // Bug: se scade la sessione chi va a settare nuovamente il sessionId
      return CacheManager.Contains("sessionId") ? _cacheManager.Get<string>("sessionId") : Connection.Login(Url, UserId, Password);
    }
  }

  public string Url { get; set; }
  public string UserId { get; set; }
  public string Password { get; set; }

}

