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

    public List<Customer> GetCustomerById(string customerId)
    {
      try
      {
        return Customer.List(_connection.Url, _connection.SessionId, new object[] { customerId }).ToList();
      }
      catch (Exception)
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

  }
}
