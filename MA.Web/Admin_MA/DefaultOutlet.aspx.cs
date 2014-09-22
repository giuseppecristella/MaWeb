using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

public partial class DefaultOutlet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RunCommandButton(Object src, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "CancellaArticolo")
        {
            DataSetMateraArredamentiTableAdapters.OutletTableAdapter taOutlet = new DataSetMateraArredamentiTableAdapters.OutletTableAdapter();
            taOutlet.Delete(int.Parse(GridView1.Rows[index].Cells[2].Text));

           

            // cancello anche l'immagine rappresentativa dell'articolo

            string pathFoto = GridView1.Rows[index].Cells[9].Text;

            string nomeFile = pathFoto.Replace("img/outlet/", "");
            GridView1.DataBind();
            //try
            //{
            //    File.Delete(Server.MapPath("~/img/outlet/") + nomeFile);

            //}
            //catch (Exception ex)
            //{

            //}
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int lastCellIndex = e.Row.Cells.Count - 1;
            ImageButton deleteButton = (ImageButton)e.Row.Cells[0].Controls[0];
            deleteButton.OnClientClick =
              "if (!window.confirm('Cancellare Articolo?')) return false;";
        }
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
       string idOutlet= GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
       Response.Redirect("InsertUpdateOutlet.aspx?IdOutlet=" + idOutlet);
    }
}
