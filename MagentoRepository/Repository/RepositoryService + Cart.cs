using System;
using System.Collections.Generic;
using System.Linq;
using Ez.Newsletter.MagentoApi;

namespace MagentoRepository.Repository
{

    public partial class RepositoryService
    {
        public int CreateCart()
        {
            try
            {
                return Cart.create(_connection.Url, _connection.SessionId);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<ShippingMethod> GetShippingMethods(int cartId)
        {
            try
            {
                var shippingMethods = Cart.cartShippingList(_connection.Url, _connection.SessionId,
                  new object[] { cartId });
                if (shippingMethods == null) return null;
                return shippingMethods.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        // TODO: Cachare anche i metodi seguenti
        public bool AssociateCustomerToCart(int cartId, Customer customer)
        {
            try
            {
                return Cart.cartCustomerSet(_connection.Url, _connection.SessionId, new object[] { cartId, customer });
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddCustomerAddressesToCart(int cartId, List<CustomerAddress> customerAddresses)
        {
            try
            {
                return Cart.cartCustomerAddresses(_connection.Url, _connection.SessionId, new object[] { cartId, customerAddresses.ToArray() });
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddProductToCart(int cartId, Product product)
        {
            try
            {
                return Cart.cartProductAdd(_connection.Url, _connection.SessionId, new object[] { cartId, product });
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<PaymentMethod> GetPaymentMethods(int cartId)
        {
            try
            {
                return Cart.cartPaymentList(_connection.Url, _connection.SessionId, new object[] { cartId }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddShippingMethodToCart(int cartId, string shippingMethod)
        {
            try
            {
                return Cart.cartShippingMethod(_connection.Url, _connection.SessionId, new object[] { cartId, "flatrate_flatrate" });
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddPaymentMethodsToCart(int cartId, PaymentMethod paymentMethod)
        {
            try
            {
                return Cart.cartPaymentMethod(_connection.Url, _connection.SessionId, new object[] { cartId, paymentMethod });
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
