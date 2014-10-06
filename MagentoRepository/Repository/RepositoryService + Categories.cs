using System;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;

namespace MagentoRepository.Repository
{

  public partial class RepositoryService 
  {

    /// <summary>
    /// Restituisce l'albero delle categorie
    /// Nota: struttura gerarchica per costruire il menu
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    public object GetCategoryLevel(string categoryId)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.CategoryLevel], categoryId);
      if (_cacheManager.Contains(key)) return _cacheManager.Get<Product>(key);
      try
      {
        var category = Category.Level(_connection.Url, _connection.SessionId, new object[] { categoryId });
        if (category == null) return null;
        _cacheManager.Add(key, category);
        return category;
      }
      catch (Exception)
      {
        return null;
      }
    }

    /// <summary>
    /// Restituisce una istanza della classe Category che contiene informazioni
    /// e metodi di accesso categoria richiesta in input
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    public Category GetCategoryInfo(string categoryId)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.CategoryInfo], categoryId);
      if (_cacheManager.Contains(key)) return _cacheManager.Get<Category>(key);
      try
      {
        var category = Category.Info(_connection.Url, _connection.SessionId, new object[] { categoryId });
        if (category == null) return null;
        _cacheManager.Add(key, category);
        return category;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public T Get<T>(string id)
    {
      throw new NotImplementedException();
    }
  }
}
