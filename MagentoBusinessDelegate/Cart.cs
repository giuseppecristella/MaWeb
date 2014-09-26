using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;

 
namespace MagentoBusinessDelegate
{
  public class Cart
  {
    private readonly List<Product> _products;
    private decimal _total;
       
    public Cart()
    {
      _products = new List<Product>();
    }

    public IEnumerable<Product> Products
    {
      get { return _products; }
    }

    public decimal Total
    {
      get { return _total; }
    }

    public void AddProductAndUpdateTotal(Product product)
    {
      if (!_products.Contains(product))
      {
        _products.Add(product);
      }
      _total += decimal.Parse(product.price);
    }
  }
}
