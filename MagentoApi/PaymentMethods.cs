using System;
using CookComputing.XmlRpc;


namespace Ez.Newsletter.MagentoApi
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class PaymentMethod
    {


        #region Private Member Variables 
        //qua vanno mappate le funzioni del modulo Cart della Magento.Api

        private string _code;
        private string _title;
        private string _po_number;
        private string _method;
        
       // private string[] _ccType;  è un array
       



        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string po_number
        {
            get { return _po_number; }
            set { _po_number = value; }
        }
        public string method
        {
            get { return _method; }
            set { _method = value; }
        }
        //public string ccTypes
        //{
        //    get { return _ccTypes; }
        //    set { _ccTypes = value; }
        //}
     
        
         

      
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
