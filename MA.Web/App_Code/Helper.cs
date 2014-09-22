using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.XPath;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using System.Collections;
public static class helper
{
  public static string test()
  {
    return "session_start fired!!";
  }

  public static String[] prova()
  {
    String[] arrStr = { "1", "2", "3", "4", "5" };
    return arrStr;
  }

  public static string getConnection(string apiUrl, string apiUser, string apiPass)
  {
    // api settings todo: leggere queste chiavi dal web.config
    string sessionId = Connection.Login(apiUrl, apiUser, apiPass);
    return sessionId;
  }

  public static bool checkConnection()
  {
    if (HttpContext.Current.Cache["apiUrl"] == null || HttpContext.Current.Cache["sessionId"] == null)
    {
      //  HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
      return false;
    }
    else
    {
      return true;
    }
  }

  public static ArrayList addProdToSessionCart(Product p)
  {
    ArrayList tempArrayCart = new ArrayList();
    tempArrayCart = (ArrayList)HttpContext.Current.Session["carrello"];
    bool isPresent = false;
    for (int i = 0; i < tempArrayCart.Count; i++)
    {
      Product tempP = (Product)tempArrayCart[i];
      if (tempP.product_id == p.product_id)
      {
        int qta = int.Parse(tempP.qty);
        qta += int.Parse(p.qty);
        tempP.qty = qta.ToString();
        tempArrayCart.RemoveAt(i);
        tempArrayCart.Insert(i, tempP);
        isPresent = true;
      }
    }
    if (!isPresent)
      tempArrayCart.Add(p);
    return tempArrayCart;
  }

  public static string ShortDesc(string stringToCut, int numChar)
  {
    string stringCutted = "";
    try
    {
      if (stringToCut.Length > numChar)
        stringCutted = stringToCut.Substring(0, numChar).Substring(0, stringToCut.Substring(0, numChar).LastIndexOf(" "));
      else
        stringCutted = stringToCut;
    }
    catch (Exception e)
    {
    }
    return stringCutted;
  }

