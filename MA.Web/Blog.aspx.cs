using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public partial class Blog : BaseBlogPage
{

  protected void Page_Load(object sender, EventArgs e)
  {
    if (IsPostBack) return;

    var fbMetaTagsTemplate = ReadTemplateFromFile("template_tagFb.htm");
    if (string.IsNullOrEmpty(fbMetaTagsTemplate)) return;

    var randomVignette = Utility.GetRandomImages(Server.MapPath("~/img/outlet/"));
    var imagePath = string.Format("{0}img/outlet/{1}", Url, Path.GetFileName(randomVignette.FirstOrDefault()));

    CreateFacebookMetaTags(fbMetaTagsTemplate, imagePath, Url);
  }

  protected void OnPagerPrerender(object sender, EventArgs e)
  {
    var randomVignette = Utility.GetRandomImages(Server.MapPath("~/img/outlet/"));
    var taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
    DataTable dtNews = taNews.GetListaNews("0");
    var arrayBlogPosts = new ArrayList();
    var k = 0;
    var j = 0;
    for (var i = 0; i < dtNews.Rows.Count; i++)
    {
      if (j > 0 && j % 12 == 0)
        k++;
      if (IsFirstBox(j, k) || IsSecondBox(j, k) || IsThirdBox(j, k))
      {
        AddCartoons(arrayBlogPosts, j, randomVignette[0]);
        AddBlogPost(arrayBlogPosts, j, dtNews.Rows[i]);
        j++;
      }
      else
      {
        AddBlogPost(arrayBlogPosts, j, dtNews.Rows[i]);
      }
      j++;
    }
    lvBlogPosts.DataSource = arrayBlogPosts;
    lvBlogPosts.DataBind();
  }

  protected void lvBlogPostsOnItemDataBound(object sender, ListViewItemEventArgs e)
  {
    var dataitem = (ListViewDataItem)e.Item;
    var ltrItemBlog = (Literal)e.Item.FindControl("ltrItemBlog");
    ltrItemBlog.Text = (string)dataitem.DataItem;
  }

  #region Private Methods

  private static bool IsThirdBox(int j, int k)
  {
    return j == 9 + 12 * k && j % 4 == 1;
  }

  private static bool IsSecondBox(int j, int k)
  {
    return j == 6 + 12 * k && j % 4 == 2;
  }

  private static bool IsFirstBox(int j, int k)
  {
    return j == 0 + 12 * k && j % 4 == 0;
  }

  private static void AddBlogPost(IList arrayBlogPosts, int j, DataRow drBlogPost)
  {
    DataTable dtNews;
    arrayBlogPosts.Insert(j,
      string.Format(
        "<h6>{0}</h6><p class=\"blog-box\">{1}</p><a class=\"blog-read-all\" href=\"BlogPost/{2}/{3}\">[+ Leggi Tutto]</a>",
       drBlogPost["Titolo"],
        Helper.GetShortStringAndCleanTags(drBlogPost["Descrizione"].ToString(), 250),
        drBlogPost["News_ID"],
        drBlogPost["Titolo"]));
  }

  private static void AddCartoons(ArrayList arrayBlogPosts, int j, string imgPath)
  {
    arrayBlogPosts.Insert(j, string.Format("<img width=\"217\"  height=\"235\" src=\"img/outlet/{0}\"/>",
      Path.GetFileName(imgPath)));
  }

  #endregion
}
