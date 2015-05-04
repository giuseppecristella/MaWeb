using System;
using System.Web.Optimization;
using System.Web.Routing;
using MagentoRepository.Connection;

namespace Shop.Web.Mvp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {


            // MagentoConnection.Instance.CacheManager = new AspnetCacheManager();
            MagentoConnection.Instance.Url = "http://www.zoom2cart.com/api/xmlrpc";
            MagentoConnection.Instance.Password = "123456";
            MagentoConnection.Instance.UserId = "ws_user";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}