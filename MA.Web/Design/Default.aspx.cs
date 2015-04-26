﻿using System;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using Microsoft.AspNet.FriendlyUrls;

public partial class shop_Default : BasePage
{
    private const string redProductCategoryId = "44";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
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
        var imageName = Helper.GetImageName(product.imageurl);
        if (imageName != null) imgProd.ImageUrl = string.Format("{0}{1}", "~/Design/Images/Prodotti/", imageName);

        var spanProductDescription = item.FindControl("spanProductDescription") as HtmlGenericControl;
        if (spanProductDescription != null) spanProductDescription.InnerHtml = Helper.GetShortString(product.name, 132);

        var pProductPrice = item.FindControl("pProductPrice") as HtmlGenericControl;
        if (pProductPrice != null) pProductPrice.InnerHtml = Helper.FormatCurrency(product.price);

        var lbGreenProductDetail = item.FindControl("lbProductDetail") as HtmlAnchor;
        if (lbGreenProductDetail != null) lbGreenProductDetail.HRef = FriendlyUrl.Href("~/Design", "Dettaglio", product.product_id, product.name.Replace(" ", "-").TrimEnd('-').ToLowerInvariant());
    }

    private static void SetProductsBoxStyle(ListViewItem dataitem)
    {
        var moduleResult = dataitem.DataItemIndex % 4;
        if (moduleResult == 0)
        {
            //var box_prodotto = dataitem.FindControl("box_prodotto") as HtmlGenericControl;
            //if (box_prodotto != null) box_prodotto.Style.Add("margin-left", "30px");
        }
        if (moduleResult == 3)
        {
            var box_prodotto = dataitem.FindControl("box_prodotto") as HtmlGenericControl;
            if (box_prodotto != null) box_prodotto.Attributes["class"] = "one-fourth view view-first last";
        }
    }

}
