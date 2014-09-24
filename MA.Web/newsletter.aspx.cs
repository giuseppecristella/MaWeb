using System;
using System.Data;
using System.Net.Mail;
public partial class newsletter : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    string mail = (string)Session["mailNewsLetter"];
    lblMail.Text = mail;

  }

  protected void btnIscrivi_Click(object sender, EventArgs e)
  {
    string mail = (string)Session["mailNewsLetter"];
    bool isValid = Utility.emailValida(mail);
    if (isValid)
    {
      if (CheckBoxcons.Checked)
      {

        DataSetMateraArredamentiTableAdapters.NewsLetterTableAdapter taNewsLetter = new DataSetMateraArredamentiTableAdapters.NewsLetterTableAdapter();
        DataTable dtNewsLetter = taNewsLetter.GetEmail(mail);
        if (dtNewsLetter.Rows.Count == 0) 
        {
          taNewsLetter.Insert(mail);
          lblNewslOK.Text = "L'iscrizione al nostro servizio Newsletter è avvenuta con successo.<br /> Riceverà a breve una e-mail di notifica.";
          notificationSucc.Visible = true;
          notificationpnl.Visible = false;
          CheckBoxcons.Checked = false;
          // mando la mail
          try
          {
            MailAddress from = new MailAddress("info@materarredamenti.it", "Matera Arredamenti");
            MailAddress to = new MailAddress(mail, mail);
            MailMessage EMAIL = new MailMessage(from, to);
            EMAIL.Subject = "Conferma iscrizione newsletter Matera Arredamenti";
            EMAIL.IsBodyHtml = true;
            string header = "<img alt='header' src='http://www.materarredamenti.it/img/logo.png' /> <br>Richiesta iscrizione Newsletter <b style='color:#bf00000'>Matera Arredamenti</b> di: " + mail + " <br><br>";
            EMAIL.Body = header + "Gentile utente: " + mail + "<br> le confermiamo l'iscrizione al nostro servizio di newsletter"; ;
            EMAIL.Bcc.Add("verduga80@libero.it");
            EMAIL.Bcc.Add("info@materarredamenti.it");
            SmtpClient SmtpMail = new SmtpClient();
            SmtpMail.Send(EMAIL);
            // invio OK!!
          }
          catch (Exception Ex)
          {

          }
        }
        else
        {
          lblErr.Text = "Attenzione: l'indirizzo e-mail inserito risulta già presente nei nostri archivi, pertanto non è possibile procedere con la registrazione.";
          notificationpnl.Visible = true;
          notificationSucc.Visible = false;
          CheckBoxcons.Checked = false;
        }
      }
      else
      {
        lblErr.Text = "Per poter iscriversi al nostro servizio Newsletter è necessario prestare il consenso.";
        notificationpnl.Visible = true;
        notificationSucc.Visible = false;
        // Utility.apriShadow("prestare il consenso");
      }

    }
    else
    {
      //l'email non ha un formato valido
      lblErr.Text = "l'email inserita non ha un formato valido. (es. user@host.it)";
      notificationpnl.Visible = true;

      notificationSucc.Visible = false;
    }
  }

  protected void btnCancella_Click(object sender, EventArgs e)
  {
    string mail = (string)Session["mailNewsLetter"];
    bool isValid = Utility.emailValida(mail);
    if (isValid)
    {
      DataSetMateraArredamentiTableAdapters.NewsLetterTableAdapter taNewsLetter = new DataSetMateraArredamentiTableAdapters.NewsLetterTableAdapter();
      DataTable dtNewsLetter = taNewsLetter.GetEmail(mail);
      if (dtNewsLetter.Rows.Count > 0)
      {
        taNewsLetter.Delete(mail);
        lblNewslOK.Text = "La cancellazione dal nostro servizio Newsletter è avvenuta con successo.";
        notificationSucc.Visible = true;
        notificationpnl.Visible = false;
        CheckBoxcons.Checked = false;
      }
      else
      { //
        lblErr.Text = "Attenzione: l'indirizzo e-mail inserito non è presente nei nostri archivi.";
        notificationpnl.Visible = true;
        notificationSucc.Visible = false;
        CheckBoxcons.Checked = false;
      }
    }
    else
    {
      //l'email non ha un formato valido
      lblErr.Text = "l'email inserita non ha un formato valido. (es. user@host.it)";
      notificationpnl.Visible = true;
      notificationSucc.Visible = false;
    }
  }
}
