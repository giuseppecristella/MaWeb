using System;
using System.Globalization;
using System.Threading;
using System.Web;
/// <summary>
/// Summary description for Class2
/// </summary>
public class LocalizationHttpModule : IHttpModule
{
  public void Init(HttpApplication context)
  {
    System.Web.SessionState.SessionStateModule mySessionMod =
    (System.Web.SessionState.SessionStateModule)context.Modules["Session"];
    mySessionMod.Start += (Session_Start);
  }

  public void Dispose() { }

  private void Session_Start(object sender, EventArgs e)
  {
  }

  private void LoadCulture(ref string path)
  {
    string[] pathParts = path.Trim('/').Split('/');
    string defaultCulture = Thread.CurrentThread.CurrentCulture.ToString();//LocalizationConfiguration.GetConfig().DefaultCultureName;
    if (pathParts.Length > 0 && pathParts[0].Length > 0)
    {
      try
      {
        CultureInfo c;
        c = CultureInfo.CreateSpecificCulture(pathParts[0]);
        Thread.CurrentThread.CurrentCulture = c;
        Thread.CurrentThread.CurrentUICulture = c;
        // Thread.CurrentThread.CurrentCulture = new CultureInfo(pathParts[0]);
        path = path.Remove(0, pathParts[0].Length + 1);
      }
      catch (Exception ex)
      {
        if (!(ex is ArgumentNullException) && !(ex is ArgumentException))
        {
          throw;
        }
        Thread.CurrentThread.CurrentCulture = new CultureInfo(defaultCulture);
      }
    }
    else
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo(defaultCulture);
    }
    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
  }
}
