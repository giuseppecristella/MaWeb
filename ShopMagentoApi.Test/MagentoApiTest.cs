using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopMagentoApi.Test
{
  /// <summary>
  /// 
  /// </summary>
  [TestClass]
  public class MagentoApiTest
  {
    private string _apiUrl;
    private string _apiUser;
    private string _apiPassword;
    private string _sessionId; 

    [TestInitialize]
    public void TestInitialize()
    {
      _apiUrl = "http://www.calzafacileshop.com/api/xmlrpc";
      _apiUser = "ws_user";
      _apiPassword = "123456";
      CheckConnection();
    }

    [TestCleanup]
    public void TestCleanup()
    {
      // cleanup all the infrastructure that was needed for our tests.
    }

    [TestMethod]
    public void AssignedProductsTest()
    {
      string categoryId = "47";
      var assignedProducts = Category.AssignedProducts(_apiUrl, _sessionId, new object[] { categoryId });
      Assert.IsTrue(assignedProducts.Length > 0, "Nessun prodotto trovato per una categoria che contiente prodotti");
    }

    [TestMethod]
    public void ProducListTest()
    {
      
      var filterParams = new XmlRpcStruct();
      var filterOperator = new XmlRpcStruct ();
      filterOperator.Add("eq","173");
      filterParams.Add("product_id", filterOperator);
      var products = Product.List(_apiUrl, _sessionId, new object[] { filterParams });

    }

    private void CheckConnection()
    {
      _sessionId = Ez.Newsletter.MagentoApi.Connection.Login(_apiUrl, _apiUser, _apiPassword);
      Assert.IsNotNull(_sessionId);
    }
  }
}
