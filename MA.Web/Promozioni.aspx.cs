using System;

public partial class Promozioni : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
    }
  }

  protected void IsPagerVisible(object sender, EventArgs e)
  {
    pagerPromo.Visible =
    Utility.IsPagerVisible(pagerPromo, objPromo);
  }

}
