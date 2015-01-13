using System;
using Microsoft.AspNet.FriendlyUrls;
public partial class Login : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    /*online non funziona*/
    const string returnUrl = "/Shop/Customers/Account.html";
    var absUrl = Helper.GetAbsoluteUrl();

    if (!string.IsNullOrEmpty(Page.Request.QueryString["ReturnUrl"]))
    {
      FriendlyUrl.Resolve("~/Shop/Accedi");
    }

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
