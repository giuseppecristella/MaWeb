using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using MagentoBusinessDelegate.Helpers;
using MagentoComunication.Cache;
using MagentoRepository.Repository;
using Cart = MagentoBusinessDelegate.Cart;

public partial class shop_Catalogo : System.Web.UI.Page
{
  private const string DefaultCategory = "47";
  private bool _isShopVerde = true;
  private readonly IRepository _repository;
  private readonly ICacheManager _cache;
  private List<CategoryAssignedProduct> _products;

  #region Ctor

  // Constructor chaining; 
  // centralizzo la creazione dell'istanza della classe repository e del singleton 
  public shop_Catalogo()
    : this(new RepositoryService(MagentoConnection.Instance, new AspnetCacheManager()))
  {

  }

  public shop_Catalogo(RepositoryService repository)
  {
    _repository = repository;
    // come gestire una singola istanza della classe cache manager?
    _cache = new AspnetCacheManager();
  }

  #endregion Ctor

  #region Events

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      ltrTotCart.Text = Cart != null ? Cart.Total.ToString() : String.Empty;
    }
    catch (Exception ex)
    {
      // Response.Redirect("Catalogo.html");
    }
  }

  protected void item_dataBound(object sender, ListViewItemEventArgs e)
  {
    var item = e.Item as ListViewDataItem;
    if (item == null) return;

    var product = item.DataItem as CategoryAssignedProduct;
    if (product != null)
    {
      var priceProduct = (HtmlGenericControl)e.Item.FindControl("priceProduct");
      var imgProd = (Image)e.Item.FindControl("imgProduct");
      var descProduct = (HtmlGenericControl)e.Item.FindControl("descProduct");
      var linkDettaglio = (HtmlAnchor)e.Item.FindControl("lnkDettaglio_1");

      // Immagine    
      if (imgProd != null && product.imageurl != null)
        imgProd.ImageUrl = string.Format("../Handler.ashx?UrlFoto={0}&W_=215&H_=215", (product.imageurl));
      // Descrizione  
      if (descProduct != null && product.name != null)
        descProduct.InnerHtml = helper.ShortDesc(product.name, 132);
      // Prezzo
      if (priceProduct != null && product.price != null)
        priceProduct.InnerHtml = helper.FormatCurrency(product.price);
      // Link pagina dettaglio   
      if (linkDettaglio != null && product.name != null)
        linkDettaglio.HRef = string.Format("{0}shop/{1}.html", helper.GetAbsoluteUrl(), product.name.Replace(" ", "-"));

      SetItemStyleAttributes(item);
    }
  }

  protected void pagerProducts_PreRender(object sender, EventArgs e)
  {
    // Inizializza i settings relativi allo shop verde o rosso
    var rootCat = SetShopTypeInfo();

    // Ottiene l'html da renderizzare per il megamenu e lo persiste in memoria
    HttpContext.Current.Cache.Insert("htmlMegaMenu", helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], rootCat));
    menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];

    if (BindProductsToList())
      ShowHidePagerForShop();
  }

  protected void AddToCart(object sender, EventArgs e)
  {
    Product product;
    using (var lnkbtn = (LinkButton)sender)
    {
      product = _repository.GetProductById(lnkbtn.Text);
    }
    if (product != null)
    {
      product.qty = "1";
      CartHelper.AddProductToCartAndUpdateCache(product);
    }
    Response.Redirect("Carrello.html");
  }

  #endregion Events

  #region Properties

  private Cart Cart
  {
    get
    {
      var key = ConfigurationHelper.CacheKeyNames[CacheKey.Cart];
      return (key != null && _cache.Contains(key)) ? _cache.Get<Cart>(key) : null;
    }
  }
  public List<CategoryAssignedProduct> Products
  {
    get { return _cache.Get<List<CategoryAssignedProduct>>(DefaultCategory); }
    set { _products = value; }
  }

  #endregion Properties

  #region Private Methods
  private bool BindProductsToList()
  {
    var products = _repository.GetProductsByCategoryId(DefaultCategory);
    if (products == null || !products.Any()) return false;

    Products = products.Where(p => p.qty_in_stock > 0).ToList();
    if (!Products.Any()) return false;
    lvProducts.DataSource = Products;
    lvProducts.DataBind();

    return true;
  }

  private string SetShopTypeInfo()
  {
    string catId = DefaultCategory;
    if (!string.IsNullOrEmpty(Request.QueryString["CatId"]))
      catId = Request.QueryString["CatId"];
    object[] catIdObj = { catId };

    /*Recupero il nome della categoria e lo scrivo nella label*/
    // Singletone per gestire la connessione a la sessionId
    object catSubMenu = Category.Level((string)HttpContext.Current.Cache["apiUrl"],
      (string)HttpContext.Current.Cache["sessionId"], catIdObj);
    var hashSubMenu = (System.Collections.Hashtable)catSubMenu;
    lblCategoria.Text = (string)hashSubMenu["name"];
    string rootCat = "37";
    if ((string)hashSubMenu["parent_id"] == DefaultCategory)
    {
      _isShopVerde = false;
      //shop rosso
      rootCat = DefaultCategory;
      logo_r.Visible = true;
      main_navigation.Attributes["class"] = "main-menu rosso";
      divCarrello.Style.Add("background", "#D10A11");
      divSpotVerde.Visible = true;
      lblCategoria.CssClass = "colore_rosso";
    }
    else
    {
      //shop verde
      lblCategoria.CssClass = "colore_verde";
      logo_v.Visible = true;
      main_navigation.Attributes["class"] = "main-menu verde";
      divSpotRosso.Visible = true;
      divCarrello.Style.Add("background", "#76A227");
    }
    return rootCat;
  }

  private void ShowHidePagerForShop()
  {
    bool isPagerVisible = (Products.Count() > pagerProducts.PageSize) && (Products != null);
    if (_isShopVerde)
    {
      pagerProducts.Visible = isPagerVisible;
      pagerRosso.Visible = false;
    }
    else
    {
      pagerRosso.Visible = isPagerVisible;
      pagerProducts.Visible = false;
    }
  }

  private void SetItemStyleAttributes(ListViewDataItem item)
  {
    var boxProdotto = (HtmlGenericControl)e.Item.FindControl("box_prodotto");
    var priceProduct = (HtmlGenericControl)e.Item.FindControl("priceProduct");
    var divMaskProd = (HtmlGenericControl)e.Item.FindControl("divMaskProd");
    if (item.DataItemIndex % 4 == 0)
    // classe margin
    {
      boxProdotto.Style.Add("margin-left", "30px");
    }
    if (item.DataItemIndex % 4 == 3)
    {
      boxProdotto.Attributes["class"] = "one-fourth view view-first last";
    }
    if (_isShopVerde)
    {
      priceProduct.Attributes["Class"] = "desc_prezzo_home verde";
      divMaskProd.Attributes["Class"] = "mask_green";
    }
    else
    {
      priceProduct.Attributes["Class"] = "desc_prezzo_home rosso";
      divMaskProd.Attributes["Class"] = "mask_red";
    }
  }

  #endregion Private Methods
}
