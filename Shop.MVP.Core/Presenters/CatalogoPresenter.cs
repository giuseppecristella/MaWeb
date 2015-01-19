using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Shop.MVP.Core.Views;

namespace Shop.MVP.Core.Presenters
{
  public class CatalogoPresenter
  {
    private ICatalogoView _view;
    public CatalogoPresenter(ICatalogoView catalogoView)
    {
       
    }

    public void OnViewLoaded()
    {
      var cacheManager = CacheFactory.GetCacheManager();
      var products = cacheManager.GetData("ProductsList") as List<CategoryAssignedProduct>;

      foreach (var p in products)
      {

      }

      //CategoryAssignedProductViewModel productsViewModel =
      //   Mapper.Map<Customer, CategoryAssignedProductViewModel>(products);
      // _view.Products = products;
    }
  }
}
