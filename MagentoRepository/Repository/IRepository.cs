using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;

namespace MagentoRepository.Repository
{
  public interface IRepository
  {
    #region Product

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Product GetFilteredProducts(Filter filter);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Product GetProductInfo(string productId);

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    List<ProductLink> GetLinkedProducts(string productId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    int GetStocksForProduct(string productId);

    #endregion

    #region Category

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    Category GetCategoryInfo(string categoryId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    object GetCategoryLevel(string categoryId);

    #endregion Category

    #region Cart

    int CreateCart();

    #endregion
  }
}
