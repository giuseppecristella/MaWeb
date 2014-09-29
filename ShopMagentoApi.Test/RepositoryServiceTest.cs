using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;
using MagentoRepository.Repository;
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
    private static readonly FakeCacheManager FakeCacheManager = new FakeCacheManager();

    [TestInitialize]
    public void TestInitialize()
    {
      // Queste informazioni devono essere inizializzate nel global.asax
      MagentoConnection.Instance.Url = "http://www.zoom2cart.com/api/xmlrpc";
      MagentoConnection.Instance.UserId = "ws_user";
      MagentoConnection.Instance.Password = "123456";

    }

    [TestMethod]
    public void GetProductsByCategoryIdTest()
    {

      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

      var products = repository.GetProductsByCategoryId("47");
      Assert.IsTrue(products.Count > 0, "Nessun prodotto trovato per una categoria che contiente prodotti");

      // La cache deve contenere la lista dei prodotti dopo la prima chiamata
      var productsFromCache = FakeCacheManager.Get<List<CategoryAssignedProduct>>
        (string.Format("{0}47", ConfigurationHelper.CacheKeyNames[CacheKey.CategoryAssignedProducts]));
      Assert.IsTrue(productsFromCache.Count > 0, "La cache di memoria deve contenere dei prodotti");

      // Recuperato dalla cache la seconda volta, la cache deve contenere un solo prodotto
      products = repository.GetProductsByCategoryId("47");
      Assert.IsTrue(products.Count > 0, "Nessun prodotto trovato per una categoria che contiente prodotti");

      products = repository.GetProductsByCategoryId("000");
      Assert.IsNull(products, "Trovato un prodotto per una categoria non esistente");

    }

    [TestMethod]
    public void GetFilteredProducts()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

      // Carico un prodotto in cache e lo recupero
      FakeCacheManager.Add(string.Format("{0}1", ConfigurationHelper.CacheKeyNames[CacheKey.FilteredProducts]),
        new Product() { product_id = "1", description = "Descrizione del prodotto 1", name = "Prodotto di test 1" });

      var product = repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "product_id", Value = "1" });
      Assert.IsNotNull(product, "Nessun risultato trovato per un Id prodotto valido");
      Assert.AreEqual(product.product_id, "1");

      product = repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "product_id", Value = "179" });
      Assert.IsNotNull(product, "Nessun risultato trovato per un Id prodotto valido");

      product = repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "product_id", Value = "aaa" });
      Assert.IsNull(product, "Trovato un prodotto per un Id non valido");
    }

    [TestMethod]
    public void GetCategoryLevel()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
      var category = repository.GetCategoryLevel("47");
    }



  }
}


