using System;
using System.Collections;
using Ez.Newsletter.MagentoApi;

public partial class Default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        


        ArrayList arrayCart = (ArrayList)Session["carrello"];


        int numItems = 0;

        if (arrayCart!=null)
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
        //Page.Session["mailNewsLetter"] = txtNL_1.Text;

        //if (Utility.emailValida(txtNL_1.Text))
        //{ Response.Redirect("~/newsletter.aspx"); }
        //else
        //{ Response.Redirect("~/Index.html"); }
    }
}
