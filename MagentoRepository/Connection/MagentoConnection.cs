using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ez.Newsletter.MagentoApi;
using MagentoComunication;

/// <summary>
/// Classe Singleton per gestire i parametri di connessione alla api di magento
/// NOTA: bisogna eliminare la dipendenza da HttpContext
/// </summary>
public class MagentoConnection : IMagentoConnection
{
  // Singleton
  private static MagentoConnection instance = null;
  private static readonly object padlock = new object();

  MagentoConnection()
  {

  }

  public static IMagentoConnection Instance
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


  public string GetSessionId(ICacheManager cacheManager)
  {
    string sessionId = "";
    if (!cacheManager.Contains("sessionId"))
    {
      sessionId = Connection.Login(url, userId, password);
    }
    else
    {
      // from cache
    }
    return sessionId;

  }

  public string url { get; set; }
  public string userId { get; set; }
  public string password { get; set; }

}