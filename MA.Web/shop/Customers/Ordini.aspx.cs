using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using CookComputing.XmlRpc;
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

 
            //+ " <li><a  href=\"../Index.html\">Torna al sito</a></li>";
        

        if (!IsPostBack)
        {
           
        }
    }

    protected void pagerOrdini_PreRender(object sender, EventArgs e)
    {

         
        //// list orders with filter
        XmlRpcStruct filterOn = new XmlRpcStruct();
        XmlRpcStruct filterParams = new XmlRpcStruct();
        //confronto e valore che voglio cercare in questo caso id=2
        var profile = HttpContext.Current.Profile;
        string utente = Page.User.Identity.Name;
        MembershipUser user = Membership.GetUser(utente);

        string idMagentoUser = user.Comment;

        filterParams.Add("eq", idMagentoUser);
        //nome del parametro
        filterOn.Add("customer_id", filterParams);

        Order[] myOrders = Ez.Newsletter.MagentoApi.Order.List((string)HttpContext.Current.Cache["apiUrl"], (string)HttpContext.Current.Cache["sessionId"], new object[] { filterOn });


        bool isPagerVisible = (myOrders.Length > pagerOrdini.PageSize);
        pagerOrdini.Visible = isPagerVisible;


        Order[] ListaOrdini = myOrders;

        int j = 0;

        for (int i = myOrders.Length-1; i > 0; i--)
        {
            ListaOrdini[j] = myOrders[i];
            j++;
        }

        lvOrd.DataSource = ListaOrdini;
        lvOrd.DataBind();

    }

     

    protected void lvDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem dataItem = (ListViewDataItem)e.Item;
        Literal lblIdOrd = (Literal)e.Item.FindControl("lblIdOrd");
        lblIdOrd.Text = ((Ez.Newsletter.MagentoApi.Order)(dataItem.DataItem)).increment_id;


        Literal lblDataOrd = (Literal)e.Item.FindControl("lblDataOrd");

        DateTime dataOrdine = System.Convert.ToDateTime(((Ez.Newsletter.MagentoApi.Order)(dataItem.DataItem)).created_at);
        lblDataOrd.Text = dataOrdine.ToString();

        Literal lblSpedOrd = (Literal)e.Item.FindControl("lblSpedOrd");
        lblSpedOrd.Text = ((Ez.Newsletter.MagentoApi.Order)(dataItem.DataItem)).shipping_name;

        Literal lblQty = (Literal)e.Item.FindControl("lblQty");
        lblQty.Text = ((Ez.Newsletter.MagentoApi.Order)(dataItem.DataItem)).total_qty_ordered;
        lblQty.Text = lblQty.Text.Substring(0, lblQty.Text.IndexOf('.'));
        Literal lblTotOrd = (Literal)e.Item.FindControl("lblTotOrd");
        lblTotOrd.Text = ((Ez.Newsletter.MagentoApi.Order)(dataItem.DataItem)).grand_total;

        lblTotOrd.Text = helper.FormatCurrency(lblTotOrd.Text);

        Literal lblStatoOrd = (Literal)e.Item.FindControl("lblStatoOrd");

        string statoOrd = ((Ez.Newsletter.MagentoApi.Order)(dataItem.DataItem)).status;

        if (statoOrd=="canceled")
        {
            lblStatoOrd.Text = "annullato";
            


        }
        else if (statoOrd=="pending")
        {
            lblStatoOrd.Text = "in carico";

        }
        else if (statoOrd == "completo")
        {
            lblStatoOrd.Text = "completo";
        }

        

        LinkButton lnkbtnInfoOrdine = (LinkButton)e.Item.FindControl("lnkbtnInfoOrdine");
        lnkbtnInfoOrdine.PostBackUrl = "InfoOrdine.aspx?IncrementId=" +
                                    ((Ez.Newsletter.MagentoApi.Order)(dataItem.DataItem)).increment_id;
    }
}
