using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using MagentoBusinessDelegate.Helpers;
using MagentoRepository.Helpers;
using MagentoRepository.Repository;
using Microsoft.AspNet.FriendlyUrls;

public partial class shop_Dettaglio : BasePage
{
  private static string _productName;
  private static string _productId;
  protected void Page_Load(object sender, EventArgs e)
  {
    _productName = Request.GetFriendlyUrlSegments()[0];
    if (string.IsNullOrEmpty(_productName)) Response.Redirect("Catalogo.aspx");

    if (IsPostBack) return;
    ltrTotCart.Text = Cart != null ? Cart.Total.ToString() : String.Empty;
    SetMainStyleAttributes();
    menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];

    var product = _repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "name", Value = _productName });
    _productId = product.product_id;

    BindProduct(_productId);
    BindInventoryInfo(_productId);
    BindProductImages(_productId);
    BindLinkedProducts(_productId);

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
  }

  protected void rptImages_OnItemDataBound(object sender, RepeaterItemEventArgs e)
  {
    var imgThumb = e.Item.FindControl("imgThumb") as HtmlImage;
    if (imgThumb != null) imgThumb.Src = e.Item.DataItem.ToString();
    var prettyThumb = e.Item.FindControl("prettyThumb") as HtmlAnchor;
    if (prettyThumb != null)
    {
      prettyThumb.HRef = e.Item.DataItem.ToString();
      prettyThumb.Title = string.Empty;
    }
  }

  protected void rptProdAssociati_OnItemDataBound(object sender, RepeaterItemEventArgs e)
  {
    if (e.Item.ItemType != ListItemType.Header)
    {
      var imgProdAss = (HtmlImage)e.Item.FindControl("imgProdAss");
      imgProdAss.Src = ((Ez.Newsletter.MagentoApi.Product)(e.Item.DataItem)).imageurl;
      var linkProd = (HtmlAnchor)e.Item.FindControl("linkProd");
      linkProd.HRef = string.Format("Dettaglio.aspx?Id={0}", ((Product)(e.Item.DataItem)).product_id);
    }
  }

  protected void btnaddTocart_Click(object sender, EventArgs e)
  {
    if (Product != null)
    {
      Product.qty = "1";
      CartHelper.AddProductToCartAndUpdateCache(Product);
    }
    Response.Redirect("~/shop/Carrello.aspx");
  }

  #region private methods

  private void BindProduct(string productId)
  {
    if (Product.name != null) lblNomeProd.Text += Product.name;

    prodProduttore.Text = Product.produttore;
    prodDescription.Text = Product.description;
    prodPrice.Text = helper.FormatCurrency(Product.price);

    var categoryId = GetProductCategory(Product.categories);
    BindCategoryName(categoryId);
    DisableProductWhenIsNotInStock(Product.is_in_stock);
  }

  private void BindLinkedProducts(string productId)
  {
    rptProdAssociati.Visible = false;
    var linkedProducts = _repository.GetLinkedProducts(productId);
    if (linkedProducts == null) return;

    var linkedProducstWithCompleteInfos = linkedProducts
      .Select(product => _repository.GetFilteredProducts
        (new Filter { FilterOperator = LogicalOperator.Eq, Key = "producId", Value = product.product_id }))
      .Where(p => p != null).ToList();

    // Stesso codice della linq lamba expression
    //foreach (var product in linkedProducts)
    //{
    //  var p = _repository.GetFilteredProducts(new Filter { FilterOperator = LogicalOperator.Eq, Key = "producId", Value = product.product_id });
    //  if (p != null)
    //    linkedProducstWithCompleteInfos.Add(p);
    //}

    rptProdAssociati.DataSource = linkedProducstWithCompleteInfos;
    rptProdAssociati.DataBind();
    rptProdAssociati.Visible = true;
  }

  private void BindProductImages(string productId)
  {
    mainImage.Src = GetProductMainImageUrl(productId);
    var images = GetProductImagesUrlExceptMain(productId);
    if (images == null) return;

    rptImages.DataSource = images;
    rptImages.DataBind();
  }

  private void BindInventoryInfo(string productId)
  {
    _repository.GetInventories(productId);
    Inventory[] scorteProdotto = Inventory.List(MagentoConnection.Instance.Url, MagentoConnection.Instance.SessionId,
      new object[] { productId });
    prodScorte.Text = scorteProdotto[0].qty.Substring(0, scorteProdotto[0].qty.IndexOf("."));

  }

  private void BindCategoryName(string categoryId)
  {
    var categoryInfo = _repository.GetCategoryInfo(categoryId);
    lblNomeCatProd.Text = (categoryInfo.name) ?? string.Empty;
  }

  private void DisableProductWhenIsNotInStock(string isInStock)
  {
    if (isInStock == "0")
    {
      btnaddTocart.Enabled = false;
      btnaddTocart.Visible = false;
      prodDisponibilità.Text = "Il prodotto non è più disponibile.";
    }
  }

  private void SetMainStyleAttributes()
  {
    logo_r.Visible = true;
    main_navigation.Attributes["class"] = "main-menu rosso";
    divCarrello.Style.Add("background", "#D10A11");
    lblNomeProd.CssClass = "colore_rosso";
    divSpotVerde.Visible = true;
  }

  private static string GetProductCategory(string[] categories)
  {
    var categoriesToExclude = ConfigurationHelper.HomeCategories.Union(new[] { ConfigurationHelper.RootCategory });
    var productSubCategories = categories.Except(categoriesToExclude).ToList();

    if (!productSubCategories.Any()) return null;
    return productSubCategories[0];
  }

  private List<string> GetProductImagesUrlExceptMain(string productId)
  {
    var productImages = _repository.GetProductImages(productId);
    if (productImages == null) return null;
    return productImages.Where(p => p.exclude != "1").Select(p => p.url).ToList();
  }

  private string GetProductMainImageUrl(string productId)
  {
    var productImages = _repository.GetProductImages(productId);
    return productImages.First(p => p.exclude == "1").url ?? string.Empty;
  }

  #endregion private methods

  public Product Product
  {
    get
    {
      return _repository.GetProductInfo(_productId);
    }
  }
}
