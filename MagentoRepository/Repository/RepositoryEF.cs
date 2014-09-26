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

    public Product GetProductById(string productId)
    {
      throw new NotImplementedException();
    }


    public object GetCategory(string categoryId)
    {
      throw new NotImplementedException();
    }
  }
}
