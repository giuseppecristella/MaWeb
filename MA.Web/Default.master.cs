using System;

public partial class _Default : System.Web.UI.MasterPage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ltrMetaFB.Text = (string)Session["metatagFB"];
  }

  protected void _goNewsLetter(object sender, EventArgs e)
  {
    Page.Session["mailNewsLetter"] = txtNewsLetter.Text;
    Response.Redirect(Utility.IsValidMailAddress(txtNewsLetter.Text) ? "~/newsletter" : "/");
  }
}
