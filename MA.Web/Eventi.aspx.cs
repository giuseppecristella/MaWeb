using System;
using System.Data;
using System.Web.UI.WebControls;
public partial class Eventi : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      DataSetVepAdminTableAdapters.NewsTableAdapter taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
      DataTable dtNews =
          taNews.GetListaNews("1");
    }
  }

  /*evento onDataBound*/
  protected void IsPagerVisible(object sender, EventArgs e)
  {
    pagerEventi.Visible =
    Utility.IsPagerVisible(pagerEventi, objEventi);
  }

  protected void lvEventiItemDataBound(object sender, ListViewItemEventArgs e)
  {
    ListViewDataItem dataitem = (ListViewDataItem)e.Item;
    string News_ID =
        ((DataSetVepAdmin.NewsRow)(((System.Data.DataRowView)(dataitem.DataItem)).Row)).News_ID.ToString();
    string Titolo =
       ((DataSetVepAdmin.NewsRow)(((System.Data.DataRowView)(dataitem.DataItem)).Row)).Titolo.ToString();
    Utility.writeXmlRewriterRules("EventoDettaglio", "Id", News_ID, Titolo, "");
  }
}
