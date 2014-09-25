using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;

public partial class shop_Catalogo : System.Web.UI.Page
{
  private bool isShopVerde = true;
  public int i = 0;
  private string mainCatName = "";
  private string _pathUrl = "";

  private IRepository _repository;

  // Constructor chaining; 
  // centralizzo la creazione dell'istanza della classe repository e del singleton 
  public shop_Catalogo()
    : this(new RepositoryService(MagentoConnection.Instance, new AspnetCacheManager()))
  {

  }

  public shop_Catalogo(RepositoryService repository)
  {
    _repository = repository;
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      var cart = Cart;
      var totale = cart.Sum(p => int.Parse(p.price));
      ltrTotCart.Text = totale.ToString();

      // Controlla la connessione?  Dovrebbe funzionare con l'introduzione del singleton
      if (!helper.checkConnection())
      {
        HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
        HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
      }
      /*PROVA API EST. AGGIUNTA FUNZIONE PER RECUPER BESTSERLLERS!!!!!
      Product[] p = Product.Peppe(apiUrl, sessionId);*/
    }
    catch (Exception ex)
    {
      helper.checkConnection();
      // Response.Redirect("Catalogo.html");
      // lblErr.Text = "apiurl: " + (string)HttpContext.Current.Cache["apiUrl"] + "SessId " + (string)HttpContext.Current.Cache["sessionId"] + ex.Message;//"session-test--> "+(string)Session["test"]+ " " +apiUrl + " sessionId: " + sessionId + " exc: " + ex.Message;
    }
  }

  private static void CalculateTotal(List<Product> arrayCart, int numItems)
  {
    if (arrayCart == null) return;

    for (int i = 0; i < arrayCart.Count; i++)
    {
      Product tProd = (Product)arrayCart[i];
      numItems += int.Parse(tProd.qty);
    }
  }


  private List<Product> Cart
  {
    get
    {
      var cart = new List<Product>();
      if (Session["carrello"] != null)
      {
        cart = Session["carrello"] as List<Product>;
      }
      return cart;
    }
  }

  private string PrintBread(string ID, ArrayList arrBreadCatId, ArrayList arrPathUrl)
  {
    /*mi conservo in cache tutte le chiamate all'api category_level per ciascun ID di categoria*/
    object catBread = null;
    if (HttpContext.Current.Cache["category_Level_" + ID] == null)
    {
      catBread = Category.Level((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { ID });
      HttpContext.Current.Cache.Insert("category_Level_" + ID, catBread);
    }
    System.Collections.Hashtable hashcatBread = (System.Collections.Hashtable)HttpContext.Current.Cache["category_Level_" + ID];
    string parentID = (string)hashcatBread["parent_id"];
    //arrBread.Add("<a href=\"Prodotti.aspx?CatId=" + (string)hashcatBread["category_id"] + "\">" + (string)hashcatBread["name"] + "</a>"+"&gt;" );
    arrBreadCatId.Add((string)hashcatBread["category_id"]);
    arrPathUrl.Add((string)hashcatBread["name"] + "/");
    return parentID;
  }

  protected void item_dataBound(object sender, ListViewItemEventArgs e)
  {
    //try
    //{
    string _catID = Request.QueryString["CatId"];
    if (string.IsNullOrEmpty(_catID))
      _catID = "40";
    ListViewDataItem dataitem = (ListViewDataItem)e.Item;
    if (dataitem.DataItemIndex % 4 == 0)
    // classe margin
    {
      HtmlGenericControl box_prodotto = (HtmlGenericControl)e.Item.FindControl("box_prodotto");
      box_prodotto.Style.Add("margin-left", "30px");
    }
    if (dataitem.DataItemIndex % 4 == 3)
    {
      HtmlGenericControl box_prodotto = (HtmlGenericControl)e.Item.FindControl("box_prodotto");
      box_prodotto.Attributes["class"] = "one-fourth view view-first last";
    }
    Image imgProd = (Image)e.Item.FindControl("imgProduct");
    imgProd.ImageUrl = "../Handler.ashx?UrlFoto=" + ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).imageurl + "&W_=215&H_=215";
    HtmlGenericControl descProduct = (HtmlGenericControl)e.Item.FindControl("descProduct");
    string name = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).name;
    descProduct.InnerHtml = helper.ShortDesc(name, 132);
    HtmlGenericControl priceProduct = (HtmlGenericControl)e.Item.FindControl("priceProduct");
    HtmlGenericControl divMaskProd = (HtmlGenericControl)e.Item.FindControl("divMaskProd");
    if (isShopVerde)
    {
      priceProduct.Attributes["Class"] = "desc_prezzo_home verde";
      divMaskProd.Attributes["Class"] = "mask_green";
    }
    else
    {
      priceProduct.Attributes["Class"] = "desc_prezzo_home rosso";
      divMaskProd.Attributes["Class"] = "mask_red";
    }
    string magento_price = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).price;
    priceProduct.InnerHtml = helper.FormatCurrency(magento_price);
    HtmlAnchor linkDettaglio_1 = (HtmlAnchor)e.Item.FindControl("linkDettaglio");
    HtmlAnchor linkDettaglio = (HtmlAnchor)e.Item.FindControl("lnkDettaglio_1");
    name = name.Replace(" ", "-");
    linkDettaglio.HRef = helper.GetAbsoluteUrl() + "shop" + _pathUrl + "/" + name + ".html";
  }

  protected void pagerProducts_PreRender(object sender, EventArgs e)
  {
    var rootCat = SetShopTypeInfo();
    HttpContext.Current.Cache.Insert("htmlMegaMenu", helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], rootCat));
    menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];

    var products = _repository.GetProductsByCatId("47");
    if (products != null && products.Any())
    {
      var productsInStock = products.Where(p => p.qty_in_stock > 0);
      bool isPagerVisible = (productsInStock.Count() > pagerProducts.PageSize);
      ShowHidePagerForShop(isPagerVisible);
      lvProducts.DataSource = productsInStock;
      lvProducts.DataBind();
    }
  }

  private string SetShopTypeInfo()
  {
    string catId = "47";
    if (!string.IsNullOrEmpty(Request.QueryString["CatId"]))
      catId = Request.QueryString["CatId"];
    object[] catIdObj = { catId };

/*Recupero il nome della categoria e lo scrivo nella label*/
    // Singletone per gestire la connessione a la sessionId
    object catSubMenu = Category.Level((string) HttpContext.Current.Cache["apiUrl"],
      (string) HttpContext.Current.Cache["sessionId"], catIdObj);
    System.Collections.Hashtable hashSubMenu = (System.Collections.Hashtable) catSubMenu;
    lblCategoria.Text = (string) hashSubMenu["name"];
    string rootCat = "37";
    if ((string) hashSubMenu["parent_id"] == "47")
    {
      isShopVerde = false;
      //shop rosso
      rootCat = "47";
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

  private void ShowHidePagerForShop(bool isPagerVisible)
  {
    if (isShopVerde)
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

  protected void addToCart(object sender, EventArgs e)
  {
    LinkButton lnkbtn = (LinkButton)sender;
    // CategoryAssignedProduct tempproductCart = new CategoryAssignedProduct();
    // tempproductCart.product_id = lnkbtn.Text;
    //la product info è veloce ma meglio usarla per il dettaglio del prodotto selezionato
    //Product myProductInfo = Product.Info(apiUrl, sessionId, new object[] { tempproductCart.product_id });
    //faccio una product.list con filtro! perchè mi servono meno attributi

    XmlRpcStruct filterParameters = new XmlRpcStruct();
    XmlRpcStruct filterOperator = new XmlRpcStruct();
    filterOperator.Add("eq", lnkbtn.Text); // operatore booleano
    filterParameters.Add("product_id", filterOperator);

    Product[] myProducts = Ez.Newsletter.MagentoApi.Product.List(
      (string)HttpContext.Current.Cache["apiUrl"],
      (string)HttpContext.Current.Cache["sessionId"],
      new object[] { filterParameters });

    myProducts[0].qty = "1";
    ArrayList tempArrayCart = new ArrayList();
    helper.addProdToSessionCart(myProducts[0]);
    tempArrayCart = (ArrayList)Session["carrello"];
    Session["carrello"] = tempArrayCart;
    Response.Redirect("Carrello.html");
  }
}
