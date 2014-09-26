using Ez.Newsletter.MagentoApi;

namespace MagentoRepository.Repository
{
  public interface IRepository
  {
    CategoryAssignedProduct[] GetProductsByCategoryId(string categoryId);
    Product GetProductById(string productId);
  }
}
