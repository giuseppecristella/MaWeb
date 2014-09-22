using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Ez.Newsletter.MagentoApi;
public partial class _Default_ar : System.Web.UI.MasterPage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ArrayList arrayCart = (ArrayList)Session["carrello"];
    int numItems = 0;
    if (arrayCart != null)
    {
      for (int i = 0; i < arrayCart.Count; i++)
      {
        Product tProd = (Product)arrayCart[i];
        numItems += int.Parse(tProd.qty);
      }
    }
    ltrTotCart.Text = numItems.ToString();
  }
  protected void _goNewsLetter(object sender, EventArgs e)
  {

  }
}
