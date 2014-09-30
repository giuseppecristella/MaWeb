
using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;

namespace MagentoRepository.Repository
{
  /// <summary>
  /// Implementa la classe repository di accesso al modello
  /// di dominio di Magento attraverso l'interrogazione
  /// diretta del database mysql
  /// </summary>
  public class RepositoryMySql : IRepository
  {
    public List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId)
    {
      throw new System.NotImplementedException();
    }

    public Product GetFilteredProducts(Filter filter)
    {
      throw new System.NotImplementedException();
    }

    public Product GetFilteredProducts(string productId)
    {
      throw new System.NotImplementedException();
    }

    public object GetCategoryLevel(string categoryId)
    {
      throw new System.NotImplementedException();
    }

    public int CreateCart()
    {
      throw new System.NotImplementedException();
    }

    public Product GetProductInfo(string productId)
    {
      throw new System.NotImplementedException();
    }

    public Category GetCategoryInfo(string categoryId)
    {
      throw new System.NotImplementedException();
    }

    public List<Inventory> GetInventories(string productId)
    {
      throw new System.NotImplementedException();
    }

    public List<ProductImage> GetProductImages(string productId)
    {
      throw new System.NotImplementedException();
    }

    public List<ProductLink> GetLinkedProducts(string productId)
    {
      throw new System.NotImplementedException();
    }

    public int GetStocksForProduct(string productId)
    {
      throw new System.NotImplementedException();
    }
  }
}
