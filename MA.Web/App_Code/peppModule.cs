using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
/// <summary>
/// Summary description for peppModule
/// </summary>
public class peppModule : IHttpModule
{
  public void Init(HttpApplication context)
  {
    context.PostAcquireRequestState += new EventHandler(Session_Start);
    //System.Web.SessionState.SessionStateModule mySessionMod =
    // (System.Web.SessionState.SessionStateModule)context.Modules["Session"];
    //mySessionMod.Start += (Session_Start);
  }
  #region IHttpModule Members

  public void Session_Start(object sender, EventArgs e)
  {
    HttpContext context = ((HttpApplication)sender).Context;
    HttpContext.Current.Session["apiUrl"] = "http://www.zoom2cart.com/api/xmlrpc";
  }

  public void Dispose()
  {
  }
  #endregion
}
