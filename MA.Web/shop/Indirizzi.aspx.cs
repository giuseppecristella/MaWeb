using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;

public partial class Indirizzi : System.Web.UI.Page
{
  //in query string mi arriva l'id del carrello dalla pagina precedente (carrello.aspx) in cui ho fatto la create
  private string idUserMagento = "";
  string cartId = "";
  Customer customer;
  CustomerAddress[] myCustomerAddresses = null;
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!helper.checkConnection())
    {
      HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
      HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
    }
    string cartId = Request.QueryString["cartId"];
    ArrayList arrayCart = (ArrayList)Session["carrello"];
    Customer customer = new Customer();
    string utente = Page.User.Identity.Name;
    if (!string.IsNullOrEmpty(utente))
    {
      MembershipUser userAspNet = Membership.GetUser(utente);
      //a questo punto l'utente sarà già loggato quindi devo fare una Customer Info per recuperare gli eventuali indirizzi
      idUserMagento = userAspNet.Comment;
      if (!IsPostBack)
      {
        if (!string.IsNullOrEmpty(cartId))
        {
          if (HttpContext.Current.Cache["customer"] == null)
          {
            HttpContext.Current.Cache.Insert("customer",
                                             Customer.Info((string)HttpContext.Current.Cache["apiUrl"],
                                                           (string)HttpContext.Current.Cache["sessionId"],
                                                           int.Parse(idUserMagento)));
          }
          customer = (Customer)HttpContext.Current.Cache["customer"];
          //Customer[] myCustomers = Customer.List(apiUrl, sessionId, new string[] { });
          //per ora non gestiamo il mode guest
          customer.mode = "register";
          //myCustomers[0].password_hash = "123456";
          CustomerAddress[] myCustomerAddresses = Ez.Newsletter.MagentoApi.CustomerAddress.List((string)HttpContext.Current.Cache["apiUrl"],
                                                                                            (string)HttpContext.Current.Cache["sessionId"],
                                                                                            new object[] { int.Parse(idUserMagento) });
          //funzione in helper per verificare che esistano gli indirizzi associati all'utente se si vado a riempire l'array indirizzi
          //importante settare addressTest.mode = "shipping / billing";
          myCustomerAddresses = ordinaIndirizzi(myCustomerAddresses);
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
          bool retCustSet = Cart.cartCustomerSet((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId), customer });
          myCustomerAddresses[0].mode = "billing";
          myCustomerAddresses[1].mode = "shipping";
          bool retCustAddress = Cart.cartCustomerAddresses((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"],
                                                           new object[] { int.Parse(cartId), myCustomerAddresses });
          //aggiungo i prodotti al carrello
          foreach (Product p in arrayCart)
          {
            Cart.cartProductAdd((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId), p });
          }
          PaymentMethod[] payMethods = Cart.cartPaymentList((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"],
                                                        new object[] { int.Parse(cartId) });
          ArrayList metodiPagamento = new ArrayList();
          for (int i = 0; i < payMethods.Length; i++)
            metodiPagamento.Add(payMethods[i].title);
          rdbtnListPayMethods.DataSource = metodiPagamento;
          rdbtnListPayMethods.DataBind();
          rdbtnListPayMethods.Items[0].Selected = true;
          //questa info devo visualizzarla nella pagina carrello.aspx e devo chiamare il metodo Cart.cartShippingMethod dopo la create*/
          //questa sbrocca perchè ho cambiato la valuta e mi ritorna un double!!!
          //ShippingMethod[] shippingMethods = Cart.cartShippingList(apiUrl, sessionId, new object[] { int.Parse(cartId) });
        }
        else
          Response.Redirect("carrello.html");
      }
    }
    else
    {
      Response.Redirect("~/Shop/accedi.html");
    }
  }
  private CustomerAddress[] ordinaIndirizzi(CustomerAddress[] customerAddress)
  {
    if (customerAddress.Length == 1)
    {
      CustomerAddress[] ordCustAdd = { customerAddress[0], customerAddress[0] };
      return ordCustAdd;
    }
    else
    {
      return customerAddress[0].is_default_billing
                 ? customerAddress
                 : customerAddress.Reverse().ToArray();
    }
  }

  protected void lnkbtnOrder_Click(object sender, EventArgs e)
  {
    ArrayList arrayCart = (ArrayList)Session["carrello"];
    string cartId = Request.QueryString["cartId"];
    CustomerAddress[] myCustomerAddresses = Ez.Newsletter.MagentoApi.CustomerAddress.List((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(idUserMagento) });
    myCustomerAddresses = ordinaIndirizzi(myCustomerAddresses);
    myCustomerAddresses[0].mode = "billing";
    myCustomerAddresses[1].mode = "shipping";
    bool retCustAddress = Cart.cartCustomerAddresses((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId), myCustomerAddresses });
    bool retShippingMethod = Cart.cartShippingMethod((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId), "flatrate_flatrate" });
    PaymentMethod[] payMethods = Cart.cartPaymentList((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId) });
    int i = 0;
    int sel = 0;
    foreach (ListItem rdbtnitem in rdbtnListPayMethods.Items)
    {
      if (rdbtnitem.Selected)
      {
        sel = i;
      }
      i++;
    }
    payMethods[sel].method = payMethods[0].code;
    payMethods[sel].po_number = "000";
    bool retPayMethod = Cart.cartPaymentMethod((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId), payMethods[sel] });
    Response.Redirect("Riepilogo.aspx?cartId=" + cartId);
  }

  protected void btnUpdateBilling_Click(object sender, EventArgs e)
  {
    string utente = Page.User.Identity.Name;
    //   var profile = HttpContext.Current.Profile;
    if (!string.IsNullOrEmpty(utente))
    {
      MembershipUser userAspNet = Membership.GetUser(utente);
      string idUserMagento = userAspNet.Comment;
      CustomerAddress[] myCustomerAddresses = Ez.Newsletter.MagentoApi.CustomerAddress.List((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(idUserMagento) });
      CustomerAddress addressBilling = new CustomerAddress();
      addressBilling.telephone = txtbphone.Text;
      addressBilling.firstname = txtbname.Text;
      addressBilling.lastname = txtblastname.Text;
      addressBilling.city = txtbcity.Text;
      addressBilling.is_default_billing = true;
      addressBilling.is_default_shipping = false;
      addressBilling.country_id = "IT";
      addressBilling.street = txtbaddress.Text;
      addressBilling.region = txtbstate.Text;//è la provincia nel caso italia
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
      addressShipping.region = txtsstate.Text;//è la provincia nel caso italia
      addressShipping.postcode = txtszip.Text;
      addressShipping.fax = txtsphone.Text;
      addressShipping.customer_address_id = myCustomerAddresses[1].customer_address_id;
      CustomerAddress.Update((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], Convert.ToInt32(myCustomerAddresses[0].customer_address_id), addressBilling);
      CustomerAddress.Update((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], Convert.ToInt32(myCustomerAddresses[1].customer_address_id), addressShipping);
    }
  }
}
