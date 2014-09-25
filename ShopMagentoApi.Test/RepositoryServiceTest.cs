using System;
using System.Linq;
using Ez.Newsletter.MagentoApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopMagentoApi.Test
{
  /// <summary>
  /// Integration Test: Vengono testati i metodi esposti dal repository service
  /// usando una classe fake di cache che persite i dati in memoria in un dizionario
  /// si usa l'istanza concreta del web service di magento
  /// </summary>
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

      products = repository.GetProductsByCatId("47");
      Assert.IsTrue(products.Length > 0, "Nessun prodotto trovato per una categoria che contiente prodotti");

      var productsFromCache = fakeCacheManager.Get<CategoryAssignedProduct[]>("CategoryAssignedProduct47");
      Assert.AreEqual(products.Count(),productsFromCache.Count(),"");

      products = repository.GetProductsByCatId("000");
      Assert.IsNull(products, "Trovato un prodotto per una categoria non esistente");
    }
  }
}


