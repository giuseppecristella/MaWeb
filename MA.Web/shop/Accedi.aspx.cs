using System;
using System.Data;
using System.Globalization;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using Ez.Newsletter.MagentoApi;

public enum AddressType
{
  Billing,
  Shipping
}

public partial class shop_Accedi : BasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (IsPostBack) return;
    ViewState["PreviousPage"] = Request.UrlReferrer;
  }

  protected void btnLogin_Click(object sender, EventArgs e)
  {
    Response.Redirect(ViewState["PreviousPage"] != null
      ? ViewState["PreviousPage"].ToString()
      : "~/Shop/Customers/Account.html");
  }

  protected void CreateMagentoUser(object sender, EventArgs e)
  {
    var usernameFromUI = CreateUserWizard1.UserName;
    var passwordFromUI = CreateUserWizard1.Password;
    var membershipUser = Membership.GetUser(usernameFromUI);
    if (membershipUser == null) return;
    bool ok = true;
    try
    {
      Roles.AddUserToRole(usernameFromUI, "User");
      var magentoCustomerId = CreateMagentoCustomer();

      // Salvo nel campo 'comment' dell'oggetto User di membership provider il customer Id di Magento prodotto
      membershipUser.Comment = magentoCustomerId;
      Membership.UpdateUser(membershipUser);

      SubscriveSignedCustomerToNewsLetter();
      SendNotificationEmailToSignedCustomer(membershipUser.UserName, passwordFromUI);
      CreateMagentoCustomerAddress(AddressType.Billing, magentoCustomerId);
      CreateMagentoCustomerAddress(AddressType.Shipping, magentoCustomerId);
    }
    catch (Exception ex)
    {
      // log 

      divErr.Visible = true;
      lblErr.Text = "Attenzione: si è verificato un'errore nella creazione dell'account. Si prega di ripetere l'operazione.";
      // Cancello l'utente dal nostro db perchè non è stato creato in magento
      Membership.DeleteUser(membershipUser.UserName);
    }
  }

  private void CreateMagentoCustomerAddress(AddressType type, string customerId)
  {
    var customerAddress = new CustomerAddress
    {
      firstname = txtFirstName.Text,
      lastname = txtLastName.Text,
      region = txtRegion.Text,
      street = txtAddress.Text,
      telephone = txtTel.Text,
      postcode = txtCap.Text,
      city = txtCity.Text,
      country_id = "IT",
    };

    switch (type)
    {
      case AddressType.Billing:
        customerAddress.is_default_billing = true;
        break;
      case AddressType.Shipping:
        customerAddress.is_default_shipping = true;
        break;
      default:
        throw new ArgumentOutOfRangeException("type");
    }
    _repository.CreateCustomerAddress(int.Parse(customerId), customerAddress);

  }

  #region Private Methods

  private void SendNotificationEmailToSignedCustomer(string username, string passwordFromUI)
  {
    try
    {
      var from = new MailAddress("info@materarredamenti.it", "Matera Arredamenti");
      var to = new MailAddress(CreateUserWizard1.Email, string.Format("{0} {1}", txtFirstName.Text, txtLastName.Text));
      var email = new MailMessage(@from, to)
      {
        Subject = "Conferma creazione account shop Matera Arredamenti",
        IsBodyHtml = true
      };
      var header =
        string.Format(
          "<img alt='header' src='http://www.materarredamenti.it/images/logo_header.jpg' /> " +
          "<br><br>Creazione account Shop <b style='color:#bf00000'>Matera Arredamenti</b> di: {0} <br><br>",
          CreateUserWizard1.Email);
      email.Body =
        string.Format(
          "{0}Gentile {1} {2},<br> le confermiamo l'iscrizione al nostro Shop.<br><br>Riepilogo dati di accesso: <br>Utente:" +
          "{3}<br>Password: {4}<br>" + "<br><a href=\"http://www.materarredamenti.it/shop/accedi.html\">" +
          "Cliccando qui</a> può accedere al suo account e verificare lo stato dei suoi ordini.",
          header, txtFirstName.Text, txtLastName.Text, username, passwordFromUI);
      email.Bcc.Add("verduga80@libero.it");
      email.Bcc.Add("info@materarredamenti.it"); // Settare in variabili di configurazione
      var smtpMail = new SmtpClient();
      smtpMail.Send(email);
    }
    catch (Exception ex)
    {

    }
  }

  private void SubscriveSignedCustomerToNewsLetter()
  {
    var taNewsLetter = new DataSetMateraArredamentiTableAdapters.NewsLetterTableAdapter();
    DataTable dtNewsLetter = taNewsLetter.GetEmail(CreateUserWizard1.Email);
    if (dtNewsLetter.Rows.Count == 0)
    {
      taNewsLetter.Insert(CreateUserWizard1.Email);
    }
  }

  private string CreateMagentoCustomer()
  {
    var customer = new Customer()
    {
      firstname = txtFirstName.Text,
      lastname = txtLastName.Text,
      email = CreateUserWizard1.Email,
      created_at = DateTime.Now.ToString(CultureInfo.InvariantCulture),
    };
    return _repository.CreateCustomer(customer);
  }

  #endregion
}
