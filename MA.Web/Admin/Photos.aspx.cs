using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Photos_aspx : System.Web.UI.Page
{
  private bool _refreshState;
  private bool _isRefresh;
  protected override void LoadViewState(object savedState)
  {
    object[] AllStates = (object[])savedState;
    base.LoadViewState(AllStates[0]);
    _refreshState = bool.Parse(AllStates[1].ToString());
    _isRefresh = _refreshState == bool.Parse(Session["__ISREFRESH"].ToString());
  }

  protected override object SaveViewState()
  {
    Session["__ISREFRESH"] = _refreshState;
    object[] AllStates = new object[2];
    AllStates[0] = base.SaveViewState();
    AllStates[1] = !(_refreshState);
    return AllStates;
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack) //check if the webpage is loaded for the first time.
    {
      ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
    }
    int AlbumID = int.Parse((string)Request.QueryString["AlbumID"]);
    DataSetVepAdminTableAdapters.NewsTableAdapter taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
    DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlb = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
    DataTable dtAlb = taAlb.GetInfoAlbumbyID(AlbumID);
    if (!string.IsNullOrEmpty(dtAlb.Rows[0]["NewsEventoID"].ToString()))
    {
      DataTable dtNews = taNews.GetDataByID(int.Parse(dtAlb.Rows[0]["NewsEventoID"].ToString()));
      // lblArticolo.Text = dtNews.Rows[0]["Titolo"].ToString();
    }
    lblNomeAlb.Text = PhotoManager.GetNomeAlbum(AlbumID);
  }

  protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
  {
    if (((Byte[])e.Values["BytesOriginal"]).Length == 0)
      e.Cancel = true;
  }

  protected void AggiungiFoto(object sender, EventArgs e)
  {
    int AlbumID = int.Parse((string)Request.QueryString["AlbumID"]);
    string caption = PhotoCaption.Text;
    byte[] photoBytes = PhotoFile.FileBytes;
    DataSetVepAdminTableAdapters.PhotosTableAdapter taphotos = new DataSetVepAdminTableAdapters.PhotosTableAdapter();
    DataTable dtphotos = taphotos.GetFotoByAlbumID(AlbumID);
    int ordine = dtphotos.Rows.Count + 1;
    PhotoManager.AddPhoto(AlbumID, caption, photoBytes, ordine);
  }

  protected void lnkBackNews_Click(object sender, EventArgs e)
  {
    int AlbumID = int.Parse((string)Request.QueryString["AlbumID"]);
    int idNews = (int)Session["NewsIDInserita"];
    DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlb = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
    DataTable dtAlbum = taAlb.GetInfoAlbumbyID(AlbumID);
    string newsIDfromDB = "";
    if (!string.IsNullOrEmpty(dtAlbum.Rows[0]["NewsEventoID"].ToString()))
    {
      newsIDfromDB = dtAlbum.Rows[0]["NewsEventoID"].ToString();
      if (int.Parse(newsIDfromDB) == idNews)
      {
        Response.Redirect("AddModNews.aspx?NewsID=" + idNews.ToString());
      }
      else
      {
        Response.Redirect("AddModNews.aspx?NewsID=" + newsIDfromDB);
      }
    }
    else
      Response.Redirect("Albums.aspx");
  }

  protected void _OnItemCommand(object sender, ListViewCommandEventArgs e)
  {
    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
    string fotoID =
    lvFoto.DataKeys[dataItem.DisplayIndex].Value.ToString();
    if (e.CommandName == "cancella")
    {
      PhotoManager.RemovePhoto(int.Parse(fotoID));
    }
    lvFoto.DataBind();
  }

  protected void ButtonUploadFoto_Click(object sender, EventArgs e)
  {
    if (!_isRefresh)
    {
      int AlbumID = int.Parse((string)Request.QueryString["AlbumID"]);
      string caption = PhotoCaption.Text;
      byte[] photoBytes = PhotoFile.FileBytes;
      //devo recuperare tutte le foto dell'album per trovare la prima posizione disponibile
      DataSetVepAdminTableAdapters.PhotosTableAdapter taPhotos = new DataSetVepAdminTableAdapters.PhotosTableAdapter();
      DataTable dtPhotos = taPhotos.GetFotoByAlbumID(AlbumID);
      int ordine = dtPhotos.Rows.Count + 1;
      PhotoManager.AddPhoto(AlbumID, caption, photoBytes, ordine);
      lvFoto.DataBind();
      btnChangePos.Visible = true;
    }
  }

  protected void lnkBackAlbumsList_Click(object sender, EventArgs e)
  {
    if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
    {
      Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
    }
  }

  protected void change_pos(object sender, EventArgs e)
  {
    string strarrPos = hdfArrPos.Value;
    string albId = Request.QueryString["AlbumID"];
    string[] splitted = strarrPos.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
    DataSetVepAdminTableAdapters.PhotosTableAdapter taPhoto = new DataSetVepAdminTableAdapters.PhotosTableAdapter();
    DataTable dtPhotos = taPhoto.GetFotoByAlbumID(int.Parse(albId));
    for (int i = 0; i < splitted.Length; i++)
    {
      int PhotoId = 0;
      for (int j = 0; j < dtPhotos.Rows.Count; j++)
      {
        if (dtPhotos.Rows[j]["ordine"].ToString() == splitted[i].ToString())
        {
          PhotoId = int.Parse(dtPhotos.Rows[j]["PhotoID"].ToString());
          int ret = taPhoto.UpdateOrdineFoto(i + 1, PhotoId);
        }
      }
    }
    lvFoto.DataBind();
  }
}