  public static string GetAbsoluteUrl()
  {
    return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
  }
  /*utilizzo il file RewriterConfig.xml
     
ToDo: fare una pulizia del nome e sostituire gli spazi con trattino
*/
  public static void writeXmlRewriterRules(string queryStringId1, string queryStringId2, string name, string path)
  {
    //name = Regex.Replace(name, @"</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>", String.Empty);
    name = name.Replace(" ", "-");
    string xmlFileName = HttpContext.Current.Server.MapPath("~/RewriterConfig.xml");
    XmlDocument _docFromFile = new XmlDocument();
    XmlDocument _doc = new XmlDocument();
    //apro il file se non ce l'ho già in cache 
    if (HttpContext.Current.Cache["writeXmlRewriterRules"] == null)
    {
      try
      {
        _docFromFile.Load(xmlFileName);
        HttpContext.Current.Cache.Insert("RewriterConfigXmlDoc", _docFromFile);
      }
      catch (Exception)
      {
        throw;
      }
    }
    _doc = (XmlDocument)HttpContext.Current.Cache["RewriterConfigXmlDoc"];
    /* in questo caso sto settando l'url di una categoria*/
    if (string.IsNullOrEmpty(queryStringId2))
    {
      /*controllo se esiste la regola*/
      XPathNavigator xNav = _doc.CreateNavigator();
      XPathNodeIterator xPathLookFor = xNav.Select("//RewriterConfig//Rules//RewriterRule//LookFor");
      XPathNodeIterator xPathSendTo = xNav.Select("//RewriterConfig//Rules//RewriterRule//SendTo");
      XPathNodeIterator xPathRewriterRule = xNav.Select("//RewriterConfig//Rules//RewriterRule");
      bool exist = false;
      bool existLookFor = false;
      while (xPathLookFor.MoveNext() && xPathSendTo.MoveNext() && xPathRewriterRule.MoveNext())
      {
        if (xPathSendTo.Current.Value == "~/shop/Catalogo.aspx?CatId=" + queryStringId1)
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
          nodeLookFor.InnerText = "~/shop/" + name + ".html";
        else
          nodeLookFor.InnerText = "~/shop/" + path + "/" + name + ".html";
        nodeSendTo.InnerText = "~/shop/Catalogo.aspx?CatId=" + queryStringId1;
        nodeRewriterRule.AppendChild(nodeLookFor);
        nodeRewriterRule.AppendChild(nodeSendTo);
        XmlNode nodeRules = _doc.SelectSingleNode("descendant::Rules");
        nodeRules.AppendChild(nodeRewriterRule);
        _doc.DocumentElement.AppendChild(nodeRules);
        _doc.Save(xmlFileName);
      }
    }
    /*in questo caso sto settando l'url di un prodotto*/
    else
    {
      /*controllo se esiste la regola*/
      XPathNavigator xNav = _doc.CreateNavigator();
      XPathNodeIterator xPathLookFor = xNav.Select("//RewriterConfig//Rules//RewriterRule//LookFor");
      XPathNodeIterator xPathSendTo = xNav.Select("//RewriterConfig//Rules//RewriterRule//SendTo");
      XPathNodeIterator xPathRewriterRule = xNav.Select("//RewriterConfig//Rules//RewriterRule");
      bool exist = false;
      while (xPathLookFor.MoveNext() && xPathSendTo.MoveNext() && xPathRewriterRule.MoveNext())
      {
        if (xPathSendTo.Current.Value == "~/shop/Dettaglio.aspx?CatId=" + queryStringId1 + "&ProdId=" + queryStringId2)
        {
          /* QUA NON ENTRA MAI!! */
          /*talvolta pur esistendo la regola è necessario riscriverla, per esempio se cambio il nome dell'articolo
         quindi faccio il confronto sul nome per vedere se è cambiato*/
          //   l'id del prodotto è lo stesso il nome è diverso quindi la vecchia regola va cancellata
          //xNav.DeleteSelf();
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
        if (String.IsNullOrEmpty(path))
          nodeLookFor.InnerText = "~/shop/" + name + ".html";
        else
          nodeLookFor.InnerText = "~/shop/" + path + "/" + name + ".html";
        nodeSendTo.InnerText = "~/shop/Dettaglio.aspx?CatId=" + queryStringId1 + "&ProdId=" + queryStringId2;
        nodeRewriterRule.AppendChild(nodeLookFor);
        nodeRewriterRule.AppendChild(nodeSendTo);
        XmlNode nodeRules = _doc.SelectSingleNode("descendant::Rules");
        nodeRules.AppendChild(nodeRewriterRule);
        _doc.DocumentElement.AppendChild(nodeRules);
        _doc.Save(xmlFileName);
      }
    }
  }

  public static string setMegaMenu(string apiUrl, string sessionId, string rootCat)
  {
    string htmlString = "";
    if (rootCat == "37")
      htmlString = Utility.readTemplateFromFile("pathTemplateShopVerde");
    else
    {
      htmlString = Utility.readTemplateFromFile("pathTemplateShopRosso");
    }

    return htmlString;
  }

  public static void GetTree(System.Collections.Hashtable category, ArrayList arrCategories, int stopLevel, string htmlString)
  {
    object[] figli = (object[])category["children"];
    /*se devo costruire dei sottomenu -> liste annidate */
    if (figli.Length > 1)
      htmlString += "<div class=\"megamenu\"><ul class=\"sub-menu\">";
    for (int i = 0; i < figli.Length; i++)
    {
      System.Collections.Hashtable figlio = (System.Collections.Hashtable)figli[i];
      /*elemento generico della lista*/
      htmlString += "<li>" + "<a href=\"Prodotti.aspx?CatId=" + figlio["category_id"] + "\">" + figlio["name"] + "</a>";
      arrCategories.Add(figlio["name"] +
                          " parent_id->" + figlio["parent_id"] +
                          " category_id->" + figlio["category_id"]);
      object[] figlio_ = (object[])figlio["children"];
      string level = figlio["level"].ToString();
      if (int.Parse(level) < stopLevel)
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

  public static string FormatCurrency(string magento_currency)
  {
    string formattedCurr = magento_currency.Remove(magento_currency.Length - 2, 2).Replace(".", ",");
    return formattedCurr;
  }

  public static decimal SommaProdotti(ArrayList arrCart)
  {
    decimal somma = 0;
    Product tempProd;
    for (int i = 0; i < arrCart.Count; i++)
    {
      tempProd = (Product)arrCart[i];
      decimal tot = decimal.Parse(helper.FormatCurrency(tempProd.price)) * int.Parse(tempProd.qty);
      somma += tot;
    }
    return somma;
  }
}
