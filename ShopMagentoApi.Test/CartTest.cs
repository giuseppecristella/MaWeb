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


    [TestMethod]
    public void Add_Product_To_Cart()
    {
      var cache = new AspNetCacheManagerTest();

      _sessionId = Ez.Newsletter.MagentoApi.Connection.Login(_apiUrl, _apiUser, _apiPassword);
      XmlRpcStruct filterParameters = new XmlRpcStruct();
      XmlRpcStruct filterOperator = new XmlRpcStruct();
      filterOperator.Add("eq", "173"); // operatore booleano
      filterParameters.Add("product_id", filterOperator);

      Product[] products = Product.List(
        _apiUrl,
        _sessionId,
        new object[] { filterParameters });

      CartHelper.CacheManager = new AspNetCacheManagerTest();
      CartHelper.AddProductToSessionCart(products[0]);
      CartHelper.AddProductToSessionCart(products[0]);

      var cartFromCache = cache.Get<Cart>("carrello");
      Assert.AreEqual(cartFromCache.Products.Count(), 2);


      // Aggiunta prodotto da lista prodotti oppure prodotto dettaglio
      // Scenario: sono in catalogo aggiungo, 
      // leggo dalla sessione se non trovo niente faccio una new
      // altrimenti aggiorno

    }
  }
}
