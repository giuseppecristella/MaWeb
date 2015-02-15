using System;
using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;
using MagentoComunication.Enum;

namespace MagentoRepository.Repository
{
  public class RepositoryEF: IRepository
  {

    public List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId)
    {
      throw new NotImplementedException();
    }

    public Product GetFilteredProducts(Filter filter)
    {
      throw new NotImplementedException();
    }

    public Product GetFilteredProducts(string productId)
    {
      throw new NotImplementedException();
    }


    public int CreateCart()
    {
      throw new NotImplementedException();
    }

    public bool AssociateCustomerToCart(int cartId, Customer customer)
    {
      throw new NotImplementedException();
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

    public string CreateCustomer(Customer customer)
    {
      throw new NotImplementedException();
    }

    public Customer GetCustomerById(int customerId)
    {
      throw new NotImplementedException();
    }

    public string CreateCustomerAddress(int customerId, CustomerAddress customerAddress)
    {
      throw new NotImplementedException();
    }

    public List<CustomerAddress> GetCustomerAddresses(int customerId)
    {
      throw new NotImplementedException();
    }

      public bool UpdateCustomerAddress(CustomerAddress billingAddress, int addressBillingId)
      {
          throw new NotImplementedException();
      }

      public OrderInfo GetOrderInfos(int orderNumber)
    {
      throw new NotImplementedException();
    }

    public bool SetOrderStatus(int orderNumber, OrderStatusType status)
    {
      throw new NotImplementedException();
    }

    public List<Order> GetOrders(Filter filter)
    {
      throw new NotImplementedException();
    }

    public Product GetProductInfo(string productId)
    {
      throw new NotImplementedException();
    }

    public Category GetCategoryInfo(string categoryId)
    {
      throw new NotImplementedException();
    }

    public List<Inventory> GetInventories(string productId)
    {
      throw new NotImplementedException();
    }

    public List<ProductImage> GetProductImages(string productId)
    {
      throw new NotImplementedException();
    }

    public List<ProductLink> GetLinkedProducts(string productId)
    {
      throw new NotImplementedException();
    }

    public int GetStocksForProduct(string productId)
    {
      throw new NotImplementedException();
    }

    public object GetCategoryLevel(string categoryId)
    {
      throw new NotImplementedException();
    }
  }
}
