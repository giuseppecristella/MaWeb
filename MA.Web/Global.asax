<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Cache" %>
<%@ Import Namespace="MagentoRepository.Connection" %>
<script RunAt="server">
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RouteConfig.RegisterRoutes(RouteTable.Routes);
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

        MagentoConnection.Instance.CacheManager = new AspnetCacheManager();
        MagentoConnection.Instance.Url = "http://www.zoom2cart.com/api/xmlrpc";
        MagentoConnection.Instance.Password = "123456";
        MagentoConnection.Instance.UserId = "ws_user";

        // DI
        //        CartHelper.CacheManager = new AspnetCacheManager();


        Session["carrello"] = new ArrayList();
        Session["numOrdine"] = "000000";

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
