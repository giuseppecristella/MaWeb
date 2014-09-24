using System;
using System.Collections;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
public partial class shop_Home_v : System.Web.UI.Page
{
  private string _pathUrl = "";
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      Session["rootCat"] = "37";
      if ((ArrayList)Session["carrello"] == null)
      {
        Session["carrello"] = new ArrayList();
      }
        if (!helper.checkConnection())
      {
        HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
        HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
      }
        //if (HttpContext.Current.Cache["htmlMegaMenu"] == null)
      //{
      //}
      if (HttpContext.Current.Cache["sessionId"] == null)
      {
        HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
      }
      HttpContext.Current.Cache.Insert("htmlMegaMenu", helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], (string)Session["rootCat"]));
        menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];
            CategoryAssignedProduct[] tempmyAssignedProducts = Category.AssignedProducts((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { 45 });
      lvVetrinaVerde.DataSource = tempmyAssignedProducts;// (ArrayList)HttpContext.Current.Cache["myAssignedProducts" + _catID.ToString()];
      lvVetrinaVerde.DataBind();
      CategoryAssignedProduct[] tempmyAssignedProductsRossa = Category.AssignedProducts((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { 44 });
      lvVetrinaRossa.DataSource = tempmyAssignedProductsRossa;// (ArrayList)HttpContext.Current.Cache["myAssignedProducts" + _catID.ToString()];
      lvVetrinaRossa.DataBind();
            /*PROVA API EST. AGGIUNTA FUNZIONE PER RECUPER BESTSERLLERS!!!!!
    Product[] p = Product.Peppe(apiUrl, sessionId);*/
    }
    catch (Exception ex)
    {
      helper.checkConnection();
      //  Response.Redirect("Catalogo.html");
      //  lblErr.Text = "apiurl: " + (string)HttpContext.Current.Cache["apiUrl"] + "SessId " + (string)HttpContext.Current.Cache["sessionId"] + ex.Message;//"session-test--> "+(string)Session["test"]+ " " +apiUrl + " sessionId: " + sessionId + " exc: " + ex.Message;
    }
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
    // imgProd.ImageUrl = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).imageurl;
    /*proviamo ad usare l'handler
   /handler.ashx?UrlFoto=http://www.materarredamenti.it/Handler.ashx?PhotoID=35&W_=200&H_=100
   */
    imgProd.ImageUrl = "../Handler.ashx?UrlFoto=" + ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).imageurl + "&W_=215&H_=215";
    HtmlGenericControl descProduct = (HtmlGenericControl)e.Item.FindControl("descProduct");
    string name = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).name;
    descProduct.InnerHtml = helper.ShortDesc(name, 132);
    HtmlGenericControl priceProduct = (HtmlGenericControl)e.Item.FindControl("priceProduct");
    string magento_price = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).price;
    priceProduct.InnerHtml = helper.FormatCurrency(magento_price);
    HtmlAnchor linkDettaglio_1 = (HtmlAnchor)e.Item.FindControl("linkDettaglio");
    HtmlAnchor linkDettaglio = (HtmlAnchor)e.Item.FindControl("lnkDettaglio_1");
    name = name.Replace(" ", "-");
    linkDettaglio.HRef = helper.GetAbsoluteUrl() + "shop" + _pathUrl + "/" + name + ".html";
    }
  protected void item_dataBound2(object sender, ListViewItemEventArgs e)
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
      HtmlGenericControl box_prodotto = (HtmlGenericControl)e.Item.FindControl("box_prodotto2");
      box_prodotto.Style.Add("margin-left", "30px");
    }
    if (dataitem.DataItemIndex % 4 == 3)
    {
      HtmlGenericControl box_prodotto = (HtmlGenericControl)e.Item.FindControl("box_prodotto2");
      box_prodotto.Attributes["class"] = "one-fourth view view-first last";
    }
    Image imgProd = (Image)e.Item.FindControl("imgProduct2");
      imgProd.ImageUrl = "../Handler.ashx?UrlFoto=" + ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).imageurl + "&W_=215&H_=215";
    HtmlGenericControl descProduct = (HtmlGenericControl)e.Item.FindControl("descProduct2");
    string name = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).name;
    descProduct.InnerHtml = helper.ShortDesc(name, 132);
    HtmlGenericControl priceProduct = (HtmlGenericControl)e.Item.FindControl("priceProduct2");
    string magento_price = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).price;
    priceProduct.InnerHtml = helper.FormatCurrency(magento_price);
    //  HtmlAnchor linkDettaglio_1 = (HtmlAnchor)e.Item.FindControl("linkDettaglio2");
    HtmlAnchor linkDettaglio = (HtmlAnchor)e.Item.FindControl("lnkDettaglio_2");
    name = name.Replace(" ", "-");
    linkDettaglio.HRef = helper.GetAbsoluteUrl() + "shop" + _pathUrl + "/" + name + ".html";
    }
}
