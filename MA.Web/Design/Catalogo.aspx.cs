﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;
using Microsoft.AspNet.FriendlyUrls;

public partial class shop_Catalogo : BasePage
{
    private bool _isShopVerde = true;

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        // ltrTotCart.Text = Cart != null ? Cart.Total.ToString() : String.Empty;
    }

    protected void pagerProducts_PreRender(object sender, EventArgs e)
    {
        var rootCat = SetMainStyleAttribute();

        // Ottiene l'html da renderizzare per il megamenu e lo persiste in memoria / da rifattorizzare ?
        HttpContext.Current.Cache.Insert("htmlMegaMenu", Utility.SetMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], rootCat));
        menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];

        if (!Request.GetFriendlyUrlSegments().Any()) return;
        //var categoryId = (Request.GetFriendlyUrlSegments().Count == 2)
        //    ? GetCategoryIdByName(Request.GetFriendlyUrlSegments()[1])
        //    : ConfigurationHelper.RootCategory;

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
            case "IdeeRegalo":
                return ConfigurationHelper.IdeeRegalo;
            case "Materassi":
                return ConfigurationHelper.Materassi;
            case "Originali":
                return ConfigurationHelper.Originali;
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
            if (imgProd != null && imagePath != null) imgProd.ImageUrl = string.Format("{0}{1}", "~/Public/", imagePath);
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

        _isShopVerde = false;
        //logo_r.Visible = true;
        //main_navigation.Attributes["class"] = "main-menu rosso";
        //divCarrello.Style.Add("background", "#D10A11");
        divSpotVerde.Visible = true;
        lblCategoria.CssClass = "colore_rosso";

        #region Garbage Shop Verde
        //else
        //{
        //  //shop verde
        //  lblCategoria.CssClass = "colore_verde";
        //  logo_v.Visible = true;
        //  main_navigation.Attributes["class"] = "main-menu verde";
        //  divSpotRosso.Visible = true;
        //  divCarrello.Style.Add("background", "#76A227");
        //} 
        #endregion
        return string.Empty;
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