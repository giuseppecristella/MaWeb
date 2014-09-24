using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using WSCryptDecrypt = it.sella.ecomms2s.WSCryptDecrypt;
public partial class Riepilogo : System.Web.UI.Page
{
  string totale = "0";
  string cartId = "";

  protected void Page_Load(object sender, EventArgs e)
  {
    if (!helper.checkConnection())
    {
      HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
      HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
    }
    //+ " <li><a  href=\"../Index.html\">Torna al sito</a></li>";
    ArrayList arrayCart = (ArrayList)Session["carrello"];
    cartId = Request.QueryString["cartId"];
    string utente = Page.User.Identity.Name;
    // ProfileCommon profile = Profile.GetProfile(utente);
    if (!string.IsNullOrEmpty(utente))
    {
      if (!IsPostBack)
      {
        if (!string.IsNullOrEmpty(cartId))
        {
          ShippingMethod[] shippingMethods = Cart.cartShippingList((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId) });
          lvCart.DataSource = arrayCart;
          lvCart.DataBind();
          decimal somma = helper.SommaProdotti(arrayCart);
          ltrSubTot.Text = somma.ToString();
          ltrSped.Text = helper.FormatCurrency(shippingMethods[0].price);
          ltrSomma.Text = (decimal.Parse(ltrSubTot.Text) + decimal.Parse(ltrSped.Text)).ToString();
        }
        else
        {
          Response.Redirect("Carrello.html");
        }
      }
    }
    else
    {
      Response.Redirect("~/Shop/Accedi.html");
    }
  }

  protected void lvDataBound(object sender, ListViewItemEventArgs e)
  {
    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
    Literal lblnomeprod = (Literal)e.Item.FindControl("lblnomeprod");
    lblnomeprod.Text = ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).name;
    Label lblprezzoun = (Label)e.Item.FindControl("lblprezzoun");
    lblprezzoun.Text = helper.FormatCurrency(((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).price);
    Image imgprod = (Image)e.Item.FindControl("imgprod");
    imgprod.ImageUrl = "../Handler.ashx?UrlFoto=" + ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).imageurl + "&W_=100&H_=100";
    Label txtqta = (Label)e.Item.FindControl("txtqta");
    txtqta.Text = ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).qty;
    Label lblprezzotot = (Label)e.Item.FindControl("lblprezzotot");
    totale = (decimal.Parse(lblprezzoun.Text) * int.Parse(txtqta.Text)).ToString();
    lblprezzoun.Text = "€. " + lblprezzoun.Text;
    lblprezzotot.Text = "Tot. €. " + totale.Replace(".", ",");
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
      orderNum = Cart.cartOrder((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId) });
      Session["numOrdine"] = orderNum;
      // bool blOrderStatus = Ez.Newsletter.MagentoApi.OrderStatus.SetStatus(apiUrl, sessionId, new object[] { orderNum, "canceled" });
    }
    catch (Exception ex)
    {
      //avvisiamo l'utente che non è stato possibile creare l'ordine
      // annullo quel numero di ordine mettendolo in uno stato x e faccio una redirect al carrello!!!
      bool blOrderStatus = Ez.Newsletter.MagentoApi.OrderStatus.SetStatus((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { orderNum, "canceled" });
    }
    it.sella.ecomms2s.WSCryptDecrypt wsCrypt = new WSCryptDecrypt();
    // it.sella.testecomm.WSCryptDecrypt wsCrypt = new WSCryptDecrypt();
    string myshoplogin = Utility.SearchConfigValue("SELLACODE");
    int mycurrency = 242;//cod euro
    string myamount = ltrSomma.Text.Replace(",", ".");
    string myshoptransactionID = orderNum + Guid.NewGuid().ToString();//"34az85ord19";
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
