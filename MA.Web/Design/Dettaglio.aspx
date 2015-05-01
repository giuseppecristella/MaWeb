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
                <label>
                    PREZZO:
                    <br />
                </label>
                <span style="font-size: 1.3em;">€.</span><span style="font-size: 1.3em; font-weight: 800; padding: 10px"><asp:Literal runat="server" ID="prodPrice"></asp:Literal></span>(Consegna Gratuita)
                <div class="clear-line"></div>
                <label>PRODUTTORE:</label><asp:Literal runat="server" ID="prodProduttore"></asp:Literal>
                <div class="clear-line"></div>
                <label>DISPONIBILITA':</label><asp:Literal runat="server" ID="prodScorte"></asp:Literal>
                PEZZI
                <label>
                    <span style="font-size: 1.3em; font-weight: 800; padding: 10px">
                        <asp:Literal runat="server" ID="prodDisponibilità"></asp:Literal></span>
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
    </div>
</asp:Content>

