using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using Cart = MagentoBusinessDelegate.Cart;
using Image = System.Web.UI.WebControls.Image;
using Label = System.Web.UI.WebControls.Label;
using TextBox = System.Web.UI.WebControls.TextBox;
public partial class Design_Carrello : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Cart != null && !Cart.Products.Any())
        {
            pnlCartTotal.Visible = false;
            lbCheckout.Enabled = false;
        }
        if (IsPostBack) return;
        ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
        if (Cart != null)
        {
            lvCart.DataSource = Cart.Products;
            lvCart.DataBind();
        }

        ltrSomma.Text = Cart != null ? Cart.Total.ToString("C") : String.Empty;

    }

    protected void lbCheckout_Click(object sender, EventArgs e)
    {
        bool blerrore = false;
        foreach (var product in Cart.Products)
        {
            if (product == null) continue;

            var qtyInStock = _repository.GetStocksForProduct(product.product_id);
            if (qtyInStock == 0 || qtyInStock >= int.Parse(product.qty)) continue;

            blerrore = true;
            msgError.Visible = true;
        }
        if (blerrore) return;
        Response.Redirect("~/Design/Indirizzi.aspx");
    }

    protected void btnUpdateCart_Click(object sender, EventArgs e)
    {
        if (Cart.Products.Any())
        {
            var storedCart = Cart;
            var productsToDelete = GetItemsToDelete(lvCart.Items);
            if (productsToDelete.Any()) storedCart.DeleteProducts(productsToDelete);
            CheckAndUpdateItemsQty(storedCart);
            Cart = storedCart;
        }
        if (!Cart.Products.Any())
        {
            pnlCartTotal.Visible = false;
            lbCheckout.Enabled = false;
        }
        lvCart.DataSource = Cart.Products;
        lvCart.DataBind();
        ltrSomma.Text = Cart.Total.ToString("C", CultureInfo.GetCultureInfo("it-IT"));

    }

    protected void lvDataBound(object sender, ListViewItemEventArgs e)
    {
        var item = (ListViewDataItem)e.Item;
        if (item == null || item.DataItem as Product == null) return;
        var product = item.DataItem as Product;

        // Id
        var hfProductId = item.FindControl("hfProductId") as HiddenField;
        if (hfProductId != null) hfProductId.Value = product.product_id;

        // Nome
        var lblnomeprod = item.FindControl("lblnomeprod") as Literal;
        if (lblnomeprod != null) lblnomeprod.Text = product.name;

        // Prezzo unitario
        var lblprezzoun = item.FindControl("lblprezzoun") as Label;
        if (lblprezzoun != null) lblprezzoun.Text = string.Format("€. {0}", Helper.FormatCurrency(product.price));

        // Q.ta
        var txtqtaprod = item.FindControl("txtqta") as TextBox;
        if (txtqtaprod != null) txtqtaprod.Text = product.qty;

        // Prezzo totale
        var tot = decimal.Parse(product.price.Replace(".", ","), CultureInfo.GetCultureInfo("it-IT").NumberFormat) * int.Parse(product.qty);
        var lblprezzotot = item.FindControl("lblprezzotot") as Label;
        if (lblprezzotot != null) lblprezzotot.Text = tot.ToString("C");

        // Immagine principale
        var imgprod = item.FindControl("imgprod") as Image;
        if (imgprod != null) imgprod.ImageUrl = string.Format("../Handler.ashx?UrlFoto={0}&W_=100&H_=100", product.imageurl);

        // Url pagina dettaglio 
        var lnkbtnDettProd = item.FindControl("lnkbtnDettProd") as LinkButton;
        if (lnkbtnDettProd != null) lnkbtnDettProd.PostBackUrl = string.Format("Dettaglio/{0}/{1}", product.product_id, product.name.Replace(" ", "-").TrimEnd('-').ToLowerInvariant());
    }

    protected void lbContinueShop_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Design/Default.aspx");
    }

    #region private methods

    private static int? GetProductItemQtyFromUI(ListViewDataItem item)
    {
        int qty;
        var txtqty = item.FindControl("txtqta") as TextBox;
        if (txtqty == null) return null;
        if (int.TryParse(txtqty.Text, out qty) == false || qty < 0) return null;
        return qty;
    }

    private void CheckAndUpdateItemsQty(Cart storedCart)
    {
        foreach (var item in lvCart.Items)
        {
            if (item == null) continue;
            var hfProductId = item.FindControl("hfProductId") as HiddenField;
            if (hfProductId == null) return;
            var productId = hfProductId.Value;

            var productQtyFromUI = GetProductItemQtyFromUI(item);
            if ((productQtyFromUI.HasValue == false) || (!storedCart.Products.Any())) continue;

            var product = storedCart.Products.Where(p => p.product_id == productId).Select(p => p.qty).FirstOrDefault();
            if (product == null) continue;

            var productQtyFromStoredCart = int.Parse(product);

            if (productQtyFromUI.Value == productQtyFromStoredCart) continue;
            if (_repository.GetStocksForProduct(productId) >= productQtyFromUI)
            {
                var valueToUpdate = storedCart.Products.First(p => p.product_id == productId);
                valueToUpdate.qty = productQtyFromUI.Value.ToString();
                Cart = storedCart;
            }
        }
    }

    private List<Product> GetItemsToDelete(IEnumerable<ListViewDataItem> items)
    {
        var productToRemove = new List<Product>();
        foreach (var item in items)
        {
            var chkDelete = item.FindControl("chkDelete") as CheckBox;
            if (chkDelete == null || !chkDelete.Checked) continue;
            var hfProductId = item.FindControl("hfProductId") as HiddenField;
            if (hfProductId == null) return null;
            productToRemove.Add((Cart.Products.Where(p => p.product_id == hfProductId.Value)).FirstOrDefault());
        }
        return productToRemove;
    }

    #endregion
}