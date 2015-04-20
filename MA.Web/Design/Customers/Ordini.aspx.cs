using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Repository;

public partial class Ordini : BasePage
{
  protected void Page_Load(object sender, EventArgs e)
  { }
  protected void pagerOrdini_PreRender(object sender, EventArgs e)
  {
    var utente = Page.User.Identity.Name;
    var user = Membership.GetUser(utente);
    
    if (user == null) return;
    string idMagentoUser = user.Comment;

    var orders = _repository.GetOrders(new Filter { FilterOperator = LogicalOperator.Eq, Key = "customer_id", Value = idMagentoUser });
    pagerOrdini.Visible = (orders.Count > pagerOrdini.PageSize);

    lvOrd.DataSource = orders;
    lvOrd.DataBind();
  }

  protected void lvDataBound(object sender, ListViewItemEventArgs e)
  {
    var item = (ListViewDataItem)e.Item;
    var order = item.DataItem as Order;
    if (order == null) return;

    var lblIdOrd = item.FindControl("lblIdOrd") as Literal;
    if (lblIdOrd != null) lblIdOrd.Text = order.increment_id;

    var lblDataOrd = item.FindControl("lblDataOrd") as Literal;
    var orderDate = Convert.ToDateTime(order.created_at);
    if (lblDataOrd != null) lblDataOrd.Text = orderDate.ToString();

    var lblSpedOrd = item.FindControl("lblSpedOrd") as Literal;
    if (lblSpedOrd != null) lblSpedOrd.Text = order.shipping_name;

    var lblQty = item.FindControl("lblQty") as Literal;
    if (lblQty != null)
    {
      lblQty.Text = order.total_qty_ordered;
      lblQty.Text = lblQty.Text.Substring(0, lblQty.Text.IndexOf('.'));
    }

    var lblTotOrd = item.FindControl("lblTotOrd") as Literal;
    if (lblTotOrd != null)
    {
      lblTotOrd.Text = order.grand_total;
      lblTotOrd.Text = Helper.FormatCurrency(lblTotOrd.Text);
    }

    var lblStatoOrd = item.FindControl("lblStatoOrd") as Literal;
    if (lblStatoOrd == null) return;

    var statoOrd = order.status;
    switch (statoOrd)
    {
      case "canceled":
        lblStatoOrd.Text = "annullato";
        break;
      case "pending":
        lblStatoOrd.Text = "in carico";
        break;
      case "completo":
        lblStatoOrd.Text = "completo";
        break;
    }
    var lnkbtnInfoOrdine = e.Item.FindControl("lnkbtnInfoOrdine") as LinkButton;
    if (lnkbtnInfoOrdine != null) lnkbtnInfoOrdine.PostBackUrl = string.Format("InfoOrdine/{0}", order.increment_id);
  }
}
