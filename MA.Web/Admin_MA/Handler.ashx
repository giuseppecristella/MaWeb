<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.IO;
using System.Web;

public class Handler : IHttpHandler {

	public bool IsReusable {
		get {
			return true;
		}
	}
	
	public void ProcessRequest (HttpContext context) {
		// Impostare le opzioni di risposta
		context.Response.ContentType = "image/jpeg";
		context.Response.Cache.SetCacheability(HttpCacheability.Public);
		context.Response.BufferOutput = false;
		// Impostare il parametro Size
		PhotoSize size;
		switch (context.Request.QueryString["Size"]) {
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
		if (context.Request.QueryString["PhotoID"] != null && context.Request.QueryString["PhotoID"] != "") {
			id = Convert.ToInt32(context.Request.QueryString["PhotoID"]);
			stream = PhotoManager.GetPhoto(id, size);
		} else {
			id = Convert.ToInt32(context.Request.QueryString["AlbumID"]);
			stream = PhotoManager.GetFirstPhoto(id, size);
		}
		// Recuperare la foto dal database. Se non viene restituito alcun elemento, recuperare la foto predefinita "segnaposto"
		if (stream == null) stream = PhotoManager.GetPhoto(size);
		// Scrivere il flusso immagini nel flusso di risposta
		const int buffersize = 1024 * 16;
		byte[] buffer = new byte[buffersize];
		int count = stream.Read(buffer, 0, buffersize);
		while (count > 0) {
			context.Response.OutputStream.Write(buffer, 0, count);
			count = stream.Read(buffer, 0, buffersize);
		}
	}

}