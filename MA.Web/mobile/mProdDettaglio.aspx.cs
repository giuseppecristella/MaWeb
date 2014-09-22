using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;

public partial class mobile_ProdDett : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       

        if (!IsPostBack)
        {

            string _idProd = Request.QueryString["ProdId"];
            Product myProduct = Product.Info((string)HttpContext.Current.Cache["apiUrl"],
                                             (string)HttpContext.Current.Cache["sessionId"], new object[] { _idProd });


            /*categoria 37 -> SHOP VERDE /
             * categoria 47 -> SHOP ROSSO*/

            bool isShopVerde = true;

            /*le categorie 44 e 45 sono riservate ai prodotti in vetrina quindi le escludo*/

            //myProduct.categories
            string idCategoria = "";
            string rootCat = "37";

            if (myProduct.categories.Contains("47"))
                isShopVerde = false;

            foreach (string sCatId in myProduct.categories)
            {


                if (sCatId != "44" && sCatId != "45" && sCatId != "37" && sCatId != "47")
                    idCategoria = sCatId;
            }


          


            /* visualizzo il nome della categoria di appartenenza del prodotto in dettaglio*/
            Category CategoryInfo = Category.Info((string)HttpContext.Current.Cache["apiUrl"],
                                                  (string)HttpContext.Current.Cache["sessionId"],
                                                  new object[] { idCategoria });
            lblCategoria.Text = CategoryInfo.name + " > "
            + myProduct.name;

            lblCategoriaTit.Text = CategoryInfo.name;
            

            //  ltrTitleProd.Text = myProduct.name;

            prodProduttore.Text = myProduct.produttore;
            //   prodModel.Text = myProduct.model;
            prodDescription.Text = myProduct.description;
            // prodNameDesc.Text = myProduct.name;
            prodPrice.Text = helper.FormatCurrency(myProduct.price);



            if (isShopVerde)
            {
                tasto_home.HRef = "mHomeShopV.aspx";
                //Catalogo.aspx?CatId=42
                
            }
            else
            {
                rootCat = "47";
                tasto_home.HRef = "mHomeShopR.aspx";
                


            }
            //goToShop.HRef = "http://www.materarredamenti.it/Shop/Catalogo.aspx?CatId=" + CategoryInfo.category_id;
            tasto_back.HRef = "mCatalogo.aspx?CatId=" + CategoryInfo.category_id;
            lblCategoriaBack.Text = CategoryInfo.name;
            aBackCat.HRef = "mCatalogo.aspx?CatId=" + CategoryInfo.category_id;
                lblCategoriaBack.Text = CategoryInfo.name;

            ProductImage[] myProductImages = ProductImage.List((string)HttpContext.Current.Cache["apiUrl"],
                                                               (string)HttpContext.Current.Cache["sessionId"],
                                                               new object[] { int.Parse(_idProd) });
            ArrayList ulrImages = new ArrayList();
            foreach (ProductImage p in myProductImages)
            {
                if (p.exclude == "1")
                {
                    mainImage.Src = p.url;
                }
                //nel vettore le immagini contengono l'attributo posizione da implementare l'ordine in futuro
                else
                    ulrImages.Add(p.url);

            }
         
        }
    }

    protected void IsPagerVisible(object sender, EventArgs e)
    {


        //pagerEventi.Visible =
        //Utility.IsPagerVisible(pagerEventi, objEventi);
    }

   
}
