using System;
using System.Collections;
using System.Net.Mail;
using System.Web;
using System.Xml;
using Ez.Newsletter.MagentoApi;
using MagentoBusinessDelegate;
using MagentoComunication.Enum;
using WSCryptDecrypt = it.sella.ecomms2s.WSCryptDecrypt;

public partial class shop_EsitoTransazione : BasePage
{

    private readonly string _errorMsg;
    private readonly string _successMsg;

    public shop_EsitoTransazione()
    {
        _successMsg = "<strong>Operazione conclusa con successo</strong> Gentile Utente, " +
                            "le comunichiamo che l'ordine n. {0} è stato preso in carico.<br> " +
                            "Riceverà al suo indirizzo email la conferma di avvenuto pagamento";

        _errorMsg = "<strong>Si è verificato un errore.</strong> " +
                      "Gentile Utente, le comunichiamo che l'ordine n. {0} è stato annullato. " +
                      "Si prega di eseguire nuovamente la procedura di acquisto.";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        try
        {
            CartHelper.ClearCart();
            var transactionResultNode = GetTransactionResult();
            if (GetTransactionResult() == null) return;
            ltrEsito.Text = "GetTransactionResult ok";
            var orderNumber = GetOrderNumber(transactionResultNode);
            if (orderNumber == null) return;

            var resultResponse = CheckTransactionResult(transactionResultNode);
            ltrEsito.Text += "GetTransactionResult ok";
            if (resultResponse == false)
            {
                ShowMessage(MessageType.Error, string.Format(_errorMsg, orderNumber));
                _repository.SetOrderStatus(int.Parse(orderNumber), OrderStatusType.Canceled);
                return;
            }

            // Recupera l'ordine relativo
            var orderDetails = _repository.GetOrderInfos(int.Parse(orderNumber));

            // recupera le info del customer che ha effettuato l'ordine 
            var customer = _repository.GetCustomerById(int.Parse(orderDetails.customer_id));

            var mailBody = CreateMailLayout(customer, orderDetails, orderNumber);
            SendMailToUser(orderDetails, customer, orderNumber, mailBody);

            ShowMessage(MessageType.Success, string.Format(_successMsg, orderNumber));
            // Aggiorna qta prodotto
        }
        catch (Exception ex)
        {
            var stack = ex.StackTrace ?? ex.StackTrace.ToString();
            //var source = ex.InnerException.Source ?? ex.InnerException.Source.ToString();

            ltrEsito.Text += stack;
        }
    }

    #region Private Methods

    private XmlNode GetTransactionResult()
    {
        var myshoplogin = Utility.SearchConfigValue("SELLACODE"); // "GESPAY54218"
        // Banca Sella ws (crypt / decrypt)
        var wsCrypt = new WSCryptDecrypt();
        var responseToDecrypt = Request.QueryString["b"];
        return wsCrypt.Decrypt(myshoplogin, responseToDecrypt);
    }

    private bool CheckTransactionResult(XmlNode decryptedNode)
    {
        var transactionResultNode = decryptedNode.SelectSingleNode("descendant::TransactionResult");
        return transactionResultNode != null && transactionResultNode.InnerText == "OK";
    }

    private string GetOrderNumber(XmlNode decryptedNode)
    {
        var nodeTransactionId = decryptedNode.SelectSingleNode("descendant::ShopTransactionID");
        return nodeTransactionId == null ? null : nodeTransactionId.InnerText.Substring(0, 6);
    }

    private static void SendMailToUser(OrderInfo orderDetails, Customer customer, string numOrdine, string mailBody)
    {
        var mainMailAddress = Utility.SearchConfigValue("MainMailAddress");
        var mainMailAlias = Utility.SearchConfigValue("MainMailAlias");

        var from = new MailAddress(mainMailAddress, mainMailAlias);
        var to = new MailAddress(orderDetails.customer_email, string.Format("{0} {1}", customer.firstname, customer.lastname));

        var mailMessage = new MailMessage(@from, to)
        {
            Subject = string.Format("Conferma ordine n. {0} dal sito materarredamenti.it", numOrdine),
            IsBodyHtml = true,
            Body = mailBody
        };
        // EMAIL.Bcc.Add("giuseppe.cristella@libero.it");
        var smtpMail = new SmtpClient();
        smtpMail.Send(mailMessage);
    }

    private static string CreateMailLayout(Customer customer, OrderInfo orderDetails, string numOrdine)
    {
        var layoutTemplate = Utility.ReadTemplateFromFile("pathTemplateMail");
        var fileName = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue(layoutTemplate));
        var orderItem = string.Empty;

        foreach (var item in orderDetails.items)
        {
            var deserializedBuyRequest = DeserializeOrderInfos(item);
            if (deserializedBuyRequest == null) continue;

            string itemTotal = GetItemTotal(deserializedBuyRequest);
            if (itemTotal == null) continue;

            orderItem += CreateOrderItem(deserializedBuyRequest, itemTotal);
        }

