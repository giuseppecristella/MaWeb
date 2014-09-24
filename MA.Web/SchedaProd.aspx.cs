using System;
using System.Data;
using System.Net.Mail;
public partial class SchedaProd : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    string idProdotto = Request.QueryString["IdProdotto"];
    if (idProdotto != null)
    {
      DataSetMateraArredamentiTableAdapters.OutletTableAdapter taOutlet = new DataSetMateraArredamentiTableAdapters.OutletTableAdapter();
      DataTable dtOutlet = taOutlet.GetDataByID(int.Parse(idProdotto));
      fotoProdotto.ImageUrl = dtOutlet.Rows[0]["ProdottoFoto"].ToString();
      lblModello.Text = dtOutlet.Rows[0]["ProdottoNome"].ToString();
      lblDesc.Text = dtOutlet.Rows[0]["ProdottoDescScheda"].ToString();
      lblListino.Text = dtOutlet.Rows[0]["ProdottoPrezzo"].ToString();
      lblSconto.Text = dtOutlet.Rows[0]["ProdottoPrezzoSconto"].ToString();
    }
  }

  protected void inviaMailInfo(object sender, EventArgs e)
  {
    if (!string.IsNullOrEmpty(txtNome.Text))
    {
      if (!string.IsNullOrEmpty(txtCognoome.Text))
      {
        if (!string.IsNullOrEmpty(txtTel.Text))
        {
          if (!string.IsNullOrEmpty(txtMail.Text))
          {
            if (chkPrivacy.Checked)
            {
              if (Utility.emailValida(txtMail.Text))
              {
                string idProdotto = Request.QueryString["IdProdotto"];
                DataSetMateraArredamentiTableAdapters.OutletTableAdapter taOutlet = new DataSetMateraArredamentiTableAdapters.OutletTableAdapter();
                DataTable dtOutlet = taOutlet.GetDataByID(int.Parse(idProdotto));
                try
                {
                  MailAddress from = new MailAddress(txtMail.Text, txtNome.Text + " " + txtCognoome.Text);
                  MailAddress to = new MailAddress("info@materarredamenti.it", "materarredamenti.it");
                  MailMessage EMAIL = new MailMessage(from, to);
                  EMAIL.Subject = "richiesta info prodotto outlet: " + dtOutlet.Rows[0]["ProdottoNome"].ToString(); ;
                  EMAIL.IsBodyHtml = true;
                  EMAIL.Body = "richiesta info prodotto outlet: " + dtOutlet.Rows[0]["ProdottoNome"].ToString() + "<br>inviata da: " + txtNome.Text + " " + txtCognoome.Text + "<br> tel: " + txtTel.Text;
                  EMAIL.Bcc.Add("verduga80@libero.it");
                  SmtpClient SmtpMail = new SmtpClient();
                  SmtpMail.Send(EMAIL);
                  // invio OK!!
                  //lblInvioOK.Text = "Il messaggio è stato inviato con successo.";
                  //notificationErr.Visible = false;
                  //notificationSucc.Visible = true;
                  //Archivio i dati dell'utente
                  try
                  {
                    DataSetMateraArredamentiTableAdapters.UtentiOutletTableAdapter taUtentiOutlet = new DataSetMateraArredamentiTableAdapters.UtentiOutletTableAdapter();
                    DataTable dtUtentiOutlet = taUtentiOutlet.GetDataByMail(txtMail.Text);
                    if (dtUtentiOutlet.Rows.Count == 0)
                    {
                      taUtentiOutlet.Insert(txtNome.Text, txtCognoome.Text, txtMail.Text, txtTel.Text);
                    }
                  }
                  catch (Exception ex)
                  {
                  }
                  txtTel.Text = "";
                  txtNome.Text = "";
                  txtCognoome.Text = "";
                  txtMail.Text = "";
                  chkPrivacy.Checked = false;
                  lblErrore.Visible = false;
                  lblSuccess.Visible = true;
                  lblSuccess.Text = "Invio richiesta info prodotto avvenuto con successo.";
                }
                catch (Exception Ex)
                {
                  lblSuccess.Visible = false;
                  lblErrore.Visible = true;
                  lblErrore.Text = Ex.Message;
                }
              }
              else
              {
                lblSuccess.Visible = false;
                lblErrore.Visible = true;
                lblErrore.Text = "Attenzione: l'indirizzo e-mail inserito non rispetta il formato corretto. Es. nome@host.it";
              }
            }
            else
            {
              lblSuccess.Visible = false;
              lblErrore.Visible = true;
              lblErrore.Text = "Attenzione: è necessario dare il consenso Privacy.";
            }
          }
          else
          {
            lblSuccess.Visible = false;
            lblErrore.Visible = true;
            lblErrore.Text = "Attenzione: è necessario compilare tutti i campi.";
          }
        }
        else
        {
          lblSuccess.Visible = false;
          lblErrore.Visible = true;
          lblErrore.Text = "Attenzione: è necessario compilare tutti i campi.";
        }
      }
      else
      {
        lblSuccess.Visible = false;
        lblErrore.Visible = true;
        lblErrore.Text = "Attenzione: è necessario compilare tutti i campi.";
      }
    }
    else
    {
      lblSuccess.Visible = false;
      lblErrore.Visible = true;
      lblErrore.Text = "Attenzione: è necessario compilare tutti i campi.";
    }
  }
}
