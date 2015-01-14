using System;
using System.Net.Mail;
using Resources;

public partial class contact : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }

  protected void btnInvioMail_Click(object sender, EventArgs e)
  {
    if (Utility.IsValidMailAddress(email.Text))
    {
      try
      {
        var from = new MailAddress(email.Text, name.Text);
        var to = new MailAddress("info@materarredamenti.it", "materarredamenti.it");
        var EMAIL = new MailMessage(from, to) { Subject = oggetto.Text, IsBodyHtml = true, Body = messaggio.Text };
        EMAIL.Bcc.Add("verduga80@libero.it");
        var SmtpMail = new SmtpClient();
        SmtpMail.Send(EMAIL);

        lblInvioOK.Text = Resource.SendMessageSuccess;
        notificationErr.Visible = false;
        notificationSucc.Visible = true;
        ResetFormFields();
      }
      catch (Exception Ex)
      {
        lblErr.Text = Ex.Message;
        notificationErr.Visible = true;
        notificationSucc.Visible = false;
      }
    }
    else
    {
      lblErr.Text = Resource.WrongMailFormatMessage;
      notificationErr.Visible = true;
      notificationSucc.Visible = false;
    }
  }

  private void ResetFormFields()
  {
    email.Text = string.Empty;
    oggetto.Text = string.Empty;
    name.Text = string.Empty;
    messaggio.Text = string.Empty;
  }
}
