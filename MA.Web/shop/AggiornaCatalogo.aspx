<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AggiornaCatalogo.aspx.cs"
    Inherits="shop_AggiornaCatalogo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Aggiorna Catalogo
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="lbUpdateCatalog" runat="server" OnClick="lbUpdateCatalog_Click" Text="Aggiorna Catalogo Prodotti"></asp:Button>
        <br />
        <asp:LinkButton ID="lbRewriteMenu" runat="server" OnClick="lbRewriteMenu_Click">Riscrivi Menu delle Categorie</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lbUpdateMagentoSessionId" runat="server" OnClick="lbUpdateMagentoSessionId_Click">Aggiorna connessione Magento</asp:LinkButton>
        <br />
        <br />
        <asp:Label runat="server" ID="lblUpdateCatalog" ForeColor="green"></asp:Label>
    </div>
    </form>
</body>
</html>
