using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mobile_HomeShopR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        //if (HttpContext.Current.Cache["sessionId"] == null)
        //{
        //    HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
        //}

        //HttpContext.Current.Cache.Insert("htmlMegaMenu", helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], "47"));



        ltrMenu.Text = Utility.readTemplateFromFile("pathTemplatemShopRosso");
    }

    protected void IsPagerVisible(object sender, EventArgs e)
    {


        //pagerEventi.Visible =
        //Utility.IsPagerVisible(pagerEventi, objEventi);
    }

   
}
