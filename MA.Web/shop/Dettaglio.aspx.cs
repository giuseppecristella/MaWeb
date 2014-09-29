using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using MagentoBusinessDelegate.Helpers;
using MagentoRepository.Helpers;

public partial class shop_Dettaglio : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

    // Totale ---> ltrTotCart.Text = numItems.ToString();

    if (!IsPostBack)
    {
      const bool isShopVerde = true;
      SetMainStyleAttributes();
      menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];

      string productId = Request.QueryString["Id"];
      var product = Product.Info(MagentoConnection.Instance.Url, MagentoConnection.Instance.SessionId, new object[] { productId });

      var categoryId = GetProductCategory(product.categories);

      #region Garbage Shop Verde
      //if (isShopVerde)
      //{
      //  logo_v.Visible = true;
      //  main_navigation.Attributes["class"] = "main-menu verde";
      //  divSpotRosso.Visible = true;
      //  divCarrello.Style.Add("background", "#76A227");
      //  lblNomeProd.CssClass = "colore_verde";
      //}
      #endregion Garbage Shop Verde



      /* visualizzo il nome della categoria di appartenenza del prodotto in dettaglio*/
      Category CategoryInfo = Category.Info(MagentoConnection.Instance.Url, MagentoConnection.Instance.SessionId, new object[] { categoryId });
      lblNomeCatProd.Text = CategoryInfo.name;
      lblNomeProd.Text += product.name;
      /*controllo la disponibilità*/
      if (product.is_in_stock == "0")
      {
        btnaddTocart.Enabled = false;
        btnaddTocart.Visible = false;
        prodDisponibilità.Text = "Il prodotto non è più disponibile.";
      }


      Inventory[] scorteProdotto = Inventory.List(MagentoConnection.Instance.Url, MagentoConnection.Instance.SessionId, new object[] { productId });
      prodScorte.Text = scorteProdotto[0].qty.Substring(0, scorteProdotto[0].qty.IndexOf("."));
      //  ltrTitleProd.Text = myProduct.name;
      prodProduttore.Text = product.produttore;
      //   prodModel.Text = myProduct.model;
      prodDescription.Text = product.description;
      // prodNameDesc.Text = myProduct.name;
      prodPrice.Text = helper.FormatCurrency(product.price);


      ProductImage[] myProductImages = ProductImage.List(MagentoConnection.Instance.Url, MagentoConnection.Instance.SessionId, new object[] { int.Parse(productId) });
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
      ProductLink[] prodottiAssociati = ProductLink.List(MagentoConnection.Instance.Url, MagentoConnection.Instance.SessionId, new object[] { "related", int.Parse(productId) });
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
              Ez.Newsletter.MagentoApi.Product.List(MagentoConnection.Instance.Url, MagentoConnection.Instance.SessionId, new object[] { filterOn });
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

  private static string GetProductCategory(string[] categories)
  {
    var categoriesToExclude = ConfigurationHelper.HomeCategories.Union(new[] { ConfigurationHelper.RootCategory });
    var productSubCategories = categories.Except(categoriesToExclude).ToList();

    if (!productSubCategories.Any()) return null;
    return productSubCategories[0];
  }

  private void SetMainStyleAttributes()
  {
    logo_r.Visible = true;
    main_navigation.Attributes["class"] = "main-menu rosso";
    divCarrello.Style.Add("background", "#D10A11");
    lblNomeProd.CssClass = "colore_rosso";
    divSpotVerde.Visible = true;
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
