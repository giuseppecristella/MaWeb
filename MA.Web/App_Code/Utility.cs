using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Web;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Xml;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using DataSetVepAdminTableAdapters;
using Google.GData.Extensions;
using Google.GData.Extensions.MediaRss;
using log4net;
using Facebook;
using System.Reflection;
using System.IO;
/// <summary>
/// Descrizione di riepilogo per Utility
/// </summary>
public static class Utility
{
 
  public static string ReadTemplateFromFile(string html_template)
  {
    var fileName = HttpContext.Current.Server.MapPath(SearchConfigValue(html_template));
    var output = "";
    if (!File.Exists(fileName))
      return output;
    var stFile = File.OpenText(fileName);
    output = stFile.ReadToEnd();
    stFile.Close();
    return output;
  }

  public static DataTable YouTubeToDataTable()
  {
    IEnumerable ien = ListVideos.YourVideos();
    var dt = new DataTable();
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
        if (pi.Name == "Rating") continue;
        if (pi.Name == "Thumbnails")
        {
          var value = pi.GetValue(obj, null);
          var thumbs = (ExtensionCollection<MediaThumbnail>)value;
          dr[pi.Name] = thumbs[4].Url;
        }
        else
        {
          if (pi.Name == "ResponseUri") continue;
          var value = pi.GetValue(obj, null);
          dr[pi.Name] = value;
        }
      }
      dt.Rows.Add(dr);
    }
    return dt;
  }
  
  public static bool IsPagerVisible(DataPager dPager, ObjectDataSource objDataSrc)
  {
    bool isVisible = false;
    DataView dv = (DataView)objDataSrc.Select();
    isVisible = (dv.Count > dPager.PageSize);
    //  dPager.Visible = isPagerVisible;
    return isVisible;
  }
 
  public static string CleanHtmlTagsFromString(string htmlString)
  {
    string strigCleaned = Regex.Replace(htmlString, @"</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>", String.Empty);
    return strigCleaned;
  }

  public static string SearchConfigValue(string keyValue)
  {
    return ConfigurationManager.AppSettings[keyValue];
  }

  public static string VisibleContentFlagDescription(int NewsID)
  {
    bool isnewsVis;
    var taNews = new NewsTableAdapter();
    DataTable dtNews = taNews.GetDataByID(NewsID);
    if (!Boolean.TryParse(dtNews.Rows[0]["Autore"].ToString(), out isnewsVis)) return "-";
    return (isnewsVis) ? "si" : "no";
  }

  public static string SetFoto(string urlFoto)
  {
    string fotoNews = "../img/foto/standard.png";
    if (!String.IsNullOrEmpty(urlFoto))
      fotoNews = "../" + urlFoto;
    return fotoNews;
  }
  
  public static string GetMonth(string intMese)
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

  public static string[] GetRandomImages(string path)
  {
    var vignette = Directory.GetFiles(path, "*.jpg");
    var rand = new Random();
    var result = new List<int>();
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

  public static string SetMegaMenu(string apiUrl, string sessionId, string rootCat)
  {
    return ReadTemplateFromFile(rootCat == "37" ? "pathTemplateShopVerde" : "pathTemplateShopRosso");
  }
}
