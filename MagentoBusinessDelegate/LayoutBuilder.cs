using System.IO;
using MagentoBusinessDelegate.Helpers;

namespace MagentoBusinessDelegate
{
  public class LayoutBuilder
  {
    
    private MailLayout _layout;

    public LayoutBuilder(string name)
    {
      _layout = new MailLayout
      {
        Html = ReadTemplateFromFile(name)
      };
    }

    public LayoutBuilder AddName(string value)
    {
      _layout.Html = _layout.Html.Replace(TemplatePlaceholder.Name, value);
      return this;
    }

    public LayoutBuilder AddShipmentHolder(string value)
    {
      _layout.Html = _layout.Html.Replace(TemplatePlaceholder.ShipmentHolder, value);
      return this;
    }

    public LayoutBuilder AddShipmentAddress(string value)
    {
      _layout.Html = _layout.Html.Replace(TemplatePlaceholder.ShipmentAddress, value);
      return this;
    }

    public LayoutBuilder AddInvoiceHolder(string value)
    {
      _layout.Html = _layout.Html.Replace(TemplatePlaceholder.InvoiceHolder, value);
      return this;
    }

    public LayoutBuilder AddInvoiceAddress(string value)
    {
      _layout.Html = _layout.Html.Replace(TemplatePlaceholder.InvoiceAddress, value);
      return this;
    }

    public LayoutBuilder AddTotalShipment(string value)
    {
      _layout.Html = _layout.Html.Replace(TemplatePlaceholder.TotalShipment, value);
      return this;
    }

    public LayoutBuilder AddOrderNumber(string value)
    {
      _layout.Html = _layout.Html.Replace(TemplatePlaceholder.OrderNumber, value);
      return this;
    }

    public LayoutBuilder AddTotalOrder(string value)
    {
      _layout.Html = _layout.Html.Replace(TemplatePlaceholder.TotalOrder, value);
      return this;
    }

    public LayoutBuilder AddOrderItem(string value)
    {
      _layout.Html = _layout.Html.Replace(TemplatePlaceholder.OrderItem, value);
      return this;
    }


    private void AddField(string field, string value)
    {
      _layout.Html = _layout.Html.Replace(field, value);
    }

    public MailLayout Build()
    {
      return _layout;
    }

    private static string ReadTemplateFromFile(string fileName)
    {
      // var fileName = HttpContext.Current.Server.MapPath(Utility.SearchConfigValue(html_template));
      var output = "";
      if (!File.Exists(fileName))
        return output;
      var stFile = File.OpenText(fileName);
      output = stFile.ReadToEnd();
      stFile.Close();
      return output;
    }
  }

  public class MailLayout
  {
    private string _html;

    public string Html
    {
      get { return _html; }
      set { _html = value; }
    }

  }
}
