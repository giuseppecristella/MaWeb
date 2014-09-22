<%@ Page Title="" Language="C#" MasterPageFile="~/shop/Default_r.master" AutoEventWireup="true"
    CodeFile="Home_r.aspx.cs" Inherits="shop_Home_r" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
    <ul runat="server" id="menuCatShop">
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div class="one">
        <div class="slideshow">
            <div id="slides">
                <div id="slider-big">
                    <div class="slides_container big-slider">
                        <!-- SLIDER STARTS-->
                        <!-- SLIDER CONTENT STARTS-->
                        <div class="slide">
                            <img src="images/slideshow/slide-rossa-01.jpg" alt=" " width="960" height="400" />
                        </div>
                        <div class="slide">
                            <img src="images/slideshow/slide-rossa-02.jpg" alt=" " width="960" height="400" />
                        </div>
                        <div class="slide">
                            <img src="images/slideshow/slide-rossa-03.jpg" alt=" " width="960" height="400" />
                        </div>
                        <div class="slide">
                            <img src="images/slideshow/slide-rossa-04.jpg" alt=" " width="960" height="400" />
                        </div>
                    </div>
                    <!-- SLIDESHOW CONTAINER ENDS-->
                </div>
                <div class="slides-nav">
                    <a href="#" class="prev">Previous Slide</a> <a href="#" class="next">Next Slide</a>
                </div>
            </div>
        </div>
        <!-- SLIDER ENDS-->
        <!-- SLIDESHOW ENDS-->
    </div>
    <div class="one">
        <div class="one-third">
            <a href="../Default.aspx" id="tasto-sito">vai al sito </a>
        </div>
        <div class="one-third">
            <a target="blank" href="http://issuu.com/materaarredamenti/docs/emme__00" id="tasto-magazine">
                vai al nostro magazine </a>
        </div>
        <div class="one-third last">
            <a href="tradizione.html" id="tasto-trad">vai allo shop design e casa </a>
        </div>
    </div>
    <div style="padding-top: 40px;" class="one">
        <div class="headline">
            <h4>
                Le offerte del <span style="color: #D10A11;" class="colored">Mese</span></h4>
        </div>
        <asp:ListView runat="server" ID="lvVetrinaRossa" OnItemDataBound="item_dataBound2">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div runat="server" id="box_prodotto2" style="margin-top: 5px; margin-right: 10px;
                    border: 1px solid #dfdfdf;" class="one-fourth view view-first">
                    <div style="width: 215px; height: 215px; overflow: hidden;">
                        <p runat="server" id="priceProduct2" class="desc_prezzo_home rosso">
                        </p>
                        <asp:Image ImageUrl="../Handler.ashx" Width="215" Height="215" runat="server" ID="imgProduct2" />
                    </div>
                    <div class="mask_red">
                        <a style="display: block; height: 100%; text-decoration: none;" runat="server" id="lnkDettaglio_2">
                            <span runat="server" id="descProduct2" class="desc_prodotto_home"></span><span class="link_vedi_dettaglio">
                                Vedi dettaglio</span> </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div style="padding-top: 40px; padding-bottom: 20px;" class="one">
        <div class="headline">
            <h4>
                Le offerte dello Shop <span class="colored">Tradizione</span></h4>
        </div>
        <asp:ListView runat="server" ID="lvVetrinaVerde" OnItemDataBound="item_dataBound">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div runat="server" id="box_prodotto" style="margin-top: 5px; margin-right: 10px;
                    border: 1px solid #dfdfdf;" class="one-fourth view view-first">
                    <div style="width: 215px; height: 215px; overflow: hidden;">
                        <p runat="server" id="priceProduct" class="desc_prezzo_home verde">
                        </p>
                        <asp:Image ImageUrl="../Handler.ashx" Width="215" Height="215" runat="server" ID="imgProduct" />
                    </div>
                    <div class="mask_green">
                        <a style="display: block; height: 100%; text-decoration: none;" runat="server" id="lnkDettaglio_1">
                            <span runat="server" id="descProduct" class="desc_prodotto_home"></span><span class="link_vedi_dettaglio">
                                Vedi dettaglio</span> </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
