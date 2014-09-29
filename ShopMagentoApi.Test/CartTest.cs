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

    private Product GetProductById(string productId)
    {
      _sessionId = Connection.Login(_apiUrl, _apiUser, _apiPassword);
      var filterParameters = new XmlRpcStruct();
      var filterOperator = new XmlRpcStruct {{"eq", productId}};
      filterParameters.Add("product_id", filterOperator);
      var products = Product.List(_apiUrl, _sessionId, new object[] { filterParameters });
      return products[0];
    }
  }
}
