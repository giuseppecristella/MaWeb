<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Default_r.master" AutoEventWireup="true" CodeFile="Catalogo.aspx.cs" Inherits="Design_Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div id="content">
        <div class="one">
            <div class="headline">
                <h4>
                    <span class="colored">
                        <asp:Label runat="server" ID="lblCategoria"></asp:Label></span></h4>
            </div>
            <asp:ListView runat="server" ID="lvProducts" OnItemDataBound="item_dataBound">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <div runat="server" id="box_prodotto" style="margin-top: 40px; margin-right: 30px; border: 1px solid #dfdfdf;"
                        class="one-fourth view view-first">
                        <div style="width: 215px; height: 215px; overflow: hidden;">
                            <p runat="server" id="priceProduct" class="desc_prezzo_home verde">
                            </p>
                            <asp:Image ImageUrl="../Handler.ashx" Width="215" Height="215" runat="server" ID="imgProduct"></asp:Image>
                        </div>
                        <div runat="server" id="divMaskProd" class="mask_green">
                            <a style="display: block; height: 100%; text-decoration: none;" runat="server" id="lnkDettaglio_1">
                                <span runat="server" id="descProduct" class="desc_prodotto_home"></span><span class="link_vedi_dettaglio">Vedi dettaglio</span> </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div style="margin-top: 20px; width: 920px;" class="one">
            <asp:DataPager runat="server" Visible="true" ID="pagerProducts" OnPreRender="pagerProducts_PreRender"
                PageSize="12" PagedControlID="lvProducts">
                <Fields>
                    <asp:NumericPagerField CurrentPageLabelCssClass="my-blog-pagination-current_gr" NextPreviousButtonCssClass="my-blog-pagination_gr"
                        NumericButtonCssClass="my-blog-pagination_gr" />
                </Fields>
            </asp:DataPager>
            <asp:DataPager runat="server" Visible="false" ID="pagerRosso" OnPreRender="pagerProducts_PreRender"
                PageSize="12" PagedControlID="lvProducts">
                <Fields>
                    <asp:NumericPagerField CurrentPageLabelCssClass="my-blog-pagination-current_red"
                        NextPreviousButtonCssClass="my-blog-pagination_red" NumericButtonCssClass="my-blog-pagination_red" />
                </Fields>
            </asp:DataPager>
        </div>
        <div runat="server" id="divSpotRosso" visible="false" style="padding: 20px 0 5px 0; height: 70px;">
            <a style="margin-top: 60px; background: transparent url('images/logo-design.png') no-repeat; display: block; float: left; width: 220px; height: 70px; text-indent: -9999px;"
                id="A1" title="Homepage" href="design.html"></a>
            <div style="margin-top: 60px; background: #D10A11; margin-left: 5px; float: left; width: 614px; height: 70px;">
                <p class="visita_shop">
                    Entra e visita il nostro Shop dedicato all'Arredamento! Mille idee ti aspettano!
                </p>
            </div>
            <div style="margin-top: 60px; float: left; width: 120px; height: 70px;">
                <a style="background: #D10A11 url('images/entra-rosso.png') no-repeat; position: relative; height: 70px; margin-top: 0px; text-indent: 60px; display: block;"
                    href="design.html"
                    class="_carrello_titolo"></a>
            </div>
        </div>
       
    </div>
</asp:Content>

