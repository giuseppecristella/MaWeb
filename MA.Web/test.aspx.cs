using System;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      /*  string s = Server.MapPath("~/images/scollati.jpg");
        string s2 = Server.MapPath("~/images/prova.png");

        System.Drawing.Image original = Bitmap.FromFile(s);
        Graphics gra = Graphics.FromImage(original);
        Bitmap logo = new Bitmap(s2);
        gra.DrawImage(logo, new Point(380, 250));

        Response.ContentType = "image/JPEG";
        original.Save(Response.OutputStream, ImageFormat.Jpeg);*/
    }
}
