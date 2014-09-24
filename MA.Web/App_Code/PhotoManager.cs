using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

public class PhotoManager
{
  //GetPhotoSliderHome
  public static DataTable GetPhotoSliderHome()
  {
    /*modifica per altri siti! devo recuperare l'album home in base al tipo*/
    DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlbum = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
    DataTable dtAlbum = taAlbum.GetAlbumByCaption("HOME");
    DataSetVepAdminTableAdapters.PhotosTableAdapter taPhotos = new DataSetVepAdminTableAdapters.PhotosTableAdapter();
    DataTable dtPhotos = taPhotos.GetPhotosByPos(int.Parse(dtAlbum.Rows[0]["AlbumID"].ToString()));
    return dtPhotos;
  }

  //ritorna l'elenco delle foto ordinate per posizione nell'album
  public static DataTable GetPhotosByPos(int AlbumID)
  {
    DataSetVepAdminTableAdapters.PhotosTableAdapter taPhotos = new DataSetVepAdminTableAdapters.PhotosTableAdapter();
    DataTable dtPhotos = taPhotos.GetPhotosByPos(AlbumID);
    return dtPhotos;
  }

  // Metodi relativi alle foto
  public static Stream GetPhoto(int photoid, PhotoSize size)
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("MSSql34290.GetPhoto", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@PhotoID", photoid));
        command.Parameters.Add(new SqlParameter("@Size", (int)size));
        bool filter = !(HttpContext.Current.User.IsInRole("Friends") || HttpContext.Current.User.IsInRole("Administrators"));
        command.Parameters.Add(new SqlParameter("@IsPublic", filter));
        connection.Open();
        object result = command.ExecuteScalar();
        try
        {
          return new MemoryStream((byte[])result);
        }
        catch
        {
          return null;
        }
      }
    }
  }

  public static Stream GetPhoto(PhotoSize size)
  {
    string path = HttpContext.Current.Server.MapPath("~/Images/");
    switch (size)
    {
      case PhotoSize.Small:
        //path += "placeholder-100.jpg";
        path += "placeholder-100.png";
        break;
      case PhotoSize.Medium:
        path += "placeholder-100.png";
        break;
      case PhotoSize.Large:
        path += "placeholder-100.png";
        break;
      default:
        path += "placeholder-100.png";
        break;
    }
    return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
  }

  public static Stream GetFirstPhoto(int albumid, PhotoSize size)
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("GetFirstPhoto", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@AlbumID", albumid));
        command.Parameters.Add(new SqlParameter("@Size", (int)size));
        bool filter = !(HttpContext.Current.User.IsInRole("Friends") || HttpContext.Current.User.IsInRole("Administrators"));
        command.Parameters.Add(new SqlParameter("@IsPublic", filter));
        connection.Open();
        object result = command.ExecuteScalar();
        try
        {
          return new MemoryStream((byte[])result);
        }
        catch
        {
          return null;
        }
      }
    }
  }

  public static List<Photo> GetPhotos(int AlbumID)
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("GetPhotos", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@AlbumID", AlbumID));
        bool filter = !(HttpContext.Current.User.IsInRole("Friends") || HttpContext.Current.User.IsInRole("Administrators"));
        command.Parameters.Add(new SqlParameter("@IsPublic", filter));
        connection.Open();
        List<Photo> list = new List<Photo>();
        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            Photo temp = new Photo(
                (int)reader["PhotoID"],
                (int)reader["AlbumID"],
                (string)reader["Caption"]);
            list.Add(temp);
          }
        }
        return list;
      }
    }
  }

  public static List<Photo> GetPhotos()
  {
    return GetPhotos(GetRandomAlbumID());
  }

  public static void AddPhoto(int AlbumID, string Caption, byte[] BytesOriginal, int ordine)
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("AddPhoto", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@AlbumID", AlbumID));
        command.Parameters.Add(new SqlParameter("@Caption", Caption));
        command.Parameters.Add(new SqlParameter("@BytesOriginal", BytesOriginal));
        command.Parameters.Add(new SqlParameter("@BytesFull", ResizeImageFile(BytesOriginal, 600)));
        command.Parameters.Add(new SqlParameter("@BytesPoster", ResizeImageFile(BytesOriginal, 198)));
        command.Parameters.Add(new SqlParameter("@BytesThumb", ResizeImageFile(BytesOriginal, 100)));
        command.Parameters.Add(new SqlParameter("@Photo_Ordine", ordine));
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
  }

  // funzione per cancellare tutte le foto di un album
  public static void RemovePhoto(int PhotoID)
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("RemovePhoto", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@PhotoID", PhotoID));
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
  }

  public static void EditPhoto(string Caption, int PhotoID)
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("EditPhoto", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@Caption", Caption));
        command.Parameters.Add(new SqlParameter("@PhotoID", PhotoID));
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
  }

  // Metodi relativi agli album
  public static List<Album> GetAlbums()
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("GetAlbums", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        bool filter = !(HttpContext.Current.User.IsInRole("Friends") || HttpContext.Current.User.IsInRole("Administrators"));
        command.Parameters.Add(new SqlParameter("@IsPublic", filter));
        connection.Open();
        List<Album> list = new List<Album>();
        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            Album temp = new Album(
                (int)reader["AlbumID"],
                (int)reader["NumberOfPhotos"],
                (string)reader["Caption"],
                (bool)reader["IsPublic"]);
            list.Add(temp);
          }
        }
        return list;
      }
    }
  }

  public static byte[] MyResizeImageFileOld(System.Web.UI.WebControls.FileUpload fileUpImage, int targetSize)
  {
    using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(fileUpImage.FileBytes)))
    {
      Size newSize = CalculateDimensions(oldImage.Size, targetSize);
      using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb))
      {
        using (Graphics canvas = Graphics.FromImage(newImage))
        {
          canvas.SmoothingMode = SmoothingMode.AntiAlias;
          canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
          canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
          canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
          MemoryStream m = new MemoryStream();
          string filePath = HttpContext.Current.Server.MapPath("~\\img\\outlet\\") + fileUpImage.FileName;
          FileStream imageResizedFile = new FileStream(filePath, FileMode.OpenOrCreate);
          newImage.Save(imageResizedFile, ImageFormat.Jpeg);
          imageResizedFile.Close();
          return m.GetBuffer();
        }
      }
    }
  }

  public static bool CheckDimensions(byte[] imageFile, int targetWidth)
  {
    bool isOverSize = false;
    using (System.Drawing.Image Image = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
    {
      if (Image.Size.Width > targetWidth)
        isOverSize = true;
    }
    return isOverSize;
  }

  public static void AddAlbum(string Caption)
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("AddAlbum", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@Caption", Caption));
        command.Parameters.Add(new SqlParameter("@IsPublic", true));
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
  }

  public static void RemoveAlbum(int AlbumID)
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("RemoveAlbum", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@AlbumID", AlbumID));
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
  }

  public static void EditAlbum(string Caption, bool IsPublic, int AlbumID)
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("EditAlbum", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@Caption", Caption));
        command.Parameters.Add(new SqlParameter("@IsPublic", IsPublic));
        command.Parameters.Add(new SqlParameter("@AlbumID", AlbumID));
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
  }

  public static int GetFotoCount(int AlbumID)
  {
    DataSetVepAdminTableAdapters.PhotosTableAdapter taAlb = new DataSetVepAdminTableAdapters.PhotosTableAdapter();
    DataTable dtFoto = taAlb.GetFotoByAlbumID(AlbumID);
    return dtFoto.Rows.Count;
  }

  public static string GetNomeAlbum(int AlbumID)
  {
    string nomeAlbume = "";
    DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlb = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
    DataTable dtInfoAlb = taAlb.GetInfoAlbumbyID(AlbumID);
    nomeAlbume = dtInfoAlb.Rows[0]["Caption"].ToString();
    return nomeAlbume;
  }

  public static bool isNewsLinked(int News_ID)
  {
    bool isLink = false;
    DataSetVepAdminTableAdapters.AlbumsTableAdapter taAlb = new DataSetVepAdminTableAdapters.AlbumsTableAdapter();
    DataTable dtAlb = taAlb.GetIdAlbum(News_ID);
    if (dtAlb.Rows.Count != 0)
    {
      isLink = true;
    }
    return isLink;
  }

  public static int GetRandomAlbumID()
  {
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
      using (SqlCommand command = new SqlCommand("GetNonEmptyAlbums", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        connection.Open();
        List<Album> list = new List<Album>();
        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            Album temp = new Album((int)reader["AlbumID"], 0, "", false);
            list.Add(temp);
          }
        }
        try
        {
          Random r = new Random();
          return list[r.Next(list.Count)].AlbumID;
        }
        catch
        {
          return -1;
        }
      }
    }
  }

  public static MemoryStream MyResizeImageFile(string pathFile, byte[] imageByte, int targetWidth, int targetHeight, Bitmap peppe)
  {
    // Impostare le opzioni di risposta
    HttpContext.Current.Response.ContentType = "image/png";
    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Public);
    HttpContext.Current.Response.BufferOutput = false;
    MemoryStream mImage;
    if (!string.IsNullOrEmpty(pathFile))
    {
      string path = "";
      string filePath = "";
      if (pathFile == "~\\")
      {
        path = "~\\img/foto/";
        filePath = HttpContext.Current.Server.MapPath(path) + "standard.jpg";
      }
      else
      {
        path = pathFile.Replace(Path.GetFileName(pathFile), "");
        filePath = HttpContext.Current.Server.MapPath(path) + Path.GetFileName(pathFile);
      }
      FileStream imageFile = new FileStream(filePath, FileMode.Open);
      int buffersize = (int)imageFile.Length;
      byte[] imageFileByte = new byte[buffersize];
      imageFile.Read(imageFileByte, 0, buffersize);
      imageFile.Close();
      mImage = new MemoryStream(imageFileByte);
    }
    else
    {
      mImage = new MemoryStream(imageByte);
      if (peppe != null)
      {
        System.Drawing.Image oldImage = peppe;
        Size newSize = MyCalculateDimensions(oldImage.Size, targetWidth, targetHeight);
        using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height))
        {
          using (Graphics canvas = Graphics.FromImage(newImage))
          {
            canvas.DrawImage(peppe, new Rectangle(new Point(0, 0), newSize));
            MemoryStream m = new MemoryStream();
            newImage.Save(m, ImageFormat.Png);
            return m;
          }
        }
      }
    }
    using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(mImage))
    {
      Size newSize = MyCalculateDimensions(oldImage.Size, targetWidth, targetHeight);
      using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb))
      {
        using (Graphics canvas = Graphics.FromImage(newImage))
        {
          canvas.SmoothingMode = SmoothingMode.AntiAlias;
          canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
          canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
          canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
          MemoryStream m = new MemoryStream();
          newImage.Save(m, ImageFormat.Jpeg);
          return m;
        }
      }
    }
  }

  private static Size MyCalculateDimensions(Size oldSize, int targetWidth, int targetHeight)
  {
    Size newSize = new Size();
    int width = oldSize.Width;
    int height = oldSize.Height;
    int mWidth = targetWidth;
    int mHeight = targetHeight;
    bool doWidthResize = (mWidth > 0 && width > mWidth && width > mHeight);
    bool doHeightResize = (mHeight > 0 && height > mHeight && height > mWidth);
    //only resize if the image is bigger than the max
    if (doWidthResize || doHeightResize)
    {
      int iStart;
      Decimal divider;
      if (doWidthResize)
      {
        iStart = width;
        divider = Math.Abs((Decimal)iStart / (Decimal)mWidth);
        width = mWidth;
        height = (int)Math.Round((Decimal)(height / divider));
        // controllo l'altezza
        if (height < targetHeight)
        {
          iStart = height;
          divider = Math.Abs((Decimal)iStart / (Decimal)mHeight);
          height = mHeight;
          width = (int)Math.Round((Decimal)(width / divider));
        }
      }
      else
      {
        iStart = height;
        divider = Math.Abs((Decimal)iStart / (Decimal)mHeight);
        height = mHeight;
        width = (int)Math.Round((Decimal)(width / divider));
        if (width < targetWidth)
        {
          iStart = width;
          divider = Math.Abs((Decimal)iStart / (Decimal)mWidth);
          width = mWidth;
          height = (int)Math.Round((Decimal)(height / divider));
        }
      }
    }
    newSize.Width = width;
    newSize.Height = height;
    return newSize;
  }

  private static Size MyCalculateDimensions_(Size oldSize, int targetWidth, int targetHeight)
  {
    Size newSize = new Size();
    if (oldSize.Height > oldSize.Width) //orientamento verticale
    {
      //ridimensiono in proporzione rispetto alla larghezza
      newSize.Width = targetWidth;
      newSize.Height = (int)(oldSize.Height * ((float)targetWidth / (float)oldSize.Width));
      //if (newSize.Height < targetHeight) // controllo la nuova altezza calcolata
      //    // ridimensiono rispetto all'altezza 
      //    newSize.Height = targetHeight;
    }
    else //orientamento orizzontale
    {
      //ridimensiono in proporzione rispetto alla larghezza
      newSize.Width = targetWidth;
      newSize.Height = (int)(oldSize.Height * ((float)targetWidth / (float)oldSize.Width));
      if (newSize.Height < targetHeight) // controllo la nuova altezza calcolata
      {
        newSize.Height = targetHeight;
        newSize.Height = (int)(oldSize.Height * ((float)targetWidth / (float)oldSize.Width));
      }
    }
    return newSize;
  }

  // Funzioni di supporto
  private static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
  {
    using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
    {
      Size newSize = CalculateDimensions(oldImage.Size, targetSize);
      using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb))
      {
        using (Graphics canvas = Graphics.FromImage(newImage))
        {
          canvas.SmoothingMode = SmoothingMode.AntiAlias;
          canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
          canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
          canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
          MemoryStream m = new MemoryStream();
          newImage.Save(m, ImageFormat.Jpeg);
          return m.GetBuffer();
        }
      }
    }
  }

  private static Size CalculateDimensions(Size oldSize, int targetSize)
  {
    Size newSize = new Size();
    if (oldSize.Height > oldSize.Width)
    {
      newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
      newSize.Height = targetSize;
    }
    else
    {
      newSize.Width = targetSize;
      newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
    }
    return newSize;
  }

  public static ICollection ListUploadDirectory()
  {
    DirectoryInfo d = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/Upload"));
    return d.GetFileSystemInfos("*.www.google.itaasdasdasdasdasdaxcvxcvxcvxvxcvxvjpg");
  }
}