<%@ Page Language="C#" MasterPageFile="Admin.master" Title="Matera Arredamenti - Gestione Albums"
    CodeFile="Albums.aspx.cs" Inherits="Admin_Albums_aspx" %>

<asp:Content ID="ContentMenu" runat="server" ContentPlaceHolderID="cphAdminMenu">
    <li><a href="ManageNews.aspx">Gestione Contenuti</a> </li>
    <li class="active"><a href="Albums.aspx">Gallerie | Slider Homepage</a> </li>
    <li><a href="Newsletter.aspx">Newsletter</a> </li>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="cphAdminBody" runat="Server">

    <script type="text/javascript" language="javascript">
        function DeleteConfirmation() {
            if (!window.confirm('Cancellare album - attenzione tutte le foto associate saranno eliminate!!!')) return false;
        }
    </script>

    <script type="text/javascript">
            function pageLoad() {

                InitFancybox();
            }
    </script>

    <div class="content-box">
        <div class="box-body">
            <div class="box-header clear">
                <h2>
                    :: Aggiungi/Modifica Album</h2>
            </div>
            <div class="box-wrap clear">
                <h4 class="bt-space15">
                    Per poter caricare le immagini in un nuovo Album bisogna prima crearlo.</h4>
                <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert">
                    <InsertItemTemplate>
                        <table class="style1">
                            <thead>
                                <tr>
                                    <th>
                                        Item
                                    </th>
                                    <th class="full">
                                        Value
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th>
                                        Titolo Album <span class="required">*</span>
                                    </th>
                                    <td class="edit-field long">
                                        <asp:TextBox ID="txtTitoloFoto" runat="server" Text='<%# Bind("Caption") %>' CssClass="text required fl" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitoloFoto"
                                            ErrorMessage="<div style='width:99.6%; margin-top:5px; margin-bottom:3px;' class='notification note-attention'><p><b>Attenzione: questo campo è obbligatorio.</b> Inserire il Titolo dell'Album che si vuole creare.</p></div>"
                                            Display="Dynamic" Style="padding-top: 20px;" />
                                    </td>
                                </tr>
                                <%--<tr>
                                    <th>
                                        Album Pubblico
                                    </th>
                                    <td>
                                        <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("IsPublic") %>' Text="Rendi pubblico l'album" />
                                    </td>
                                </tr>--%>
                            </tbody>
                        </table>
                        <asp:Button ID="ImageButton1" runat="server" Text="CREA Album" CommandName="Insert"
                            CssClass="button green fr bt-space15" SkinID="add" />
                    </InsertItemTemplate>
                </asp:FormView>
                <div class="clear">
                </div>
                <div class="rule">
                </div>
                <div id="content">
                    <h4 class="bt-space15">
                        Nel sito sono già disponibili gli Album seguenti. Scegliere <strong><em>'Modifica'</em></strong>
                        per modificare le immagini presenti nell'Album. Scegliere <strong><em>'Cancella'</em></strong>
                        per rimuovere in modo permanente dal sito l'Album e tutte le immagini in esso contenute.</h4>
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updlvAlb">
                        <ContentTemplate>
                            <asp:ListView runat="server" ID="lvAlbums" OnItemCommand="_OnItemCommand" DataSourceID="ObjectDataSource1"
                                DataKeyNames="AlbumID" OnItemCreated="_OnCreated">
                                <EmptyDataTemplate>
                                    <div class="notification note-info">
                                        <p>
                                            <strong>ATTENZIONE:</strong> Nel sito non è stato ancora caricato nessun Album.
                                            Per inserirne uno usare il pannello superiore. Una volta creato un nuovo Album sarà
                                            possibile aggiungere le foto</p>
                                    </div>
                                </EmptyDataTemplate>
                                <LayoutTemplate>
                                    <table class="style1">
                                        <thead>
                                            <tr>
                                                <th>
                                                    Foto
                                                </th>
                                                <th>
                                                    Descrizione
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
                                        <td class="box-slide-body ln-normal">
                                            <%--<a href="Handler.ashx?PhotoID=<%# Eval("AlbumID") %>.jpg" title="Anteprima">--%>
                                            <img src="Handler.ashx?AlbumID=<%#  Eval("AlbumID") %>&Size=S" alt="" class="thumb size64 clickable" />
                                            <%-- </a>--%>
                                        </td>
                                        <td class="box-slide-body ln-normal">
                                            <div class="trio fl">
                                                <div class="mark bt-space0" style="width: 820px; padding-top: 7px;">
                                                    <ul class="bt-space0">
                                                        <li class="clear bt-space5">
                                                            <img src="images/ball_blue_16.png" class="fl-space" alt="" /><span class="fl" style="width: 170px;">Titolo
                                                                dell'Album:</span> <span class="fl value">
                                                                    <%# Server.HtmlEncode(Eval("Caption").ToString()) %></span></li>
                                                        <li class="clear bt-space5">
                                                            <asp:Image runat="server" ID="imgCount" ImageUrl="~/Admin/images/ball_red_16.png"
                                                                CssClass="fl-space" /><span class="fl" style="width: 170px;">Numero di Foto nell' Album:</span>
                                                            <span class="fl value">
                                                                <asp:Label runat="server" ID="numFotoss" Text='<%# PhotoManager.GetFotoCount(int.Parse(Eval("AlbumID").ToString())) %>'></asp:Label></span></li>
                                                        <li class="clear bt-space5">
                                                            <asp:Image runat="server" ID="imgLinked" ImageUrl="~/Admin/images/ball_red_16.png"
                                                                CssClass="fl-space" /><span class="fl" style="width: 170px;">Collegato ad un Progetto:
                                                                </span><span class="fl value">
                                                                    <asp:Label runat="server" ID="lblLinkedtoNews" Text="No"></asp:Label></span></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="fr">
                                                <ul class="vcenter" style="margin: 12px;">
                                                    <li class="bt-space5">
                                                        <asp:Button ID="ImageButton2" runat="server" Text="Modifica" CommandName="modifica"
                                                            CssClass="button green size-120" CausesValidation="false" /></li>
                                                    <li class="bt-space5">
                                                        <asp:Button ID="ImageButton3" OnClientClick="return DeleteConfirmation();" runat="server"
                                                            Text="Cancella" CommandName="cancella" CssClass="button red size-120" CausesValidation="false" /></li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                            <div class="tab-footer clear">
                                <asp:DataPager ID="DataPagerlvAlbume" runat="server" PagedControlID="lvAlbums" PageSize="5">
                                    <Fields>
                                        <peppPager:FollowingPagerField ButtonCount="5" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="PhotoManager"
        SelectMethod="GetAlbums" InsertMethod="AddAlbum" DeleteMethod="RemoveAlbum" UpdateMethod="EditAlbum">
    </asp:ObjectDataSource>
</asp:Content>
