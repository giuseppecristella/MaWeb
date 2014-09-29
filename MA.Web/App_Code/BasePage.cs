using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using MagentoBusinessDelegate.Helpers;
using MagentoComunication.Cache;
using MagentoRepository.Helpers;
using MagentoRepository.Repository;
using Cart = MagentoBusinessDelegate.Cart;


/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
  protected readonly IRepository _repository;
  protected readonly ICacheManager _cache;

	 #region Ctor

  // Constructor chaining; 
  // centralizzo la creazione dell'istanza della classe repository e del singleton 
  public BasePage()
    : this(new RepositoryService(MagentoConnection.Instance, new AspnetCacheManager()))
  {

  }

  public BasePage(RepositoryService repository)
  {
    _repository = repository;
    // come gestire una singola istanza della classe cache manager?
    _cache = new AspnetCacheManager();
  }

  #endregion Ctor

  protected Cart Cart
  {
    get
    {
      var key = ConfigurationHelper.CacheKeyNames[CacheKey.Cart];
      return (key != null && _cache.Contains(key)) ? _cache.Get<Cart>(key) : null;
    }
  }

  protected void AddToCart(object sender, EventArgs e)
  {
    Product product;
    using (var lnkbtn = (LinkButton)sender)
    {
      product = _repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "product_id", Value = lnkbtn.Text });
    }
    if (product != null)
    {
      product.qty = "1";
      CartHelper.AddProductToCartAndUpdateCache(product);
    }
    Response.Redirect("~/shop/Carrello.html");
  }
}