using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
public partial class shop_Carrello : System.Web.UI.Page
{
  private string idCategoria = "";

  protected void Page_Load(object sender, EventArgs e)
  {
    /*inizio codice da vecchia master page*/
    ArrayList arrayCart = (ArrayList)Session["carrello"];
    if (!helper.checkConnection())
    {
      HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
      HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
    }
    int numItems = 0;
    if (arrayCart != null)
    {
      for (int i = 0; i < arrayCart.Count; i++)
      {
        Product tProd = (Product)arrayCart[i];
        numItems += int.Parse(tProd.qty);
      }
    }
    ltrTotCart.Text = numItems.ToString();
    /*fine codice master page vecchia*/
    string rootCat = "37";
    /*l'ultimo elemento del vettore è l'ultimo prodotto aggiunto al carrello*/
    if (arrayCart.Count > 0)
    {
      Product tProd = (Product)arrayCart[arrayCart.Count - 1];
      bool isShopVerde = true;
      /*le categorie 44 e 45 sono riservate ai prodotti in vetrina quindi le escludo*/
      //myProduct.categories
      foreach (string strCat in tProd.category_ids)
      {
        if (strCat != "44" && strCat != "45" && strCat != "37" && strCat != "47")
          idCategoria = strCat;
      }
      if (tProd.category_ids.Contains("47"))
        isShopVerde = false;
      if (isShopVerde)
      {
        //logo_v.Visible = true;
        //main_navigation.Attributes["class"] = "main-menu verde";
        //divCarrello.Style.Add("background", "#76A227");
      }
      else
      {
        rootCat = "47";
        //logo_r.Visible = true;
        //main_navigation.Attributes["class"] = "main-menu rosso";
        //divCarrello.Style.Add("background", "#D10A11");
      }
      //+ " <li><a  href=\"../Index.html\">Torna al sito</a></li>";        /*visualizzo il dettaglio del prodotto*/
    }
    else
    {
      bool isShopVerde = true;
      if ((string)Session["rootCat"] == "47")
        isShopVerde = false;
      }
    if (HttpContext.Current.Cache["htmlMegaMenu"] == null)
    {
      if (HttpContext.Current.Cache["sessionId"] == null)
      {
        HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
      }
      HttpContext.Current.Cache.Insert("htmlMegaMenu", helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], rootCat));
    }
    arrayCart = (ArrayList)Session["carrello"];
    if (arrayCart.Count == 0)
    {
      //btnUpdateCart.Visible = false;
      pnlCartTotal.Visible = false;
      LinkButton1.Enabled = false;
    }
    if (!IsPostBack)
    {
      ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
      lvCart.DataSource = arrayCart;
      lvCart.DataBind();
      decimal somma = helper.SommaProdotti(arrayCart);
      ltrSomma.Text = somma.ToString();
    }
  }

  protected void lnkbtncheckout(object sender, EventArgs e)
  {
    ArrayList arrayCart = (ArrayList)Session["carrello"];
    int i = 0;
    bool blerrore = false;
    Product tempP = new Product();
    foreach (ListViewDataItem item in lvCart.Items)
    {
      TextBox txtqty = (TextBox)item.FindControl("txtqta");
      tempP = (Product)arrayCart[i];
      int qty = 0;
      if (!int.TryParse(txtqty.Text, out qty) || qty < 0)
        qty = 1;
      Inventory[] scorteProdotto = Inventory.List((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { tempP.product_id });
      if (int.Parse(scorteProdotto[0].qty.Substring(0, scorteProdotto[0].qty.IndexOf("."))) < qty)
      {
        blerrore = true;
        msgError.Visible = true;
        txtqty.BorderColor = System.Drawing.Color.Red;
      }
      i++;
    }
    if (!blerrore)
    {
      int IdCarrello = Cart.create((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"]);
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
    Category CategoryInfo = Category.Info((string)HttpContext.Current.Cache["apiUrl"],
                                         (string)HttpContext.Current.Cache["sessionId"],
                                         new object[] { idCategoria });
    //CategoryInfo.name;
    Response.Redirect("~/shop/" + CategoryInfo.name + ".html");
  }
}
