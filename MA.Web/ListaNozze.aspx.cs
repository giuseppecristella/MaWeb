using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class ListaNozze : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }

  protected void _isPagerVisible(object sender, EventArgs e)
  {
    bool isVis = Utility.IsPagerVisible(pagerCasa, objCasa);
    pagerCasa.Visible = isVis;
  }

  protected void _isPagerVisibleCucina(object sender, EventArgs e)
  {
    bool isVis = Utility.IsPagerVisible(pagerCucina, objCucina);
    pagerCucina.Visible = isVis;
  }

  protected void _isPagerVisibleManu(object sender, EventArgs e)
  {
    bool isVis = Utility.IsPagerVisible(pagerManu, objManutenzione);
    pagerManu.Visible = isVis;
  }

}
