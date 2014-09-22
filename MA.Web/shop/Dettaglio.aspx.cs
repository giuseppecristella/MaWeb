using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
public partial class shop_Dettaglio : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!helper.checkConnection())
    {
      HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
      HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
    }
    /*inizio codice da vecchia master page*/
    ArrayList arrayCart = (ArrayList)Session["carrello"];
    int numItems = 0;
    if (arrayCart != null)
    {
      for (int i = 0; i < arrayCart.Count; i++)
      {
        Product tProd = (Product)arrayCart[i];
        numItems += int.Parse(tProd.qty);
      }
    }
    ltrTotCart.Text = numItems.ToString();
    /*fine codice master page vecchia*/
    helper.checkConnection();
    if (!IsPostBack)
    {
      //try
      //{
      string _idProd = Request.QueryString["ProdId"];
      Product myProduct = Product.Info((string)HttpContext.Current.Cache["apiUrl"],
                                       (string)HttpContext.Current.Cache["sessionId"], new object[] { _idProd });
      /*categoria 37 -> SHOP VERDE /
* categoria 47 -> SHOP ROSSO*/
      bool isShopVerde = true;
      /*le categorie 44 e 45 sono riservate ai prodotti in vetrina quindi le escludo*/
      //myProduct.categories
      string idCategoria = "";
      string rootCat = "37";
      if (myProduct.categories.Contains("47"))
        isShopVerde = false;
      foreach (string sCatId in myProduct.categories)
      {
        if (sCatId != "44" && sCatId != "45" && sCatId != "37" && sCatId != "47")
          idCategoria = sCatId;
      }
      if (isShopVerde)
      {
        logo_v.Visible = true;
        main_navigation.Attributes["class"] = "main-menu verde";
        divSpotRosso.Visible = true;
        divCarrello.Style.Add("background", "#76A227");
        lblNomeProd.CssClass = "colore_verde";
      }
      else
      {
        rootCat = "47";
        logo_r.Visible = true;
        main_navigation.Attributes["class"] = "main-menu rosso";
        divCarrello.Style.Add("background", "#D10A11");
        lblNomeProd.CssClass = "colore_rosso";
        divSpotVerde.Visible = true;
      }
      /*RIPRISTINARE!!*/
      if (rootCat != (string)Session["rootCat"])
      {
        if (HttpContext.Current.Cache["sessionId"] == null)
        {
          HttpContext.Current.Cache.Insert("sessionId",
                                           helper.getConnection(Utility.SearchConfigValue("apiUrl"),
                                                                Utility.SearchConfigValue("apiUser"),
                                                                Utility.SearchConfigValue("apiPsw")));
        }
        HttpContext.Current.Cache.Insert("htmlMegaMenu", helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], rootCat));
      }
      if (HttpContext.Current.Cache["htmlMegaMenu"] == null)
      {
        if (HttpContext.Current.Cache["sessionId"] == null)
        {
          HttpContext.Current.Cache.Insert("sessionId",
                                           helper.getConnection(Utility.SearchConfigValue("apiUrl"),
                                                                Utility.SearchConfigValue("apiUser"),
                                                                Utility.SearchConfigValue("apiPsw")));
        }
        HttpContext.Current.Cache.Insert("htmlMegaMenu",
          helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"],
          (string)HttpContext.Current.Cache["sessionId"], rootCat));
      }
      menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];
      //+ " <li><a  href=\"../Index.html\">Torna al sito</a></li>";        /*visualizzo il dettaglio del prodotto*/
      /* visualizzo il nome della categoria di appartenenza del prodotto in dettaglio*/
      Category CategoryInfo = Category.Info((string)HttpContext.Current.Cache["apiUrl"],
                                            (string)HttpContext.Current.Cache["sessionId"],
                                            new object[] { idCategoria });
      lblNomeCatProd.Text = CategoryInfo.name;
      lblNomeProd.Text += myProduct.name;
      /*controllo la disponibilità*/
      if (myProduct.is_in_stock == "0")
      {
        btnaddTocart.Enabled = false;
        btnaddTocart.Visible = false;
        prodDisponibilità.Text = "Il prodotto non è più disponibile.";
      }
      Inventory[] scorteProdotto = Inventory.List((string)HttpContext.Current.Cache["apiUrl"],
                                                (string)HttpContext.Current.Cache["sessionId"],
                                                new object[] { _idProd });
      prodScorte.Text = scorteProdotto[0].qty.Substring(0, scorteProdotto[0].qty.IndexOf("."));
      //  ltrTitleProd.Text = myProduct.name;
      prodProduttore.Text = myProduct.produttore;
      //   prodModel.Text = myProduct.model;
      prodDescription.Text = myProduct.description;
      // prodNameDesc.Text = myProduct.name;
      prodPrice.Text = helper.FormatCurrency(myProduct.price);
      ProductImage[] myProductImages = ProductImage.List((string)HttpContext.Current.Cache["apiUrl"],
                                                       (string)HttpContext.Current.Cache["sessionId"],
                                                       new object[] { int.Parse(_idProd) });
      ArrayList ulrImages = new ArrayList();
      foreach (ProductImage p in myProductImages)
      {
        if (p.exclude == "1")
        {
          mainImage.Src = p.url;
        }
        //nel vettore le immagini contengono l'attributo posizione da implementare l'ordine in futuro
        else
          ulrImages.Add(p.url);
      }
      rptImages.DataSource = ulrImages;
      rptImages.DataBind();
      /*recupero gli eventuali prodotti ASSOCIATI*/
      ProductLink[] prodottiAssociati = ProductLink.List((string)HttpContext.Current.Cache["apiUrl"],
                                                       (string)HttpContext.Current.Cache["sessionId"],
                                                       new object[] { "related", int.Parse(_idProd) });
      if (prodottiAssociati.Length > 0)
      {
        Product[] ArrProdottiAssociati = new Product[prodottiAssociati.Length];
        for (int i = 0; i < prodottiAssociati.Length; i++)
        {
          //    Product tempProduct = Product.Info(apiUrl, sessionId, new object[] { prodottiAssociati[i].product_id });
          XmlRpcStruct filterOn = new XmlRpcStruct();
          XmlRpcStruct filterParams = new XmlRpcStruct();
          filterParams.Add("eq", prodottiAssociati[i].product_id);
          filterOn.Add("product_id", filterParams);
          Product[] tempProducts =
              Ez.Newsletter.MagentoApi.Product.List((string)HttpContext.Current.Cache["apiUrl"],
                                                    (string)HttpContext.Current.Cache["sessionId"],
                                                    new object[] { filterOn });
          ArrProdottiAssociati[i] = tempProducts[0];
        }
        rptProdAssociati.DataSource = ArrProdottiAssociati;
        rptProdAssociati.DataBind();
        rptProdAssociati.Visible = true;
      }
      else
      {
        rptProdAssociati.Visible = false;
      }
    }
  }

  protected void btnaddTocart_Click(object sender, EventArgs e)
  {
    string _idProd = Request.QueryString["ProdId"];
    //faccio una product.list con filtro! perchè mi servono meno attributi
    XmlRpcStruct filterOn = new XmlRpcStruct();
    XmlRpcStruct filterParams = new XmlRpcStruct();
    filterParams.Add("eq", _idProd);
    filterOn.Add("product_id", filterParams);
    Product[] myProducts = Ez.Newsletter.MagentoApi.Product.List((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { filterOn });
    myProducts[0].qty = "1";// in questo caso posso acquistare un solo prodotto alla volta prodQta.Text;
    ArrayList tempArrayCart = new ArrayList();
    helper.addProdToSessionCart(myProducts[0]);
    tempArrayCart = (ArrayList)Session["carrello"];
    Session["carrello"] = tempArrayCart;
    Response.Redirect("Carrello.html");
  }

  protected void _rptImagesItemDataBound(object sender, RepeaterItemEventArgs e)
  {
    HtmlImage imgThumb = (HtmlImage)e.Item.FindControl("imgThumb");
    imgThumb.Src = e.Item.DataItem.ToString();
    HtmlAnchor prettyThumb = (HtmlAnchor)e.Item.FindControl("prettyThumb");
    prettyThumb.HRef = e.Item.DataItem.ToString();
    prettyThumb.Title = " ";
    // e.Item.DataItem
  }

  protected void _rptProdAssociatiItemDataBound(object sender, RepeaterItemEventArgs e)
  {
    if (e.Item.ItemType != ListItemType.Header)
    {
      HtmlImage imgProdAss = (HtmlImage)e.Item.FindControl("imgProdAss");
      imgProdAss.Src = ((Ez.Newsletter.MagentoApi.Product)(e.Item.DataItem)).imageurl;
      HtmlAnchor linkProd = (HtmlAnchor)e.Item.FindControl("linkProd");
      linkProd.HRef =
      helper.GetAbsoluteUrl() + "Shop/" + ((Ez.Newsletter.MagentoApi.Product)(e.Item.DataItem)).name.Replace(" ", "-") + ".html";
    }
  }
}
