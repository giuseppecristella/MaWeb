using System;
using MagentoComunication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopMagentoApi.Test
{
  [TestClass]
  public class RepositoryTest
  {

    [TestMethod]
    public void SingletoneConnectionTest()
    {
      // Queste informazioni devono essere inizializzate nel global.asax
      MagentoConnection.Instance.url = "http://www.zoom2cart.com/api/xmlrpc";
      MagentoConnection.Instance.userId = "ws_user";
      MagentoConnection.Instance.password = "123456";

      var cacheManager = new CacheManager();

      var repository = new RepositoryService(MagentoConnection.Instance, cacheManager);
      var products = repository.GetProductsByCatId("47");
      Assert.IsTrue(products.Length > 0, "Nessun prodotto trovato per una categoria che contiente prodotti");
    }
  }


  public class CacheManager : ICacheManager
  {
    public bool Contains(string key)
    {
      return false;
    }
  }
}


