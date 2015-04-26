<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AggiornaCatalogo.aspx.cs" MasterPageFile="~/Design/Default_r.master"
    Inherits="shop_AggiornaCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div>
        <asp:Button ID="lbUpdateCatalog" runat="server" OnClick="lbUpdateCatalog_Click" Text="Aggiorna Catalogo Prodotti"></asp:Button>
        <br />
        <asp:Label runat="server" ID="lblUpdateCatalog" ForeColor="green"></asp:Label>
    </div>
</asp:Content>



