using System;
using System.Data;
using Microsoft.AspNet.FriendlyUrls;

public partial class PromoDettaglio : BaseBlogPage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ltrSocial.Text = Utility.ReadTemplateFromFile("pathSocial");
    var promoId = Request.GetFriendlyUrlSegments()[0];
    
    var taPromo = new DataSetVepAdminTableAdapters.NewsTableAdapter();
    DataTable dtPromo = taPromo.GetDataByID(int.Parse(promoId));
    var imagePath = Url + dtPromo.Rows[0]["UrlFotoHome"];
    var fbMetaTagsTemplate = ReadTemplateFromFile("template_tagFb.htm");
    CreateFacebookMetaTags(fbMetaTagsTemplate, imagePath, String.Format("{0}PromoDettaglio/{1}/{2}", Url, dtPromo.Rows[0]["News_ID"], dtPromo.Rows[0]["Titolo"]));
  }

}
