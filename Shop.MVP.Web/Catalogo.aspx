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
           <div runat="server" id="box_prodotto" style="margin-top: 40px; margin-right: 10px; border: 1px solid #dfdfdf;"
                                        class="one-fourth view view-first">
                <div style="width: 215px; height: 215px; overflow: hidden;">
                    <p  class="desc_prezzo_home verde"><%# Eval("Price") %></p>
                    <asp:Image ImageUrl='<%# Eval("ImageUrl") %>' Width="215" Height="215" runat="server" ID="imgProduct"></asp:Image>
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
