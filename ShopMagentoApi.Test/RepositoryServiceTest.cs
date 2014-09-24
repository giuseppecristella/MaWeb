using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopMagentoApi.Test
{
  [TestClass]
  public class RepositoryServiceTest
  {
    [TestInitialize]
    public void TestInitialize()
    {
      // Queste informazioni devono essere inizializzate nel global.asax
      MagentoConnection.Instance.url = "http://www.zoom2cart.com/api/xmlrpc";
      MagentoConnection.Instance.userId = "ws_user";
      MagentoConnection.Instance.password = "123456";
      
    }

    [TestMethod]
    public void GetProductsByCatIdTest()
    {

      var fakeCacheManager = new FakeCacheManager();

      var repository = new RepositoryService(MagentoConnection.Instance, fakeCacheManager);
      var products = repository.GetProductsByCatId("47");
      Assert.IsTrue(products.Length > 0, "Nessun prodotto trovato per una categoria che contiente prodotti");
    }
  }
}


