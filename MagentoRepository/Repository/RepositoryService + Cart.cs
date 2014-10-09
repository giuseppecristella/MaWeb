using System;
using System.Collections.Generic;
using System.Linq;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;

namespace MagentoRepository.Repository
{

  public partial class RepositoryService
  {
    public int CreateCart()
    {
      try
      {
        return Cart.create(_connection.Url, _connection.SessionId);
      }
      catch (Exception)
      {
        return 0;
      }
    }

    public List<ShippingMethod> GetShippingMethods(int cartId)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.ShippingMethods], cartId.ToString());
      if (_cacheManager.Contains(key)) return _cacheManager.Get<List<ShippingMethod>>(key);
      try
      {
        var shippingMethods = Cart.cartShippingList(_connection.Url, _connection.SessionId,
          new object[] { cartId });
        if (shippingMethods == null) return null;
        _cacheManager.Add(key, shippingMethods);
        return shippingMethods.ToList();
      }
      catch (Exception)
      {
        return null;
      }
    }

    public bool AssociateCustomerToCart(int cartId, Customer customer)
    {
      try
      {
        return Cart.cartCustomerSet(_connection.Url, _connection.SessionId, new object[] { cartId , customer});
      }
      catch (Exception ex)
      {

        return false;
      }
    }

    public bool AddCustomerAddressesToCart(int cartId, List<CustomerAddress> customerAddresses)
    {
      throw new NotImplementedException();
    }

    public bool AddProductToCart(int cartId, Product product)
    {
      throw new NotImplementedException();
    }

    public List<PaymentMethod> GetPaymentMethods(int cartId)
    {
      throw new NotImplementedException();
    }

    public bool AddShippingMethodToCart(string shippingMethod)
    {
      throw new NotImplementedException();
    }
  }
}
