
using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;
using MagentoComunication.Enum;

namespace MagentoRepository.Repository
{
  /// <summary>
  /// Implementa la classe repository di accesso al modello
  /// di dominio di Magento attraverso l'interrogazione
  /// diretta del database mysql
  /// </summary>
  public class RepositoryMySql : IRepository
  {
    public List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId)
    {
      throw new System.NotImplementedException();
    }

    public Product GetFilteredProducts(Filter filter)
    {
      throw new System.NotImplementedException();
    }

    public Product GetFilteredProducts(string productId)
    {
      throw new System.NotImplementedException();
    }

    public object GetCategoryLevel(string categoryId)
    {
      throw new System.NotImplementedException();
    }

    public int CreateCart()
    {
      throw new System.NotImplementedException();
    }

    public bool AssociateCustomerToCart(int cartId,Customer customer)
    {
      throw new System.NotImplementedException();
    }

    public bool AddCustomerAddressesToCart(int cartId, List<CustomerAddress> customerAddresses)
    {
      throw new System.NotImplementedException();
    }

    public bool AddProductToCart(int cartId, Product product)
    {
      throw new System.NotImplementedException();
    }

    public List<PaymentMethod> GetPaymentMethods(int cartId)
    {
      throw new System.NotImplementedException();
    }

    public bool AddShippingMethodToCart(string shippingMethod)
    {
      throw new System.NotImplementedException();
    }

    public string CreateCustomer(Customer customer)
    {
      throw new System.NotImplementedException();
    }

    public Customer GetCustomerById(int customerId)
    {
      throw new System.NotImplementedException();
    }

    public string CreateCustomerAddress(int customerId, CustomerAddress customerAddress)
    {
      throw new System.NotImplementedException();
    }

    public List<CustomerAddress> GetCustomerAddresses(int customerId)
    {
      throw new System.NotImplementedException();
    }

    public OrderInfo GetOrderInfos(int orderNumber)
    {
      throw new System.NotImplementedException();
    }

    public bool SetOrderStatus(int orderNumber, OrderStatusType status)
    {
      throw new System.NotImplementedException();
    }

    public Product GetProductInfo(string productId)
    {
      throw new System.NotImplementedException();
    }

    public Category GetCategoryInfo(string categoryId)
    {
      throw new System.NotImplementedException();
    }

    public List<Inventory> GetInventories(string productId)
    {
      throw new System.NotImplementedException();
    }

    public List<ProductImage> GetProductImages(string productId)
    {
      throw new System.NotImplementedException();
    }

    public List<ProductLink> GetLinkedProducts(string productId)
    {
      throw new System.NotImplementedException();
    }

    public int GetStocksForProduct(string productId)
    {
      throw new System.NotImplementedException();
    }
  }
}
