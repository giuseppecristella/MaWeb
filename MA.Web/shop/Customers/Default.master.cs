using System;
using System.Collections;
using System.Linq;
using Ez.Newsletter.MagentoApi;
public partial class Default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var arrayCart = (ArrayList)Session["carrello"];
        var numItems = 0;
        if (arrayCart != null)
        {
            numItems += arrayCart.Cast<Product>().Sum(tProd => int.Parse(tProd.qty));
        }

    }

    protected void _goNewsLetter(object sender, EventArgs e)
    {

    }
}
