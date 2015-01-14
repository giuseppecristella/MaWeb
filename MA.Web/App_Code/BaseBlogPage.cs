using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

/// <summary>
/// Summary description for BaseBlogPage
/// </summary>
public class BaseBlogPage : System.Web.UI.Page
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
      return string.Format("{0}{1}", Request.Url.GetLeftPart(UriPartial.Authority), VirtualPathUtility.ToAbsolute("~/"));
    }
  }

  protected static string ReadTemplateFromFile(string _filename)
  {
    var fileName = HttpContext.Current.Server.MapPath("~\\public\\templates\\" + _filename);
    var output = string.Empty;
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
      .Replace("##url##", string.Format("{0}Blog.html", url))
      .Replace("##titolo##", titolo.ToString())
      .Replace("##caption##", description.ToString());
  }

}