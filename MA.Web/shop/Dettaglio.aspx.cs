using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;
using MagentoRepository.Repository;

public partial class shop_Dettaglio : BasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ltrTotCart.Text = Cart != null ? Cart.Total.ToString() : String.Empty;

    if (!IsPostBack)
    {
      SetMainStyleAttributes();
      menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];

      if (string.IsNullOrEmpty(Request.QueryString["Id"])) Response.Redirect("Catalogo.aspx");
      var productId = Request.QueryString["Id"];
      BindProduct(productId);
      BindInventoryInfo(productId);
      BindProductImages(productId);
      BindLinkedProducts(productId);
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
  }

  protected void _rptImagesItemDataBound(object sender, RepeaterItemEventArgs e)
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

  protected void _rptProdAssociatiItemDataBound(object sender, RepeaterItemEventArgs e)
  {
    if (e.Item.ItemType != ListItemType.Header)
    {
      var imgProdAss = (HtmlImage)e.Item.FindControl("imgProdAss");
      imgProdAss.Src = ((Ez.Newsletter.MagentoApi.Product)(e.Item.DataItem)).imageurl;
      var linkProd = (HtmlAnchor)e.Item.FindControl("linkProd");
      linkProd.HRef = string.Format("Dettaglio.aspx?Id={0}", ((Product)(e.Item.DataItem)).product_id);
    }
  }

  #region private methods

  private void BindProduct(string productId)
  {
    var product = _repository.GetProductInfo(productId);

    if (product.name != null) lblNomeProd.Text += product.name;

    prodProduttore.Text = product.produttore;
    prodDescription.Text = product.description;
    prodPrice.Text = helper.FormatCurrency(product.price);

    var categoryId = GetProductCategory(product.categories);
    BindCategoryName(categoryId);
    DisableProductWhenIsNotInStock(product.is_in_stock);
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

}
