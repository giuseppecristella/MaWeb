﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Ez.Newsletter.MagentoApi;
using iTextSharp.text;
using MagentoRepository.Repository;
using Microsoft.Practices.EnterpriseLibrary.Caching;

public partial class shop_AggiornaCatalogo : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void lbUpdateCatalog_Click(object sender, EventArgs e)
    {
        var products = _repository.GetProductsByCategoryId("47");
        lblUpdateCatalog.Text = "num prodotti: " + products.Count.ToString();
        // if (products == null) return;
        var cacheManager = CacheFactory.GetCacheManager();
        var cachedProducts = cacheManager.GetData("ProductsList") as List<CategoryAssignedProduct>;

        var images = new List<string>();
        cachedProducts = null;
        if (cachedProducts != null)
        {
            GetChangedImages(products, cachedProducts, images);
            GetNewImages(products, cachedProducts, images);
        }
        else
        {
            GetAllProductsImages(products, images);
        }
        DownloadImages(images);

        #region To Delete
        HttpContext.Current.Cache.Remove("myAssignedProducts38");
        HttpContext.Current.Cache.Remove("myAssignedProducts39");
        HttpContext.Current.Cache.Remove("myAssignedProducts40");
        HttpContext.Current.Cache.Remove("myAssignedProducts41");
        HttpContext.Current.Cache.Remove("myAssignedProducts42");
        HttpContext.Current.Cache.Remove("myAssignedProducts43");
        HttpContext.Current.Cache.Remove("myAssignedProducts48");
        HttpContext.Current.Cache.Remove("myAssignedProducts49");
        HttpContext.Current.Cache.Remove("myAssignedProducts50");
        HttpContext.Current.Cache.Remove("myAssignedProducts51");
        HttpContext.Current.Cache.Remove("myAssignedProducts52");
        HttpContext.Current.Cache.Remove("myAssignedProducts53");
        HttpContext.Current.Cache.Remove("myAssignedProducts54");
        HttpContext.Current.Cache.Remove("myAssignedProducts55");
        HttpContext.Current.Cache.Remove("myAssignedProducts56");
        HttpContext.Current.Cache.Remove("myAssignedProducts58");
        #endregion
        //  lblUpdateCatalog.Text = "<br>Le modifiche al catalogo sono state eseguite correttamente!";
    }

    private void DownloadImages(IEnumerable<string> images)
    {
        var imgPath = Server.MapPath("~/Public/");

        foreach (var img in images)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(img, string.Format("{0}{1}", imgPath, GetFolderAndImageName(img)));
            }
        }
    }

    protected void lbRewriteMenu_Click(object sender, EventArgs e)
    {
        WriteMenu("37");
        WriteMenu("47");
    }

    protected void lbUpdateMagentoSessionId_Click(object sender, EventArgs e)
    {
        if (!helper.checkConnection())
        {
            HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
            HttpContext.Current.Cache.Insert("sessionId",
                                             helper.getConnection(Utility.SearchConfigValue("apiUrl"),
                                                                  Utility.SearchConfigValue("apiUser"),
                                                                  Utility.SearchConfigValue("apiPsw")));
        }
        lblUpdateCatalog.Text += " SESSION: ID" + (string)HttpContext.Current.Cache["sessionId"];
    }

    #region Private Methods

    private static void GetAllProductsImages(IEnumerable<CategoryAssignedProduct> products, List<string> images)
    {
        images.AddRange(products.Select(newProduct => newProduct.imageurl));
    }

    private static void GetNewImages(IEnumerable<CategoryAssignedProduct> products, IEnumerable<CategoryAssignedProduct> cachedProducts, List<string> images)
    {
        var newProducts = products.Where(p =>
        {
            var categoryAssignedProducts = cachedProducts as IList<CategoryAssignedProduct> ?? cachedProducts.ToList();
            return !categoryAssignedProducts.Select(c => c.product_id).Contains(p.product_id);
        });

        images.AddRange(newProducts.Select(newProduct => newProduct.imageurl));
    }

    private static void GetChangedImages(IEnumerable<CategoryAssignedProduct> products, List<CategoryAssignedProduct> cachedProducts, List<string> images)
    {
        foreach (var product in products)
        {
            var p = product;
            var productWithChangedImage =
                cachedProducts.FirstOrDefault(
                    cp => cp.product_id.Equals(p.product_id) && !cp.imageurl.Equals(p.imageurl));
            if (productWithChangedImage == null) continue;
            images.Add(productWithChangedImage.imageurl);
        }
    }


    public static string GetFolderAndImageName(string imageurl)
    {
        var uri = new Uri(imageurl);
        var segments = uri.Segments;
        //var imageFolder = string.Empty;
        //foreach (var segment in segments)
        //{
        //    Guid guidValue;
        //    if (!Guid.TryParse(segment.Remove(segment.Length - 1, 1), out guidValue)) continue;
        //    imageFolder = segment.Remove(segment.Length - 1, 1);
        //}
        //if (string.IsNullOrEmpty(imageFolder)) return null;
        return segments.LastOrDefault();
    }

    private void WriteMenu(string rootCat)
    {
        var strMegaMenu = string.Empty;
        var strMenuMobile = string.Empty;
        if (!helper.checkConnection())
        {
            HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
            HttpContext.Current.Cache.Insert("sessionId",
                                             helper.getConnection(Utility.SearchConfigValue("apiUrl"),
                                                                  Utility.SearchConfigValue("apiUser"),
                                                                  Utility.SearchConfigValue("apiPsw")));
        }
        /*costruisco l'albero delle categorie*/
        /*per ora non uso questo oggetto*/

        // get the tree (does not always return array) baco sulla tree utilizzo la level per ottenere l'albero
        //  HostingEnvironment.ApplicationVirtualPath;
        var myCategoryLevel = Category.Level((string)HttpContext.Current.Cache["apiUrl"],
                                                (string)HttpContext.Current.Cache["sessionId"], new object[] { rootCat });
        var myCategoryTree = (Hashtable)myCategoryLevel;
        /*ottengo sempre un array min. 1 elemento*/
        var figli = (object[])myCategoryTree["children"];
        for (int i = 0; i < figli.Length; i++)
        {
            var figlio = (System.Collections.Hashtable)figli[i];
            strMegaMenu += "<li>" + "<a href=\"" + helper.GetAbsoluteUrl() + "shop/" + figlio["name"].ToString().Replace(" ", "-") + ".html" + "\">" + figlio["name"] + "</a>";
            strMenuMobile += "<li>" + "<a style=\"font-size: 18px;\" href=\"" + helper.GetAbsoluteUrl() + "mobile/mCatalogo.aspx?CatId=" + figlio["category_id"] + "\">" + figlio["name"] + "</a>";
            //  GetTree(figlio, arrCategories, 3, htmlString);
            strMegaMenu += "</li>";
            strMenuMobile += "</li>";
        }
        if (rootCat == "37")
        {
            var fileName = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue("pathTemplateShopVerde"));
            var fileNameMob = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue("pathTemplatemShopVerde"));
            if (File.Exists(fileName))
                File.WriteAllText(fileName, strMegaMenu);
            else if (File.Exists(fileNameMob)) File.WriteAllText(fileNameMob, strMenuMobile);
        }
        else
        {
            string fileName = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue("pathTemplateShopRosso"));
            string fileNameMob = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue("pathTemplatemShopRosso"));
            if (File.Exists(fileName))
                File.WriteAllText(fileName, strMegaMenu);
            else
                if (File.Exists(fileNameMob)) File.WriteAllText(fileNameMob, strMenuMobile);
        }
    }

    #endregion

}
