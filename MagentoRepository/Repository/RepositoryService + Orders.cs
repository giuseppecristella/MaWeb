using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ez.Newsletter.MagentoApi;
using MagentoComunication.Enum;
using MagentoRepository.Helpers;

namespace MagentoRepository.Repository
{
  public partial class RepositoryService
  {
    public OrderInfo GetOrderInfos(int orderNumber)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.OrderInfo], orderNumber.ToString());
      if (_cacheManager.Contains(key)) return _cacheManager.Get<OrderInfo>(key);
      try
      {
        return Order.Info(_connection.Url, _connection.SessionId,
          new object[] { orderNumber });
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public List<Order> GetOrders(Filter filter)
    {
      var key = ConfigurationHelper.CacheKeyNames[CacheKey.Orders];
      if (_cacheManager.Contains(key)) return _cacheManager.Get<List<Order>>(key);

      var filterParameters = CreateParameters(filter);
      try
      {
        return Order.List(_connection.Url, _connection.SessionId, new object[] { filterParameters }).ToList();
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public bool SetOrderStatus(int orderNumber, OrderStatusType status)
    {
      try
      {
        OrderStatus.SetStatus(_connection.Url, _connection.SessionId, new object[] { orderNumber, status.ToString().ToLower() });
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}
