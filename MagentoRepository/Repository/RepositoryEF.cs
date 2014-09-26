using System;
using Ez.Newsletter.MagentoApi;

namespace MagentoRepository.Repository
{
  public class RepositoryEF: IRepository
  {

    public Ez.Newsletter.MagentoApi.CategoryAssignedProduct[] GetProductsByCategoryId(string categoryId)
    {
      throw new NotImplementedException();
    }

    public Product GetProductById(string productId)
    {
      throw new NotImplementedException();
    }
  }
}
