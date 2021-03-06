﻿using System;
using System.Web;
using Microsoft.AspNet.FriendlyUrls;
public partial class Login : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (HttpContext.Current.User.IsInRole("Admin")) return;
    /*online non funziona*/
    const string returnUrl = "/Design/Customers/Account.html";
    var absUrl = Helper.GetAbsoluteUrl();

    if (!string.IsNullOrEmpty(Page.Request.QueryString["ReturnUrl"]))
    {
        Response.Redirect("~/Design/Accedi.aspx");
      // FriendlyUrl.Resolve("~/Shop/Accedi");
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
