using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNet.FriendlyUrls;
public partial class BlogPost : BaseBlogPage
{
  protected void Page_Load(object sender, EventArgs e)
  {

    var idEvento = Request.GetFriendlyUrlSegments()[0];
    Session["BlogPostID"] = idEvento;
    if (!string.IsNullOrEmpty(idEvento))
    {
      ltrSocial.Text = Utility.ReadTemplateFromFile("pathSocial");
      var taArticoli = new DataSetMateraArredamentiTableAdapters.NewsTableAdapter();
      DataTable dtArticolo = taArticoli.GetDataByID(int.Parse(idEvento));
      var blogPostHtmlDocument = Server.MapPath(string.Format("~/public/HTML_Articoli/MateraArredamentiBlogPost_{0}.html", dtArticolo.Rows[0]["News_ID"]));
      try
      {
        CreatePrintableHtml(blogPostHtmlDocument, dtArticolo.Rows[0]);

        var fbMetaTagsTemplate = ReadTemplateFromFile("template_tagFb.htm");
        if (string.IsNullOrEmpty(fbMetaTagsTemplate)) return;
        var randomVignette = Utility.GetRandomImages(Server.MapPath("~/img/outlet/"));
        var imagePath = string.Format("{0}img/outlet/{1}", Url, Path.GetFileName(randomVignette.FirstOrDefault()));
        CreateFacebookMetaTags(fbMetaTagsTemplate, imagePath, Url);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    Session["AlbumID"] = 0;
    try
    {
      var taAlbums = new DataSetMateraArredamentiTableAdapters.AlbumsTableAdapter();
      DataTable dtAlbumID = taAlbums.GetIdAlbum(int.Parse(idEvento));
      if (dtAlbumID.Rows.Count > 0) Session["AlbumID"] = int.Parse(dtAlbumID.Rows[0][0].ToString());
    }
    catch (Exception)
    {
    }
  }

  public string GetPrintUrl(string blogPostId)
  {
    return string.Format("{0}/public/html_articolo_{1}", Request.Url.GetLeftPart(UriPartial.Authority), blogPostId);
  }

  private static void CreatePrintableHtml(string blogPostHtmlDocument, DataRow drBlogPost)
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

  protected void CreatePDF(object sender, EventArgs e)
  {
    var dvBlogPost = (DataView)objPost.Select();
    if (dvBlogPost == null) return;
    var dtBlogPost = dvBlogPost.ToTable();

    var document = new Document(PageSize.A4);
    document.AddAuthor("Giovanni Matera");
    document.AddSubject("Ricerca e formazione");
    var sPDF = Server.MapPath("~/public/PDF_Articoli/pdf_articolo_" + dtBlogPost.Rows[0]["News_ID"].ToString() + ".pdf");//articolo in pdf mod il path
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
      document.Add(new Phrase(dtBlogPost.Rows[0]["Titolo"] + "\n\n", new Font(Font.TIMES_ROMAN, 10, Font.BOLD, Color.RED)));
      var decodedBlogPostText = DecodeBlogPostText(dtBlogPost.Rows[0]["Testo"].ToString());
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
      var headerAttFileName = "attachment; filename=" + "BlogMateraArredamenti_" + dtBlogPost.Rows[0]["News_ID"] + ".pdf";
      Response.AppendHeader("Content-Disposition", headerAttFileName);
      Response.Flush();
      Response.WriteFile(Server.MapPath("~/public/PDF_Articoli/pdf_articolo_" + dtBlogPost.Rows[0]["News_ID"] + ".pdf"));
      try
      {
        //Trappo il solito errore del response.end
        Response.End();
      }
      catch
      { }
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
