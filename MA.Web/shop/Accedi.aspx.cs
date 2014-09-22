using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
public partial class shop_Accedi : System.Web.UI.Page
{
  private string sessionId = "";
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
    }
    helper.checkConnection();
  }

  protected void btnLogin_Click(object sender, EventArgs e)
  {
    if (ViewState["PreviousPage"] != null) //Check if the ViewState contains Previous page URL
    {
      Response.Redirect(ViewState["PreviousPage"].ToString());
      //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
    }
    else
    {
      Response.Redirect("~/Shop/Customers/Account.html");
    }
  }

  protected void CreateMagentoUser(object sender, EventArgs e)
  {
    var apiUrl = (string)HttpContext.Current.Session.Contents["apiUrl"];
    var sessionId = (string)HttpContext.Current.Session.Contents["sessionId"];
    string utente = CreateUserWizard1.UserName;
    string password = CreateUserWizard1.Password;
    MembershipUser o = Membership.GetUser(utente);
    bool ok = true;
    Roles.AddUserToRole(utente, "User");
    string MagentoCustomerId = "";
    try
    {
      /*creo l'utente nel repository di Magento*/
      Ez.Newsletter.MagentoApi.Customer MagentoCustomer = new Ez.Newsletter.MagentoApi.Customer();
      MagentoCustomer.email = CreateUserWizard1.Email;
      MagentoCustomer.firstname = txtFirstName.Text;
      MagentoCustomer.lastname = txtLastName.Text;
      MagentoCustomerId = Ez.Newsletter.MagentoApi.Customer.Create((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], MagentoCustomer);
      o.Comment = MagentoCustomerId;
      Membership.UpdateUser(o);
      //var profile = HttpContext.Current.Profile; //vscinz docet-->
      // ProfileCommon profile = GetProfile(utente);
      //profile.Save();
      /*iscrivo l'utente alla newsletter*/
      DataSetMateraArredamentiTableAdapters.NewsLetterTableAdapter taNewsLetter = new DataSetMateraArredamentiTableAdapters.NewsLetterTableAdapter();
      DataTable dtNewsLetter = taNewsLetter.GetEmail(MagentoCustomer.email);
      if (dtNewsLetter.Rows.Count == 0)
      {
        taNewsLetter.Insert(MagentoCustomer.email);
      }
      /*invio la mail*/
      try
      {
        MailAddress from = new MailAddress("info@materarredamenti.it", "Matera Arredamenti");
        MailAddress to = new MailAddress(MagentoCustomer.email, MagentoCustomer.firstname + " " + MagentoCustomer.lastname);
        MailMessage EMAIL = new MailMessage(from, to);
        EMAIL.Subject = "Conferma creazione account shop Matera Arredamenti";
        EMAIL.IsBodyHtml = true;
        string header = "<img alt='header' src='http://www.materarredamenti.it/images/logo_header.jpg' /> <br><br>Creazione account Shop <b style='color:#bf00000'>Matera Arredamenti</b> di: " + MagentoCustomer.email + " <br><br>";
        EMAIL.Body = header + "Gentile " + MagentoCustomer.firstname + " " + MagentoCustomer.lastname + ",<br> le confermiamo l'iscrizione al nostro Shop.<br><br>Riepilogo dati di accesso: <br>Utente:" + o.UserName + "<br>Password: " + password + "<br>" +
                 "<br><a href=\"http://www.materarredamenti.it/shop/accedi.html\">Cliccando qui</a> può accedere al suo account e verificare lo stato dei suoi ordini."; ;
        EMAIL.Bcc.Add("verduga80@libero.it");
        EMAIL.Bcc.Add("info@materarredamenti.it");
        SmtpClient SmtpMail = new SmtpClient();
        SmtpMail.Send(EMAIL);
        // invio OK!!
      }
      catch (Exception Ex)
      {
      }
    }
    catch (Exception ex)
    {
      //loggo
      //cancello l'utente dal nostro db perchè non è stato creato in magento
      divErr.Visible = true;
      lblErr.Text = "Attenzione: si è verificato un'errore nella creazione dell'account. Si prega di ripetere l'operazione.";
      Membership.DeleteUser(o.UserName);
      ok = false;
    }
    try
    {
      var CustomerAddressBilling = new CustomerAddress();
      CustomerAddressBilling.firstname = txtFirstName.Text;
      CustomerAddressBilling.lastname = txtLastName.Text;
      CustomerAddressBilling.region = txtRegion.Text;
      CustomerAddressBilling.street = txtAddress.Text;
      CustomerAddressBilling.telephone = txtTel.Text;
      CustomerAddressBilling.postcode = txtCap.Text;
      CustomerAddressBilling.city = txtCity.Text;
      CustomerAddressBilling.country_id = "IT";
      CustomerAddressBilling.is_default_billing = true;
      string myCustomerAddressId = CustomerAddress.Create((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], int.Parse(MagentoCustomerId),
                                                        CustomerAddressBilling);
      var CustomerAddressShipping = new CustomerAddress();
      CustomerAddressShipping.firstname = txtFirstName.Text;
      CustomerAddressShipping.lastname = txtLastName.Text;
      CustomerAddressShipping.region = txtRegion.Text;
      CustomerAddressShipping.street = txtAddress.Text;
      CustomerAddressShipping.telephone = txtTel.Text;
      CustomerAddressShipping.postcode = txtCap.Text;
      CustomerAddressShipping.city = txtCity.Text;
      CustomerAddressShipping.country_id = "IT";
      CustomerAddressShipping.is_default_shipping = true;
      string myCustomerAddressIdSped = CustomerAddress.Create((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], int.Parse(MagentoCustomerId),
                                                              CustomerAddressShipping);
    }
    catch (Exception ex)
    {
      ok = false;
    }
    if (ok)
    { }
  }
}
