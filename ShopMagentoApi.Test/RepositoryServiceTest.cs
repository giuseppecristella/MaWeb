using System.Collections.Generic;
using System.Linq;
using System.Net;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Connection;
using MagentoRepository.Helpers;
using MagentoRepository.Repository;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Infrastructure.Cache;

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

    // to delete
    [TestMethod]
    public void AddProductToELCacheManager()
    {
      var cacheManager = CacheFactory.GetCacheManager();
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

      var products = repository.GetProductsByCategoryId("47");
      //    var result = cacheManager.GetData("test_products") as List<CategoryAssignedProduct>;
      //  Assert.IsNotNull(result);
      cacheManager.Add("ProductsList", products);
      //  Assert.IsNotNull(products, "Nessun prodoto trovato");
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

      // Questa chiamata recupera i dati dalla cache
      products = repository.GetProductsByCategoryId("47");
      Assert.IsTrue(products.Count > 0, "Nessun prodotto trovato per una categoria che contiente prodotti");

      products = repository.GetProductsByCategoryId("000");
      Assert.IsNull(products, "Trovato un prodotto per una categoria non esistente");

    }

    [TestMethod]
    public void Get_Products_Filtered_By_ProductID_On_Equality_Operator()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

      // Carico un prodotto in cache e lo recupero
      FakeCacheManager.Add(string.Format("{0}1", ConfigurationHelper.CacheKeyNames[CacheKey.FilteredProducts]),
        new Product() { product_id = "1", description = "Descrizione del prodotto 1", name = "Prodotto di test 1" });

      var product = repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "product_id", Value = "1" });
      Assert.IsNotNull(product, "Nessun risultato trovato per un Id prodotto valido");
      Assert.AreEqual(product.product_id, "1");

      // Il prodotto non è in cache esegue la chiamata api
      product = repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "product_id", Value = "179" });
      Assert.IsNotNull(product, "Nessun risultato trovato per un Id prodotto valido");

      product = repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "product_id", Value = "aaa" });
      Assert.IsNull(product, "Trovato un prodotto per un Id non valido");

      // Aggiungere i metodi relativi alle altre operazioni logiche su attributi diversi
      const string name = "Basamento impero struttura in metallo decorato";

      product = repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "name", Value = name });
      Assert.IsTrue(product.name == name);

    }

    [TestMethod]
    public void GetProductInfo()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

      // Carico un prodotto in cache e lo recupero
      FakeCacheManager.Add(string.Format("{0}1", ConfigurationHelper.CacheKeyNames[CacheKey.ProductInfo]),
        new Product() { product_id = "1", description = "Descrizione del prodotto 1", name = "Prodotto di test 1" });

      var product = repository.GetProductInfo("1");
      Assert.IsNotNull(product, "Nessun risultato trovato per un Id prodotto valido");
      Assert.AreEqual(product.product_id, "1");

      // Il prodotto non è in cache esegue la chiamata api
      product = repository.GetProductInfo("173");
      Assert.IsNotNull(product, "Nessun risultato trovato per un Id prodotto valido");

      product = repository.GetProductInfo("123456");
      Assert.IsNull(product, "Trovato un prodotto per un Id non valido");
    }

    [TestMethod]
    public void GetInventories()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

      var fakeInventories = new List<Inventory>();
      fakeInventories.Add(new Inventory() { product_id = "173", is_in_stock = "0", qty = "10", sku = "" });

      // Carico un prodotto in cache e lo recupero
      FakeCacheManager.Add(string.Format("{0}173", ConfigurationHelper.CacheKeyNames[CacheKey.Inventories]),
        fakeInventories);

      var inventoryFromCache = repository.GetInventories("173");
      Assert.IsNotNull(inventoryFromCache, "Nessun risultato trovato per un Id prodotto valido");
      Assert.AreEqual(inventoryFromCache.FirstOrDefault().product_id, "173");

      // elimino l'informazione dalla cache
      FakeCacheManager.Remove(string.Format("{0}173", ConfigurationHelper.CacheKeyNames[CacheKey.Inventories]));

      // Il prodotto non è in cache esegue la chiamata api
      var inventoryFromRepository = repository.GetInventories("173");
      Assert.IsNotNull(inventoryFromRepository, "Nessun risultato trovato per un Id prodotto valido");

      Assert.AreNotEqual(inventoryFromCache.FirstOrDefault().qty, inventoryFromRepository.FirstOrDefault().qty);

      inventoryFromRepository = repository.GetInventories("123456");
      Assert.IsNull(inventoryFromRepository, "Trovato un prodotto per un Id non valido");
    }

    [TestMethod]
    public void GetProductImages()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

      var fakeProductImage = new List<ProductImage>();
      fakeProductImage.Add(new ProductImage() { exclude = "1", file = "path", url = "url" });
      fakeProductImage.Add(new ProductImage() { exclude = "0", file = "path", url = "url" });

      // Carico una lista fake di immagini in cache
      FakeCacheManager.Add(string.Format("{0}173", ConfigurationHelper.CacheKeyNames[CacheKey.ProductImages]),
        fakeProductImage);

      var productImages = repository.GetProductImages("173");
      Assert.IsNotNull(productImages, "Nessun risultato per un prodotto memorizzato in cache");
      Assert.AreEqual(productImages[0].file, fakeProductImage[0].file);
      Assert.AreEqual(productImages[0].exclude, fakeProductImage[0].exclude);
      Assert.AreEqual(productImages[0].url, fakeProductImage[0].url);

      FakeCacheManager.Remove(string.Format("{0}173", ConfigurationHelper.CacheKeyNames[CacheKey.ProductImages]));
      productImages = repository.GetProductImages("173");
      Assert.IsNotNull(productImages, "Nessun risultato per un Id prodotto valido");
      Assert.AreNotEqual(productImages[0].file, fakeProductImage[0].file);
      Assert.AreNotEqual(productImages[0].url, fakeProductImage[0].url);

      // testare un prodotto che non ha immagini, il metodo mi deve restituire lista null
    }

    [TestMethod]
    public void Should_Download_Products_Images_And_Save_To_Local_Folder()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
      var productImages = repository.GetProductImages("173");
      string localFilename = @"c:\temp\tofile.jpg";
      using (WebClient client = new WebClient())
      {
        client.DownloadFile(productImages[0].url, localFilename);
      }
    }

    [TestMethod]
    public void GetLinkedProducts()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

      var fakeLinkedProducts = new List<ProductLink>();
      fakeLinkedProducts.Add(new ProductLink() { product_id = "539", position = "", set = "", sku = "", type = "" });

      // Carico una lista fake di prodotti associati
      FakeCacheManager.Add(string.Format("{0}539", ConfigurationHelper.CacheKeyNames[CacheKey.LinkedProducts]),
        fakeLinkedProducts);

      var linkedProducts = repository.GetLinkedProducts("539");
      Assert.IsNotNull(linkedProducts, "Nessun risultato per un prodotto memorizzato in cache");
      Assert.AreEqual(linkedProducts[0].product_id, fakeLinkedProducts[0].product_id);

      FakeCacheManager.Remove(string.Format("{0}539", ConfigurationHelper.CacheKeyNames[CacheKey.LinkedProducts]));
      linkedProducts = repository.GetLinkedProducts("539");
      Assert.IsNotNull(linkedProducts, "Nessun risultato per un prodotto che possiede dei prodotti correlati");


    }


    #region Category Test

    [TestMethod]
    public void GetCategoryLevel()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
      var category = repository.GetCategoryLevel("47");
      Assert.IsNotNull(category, "Nessun risultato per un Id categoria valido");
      // Approfondire l'utilità della level per recuperare il grafo delle categorie nel contesto applicativo
    }

    [TestMethod]
    public void GetCategoryInfo()
    {
      var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

      // Carico categoria fake in cache
      FakeCacheManager.Add(string.Format("{0}999", ConfigurationHelper.CacheKeyNames[CacheKey.CategoryInfo]),
        new Category() { category_id = "999", description = "Descrizione categoria 999", name = "Categoria di test 999" });

      // recupero la categoria fake 
      var category = repository.GetCategoryInfo("999");
      Assert.IsNotNull(category, "Nessun risultato per un Id categoria memorizzato in cache");

      // elimino la categoria fake dalla cache
      FakeCacheManager.Remove(string.Format("{0}999", ConfigurationHelper.CacheKeyNames[CacheKey.CategoryInfo]));

      // provo a recuperare nuovamente la categoria fake 
      category = repository.GetCategoryInfo("999");
      Assert.IsNull(category, "Trovato un risultato per un Id categoria eliminato dalla cache");

      category = repository.GetCategoryInfo("47");
      Assert.IsNotNull(category, "Nessun risultato per un Id categoria valido");
    }

    #endregion Category Test

  }
}


