<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCShopMenu.ascx.cs" Inherits="Design_UserControls_UCShopMenu" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<ul>
    <li><a href="http://www.materarredamenti.it">VAI AL SITO</a></li>
    <li><a runat="server" id="lbMenuItemHome" href="/Design">Home</a></li>
    <li style="float: right;"><a style="padding-right: 0" href="/Design/Carrello">Carrello(<asp:Label ID="lbCartQty" runat="server"/>)</a></li>
    <asp:Repeater runat="server" ID="rptMenuItems" OnItemDataBound="rptMenuItems_OnItemDataBound">
        <ItemTemplate>
            <li>
                <a href='<%# FriendlyUrl.Href("~/Design/Catalogo/",Eval("name")) %>' id="lbMenuItem" runat="server"><%# Eval("name").ToString().Replace("-"," ") %></a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
