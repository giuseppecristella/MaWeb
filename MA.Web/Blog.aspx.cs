using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using System.Reflection;
using Facebook;
using DataSetVepAdminTableAdapters;

public partial class Blog : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      string[] randomVignette = randomImage();
      string url = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");//Page.Request.Url.ToString();
      string imagePath = url + "img/outlet/" + Path.GetFileName(randomVignette[0]);
      //BlogPost.aspx?Id
      string templateHtml = readTemplateFromFile("template_tagFb.htm");
      string replaceImage_p = templateHtml.Replace("##image##", imagePath);
      string replaceUrl_p = replaceImage_p.Replace("##url##", url + "Blog.html");
      string replaceTitle_p = replaceUrl_p.Replace("##titolo##", "Matera Arredamenti > Blog");
      string replaceDesc_p = replaceTitle_p.Replace("##caption##", "Il Blog di Giovanni Matera. E in edicola puoi trovare il libro La cassetta degli attrezzi - Strumenti per il marketing e l'imprenditoria. Anche su amazon e ibs.");
      Session["metatagFB"] = replaceDesc_p;
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

  string[] randomImage()
  {
    string pathimg = Server.MapPath("~/img/outlet/");
    // string[] filePaths = Directory.GetFiles(@"c:\img\outlet", "*.jpg");
    string[] vignette = Directory.GetFiles(@pathimg, "*.jpg");

    Random rand = new Random();
    List<Int32> result = new List<Int32>();
    for (Int32 i = 0; i < 3; i++)
    {
      Int32 curValue = rand.Next(0, vignette.Length);
      while (result.Exists(value => value == curValue))
      {
        curValue = rand.Next(0, vignette.Length);
      }
      result.Add(curValue);
    }
    string[] randomVignette = { vignette[result[0]], vignette[result[1]], vignette[result[2]] };
    return randomVignette;
  }

  protected void pagerPrerender(object sender, EventArgs e)
  {
    string[] randomVignette = randomImage();
    DataSetVepAdminTableAdapters.NewsTableAdapter taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
    DataTable dtNews =
        taNews.GetListaNews("0");
    ArrayList arrayBlogPosts = new ArrayList();
    int k = 0;

    int j = 0;
    for (int i = 0; i < dtNews.Rows.Count; i++)
    {
      if (j > 0 && j % 12 == 0)
        k++;
      if (j == 0 + 12 * k && j % 4 == 0)
      {
        //metto la prima immmagine

        arrayBlogPosts.Insert(j, "<img width=\"217\"  height=\"235\" src=\"img/outlet/" + Path.GetFileName(randomVignette[0]) + "\"" + "/>");
        j++;
        arrayBlogPosts.Insert(j, "<h6 style=\"height:50px;\">" + dtNews.Rows[i]["Titolo"].ToString() + "</h6>" +
            "<p style=\"height:150px;overflow:hidden;\">" +
            Utility.ShortDesc(dtNews.Rows[i]["Descrizione"].ToString(), 255).ToString() + "</p>" +
            //"<a  href=\"" + dtNews.Rows[i]["Titolo"].ToString().Replace("%", "").Replace("?", "").Replace(" ", "-") + ".html\">" +
            "<a  href=\"BlogPost.aspx?Id="+ dtNews.Rows[i]["News_ID"].ToString()+"\">" +
            "[+ Leggi Tutto]" + "</a>");
      }
      //else if (i == 6)
      else if (j == 6 + 12 * k && j % 4 == 2)
      {
        arrayBlogPosts.Insert(j, "<img  width=\"217\"  height=\"235\"  src=\"img/outlet/" + Path.GetFileName(randomVignette[1]) + "\"" + "/>");
        j++;
        arrayBlogPosts.Insert(j, "<h6 style=\"height:50px;\">" + dtNews.Rows[i]["Titolo"].ToString() + "</h6>" +
            "<p style=\"height:150px;overflow:hidden;\">" +
            Utility.ShortDesc(dtNews.Rows[i]["Descrizione"].ToString(), 255).ToString() + "</p>" +
            //"<a  href=\"" + dtNews.Rows[i]["Titolo"].ToString().Replace("%", "").Replace("?", "").Replace(" ", "-") + ".html\">" +
            "<a  href=\"BlogPost.aspx?Id=" + dtNews.Rows[i]["News_ID"].ToString() + "\">" +
            "[+ Leggi Tutto]" + "</a>");
      }
      else if (j == 9 + 12 * k && j % 4 == 1)
      {
        arrayBlogPosts.Insert(j, "<img  width=\"217\"  height=\"235\"  src=\"img/outlet/" + Path.GetFileName(randomVignette[2]) + "\"" + "/>");
        j++;
        arrayBlogPosts.Insert(j, "<h6 style=\"height:50px;\">" + dtNews.Rows[i]["Titolo"].ToString() + "</h6>" +
            "<p style=\"height:150px;overflow:hidden;\">" +
            Utility.ShortDesc(dtNews.Rows[i]["Descrizione"].ToString(), 255).ToString() + "</p>" +
            //"<a  href=\"" + dtNews.Rows[i]["Titolo"].ToString().Replace("%", "").Replace("?", "").Replace(" ", "-") + ".html\">" +
            "<a  href=\"BlogPost.aspx?Id=" + dtNews.Rows[i]["News_ID"].ToString() + "\">" +
            "[+ Leggi Tutto]" + "</a>");
      }
      else
      {
        arrayBlogPosts.Insert(j, "<h6 style=\"height:50px;\">" + dtNews.Rows[i]["Titolo"].ToString() + "</h6>" +
            "<p style=\"height:150px;overflow:hidden;\">" +
            Utility.ShortDesc(dtNews.Rows[i]["Descrizione"].ToString(), 255).ToString() + "</p>" +
            //"<a  href=\"" + dtNews.Rows[i]["Titolo"].ToString().Replace("%", "").Replace("?", "").Replace(" ", "-") + ".html\">" +
            "<a  href=\"BlogPost.aspx?Id=" + dtNews.Rows[i]["News_ID"].ToString() + "\">" +
            "[+ Leggi Tutto]" + "</a>");
      }
      j++;
    }
    lvBlogPosts.DataSource = arrayBlogPosts;
    lvBlogPosts.DataBind();
  }

  protected void lvBlogPosts_ItemDataBound(object sender, ListViewItemEventArgs e)
  {
    ListViewDataItem dataitem = (ListViewDataItem)e.Item;
    Literal ltrItemBlog = (Literal)e.Item.FindControl("ltrItemBlog");
    ltrItemBlog.Text = (string)dataitem.DataItem;
  }
}
