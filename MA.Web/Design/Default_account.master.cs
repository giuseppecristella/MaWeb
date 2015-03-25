using System;
using System.Collections;
using Ez.Newsletter.MagentoApi;
public partial class Default_account : System.Web.UI.MasterPage
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
    
  }

  protected void _goNewsLetter(object sender, EventArgs e)
  {
  }
}
