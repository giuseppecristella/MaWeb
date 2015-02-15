using System;
using System.Collections.Generic;
using System.Linq;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;

namespace MagentoRepository.Repository
{

  public partial class RepositoryService
  {
    public string CreateCustomer(Customer customer)
    {
      try
      {
        return Customer.Create(_connection.Url, _connection.SessionId, customer);
      }
      catch (Exception ex)
      {
        return string.Empty;
      }
    }

    public Customer GetCustomerById(int customerId)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.Customer], customerId.ToString());
      if (_cacheManager.Contains(key)) return _cacheManager.Get<Customer>(key);
      try
      {
        var customer = Customer.Info(_connection.Url, _connection.SessionId, customerId);
        if (customer == null) return null;
        _cacheManager.Add(key, customer);
        return customer;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public string CreateCustomerAddress(int customerId, CustomerAddress customerAddress)
    {
      try
      {
        return CustomerAddress.Create(_connection.Url, _connection.SessionId, customerId, customerAddress);
      }
      catch (Exception)
      {
        return string.Empty;
      }
    }

    public List<CustomerAddress> GetCustomerAddresses(int customerId)
    {
      var key = CreateCacheDictionaryKey(ConfigurationHelper.CacheKeyNames[CacheKey.CustomerAddresses], customerId.ToString());
      if (_cacheManager.Contains(key)) return _cacheManager.Get<List<CustomerAddress>>(key);
      try
      {
        var customersAddresses = CustomerAddress.List(_connection.Url, _connection.SessionId, new object[] { customerId });
        if (customersAddresses == null) return null;
        _cacheManager.Add(key, customersAddresses.ToList());
        return customersAddresses.ToList();
      }
      catch (Exception ex)
      {
        return null;
      }
    }

      public bool UpdateCustomerAddress(CustomerAddress billingAddress, int addressBillingId)
      {
          return CustomerAddress.Update(_connection.Url, _connection.SessionId, addressBillingId, billingAddress);
      }
  }
}
