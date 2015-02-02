using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using Cart = MagentoBusinessDelegate.Cart;
using Image = System.Web.UI.WebControls.Image;
using Label = System.Web.UI.WebControls.Label;
using TextBox = System.Web.UI.WebControls.TextBox;

public partial class shop_Carrello : BasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ltrTotCart.Text = Cart != null ? Cart.Total.ToString() : String.Empty;

    if (Cart != null && !Cart.Products.Any())
    {
      pnlCartTotal.Visible = false;
      LinkButton1.Enabled = false;
    }
    if (IsPostBack) return;
    ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
    if (Cart != null)
    {
      lvCart.DataSource = Cart.Products;
      lvCart.DataBind();
    }

    ltrSomma.Text = Cart != null ? Cart.Total.ToString() : String.Empty;
  }

  protected void lnkbtncheckout_Click(object sender, EventArgs e)
  {
    bool blerrore = false;
    foreach (var item in lvCart.Items)
    {

      var product = item.DataItem as Product;
      if (product == null) continue;

      var qty = GetProductItemQtyFromUI(item);
      if (!qty.HasValue) continue; // errore non riesco a recuperare la qta dall'interfaccia

      var qtyInStock = _repository.GetStocksForProduct(product.product_id);
      if (qtyInStock == 0 || qtyInStock >= qty) continue;

      blerrore = true;
      msgError.Visible = true;
      var textBox = item.FindControl("txtqty") as TextBox;
      if (textBox != null)
        textBox.BorderColor = System.Drawing.Color.Red;
    }
    if (blerrore) return;
    var cartId = _repository.CreateCart();
    Response.Redirect(string.Format("Indirizzi.aspx?cartId={0}", cartId));
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
      Response.Redirect("home_r.aspx");
      pnlCartTotal.Visible = false;
      LinkButton1.Enabled = false;
    }
    lvCart.DataSource = Cart;
    lvCart.DataBind();
    ltrTotCart.Text = ltrSomma.Text = Cart.Total.ToString("c");

  }

  protected void lvDataBound(object sender, ListViewItemEventArgs e)
  {
    var item = (ListViewDataItem)e.Item;
    if (item == null || item.DataItem as Product == null) return;
    var product = item.DataItem as Product;

    // Nome
    var lblnomeprod = item.FindControl("lblnomeprod") as Literal;
    if (lblnomeprod != null) lblnomeprod.Text = product.name;

    // Prezzo unitario
    var lblprezzoun = item.FindControl("lblprezzoun") as Label;
    if (lblprezzoun != null) lblprezzoun.Text = string.Format("€. {0}", Helper.FormatCurrency(Helper.FormatCurrency(product.price)));

    // Q.ta
    var txtqtaprod = item.FindControl("txtqta") as TextBox;
    if (txtqtaprod != null) txtqtaprod.Text = product.qty;

    // Prezzo totale
    var tot = decimal.Parse(product.price) * int.Parse(product.qty);
    var lblprezzotot = item.FindControl("lblprezzotot") as Label;
    if (lblprezzotot != null) lblprezzotot.Text = string.Format("Tot. €. {0}", tot.ToString().Replace(".", ","));

    // Immagine principale
    var imgprod = item.FindControl("imgprod") as Image;
    if (imgprod != null) imgprod.ImageUrl = string.Format("../Handler.ashx?UrlFoto={0}&W_=100&H_=100", product.imageurl);

    // Url pagina dettaglio 
    var lnkbtnDettProd = item.FindControl("lnkbtnDettProd") as LinkButton;
    if (lnkbtnDettProd != null) lnkbtnDettProd.PostBackUrl = string.Format("Dettaglio.aspx?CatId={0}&ProdId={1}",
         product.categories[0], product.product_id);
      //product.category_ids[0], product.product_id);
  }

  protected void lnkbtnContinueShop_Click(object sender, EventArgs e)
  {
    Response.Redirect("~/shop/Catalogo.aspx");
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
      if (item == null || item.DataItem as Product == null) continue;
      var productId = (item.DataItem as Product).product_id;

      var productQtyFromUI = GetProductItemQtyFromUI(item);
      if (productQtyFromUI.HasValue == false) continue;

      var productQtyFromStoredCart = int.Parse(
        storedCart.Products.Where(p => p.product_id == productId).Select(p => p.qty).First());
      if (productQtyFromUI.Value == productQtyFromStoredCart) continue;
      if (_repository.GetStocksForProduct(productId) > productQtyFromUI)
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
      if (chkDelete == null) continue;
      productToRemove.Add((item.DataItem as Product));
    }
    return productToRemove;
  }

  #endregion

}
