using System;
using System.Web;
using System.Web.Security;
using Ez.Newsletter.MagentoApi;
using Microsoft.AspNet.FriendlyUrls;

public partial class shop_Customers_Default : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    
    string utente = Page.User.Identity.Name;
    //   var profile = Profile.GetProfile(utente);
    if (IsPostBack) return;
    if (!string.IsNullOrEmpty(utente))
    {
      MembershipUser userAspNet = Membership.GetUser(utente);
      //a questo punto l'utente sarà già loggato quindi devo fare una Customer Info per recuperare gli eventuali indirizzi
      string idUserMagento = userAspNet.Comment;
      Ez.Newsletter.MagentoApi.Customer customer = Ez.Newsletter.MagentoApi.Customer.Info((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], int.Parse(idUserMagento));
      CustomerAddress[] myCustomerAddresses = Ez.Newsletter.MagentoApi.CustomerAddress.List((string)HttpContext.Current.Cache["apiUrl"],
        (string)HttpContext.Current.Cache["sessionId"],
        new object[]
        {
          int.
            Parse
            (idUserMagento)
        });
      //funzione in Helper per verificare che esistano gli indirizzi associati all'utente se si vado a riempire l'array indirizzi
      //importante settare addressTest.mode = "shipping / billing";
      /*billing*/
      txtbphone.Text = myCustomerAddresses[0].telephone;
      txtbname.Text = myCustomerAddresses[0].firstname;
      txtblastname.Text = myCustomerAddresses[0].lastname;
      txtbcity.Text = myCustomerAddresses[0].city;
      txtbaddress.Text = myCustomerAddresses[0].street;
      txtbzip.Text = myCustomerAddresses[0].postcode;
      txtbstate.Text = myCustomerAddresses[0].region; /*region-->provincia*/
      //ddl per il country_id (legge dal db il campo  [country_id] => IT)
      //quando modifico prendo il codice a 2 lettere e lo metto nel db
      /*shipping*/
      txtsphone.Text = myCustomerAddresses[1].telephone;
      txtsname.Text = myCustomerAddresses[1].firstname;
      txtslastname.Text = myCustomerAddresses[1].lastname;
      txtscity.Text = myCustomerAddresses[1].city;
      txtsaddress.Text = myCustomerAddresses[1].street;
      txtszip.Text = myCustomerAddresses[1].postcode;
      txtsstate.Text = myCustomerAddresses[1].region;
      lblNome.Text = customer.firstname;
      lblCognome.Text = customer.lastname;
      lblEmail.Text = customer.email;
    }
    else
    {
      FriendlyUrl.Resolve("~/Shop/Accedi");
      //Response.Redirect("~/Shop/Accedi");
    }
  }
  protected void btnUpdateBilling_Click(object sender, EventArgs e)
  {
    string utente = Page.User.Identity.Name;
    //  var profile = HttpContext.Current.Profile;
    if (!string.IsNullOrEmpty(utente))
    {
      MembershipUser userAspNet = Membership.GetUser(utente);
      string idUserMagento = userAspNet.Comment;
      CustomerAddress[] myCustomerAddresses = Ez.Newsletter.MagentoApi.CustomerAddress.List((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"],
                                                                                            new object[]
                                                                                                         {
                                                                                                             int.Parse(
                                                                                                                 idUserMagento)
                                                                                                         });
      CustomerAddress addressBilling = new CustomerAddress();
      addressBilling.telephone = txtbphone.Text;
      addressBilling.firstname = txtbname.Text;
      addressBilling.lastname = txtblastname.Text;
      addressBilling.city = txtbcity.Text;
      addressBilling.is_default_billing = true;
      addressBilling.is_default_shipping = false;
      addressBilling.country_id = "IT";
      addressBilling.street = txtbaddress.Text;
      addressBilling.region = txtbstate.Text; //è la provincia nel caso italia
      addressBilling.postcode = txtbzip.Text;
      addressBilling.fax = txtbphone.Text;
      addressBilling.customer_address_id = myCustomerAddresses[0].customer_address_id;
      CustomerAddress addressShipping = new CustomerAddress();
      addressShipping.telephone = txtsphone.Text;
      addressShipping.firstname = txtsname.Text;
      addressShipping.lastname = txtslastname.Text;
      addressShipping.city = txtscity.Text;
      addressShipping.is_default_billing = false;
      addressShipping.is_default_shipping = true;
      addressShipping.country_id = "IT";
      addressShipping.street = txtsaddress.Text;
      addressShipping.region = txtsstate.Text; //è la provincia nel caso italia
      addressShipping.postcode = txtszip.Text;
      addressShipping.fax = txtsphone.Text;
      addressShipping.customer_address_id = myCustomerAddresses[1].customer_address_id;
      CustomerAddress.Update((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], Convert.ToInt32(myCustomerAddresses[0].customer_address_id),
                             addressBilling);
      CustomerAddress.Update((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], Convert.ToInt32(myCustomerAddresses[1].customer_address_id),
                             addressShipping);
    }
  }
}
