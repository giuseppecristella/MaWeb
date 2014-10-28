<%@ Page Language="C#" MasterPageFile="Admin.master" Title="Matera Arredamenti - Gestione Albums"
    CodeFile="Photos.aspx.cs" Inherits="Admin_Photos_aspx" %>

<asp:Content ID="ContentMenu" runat="server" ContentPlaceHolderID="cphAdminMenu">
    <li><a href="ManageNews.aspx">Gestione Contenuti</a> </li>
    <li class="active"><a href="Albums.aspx">Gallerie | Slider Homepage</a> </li>
    <li><a href="../App_Code/Newsletter.aspx">Newsletter</a> </li>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="cphAdminBody" runat="Server">

    <script src="js/jquery.tablednd_0_5.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function DeleteConfirmation() {
            if (!window.confirm('Cancellare la foto?')) return false;
        }
    </script>

    <script type="text/javascript">
        function pageLoad() {

            InitFancybox();
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function() {


            $(".style1").tableDnD({
                onDragClass: "myDragClass",
                onDrop: function(table, row) {
                    var rows = table.tBodies[0].rows;
                    var debugStr = ""; //"Row dropped was " + row.id + ". New order: ";
                    for (var i = 0; i < rows.length; i++) {
                        debugStr += rows[i].id + "&";
                    }
                    var hdfArrPos = document.getElementById("<%=hdfArrPos.ClientID %>");
                    hdfArrPos.value = debugStr;
                    // alert(hdfArrPos.value);
                },
                onDragStart: function(table, row) {
                    //	alert("Started dragging row "+row.id);
                }
            });
        });
        
    </script>

    <div class="content-box">
        <div class="box-body">
            <div class="box-header clear">
                <h2>
                    :: Modifica/Aggiorna FotoAlbum
                </h2>
            </div>
            <div class="box-wrap clear">
                <h4 class="bt-space15">
                    Per aggiungere una foto a questo Album selezionare un file e, opzionalmente, una
                    didascalia, quindi scegliere <em>'AGGIUNGI Foto'</em>.</h4>
                <asp:HiddenField runat="server" ID="hdfArrPos" />
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
                                Foto <span class="required">*</span>
                            </th>
                            <td>
                                <asp:FileUpload ID="PhotoFile" runat="server" CssClass="form-file fl-space2" />
                                <div class="clear">
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="rfvPhotoFile" ControlToValidate="PhotoFile"
                                    ErrorMessage="<div style='width:99.5%; margin-top:5px; margin-bottom:1px;' class='notification note-attention'><p><b>Attenzione: questo campo è obbligatorio.</b> Scegliere una foto da caricare attraverso il tasto <em>'Sfoglia'</em>.</p></div>"
                                    Display="Dynamic" BackColor="LemonChiffon"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Didascalia
                            </th>
                            <td class="edit-field long">
                                <asp:TextBox ID="PhotoCaption" runat="server" Text='<%# Bind("Caption") %>' CssClass="required fl-space2" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="form-field clear">
                    <asp:Button ID="ButtonUploadFoto" CssClass="button green fr" runat="server" Text="AGGIUNGI Foto"
                        OnClick="ButtonUploadFoto_Click" />
                </div>
                <div class="rule">
                </div>
                <h4 class="bt-space15">
                    Nell'album
                    <asp:Label Style="color: #bf0000;" ID="lblNomeAlb" runat="server" Text="NomeAlbum"></asp:Label>
                    sono contenute le seguenti Foto:</h4>
                <asp:ListView runat="server" ID="lvFoto" OnItemCommand="_OnItemCommand" DataSourceID="ObjectDataSource1"
                    DataKeyNames="PhotoID">
                    <EmptyDataTemplate>
                        <div class="notification note-info">
                            <p>
                                <strong>ATTENZIONE:</strong> In questo Album non è ancora presente nessuna foto.
                                Per inserirne una usare il pannello superiore.</p>
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
                                        Didascalia
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
                        <tr id="<%# Eval("ordine") %>">
                            <td>
                                <a href="Handler.ashx?PhotoID=<%# Eval("PhotoID") %>.jpg" title="Anteprima">
                                    <img src='Handler.ashx?Size=S&PhotoID=<%# Eval("PhotoID") %>' alt="" class="thumb size64 clickable" />
                                </a>
                            </td>
                            <td style="width: 700px;">
                                <h4>
                                    <p class="description">
                                        <%# Server.HtmlEncode(Eval("Caption").ToString()) %>
                                    </p>
                                </h4>
                            </td>
                            <td class="vcenter">
                                <asp:Button ID="ImageButton3" OnClientClick="return DeleteConfirmation();" runat="server"
                                    Text="CANCELLA Foto" CommandName="cancella" CssClass="button red fr-space2 size-120"
                                    CausesValidation="false" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <asp:Button ID="lnkBackAlbumsList" runat="server" CssClass="button blue fr" Text="Indietro"
                    CausesValidation="false" OnClick="lnkBackAlbumsList_Click" Style="margin-left: 10px;">
                </asp:Button>
                <asp:Button ID="btnChangePos" runat="server" CssClass="button green fr size-120"
                    Text="Reorder" OnClick="change_pos" CausesValidation="false"></asp:Button>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="PhotoManager"
        SelectMethod="GetPhotosByPos" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:QueryStringParameter Name="AlbumID" Type="Int32" QueryStringField="AlbumID"
                DefaultValue="1" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
