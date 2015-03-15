using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;

/// <summary>
/// Accedo a questa pagina con l'Id carrello in query string
/// workflow: 
/// 1) binding indirizzi utente per eventuale modifica 
/// 2) preparazione carrello associa customer - indirizzi customer - prodotti - metodi pagamento - spedizione
/// 3) Nota: rendere logica business indipendente dall'ìnterfaccia
/// </summary>
public partial class Indirizzi : BasePage
{
    private static int _customerId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        var utente = Page.User.Identity.Name;
        if (string.IsNullOrEmpty(utente)) Response.Redirect("~/Shop/accedi.aspx");

        var aspNetUser = Membership.GetUser(utente);
        if (aspNetUser == null) Response.Redirect("~/Shop/accedi.aspx");
        var magentoUserId = aspNetUser.Comment;

        if (!int.TryParse(magentoUserId, out _customerId)) return;
        var customer = _repository.GetCustomerById(_customerId);
        customer.mode = "register";

        SessionFacade.CartId = _repository.CreateCart();
        var areCustomerAssociatedToCart = _repository.AssociateCustomerToCart(SessionFacade.CartId, customer);
        if (!areCustomerAssociatedToCart) return; // trace log

        var customerAddresses = _repository.GetCustomerAddresses(_customerId);
        BindCustomerAddresses(customerAddresses);
        customerAddresses[0].mode = "billing";
        customerAddresses[1].mode = "shipping";

        var areCustomerAddressesAddedToCart = _repository.AddCustomerAddressesToCart(SessionFacade.CartId, customerAddresses);
        if (!areCustomerAddressesAddedToCart) return; // trace log

        // aggiungo i prodotti al carrello
        foreach (var product in Cart.Products)
        {
            _repository.AddProductToCart(SessionFacade.CartId, product);
        }

        var paymentMethods = _repository.GetPaymentMethods(SessionFacade.CartId);

        rdbtnListPayMethods.DataSource = paymentMethods.Select(p => p.title).ToList();
        rdbtnListPayMethods.DataBind();
        rdbtnListPayMethods.Items[0].Selected = true;
        //questa info devo visualizzarla nella pagina carrello.aspx e devo chiamare il metodo Cart.cartShippingMethod dopo la create*/
        //questa sbrocca perchè ho cambiato la valuta e mi ritorna un double!!!
        //ShippingMethod[] shippingMethods = Cart.cartShippingList(apiUrl, sessionId, new object[] { int.Parse(cartId) });

    }

    private void BindCustomerAddresses(List<CustomerAddress> myCustomerAddresses)
    {
        /*billing*/
        txtbphone.Text = myCustomerAddresses[0].telephone;
        txtbname.Text = myCustomerAddresses[0].firstname;
        txtblastname.Text = myCustomerAddresses[0].lastname;
        txtbcity.Text = myCustomerAddresses[0].city;
        txtbaddress.Text = myCustomerAddresses[0].street;
        txtbzip.Text = myCustomerAddresses[0].postcode;
        txtbstate.Text = myCustomerAddresses[0].region;

        /*shipping*/
        txtsphone.Text = myCustomerAddresses[1].telephone;
        txtsname.Text = myCustomerAddresses[1].firstname;
        txtslastname.Text = myCustomerAddresses[1].lastname;
        txtscity.Text = myCustomerAddresses[1].city;
        txtsaddress.Text = myCustomerAddresses[1].street;
        txtszip.Text = myCustomerAddresses[1].postcode;
        txtsstate.Text = myCustomerAddresses[1].region;
    }

    protected void lnkbtnOrder_Click(object sender, EventArgs e)
    {
        // Implementare uno unit test, per lo scenario di scadenza sessione per un carrello creato a cui devo assegnare i metodi di pagamento

        var myCustomerAddresses = _repository.GetCustomerAddresses(_customerId);
        myCustomerAddresses[0].mode = "billing";
        myCustomerAddresses[1].mode = "shipping";

        //Ez.Newsletter.MagentoApi.Cart.cartCustomerAddresses((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(cartId), myCustomerAddresses });

        if (!_repository.AddShippingMethodToCart(SessionFacade.CartId, "flatrate_flatrate")) return;
        var payMethods = _repository.GetPaymentMethods(SessionFacade.CartId);

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
        if (!_repository.AddPaymentMethodsToCart(SessionFacade.CartId, payMethods[sel])) return;
        Response.Redirect("Riepilogo.aspx");
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
            var addressBilling = new CustomerAddress();
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
