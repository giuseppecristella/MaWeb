using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ez.Newsletter.MagentoApi;
using MagentoBusinessApi.Test;
using MagentoBusinessDelegate.Helpers;
using MagentoRepository.Connection;
using MagentoRepository.Helpers;
using MagentoRepository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Infrastructure.Cache;
using Cart = MagentoBusinessDelegate.Cart;
using CookComputing.XmlRpc;


namespace ShopMagentoApi.Test
{
  [TestClass]
  public class CartTest
  {
    private static readonly int testCartId = 482;
    private static readonly FakeCacheManager FakeCacheManager = new FakeCacheManager();

    [TestInitialize]
    public void TestInitialize()
    {
      MagentoConnection.Instance.Url = "http://www.zoom2cart.com/api/xmlrpc";
      MagentoConnection.Instance.UserId = "ws_user";
      MagentoConnection.Instance.Password = "123456";
      MagentoConnection.Instance.CacheManager = FakeCacheManager;
      MagentoConnection.Instance.Login();
    }

    [TestMethod]
    public void Should_Add_Key_To_Session_Cache()
    {
      var cache = new AspNetCacheManagerTest();
      cache.Add("test_key_string", "stringa di prova");
      var value = cache.Get<string>("test_key_string");
      Assert.AreEqual(value, "stringa di prova");
    }

    /// <summary>
    /// Integration Test: viene testato il processo di aggiunta prodotti
    /// al carrello, usando come meccanismo di cache quello effettivo
    /// che sarà utilizzato nell'applicazione ossia la session cache asp.net
    /// </summary>
    [TestMethod]
    public void Add_Some_Products_To_Cart()
    {
      var cache = new AspNetCacheManagerTest();
      var product = GetProductById("173");

      CartHelper.CacheManager = new AspNetCacheManagerTest();
      CartHelper.AddProductToCartAndUpdateCache(product);
      CartHelper.AddProductToCartAndUpdateCache(product);

      var cartFromCache = cache.Get<Cart>("Cart");
      Assert.AreEqual(cartFromCache.Products.Count(), 1);

      product = GetProductById("179");
      CartHelper.AddProductToCartAndUpdateCache(product);

      cartFromCache = cache.Get<Cart>("Cart");
      Assert.AreEqual(cartFromCache.Products.Count(), 2);
    }

    [TestMethod]
    public void Update_Product_Qty_Of_Items_In_Cart()
    {
      var cache = new AspNetCacheManagerTest();
      var product = GetProductById("173");

      CartHelper.CacheManager = new AspNetCacheManagerTest();
      CartHelper.AddProductToCartAndUpdateCache(product);
      product = GetProductById("179");
      CartHelper.AddProductToCartAndUpdateCache(product);

      var cartFromCache = cache.Get<Cart>("Cart");
      Assert.AreEqual(cartFromCache.Products.Count(), 2);

      Assert.IsNull(cartFromCache.Products.First(p => p.product_id == "173").qty);
      var itemToUpdate = cartFromCache.Products.First(p => p.product_id == "173");
      itemToUpdate.qty = "100";
      Assert.AreEqual(cartFromCache.Products.First(p => p.product_id == "173").qty, "100");
    }

    [TestMethod]
    public void Should_Delete_Products_From_Cart()
    {
      var productsToDelete = new List<Product>();

      // Creo un carrello con 2 prodotti
      var cache = new AspNetCacheManagerTest();
      var product = GetProductById("173");
      productsToDelete.Add(product);

      CartHelper.CacheManager = new AspNetCacheManagerTest();
      CartHelper.AddProductToCartAndUpdateCache(product);
      product = GetProductById("179");
      //productsToDelete.Add(product);
      CartHelper.AddProductToCartAndUpdateCache(product);

      var cartFromCache = cache.Get<Cart>("Cart");
      cartFromCache.DeleteProducts(productsToDelete);
      Assert.AreEqual(cartFromCache.Products.Count(), 1);
      Assert.AreEqual(cartFromCache.Products.First().product_id, "179");
    }

    [TestMethod]
    public void Should_Get_All_Shipping_Methods()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
    }

    /// <summary>
    /// Solo per creare un carrello di test
    /// </summary>
    [TestMethod]
    public void Should_Create_Cart_In_Magento()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
      var cart = repository.CreateCart();
    }

    [TestMethod]
    public void Should_Associate_Customer_To_Cart()
    {
      var key = ConfigurationHelper.CacheKeyNames;

      //var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
      //var cartId = repository.CreateCart();
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
      var customer = repository.GetCustomerById(33);
      customer.mode = "register";
      var result = repository.AssociateCustomerToCart(testCartId, customer);

      Assert.IsTrue(result, "Non è stato possibile associare un carrello valido ad un utente esistente");
    }

    #region Private Methods

    private Product GetProductById(string productId)
    {

      var filterParameters = new XmlRpcStruct();
      var filterOperator = new XmlRpcStruct { { "eq", productId } };
      filterParameters.Add("product_id", filterOperator);
      var products = Product.List(MagentoConnection.Instance.Url, MagentoConnection.Instance.SessionId, new object[] { filterParameters });
      return products[0];
    }
    #endregion
  }
}
