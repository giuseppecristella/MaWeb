using System;
using System.Data;
using System.Net.Mail;
using Resources;

public partial class newsletter : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    var mail = (string)Session["mailNewsLetter"];
    lblMail.Text = mail;
  }

  protected void btnIscrivi_Click(object sender, EventArgs e)
  {
    var mail = (string)Session["mailNewsLetter"];
    var isValid = Utility.IsValidMailAddress(mail);
    if (!isValid)
    {
      lblErr.Text = Resource.WrongMailFormatMessage;
      notificationpnl.Visible = true;
      notificationSucc.Visible = false;
      return;
    }
    if (CheckBoxcons.Checked)
    {
      var taNewsLetter = new DataSetMateraArredamentiTableAdapters.NewsLetterTableAdapter();
      DataTable dtNewsLetter = taNewsLetter.GetEmail(mail);
      if (dtNewsLetter.Rows.Count > 0)
      {
        lblErr.Text = Resource.NewsletterMessageAlreadySubscribed;
        notificationpnl.Visible = true;
        notificationSucc.Visible = false;
        CheckBoxcons.Checked = false;
        return;
      }
      taNewsLetter.Insert(mail);
      lblNewslOK.Text = Resource.NewsletterSubscribeMessageSuccess;
      notificationSucc.Visible = true;
      notificationpnl.Visible = false;
      CheckBoxcons.Checked = false;

      try
      {
        SendNotificationMail(mail);
      }
      catch (Exception Ex)
      {
        lblNewslOK.Text = Ex.Message;
        notificationpnl.Visible = true;
        notificationSucc.Visible = false;
      }
    }
    else
    {
      lblErr.Text = Resource.NewsletterMessageAccord;
      notificationpnl.Visible = true;
      notificationSucc.Visible = false;
    }
  }

  private static void SendNotificationMail(string mail)
  {
    var from = new MailAddress("info@materarredamenti.it", "Matera Arredamenti");
    var to = new MailAddress(mail, mail);
    var mailMessage = new MailMessage(@from, to)
    {
      Subject = "Conferma iscrizione newsletter Matera Arredamenti",
      IsBodyHtml = true
    };
    var mailBody =
      string.Format(
        "<img alt='header' src='http://www.materarredamenti.it/img/logo.png' /> <br>Richiesta iscrizione Newsletter <b style='color:#bf00000'>Matera Arredamenti</b> di: {0} <br><br>",
        mail);
    mailMessage.Body =
      string.Format("{0}Gentile utente: {1}<br> le confermiamo l'iscrizione al nostro servizio di newsletter", mailBody,
        mail);
    
    mailMessage.Bcc.Add("verduga80@libero.it");
    mailMessage.Bcc.Add("info@materarredamenti.it");
    var SmtpMail = new SmtpClient();
    SmtpMail.Send(mailMessage);
  }

  protected void btnDeleteSubscribedUser_OnClick(object sender, EventArgs e)
  {
    var mail = (string)Session["mailNewsLetter"];
    var isValid = Utility.IsValidMailAddress(mail);
    if (isValid)
    {
      var taNewsLetter = new DataSetMateraArredamentiTableAdapters.NewsLetterTableAdapter();
      DataTable dtNewsLetter = taNewsLetter.GetEmail(mail);
      if (dtNewsLetter.Rows.Count > 0)
      {
        taNewsLetter.Delete(mail);
        lblNewslOK.Text = Resource.NewsletterMessageDeleteMessageSuccess;
        notificationSucc.Visible = true;
        notificationpnl.Visible = false;
        CheckBoxcons.Checked = false;
      }
      else
      {
        lblErr.Text = Resource.NewsletterMessageDeleteMessageError;
        notificationpnl.Visible = true;
        notificationSucc.Visible = false;
        CheckBoxcons.Checked = false;
      }
    }
    else
    {
      lblErr.Text = Resource.WrongMailFormatMessage;
      notificationpnl.Visible = true;
      notificationSucc.Visible = false;
    }
  }
}
