using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using iTextSharp.text.pdf;

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
    foreach (ListViewDataItem item in lvCart.Items)
    {
      var product = item.DataItem as Product;
      if (product == null) return;

      int qty;
      var txtqty = item.FindControl("txtqta") as TextBox;
      if (txtqty == null || (int.TryParse(txtqty.Text, out qty))) return;
      if (qty < 0) qty = 1;

      var inventories = _repository.GetInventories(product.product_id);
      if (inventories != null)
      {
        int.Parse(inventories.FirstOrDefault().qty);

      }
      // confronto la quantità richiesta, prendendo il dato dalla listview

      Inventory[] scorteProdotto = Inventory.List((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { tempP.product_id });
      if (int.Parse(scorteProdotto[0].qty.Substring(0, scorteProdotto[0].qty.IndexOf("."))) < qty)
      {
        blerrore = true;
        msgError.Visible = true;
        txtqty.BorderColor = System.Drawing.Color.Red;
      }

    }
    if (!blerrore)
    {

      int IdCarrello = Ez.Newsletter.MagentoApi.Cart.create((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"]);
      // UserManager dd = new 
      Response.Redirect("Indirizzi.aspx?cartId=" + IdCarrello.ToString());
    }
  }

  protected void btnUpdateCart_Click(object sender, EventArgs e)
  {
    ArrayList arrayCart = (ArrayList)Session["carrello"];
    //controllo checkbox
    string apiUrl = (string)HttpContext.Current.Session.Contents["apiUrl"];
    string sessionId = (string)HttpContext.Current.Session.Contents["sessionId"];
    if (arrayCart.Count > 0)
    {
      //aggiornamento qta
      int i = 0;
      bool blerrore = false;
      Product tempP = new Product();
      foreach (ListViewDataItem item in lvCart.Items)
      {
        TextBox txtqty = (TextBox)item.FindControl("txtqta");
        int qty = 0;
        if (!int.TryParse(txtqty.Text, out qty) || qty < 0)
          qty = 1;
        tempP = (Product)arrayCart[i];
        Inventory[] scorteProdotto = Inventory.List((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { tempP.product_id });
        if (int.Parse(scorteProdotto[0].qty.Substring(0, scorteProdotto[0].qty.IndexOf("."))) >= qty)
        {
          if (qty.ToString() != tempP.qty)
            tempP.qty = qty.ToString();
          arrayCart.RemoveAt(i);
          arrayCart.Insert(i, tempP);
        }
        else
        {
          blerrore = true;
        }
        i++;
      }
      //controllo gli item da cancellare
      int j = 0;
      foreach (ListViewDataItem item in lvCart.Items)
      {
        CheckBox chkDelete = (CheckBox)item.FindControl("chkDelete");
        if (chkDelete.Checked)
          if (arrayCart.Count == lvCart.Items.Count)
          {
            arrayCart.RemoveAt(j);
          }
          else
            arrayCart.RemoveAt(j - 1);
        j++;
      }
      if (blerrore)
        msgError.Visible = true;
      else
      {
        msgError.Visible = false;
      }
      Session["carrello"] = arrayCart;
    }
    if (arrayCart.Count == 0)
    {
      Response.Redirect("home_r.aspx");
      pnlCartTotal.Visible = false;
      LinkButton1.Enabled = false;
    }
    lvCart.DataSource = arrayCart;
    lvCart.DataBind();
    int numItems = 0;
    for (int k = 0; k < arrayCart.Count; k++)
    {
      Product tProd = (Product)arrayCart[k];
      numItems += int.Parse(tProd.qty);
    }
    // Literal ltrTotCart = (Literal)Page.Master.FindControl("ltrTotCart");
    ltrTotCart.Text = numItems.ToString();
    decimal somma = helper.SommaProdotti(arrayCart);
    ltrSomma.Text = somma.ToString("c");
  }

  /*costruzione del carrello*/
  protected void lvDataBound(object sender, ListViewItemEventArgs e)
  {
    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
    Literal lblnomeprod = (Literal)e.Item.FindControl("lblnomeprod");
    lblnomeprod.Text = ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).name;
    //  Label lblmodprod = (Label)e.Item.FindControl("lblmodprod");
    //  lblmodprod.Text = ((Ez.Newsletter.MagentoApi.Product)(e.Item.DataItem)).model;
    Label lblprezzoun = (Label)e.Item.FindControl("lblprezzoun");
    string prezzoUn = ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).price;
    lblprezzoun.Text = helper.FormatCurrency(prezzoUn);
    Image imgprod = (Image)e.Item.FindControl("imgprod");
    // imgprod.ImageUrl = ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).imageurl;
    imgprod.ImageUrl = "../Handler.ashx?UrlFoto=" + ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).imageurl + "&W_=100&H_=100";
    LinkButton lnkbtnDettProd = (LinkButton)e.Item.FindControl("lnkbtnDettProd");
    // lnkbtnDettProd.PostBackUrl = "Dettaglio.aspx?CatId=" + ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).category_ids[0] + "&ProdId=" + ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).product_id;
    lnkbtnDettProd.PostBackUrl = helper.GetAbsoluteUrl() + "Shop/" + ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).name.Replace(" ", "-") + ".html";
    TextBox txtqtaprod = (TextBox)e.Item.FindControl("txtqta");
    txtqtaprod.Text = ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).qty;
    decimal tot = decimal.Parse(lblprezzoun.Text) * int.Parse(txtqtaprod.Text);
    lblprezzoun.Text = "€. " + helper.FormatCurrency(prezzoUn);
    Label lblprezzotot = (Label)e.Item.FindControl("lblprezzotot");
    //  txtqtaprod.Text = "Qta. "+((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).qty;
    lblprezzotot.Text = "Tot. €. " + tot.ToString().Replace(".", ",");
  }

  protected void lnkbtnContinueShop_Click(object sender, EventArgs e)
  {
    Response.Redirect("~/shop/Catalogo.aspx");
  }
}
