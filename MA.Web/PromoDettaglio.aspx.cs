using System;
using System.Data;
using System.Web;
using System.IO;

public partial class PromoDettaglio : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ltrSocial.Text = Utility.readTemplateFromFile("pathSocial");
    string id = Request.QueryString["Id"];
    DataSetVepAdminTableAdapters.NewsTableAdapter taN = new DataSetVepAdminTableAdapters.NewsTableAdapter();
    DataTable dtArticolo = taN.GetDataByID(int.Parse(id));
    string url = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
    string imagePath = url + dtArticolo.Rows[0]["UrlFotoHome"];
    string templateHtml = readTemplateFromFile("template_tagFb.htm");
    string replaceImage_p = templateHtml.Replace("##image##", imagePath);
    string replaceUrl_p = replaceImage_p.Replace("##url##", url + "PromoDettaglio.aspx?Id=" + dtArticolo.Rows[0]["News_ID"].ToString());
    string replaceTitle_p = replaceUrl_p.Replace("##titolo##", dtArticolo.Rows[0]["Titolo"].ToString());
    string replaceDesc_p = replaceTitle_p.Replace("##caption##", Utility.ShortDesc(Utility.cleanTagFromString(dtArticolo.Rows[0]["Testo"].ToString()), 200));
    Session["metatagFB"] = replaceDesc_p;
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
}
