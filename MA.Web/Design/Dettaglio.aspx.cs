using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MagentoComunication.Helpers;
using MagentoRepository.Repository;
using Microsoft.AspNet.FriendlyUrls;
using Ez.Newsletter.MagentoApi;

public partial class Design_Dettaglio : BasePage
{

    private static string _productName;
    private static string _productId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.GetFriendlyUrlSegments().Any()) return;
        _productId = Request.GetFriendlyUrlSegments()[1];
        if (string.IsNullOrEmpty(_productId)) Response.Redirect("Catalogo.aspx");

        if (IsPostBack) return;

        BindProduct(_productId);
        BindInventoryInfo(_productId);
        BindProductImages(_productId);
        BindLinkedProducts(_productId);

        var ltrMetaFB = Master.FindControl("ltrMetaFB") as Literal;
        if (ltrMetaFB == null) return;

        ltrMetaFB.Text = GetFbMeta();
    }

    protected void rptImages_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var imgThumb = e.Item.FindControl("imgThumb") as HtmlImage;
        if (imgThumb != null) imgThumb.Src = e.Item.DataItem.ToString();
        var prettyThumb = e.Item.FindControl("prettyThumb") as HtmlAnchor;
        if (prettyThumb != null)
        {
            var imageName = Helper.GetImageName(e.Item.DataItem.ToString());
            prettyThumb.HRef = e.Item.DataItem.ToString(); //string.Format("{0}{1}", "~/Design/Images/Prodotti/", imageName);
            prettyThumb.Title = " ";
        }
    }

    protected void rptProdAssociati_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header)
        {
            var imgProdAss = (HtmlImage)e.Item.FindControl("imgProdAss");
            var product = (e.Item.DataItem) as Product;
            if (product == null) return;
            imgProdAss.Src = product.imageurl;
            var linkProd = (HtmlAnchor)e.Item.FindControl("linkProd");
            if (linkProd != null)
            {
                var category = Request.GetFriendlyUrlSegments()[0];
                linkProd.HRef = FriendlyUrl.Href("~/Design", "Dettaglio", category, product.product_id, product.name.Replace(" ", "-").TrimEnd('-').ToLowerInvariant());
            }
        }
    }

    protected void btnaddTocart_Click(object sender, EventArgs e)
    {
        if (Product != null)
        {
            Product.qty = "1";
            CartHelper.AddProductToCartAndUpdateCache(Product);
        }
        Response.Redirect("~/Design/Carrello.aspx");
    }

    #region private methods

    private void BindProduct(string productId)
    {
        if (Product.name != null) lblNomeProd.Text += Product.name;

        prodProduttore.Text = Product.produttore;
        prodDescription.Text = Product.description;
        prodPrice.Text = Helper.FormatCurrency(Product.price);

        DisableProductWhenIsNotInStock(Product.is_in_stock);
    }

    private void BindLinkedProducts(string productId)
    {
        rptProdAssociati.Visible = false;
        var linkedProducts = _repository.GetLinkedProducts(productId);
        if (linkedProducts == null) return;

        var linkedProducstWithCompleteInfos = linkedProducts
          .Select(product => _repository.GetFilteredProducts
            (new Filter { FilterOperator = LogicalOperator.Eq, Key = "product_id", Value = product.product_id }))
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
        var imageName = Helper.GetImageName(GetProductMainImageUrl(productId));
        mainImage.Src = Product.imageurl = string.Format("{0}{1}", "~/Design/Images/Prodotti/", imageName);
        var images = GetProductImagesUrlExceptMain(productId);
        if (images == null) return;

        rptImages.DataSource = images;
        rptImages.DataBind();
    }

    private void BindInventoryInfo(string productId)
    {
        var inventories = _repository.GetInventories(productId);
        if (!inventories.Any() || inventories.FirstOrDefault() == null) return;
        prodScorte.Text = inventories[0].qty.Substring(0, inventories.FirstOrDefault().qty.IndexOf(".", StringComparison.Ordinal));
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
        if (productImages.FirstOrDefault(p => p.exclude == "1") == default(ProductImage)) return string.Empty;
        return productImages.First(p => p.exclude == "1").url;
    }

    #endregion private methods

    public Product Product
    {
        get
        {
            return _repository.GetProductInfo(_productId);
        }
    }

    private string GetFbMeta()
    {
        var fileName = HttpContext.Current.Server.MapPath("~\\public\\templates\\template_tagFb.htm");
        using (var srFbMeta = new StreamReader(fileName, Encoding.Default))
        {
            var sbFbMeta = new StringBuilder(srFbMeta.ReadToEnd());
            sbFbMeta.Replace("##image##", string.Format("{0}{1}", Helper.GetAbsoluteUrl(), Product.imageurl.Remove(0, 2)))
                .Replace("##titolo##", Product.name)
                .Replace("##url##", string.Empty)
                .Replace("##titolo##", Product.name)
                .Replace("##caption##", Product.description);
            return sbFbMeta.ToString();
        }
    }
}