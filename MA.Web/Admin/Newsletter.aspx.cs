using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using System.IO;
//using FileHelpers.RunTime;
//using FileHelpers;
public partial class Admin_ManageLinks : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      //carico il template
      FCKeditor1.Value = readTemplateFromFile("template_matera.html");

    }
  }

  static string readTemplateFromFile(string templateType)
  {
    string fileName = HttpContext.Current.Server.MapPath("~\\public\\" + templateType);
    string output = "";
    if (!File.Exists(fileName))
      return output;
    StreamReader stFile = File.OpenText(fileName);
    output = stFile.ReadToEnd();
    stFile.Close();
    return output;
  }

  static string saveTemplateToFile(string templateType, string template_content)
  {
    string fileName = HttpContext.Current.Server.MapPath("~\\public\\" + templateType);
    string output = "";
    if (!File.Exists(fileName))
      return output;
    File.WriteAllText(fileName, template_content);
    return output;
  }

  protected void _OnCreated(object sender, ListViewItemEventArgs e)
  {
  }

  protected void _OnItemCommand(object sender, ListViewCommandEventArgs e)
  {
    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
    string mailID = ListViewMail.DataKeys[dataItem.DisplayIndex].Value.ToString();
    if (e.CommandName == "cancella")
    {
      DivSuccess.Visible = false;
      DivError.Visible = false;
      DataSetVepAdminTableAdapters.NewsLetterTableAdapter taNl = new DataSetVepAdminTableAdapters.NewsLetterTableAdapter();
      taNl.DeletebyId(int.Parse(mailID));
      ListViewMail.DataBind();
    }
    else if (e.CommandName == "modifica")
    {
      DivSuccess.Visible = false;
      DivError.Visible = false;
      DataSetVepAdminTableAdapters.NewsLetterTableAdapter taNl = new DataSetVepAdminTableAdapters.NewsLetterTableAdapter();
      DataTable dtMail = taNl.GetDataById(int.Parse(mailID));
      txtEmail.Text = dtMail.Rows[0]["email"].ToString();
      ButtonAgg.Visible = true;
      ButtonInsert.Visible = false;
      hdnmailID.Value = mailID;
    }
  }

  protected void ButtonAnnulla_Click(object sender, EventArgs e)
  {
  }

  protected void ButtonInsert_Click(object sender, EventArgs e)
  {
    DataSetVepAdminTableAdapters.NewsLetterTableAdapter taNewsletter = new DataSetVepAdminTableAdapters.NewsLetterTableAdapter();
    if (!Utility.emailValida(txtEmail.Text))
    {
      LabelError.Text = "Wrong format. [accepted: mail@host.it].";
      DivSuccess.Visible = false;
      DivError.Visible = true;
    }
    else
    {
      taNewsletter.Insert(txtEmail.Text);
      txtEmail.Text = "";
      LabelSuccess.Text = "e-mail added to archive.";
      DivSuccess.Visible = true;
      DivError.Visible = false;
      ListViewMail.DataBind();
    }
  }

  protected void ButtonAgg_Click(object sender, EventArgs e)
  {
    DataSetVepAdminTableAdapters.NewsLetterTableAdapter taNewsletter = new DataSetVepAdminTableAdapters.NewsLetterTableAdapter();
    // faccio l'update!
    taNewsletter.Update(txtEmail.Text, int.Parse(hdnmailID.Value));
    txtEmail.Text = "";
    ButtonAgg.Visible = false;
    LabelSuccess.Text = "Update Success.";
    ButtonInsert.Visible = true;
    DivSuccess.Visible = true;
    DivError.Visible = false;
    ListViewMail.DataBind();
    //updpnlListaProg.Update();
  }

  protected void ButtonInviaNl_Click(object sender, EventArgs e)
  {
    if (!string.IsNullOrEmpty(FCKeditor1.Value))
    {
      try
      {
        MailAddress from = new MailAddress("web@materarredamenti.it", "Matera Arredamenti");
        MailAddress to = new MailAddress("info@materarredamenti.it", "test invio");
        MailMessage EMAIL = new MailMessage(from, to);
        EMAIL.Subject = "Newsletter Matera Arredamenti";
        EMAIL.IsBodyHtml = true;
        EMAIL.Body = FCKeditor1.Value;

        DataSetVepAdminTableAdapters.NewsLetterTableAdapter taNewsLett = new DataSetVepAdminTableAdapters.NewsLetterTableAdapter();
        DataTable dtNewsLetter = taNewsLett.GetListaMailNewsLetter();
        int numDestinatari = 0;
        int sent = 0;
        if (dtNewsLetter.Rows.Count > 0)
        {
          for (numDestinatari = 0; numDestinatari < dtNewsLetter.Rows.Count; numDestinatari++)
          {
            try
            {
              EMAIL.Bcc.Add(dtNewsLetter.Rows[numDestinatari][0].ToString());
            }
            catch (Exception ex) { }
            // sarà inviata la newsletter a i destinatari
            SmtpClient SmtpMail = new SmtpClient();
            try
            {
              SmtpMail.Send(EMAIL);
              sent++;
            }
            catch (Exception ex)
            {
            }
            //invio OK
          }
          LabelSuccess.Text = "Newsletter sended to " + sent + " users.";
          DivSuccess.Visible = true;
          DivError.Visible = false;
        }
        else
        {
          //errore nessun destinatario presente

          LabelError.Text = "Error: no users in archive. ";
          DivError.Visible = true;
          DivSuccess.Visible = false;
        }
      }
      catch (Exception Ex)
      {
        LabelError.Text = Ex.Message;
        DivError.Visible = true;
        DivSuccess.Visible = false;
      }
    }
    else
    {
      LabelError.Text = "Empty message.";
      DivError.Visible = true;
      DivSuccess.Visible = false;
    }
  }

  protected void gotosliderPage(object sender, EventArgs e)
  {
  }

  protected void ButtonSave_template(object sender, EventArgs e)
  {
    saveTemplateToFile("template_matera.html", FCKeditor1.Value);
  }
}
