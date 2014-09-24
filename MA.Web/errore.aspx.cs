using System;

public partial class errore : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }

  protected void btnIndietro_Click(object sender, EventArgs e)
  {
    if (Utility.emailValida(txtNewsLettererr.Text))
    {
      Page.Session["mailNewsLetter"] = txtNewsLettererr.Text;
      Response.Redirect("~/newsletter.html");
    }
    else
    {
      Response.Redirect("~/errore.aspx");
    }
  }
}
