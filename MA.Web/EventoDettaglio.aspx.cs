using System;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class EventoDettaglio : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    //QueryStringField="Evento"
    string idEvento = Request.QueryString["Id"];
    if (!string.IsNullOrEmpty(idEvento))
    {
      DataSetVepAdminTableAdapters.NewsTableAdapter taArticoli = new DataSetVepAdminTableAdapters.NewsTableAdapter();
      DataTable dtArticolo = taArticoli.GetDataByID(int.Parse(idEvento));
      string sHTML = Server.MapPath("public/html_articolo_" + dtArticolo.Rows[0]["News_ID"].ToString() + ".html");//articolo in html mod il path
      try
      {
        ltrSocial.Text = Utility.readTemplateFromFile("pathSocial");
        string url = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");//Page.Request.Url.ToString();
        string imagePath = url + dtArticolo.Rows[0]["UrlFotoHome"];// "img/logo_w.png";
        //BlogPost.aspx?Id
        string templateHtml = readTemplateFromFile("template_tagFb.htm");
        string replaceImage_p = templateHtml.Replace("##image##", imagePath);
        string replaceUrl_p = replaceImage_p.Replace("##url##", url + "EventoDettaglio.aspx?Id=" + dtArticolo.Rows[0]["News_ID"].ToString());
        string replaceTitle_p = replaceUrl_p.Replace("##titolo##", dtArticolo.Rows[0]["Titolo"].ToString());
        string replaceDesc_p = replaceTitle_p.Replace("##caption##", Utility.ShortDesc(Utility.cleanTagFromString(dtArticolo.Rows[0]["Testo"].ToString()), 200));
        Session["metatagFB"] = replaceDesc_p;
        Encoding myEnconding = Encoding.GetEncoding(1252);
        StreamWriter sWriter = new StreamWriter(sHTML, false, Encoding.UTF8);
        sWriter.Write("<html style='background:#fff;padding-left:0px;margin-left:10px;'>");
        sWriter.Write("<body style='margin-left:15px;margin-top:10px;'>");
        sWriter.Write("<b style='color:#bf0000;font-size:1.2em;'>" + dtArticolo.Rows[0]["Titolo"].ToString() + "</b></br></br>");
        sWriter.Write("a cura di <b>" + dtArticolo.Rows[0]["Autore"].ToString() + "</b></br></br>");
        sWriter.Write("<div style='width:530px;text-align:justify;'>");
        sWriter.Write(dtArticolo.Rows[0]["Testo"].ToString());
        sWriter.Write("</div>");
        sWriter.Write("</br></br><input id='stampa' type='button' value='stampa' style='text-align:center' onclick='window.print();' />");
        sWriter.Write("</body>");
        sWriter.Write("</html>");
        sWriter.Close();
        sWriter.Dispose();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    Session["AlbumID"] = 0;
    try
    {
      DataSetMateraArredamentiTableAdapters.AlbumsTableAdapter taAlbums = new DataSetMateraArredamentiTableAdapters.AlbumsTableAdapter();
      DataTable dtAlbumID = taAlbums.GetIdAlbum(int.Parse(idEvento));
      Session["AlbumID"] = int.Parse(dtAlbumID.Rows[0][0].ToString());
    }
    catch (Exception)
    {
    }
  }

  public string readTemplateFromFile(string _filename)
  {
    string fileName = HttpContext.Current.Server.MapPath("~\\public\\templates\\" + _filename);
    string output = "";
    if (!File.Exists(fileName))
      return output;
    StreamReader stFile = File.OpenText(fileName);
    output = stFile.ReadToEnd();
    stFile.Close();
    return output;
  }

  protected void CreaPdf(object sender, EventArgs e)
  {
    DataView dvArticolo = (DataView)objPost.Select();
    DataTable dtArticolo = dvArticolo.ToTable();
    // Document document = new Document(PageSize.A4, 80, 50, 30, 65);
    Document document = new Document(PageSize.A4);
    document.AddAuthor("Giovanni Matera");
    document.AddSubject("Ricerca e formazione");
    //string sHTML = Server.MapPath("public/html_articolo_"+dtArticolo.Rows[0]["News_ID"].ToString()+".html");//articolo in html mod il path
    string sPDF = Server.MapPath("public/pdf_articolo_" + dtArticolo.Rows[0]["News_ID"].ToString() + ".pdf");//articolo in pdf mod il path
    try
    {
      Encoding myEnconding = Encoding.GetEncoding(1252);
      PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sPDF, FileMode.Create));
      document.Open();
      string html = dtArticolo.Rows[0]["Testo"].ToString();
      string decodedHtml = Server.HtmlDecode(html);
      //HtmlParser.Parse(document, decodedHtml);
      decodedHtml = decodedHtml.Replace("<br />", "");
      decodedHtml = decodedHtml.Replace("<strong>", "");
      decodedHtml = decodedHtml.Replace("</strong>", "");
      decodedHtml = decodedHtml.Replace("<em>", "");
      decodedHtml = decodedHtml.Replace("</em>", "");
      iTextSharp.text.Image marchio = iTextSharp.text.Image.GetInstance(Server.MapPath("img/MARCHIO Ridotto.jpg"));
      marchio.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
      marchio.ScalePercent(40);
      document.Add(marchio);
      Phrase ricerca = new Phrase("\n\nRicerca e Formazione ", new Font(Font.TIMES_ROMAN, 14, Font.BOLD, Color.RED));
      document.Add(ricerca);
      Phrase acura = new Phrase("a cura di Giovanni Matera\n\n", new Font(Font.TIMES_ROMAN, 12, Font.NORMAL));
      document.Add(acura);
      Phrase titolo = new Phrase(dtArticolo.Rows[0]["Titolo"].ToString() + "\n\n", new Font(Font.TIMES_ROMAN, 10, Font.BOLD, Color.RED));
      document.Add(titolo);
      Phrase myPhrase = new Phrase(decodedHtml, new Font(Font.TIMES_ROMAN, 8, Font.NORMAL));
      document.Add(myPhrase);
      Phrase firma = new Phrase("\n\n Giovanni Matera", new Font(Font.TIMES_ROMAN, 10, Font.BOLD, Color.BLACK));
      document.Add(firma);
      Phrase footer = new Phrase("\n\n www.materarredamenti.it", new Font(Font.TIMES_ROMAN, 7, Font.NORMAL, Color.RED));
      document.Add(footer);
      document.Close();
    }
    catch (Exception ex)
    {
      throw ex;
    }
    finally
    {
      Response.Write(Server.MapPath("pdffilename.pdf"));
      Response.ClearContent();
      Response.BufferOutput = true;
      Response.Clear();
      Response.ContentType = "application/pdf";
      string headerAttFileName = "attachment; filename=" + "pdf_articolo_" + dtArticolo.Rows[0]["News_ID"].ToString() + ".pdf";
      Response.AppendHeader("Content-Disposition", headerAttFileName);
      Response.Flush();
      Response.WriteFile(Server.MapPath("public/pdf_articolo_" + dtArticolo.Rows[0]["News_ID"].ToString() + ".pdf"));
      Response.End();
    }
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
