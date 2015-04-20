<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Default_r.master" AutoEventWireup="true" CodeFile="Dettaglio.aspx.cs" Inherits="Design_Dettaglio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div id="content">
        <div style="padding: 20px 0 20px 0;" class="one">
        </div>
        <div style="min-height: 580px" class="one">
            <div class="one-half">
                <img runat="server" style="border: 1px solid #dfdfdf;" width="450" src="" alt=""
                    id="mainImage" />
                <div class="clear-line">
                </div>
                <asp:Repeater OnItemDataBound="rptImages_OnItemDataBound" runat="server" ID="rptImages">
                    <ItemTemplate>
                        <ul id="clients">
                            <li><a runat="server" id="prettyThumb" rel="prettyPhoto" href="#">
                                <img height="63" runat="server" id="imgThumb" src="images/product-thumb.png" alt="" /></a>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear-line">
                </div>
                <div class="one-half">
                    <asp:Repeater OnItemDataBound="rptProdAssociati_OnItemDataBound" Visible="false" runat="server"
                        ID="rptProdAssociati">
                        <HeaderTemplate>
                            <h4>Potrebbero anche interessarti:
                            </h4>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <ul style="float: left;" id="clients">
                                <li><a runat="server" id="linkProd" href="#">
                                    <img height="63" runat="server" id="imgProdAss" src="" alt="" />
                                </a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="one-half last dettaglio-prodotto">
                <h1>
                    <asp:Label runat="server" ID="lblNomeProd"></asp:Label></h1>
                <asp:Literal runat="server" ID="prodDescription"></asp:Literal>
                <label>PREZZO: <br /></label>€.<asp:Literal runat="server" ID="prodPrice"></asp:Literal> (Consegna Gratuita)
                <label>PRODUTTORE:</label><asp:Literal runat="server" ID="prodProduttore"></asp:Literal>
                <label>DISPONIBILITA':</label><asp:Literal runat="server" ID="prodScorte"></asp:Literal> PEZZO
                <label><asp:Literal runat="server" ID="prodDisponibilità"></asp:Literal>
                </label>
                <div class="clear-line">
                </div>
                <asp:ImageButton runat="server" ID="btnaddTocart" ImageUrl="images/tasto-carrello.png"
                    Style="border: none;" CssClass="btnImageCart" Text="Aggiungi al Carrello" OnClick="btnaddTocart_Click" />
                <div class="clear">
                </div>
                <div class="clear-line">
                </div>
            </div>
        </div>
        <div runat="server" id="divSpotRosso" visible="false" style="padding: 20px 0 5px 0; height: 70px;">
            <!-- HEADER  -->
            <!-- LOGO -->
            <a style="background: transparent url('images/logo-design.png') no-repeat; display: block; float: left; width: 220px; height: 70px; text-indent: -9999px;"
                id="A1" title="Homepage"
                href="design.html"></a>
            <!--LOGO ENDS  -->
            <div style="background: #D10A11; margin-left: 5px; float: left; width: 614px; height: 70px;">
                <p class="visita_shop">
                    Entra e visita il nostro Shop dedicato all'Arredamento! Mille idee ti aspettano!
                </p>
            </div>
            <div style="float: left; width: 120px; height: 70px;">
                <a style="background: #D10A11 url('images/entra-rosso.png') no-repeat; position: relative; height: 70px; margin-top: 0px; text-indent: 60px; display: block;"
                    href="design.html"
                    class="_carrello_titolo"></a>
            </div>
        </div>
        <div runat="server" id="divSpotVerde" visible="false" style="padding: 20px 0 5px 0; height: 70px;">
            <!-- HEADER  -->
            <!-- LOGO -->
            <a class="banner-tradizione-logo" id="A2" title="Homepage"
                href="#"></a>
            <!--LOGO ENDS  -->
            <div style="background: #76A227; margin-left: 5px; float: left; width: 614px; height: 70px;">
                <p class="visita_shop">
                    Entra e visita il nostro Shop Tradizione! Mille idee ti aspettano!
                </p>
            </div>
            <div style="float: left; width: 120px; height: 70px;">
                <a style="background: #76A227 url('images/entra-rosso.png') no-repeat; position: relative; height: 70px; margin-top: 0px; text-indent: 60px; display: block;"
                    href="tradizione.html"
                    class="_carrello_titolo"></a>
            </div>
        </div>
    </div>
</asp:Content>

