using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using WSCryptDecrypt = it.sella.ecomms2s.WSCryptDecrypt;
public partial class Riepilogo : BasePage
{
  string totale = "0";

  public int CartId { get;  set; }

  protected void Page_Load(object sender, EventArgs e)
  {
    var arrayCart = (ArrayList)Session["carrello"];
   // CartId = Request.QueryString["cartId"];
    var utente = Page.User.Identity.Name;

    if (string.IsNullOrEmpty(utente)) Response.Redirect("~/Shop/Accedi.aspx");

    if (IsPostBack) return;
    if (string.IsNullOrEmpty(cartId)) Response.Redirect("Carrello.aspx");

    var shippingMethods =
      Ez.Newsletter.MagentoApi.Cart.cartShippingList((string)HttpContext.Current.Cache["apiUrl"],
        (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId) });

    // Binding carrello
    lvCart.DataSource = Cart;
    lvCart.DataBind();

    ltrSubTot.Text = Cart.Total.ToString();
    ltrSped.Text = helper.FormatCurrency(shippingMethods[0].price);
    // totale + spese spedizione
    ltrSomma.Text = (decimal.Parse(ltrSped.Text) + decimal.Parse(ltrSubTot.Text)).ToString();

  }

  protected void lvDataBound(object sender, ListViewItemEventArgs e)
  {
    var dataItem = (ListViewDataItem)e.Item;
    var lblnomeprod = (Literal)e.Item.FindControl("lblnomeprod");
    lblnomeprod.Text = ((Product)(dataItem.DataItem)).name;
    var lblprezzoun = (Label)e.Item.FindControl("lblprezzoun");
    lblprezzoun.Text = helper.FormatCurrency(((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).price);
    var imgprod = (Image)e.Item.FindControl("imgprod");
    imgprod.ImageUrl = "../Handler.ashx?UrlFoto=" + ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).imageurl + "&W_=100&H_=100";
    var txtqta = (Label)e.Item.FindControl("txtqta");
    txtqta.Text = ((Product)(dataItem.DataItem)).qty;
    var lblprezzotot = (Label)e.Item.FindControl("lblprezzotot");
    totale = (decimal.Parse(lblprezzoun.Text) * int.Parse(txtqta.Text)).ToString();
    // usare string.Format currency
    lblprezzoun.Text = string.Format("€. {0}", lblprezzoun.Text);
    lblprezzotot.Text = string.Format("Tot. €. {0}", totale.Replace(".", ","));
  }

  protected void rptCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
  {
  }

  protected void lnkbtnOrder_Click(object sender, EventArgs e)
  {
    //controllare se l'ordine è stato già creato e in che stato si trova
    string orderNum = "0";
    try
    {
      orderNum = Ez.Newsletter.MagentoApi.Cart.cartOrder((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(_cartId) });
      Session["numOrdine"] = orderNum;
      // bool blOrderStatus = Ez.Newsletter.MagentoApi.OrderStatus.SetStatus(apiUrl, sessionId, new object[] { orderNum, "canceled" });
    }
    catch (Exception ex)
    {
      //avvisiamo l'utente che non è stato possibile creare l'ordine
      // annullo quel numero di ordine mettendolo in uno stato x e faccio una redirect al carrello!!!
      bool blOrderStatus = Ez.Newsletter.MagentoApi.OrderStatus.SetStatus((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { orderNum, "canceled" });
    }
    var wsCrypt = new WSCryptDecrypt();
    // it.sella.testecomm.WSCryptDecrypt wsCrypt = new WSCryptDecrypt();
    string myshoplogin = Utility.SearchConfigValue("SELLACODE");
    int mycurrency = 242;//cod euro
    var myamount = ltrSomma.Text.Replace(",", ".");
    var myshoptransactionID = orderNum + Guid.NewGuid().ToString();//"34az85ord19";
    System.Xml.XmlNode tempNode = wsCrypt.Encrypt(myshoplogin, mycurrency.ToString(), myamount, myshoptransactionID, "", "", "", "", "", "", "", "");
    System.Xml.XmlNode nodeCrypstedString = tempNode.SelectSingleNode("descendant::CryptDecryptString");
    System.Xml.XmlNode nodeTransactionResult = tempNode.SelectSingleNode("descendant::TransactionResult");
    System.Xml.XmlNode nodeErrorDesc = tempNode.SelectSingleNode("descendant::ErrorDescription");
    if (nodeTransactionResult.InnerText == "OK")
    {
      // qua posso tracciare lo stato dell'ordine prima 
      //Response.Redirect("https://testecomm.sella.it/gestpay/pagam.asp?a=" + myshoplogin + "&b=" + nodeCrypstedString.InnerText);
      Response.Redirect("https://ecomm.sella.it/gestpay/pagam.asp?a=" + myshoplogin + "&b=" + nodeCrypstedString.InnerText);
    }
    else
    {
      string errore = nodeErrorDesc.InnerText;
      //loggo e messaggio errore
      lblSella.Text = errore;
      //annullo l'ordine orderNum perchè ci sono stati problemi con  il gateway quindi ritorno al carrello per 
      // creare un altro cartID
      bool blOrderStatus = Ez.Newsletter.MagentoApi.OrderStatus.SetStatus((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { orderNum, "canceled" });
      //  Response.Redirect("Carrello.html");
    }

  }
}
