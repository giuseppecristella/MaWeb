using System;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using Ez.Newsletter.MagentoApi;
using MagentoComunication.Enum;
using MagentoRepository.Helpers;
using WSCryptDecrypt = it.sella.ecomms2s.WSCryptDecrypt;
public partial class Riepilogo : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var customers = Page.User.Identity.Name;

        if (string.IsNullOrEmpty(customers)) Response.Redirect("~/Design/Accedi.aspx");

        if (IsPostBack) return;
        if (SessionFacade.CartId.Equals(0)) Response.Redirect("Carrello.aspx");

        var shippingMethods = _repository.GetShippingMethods(SessionFacade.CartId);
        if (!shippingMethods.Any()) return;

        // Binding carrello
        lvCart.DataSource = Cart.Products;
        lvCart.DataBind();

        var cartTotal = Cart.Total.ToString();
        ltrSubTot.Text = Cart.Total.ToString("C");
        ltrSped.Text = Helper.FormatCurrency(shippingMethods.FirstOrDefault().price);
        // totale + spese spedizione
        ltrSomma.Text = (decimal.Parse(ltrSped.Text, CultureInfo.GetCultureInfo("it-IT").NumberFormat) + decimal.Parse(cartTotal)).ToString("C");
    }

    protected void lvCartOnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var item = (ListViewDataItem)e.Item;
        if (item == null || item.DataItem as Product == null) return;
        var product = item.DataItem as Product;

        var lblnomeprod = (Literal)e.Item.FindControl("lblnomeprod");
        lblnomeprod.Text = product.name;
        var lblprezzoun = (Label)e.Item.FindControl("lblprezzoun");
        lblprezzoun.Text = Helper.FormatCurrency(product.price);
        var imgprod = (Image)e.Item.FindControl("imgprod");
        imgprod.ImageUrl = "../Handler.ashx?UrlFoto=" + product.imageurl + "&W_=100&H_=100";
        var txtqta = (Label)e.Item.FindControl("txtqta");
        txtqta.Text = product.qty;
        var lblprezzotot = (Label)e.Item.FindControl("lblprezzotot");
        var totale = (decimal.Parse(lblprezzoun.Text, CultureInfo.GetCultureInfo("it-IT").NumberFormat) * int.Parse(txtqta.Text)).ToString();
        // usare string.Format currency
        lblprezzoun.Text = string.Format("€. {0}", lblprezzoun.Text);
        lblprezzotot.Text = string.Format("Tot. €. {0}", totale.Replace(".", ","));

        // Url pagina dettaglio 
        var lnkbtnDettProd = item.FindControl("lnkbtnDettProd") as LinkButton;
        if (lnkbtnDettProd != null) lnkbtnDettProd.PostBackUrl = string.Format("Dettaglio/{0}/{1}", product.product_id, product.name.Replace(" ", "-").TrimEnd('-').ToLowerInvariant());
    }

    protected void rptCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    }

    protected void lbOrder_Click(object sender, EventArgs e)
    {
        // controllare se l'ordine è stato già creato e in che stato si trova (<- ha senso? verificare il flusso)
        var orderNum = _repository.CreateOrder(SessionFacade.CartId);
        if (orderNum == 0) return; // Messaggio notifica errore;

        var shopId = Utility.SearchConfigValue("SELLACODE");
        var transactionId = CreateTransactionId(orderNum); //"34az85ord19";
        var encryptedInfos = EncryptInfos(shopId, ConfigurationHelper.SellaCurrencyCode, "1", transactionId);

        if (IsOrderEncrypted(encryptedInfos))
        {
            // qua posso tracciare lo stato dell'ordine prima dell'invio del pagamento 
            //Response.Redirect("https://testecomm.sella.it/gestpay/pagam.asp?a=" + myshoplogin + "&b=" + nodeCrypstedString.InnerText);
            Response.Redirect(string.Format("https://ecomm.sella.it/gestpay/pagam.asp?a={0}&b={1}", shopId, GetCryptedString(encryptedInfos)));
        }
        else
        {
            lblSella.Text = GetTransactionError(encryptedInfos);
            if (!_repository.SetOrderStatus(orderNum, OrderStatusType.Canceled))
            {
                // Log errore annullamento ordine
            }
        }
    }

    #region Private Methods
    private static string CreateTransactionId(int orderNum)
    {
        return string.Format("{0}{1}", orderNum, Guid.NewGuid());
    }

    private XmlNode EncryptInfos(string shopId, string currencyCode, string total, string transactionId)
    {
        var wsCrypt = new WSCryptDecrypt();
        return wsCrypt.Encrypt(shopId, currencyCode, total, transactionId, string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
    }

    private bool IsOrderEncrypted(XmlNode encryptedInfos)
    {
        var nodeTransactionResult = encryptedInfos.SelectSingleNode("descendant::TransactionResult");
        return nodeTransactionResult != null && nodeTransactionResult.InnerText.Equals("OK");
    }

    private string GetCryptedString(XmlNode encryptedInfos)
    {
        var cryptedInfosNode = encryptedInfos.SelectSingleNode("descendant::CryptDecryptString");
        return cryptedInfosNode == null ? string.Empty : cryptedInfosNode.InnerText;
    }

    private string GetTransactionError(XmlNode encryptedInfos)
    {
        var nodeErrorDesc = encryptedInfos.SelectSingleNode("descendant::ErrorDescription");
        return nodeErrorDesc == null ? "Errore transazione, l'ordine sarà annullato" : nodeErrorDesc.InnerText;
    }
}
    #endregion
