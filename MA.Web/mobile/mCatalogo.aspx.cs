using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;

public partial class mobile_Catalogo : System.Web.UI.Page
{
    private bool isShopVerde = true;

    public int i = 0;
    private string mainCatName = "";
    private string _pathUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        string _catID = "47";
        if (!string.IsNullOrEmpty(Request.QueryString["CatId"]))
            _catID = Request.QueryString["CatId"];
        object[] catIdObj = { _catID };

        if (!helper.checkConnection())
        {
            HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
            HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));

        }

        /*Recupero il nome della categoria e lo scrivo nella label*/
        object catSubMenu = Category.Level((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], catIdObj);
        System.Collections.Hashtable hashSubMenu = (System.Collections.Hashtable)catSubMenu;
        lblCategoria.Text = (string)hashSubMenu["name"];

        string rootCat = "37";


        if ((string)hashSubMenu["parent_id"] == "47")
        {
            isShopVerde = false;
            //shop rosso
            rootCat = "47";
            tasto_home.HRef = "mHomeShopR.aspx";
             


        }
        else
        {
            //shop verde
            tasto_home.HRef = "mHomeShopV.aspx";
            

           
        }


        //lblCategoria.Text = (string) Session["apiUrl"] +
        //                    (string) Session["sessionId"] + " --> "+rootCat;




        if (HttpContext.Current.Cache["sessionId"] == null)
        {
            HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));
        }

        HttpContext.Current.Cache.Insert("htmlMegaMenu", helper.setMegaMenu((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], rootCat));









 

        CategoryAssignedProduct[] tempmyAssignedProducts = null;
        if (HttpContext.Current.Cache["myAssignedProducts" + _catID.ToString()] == null)
        {

            tempmyAssignedProducts = Category.AssignedProducts((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], catIdObj);
            /*modifica per visualizzare soltanto gli articoli disponibili*/

            ArrayList almyAssignedProducts = new ArrayList();

            foreach (CategoryAssignedProduct product in tempmyAssignedProducts)
            {
                if (product.qty_in_stock > 0)
                {
                    almyAssignedProducts.Add(product);

                }
            }


            HttpContext.Current.Cache.Insert("myAssignedProducts" + _catID.ToString(), almyAssignedProducts);
        }

 

 



        ArrayList peppe = (ArrayList)HttpContext.Current.Cache["myAssignedProducts" + _catID.ToString()];
        lvProducts.DataSource = peppe;// (ArrayList)HttpContext.Current.Cache["myAssignedProducts" + _catID.ToString()];
        lvProducts.DataBind();
        //}
        //catch (Exception ex)
        //{ 
        //    //lblErr.Text = ex.Message;
        //    //helper.checkConnection();
        //    //Response.Redirect("Catalogo.html");

        //}
    }



    protected void item_dataBound(object sender, ListViewItemEventArgs e)
    {

        //try
        //{


        string _catID = Request.QueryString["CatId"];

        if (string.IsNullOrEmpty(_catID))
            _catID = "40";
        ListViewDataItem dataitem = (ListViewDataItem)e.Item;


        //if (dataitem.DataItemIndex % 4 == 0)
        //// classe margin
        //{
        //    HtmlGenericControl box_prodotto = (HtmlGenericControl)e.Item.FindControl("box_prodotto");
        //    box_prodotto.Style.Add("margin-left", "30px");

        //}

        //if (dataitem.DataItemIndex % 4 == 3)
        //{
        //    HtmlGenericControl box_prodotto = (HtmlGenericControl)e.Item.FindControl("box_prodotto");
        //    box_prodotto.Attributes["class"] = "one-fourth view view-first last";



        //}

        Image imgProd = (Image)e.Item.FindControl("imgProduct");


        imgProd.ImageUrl = "../Handler.ashx?UrlFoto=" + ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).imageurl + "&W_=215&H_=215";

        HtmlGenericControl descProduct = (HtmlGenericControl)e.Item.FindControl("descProduct");
        string name = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).name;
        descProduct.InnerHtml = helper.ShortDesc(name, 132);
        HtmlGenericControl priceProduct = (HtmlGenericControl)e.Item.FindControl("priceProduct");
        HtmlGenericControl divMaskProd = (HtmlGenericControl)e.Item.FindControl("divMaskProd");
        if (isShopVerde)
        {
        //    priceProduct.Attributes["Class"] = "desc_prezzo_home verde";
        //    divMaskProd.Attributes["Class"] = "mask_green";


        }
        else
         {
        //    priceProduct.Attributes["Class"] = "desc_prezzo_home rosso";
        //    divMaskProd.Attributes["Class"] = "mask_red";


        }



        string magento_price = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).price;
        priceProduct.InnerHtml ="€. "+ helper.FormatCurrency(magento_price);


        HtmlAnchor linkDettaglio_1 = (HtmlAnchor)e.Item.FindControl("linkDettaglio");
        HtmlAnchor linkDettaglio = (HtmlAnchor)e.Item.FindControl("lnkDettaglio_1");

        name = name.Replace(" ", "-");

 
       // linkDettaglio.HRef = helper.GetAbsoluteUrl() + "shop" + _pathUrl + "/" + name + ".html";
        linkDettaglio.HRef = "mProdDettaglio.aspx?CatId=" + _catID + "&ProdId=" + ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).product_id;

        
        //if (linkDettaglio.HRef!=null)
        //    linkDettaglio_1.HRef = linkDettaglio.HRef;



        //helper.writeXmlRewriterRules(_catID.ToString(), ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).product_id, name, _pathUrl);

        /*per gestire il tasto aggiungi al carrello direttamente dalla lista dei prodotti in catalogo
        LinkButton lnkbrnAddToCart = (LinkButton)e.Item.FindControl("lnkbrnAddToCart");
        if (((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).qty_in_stock > 0)
        {

            lnkbrnAddToCart.Text = ((Ez.Newsletter.MagentoApi.CategoryAssignedProduct)(dataitem.DataItem)).product_id;
        }
        else
         
                
            lnkbrnAddToCart.Enabled = false;*/
        //}
        //catch (Exception ex)
        //{

        //    throw;
        //}



    }

    protected void IsPagerVisible(object sender, EventArgs e)
    {


        //pagerEventi.Visible =
        //Utility.IsPagerVisible(pagerEventi, objEventi);
    }

   
}
