using System;
using CookComputing.XmlRpc;


namespace Ez.Newsletter.MagentoApi
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Cart
    {


        #region Private Member Variables 
        //qua vanno mappate le funzioni del modulo Cart della Magento.Api
        private const string _cart_create = "cart.create";
        private const string _cart_totals = "cart.totals";

        private const string _cart_product_add = "cart_product.add";
        private const string _cart_order = "cart.order";
        private const string _cart_customer_set = "cart_customer.set";
        private const string _cart_customer_addresses = "cart_customer.addresses";
        private const string _cart_shipping_list = "cart_shipping.list";
        private const string _cart_shipping_method = "cart_shipping.method";

        private const string _cart_payment_list = "cart_payment.list";
        private const string _cart_payment_method = "cart_payment.method";
         
        
        
         

      
        //qua vanno mappati i parametri delle funzioni del modulo 

         #endregion

        #region Private Properties

        #endregion


        #region Constructor

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        // method to get orders
        public static int create(string apiUrl, string sessionId)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;

            return proxy.create(sessionId, _cart_create);
        }

        public static string[] totals(string apiUrl, string sessionId, object[] args)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;

            return proxy.totals(sessionId, _cart_totals, args);
        }


        public static bool cartProductAdd(string apiUrl, string sessionId, object[] args)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;
         
            return proxy.cartProductAdd(sessionId, _cart_product_add, args);
        }

        public static string cartOrder(string apiUrl, string sessionId, object[] args)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;

            return proxy.cartOrder(sessionId, _cart_order, args);
        }

        public static bool cartCustomerSet(string apiUrl, string sessionId, object[] args)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;

            return proxy.cartCustomerSet(sessionId, _cart_customer_set, args);
        }


        public static bool cartCustomerAddresses(string apiUrl, string sessionId, object[] args)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;

            return proxy.cartCustomerAddresses(sessionId, _cart_customer_addresses, args);
        }

        public static ShippingMethod[] cartShippingList(string apiUrl, string sessionId, object[] args)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;

            return proxy.cartShippingList(sessionId, _cart_shipping_list, args);
        }

        public static bool cartShippingMethod(string apiUrl, string sessionId, object[] args)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;

            return proxy.cartShippingMethod(sessionId, _cart_shipping_method, args);
        }

        public static PaymentMethod[] cartPaymentList(string apiUrl, string sessionId, object[] args)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;

            return proxy.cartPaymentList(sessionId, _cart_payment_list, args);
        }

        public static bool cartPaymentMethod(string apiUrl, string sessionId, object[] args)
        {
            ICart proxy = (ICart)XmlRpcProxyGen.Create(typeof(ICart));
            proxy.Url = apiUrl;

            return proxy.cartPaymentMethod(sessionId, _cart_payment_method, args);
        }

        #endregion




        #region Interfaces
        // interface to orders
        public interface ICart : IXmlRpcProxy
        {
            [XmlRpcMethod("call")]
            int create(string sessionId, string method);
            [XmlRpcMethod("call")]
            string[] totals(string sessionId, string method, object[] args);

            [XmlRpcMethod("call")]
            bool cartProductAdd(string sessionId, string method, object[] args);

            [XmlRpcMethod("call")]
            string cartOrder(string sessionId, string method, object[] args);

            [XmlRpcMethod("call")]
            bool cartCustomerSet(string sessionId, string method, object[] args);
           
            [XmlRpcMethod("call")]
            bool cartCustomerAddresses(string sessionId, string method, object[] args);

            [XmlRpcMethod("call")]
            ShippingMethod[] cartShippingList(string sessionId, string method, object[] args);

            [XmlRpcMethod("call")]
            bool cartShippingMethod(string sessionId, string method, object[] args);

            [XmlRpcMethod("call")]
            PaymentMethod[] cartPaymentList(string sessionId, string method, object[] args);

            [XmlRpcMethod("call")]
            bool cartPaymentMethod(string sessionId, string method, object[] args);

      
        }
        #endregion
    }
}
