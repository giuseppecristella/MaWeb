using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;

namespace MagentoRepository.Repository
{
  public interface IRepository
  {
    List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId);
    Product GetProductById(string productId);
    object GetCategory(string categoryId);
  }
}
