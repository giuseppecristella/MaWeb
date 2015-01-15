using System;
using System.Collections.Generic;
using System.Web.UI;
using System.IO;
using System.Data;

public partial class AddModNews : System.Web.UI.Page
{
  string idTipo = "";
  protected void Page_Load(object sender, EventArgs e)
  {
    DivError.Visible = false;
    string idNews = Request.QueryString["NewsID"];
    idTipo = Request.QueryString["tipo"];
    if (idNews != null)
    {
      Session["NewsIDInserita"] = int.Parse(idNews);
      // si tratta di una modifica
      if ((txtTitoloNews.Text == "") && (txtData.Text == "") && (FCKeditor1.Value == ""))
      {
        //sto caricando una news da modificare
        DataSetVepAdminTableAdapters.NewsTableAdapter taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
        DataTable dtNews = taNews.GetDataByID(int.Parse(idNews));
        News_ID.Text = idNews;
        txtTitoloNews.Text = dtNews.Rows[0]["Titolo"].ToString();
        txtData.Text = dtNews.Rows[0]["Data"].ToString();
        //txtAutore.Text = dtNews.Rows[0]["Autore"].ToString();
        //               txtFonte.Text = dtNews.Rows[0]["Fonte"].ToString();
        txtDescrizione.Text = dtNews.Rows[0]["Descrizione"].ToString();
        imgFotoArticolo.ImageUrl = "~/" + dtNews.Rows[0]["UrlFotoHome"].ToString();
        if ((imgFotoArticolo.ImageUrl != "") && (imgFotoArticolo.ImageUrl != "~/") && (imgFotoArticolo.ImageUrl != "~/img/Foto/standard.jpg"))
        {
          lnkCancFoto.Visible = true;
          imgFotoArticolo.Visible = true;
          FileUploadFoto.Visible = false;
          ButtonUploadFoto.Visible = false;
        }
        else
        {
          imgFotoArticolo.Visible = false;
          FileUploadFoto.Visible = true;
          ButtonUploadFoto.Visible = true;
        }
        //Fotogallery
        if (PhotoManager.isNewsLinked(int.Parse(idNews)))
        {
          imgCancFotoG.Visible = true;
          txtFotoGallery.Text = "FotoAlbum associato";
          btnFotoAlbum.Text = "MODIFICA FotoAlbum";
          btnFotoAlbum.CssClass = "button blue";
        }
        else
        {
          imgCancFotoG.Visible = false;
          txtFotoGallery.Text = "Nessun FotoAlbum associato";
          btnFotoAlbum.Text = "ASSOCIA FotoAlbum";
          btnFotoAlbum.CssClass = "button green";
        }
        txtNomeFile.Text = dtNews.Rows[0]["Allegati"].ToString().Replace("public/allegati/", "");
        if ((txtNomeFile.Text != "Nessun file allegato") && (txtNomeFile.Text != ""))
        {
          lnkCancAllegato.Visible = true;
          FileUploadAllegati.Visible = false;
          ButtonUploadAllegati.Visible = false;
        }
        else
        {
          txtNomeFile.Text = "Nessun file allegato";
          lnkCancAllegato.Visible = false;
          FileUploadAllegati.Visible = true;
          ButtonUploadAllegati.Visible = true;
        }
        FCKeditor1.Value = dtNews.Rows[0]["Testo"].ToString();
        //uso il campo autore per ved. se visualizzare la news in homepage
        chkboxPrjHome.Checked = false;// (bool.Parse(dtNews.Rows[0]["Autore"].ToString()));
        // devo prendermi anche i path degli allegati e delle foto e salvare queste info nel var di sessione
        Session["UrlFotoHome"] = dtNews.Rows[0]["UrlFotoHome"].ToString();
        Session["UrlAllegato"] = dtNews.Rows[0]["Allegati"].ToString();
        Session["DataInserimento"] = dtNews.Rows[0]["Data"].ToString();
      }
      ButtonAgg.Visible = true;
      ButtonInsert.Visible = false;
      trFotoGallery.Visible = true;
    }
    else
    {
      if (txtTitoloNews.Text == "") //si tratta del pageload di una nuova news
      {
        string allegati = (string)Session["UrlAllegato"];
        string PathStdFotoHome = Utility.SearchConfigValue("pathFotoNews") + Utility.SearchConfigValue("standardFotoName");
        ButtonAgg.Visible = false;
        ButtonInsert.Visible = true;
        Session["UrlFotoHome"] = PathStdFotoHome.Remove(0, 2);
        imgFotoArticolo.ImageUrl = PathStdFotoHome;
        previewFoto.HRef = PathStdFotoHome;
        lnkCancFoto.Visible = false;
        imgFotoArticolo.Visible = false;
        FileUploadFoto.Visible = true;
        ButtonUploadFoto.Visible = true;
        lnkCancAllegato.Visible = false;
      }
    }
  }
  protected void CancellaAllegato(object sender, EventArgs e)
  {
    string pathAllegatoFromConfig = Utility.SearchConfigValue("pathAllegatiNews");
    string pathAllegato = Server.MapPath(pathAllegatoFromConfig.Replace("/", "\\"));
    string nomeFile = txtNomeFile.Text.Replace(pathAllegatoFromConfig.Remove(0, 2), "");
    try
    {
      File.Delete(pathAllegato + nomeFile);
      Session["UrlAllegato"] = "";
      txtNomeFile.Text = "Nessun file allegato";
      lnkCancAllegato.Visible = false;
      FileUploadAllegati.Visible = true;
      ButtonUploadAllegati.Visible = true;
    }
    catch (Exception ex)
    {
      DivError.Visible = true;
      DivSuccess.Visible = false;
      LabelError.Text = ex.Message;
    }
  }
  protected void CancellaFoto(object sender, EventArgs e)
  {
    // ~/img/FotoArticoli/
    string pathFotoFromConfig = Utility.SearchConfigValue("pathFotoNews");
    string pathFoto = Server.MapPath(pathFotoFromConfig.Replace("/", "\\"));
    string nomeFile = imgFotoArticolo.ImageUrl.Replace("~/" + pathFotoFromConfig.Remove(0, 2), "");
    string PathStdFotoHome = Utility.SearchConfigValue("pathFotoNews") + Utility.SearchConfigValue("standardFotoName");
    try
    {
      File.Delete(pathFoto + nomeFile);
      Session["UrlFotoHome"] = PathStdFotoHome.Remove(0, 2);
      imgFotoArticolo.ImageUrl = PathStdFotoHome;
      previewFoto.HRef = PathStdFotoHome;
      lnkCancFoto.Visible = false;
      imgFotoArticolo.Visible = false;
      FileUploadFoto.Visible = true;
      ButtonUploadFoto.Visible = true;
    }
    catch (Exception ex)
    {
      DivError.Visible = true;
      DivSuccess.Visible = false;
      LabelError.Text = ex.Message;
    }
  }
  //Pulsante di INSERIMENTO della News
  /* scrivo anche la regola nel file RewriterConfing.xml*/
  protected void ButtonInsert_Click(object sender, EventArgs e)
  {
    string idScuola = (string)Session["ddlScuola"];
    string urlFotoHome = (string)Session["UrlFotoHome"];
    string allegati = (string)Session["UrlAllegato"];
    try
    {
      if (urlFotoHome == "")
      {
        urlFotoHome = Utility.SearchConfigValue("pathFotoNews") + Utility.SearchConfigValue("standardFotoName");
      }
      DataSetVepAdminTableAdapters.NewsTableAdapter taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
      string inHome = "";
      if (chkboxPrjHome.Checked) inHome = "si"; else inHome = "no";
      int idNews = Convert.ToInt32(taNews.InsertNewsRetID("_fonte",
        txtTitoloNews.Text,
        FCKeditor1.Value,
        System.Convert.ToDateTime(txtData.Text),
         chkboxPrjHome.Checked.ToString(), //AUTORE ->inHome
        txtDescrizione.Text,
        idTipo,
        urlFotoHome,
        allegati));
      Session["NewsIDInserita"] = idNews;
      Session["CaptionAlbumNews"] = txtTitoloNews.Text;
      News_ID.Text = idNews.ToString();
      //scrivo la regola per l'url rewriting
      /*      
            Blog:           0
            Evento          1
            Promozione      5
            casa.           2
            manu.           3
            cucina.         4   */
      //switch (idTipo)
      //{
      //  case "0":
      //    Utility.writeXmlRewriterRules("BlogPost", "Id", idNews.ToString(), txtTitoloNews.Text, "");
      //    break;
      //  case "1":
      //    Utility.writeXmlRewriterRules("EventoDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
      //    break;
      //  case "2":
      //    Utility.writeXmlRewriterRules("SuggDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
      //    break;
      //  case "3":
      //    Utility.writeXmlRewriterRules("SuggDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
      //    break;
      //  case "4":
      //    Utility.writeXmlRewriterRules("SuggDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
      //    break;
      //  case "5":
      //    Utility.writeXmlRewriterRules("PromoDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
      //    break;
      //}
      Response.Redirect("~/Admin/ManageNews.aspx?tipo=" + idTipo);
    }
    catch (Exception ex)
    {
      DivSuccess.Visible = false;
      DivError.Visible = true;
      LabelError.Text = ex.Message;
    }
  }
  //Pulsante di AGGIORNAMENTO della News
  protected void ButtonAgg_Click(object sender, EventArgs e)
  {
    int idNews = (int)Session["NewsIDInserita"];
    DataSetVepAdminTableAdapters.NewsTableAdapter taNews = new DataSetVepAdminTableAdapters.NewsTableAdapter();
    string allegati = (string)Session["UrlAllegato"];
    string urlFotoHome = (string)Session["UrlFotoHome"];
    // string data = (string)Session["DataInserimento"];
    string data = txtData.Text;
    string idScuola = (string)Session["ddlScuola"];
    string inHome = "";
    if (chkboxPrjHome.Checked) inHome = "si"; else inHome = "no";
    //scrivo la regola per l'url rewriting
    /*      
          Blog:           0
          Evento          1
          Promozione      5
          casa.           2
          manu.           3
          cucina.         4   */
    //switch (idTipo)
    //{
    //  case "0":
    //    Utility.writeXmlRewriterRules("BlogPost", "Id", idNews.ToString(), txtTitoloNews.Text, "");
    //    break;
    //  case "1":
    //    Utility.writeXmlRewriterRules("EventoDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
    //    break;
    //  case "2":
    //    Utility.writeXmlRewriterRules("SuggDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
    //    break;
    //  case "3":
    //    Utility.writeXmlRewriterRules("SuggDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
    //    break;
    //  case "4":
    //    Utility.writeXmlRewriterRules("SuggDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
    //    break;
    //  case "5":
    //    Utility.writeXmlRewriterRules("PromoDettaglio", "Id", idNews.ToString(), txtTitoloNews.Text, "");
    //    break;
    //}
    try
    {
      News_ID.Text = idNews.ToString();
      taNews.UpdateNewsEventi("_fonte",
        txtTitoloNews.Text,
        FCKeditor1.Value,
        System.Convert.ToDateTime(System.Convert.ToDateTime(data).ToShortDateString())
        , chkboxPrjHome.Checked.ToString(),
      txtDescrizione.Text,
        idTipo,
        urlFotoHome,
        allegati, idNews
        );
      DivSuccess.Visible = true;
      DivError.Visible = false;
      Response.Redirect("~/Admin/ManageNews.aspx?tipo=" + idTipo);
    }
    catch (Exception ex)
    {
      LabelError.Text = ex.Message;
      DivSuccess.Visible = false;
      DivError.Visible = true;
    }
  }
  protected void ButtonUploadFoto_Click(object sender, EventArgs e)
  {
    string pathFotoFromConfig = Utility.SearchConfigValue("pathFotoNews");
    string fileName = Server.HtmlEncode(FileUploadFoto.FileName);
    string filePath = Server.MapPath(pathFotoFromConfig.Replace("/", "\\"));
    string extension = System.IO.Path.GetExtension(fileName);
    //string filePath = Server.MapPath("~\\img\\FotoArticoli\\");
    // controlliamo se il controllo FileUploadFoto contiene un file da caricare
    if (FileUploadFoto.HasFile)
    {
      if ((extension.ToUpper() == ".JPG") || (extension.ToUpper() == ".PNG"))
      {
        int fileSize = FileUploadFoto.PostedFile.ContentLength;
        // consento l'upload di file con dimensione < di 1mb!
        if (fileSize < 1100000)
        {
          // se si, aggiorniamo il path del file
          filePath += FileUploadFoto.FileName;
          // salviamo il file nel percorso calcolato
          FileUploadFoto.SaveAs(filePath);
          Session["UrlFotoHome"] = pathFotoFromConfig.Remove(0, 2) + FileUploadFoto.FileName;
          imgFotoArticolo.ImageUrl = pathFotoFromConfig + FileUploadFoto.FileName;
          lnkCancFoto.Visible = true;
          imgFotoArticolo.Visible = true;
          FileUploadFoto.Visible = false;
          ButtonUploadFoto.Visible = false;
          previewFoto.HRef = "../img/foto/" + FileUploadFoto.FileName;
        }
        else
        {
          LabelError.Text = "Attenzione: La foto eccede le dimensioni massime consentite (1Mb).";
          DivSuccess.Visible = false;
          DivError.Visible = true;
        }
      }
      else
      {
        DivSuccess.Visible = false;
        DivError.Visible = true;
        LabelError.Text = "Attenzione: Verificare che la foto sia nel formato *.jpg oppure *.png";
      }
    }
    else
    {
      DivSuccess.Visible = false;
      DivError.Visible = true;
      LabelError.Text = "Attenzione: Devi prima selezionare una foto attraverso il tasto 'Sfoglia'.";
    }
  }
  protected void ButtonUploadAllegati_Click(object sender, EventArgs e)
  {
    string pathAllegatoFromConfig = Utility.SearchConfigValue("pathAllegatiNews");
    string filePath = Server.MapPath(pathAllegatoFromConfig.Replace("/", "\\"));
    //string filePath = Server.MapPath("~\\public\\allegati\\");
    if (FileUploadAllegati.HasFile)
    {
      // se si, aggiorniamo il path del file
      filePath += FileUploadAllegati.FileName;
      // salviamo il file nel percorso calcolato
      FileUploadAllegati.SaveAs(filePath);
      Session["UrlAllegato"] = pathAllegatoFromConfig.Remove(0, 2) + FileUploadAllegati.FileName;
      txtNomeFile.Text = ((string)Session["UrlAllegato"]).Replace("public/allegati/", "");
      lnkCancAllegato.Visible = true;
      FileUploadAllegati.Visible = false;
      ButtonUploadAllegati.Visible = false;
    }
    else
    {
      DivSuccess.Visible = false;
      DivError.Visible = true;
      LabelError.Text = "Attenzione: Devi prima selezionare un allegato attraverso il tasto 'Sfoglia'.";
    }
  }
  protected void ButtonAnnulla_Click(object sender, EventArgs e)
  {
    Response.Redirect("~/Admin/ManageNews.aspx");
  }
  protected void BtnGalleryArt_Click(object sender, EventArgs e)
  {
    int idNews = (int)Session["NewsIDInserita"];
    if (idNews != 0)
    {
      string caption = (string)Session["CaptionAlbumNews"];
      DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlbums = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
      int albumID = 0;
      string idScuola = (string)Session["ddlScuola"];
      if (Request.QueryString["NewsID"] == null)
      {
        albumID = Convert.ToInt32(taAlbums.InsertAlbumRetID(caption, true, idNews));
        //nuova news inserita faccio una redirect e nella sessione ho già l'id_news!
        Response.Redirect("~/Admin/Photos.aspx?AlbumID=" + albumID.ToString());
      }
      else
      {
        DataTable dtAlbum = taAlbums.GetIdAlbum(idNews);
        if (dtAlbum.Rows.Count == 0)
        {
          albumID = System.Convert.ToInt32(taAlbums.InsertAlbumRetID(txtTitoloNews.Text, true, idNews));
        }
        else
        {
          albumID = int.Parse(dtAlbum.Rows[0]["AlbumID"].ToString());
        }
        //si tratta di una modifica l'id_news la ottengo dalla querystring, quindi setto la var di sessione
        Session["NewsIDInserita"] = int.Parse(Request.QueryString["NewsID"]);
        Response.Redirect("~/Admin/Photos.aspx?AlbumID=" + albumID.ToString());
      }
    }
    else
    {
      //errore devi prima inserire la news e poi puoi associare la fotogallery
      LabelError.Text = "Attenzione: Devi prima inserire l'articolo.";
      DivError.Visible = true;
      DivSuccess.Visible = false;
    }
  }
  protected void CancellaFotoGallery(object sender, ImageClickEventArgs e)
  {
    string idNews = Request.QueryString["NewsID"];
    DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlbum = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
    DataTable dtAlbID = taAlbum.GetIdAlbum(int.Parse(idNews));
    if (dtAlbID.Rows.Count > 0)
    {
      string albumID = dtAlbID.Rows[0]["AlbumID"].ToString();
      List<Photo> list = new List<Photo>();
      list = PhotoManager.GetPhotos(int.Parse(albumID));
      for (int i = 0; i < list.Count; i++)
      {
        PhotoManager.RemovePhoto(list[i].AlbumID);
      }
      taAlbum.Delete(int.Parse(albumID));
      imgCancFotoG.Visible = false;
      txtFotoGallery.Text = "Nessun FotoAlbum associato";
      btnFotoAlbum.Text = "ASSOCIA FotoAlbum";
      btnFotoAlbum.CssClass = "button green";
    }
    else
    {
      //messaggio notifica 
    }
  }
}