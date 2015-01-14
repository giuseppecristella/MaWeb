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

    var blogPostId = Request.GetFriendlyUrlSegments()[0];
    Session["BlogPostID"] = blogPostId;
    if (!string.IsNullOrEmpty(blogPostId))
    {
      ltrSocial.Text = Utility.ReadTemplateFromFile("pathSocial");
      var taArticoli = new DataSetMateraArredamentiTableAdapters.NewsTableAdapter();
      DataTable dtArticolo = taArticoli.GetDataByID(int.Parse(blogPostId));
      var blogPostHtmlDocument = Server.MapPath(string.Format("~/public/HTML_Articoli/MateraArredamentiBlogPost_{0}.html", dtArticolo.Rows[0]["News_ID"]));
      try
      {
        CreatePrintableHtml(blogPostHtmlDocument, dtArticolo.Rows[0]);

        var fbMetaTagsTemplate = ReadTemplateFromFile("template_tagFb.htm");
        if (string.IsNullOrEmpty(fbMetaTagsTemplate)) return;
        var randomVignette = Utility.GetRandomImages(Server.MapPath("~/img/outlet/"));
        var imagePath = string.Format("{0}img/outlet/{1}", Url, Path.GetFileName(randomVignette.FirstOrDefault()));
        CreateFacebookMetaTags(fbMetaTagsTemplate, imagePath, String.Format("{0}BlogPost/{1}/{2}", Url, dtArticolo.Rows[0]["News_ID"], dtArticolo.Rows[0]["Titolo"]));
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
      DataTable dtAlbumID = taAlbums.GetIdAlbum(int.Parse(blogPostId));
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

  protected void CreatePDF(object sender, EventArgs e)
  {
    var dvBlogPost = (DataView)objPost.Select();
    if (dvBlogPost == null) return;
    var dtBlogPost = dvBlogPost.ToTable();

    PdfExport(dtBlogPost.Rows[0]);
  }


  
}
