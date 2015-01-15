using System;

public partial class mobile_HomeShopR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        //if (HttpContext.Current.Cache["sessionId"] == null)
        //{
        //    HttpContext.Current.Cache.Insert("sessionId", Helper.GetConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
        //}

        //HttpContext.Current.Cache.Insert("htmlMegaMenu", Helper.SetMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], "47"));



        ltrMenu.Text = Utility.ReadTemplateFromFile("pathTemplatemShopRosso");
    }

    protected void IsPagerVisible(object sender, EventArgs e)
    {


        //pagerEventi.Visible =
        //Utility.IsPagerVisible(pagerEventi, objEventi);
    }

   
}
