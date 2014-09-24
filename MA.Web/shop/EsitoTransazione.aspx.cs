using System;
using System.Collections;
using System.Net.Mail;
using System.Web;
using Ez.Newsletter.MagentoApi;
using WSCryptDecrypt = it.sella.ecomms2s.WSCryptDecrypt;
public partial class shop_EsitoTransazione : System.Web.UI.Page
{
  private int numLoad = 0;
  protected void Page_Load(object sender, EventArgs e)
  {
    string myshoplogin = Utility.SearchConfigValue("SELLACODE");//"GESPAY54218"; //da web.config
    helper.checkConnection();
    if (!IsPostBack)
    {
      try
      {
        numLoad += 1;
        //azzero il carrello
        Session["carrello"] = null;
        it.sella.ecomms2s.WSCryptDecrypt wsCrypt = new WSCryptDecrypt();
        //  it.sella.testecomm.WSCryptDecrypt wsCrypt = new WSCryptDecrypt();
        string DecryptResponse = Request.QueryString["b"];
        System.Xml.XmlNode tempNodeToDecrypt = wsCrypt.Decrypt(myshoplogin, DecryptResponse);
        System.Xml.XmlNode nodeTransactionResult = tempNodeToDecrypt.SelectSingleNode("descendant::TransactionResult");
        System.Xml.XmlNode nodeErrorDescr = tempNodeToDecrypt.SelectSingleNode("descendant::ErrorDescription");
        string numOrdine = "";
        //ripristinare ok!!!!!!!!!!!!!!!!!
        if (nodeTransactionResult.InnerText == "OK")
        {//class="simple-notice"
          System.Xml.XmlNode nodeTransactionId = tempNodeToDecrypt.SelectSingleNode("descendant::ShopTransactionID");
          //000000065
          numOrdine = nodeTransactionId.InnerText.Substring(0, 9);
          OrderInfo DettOrdine = Ez.Newsletter.MagentoApi.Order.Info((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(numOrdine) });
          var serializer = new Conversive.PHPSerializationLibrary.Serializer();
          Ez.Newsletter.MagentoApi.Customer customer = Ez.Newsletter.MagentoApi.Customer.Info((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], int.Parse(DettOrdine.customer_id));
          string mailBody = Utility.readTemplateFromFile("pathTemplateMail");
          string trDettaglioOrd = "";
          mailBody = mailBody.Replace("##NOME##", customer.firstname + " " + customer.lastname);
          foreach (var orderProduct in DettOrdine.items)
          {
            //orderProduct.product_options
            Hashtable ht = (Hashtable)serializer.Deserialize(orderProduct.product_options);
            Hashtable ht2 = (Hashtable)ht["info_buyRequest"];
            string totArticolo = (int.Parse((string)ht2["qty"]) * decimal.Parse(helper.FormatCurrency((string)ht2["price"]))).ToString();
            totArticolo = totArticolo.Replace(".", ",");
            trDettaglioOrd += "<tr><td width=\"220\" valign=\"middle\" height=\"30\" align=\"left\" style=\"text-align: left; color: #444444; font-weight: bold; border-bottom: 1px dotted #DDDDDD; padding-left: 10px;\">" +
                                       (string)ht2["name"] +
                                    "</td> " +
                          "<td width=\"100\" valign=\"middle\" height=\"30\" align=\"left\" style=\"text-align: left; border-bottom: 1px dotted #DDDDDD;\">" +
                                       (string)ht2["product_id"] +
                                    "</td>" +
                          "" +
                          "<td width=\"100\" valign=\"middle\" height=\"30\" align=\"center\" style=\"text-align: center; border-bottom: 1px dotted #DDDDDD;\">" +
                                       (string)ht2["qty"] +
                                    "</td><td width=\"100\" valign=\"middle\" height=\"30\" align=\"right\" style=\"text-align: right; border-bottom: 1px dotted #DDDDDD;\">" +
                                       "€. " + helper.FormatCurrency((string)ht2["price"]) +
                                    "</td><td width=\"90\" valign=\"middle\" height=\"30\" align=\"right\" style=\"text-align: right; border-bottom: 1px dotted #DDDDDD; padding-right: 10px;\">"
                                    + "€. " + totArticolo +
                                    "</td></tr>";
          }
          mailBody = mailBody.Replace("##SPEDIZIONE_1##", DettOrdine.shipping_address.firstname + " " + DettOrdine.shipping_address.lastname);
          mailBody = mailBody.Replace("##SPEDIZIONE_2##", DettOrdine.shipping_address.street + " " + DettOrdine.shipping_address.city + " " + DettOrdine.shipping_address.postcode);
          mailBody = mailBody.Replace("##FATT_1##", DettOrdine.billing_address.firstname + " " + DettOrdine.billing_address.lastname);
          mailBody = mailBody.Replace("##FATT_2##", DettOrdine.billing_address.street + " " + DettOrdine.billing_address.city + " " + DettOrdine.billing_address.postcode);
          mailBody = mailBody.Replace("##NUMERO ORDINE##", numOrdine);
          mailBody = mailBody.Replace("##TR_ORDINE##", trDettaglioOrd);
          mailBody = mailBody.Replace("##SPEDIZIONE##", "€. " + helper.FormatCurrency(DettOrdine.shipping_amount));
          mailBody = mailBody.Replace("##TOTALE##", "€. " + helper.FormatCurrency(DettOrdine.grand_total));
          divEsito.Attributes["class"] = "simple-notice";
          ltrEsito.Text =
              "<strong>Operazione conclusa con successo</strong> Gentile Utente, le comunichiamo che l'ordine n. " +
              numOrdine +
              " è stato preso in carico.<br> Riceverà al suo indirizzo email la conferma di avvenuto pagamento";
          // invio mail su template nl!!
          string MainMailAddress = Utility.SearchConfigValue("MainMailAddress");
          string MainMailAlias = Utility.SearchConfigValue("MainMailAlias");
          MailAddress from = new MailAddress(MainMailAddress, MainMailAlias);
          MailAddress to = new MailAddress(DettOrdine.customer_email, customer.firstname + " " + customer.lastname);
          MailMessage EMAIL = new MailMessage(from, to);
          EMAIL.Subject = "Conferma ordine n. " + numOrdine + " dal sito materarredamenti.it";
          EMAIL.IsBodyHtml = true;
          EMAIL.Body = mailBody;
          // EMAIL.Bcc.Add("giuseppe.cristella@libero.it");
          SmtpClient SmtpMail = new SmtpClient();
          SmtpMail.Send(EMAIL);
          // invio OK!!
        }
        else
        {
          divEsito.Attributes["class"] = "simple-error";
          ltrEsito.Text = "<strong>Si è verificato un errore.</strong> Gentile Utente, le comunichiamo che l'ordine n. " + numOrdine + " è stato annullato. Si prega di eseguire nuovamente la procedura di acquisto.";
          /*annullo l'ordine*/
          bool blOrderStatus = Ez.Newsletter.MagentoApi.OrderStatus.SetStatus((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { numOrdine, "canceled" });
          //Response.Redirect("Carrello.html");
        }
      }
      catch (Exception ex)
      {
        ltrEsito.Text = ex.Message;
      }
    }
  }
}
