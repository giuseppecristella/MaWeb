using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ez.Newsletter.MagentoApi;
using MagentoBusinessApi.Test;
using MagentoBusinessDelegate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cart = MagentoBusinessDelegate.Cart;
using CookComputing.XmlRpc;

namespace ShopMagentoApi.Test
{
  [TestClass]
  public class CartTest
  {
    private string _apiUrl;
    private string _apiUser;
    private string _apiPassword;
    private string _sessionId;

    [TestInitialize]
    public void TestInitialize()
    {
      _apiUrl = "http://www.zoom2cart.com/api/xmlrpc";
      _apiUser = "ws_user";
      _apiPassword = "123456";

      HttpContext.Current = new HttpContext(
        new HttpRequest(null, "http://tempuri.org", null),
        new HttpResponse(null));
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
    public void Sould_Delete_Products_From_Cart()
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

    private Product GetProductById(string productId)
    {
      _sessionId = Connection.Login(_apiUrl, _apiUser, _apiPassword);
      var filterParameters = new XmlRpcStruct();
      var filterOperator = new XmlRpcStruct { { "eq", productId } };
      filterParameters.Add("product_id", filterOperator);
      var products = Product.List(_apiUrl, _sessionId, new object[] { filterParameters });
      return products[0];
    }
  }
}
