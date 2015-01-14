using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Xml;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using log4net;
using Facebook;
using System.Reflection;
using System.IO;
/// <summary>
/// Descrizione di riepilogo per Utility
/// </summary>
public static class Utility
{
  public static void writeXmlRewriterRules(string aspxPage, string queryStringName, string queryStringId1, string name, string path)
  {
    name = name.Replace("%", "").Replace("?", "").Replace(" ", "-");
    string xmlFileName = HttpContext.Current.Server.MapPath("~/RewriterConfig.xml");
    XmlDocument _docFromFile = new XmlDocument();
    XmlDocument _doc = new XmlDocument();
    //apro il file se non ce l'ho già in cache 
    if (HttpContext.Current.Cache["RewriterConfigXmlDoc"] == null)
    {
      _docFromFile.Load(xmlFileName);
      HttpContext.Current.Cache.Insert("RewriterConfigXmlDoc", _docFromFile);
    }
    _doc = (XmlDocument)HttpContext.Current.Cache["RewriterConfigXmlDoc"];
    /*controllo se esiste la regola*/
    XPathNavigator xNav = _doc.CreateNavigator();
    XPathNodeIterator xPathLookFor = xNav.Select("//RewriterConfig//Rules//RewriterRule//LookFor");
    XPathNodeIterator xPathSendTo = xNav.Select("//RewriterConfig//Rules//RewriterRule//SendTo");
    XPathNodeIterator xPathRewriterRule = xNav.Select("//RewriterConfig//Rules//RewriterRule");
    bool exist = false;
    while (xPathLookFor.MoveNext() && xPathSendTo.MoveNext() && xPathRewriterRule.MoveNext())
    {
      if (xPathSendTo.Current.Value == "~/" + aspxPage + ".aspx?" + queryStringName + "=" + queryStringId1)
      {
        xPathLookFor.Current.DeleteSelf();
        xPathSendTo.Current.DeleteSelf();
        xPathRewriterRule.Current.DeleteSelf();
      }
    }
    if (!exist)
    {
      //RewriterRule
      //Rules
      XmlNode nodeRewriterRule = _doc.CreateNode(XmlNodeType.Element, "RewriterRule", null);
      // XmlNode nodeRules = _doc.ReadNode(XmlReader)
      XmlNode nodeLookFor = _doc.CreateNode(XmlNodeType.Element, "LookFor", null);
      XmlNode nodeSendTo = _doc.CreateNode(XmlNodeType.Element, "SendTo", null);
      // nodeLookFor.InnerText = "~/" + name + ".html";
      if (String.IsNullOrEmpty(path))
        nodeLookFor.InnerText = "~/" + name + ".html";
      else
        nodeLookFor.InnerText = "~/" + path + "/" + name + ".html";
      nodeSendTo.InnerText = "~/" + aspxPage + ".aspx?" + queryStringName + "=" + queryStringId1;
      nodeRewriterRule.AppendChild(nodeLookFor);
      nodeRewriterRule.AppendChild(nodeSendTo);
      XmlNode nodeRules = _doc.SelectSingleNode("descendant::Rules");
      nodeRules.AppendChild(nodeRewriterRule);
      _doc.DocumentElement.AppendChild(nodeRules);
      _doc.Save(xmlFileName);
    }
  }
  public static string ReadTemplateFromFile(string html_template)
  {
    var fileName = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue(html_template));
    var output = "";
    if (!File.Exists(fileName))
      return output;
    var stFile = File.OpenText(fileName);
    output = stFile.ReadToEnd();
    stFile.Close();
    return output;
  }
  public static string showFbTitle(string _message)
  {
    if (String.IsNullOrEmpty(_message))
      return "Matera Arredamenti presenta:";
    else
      return _message;
  }
  public static DataTable youtubeToDataTable()
  {
    IEnumerable ien = ListVideos.YourVideos();
    DataTable dt = new DataTable();
    foreach (object obj in ien)
    {
      Type t = obj.GetType();
      PropertyInfo[] pis = t.GetProperties();
      if (dt.Columns.Count == 0)
      {
        foreach (PropertyInfo pi in pis)
        {
          if (pi.Name == "Thumbnails")
          {
            dt.Columns.Add(pi.Name,
                Type.GetType("System.String"));
          }
          else
            dt.Columns.Add(pi.Name, pi.PropertyType);
        }
      }
      DataRow dr = dt.NewRow();
      foreach (PropertyInfo pi in pis)
      {
        if (pi.Name != "Rating")
        {
          if (pi.Name == "Thumbnails")
          {
            object value = pi.GetValue(obj, null);
            Google.GData.Extensions.ExtensionCollection<Google.GData.Extensions.MediaRss.MediaThumbnail> thumbs =
                (Google.GData.Extensions.ExtensionCollection<Google.GData.Extensions.MediaRss.MediaThumbnail>)value;
            dr[pi.Name] = thumbs[4].Url;
          }
          else
          {
            if (pi.Name != "ResponseUri")
            {
              object value = pi.GetValue(obj, null);
              dr[pi.Name] = value;
            }
          }
        }
      }
      dt.Rows.Add(dr);
    }
    return dt;
  }
  public static string fbLikes(string idFbPage)
  {
    // Facebook.FacebookAPI api = new Facebook.FacebookAPI();
    //JSONObject profileInfo = api.Get("/" + idFbPage);
    //string likes = profileInfo.Dictionary["likes"].String;
    string likes = "2";
    return likes;
  }
  public static DataTable fbFeedsToDataTable()
  {
    //  Facebook.FacebookAPI api = new Facebook.FacebookAPI("AAABZBvUXfKBQBAE7mYf1X2ot5Q5iYHOzHQjzNQXnwHulQK4CRQBpYFszlz4ZBuychfQ5zCDxCkYMuO9MYgYx6m19v8gmH3J9DNxFXPvgZDZD");
    Facebook.FacebookAPI api = new Facebook.FacebookAPI();
    JSONObject feeds = api.Get("/matearredamenti/feed?access_token=AAABZBvUXfKBQBAE7mYf1X2ot5Q5iYHOzHQjzNQXnwHulQK4CRQBpYFszlz4ZBuychfQ5zCDxCkYMuO9MYgYx6m19v8gmH3J9DNxFXPvgZDZD");
    //	String companyOverview = codesamplezObject.Dictionary["company_overview"].String;
    //JSONObject feeds = api.Get("/me/feed");
    //  JSONObject events = api.Get("/me/events");
    DataTable dtFacebook = new DataTable();
    if (dtFacebook.Columns.Count == 0)
    {
      dtFacebook.Columns.Add("name", Type.GetType("System.String"));
      dtFacebook.Columns.Add("message", Type.GetType("System.String"));
      dtFacebook.Columns.Add("link", Type.GetType("System.String"));
      dtFacebook.Columns.Add("picture", Type.GetType("System.String"));
    }
    int numPost = feeds.Dictionary["data"].Array.GetLength(0);
    string link = "";
    string message = "";
    string picture = "";
    string name = "";
    string video_thumb = "";
    for (int i = 0; i < numPost; i++)
    {
      if (feeds.Dictionary["data"].Array[i].Dictionary.ContainsKey("name") &&
          feeds.Dictionary["data"].Array[i].Dictionary.ContainsKey("picture"))
      {
        DataRow dr = dtFacebook.NewRow();
        name = feeds.Dictionary["data"].Array[i].Dictionary["name"].String;
        dr["name"] = name;
        if (!feeds.Dictionary["data"].Array[i].Dictionary.ContainsKey("video"))
        {
          if (feeds.Dictionary["data"].Array[i].Dictionary.ContainsKey("message"))
          {
            message = feeds.Dictionary["data"].Array[i].Dictionary["message"].String;
          }
          else
            message = "";
          dr["message"] = message;
          if (feeds.Dictionary["data"].Array[i].Dictionary.ContainsKey("link"))
          {
            link = feeds.Dictionary["data"].Array[i].Dictionary["link"].String;
          }
          else
            link = "";
          dr["link"] = link;
          if (feeds.Dictionary["data"].Array[i].Dictionary.ContainsKey("picture"))
          {
            picture = feeds.Dictionary["data"].Array[i].Dictionary["picture"].String;
          }
          else
            picture = "";
          //http://img.youtube.com/vi/mPYEhSBpHg0/1.jpg
          if (feeds.Dictionary["data"].Array[i].Dictionary.ContainsKey("source"))
          {
            string linkVideo = feeds.Dictionary["data"].Array[i].Dictionary["source"].String;
            string _idVideo = linkVideo.Replace("http://www.youtube.com/v/", "");
            string _idvideoCleaned = _idVideo.Substring(0, _idVideo.IndexOf("?"));
            video_thumb = "http://img.youtube.com/vi/" + _idvideoCleaned + "/1.jpg";
            picture = video_thumb;
          }
          dr["picture"] = picture;
        }
        dtFacebook.Rows.Add(dr);
      }
    }
    return dtFacebook;
  }
  public class Log
  {
    public readonly ILog logger;
    public Log()
    {
      logger = LogManager.GetLogger
      (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
  }
  public static void WriteLog(string logParameters)
  {
    Log scriviLog = new Log();
    scriviLog.logger.Debug(logParameters);
  }
  public static bool IsPagerVisible(DataPager dPager, ObjectDataSource objDataSrc)
  {
    bool isVisible = false;
    DataView dv = (DataView)objDataSrc.Select();
    isVisible = (dv.Count > dPager.PageSize);
    //  dPager.Visible = isPagerVisible;
    return isVisible;
  }
  public static string cleanTagFromString(string htmlString)
  {
    string strigCleaned = Regex.Replace(htmlString, @"</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>", String.Empty);
    return strigCleaned;
  }
  public static string SearchConfigValue(string keyValue)
  {
    return System.Configuration.ConfigurationManager.AppSettings[keyValue];
  }
  public static string uploadFoto(FileUpload fileUpload)
  {
    string error = "";
    string pathFotoFromConfig = Utility.SearchConfigValue("pathFotoNews");
    string fileName = HttpUtility.HtmlEncode(fileUpload.FileName);
    string filePath = HttpContext.Current.Server.MapPath(pathFotoFromConfig.Replace("/", "\\"));
    string extension = System.IO.Path.GetExtension(fileName);
    //string filePath = Server.MapPath("~\\img\\FotoArticoli\\");
    // controlliamo se il controllo FileUploadFoto contiene un file da caricare
    if (fileUpload.HasFile)
    {
      if ((extension.ToUpper() == ".JPG") || (extension.ToUpper() == ".PNG"))
      {
        int fileSize = fileUpload.PostedFile.ContentLength;
        // consento l'upload di file con dimensione < di 1mb!
        if (fileSize < 1100000)
        {
          // se si, aggiorniamo il path del file
          filePath += fileUpload.FileName;
          // salviamo il file nel percorso calcolato
          fileUpload.SaveAs(filePath);
        }
        else
        {
          error = "Attenzione: La foto eccede le dimensioni massime consentite (1Mb).";
        }
      }
      else
      {
        error = "Attenzione: Verificare che la foto sia nel formato *.jpg oppure *.png";
      }
    }
    else
    {
      error = "Attenzione: Devi prima selezionare una foto attraverso il tasto 'Sfoglia'.";
    }
    return error;
  }
  public static bool isNewsLinked(int AlbumID)
  {
    bool isnewsLinked = false;
    DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlbum = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
    DataTable dtAlbum = taAlbum.GetInfoAlbumbyID(AlbumID);
    if (!string.IsNullOrEmpty(dtAlbum.Rows[0]["NewsEventoID"].ToString()))
      isnewsLinked = true;
    return isnewsLinked;
  }
  public static string isVisible(int NewsID)
  {
    bool isnewsVis = false;
    string retString = "no";
    DataSetVepAdminTableAdapters.NewsTableAdapter taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
    DataTable dtNews = taNews.GetDataByID(NewsID);
    if (bool.TryParse(dtNews.Rows[0]["Autore"].ToString(), out isnewsVis)) ;
    if (isnewsVis)
      retString = "si";
    return retString;
  }
  public static string ShortDesc(string stringToCut, int numChar)
  {
    string stringCutted = "";
    try
    {
      if (stringToCut.Length > numChar)
      {
        //stringCutted = stringToCut.Substring(0, numChar).Substring(0, stringToCut.Substring(0, numChar).LastIndexOf(" "));
        stringCutted = stringToCut.Substring(0, numChar);
        stringCutted = stringCutted.Substring(0, stringCutted.LastIndexOf(" "));
      }
      else
        stringCutted = stringToCut;
    }
    catch (Exception e)
    {
    }
    stringCutted = Regex.Replace(stringCutted, @"</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>", String.Empty).Trim();
    return stringCutted;
  }
  public static string SetFoto(string urlFoto)
  {
    string fotoNews = "../img/foto/standard.png";
    if (!string.IsNullOrEmpty(urlFoto))
      fotoNews = "../" + urlFoto;
    return fotoNews;
  }
  public static string SetJavaParam(string param)
  {
    string paramOk = '"' + param + '"';
    return paramOk;
  }
 
  public static void Show(string message)
  {
    // Cleans the message to allow single quotation marks
    string cleanMessage = message.Replace("'", "\'");
    string script = "<script type='text/javascript'>alert('" + cleanMessage + "');</script>";
    // Gets the executing web page
    Page page = HttpContext.Current.CurrentHandler as Page;
    // Checks if the handler is a Page and that the script isn't allready on the Page
    if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
    {
      page.ClientScript.RegisterClientScriptBlock(typeof(Utility), "alert", script);
    }
  }
  public static void ShowFaceBox(string message)
  {
    // Gets the executing web page
    Page page = HttpContext.Current.CurrentHandler as Page;
    page.ClientScript.RegisterStartupScript(typeof(Utility), "facebox", "jQuery.facebox('" + message + "');", true);
  }
  public static void apriShadow(string message)
  {
    // Gets the executing web page
    Page page = HttpContext.Current.CurrentHandler as Page;
    page.ClientScript.RegisterStartupScript(typeof(Utility), "shadowbox",
        "Shadowbox.open({content:" + "ciao" + ",player:" + "html" + ",title:Condividere});", true);
  }
  public static bool IsValidMailAddress(string email)
  {
    var reMailAddress = new Regex("(?<user>[^@]+)@(?<host>.+)");
    return reMailAddress.Match(email).Success;
  }
  public static bool isVisible(string stringa)
  {
    if (string.IsNullOrEmpty(stringa))
      return false;
    else
      return true;
  }
  public static string GetAbsoluteUrl()
  {
    return "http://" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
  }
  public static string GetHttp()
  {
    string ret = "http://www.materarredamenti.it/";
    return ret;
  }
  public static string GetMese(string intMese)
  {
    string ret = "";
    switch (intMese)
    {
      case "1":
        ret = "Gen";
        break;
      case "2":
        ret = "Feb";
        break;
      case "3":
        ret = "Mar";
        break;
      case "4":
        ret = "Apr";
        break;
      case "5":
        ret = "Mag";
        break;
      case "6":
        ret = "Giu";
        break;
      case "7":
        ret = "Lug";
        break;
      case "8":
        ret = "Ago";
        break;
      case "9":
        ret = "Set";
        break;
      case "10":
        ret = "Ott";
        break;
      case "11":
        ret = "Nov";
        break;
      case "12":
        ret = "Dic";
        break;
    }
    return ret;
  }
  public static void ShowShadowBox(string message)
  {
    Page page = HttpContext.Current.CurrentHandler as Page;
    page.ClientScript.RegisterStartupScript(typeof(Utility), "shadowbox",
        "Shadowbox.open({content:'http://www.google.it',player:'iframe',title:'Welcome',height:550,width:550 });return false", true);
  }
  public static string GetStringTransFromDB(string nomeCampoITA, string nomeCampoENG, string nomeCampoDE, System.Threading.Thread currentCulture)
  {
    string transString = "";
    if (currentCulture.CurrentCulture.ThreeLetterISOLanguageName == "ita")
    {
      transString = nomeCampoITA;
    }
    else if (currentCulture.CurrentCulture.ThreeLetterISOLanguageName == "eng")
    {
      transString = nomeCampoENG;
      if (string.IsNullOrEmpty(transString.Trim()))
        transString = nomeCampoITA;
    }
    else if (currentCulture.CurrentCulture.ThreeLetterISOLanguageName == "deu")
    {
      transString = nomeCampoDE;
      if (string.IsNullOrEmpty(transString.Trim()))
        transString = nomeCampoITA;
    }
    transString = transString.Replace("<div>", "");
    transString = transString.Replace("<p>", "");
    transString = transString.Replace("</p>", "");
    transString = transString.Replace("</div>", "");
    return transString;
  }
  public static string SetPrjID(string param)
  {
    string paramOk = "SetPrjID('" + param + "');";
    return paramOk;
  }
  public static string[] GetRandomImages(string path)
  {
    var vignette = Directory.GetFiles(path, "*.jpg");
    var rand = new Random();
    var result = new List<Int32>();
    for (var i = 0; i < 3; i++)
    {
      var curValue = rand.Next(0, vignette.Length);
      while (result.Exists(value => value == curValue))
      {
        curValue = rand.Next(0, vignette.Length);
      }
      result.Add(curValue);
    }
    string[] randomVignette = { vignette[result[0]], vignette[result[1]], vignette[result[2]] };
    return randomVignette;
  } 
}
