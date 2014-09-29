using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;

namespace MagentoRepository.Repository
{
  public interface IRepository
  {
    List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId);
    Product GetFilteredProducts(Filter filter);
    object GetCategoryLevel(string categoryId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Product GetProductInfo(string productId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    Category GetCategoryInfo(string categoryId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    List<Inventory> GetInventories(string productId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    List<ProductImage> GetProductImages(string productId);

    ///
    List<ProductLink> GetLinkedProducts(string productId);
  }
}
