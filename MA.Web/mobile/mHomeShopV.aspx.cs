using System;

public partial class mobile_HomeShopV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        //if (HttpContext.Current.Cache["sessionId"] == null)
        //{
        //    HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
        //}

        //HttpContext.Current.Cache.Insert("htmlMegaMenu", helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], "47"));



        ltrMenu.Text = Utility.readTemplateFromFile("pathTemplatemShopVerde");
    }

    protected void IsPagerVisible(object sender, EventArgs e)
    {


        //pagerEventi.Visible =
        //Utility.IsPagerVisible(pagerEventi, objEventi);
    }

   
}
