using System;
using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;

namespace MagentoRepository.Repository
{
  public class RepositoryEF: IRepository
  {

    public List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId)
    {
      throw new NotImplementedException();
    }

    public Product GetFilteredProducts(Filter filter)
    {
      throw new NotImplementedException();
    }

    public Product GetFilteredProducts(string productId)
    {
      throw new NotImplementedException();
    }


    public object GetCategoryLevel(string categoryId)
    {
      throw new NotImplementedException();
    }

    public Product GetProductInfo(string productId)
    {
      throw new NotImplementedException();
    }

    public Category GetCategoryInfo(string categoryId)
    {
      throw new NotImplementedException();
    }

    public Inventory GetInventoryInfo(string productId)
    {
      throw new NotImplementedException();
    }

    public ProductImage GetProductImage(string productId)
    {
      throw new NotImplementedException();
    }

    public ProductLink GetProductLinked(string productId)
    {
      throw new NotImplementedException();
    }
  }
}
