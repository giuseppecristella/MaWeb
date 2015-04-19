using System;
using System.Activities.Expressions;
using System.Collections;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Google.GData.Extensions;
using MagentoRepository.Connection;
using MagentoRepository.Helpers;
using MagentoRepository.Repository;
using Microsoft.AspNet.FriendlyUrls;

public partial class Design_UserControls_UCShopMenu : System.Web.UI.UserControl
{
    private string _pageName;

    public string PageName
    {
        get { return Request.GetFriendlyUrlSegments().Any() ? Request.GetFriendlyUrlSegments()[0] : string.Empty; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        var repository = new RepositoryService(MagentoConnection.Instance, new Cache.ELCacheManager());
        var rootCategoryInfo = repository.GetCategoryLevel(ConfigurationHelper.RootCategory) as Hashtable;
        if (rootCategoryInfo == null) return;
        var categories = rootCategoryInfo["children"] as object[];
        if (categories == null) return;

        if (Request.GetFriendlyUrlFileVirtualPath().ToLowerInvariant().Contains("default")) lbMenuItemHome.Attributes["class"] = "menu-item-selected";
        
        rptMenuItems.DataSource = categories.Select(c => new { name = (c as Hashtable)["name"].ToString().Replace(" ", "-") }).ToList();
        rptMenuItems.DataBind();
    }

    protected void rptMenuItems_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var dataItem = e.Item.DataItem;

        var lbMenuItem = e.Item.FindControl("lbMenuItem") as HtmlAnchor;
        if (lbMenuItem == null) return;
        if (!string.IsNullOrEmpty(PageName))
        {
            if (lbMenuItem.HRef.Contains(PageName)) lbMenuItem.Attributes["class"] = "menu-item-selected";
        }
        
    }
}