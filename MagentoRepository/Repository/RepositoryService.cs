using System;
using System.Diagnostics;
using System.Linq;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using MagentoComunication.Cache;
using MagentoRepository.Connection;
using MagentoRepository.Repository;


/// <summary>
/// Classe Repository di accesso al dominio di Magento
/// attraverso le API esposte dal suo web service 
/// NOTE: 
/// 1) l'object model Magento dovrebbe essere rimappato su oggetti semplificati del nostro dominio
/// a tal proposito potrebbe essere usato EF come ulteriore layer;
/// 2) tutti i metodi dovrebbero cachare i risultati, da implementare considerando un adeguato pattern di caching
/// </summary>
public class RepositoryService : IRepository
{

  private IMagentoConnection _connection;
  private ICacheManager _cacheManager;

  // Constructor injection
  public RepositoryService(IMagentoConnection connection, ICacheManager cacheMAnager)
  {
    _connection = connection;
    _cacheManager = cacheMAnager;
  }

  public CategoryAssignedProduct[] GetProductsByCategoryId(string categoryId)
  {
    // Convenzione: le chiavi in cache avranno il nome della classe (plurale se collection) e l'eventuale id del filtro
    var key = CreateCacheDictionaryKey("CategoryAssignedProduct", categoryId);
    if (_cacheManager.Contains(key)) return _cacheManager.Get<CategoryAssignedProduct[]>(key);
    try
    {
      var assignedProducts = Category.AssignedProducts(_connection.url, _connection.SessionId, new object[] { categoryId });
      _cacheManager.Add(key, assignedProducts);
      return assignedProducts;
    }
    catch (Exception ex)
    {
      return null;
    }
  }


  public Product GetProductById(string productId)
  {
    var key = CreateCacheDictionaryKey("Product", productId);
    if (_cacheManager.Contains(key)) return _cacheManager.Get<Product>(key);

    var filterParameters = new XmlRpcStruct();
    var filterOperator = new XmlRpcStruct { { "eq", productId } };
    filterParameters.Add("product_id", filterOperator);

    try
    {
      var products = Product.List(_connection.url, _connection.SessionId, new object[] { filterParameters });
      if (products == null || !products.Any()) return null;
      _cacheManager.Add(key, products[0]);
      return products[0];
    }
    catch (Exception)
    {
      return null;
    }
  }

  private static string CreateCacheDictionaryKey(string entity, string filter)
  {
    var key = String.Concat(entity, filter);
    return key;
  }
}


