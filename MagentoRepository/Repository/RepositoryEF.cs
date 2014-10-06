using System;
using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;

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

    public string CreateCustomer(Customer customer)
    {
      throw new NotImplementedException();
    }

    public List<Customer> GetCustomerById(string customerId)
    {
      throw new NotImplementedException();
    }

    public string CreateCustomerAddress(int customerId, CustomerAddress customerAddress)
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
