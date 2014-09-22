<%@ Application Language="C#" %>
 <script runat="server">
     void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
     }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
     }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
     }
     
     void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
           // api settings
       // Session["apiUrl"] = "http://localhost/magento/api/xmlrpc";
        Session["apiUrl"] = "http://www.zoom2cart.com/api/xmlrpc";
        string apiUser = "ws_user";
        string apiPass = "123456";
       //  Session["sessionId"] = helper.getConnection((string)Session["apiUrl"], apiUser, apiPass);
        Session["carrello"] = new ArrayList();
        Session["numOrdine"] = "000000";
        //Session["rootCat"] = "37";
        //Session["htmlMegaMenu"] = helper.setMegaMenu((string)Session["apiUrl"], (string)Session["sessionId"], (string)Session["rootCat"]);
        
        Session["NewsIDInserita"] = 0;
        Session["CaptionAlbumNews"] = "";
        Session["UrlFotoHome"] = "";
        Session["AlbumID"] = "";
        Session["IDProdottoOutlet"] = 0;
        Session["CaptionAlbumNews"] = "";
        Session["UrlFotoHome"] = "";
        Session["AlbumID"] = "";
        Session["UrlFotoProdOutlet"] = "";
        Session["UrlAllegato"] = "";
        Session["mailNewsLetter"] = "";
        Session["metatagFB"] = "";
        //nuova var sessione per la foto Articolo
        Session["pathFotoArticolo"] = "";
        Session["tipoNews"] = "";
    }
     void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
     }
       
</script>
