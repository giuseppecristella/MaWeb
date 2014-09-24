using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;

public partial class Ordini : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

          if (!helper.checkConnection())
           {
               HttpContext.Current.Cache.Insert("apiUrl", Utility.SearchConfigValue("apiUrl"));
               HttpContext.Current.Cache.Insert("sessionId", helper.getConnection(Utility.SearchConfigValue("apiUrl"), Utility.SearchConfigValue("apiUser"), Utility.SearchConfigValue("apiPsw")));

           }


     


        //in query string leggerò l'id dell'utente per ora prendo l'utente id=2
        
        ArrayList arrDettOrdine = new ArrayList();
        if (!IsPostBack)
        {

           
            string incrementId = Request.QueryString["IncrementId"];
            lblNumOrdine.Text = incrementId;
            OrderInfo DettOrdine = Ez.Newsletter.MagentoApi.Order.Info((string)HttpContext.Current.Cache["apiUrl"],(string) HttpContext.Current.Cache["sessionId"], new object[] { int.Parse(incrementId) });
            var serializer = new Conversive.PHPSerializationLibrary.Serializer();

            foreach (var orderProduct in DettOrdine.items)
            {
                //orderProduct.product_options
                Hashtable ht = (Hashtable)serializer.Deserialize(orderProduct.product_options);
                Hashtable ht2 = (Hashtable)ht["info_buyRequest"];

                Product p = new Product();
                p.product_id = (string)ht2["product_id"];
                p.price = (string)ht2["price"];
                p.qty = (string)ht2["qty"];
                p.name = (string)ht2["name"];
                p.imageurl = "";
                arrDettOrdine.Add(p);
            }
            ltrSpedNome.Text =
                DettOrdine.shipping_address.firstname + " " + DettOrdine.shipping_address.lastname;
            
            ltrSpedIndirizzo.Text = DettOrdine.shipping_address.street;
            ltrSpedCitta.Text = DettOrdine.shipping_address.city;
            ltrSpedCap.Text = DettOrdine.shipping_address.postcode;


            ltrBillNome.Text =
            DettOrdine.billing_address.firstname + " " + DettOrdine.billing_address.lastname;

            ltrBillIndirizzo.Text = DettOrdine.billing_address.street;
            ltrBillCitta.Text = DettOrdine.billing_address.city;
            ltrBillCap.Text = DettOrdine.billing_address.postcode;

            ltrSubTot.Text = helper.FormatCurrency(DettOrdine.subtotal);
            ltrSomma.Text = helper.FormatCurrency(DettOrdine.grand_total);
            ltrSped.Text = helper.FormatCurrency(DettOrdine.shipping_amount);
            lvOrd.DataSource = arrDettOrdine;
            lvOrd.DataBind();
           
        }
    }

    protected void lvDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem dataItem = (ListViewDataItem)e.Item;
        //Literal lblIdOrd = (Literal)e.Item.FindControl("lblIdOrd");
        //lblIdOrd.Text = ((Ez.Newsletter.MagentoApi.Order)(dataItem.DataItem)).increment_id;


        //Literal lblDataOrd = (Literal)e.Item.FindControl("lblDataOrd");
        //lblDataOrd.Text = ((Ez.Newsletter.MagentoApi.Order)(dataItem.DataItem)).created_at;

        Literal lblnomeprod = (Literal)e.Item.FindControl("ltrnomeprod");

        lblnomeprod.Text = ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).name;

        //  Label lblmodprod = (Label)e.Item.FindControl("lblmodprod");
        //  lblmodprod.Text = ((Ez.Newsletter.MagentoApi.Product)(e.Item.DataItem)).model;

        Literal lblprezzoun = (Literal)e.Item.FindControl("ltrprezzoun");
        lblprezzoun.Text = helper.FormatCurrency(((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).price);



        Literal ltrProdId = (Literal)e.Item.FindControl("ltrProdId");
        ltrProdId.Text = ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).product_id;

        Literal txtqtaprod = (Literal)e.Item.FindControl("txtqtaprod");

        txtqtaprod.Text = ((Ez.Newsletter.MagentoApi.Product)(dataItem.DataItem)).qty;

        Literal lblprezzotot = (Literal)e.Item.FindControl("ltrprezzotot");
        string totale = (decimal.Parse(lblprezzoun.Text) * int.Parse(txtqtaprod.Text)).ToString();

        lblprezzotot.Text = totale.Replace(".", ",");


        
    }
}
