<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Shop.Web.Mvp.Catalogo" %>

<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:ListView runat="server" ID="lvCatalog">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <div>
                    <p><%# Eval("Price") %></p>
                    <asp:Image ImageUrl="<%# Eval("ImageUrl") %>" Width="215" Height="215" runat="server" ID="imgProduct"></asp:Image>
                </div>
                <div>
                    <span><%# Eval("Name") %></span>
                    <span><%# Eval("Description") %></span>
                    <a href='<%# FriendlyUrl.Href("~/Shop", "Dettaglio", Eval("Name")) %>'>
                        <span class="link_vedi_dettaglio">Vedi dettaglio</span>
                    </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
