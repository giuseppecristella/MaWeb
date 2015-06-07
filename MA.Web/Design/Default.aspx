<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Default_r.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="shop_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div class="one">
        <div class="slideshow">
            <div id="slides">
                <div id="slider-big">
                    <div class="slides_container big-slider">
                        <div class="slide">
                            <img src="images/slideshow/slider_01.jpg" alt=" " width="960" height="400" />
                        </div>
                        <%--<div class="slide">
                            <img src="images/slideshow/slide-rossa-01.jpg" alt=" " width="960" height="400" />
                        </div>--%>
                        <div class="slide">
                            <img src="images/slideshow/slider_02.jpg" alt=" " width="960" height="400" />
                        </div>
                        <div class="slide">
                            <img src="images/slideshow/slider_03.jpg" alt=" " width="960" height="400" />
                        </div>
                        <div class="slide">
                            <img src="images/slideshow/slider_04.jpg" alt=" " width="960" height="400" />
                        </div>
                    </div>
                </div>
                <div class="slides-nav">
                    <a href="#" class="prev">Previous Slide</a> <a href="#" class="next">Next Slide</a>
                </div>
            </div>
        </div>
    </div>
    <div style="margin-top: 15px;" class="one">
        <div class="one-third">
            <a href="http://stores.ebay.it/MaterarredamentiShop" target="_blank" id="tasto-ebay"></a>
        </div>
        <div class="one-third">
            <a href="http://issuu.com/materaarredamenti" target="_blank" id="tasto-issuu"></a>
        </div>
        <div class="one-third last">
            <a target="_blank" href="http://www.amazon.it/s/ref=nb_sb_noss/275-7821011-7208732?__mk_it_IT=%C3%85M%C3%85%C5%BD%C3%95%C3%91&url=search-alias%3Dkitchen&field-keywords=materashop.it&rh=n%3A524015031%2Ck%3Amaterashop.it" id="tasto-amazon"></a>
        </div>
    </div>
    <div style="margin-top: 30px;" class="one">
        <div class="headline">
            <h4>PRODOTTI IN PRIMO PIANO</h4>
        </div>
        <asp:ListView runat="server" ID="lvProductsShowCase" OnItemDataBound="lvProductsShowCase_OnItemDataBound">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div runat="server" id="box_prodotto" style="margin-top: 25px; margin-right: 30px; border: 1px solid #dfdfdf;"
                    class="one-fourth view view-first">
                    <div style="width: 215px; height: 215px; overflow: hidden;">
                        <p runat="server" id="pProductPrice" class="desc_prezzo_home rosso">
                        </p>
                        <asp:Image ImageUrl="" Width="215" Height="215" runat="server" ID="imgProduct" />
                    </div>
                    <div class="mask_red">
                        <asp:LinkButton Style="display: block; height: 100%; text-decoration: none;" OnClick="lbProductDetail_OnClick" runat="server" ID="lbProductDetail">
                            <asp:HiddenField runat="server" ID="hfProductId" />
                            <span runat="server" id="spanProductDescription" class="desc_prodotto_home"></span>
                            <span class="link_vedi_dettaglio">Vedi dettaglio</span>
                        </asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

