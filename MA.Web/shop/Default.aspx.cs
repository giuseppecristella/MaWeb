using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using Microsoft.AspNet.FriendlyUrls;

public partial class shop_Default : BasePage
{
  private const string redProductCategoryId = "44";
  private const string greenProductCategoryId = "45";
 
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      HttpContext.Current.Cache.Insert("htmlMegaMenu", Helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], (string)Session["rootCat"]));
      menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];

      var showcaseProducts = _repository.GetProductsByCategoryId(redProductCategoryId);
      lvProductsShowCase.DataSource = showcaseProducts;
      lvProductsShowCase.DataBind();
     
      // Product[] p = Product.Peppe(apiUrl, sessionId); BestSellers Products
    }
    catch (Exception ex)
    {
      // Log Exception
    }
  }

  protected void lvProductsShowCase_OnItemDataBound(object sender, ListViewItemEventArgs e)
  {
    var item = (ListViewDataItem)e.Item;
    var product = item.DataItem as CategoryAssignedProduct;
    if (product == null) return;
    SetProductsBoxStyle(item);

    var imgProd = (Image)item.FindControl("imgProduct");
    var imagePath = Helper.GetFolderAndImageName(product.imageurl);
    if (imagePath != null) imgProd.ImageUrl = string.Format("{0}{1}", "~/Public/", imagePath);

    var spanProductDescription = item.FindControl("spanProductDescription") as HtmlGenericControl;
    var name = ((CategoryAssignedProduct)(item.DataItem)).name;
    if (spanProductDescription != null) spanProductDescription.InnerHtml = Helper.ShortDesc(name, 132);
   
    var pProductPrice = item.FindControl("pProductPrice") as HtmlGenericControl;
    var magentoPrice = ((CategoryAssignedProduct)(item.DataItem)).price;
    if (pProductPrice != null) pProductPrice.InnerHtml = Helper.FormatCurrency(magentoPrice);
    
    var lbGreenProductDetail = item.FindControl("lbGreenProductDetail") as HtmlAnchor;
    if (lbGreenProductDetail != null) lbGreenProductDetail.HRef = FriendlyUrl.Href("~/Shop", "Dettaglio", name.Replace(" ", "-"));
  }

  private static void SetProductsBoxStyle(ListViewItem dataitem)
  {
    var moduleResult = dataitem.DataItemIndex % 4;
    if (moduleResult == 0)
    {
      var box_prodotto = dataitem.FindControl("box_prodotto") as HtmlGenericControl;
      if (box_prodotto != null) box_prodotto.Style.Add("margin-left", "30px");
    }
    if (moduleResult == 3)
    {
      var box_prodotto = dataitem.FindControl("box_prodotto") as HtmlGenericControl;
      if (box_prodotto != null) box_prodotto.Attributes["class"] = "one-fourth view view-first last";
    }
  }

}
