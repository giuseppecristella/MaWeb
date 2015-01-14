using System;

public partial class shadow : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  protected void _goNewsLetter(object sender, EventArgs e)
  {
    Page.Session["mailNewsLetter"] = txtNL_1.Text;

    if (Utility.IsValidMailAddress(txtNL_1.Text))
    { Response.Redirect("~/newsletter.aspx"); }
    else
    { Response.Redirect("~/Index.html"); }


  }
}
