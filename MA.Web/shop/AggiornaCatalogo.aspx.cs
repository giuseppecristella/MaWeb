using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
public partial class shop_AggiornaCatalogo : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }

  protected void LinkButton1_Click(object sender, EventArgs e)
  {
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
    //ATTENZIONE: quando aggiungiamo una nuova categoria devo aggiornare l'elenco sopra
    //HttpContext.Current.Cache["myAssignedProducts" + "38"] = null;
    /*sincronizzo i files delle regole degli url
  string fileName = "test.txt";
    string sourceFile = HttpContext.Current.Server.MapPath(@"~\RewriterConfig_2.xml"); //@"C:\Users\Public\TestFolder";
string destFile = HttpContext.Current.Server.MapPath(@"~\RewriterConfig.xml");
  // Use Path class to manipulate file and directory paths.
// string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
//string destFile = System.IO.Path.Combine(targetPath, fileName);
           
// To copy a file to another location and 
// overwrite the destination file if it already exists.
System.IO.File.Copy(sourceFile, destFile, true);*/
    lblAggCat.Text = "<br>Le modifiche al catalogo sono state eseguite correttamente!";
  }

  private void WriteRules(string rootCat)
  {
    if (!helper.checkConnection())
    {
      HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
      HttpContext.Current.Cache.Insert("sessionId",
                                       helper.getConnection(Utility.SearchConfigValue("apiUrl"),
                                                            Utility.SearchConfigValue("apiUser"),
                                                            Utility.SearchConfigValue("apiPsw")));
    }
    object myCategoryLevel = Category.Level((string)HttpContext.Current.Cache["apiUrl"],
                                          (string)HttpContext.Current.Cache["sessionId"], new object[] { rootCat });
    System.Collections.Hashtable myCategoryTree = (System.Collections.Hashtable)myCategoryLevel;
    /*ottengo sempre un array min. 1 elemento*/
    object[] figli = (object[])myCategoryTree["children"];
    for (int i = 0; i < figli.Length; i++)
    {
      System.Collections.Hashtable figlio = (System.Collections.Hashtable)figli[i];
      /* scrivo la regola se questa non esiste già a livello di querystring*/
      helper.writeXmlRewriterRules(figlio["category_id"].ToString(), "", figlio["name"].ToString(), "");
      /* prendo tutti i prodotti di ciascuna sotto categoria e scrivo le regole relative ad ogni prodotto*/
      if (!helper.checkConnection())
      {
        HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
        HttpContext.Current.Cache.Insert("sessionId",
                                         helper.getConnection(Utility.SearchConfigValue("apiUrl"),
                                                              Utility.SearchConfigValue("apiUser"),
                                                              Utility.SearchConfigValue("apiPsw")));
      }
      CategoryAssignedProduct[] prodFromSubCat
        = Category.AssignedProducts((string)HttpContext.Current.Cache["apiUrl"],
                                    (string)HttpContext.Current.Cache["sessionId"],
                                    new object[] { figlio["category_id"].ToString() });
      foreach (CategoryAssignedProduct product in prodFromSubCat)
      {
        helper.writeXmlRewriterRules(figlio["category_id"].ToString(), product.product_id, product.name, "");
      }
    }
  }

  protected void AggiornaURL(object sender, EventArgs e)
  {
    /*
    Ricavo l'albero delle categorie per ciascuna categoria di root
 *  in questo caso (37-shopverde e 47-shoprosso)
 *  
 * per ciascuna sottocategoria ricavo i prodotti e costruisco se necessario gli url aggiornando il dile
 * RewriterConfig.xml 
 * 
 * in questo modo l'accesso in scrittura non avverrà più nel front-end
 * 
 * 
 */
    WriteRules("37");
    WriteRules("47");
    // il codice seguente mi serve per costruire il menu
    // htmlString += "<li>" + "<a href=\"" + GetAbsoluteUrl() + "shop/" + figlio["name"] + ".html" + "\">" + figlio["name"] + "</a>";
    //htmlString += "</li>";
  }

  //AggiornaSessionIdMagento
  private bool WriteMenu(string rootCat)
  {
    bool ret = true;
    string strMegaMenu = "";
    string strMenuMobile = "";
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
    ArrayList arrCategories = new ArrayList();
    // get the tree (does not always return array) baco sulla tree utilizzo la level per ottenere l'albero
    //  HostingEnvironment.ApplicationVirtualPath;
    object myCategoryLevel = Category.Level((string)HttpContext.Current.Cache["apiUrl"],
                                            (string)HttpContext.Current.Cache["sessionId"], new object[] { rootCat });
    System.Collections.Hashtable myCategoryTree = (System.Collections.Hashtable)myCategoryLevel;
    /*ottengo sempre un array min. 1 elemento*/
    object[] figli = (object[])myCategoryTree["children"];
    for (int i = 0; i < figli.Length; i++)
    {
      System.Collections.Hashtable figlio = (System.Collections.Hashtable)figli[i];
      strMegaMenu += "<li>" + "<a href=\"" + helper.GetAbsoluteUrl() + "shop/" + figlio["name"].ToString().Replace(" ", "-") + ".html" + "\">" + figlio["name"] + "</a>";
      strMenuMobile += "<li>" + "<a style=\"font-size: 18px;\" href=\"" + helper.GetAbsoluteUrl() + "mobile/mCatalogo.aspx?CatId=" + figlio["category_id"] + "\">" + figlio["name"] + "</a>";
      //  GetTree(figlio, arrCategories, 3, htmlString);
      strMegaMenu += "</li>";
      strMenuMobile += "</li>";
    }
    if (rootCat == "37")
    {
      string fileName = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue("pathTemplateShopVerde"));
      string fileNameMob = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue("pathTemplatemShopVerde"));
      if (File.Exists(fileName))
        File.WriteAllText(fileName, strMegaMenu);
      else
        ret = false;
      if (File.Exists(fileNameMob))
        File.WriteAllText(fileNameMob, strMenuMobile);
      else
        ret = false;
    }
    else
    {
      string fileName = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue("pathTemplateShopRosso"));
      string fileNameMob = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue("pathTemplatemShopRosso"));
      if (File.Exists(fileName))
        File.WriteAllText(fileName, strMegaMenu);
      else
        ret = false;
      if (File.Exists(fileNameMob))
        File.WriteAllText(fileNameMob, strMenuMobile);
      else
        ret = false;
    }
    return ret;
  }

  protected void RiscriviMenuCategorie(object sender, EventArgs e)
  {
    WriteMenu("37");
    WriteMenu("47");
  }

  protected void AggiornaSessionIdMagento(object sender, EventArgs e)
  {
    if (!helper.checkConnection())
    {
      HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
      HttpContext.Current.Cache.Insert("sessionId",
                                       helper.getConnection(Utility.SearchConfigValue("apiUrl"),
                                                            Utility.SearchConfigValue("apiUser"),
                                                            Utility.SearchConfigValue("apiPsw")));
    }
    lblAggCat.Text += " SESSION: ID" + (string)HttpContext.Current.Cache["sessionId"];
  }
}
