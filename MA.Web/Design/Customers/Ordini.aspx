<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Customers/Default.master" AutoEventWireup="true"
    CodeFile="Ordini.aspx.cs" Inherits="Ordini" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">

                  <div class="one">
                     <asp:ListView runat="server" ID="lvOrd" OnItemDataBound="lvDataBound">
                            <EmptyDataTemplate>
                                <div class="ribbonbig" style="margin-bottom: 300px;">
                                    <div class="lijevo fl" style="padding-left: 20px;">
                                        <div class="bigtitle">
                                            Nessun ordine disponibile</div>
                                    </div>
                                </div>
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table class="carrello" >
                                     
                                    <tr runat="server" id="itemPlaceholder" />
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                   
                                    <td>
                                        <fieldset>
                                            <label style="width: 150px;" class="cartLabel">ID:&nbsp; 
                                               <span class="nero">
                                                <asp:Literal runat="server" ID="lblIdOrd"></asp:Literal></span></label>
                                                
                                                <label style="width: 142px;" class="cartLabel">Data:&nbsp; 
                                               <span class="nero">
                                                <asp:Literal runat="server" ID="lblDataOrd"></asp:Literal></span></label>
                                                
                                                <label style="width: 200px;" class="cartLabel">Eseguito da:&nbsp;  
                                                <span class="nero">
                                                <asp:Literal runat="server" ID="lblSpedOrd"></asp:Literal></span></label>
                                                
                                                <label style="width: 60px;" class="cartLabel">n. prod:&nbsp; 
                                                <span class="nero">
                                                <asp:Literal runat="server" ID="lblQty"></asp:Literal></span></label>
                                                
                                                <label style="width: 180px;" class="cartLabel">Stato:&nbsp;
                                                <span runat="server" id="spanStato" class="nero"> 
                                                 <asp:Literal runat="server" ID="lblStatoOrd"></asp:Literal></span></label>
                                                
                                                <label style="width: 90px;" class="cartLabel">Totale €.&nbsp; 
                                                <span class="nero">
                                                <asp:Literal runat="server" ID="lblTotOrd"></asp:Literal>
                                                </span></label>
                                                
                                                
                                            
                                        </fieldset>
                                        <br />
                                        <%--<fieldset>
                                            <asp:CheckBox runat="server" ID="chkDelete" Style="float: left;"  />
                                            <label style="margin-left: 5px; float: left;">
                                                voglio eliminare questo articolo dal carrello.</label>
                                            <asp:LinkButton runat="server" Style="float: right;" ID="lnkbtnDettProd" Text="visualizza dettagli articolo" />
                                        </fieldset>--%>
                                        <fieldset>
                                        <asp:LinkButton runat="server" ID="lnkbtnInfoOrdine"  Style="float: right;">visualizza dettaglio ordine</asp:LinkButton>
                                        </fieldset>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                      
                   <div class="clear-line"></div>
                   <div style="padding-left: 30px; margin-top: 20px; width: 920px;" class="one">
                      <asp:DataPager runat="server" ID="pagerOrdini" OnPreRender="pagerOrdini_PreRender"
                PageSize="6" PagedControlID="lvOrd">
                <Fields>
                    <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                        NumericButtonCssClass="my-blog-pagination" />
                </Fields>
            </asp:DataPager>   
                      </div>
                </div>
            
</asp:Content>
