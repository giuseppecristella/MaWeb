using System;
using System.Collections.Generic;
using System.Linq;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;

namespace MagentoRepository.Repository
{
  public partial class RepositoryService
  {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    public List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.CategoryAssignedProducts], categoryId);
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

    /// <summary>
    /// Restituisce una istanza della classe Product che contiene informazioni 
    /// sul prodotto relativo all'Id in input
    /// NOTA: è uguale al metodo successivo, parametrizzare passando un filtro per poter filtrare in prodotti 
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public Product GetFilteredProducts(Filter filter)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.FilteredProducts], filter.Value);
      if (_cacheManager.Contains(key)) return _cacheManager.Get<Product>(key);

      var filterParameters = CreateParameters(filter);

      try
      {
        var products = Product.List(_connection.Url, _connection.SessionId, new object[] { filterParameters });
        if (products == null || !products.Any()) return null;
        _cacheManager.Add(key, products[0]);
        return products[0];
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    /// <summary>
    /// Restituisce una istanza della classe Product che contiene informazioni 
    /// sul prodotto relativo all'Id in input 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Product GetProductInfo(string productId)
    {
      return null;
    }

    /// <summary>
    /// Restituisce una istanza della classe Inventory che contiene informazioni
    /// e metodi di accesso all'inventario del prodotto
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Inventory GetInventoryInfo(string productId)
    {
      return null;
    }

    /// <summary>
    /// Restituisce una istanza della classe ProductImage che contiene informazioni
    /// e metodi di accesso alle immagini associate al prodotto
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public ProductImage GetProductImage(string productId)
    {
      return null;
    }

    /// <summary>
    /// Restituisce una istanza della classe ProductLink che contiene informazioni
    /// e metodi di accesso ai prodotti correlati/associati al prodotto in input
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public ProductLink GetProductLinked(string productId)
    {
      return null;
    }

  }
}
