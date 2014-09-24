using System;
using System.Data;

public partial class InsertUpdateOutlet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        string idOutlet = Request.QueryString["IdOutlet"];

        if (idOutlet != null)
        {
            //si tratta di una modifica
            Session["IDProdottoOutlet"] = int.Parse(idOutlet);

            if (
           (txtProdotto.Text == "") && (txtProdottoDesc.Text == "") && (txtProdottoDescS.Text == "") &&
            ( txtProdottoPrezzo.Text  == "") && ( txtProdottoPrezzoSconto.Text  == "")
          && (txtProdottoFoto.Text == ""))
            {

                DataSetMateraArredamentiTableAdapters.OutletTableAdapter taOutlet = new DataSetMateraArredamentiTableAdapters.OutletTableAdapter();

                DataTable dtOutlet = taOutlet.GetDataByID(int.Parse(idOutlet));

               
                 
                txtProdotto.Text = dtOutlet.Rows[0]["ProdottoNome"].ToString();
                txtProdottoDesc.Text = dtOutlet.Rows[0]["ProdottoDescHome"].ToString();
                txtProdottoDescS.Text = dtOutlet.Rows[0]["ProdottoDescScheda"].ToString(); 
                txtProdottoPrezzo.Text = dtOutlet.Rows[0]["ProdottoPrezzo"].ToString();
                txtProdottoPrezzoSconto.Text = dtOutlet.Rows[0]["ProdottoPrezzoSconto"].ToString();
                txtProdottoFoto.Text = dtOutlet.Rows[0]["ProdottoFoto"].ToString();

               //string prova = Server.MapPath("~/img/outlet/") + txtProdottoFoto.Text.Replace("/img/outlet/", "").Replace('/','\\');


                imgProdotto.ImageUrl = "~/" + txtProdottoFoto.Text;
            }
            ButtonAgg.Visible = true;
            ButtonInsert.Visible = false;
        }
        else
        {
            ButtonAgg.Visible = false;
            ButtonInsert.Visible = true;
        }

    }
    protected void ButtonInsert_Click1(object sender, EventArgs e)
    {
        string urlFoto = (string) Session["UrlFotoProdOutlet"];

        if (string.IsNullOrEmpty(urlFoto))
        {
            errNoImg.Visible = true;
            artErr.Visible = true;
            artSucc.Visible = false;
            lblErr.Text = "Attenzione verificare che sia stata inserita un immagine.";
        }
        else
        {
            decimal prodPrezzo = 0;
            decimal prodPrezzoScont = 0;

            if ((decimal.TryParse(txtProdottoPrezzo.Text, out prodPrezzo)) && (decimal.TryParse(txtProdottoPrezzoSconto.Text, out prodPrezzoScont)))
            {
                DataSetMateraArredamentiTableAdapters.OutletTableAdapter taOutlet = new DataSetMateraArredamentiTableAdapters.OutletTableAdapter();
                taOutlet.Insert(txtProdotto.Text, txtProdottoDesc.Text, txtProdottoDescS.Text, decimal.Parse(txtProdottoPrezzo.Text),
                    decimal.Parse(txtProdottoPrezzoSconto.Text), true, urlFoto);
                Session["UrlFotoProdOutlet"] = "";
                errNoImg.Visible = false;
                artErr.Visible = false;
                artSucc.Visible = true;
            }
            else
            {
                artErr.Visible = true;
                artSucc.Visible = false;
                lblErr.Text = "Attenzione verificare che il prezzo sia inserito nel formato corretto";
            }

        }

    }
    protected void ButtonAgg_Click(object sender, EventArgs e)
    {
        int idOutlet = (int)Session["IDProdottoOutlet"];
        try
        {
            DataSetMateraArredamentiTableAdapters.OutletTableAdapter taOutlet = new DataSetMateraArredamentiTableAdapters.OutletTableAdapter();
            taOutlet.Update(txtProdotto.Text, txtProdottoDesc.Text, txtProdottoDescS.Text, decimal.Parse(txtProdottoPrezzo.Text), decimal.Parse(txtProdottoPrezzoSconto.Text), true, txtProdottoFoto.Text, idOutlet);
             
        }
        catch (Exception ex)
        {
            artErr.Visible = true;
            artSucc.Visible = false;
            lblErr.Text = ex.Message;
        }
    }

    protected void ButtonUpload_Click(object sender, EventArgs e)
    {       
        string filePath = Server.MapPath("~\\img\\outlet\\");
        // controlliamo se il controllo FileUpload1
        // contiene un file da caricare
        if (FileUpload1.HasFile)
        {
             // controlliamo che stiamo inserendo un immagine
            // Get the name of the file to upload.
            string fileName = Server.HtmlEncode(FileUpload1.FileName);

            // Get the extension of the uploaded file.
            string extension = System.IO.Path.GetExtension(fileName);

            if ((extension.ToUpper() == ".JPG") || (extension.ToUpper() == ".PNG"))
            {
                 
                 int fileSize = FileUpload1.PostedFile.ContentLength;

            // consento l'upload di file con dimensione < di 1mb!
                 if (fileSize < 1100000)
                 {
                     filePath += FileUpload1.FileName;
                     // prima di salvare vado a vedere se devo ridimensionarla ulteriormente!!

                     bool needResize =  PhotoManager.CheckDimensions(FileUpload1.FileBytes, 400);
                     if (needResize)
                     {
                         byte[] FotoRidimensionata = PhotoManager.MyResizeImageFileOld(FileUpload1, 380);

                     }
                     else
                     {
                         // salviamo il file nel percorso calcolato
                         FileUpload1.SaveAs(filePath);
                     }
                     

                     Session["UrlFotoProdOutlet"] = "img" + "/" + "outlet" + "/" + FileUpload1.FileName;
                     txtProdottoFoto.Text = (string)Session["UrlFotoProdOutlet"];

                     imgProdotto.ImageUrl = "~/" + txtProdottoFoto.Text;
                     errNoImg.Visible = false;
                   
                 
                 }
                 else
                 {
                     artErr.Visible = true;
                     artSucc.Visible = false;
                     lblErr.Text = "Attenzione la foto eccede le dimensioni consentite (1Mb).";
                 
                 }


            }
            else
            {
                artErr.Visible = true;
                artSucc.Visible = false;
                lblErr.Text = "Attenzione verificare che la foto sia nel formato .jpg o .png";
            
            }


           



           
        }
    }


}
