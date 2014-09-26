using System;
using System.Collections.Generic;
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

  private readonly IMagentoConnection _connection;
  private readonly ICacheManager _cacheManager;

  // Constructor injection
  public RepositoryService(IMagentoConnection connection, ICacheManager cacheMAnager)
  {
    _connection = connection;
    _cacheManager = cacheMAnager;
  }

  public List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId)
  {
    // Convenzione: le chiavi in cache avranno il nome della classe (plurale se collection) e l'eventuale id del filtro
    var key = CreateCacheDictionaryKey("CategoryAssignedProducts", categoryId);
    if (_cacheManager.Contains(key)) return _cacheManager.Get<List<CategoryAssignedProduct>>(key);
    try
    {
      var assignedProducts = Category.AssignedProducts(_connection.Url, _connection.SessionId, new object[] { categoryId });
      if (assignedProducts == null) return null;
      var productsInStock = assignedProducts.Where(p => p.qty_in_stock > 0).ToList();
      if (!productsInStock.Any()) return null;
      _cacheManager.Add(key, productsInStock);
      return productsInStock;
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
      var products = Product.List(_connection.Url, _connection.SessionId, new object[] { filterParameters });
      if (products == null || !products.Any()) return null;
      _cacheManager.Add(key, products[0]);
      return products[0];
    }
    catch (Exception)
    {
      return null;
    }
  }

  public object GetCategory(string categoryId)
  {
    return Category.Level(_connection.Url, _connection.SessionId, new object[] { categoryId }) as Category;
  }

  private static string CreateCacheDictionaryKey(string entity, string filter)
  {
    var key = String.Concat(entity, filter);
    return key;
  }
}


