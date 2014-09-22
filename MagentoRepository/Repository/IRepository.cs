using System;
public interface IRepository
{
  global::Ez.Newsletter.MagentoApi.CategoryAssignedProduct[] GetProductsByCatId(string categoryId);
}
