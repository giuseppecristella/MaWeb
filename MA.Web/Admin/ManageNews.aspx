<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ManageNews.aspx.cs" Inherits="Admin_ManageNews" Title="Matera Arredamenti - Gestione News" %>

 
<asp:Content ID="ContentMenu" runat="server" ContentPlaceHolderID="cphAdminMenu">
   
    <li class="active"><a href="ManageNews.aspx">Gestione Contenuti</a> </li>
    <li><a href="Albums.aspx">Gallerie | Slider Homepage</a> </li>
    <li><a href="Newsletter.aspx">Newsletter</a> </li>
    
    
</asp:Content>
<asp:Content ID="ContentBody" runat="server" ContentPlaceHolderID="cphAdminBody">

    <script type="text/javascript" language="javascript">
        function DeleteConfirmation() {
            if (!window.confirm('Cancellare la news?')) return false;
        }
    </script>

    <div class="content-box">
        <div class="box-body">
            <div class="box-header clear">
                <h2>
                    Elenco contenuti</h2>
            </div>
            <!-- box-header -->
            <div class="box-wrap clear">
            <p>Filtra per: &nbsp;
             <asp:DropDownList ID="ddlTipo" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="0">Blog: Ric/Form</asp:ListItem>
                        <asp:ListItem Value="1">Evento</asp:ListItem>
                        <asp:ListItem Value="5">Promozione</asp:ListItem>
                        <asp:ListItem Value="2">Sugg. Casa</asp:ListItem>
                        <asp:ListItem Value="3">Sugg. Manutenzione</asp:ListItem>
                        <asp:ListItem Value="4">Sugg. Cucina</asp:ListItem>
             </asp:DropDownList>
            </p>
                <p>
                    <asp:Button ID="Nuovo" runat="server" Text="Aggiungi" CssClass="button green size-80"
                        OnClick="Nuovo_Click" />
                        
                   
                        
                </p>
                 

                <script type="text/javascript">
                    function pageLoad() {
                        InitBoxSlide();
                        InitFancybox();
                    }
                </script>

                <asp:UpdatePanel runat="server" ID="updPnlListaNews" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:ListView ID="ListViewNews" runat="server" DataKeyNames="News_ID" DataSourceID="ObjectDataSource1"
                            OnItemCommand="_OnItemCommand" OnItemCreated="_OnCreated">
                            <EmptyDataTemplate>
                                <div class="notification note-info">
                                    <p>
                                        <strong>ATTENZIONE:</strong> Nel sito non è stata ancora inserita nessuna News.
                                    </p>
                                </div>
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table class="style1">
                                    <thead>
                                        <tr>
                                            <th>
                                                n. [ID]
                                            </th>
                                            <th>
                                                Foto
                                            </th>
                                            <th>
                                                News
                                            </th>
                                            <th>
                                                Data Ins.
                                            </th>
                                            <th>
                                                Media
                                            </th>
                                            <th>
                                                Visibile
                                            </th>
                                            <th>
                                                
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr runat="server" id="itemPlaceholder" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblriga" Text=""></asp:Label>
                                       [ <%#Eval("News_ID") %> ]
                                    </td>
                                    <td>
                                        <a href="<%# Utility.SetFoto(Eval("UrlFotoHome").ToString()) %>" title="Anteprima">
                                            <img src="<%# Utility.SetFoto(Eval("UrlFotoHome").ToString()) %>" alt="" class="thumb  size64 clickable" />
                                        </a>
                                    </td>
                                    <td>
                                        <%# Eval("Titolo") %>
                                        
                                       <%-- <%# Utility.ShortDesc(Eval("Testo").ToString(),50).ToString() %>--%>
                                    </td>
                                    <td>
                                        <%# System.Convert.ToDateTime(Eval("Data")).Date.ToShortDateString()%>
                                    </td>
                                    <td>
                                               <%-- integrare tooltip!--%>
                                                  <asp:Image  runat="server" ToolTip='<%# Eval("Allegati")%>' Visible="false" ID="imgAllegato" ImageUrl="~/Admin/images/attach.png"
                                                    CssClass="fl-space2" />
                                                     <asp:Image runat="server" Visible="false" ID="imgVideo" ImageUrl="~/Admin/images/youtube.png"
                                                    CssClass="fl-space2" />
                                                     <asp:Image runat="server" Visible="false" ID="imgPhoto" ImageUrl="~/Admin/images/photo.png"
                                                    CssClass="fl-space2" />
                                            
                                    </td>
                                    <td>
                                    <%# Utility.isVisible(int.Parse(Eval("News_ID").ToString())).ToString() %>

                                     
                                    </td>
                                    <td>   
                                    <asp:LinkButton ImageUrl="images/ico_edit_16.png" CommandName="modifica" ID="lnkButtonModifica"
                                            runat="server" CssClass="icon16 fl-space2" Text="Modifica">Modifica</asp:LinkButton>
                                        <asp:ImageButton OnClientClick="return DeleteConfirmation();" CommandName="cancella"
                                            ImageUrl="images/ico_delete_16.png" ID="lnkButtonDelete" runat="server" CssClass="icon16 fl-space2"
                                            Text="Elimina"></asp:ImageButton>
                                            <asp:Image runat="server" ID="Image1" ImageUrl="~/Admin/images/photo.png"
                                                    CssClass="icon16 fl-space2" />
                                            <asp:LinkButton CommandName="fotoGallery" ID="lnkButtonFotoG" runat="server" CssClass="button blue size-80"
                                                    Text="FotoAlbum"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                        <div class="tab-footer clear">
                            <asp:DataPager runat="server" ID="pager" PagedControlID="ListViewNews" PageSize="10">
                                <Fields>
                                    <peppPager:FollowingPagerField ButtonCount="10" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetListaNews"
                    TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlTipo" DefaultValue="0" Name="Tipo" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
