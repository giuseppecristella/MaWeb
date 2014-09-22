using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using it.sella.testecomm;
public partial class peppe : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    string myshoplogin = Utility.SearchConfigValue("SELLACODE");//"GESPAY54218"; //da web.config
    helper.checkConnection();
    if (HttpContext.Current.Cache["htmlMegaMenu"] == null)
    {
      if (HttpContext.Current.Cache["sessionId"] == null)
      {
        HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
      }
      HttpContext.Current.Cache.Insert("htmlMegaMenu", helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], (string)Session["rootCat"]));
    }
    menuCatShop.InnerHtml = (string)HttpContext.Current.Cache["htmlMegaMenu"];
    // + " <li><a  href=\"../Index.html\">Torna al sito</a></li>";
    if (!IsPostBack)
    {
      try
      {
        //azzero il carrello
        Session["carrello"] = null;
        string numOrdine = "";
        //ripristinare ok!!!!!!!!!!!!!!!!!
        if (true == true)
        {//class="simple-notice"
          //000000065
          string mailBody = Utility.readTemplateFromFile("pathTemplateMail");
          string trDettaglioOrd = "";
          string MainMailAddress = Utility.SearchConfigValue("MainMailAddress");
          string MainMailAlias = Utility.SearchConfigValue("MainMailAlias");
          MailAddress from = new MailAddress(MainMailAddress, MainMailAlias);
          MailAddress to = new MailAddress("verduga80@libero.it", "vscinz");
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
          // divEsito.Attributes["class"] = "simple-error";
          //ltrEsito.Text = "<strong>Si è verificato un errore.</strong> Gentile Utente, le comunichiamo che l'ordine n. " + numOrdine + " è stato annullato. Si prega di eseguire nuovamente la procedura di acquisto.";
          /*annullo l'ordine*/
          bool blOrderStatus = Ez.Newsletter.MagentoApi.OrderStatus.SetStatus((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { numOrdine, "canceled" });
          Response.Redirect("Carrello.html");
        }
      }
      catch (Exception ex)
      {
      }
    }
  }
}
