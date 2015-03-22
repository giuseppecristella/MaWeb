using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using Ez.Newsletter.MagentoApi;
using System.Collections;
public static class Helper
{

    #region Magento Connection
    public static string GetConnection(string apiUrl, string apiUser, string apiPass)
    {
        return Connection.Login(apiUrl, apiUser, apiPass);
    }

    public static bool CheckConnection()
    {
        return HttpContext.Current.Cache["apiUrl"] != null && HttpContext.Current.Cache["sessionId"] != null;
    }
    #endregion

    #region URI

    public static string GetImageName(string imageurl)
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

    public static string GetAbsoluteUrl()
    {
        return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
    }
    #endregion

    #region String

    /// <summary>
    /// Restituisce una stringa di lunghezza uguale al numero di caratteri in input
    /// Todo: implementare questo metodo come un extension method del tipo string
    /// </summary>
    /// <param name="stringToCut"></param>
    /// <param name="numChar"></param>
    /// <returns></returns>
    public static string GetShortString(string stringToCut, int numChar)
    {
        var stringCutted = String.Empty;
        try
        {
            stringCutted = stringToCut.Length > numChar ? stringToCut.Substring(0, numChar).Substring(0, stringToCut.Substring(0, numChar).LastIndexOf(" ", StringComparison.Ordinal)) : stringToCut;
        }
        catch (Exception e)
        {
        }
        return stringCutted;
    }

    public static string GetShortStringAndCleanTags(string stringToCut, int numChar)
    {
        var stringCutted = GetShortString(stringToCut, numChar);
        stringCutted = Regex.Replace(stringCutted, @"</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>", String.Empty).Trim();
        return stringCutted;
    }

    #endregion

    #region Validation
    public static bool IsValidMailAddress(string email)
    {
        var reMailAddress = new Regex("(?<user>[^@]+)@(?<host>.+)");
        return reMailAddress.Match(email).Success;
    }

    #endregion

    public static void GetTree(Hashtable category, ArrayList arrCategories, int stopLevel, string htmlString)
    {
        var figli = (object[])category["children"];
        /*se devo costruire dei sottomenu -> liste annidate */
        if (figli.Length > 1)
            htmlString += "<div class=\"megamenu\"><ul class=\"sub-menu\">";
        foreach (var t in figli)
        {
            var figlio = (Hashtable)t;
            /*elemento generico della lista*/
            htmlString += "<li>" + "<a href=\"Prodotti.aspx?CatId=" + figlio["category_id"] + "\">" + figlio["name"] + "</a>";
            arrCategories.Add(figlio["name"] +
                              " parent_id->" + figlio["parent_id"] +
                              " category_id->" + figlio["category_id"]);
            var figlio_ = (object[])figlio["children"];
            var level = figlio["level"].ToString();
            if (Int32.Parse(level) < stopLevel)
            {
                if (figlio_.Length > 1)
                    GetTree(figlio, arrCategories, 3, htmlString); //corrisponde al livello 2 dell' albero
                else
                    htmlString += "</li>";
            }
            else
            {
                htmlString += "</li>";
            }
        }
        if (figli.Length > 1)
            htmlString += "</ul></div>";
    }

    // Todo: Rimuovere questa funzione ed usare quelle dell framework
    public static string FormatCurrency(string magento_currency)
    {
        var formattedCurr = magento_currency.Remove(magento_currency.Length - 2, 2).Replace(".", ",");
        return formattedCurr;
    }

}
