using System;
using CookComputing.XmlRpc;
using MagentoRepository.Connection;
using Shop.Infrastructure.Cache;

namespace MagentoRepository.Repository
{
  /// <summary>
  /// Classe Repository di accesso al dominio di Magento
  /// attraverso le API esposte dal suo web service 
  /// NOTE: 
  /// 1) l'object model Magento dovrebbe essere rimappato su oggetti semplificati del nostro dominio
  /// a tal proposito potrebbe essere usato EF come ulteriore layer;
  /// 2) tutti i metodi dovrebbero cachare i risultati, da implementare considerando un adeguato pattern di caching
  /// </summary>
  public partial class RepositoryService : IRepository
  {

    private readonly IMagentoConnection _connection;
    private readonly ICacheManager _cacheManager;

    // Constructor injection
    public RepositoryService(IMagentoConnection connection, ICacheManager cacheManager)
    {
      _connection = connection;
      _cacheManager = cacheManager;
    }


    #region private methods
    private static string CreateCacheDictionaryKey(string entity, string filter)
    {
      return String.Concat(entity, filter);
    }

    private static XmlRpcStruct CreateParameters(Filter filter)
    {
      var filterParameters = new XmlRpcStruct();
      var filterOperator = new XmlRpcStruct { { filter.FilterOperator, filter.Value } };
      filterParameters.Add(filter.Key, filterOperator);
      return filterParameters;
    }
    #endregion private methods
  }
}
