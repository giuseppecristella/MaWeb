using System;
using MagentoComunication;

/// <summary>
/// Descrive una interfaccia generica di connessione ad un data layer, utilizzata dal repository
/// NOTA: Per rendere questa interfaccia estendibile rispetto ad un diverso data layer (es. Database Mysql)
/// è sufficiente aggiungere nel contratto i metodi specifici del data layer a cui interfacciarsi
/// che saranno poi implementati nella classe concreta;
/// </summary>
public interface IMagentoConnection
{
  string userId { get; set; }
  string password { get; set; }
  string GetSessionId(ICacheManager cacheManager);
  string url { get; set; }
  // + Connection Mysql
  // + Connection EF
  // + CSV - XML - Json
}
