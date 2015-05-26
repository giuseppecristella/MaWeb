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
                            <img src="images/slideshow/slide-rossa-01.jpg" alt=" " width="960" height="400" />
                        </div>
                        <%--<div class="slide">
                            <img src="images/slideshow/slide-rossa-02.jpg" alt=" " width="960" height="400" />
                        </div>--%>
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
            <a href="http://stores.ebay.it/MaterarredamentiShop" target="_blank" id="tasto-ebay">vai al sito </a>
        </div>
        <div class="one-third">
            <a href="" id="tasto-issuu">vai allo shop design e casa </a>
        </div>
        <div class="one-third last">
          <a target="_blank" href="http://www.amazon.it/s/ref=bl_sr_kitchen?ie=UTF8&field-brandtextbin=Matera+Arredamenti&node=524015031" id="tasto-amazon">vai al nostro magazine </a>
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
                        <asp:LinkButton style="display: block; height: 100%; text-decoration: none;" OnClick="lbProductDetail_OnClick" runat="server" id="lbProductDetail">
                            <asp:HiddenField runat="server" ID="hfProductId"/>
                            <span runat="server" id="spanProductDescription" class="desc_prodotto_home"></span>
                            <span class="link_vedi_dettaglio">Vedi dettaglio</span> </asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

