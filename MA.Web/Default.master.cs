using System;

public partial class _Default : System.Web.UI.MasterPage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    //lblLikes.Text ="<b>"+ Utility.fbLikes("matearredamenti")+"</b> \"Mi piace\"";
    ltrMetaFB.Text = (string)Session["metatagFB"];
  }

  protected void _goNewsLetter(object sender, EventArgs e)
  {
    Page.Session["mailNewsLetter"] = txtNL_1.Text;
    if (Utility.emailValida(txtNL_1.Text))
    { Response.Redirect("~/newsletter.aspx"); }
    else
    { Response.Redirect("~/Index.html"); }
  }
}
