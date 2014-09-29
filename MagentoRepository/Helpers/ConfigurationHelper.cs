﻿using System.Collections.Generic;

namespace MagentoRepository.Helpers
{
  public enum CacheKey
  {
    Cart,
    FilteredProducts,
    CategoryAssignedProducts,
    ProductInfo,
    InventoryInfo,
    ProductImage,
    ProductLinked,
    CategoryLevel,
    CategoryInfo
  }

  public static class ConfigurationHelper
  {
    public const string RootCategory = "47";
    public static readonly string[] HomeCategories = { "44", "45" };

    public const string CartKey = "";

    public static readonly Dictionary<CacheKey, string> CacheKeyNames = new Dictionary<CacheKey, string>()
    {
      { CacheKey.Cart, "Cart" },
      { CacheKey.FilteredProducts, "FilteredProducts§" },
      { CacheKey.CategoryAssignedProducts, "CategoryAssignedProducts§" },
      { CacheKey.ProductInfo, "ProductInfo§" },
      { CacheKey.InventoryInfo, "InventoryInfo§" },
      { CacheKey.ProductImage, "ProductImage§" },
      { CacheKey.ProductLinked, "ProductLinked§" },
      { CacheKey.CategoryLevel, "CategoryLevel§" },
      { CacheKey.CategoryInfo, "CategoryInfo§" }
    };
  }
}
