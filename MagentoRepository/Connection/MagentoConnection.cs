using MagentoComunication.Helpers;
using Shop.Infrastructure.Cache;

namespace MagentoRepository.Connection
{
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
      // nel costruttore stabilisco una connessione con magento e salvo in cache il session Id
      // se faccio injection di url e psw
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
        return CacheManager.Contains(ConfigurationHelper.CacheKeyNames[CacheKey.SessionId])
          ? _cacheManager.Get<string>(ConfigurationHelper.CacheKeyNames[CacheKey.SessionId]) 
          : Ez.Newsletter.MagentoApi.Connection.Login(Url, UserId, Password);
      }
    }

    public string Url { get; set; }
    public string UserId { get; set; }
    public string Password { get; set; }

    public bool Login()
    {
      var sessionId = Ez.Newsletter.MagentoApi.Connection.Login(Url, UserId, Password);
      if (sessionId == null) return false; // exception connessione non effettuata con magento
      CacheManager.Add(ConfigurationHelper.CacheKeyNames[CacheKey.SessionId], sessionId);
      return true;
    }
  }
}

