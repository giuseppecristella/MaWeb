using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;
using Microsoft.AspNet.FriendlyUrls;

public partial class Design_Catalogo : BasePage
{
    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        // ltrTotCart.Text = Cart != null ? Cart.Total.ToString() : String.Empty;
    }

    protected void pagerProducts_PreRender(object sender, EventArgs e)
    {
        if (!Request.GetFriendlyUrlSegments().Any()) Response.Redirect("~/Design/Default"); 

        if (BindProductsToList(GetCategoryIdByName(Request.GetFriendlyUrlSegments()[0])))
            ShowHidePagerForShop();
    }

    private string GetCategoryIdByName(string categoryName)
    {
        // level mapping nome id

        switch (categoryName)
        {
            case "Complementi":
                return ConfigurationHelper.ComplementiCatId;
            case "Arredi":
                return ConfigurationHelper.Arredi;
            case "Idee-Regalo":
                return ConfigurationHelper.IdeeRegalo;
            case "Materassi":
                return ConfigurationHelper.Materassi;
            case "Maioliche":
                return ConfigurationHelper.Maioliche;
            default:
                return ConfigurationHelper.RootCategory;
        }
    }

    protected void item_dataBound(object sender, ListViewItemEventArgs e)
    {
        var item = e.Item as ListViewDataItem;
        if (item == null) return;

        var product = item.DataItem as CategoryAssignedProduct;
        if (product != null)
        {
            var imgProd = item.FindControl("imgProduct") as Image;
            var descProduct = item.FindControl("descProduct") as HtmlGenericControl;
            var priceProduct = item.FindControl("priceProduct") as HtmlGenericControl;
            var linkDettaglio = item.FindControl("lnkDettaglio_1") as HtmlAnchor;

            // Immagine    
            //if (imgProd != null && product.imageurl != null) imgProd.ImageUrl = string.Format("../Handler.ashx?UrlFoto={0}&W_=215&H_=215", (product.imageurl));
            // if (imgProd != null && product.imageurl != null) imgProd.ImageUrl = product.imageurl;
            var imagePath = Helper.GetImageName(product.imageurl);
            if (imgProd != null && imagePath != null) imgProd.ImageUrl = string.Format("{0}{1}", "~/Design/Images/Prodotti/", imagePath);
            // Descrizione  
            if (descProduct != null && product.name != null) descProduct.InnerHtml = Helper.GetShortString(product.name, 132);
            // Prezzo
            if (priceProduct != null && product.price != null) priceProduct.InnerHtml = Helper.FormatCurrency(product.price);
            // Link pagina dettaglio   

            if (linkDettaglio != null && product.name != null) linkDettaglio.HRef = FriendlyUrl.Href("~/Design", "Dettaglio", product.product_id, product.name.Replace(" ", "-").TrimEnd('-').ToLowerInvariant());

            SetItemStyleAttributes(item);
        }
    }

    #endregion Events

    #region Properties

    public List<CategoryAssignedProduct> Products
    {
        get
        {
            return _cache.Get<List<CategoryAssignedProduct>>(string.Format("CategoryAssignedProduct{0}", ConfigurationHelper.RootCategory));
        }
        set
        {
            _cache.Add(string.Format("CategoryAssignedProduct{0}", ConfigurationHelper.RootCategory), value);
        }
    }

    #endregion Properties

    #region Private Methods
    private bool BindProductsToList(string categoryId)
    {

        var products = _repository.GetProductsByCategoryId(categoryId);
        if (products == null || !products.Any()) return false;

        Products = products.Where(p => p.qty_in_stock > 0).ToList();
        if (!Products.Any()) return false;
        lvProducts.DataSource = Products;
        lvProducts.DataBind();

        return true;
    }

    private string SetMainStyleAttribute()
    {

        lblCategoria.CssClass = "colore_rosso";
        return string.Empty;
    }

    private void ShowHidePagerForShop()
    {
        bool isPagerVisible = (Products.Count() > pagerProducts.PageSize) && (Products != null);

        pagerRosso.Visible = isPagerVisible;
        pagerProducts.Visible = false;

    }

    private void SetItemStyleAttributes(ListViewDataItem item)
    {
        var boxProdotto = (HtmlGenericControl)item.FindControl("box_prodotto");
        var priceProduct = (HtmlGenericControl)item.FindControl("priceProduct");
        var divMaskProd = (HtmlGenericControl)item.FindControl("divMaskProd");
        if (item.DataItemIndex % 4 == 0)
        // classe margin
        {
            //boxProdotto.Style.Add("margin-left", "30px");
        }
        if (item.DataItemIndex % 4 == 3)
        {
            boxProdotto.Attributes["class"] = "one-fourth view view-first last";
        }

        priceProduct.Attributes["Class"] = "desc_prezzo_home rosso";
        divMaskProd.Attributes["Class"] = "mask_red";
    }

    #endregion Private Methods
}