        var templateHtml = ReplaceTemplatePlaceholder(orderDetails, numOrdine, fileName, orderItem);

        return templateHtml.Html;
    }

    private static MailLayout ReplaceTemplatePlaceholder(OrderInfo orderDetails, string numOrdine, string fileName,
      string orderItem)
    {
        // Refactoring futuro: builder per costruire un oggetto Order con i campi seguenti
        // Reflection sulle proprietà dell'oggetto, cercando il placeholder relativo nel template e sostituendo con il 
        // valore del campo
        var name = string.Format("{0} {1}", orderDetails.billing_address.firstname, orderDetails.billing_address.lastname);
        var shipmentHolder = string.Format("{0} {1}", orderDetails.shipping_address.firstname,
          orderDetails.shipping_address.lastname);
        var shipmentAddress = string.Format("{0} {1} {2}", orderDetails.shipping_address.street,
          orderDetails.shipping_address.city, orderDetails.shipping_address.postcode);
        var invoiceHolder = string.Format("{0} {1}", orderDetails.billing_address.firstname,
          orderDetails.billing_address.lastname);
        var invoiceAddress = string.Format("{0} {1}", orderDetails.billing_address.firstname,
          orderDetails.billing_address.lastname);
        var totalShipment = "€. " + Helper.FormatCurrency(orderDetails.shipping_amount);
        var total = Helper.FormatCurrency(orderDetails.grand_total);

        var layoutBuilder = new LayoutBuilder(fileName);
        var templateHtml = layoutBuilder.AddName(name)
          .AddInvoiceHolder(invoiceHolder).AddInvoiceAddress(invoiceAddress)
          .AddShipmentHolder(shipmentHolder).AddShipmentAddress(shipmentAddress)
          .AddOrderItem(orderItem).AddOrderNumber(numOrdine)
          .AddTotalShipment(totalShipment).AddTotalOrder(total).Build();
        return templateHtml;
    }

    private static string CreateOrderItem(Hashtable deserializedBuyRequest, string itemTotal)
    {
        return
          string.Format(
            "<tr><td width=\"220\" valign=\"middle\" height=\"30\" align=\"left\" style=\"text-align: left; color: #444444; font-weight: bold; border-bottom: 1px dotted #DDDDDD; padding-left: 10px;\">{0}</td> "
            +
            "<td width=\"100\" valign=\"middle\" height=\"30\" align=\"left\" style=\"text-align: left; border-bottom: 1px dotted #DDDDDD;\">{1}</td>"
            + ""
            +
            "<td width=\"100\" valign=\"middle\" height=\"30\" align=\"center\" style=\"text-align: center; border-bottom: 1px dotted #DDDDDD;\">{2}</td><td width=\"100\" valign=\"middle\" height=\"30\" align=\"right\" style=\"text-align: right; border-bottom: 1px dotted #DDDDDD;\">"
            +
            "€. {3}</td><td width=\"90\" valign=\"middle\" height=\"30\" align=\"right\" style=\"text-align: right; border-bottom: 1px dotted #DDDDDD; padding-right: 10px;\">"
            + "€. {4}</td></tr>"
            , (string)deserializedBuyRequest["name"]
            , (string)deserializedBuyRequest["product_id"]
            , (string)deserializedBuyRequest["qty"]
            , Helper.FormatCurrency((string)deserializedBuyRequest["price"])
            , itemTotal);
    }

    private static string GetItemTotal(Hashtable deserializedBuyRequest)
    {
        int qty;
        decimal price;
        if (int.TryParse((string)deserializedBuyRequest["qty"], out qty) == false) return null;
        return decimal.TryParse(Helper.FormatCurrency((string)deserializedBuyRequest["price"]), out price) == false ? null : (qty * price).ToString().Replace(".", ",");
    }

    private static Hashtable DeserializeOrderInfos(OrderProduct orderProduct)
    {
        // deserializza le informazioni ottenute
        var serializer = new Conversive.PHPSerializationLibrary.Serializer();
        var deserializedProductOptions = serializer.Deserialize(orderProduct.product_options) as Hashtable;

        if (deserializedProductOptions == null) return null;
        var deserializedBuyRequest = deserializedProductOptions["info_buyRequest"] as Hashtable;
        if (deserializedBuyRequest == null) return null;
        return deserializedBuyRequest;
    }

    private void ShowMessage(MessageType type, string message)
    {
        var cssClass = "simple-notice";

        if (type == MessageType.Error)
        {
            cssClass = "simple-error";
        }

        divEsito.Attributes["class"] = cssClass;
        ltrEsito.Text = message;
    }

    #endregion
}





