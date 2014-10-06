using Ez.Newsletter.MagentoApi;
using MagentoComunication.Cache;

namespace MagentoBusinessDelegate.Helpers
{

  public static class CartHelper
  {
    private static ICacheManager _cacheManager;

    public static ICacheManager CacheManager
    {
      set { _cacheManager = value; }
    }

    public static void AddProductToCartAndUpdateCache(Product product)
    {
      var cart = _cacheManager.Get<Cart>("Cart") ?? new Cart();
      cart.AddProductAndUpdateTotal(product);
      _cacheManager.Add("Cart", cart);
    }
  }
}
