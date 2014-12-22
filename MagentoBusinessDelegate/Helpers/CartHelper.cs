using Ez.Newsletter.MagentoApi;
using MagentoComunication.Cache;
using MagentoRepository.Helpers;

namespace MagentoBusinessDelegate.Helpers
{

  public static class CartHelper
  {
    private static ICacheManager _cacheManager;
    private static readonly string _cacheKey = ConfigurationHelper.CacheKeyNames[CacheKey.Cart];

    public static ICacheManager CacheManager
    {
      set { _cacheManager = value; }
    }

    public static void AddProductToCartAndUpdateCache(Product product)
    {
      var cart = _cacheManager.Get<Cart>(_cacheKey) ?? new Cart();
      cart.AddProductAndUpdateTotal(product);
      _cacheManager.Add(_cacheKey, cart);
    }

    public static void ClearCart()
    {
      _cacheManager.Remove(_cacheKey);
    }
  }
}
