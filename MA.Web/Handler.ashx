<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web;

public class Handler : IHttpHandler
{

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

    public void ProcessRequest(HttpContext context)
    {
        // Impostare le opzioni di risposta
        context.Response.ContentType = "image/jpeg";
        context.Response.Cache.SetCacheability(HttpCacheability.Public);
        context.Response.BufferOutput = false;



        // la foto non viene presa dal db!!
        if (context.Request.QueryString["Path"] != null && context.Request.QueryString["Path"] != "")
        {

            string pathFoto = context.Request.QueryString["Path"];
            // preparo lo stream e lo mostro
            

            // controllo se devo ridimensionarla ulteriormente

            if ((!string.IsNullOrEmpty((string)context.Request.QueryString["W_"])) &&
                (!string.IsNullOrEmpty((string)context.Request.QueryString["H_"])))
            {
                int imgWidth = int.Parse((string)context.Request.QueryString["W_"]);
                int imgHeight = int.Parse((string)context.Request.QueryString["H_"]);
                
                
                MemoryStream m = PhotoManager.MyResizeImageFile(pathFoto, new byte[0],imgWidth, imgHeight,null);

                byte[] newImageByte = m.GetBuffer();


                //HttpContext.Current.Response.ContentType = "image/PNG";
                
              //  HttpContext.Current.Response.OutputStream.Write(newImageByte, 0, newImageByte.Length);


                
                System.Drawing.Image original = Bitmap.FromStream(m);
                original.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Png);
            }




        }//UrlFoto contiene l'url completo della foto es: http://www.materarredamenti.it/images/foto.jpg
        else if (context.Request.QueryString["UrlFoto"] != null && context.Request.QueryString["UrlFoto"] != "")
        {

            string urlFoto = context.Request.QueryString["UrlFoto"];
            // preparo lo stream e lo mostro


            // controllo se devo ridimensionarla ulteriormente

            if ((!string.IsNullOrEmpty((string)context.Request.QueryString["W_"])) &&
                (!string.IsNullOrEmpty((string)context.Request.QueryString["H_"])))
            {
                int imgWidth = int.Parse((string)context.Request.QueryString["W_"]);
                int imgHeight = int.Parse((string)context.Request.QueryString["H_"]);


                HttpWebRequest MyRequest = (HttpWebRequest)WebRequest.Create(urlFoto);

                HttpWebResponse response = (HttpWebResponse)
                           MyRequest.GetResponse();

                
                
                // we will read data via the response stream
                Stream stream = response.GetResponseStream();

                Bitmap strimg = new Bitmap(stream);

                const int buffersize = 1024 * 16;
                byte[] buffer = new byte[buffersize];
                int count = stream.Read(buffer, 0, buffersize);
                while (count > 0)
                {

                    count = stream.Read(buffer, 0, buffersize);
                }


                MemoryStream m = PhotoManager.MyResizeImageFile("", buffer, imgWidth, imgHeight, strimg);

                byte[] newImageByte = m.GetBuffer();


                /*prova sovrapposizione*/


                //string s2 = HttpContext.Current.Server.MapPath("~/images/prova.png");


                //MemoryStream mImage = new MemoryStream(newImageByte);
                //System.Drawing.Image original = Bitmap.FromStream(mImage);
                //Graphics gra = Graphics.FromImage(original);
                //Bitmap logo = new Bitmap(s2);
                //gra.DrawImage(logo, new Point(0, 0));

                HttpContext.Current.Response.ContentType = "image/PNG";
                //original.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Png);
                HttpContext.Current.Response.OutputStream.Write(newImageByte, 0, newImageByte.Length);
            }




        }

        else// foto presa dal db
        {

            // Impostare il parametro Size
            PhotoSize size;
            switch (context.Request.QueryString["Size"])
            {
                case "S":
                    size = PhotoSize.Small;
                    break;
                case "M":
                    size = PhotoSize.Medium;
                    break;
                case "L":
                    size = PhotoSize.Large;
                    break;
                default:
                    size = PhotoSize.Original;
                    break;
            }
            // Impostare il parametro PhotoID
            Int32 id = -1;
            Stream stream = null;
            if (context.Request.QueryString["PhotoID"] != null && context.Request.QueryString["PhotoID"] != "")
            {

                string strPhotoID = context.Request.QueryString["PhotoID"].Replace(".jpg", "");
                id = Convert.ToInt32(strPhotoID);

                stream = PhotoManager.GetPhoto(id, size);
            }
            else
            {
                id = Convert.ToInt32(context.Request.QueryString["AlbumID"]);
                stream = PhotoManager.GetFirstPhoto(id, size);
            }
            // Recuperare la foto dal database. Se non viene restituito alcun elemento, recuperare la foto predefinita "segnaposto"
            if (stream == null) stream = PhotoManager.GetPhoto(size);
            // Scrivere il flusso immagini nel flusso di risposta


            // controllo se devo ridimensionarla ulteriormente

            if ((!string.IsNullOrEmpty((string)context.Request.QueryString["W_"])) &&
                (!string.IsNullOrEmpty((string)context.Request.QueryString["H_"])))
            {
                int imgWidth = int.Parse((string)context.Request.QueryString["W_"]);
                int imgHeight = int.Parse((string)context.Request.QueryString["H_"]);

                int buffersize = (int)stream.Length;
                byte[] buffer = new byte[buffersize];
                int count = stream.Read(buffer, 0, buffersize);
                while (count > 0)
                {
                    
                    count = stream.Read(buffer, 0, buffersize);
                }


                MemoryStream m = PhotoManager.MyResizeImageFile("", buffer, imgWidth, imgHeight,null);

                byte[] newImageByte = m.GetBuffer();
                HttpContext.Current.Response.OutputStream.Write(newImageByte, 0, newImageByte.Length);
            }
            else
            {


                const int buffersize = 1024 * 16;
                byte[] buffer = new byte[buffersize];
                int count = stream.Read(buffer, 0, buffersize);
                while (count > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, count);
                    count = stream.Read(buffer, 0, buffersize);
                }
            }
        }

    }
}