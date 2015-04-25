<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Default_r.master" AutoEventWireup="true"
    CodeFile="EsitoTransazione.aspx.cs" Inherits="shop_EsitoTransazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div class="wrapper_pepp">
        <div id="container">
            <div id="content">
                <div class="one">
                    <div style="text-align: center" runat="server" id="divEsito">
                        <asp:Literal ID="ltrEsito" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
