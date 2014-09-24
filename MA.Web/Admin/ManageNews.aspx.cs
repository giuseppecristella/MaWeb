using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_ManageNews : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack) //check if the webpage is loaded for the first time.
    {
      if (!String.IsNullOrEmpty(Request.QueryString["tipo"]))
      {
        ddlTipo.SelectedValue = Request.QueryString["tipo"];
      }
    }
  }

  protected void _OnCreated(object sender, ListViewItemEventArgs e)
  {
    if (e.Item.ItemType.ToString() != "EmptyItem")
    {
      DataSetVepAdminTableAdapters.NewsTableAdapter taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
      ListViewDataItem dataItem = (ListViewDataItem)e.Item;
      string newsID = ListViewNews.DataKeys[dataItem.DisplayIndex].Value.ToString();
      DataTable dtNews = taNews.GetDataByID(int.Parse(newsID));
      Label lblAllegato = (Label)(e.Item.FindControl("lblAllAss"));
      Label lbllinkGall = (Label)(e.Item.FindControl("lbllinkGall"));
      Label lblVideo = (Label)(e.Item.FindControl("lblVideoAss"));
      Label lblriga = (Label)(e.Item.FindControl("lblriga"));
      lblriga.Text = (dataItem.DataItemIndex + 1).ToString();
      Image imgPhoto = (Image)(e.Item.FindControl("imgPhoto"));
      Image imgVideo = (Image)(e.Item.FindControl("imgVideo"));
      Image imgAllegato = (Image)(e.Item.FindControl("imgAllegato"));
      if (dtNews.Rows[0]["Allegati"].ToString() != "")
      {
        imgAllegato.Visible = true;
        //lblAllegato.Text = "Si";
        //imgAllegato.ImageUrl = "~/Admin/images/ball_blue_16.png";
      }
    }
  }

  protected void _OnItemCommand(object sender, ListViewCommandEventArgs e)
  {
    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
    string newsID = ListViewNews.DataKeys[dataItem.DisplayIndex].Value.ToString();
    if (e.CommandName == "cancella")
    {
      DataSetMateraArredamentiTableAdapters.NewsTableAdapter taNews = new DataSetMateraArredamentiTableAdapters.NewsTableAdapter();
      taNews.DeleteNewsEventi(int.Parse(newsID));
    }
    else if (e.CommandName == "modifica")
    {
      Response.Redirect("AddModNews.aspx?tipo=" + ddlTipo.SelectedValue + "&NewsID=" + newsID);
    }
    else if (e.CommandName == "fotoGallery")
    {
      DataSetVepAdminTableAdapters.NewsTableAdapter taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
      int idNews = int.Parse(newsID);
      DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlbums = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
      int albumID = 0;
      DataTable dtAlbum = taAlbums.GetIdAlbum(idNews);
      DataTable dtNews = taNews.GetDataByID(idNews);
      string idScuola = (string)Session["ddlScuola"];
      if (dtAlbum.Rows.Count == 0)
      {
        albumID = Convert.ToInt32(taAlbums.InsertAlbumRetID(dtNews.Rows[0]["Descrizione"].ToString(), true, idNews));
        //nuova news inserita faccio una redirect e nella sessione ho già l'id_news!
        Response.Redirect("~/Admin/Photos.aspx?AlbumID=" + albumID.ToString());
      }
      else
      {
        Response.Redirect("~/Admin/Photos.aspx?AlbumID=" + dtAlbum.Rows[0]["AlbumID"].ToString());
      }
    }
    ListViewNews.DataBind();
  }

  protected void Nuovo_Click(object sender, EventArgs e)
  {
    Response.Redirect("~/Admin/AddModNews.aspx?tipo=" + ddlTipo.SelectedValue);
  }
}
