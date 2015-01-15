using System;
using System.Net.Mail;

public partial class mobile_Contatti : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void IsPagerVisible(object sender, EventArgs e)
    {


        //pagerEventi.Visible =
        //Utility.IsPagerVisible(pagerEventi, objEventi);
    }


    protected void btnInvioMail_Click(object sender, EventArgs e)
    {

        if (Helper.IsValidMailAddress(email.Text))
        {
            try
            {
                MailAddress from = new MailAddress(email.Text, name.Text);

                MailAddress to = new MailAddress("info@materarredamenti.it", "materarredamenti.it");
                MailMessage EMAIL = new MailMessage(from, to);
                EMAIL.Subject = oggetto.Text;
                EMAIL.IsBodyHtml = true;
                EMAIL.Body = messaggio.Text;

                EMAIL.Bcc.Add("verduga80@libero.it");


                SmtpClient SmtpMail = new SmtpClient();
                SmtpMail.Send(EMAIL);

                // invio OK!!

                lblInvioOK.Text = "Il messaggio è stato inviato con successo.";
              //  notificationErr.Visible = false;
                //notificationSucc.Visible = true;

                email.Text = "";
                oggetto.Text = "";
                name.Text = "";
                messaggio.Text = "";

            }
            catch (Exception Ex)
            {

                lblErr.Text = Ex.Message;
              //  notificationErr.Visible = true;
                //notificationSucc.Visible = false;
            }

        }
        else
        {
            // formato email non valido
            lblErr.Text = "Attenzione: l'indirizzo e-mail inserito non rispetta il formato corretto. </br>Verificare che sia stato digitato correttamente es. nome@host.it";
           // notificationErr.Visible = true;
            //notificationSucc.Visible = false;
        }




    }
}
