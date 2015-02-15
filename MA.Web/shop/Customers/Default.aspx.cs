using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using Ez.Newsletter.MagentoApi;
using Microsoft.AspNet.FriendlyUrls;

public partial class shop_Customers_Default : BasePage
{

    #region Properties
    public string AddressShippingId
    {
        get
        {
            return (Session["AddressShippingId"] as string);
        }
        set
        {
            Session["AddressShippingId"] = value;
        }
    }

    public string AddressBillingId
    {
        get
        {
            return (Session["AddressBillingId"] as string);
        }
        set
        {
            Session["AddressBillingId"] = value;
        }
    } 
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        var utente = Page.User.Identity.Name;
        if (IsPostBack) return;
        if (!string.IsNullOrEmpty(utente))
        {
            var userAspNet = Membership.GetUser(utente);
            if (userAspNet == null) return;
            var magentoUserId = userAspNet.Comment;
           
            var customerAddresses = _repository.GetCustomerAddresses(int.Parse(magentoUserId));
            if (customerAddresses == null || !customerAddresses.Any()) return;

            var shippingAddressesId = customerAddresses.FirstOrDefault();
            AddressShippingId = shippingAddressesId != null ? shippingAddressesId.customer_address_id : string.Empty;
            var billingAddressesId = customerAddresses.LastOrDefault();
            AddressBillingId = billingAddressesId != null ? billingAddressesId.customer_address_id : string.Empty;

            //importante settare addressTest.mode = "shipping / billing";
            BindBillingAddress(customerAddresses.FirstOrDefault());
            BindShippingAddress(customerAddresses.LastOrDefault());

            var customer = _repository.GetCustomerById(int.Parse(magentoUserId));
            BindCustomerDetail(customer);
        }
        else
        {
            FriendlyUrl.Resolve("~/Shop/Accedi");
        }
    }

    protected void btnUpdateCustomerAddresses_Click(object sender, EventArgs e)
    {
        string utente = Page.User.Identity.Name;
        if (!string.IsNullOrEmpty(utente))
        {
          
            var billingAddress = new CustomerAddress
            {
                telephone = txtbphone.Text,
                firstname = txtbname.Text,
                lastname = txtblastname.Text,
                city = txtbcity.Text,
                is_default_billing = true,
                is_default_shipping = false,
                country_id = "IT",
                street = txtbaddress.Text,
                region = txtbstate.Text,
                postcode = txtbzip.Text,
                fax = txtbphone.Text,
                customer_address_id = AddressShippingId
            };
            var shippingAddress = new CustomerAddress
            {
                telephone = txtsphone.Text,
                firstname = txtsname.Text,
                lastname = txtslastname.Text,
                city = txtscity.Text,
                is_default_billing = false,
                is_default_shipping = true,
                country_id = "IT",
                street = txtsaddress.Text,
                region = txtsstate.Text,
                postcode = txtszip.Text,
                fax = txtsphone.Text,
                customer_address_id = AddressBillingId
            };
            _repository.UpdateCustomerAddress(billingAddress, int.Parse(AddressBillingId));
            _repository.UpdateCustomerAddress(shippingAddress, int.Parse(AddressShippingId));
  }
    }

    #region Private Methods

    private void BindCustomerDetail(Customer customer)
    {
        lblNome.Text = customer.firstname;
        lblCognome.Text = customer.lastname;
        lblEmail.Text = customer.email;
    }

    private void BindShippingAddress(CustomerAddress customerAddresses)
    {
        if (customerAddresses == default(CustomerAddress)) return;

        txtsphone.Text = customerAddresses.telephone;
        txtsname.Text = customerAddresses.firstname;
        txtslastname.Text = customerAddresses.lastname;
        txtscity.Text = customerAddresses.city;
        txtsaddress.Text = customerAddresses.street;
        txtszip.Text = customerAddresses.postcode;
        txtsstate.Text = customerAddresses.region;
    }

    private void BindBillingAddress(CustomerAddress customerAddresses)
    {
        if (customerAddresses == default(CustomerAddress)) return;

        txtbphone.Text = customerAddresses.telephone;
        txtbname.Text = customerAddresses.firstname;
        txtblastname.Text = customerAddresses.lastname;
        txtbcity.Text = customerAddresses.city;
        txtbaddress.Text = customerAddresses.street;
        txtbzip.Text = customerAddresses.postcode;
        txtbstate.Text = customerAddresses.region; /*region-->provincia*/
    } 
    #endregion
}
