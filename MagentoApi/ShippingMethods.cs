using System;
using CookComputing.XmlRpc;


namespace Ez.Newsletter.MagentoApi
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class ShippingMethod
    {


        #region Private Member Variables 
        //qua vanno mappate le funzioni del modulo Cart della Magento.Api

        private string _code;
        private string _carrier;
        private string _carrier_title;
        private string _method;
        private string _method_title;
        private string _method_description;
        private string _price;
        private string _carrierName;



        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string carrier
        {
            get { return _carrier; }
            set { _carrier = value; }
        }
        public string carrier_title
        {
            get { return _carrier_title; }
            set { _carrier_title = value; }
        }
        public string method
        {
            get { return _method; }
            set { _method = value; }
        }
        public string method_title
        {
            get { return _method_title; }
            set { _method_title = value; }
        }
        public string method_description
        {
            get { return _method_description; }
            set { _method_description = value; }
        }
        public string price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string carrierName
        {
            get { return _carrierName; }
            set { _carrierName = value; }
        }
        
         

      
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
        
        

        #endregion




        #region Interfaces
        // interface to orders
        
        #endregion
    }
}
