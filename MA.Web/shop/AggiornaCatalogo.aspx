<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AggiornaCatalogo.aspx.cs"
    Inherits="shop_AggiornaCatalogo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Aggiorna Catalogo Prodotti</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="AggiornaURL">Aggiorna URL</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="RiscriviMenuCategorie">Riscrivi Menu delle Categorie</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="AggiornaSessionIdMagento">Aggiorna connessione Magento</asp:LinkButton>
        <br />
        <br />
        <asp:Label runat="server" ID="lblAggCat" ForeColor="green"></asp:Label>
    </div>
    </form>
</body>
</html>
