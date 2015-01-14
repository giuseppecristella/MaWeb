using System;
using System.Data;
using System.Web.UI.WebControls;
public partial class Eventi : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }
  protected void IsPagerVisible(object sender, EventArgs e)
  {
    pagerEventi.Visible =
    Utility.IsPagerVisible(pagerEventi, objEventi);
  }

}
