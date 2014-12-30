using System;
using System.Data;

public partial class Azienda : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    DataSetVepAdminTableAdapters.AlbumsTableAdapter taNews = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
    DataTable dtNews = taNews.GetInfoAlbums();
  }
}
