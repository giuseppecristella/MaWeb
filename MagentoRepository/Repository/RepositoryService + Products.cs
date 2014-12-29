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
     // if (_cacheManager.Contains(key)) return _cacheManager.Get<List<CategoryAssignedProduct>>(key);
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
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.ProductInfo], productId);
      if (_cacheManager.Contains(key)) return _cacheManager.Get<Product>(key);
      try
      {
        var product = Product.Info(_connection.Url, _connection.SessionId, new object[] { productId });
        if (product == null) return null;
        _cacheManager.Add(key, product);
        return product;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    /// <summary>
    /// Restituisce una istanza della classe Inventory che contiene informazioni
    /// e metodi di accesso all'inventario del prodotto
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public List<Inventory> GetInventories(string productId)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.Inventories], productId);
      if (_cacheManager.Contains(key)) return _cacheManager.Get<List<Inventory>>(key);
      try
      {
        var inventories = Inventory.List(_connection.Url, _connection.SessionId, new object[] { productId });
        if (inventories == null || !inventories.Any()) return null;
        _cacheManager.Add(key, inventories.ToList());
        return inventories.ToList();
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    /// <summary>
    /// Restituisce una istanza della classe ProductImage che contiene informazioni
    /// e metodi di accesso alle immagini associate al prodotto
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public List<ProductImage> GetProductImages(string productId)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.ProductImages], productId);
      if (_cacheManager.Contains(key)) return _cacheManager.Get<List<ProductImage>>(key);
      try
      {
        var productImages = ProductImage.List(_connection.Url, _connection.SessionId, new object[] { productId });
        if (productImages == null || !productImages.Any()) return null;
        return productImages.ToList();
      }
      catch (Exception)
      {
        return null;
      }
    }

    /// <summary>
    /// Restituisce una istanza della classe ProductLink che contiene informazioni
    /// e metodi di accesso ai prodotti correlati/associati al prodotto in input
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public List<ProductLink> GetLinkedProducts(string productId)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.LinkedProducts], productId);
      if (_cacheManager.Contains(key)) return _cacheManager.Get<List<ProductLink>>(key);
      try
      {
        var pId = int.Parse(productId);
        var linkedProducts = ProductLink.List(_connection.Url, _connection.SessionId, new object[] { "related", pId });
        if (linkedProducts == null || !linkedProducts.Any()) return null;
        return linkedProducts.ToList();
      }
      catch (Exception)
      {
        return null;
      }
    }

    public int GetStocksForProduct(string productId)
    {
      var inventories = GetInventories(productId);
      if (inventories == null || inventories.First() == null) return 0;
      int qty;
      if ((int.TryParse(inventories.First().qty.Substring(0, inventories.First().qty.IndexOf(".", StringComparison.Ordinal)), out qty)) == false) return 0;
      return qty;
    }

  }
}
