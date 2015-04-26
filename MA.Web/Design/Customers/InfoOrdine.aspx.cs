using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using Microsoft.AspNet.FriendlyUrls;

public partial class Ordini : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var orders = new List<Product>();
        if (IsPostBack) return;
        var incrementId = Request.GetFriendlyUrlSegments()[0];

        lblNumOrdine.Text = incrementId;
        var orderDetail = _repository.GetOrderInfos(int.Parse(incrementId));
        var serializer = new Conversive.PHPSerializationLibrary.Serializer();
        foreach (var orderProduct in orderDetail.items)
        {
            var deserializedProductOptionsBuyRequest = (Hashtable)serializer.Deserialize(orderProduct.product_options);
            var deserializedProductOptions = (Hashtable)deserializedProductOptionsBuyRequest["info_buyRequest"];
            var p = new Product
            {
                product_id = (string)deserializedProductOptions["product_id"],
                price = (string)deserializedProductOptions["price"],
                qty = (string)deserializedProductOptions["qty"],
                name = (string)deserializedProductOptions["name"],
                imageurl = string.Empty
            };
            orders.Add(p);
        }
        BindOrderToForm(orderDetail);
        lvOrders.DataSource = orders;
        lvOrders.DataBind();
    }

    private void BindOrderToForm(OrderInfo orderDetail)
    {
        ltrSpedNome.Text = string.Format("{0} {1}", orderDetail.shipping_address.firstname,
          orderDetail.shipping_address.lastname);
        ltrSpedIndirizzo.Text = orderDetail.shipping_address.street;
        ltrSpedCitta.Text = orderDetail.shipping_address.city;
        ltrSpedCap.Text = orderDetail.shipping_address.postcode;
        ltrBillNome.Text = string.Format("{0} {1}", orderDetail.billing_address.firstname,
          orderDetail.billing_address.lastname);
        ltrBillIndirizzo.Text = orderDetail.billing_address.street;
        ltrBillCitta.Text = orderDetail.billing_address.city;
        ltrBillCap.Text = orderDetail.billing_address.postcode;
        ltrSubTot.Text = Helper.FormatCurrency(orderDetail.subtotal);
        ltrSomma.Text = Helper.FormatCurrency(orderDetail.grand_total);
        ltrSped.Text = Helper.FormatCurrency(orderDetail.shipping_amount);
    }

    protected void lvDataBound(object sender, ListViewItemEventArgs e)
    {
        var item = (ListViewDataItem)e.Item;
        var product = (Product)item.DataItem;
        if (product == null) return;

        var lblnomeprod = e.Item.FindControl("ltrnomeprod") as Literal;
        if (lblnomeprod != null) lblnomeprod.Text = product.name;

        var lblprezzoun = item.FindControl("ltrprezzoun") as Literal;
        if (lblprezzoun != null) lblprezzoun.Text = Helper.FormatCurrency(product.price);

        var ltrProdId = item.FindControl("ltrProdId") as Literal;
        if (ltrProdId != null) ltrProdId.Text = product.product_id;

        var txtqtaprod = item.FindControl("txtqtaprod") as Literal;
        if (txtqtaprod != null) txtqtaprod.Text = product.qty;

        var lblprezzotot = item.FindControl("ltrprezzotot") as Literal;

        if (lblprezzoun != null && lblprezzotot != null)
        {
            var totale = (decimal.Parse(lblprezzoun.Text) * int.Parse(txtqtaprod.Text)).ToString();
            lblprezzotot.Text = totale.Replace(".", ",");
        }
    }
}
