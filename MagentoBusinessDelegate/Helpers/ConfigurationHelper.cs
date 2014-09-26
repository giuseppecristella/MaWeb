using System.Collections.Generic;

namespace MagentoBusinessDelegate.Helpers
{
  public enum CacheKey
  {
    Cart,
    Products
  }

  public static class ConfigurationHelper
  {
    public const string CartKey = "";
    public static readonly Dictionary<CacheKey, string> CacheKeyNames = new Dictionary<CacheKey, string>()
    {
      { CacheKey.Cart, "Cart" }
    };
  }
}
