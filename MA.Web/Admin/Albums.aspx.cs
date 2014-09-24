using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
public partial class Admin_Albums_aspx : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }
  protected void _OnCreated(object sender, ListViewItemEventArgs e)
  {
    if (e.Item.ItemType.ToString() != "EmptyItem")
    {
      DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlbums = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
      ListViewDataItem dataItem = (ListViewDataItem)e.Item;
      string albumID = lvAlbums.DataKeys[dataItem.DisplayIndex].Value.ToString();
      DataTable dtAlbums = taAlbums.GetInfoAlbumbyID(int.Parse(albumID));
      Label lblLinked = (Label)(e.Item.FindControl("lblLinkedtoNews"));
      Image imgCount = (Image)(e.Item.FindControl("imgCount"));
      Image imgLinked = (Image)(e.Item.FindControl("imgLinked"));
      if (PhotoManager.GetFotoCount(int.Parse(albumID)) > 0)
      {
        imgCount.ImageUrl = "~/Admin/images/ball_blue_16.png";
      }
      if (dtAlbums.Rows[0]["NewsEventoID"].ToString() != "")
      {
        lblLinked.Text = "Si";
        imgLinked.ImageUrl = "~/Admin/images/ball_blue_16.png";
      }
    }
  }
  protected void _OnItemCommand(object sender, ListViewCommandEventArgs e)
  {
    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
    string albumID = lvAlbums.DataKeys[dataItem.DisplayIndex].Value.ToString();
    if (e.CommandName == "cancella")
    {
      DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlbum = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
      List<Photo> list = new List<Photo>();
      list = PhotoManager.GetPhotos(int.Parse(albumID));
      for (int i = 0; i < list.Count; i++)
      {
        PhotoManager.RemovePhoto(list[i].AlbumID);
      }
      taAlbum.Delete(int.Parse(albumID));
    }
    else if (e.CommandName == "modifica")
    {
      Response.Redirect("Photos.aspx?AlbumID=" + albumID);
    }
    lvAlbums.DataBind();
  }
}