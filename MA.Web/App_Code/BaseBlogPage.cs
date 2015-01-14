using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;

/// <summary>
/// Summary description for BaseBlogPage
/// </summary>
public class BaseBlogPage : Page
{
	public BaseBlogPage()
	{
		//
		// TODO: Add constructor logic here
		//
	}

  public string Url
  {
    get
    {
      return String.Format("{0}{1}", Request.Url.GetLeftPart(UriPartial.Authority), VirtualPathUtility.ToAbsolute("~/"));
    }
  }

  protected static string ReadTemplateFromFile(string _filename)
  {
    var fileName = HttpContext.Current.Server.MapPath("~\\public\\templates\\" + _filename);
    var output = String.Empty;
    if (!File.Exists(fileName)) return output;
    using (var stFile = File.OpenText(fileName))
    {
      output = stFile.ReadToEnd();
      stFile.Close();
    }
    return output;
  }

  protected void CreateFacebookMetaTags(string fbMetaTagsTemplate, string imagePath, string url)
  {
    // <asp:Label ID="Label1" runat="server" Text="<%$ Resources:resxFile,message %>" 
    var description = GetGlobalResourceObject("Resource", "MetaTagFB_Description");
    if (description == null) return;
    var titolo = GetGlobalResourceObject("Resource", "MetaTagFB_Titolo");
    if (titolo == null) return;
    Session["metatagFB"] = fbMetaTagsTemplate.Replace("##image##", imagePath)
      .Replace("##url##", url)
      .Replace("##titolo##", titolo.ToString())
      .Replace("##caption##", description.ToString());
  }

  protected static void CreatePrintableHtml(string blogPostHtmlDocument, DataRow drBlogPost)
  {
    using (var sWriter = new StreamWriter(blogPostHtmlDocument, false, Encoding.UTF8))
    {
      sWriter.Write("<html style='background:#fff;padding-left:0px;margin-left:10px;'><body style='margin-left:15px;margin-top:10px;'>");
      sWriter.Write("<b style='color:#bf0000;font-size:1.2em;'>{0}</b></br></br>", drBlogPost["Titolo"]);
      sWriter.Write("a cura di <b>Giovanni Matera</b></br></br><div style='width:530px;text-align:justify;'>");
      sWriter.Write(drBlogPost["Testo"].ToString());
      sWriter.Write("</div>");
      sWriter.Write("</br></br><input id='stampa' type='button' value='stampa' style='text-align:center' onclick='window.print();' /></body></html>");
      sWriter.Close();
      sWriter.Dispose();
    }
  }

  protected void PdfExport(DataRow drBlogPost)
  {
    var document = new Document(PageSize.A4);
    document.AddAuthor("Giovanni Matera");
    document.AddSubject("Ricerca e formazione");
    var sPDF = Server.MapPath("~/public/PDF_Articoli/pdf_articolo_" + drBlogPost["News_ID"] + ".pdf");
    //articolo in pdf mod il path
    try
    {
      PdfWriter.GetInstance(document, new FileStream(sPDF, FileMode.Create));
      document.Open();

      var logoImage = Image.GetInstance(Server.MapPath("~/img/logo_w.png"));
      logoImage.Alignment = Element.ALIGN_LEFT;
      logoImage.ScalePercent(40);
      document.Add(logoImage);

      document.Add(new Phrase("\n\nRicerca e Formazione ", new Font(Font.TIMES_ROMAN, 14, Font.BOLD, Color.RED)));
      document.Add(new Phrase("a cura di Giovanni Matera\n\n", new Font(Font.TIMES_ROMAN, 12, Font.NORMAL)));
      document.Add(new Phrase(drBlogPost["Titolo"] + "\n\n", new Font(Font.TIMES_ROMAN, 10, Font.BOLD, Color.RED)));
      var decodedBlogPostText = DecodeBlogPostText(drBlogPost["Testo"].ToString());
      document.Add(new Phrase(decodedBlogPostText, new Font(Font.TIMES_ROMAN, 8, Font.NORMAL)));
      document.Add(new Phrase("\n\n Giovanni Matera", new Font(Font.TIMES_ROMAN, 10, Font.BOLD, Color.BLACK)));
      document.Add(new Phrase("\n\n www.materarredamenti.it", new Font(Font.TIMES_ROMAN, 7, Font.NORMAL, Color.RED)));
      document.Close();
    }
    catch (Exception ex)
    {
      // Log Exception
    }
    finally
    {
      Response.Write(Server.MapPath("pdffilename.pdf"));
      Response.ClearContent();
      Response.BufferOutput = true;
      Response.Clear();
      Response.ContentType = "application/pdf";
      var headerAttFileName = "attachment; filename=" + "BlogMateraArredamenti_" + drBlogPost["News_ID"] + ".pdf";
      Response.AppendHeader("Content-Disposition", headerAttFileName);
      Response.Flush();
      Response.WriteFile(Server.MapPath("~/public/PDF_Articoli/pdf_articolo_" + drBlogPost["News_ID"] + ".pdf"));
      try
      {
        //Trappo il solito errore del response.end
        Response.End();
      }
      catch
      {
      }
    }
  }

  private string DecodeBlogPostText(string blogPostText)
  {
    return Server.HtmlDecode(blogPostText)
      .Replace("<br />", string.Empty)
      .Replace("<strong>", string.Empty)
      .Replace("</strong>", string.Empty)
      .Replace("<em>", string.Empty)
      .Replace("</em>", string.Empty);
  }
}