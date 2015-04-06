<%@ Page Title="" Language="C#" MasterPageFile="Shop.Master.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Shop.Web.Mvp.Themes.flatfolio.Catalogo" %>

<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="row oi_port_container">
        <asp:ListView runat="server" ID="lvCatalog">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>

                <div class="oi_strange_portfolio_item col-md-4 portfolio-long design">
                    <div class="oi_strange_portfolio_item_holder">
                        <a href="freelancers.html">
                            <asp:Image ImageUrl='<%# Eval("ImageUrl") %>' runat="server" ID="imgProduct" CssClass="img-responsive"></asp:Image>
                            <div class="oi_mask">
                                <h4 class="oi_sub_legend"><%# Eval("Name") %></h4>
                                <div class="oi_port_sep">
                                </div>
                                <div class="oi_port_cats">
                                    <%# Eval("Name") %>
                                </div>
                                <div class="oi_small_descr">
                                    <%# Eval("Description") %>
                                </div>
                               <%-- <img class="img-responsive oi_por_small_thumb" src="<%# Eval("ImageUrl") %>" alt="">--%>
                            </div>
                        </a>
                    </div>
                </div>

            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
