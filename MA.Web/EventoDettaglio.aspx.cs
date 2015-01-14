using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNet.FriendlyUrls;

public partial class EventoDettaglio : BaseBlogPage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    var eventId = Request.GetFriendlyUrlSegments()[0];
    Session["BlogPostID"] = eventId;

    if (string.IsNullOrEmpty(eventId)) return;

    var taArticoli = new DataSetVepAdminTableAdapters.NewsTableAdapter();
    DataTable dtArticolo = taArticoli.GetDataByID(int.Parse(eventId));
    var eventsHtmlDocument = Server.MapPath("public/html_articolo_" + dtArticolo.Rows[0]["News_ID"] + ".html");
    try
    {
      ltrSocial.Text = Utility.ReadTemplateFromFile("pathSocial");
      var fbMetaTagsTemplate = ReadTemplateFromFile("template_tagFb.htm");
      if (string.IsNullOrEmpty(fbMetaTagsTemplate)) return;
      var randomVignette = Utility.GetRandomImages(Server.MapPath("~/img/outlet/"));
      var imagePath = string.Format("{0}img/outlet/{1}", Url, Path.GetFileName(randomVignette.FirstOrDefault()));
      CreateFacebookMetaTags(fbMetaTagsTemplate, imagePath,
        String.Format("{0}EventoDettaglio/{1}/{2}", Url, dtArticolo.Rows[0]["News_ID"], dtArticolo.Rows[0]["Titolo"]));

      CreatePrintableHtml(eventsHtmlDocument, dtArticolo.Rows[0]);
    }
    catch (Exception ex)
    {
      throw ex;
    }
    Session["AlbumID"] = 0;
    try
    {
      var taAlbums = new DataSetMateraArredamentiTableAdapters.AlbumsTableAdapter();
      DataTable dtAlbumID = taAlbums.GetIdAlbum(int.Parse(eventId));
      if (dtAlbumID.Rows.Count > 0) Session["AlbumID"] = int.Parse(dtAlbumID.Rows[0][0].ToString());
    }
    catch (Exception)
    {
    }
  }


  protected void CreaPdf(object sender, EventArgs e)
  {
    var dvEventDetail = (DataView)objPost.Select();
    if (dvEventDetail == null) return;
    var dtEventDetail = dvEventDetail.ToTable();

    PdfExport(dtEventDetail.Rows[0]);
  }

  protected void isPagerVis(object sender, EventArgs e)
  {
    bool isVis = Utility.IsPagerVisible(pagerEventi, objPostList);
    pagerEventi.Visible = isVis;
  }

  protected void isPagerVisGallery(object sender, EventArgs e)
  {
    bool isVis = Utility.IsPagerVisible(dpGallery, objGallery);
    dpGallery.Visible = isVis;
  }
  private int i = 6;
  protected void _itemCreated(object sender, ListViewItemEventArgs e)
  {
    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
    int index = dataItem.DisplayIndex;
    HtmlGenericControl liGallery = (HtmlGenericControl)dataItem.FindControl("liGallery");
    if (index + 1 == i)
    {
      liGallery.Attributes["style"] = "margin-right:0px;";
      i += 6;
    }
  }
}
