using System;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*online non funziona*/

        string returnUrl = "/materarredamenti.it/Shop/Customers/Account.html";

        string returnUrlOnline = "/Shop/Customers/Account.html";

        string absUrl = Helper.GetAbsoluteUrl();

        if (absUrl.Contains("www.materarredamenti.it"))
        {
            if (!string.IsNullOrEmpty(Page.Request.QueryString["ReturnUrl"]))
            {
                if (Page.Request.QueryString["ReturnUrl"].ToLower().Substring(0, 16) == returnUrlOnline.ToLower().Substring(0, 16))
                    Response.Redirect("~/shop/Accedi.aspx");
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(Page.Request.QueryString["ReturnUrl"]))
            {
                if (Page.Request.QueryString["ReturnUrl"].ToLower().Substring(0, 36) == returnUrl.ToLower().Substring(0, 36))
                    Response.Redirect("~/shop/Accedi.html");
            }
        }





        //DivError.Visible = false;
        ContattilblNotificationErr.Visible = false;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //
        // Validate user, check login, create authentication ticket, populate roles, etc.
        // ...
        //


        Response.Redirect("~/Admin/ManageNews.aspx");

    }

    protected void LoginError(object sender, EventArgs e)
    {
        DivError.Visible = true;
        ContattilblNotificationErr.Visible = true;

        DivInfo.Visible = false;
    }
}
