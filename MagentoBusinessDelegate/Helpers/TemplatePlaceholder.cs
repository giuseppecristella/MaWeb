using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagentoBusinessDelegate.Helpers
{
  public static class TemplatePlaceholder
  {
    public const string Name = "##NOME##";
    public const string OrderNumber = "##NUMERO ORDINE##";
    public const string ShipmentHolder = "##SPEDIZIONE_1##";
    public const string ShipmentAddress = "##SPEDIZIONE_2##";
    public const string InvoiceHolder = "##FATT_1##";
    public const string InvoiceAddress = "##FATT_2##";
    public const string OrderItem = "##TR_ORDINE##";
    public const string TotalShipment = "##SPEDIZIONE##";
    public const string TotalOrder = "##TOTALE##";
  }
}
