<%@ Page Title="Matera Arredamenti - Gestione News" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" ValidateRequest="false" CodeFile="AddModNews.aspx.cs"
    Inherits="AddModNews" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="ContentMenu" runat="server" ContentPlaceHolderID="cphAdminMenu">
     
  
    <li class="active"><a href="ManageNews.aspx">Gestione Contenuti</a> </li>
    <li><a href="Albums.aspx">Gallerie | Slider Homepage</a> </li>
    <li><a href="../App_Code/Newsletter.aspx">Newsletter</a> </li>
 
    
     
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="cphAdminBody" runat="Server">

<script type="text/javascript">

$('#peppe').onkeyup(function(){alert('sciamn');});
  

    function getCleanedWordString(content) {

        var fullStr = content + " ";
        var initial_whitespace_rExp = /^[^A-Za-z0-9]+/gi;
        var left_trimmedStr = fullStr.replace(initial_whitespace_rExp, "");
        var non_alphanumerics_rExp = rExp = /[^A-Za-z0-9]+/gi;
        var cleanedStr = left_trimmedStr.replace(non_alphanumerics_rExp, " ");
        var splitString = cleanedStr.split(" ");
        return splitString;
    }

    function countWord(cleanedWordString) {
        var word_count = cleanedWordString.length - 1;
        return word_count;
    }

    function conta()
    {
        alert("aaa");
        var words = document.getElementById("peppe").value;

        var num = countWord(words);
        alert(num);

       
        }

    	    var info;
    	    $(document).ready(function() {
    	        var options = {
    	            'maxCharacterSize': -2,
    	            'originalStyle': 'originalTextareaInfo',
    	            'warningStyle': 'warningTextareaInfo',
    	            'warningNumber': 40
    	        };
    	        $('#testTextarea').textareaCount(options);

    	        var options2 = {
    	            'maxCharacterSize': 2,
    	            'originalStyle': 'originalTextareaInfo',
    	            'warningStyle': 'warningTextareaInfo',
    	            'warningNumber': 40,
    	            'displayFormat': '#input/#max | #words words'
    	        };
    	        $('#pepp1de').textareaCount(options2);

    	        var options3 = {
    	            'maxCharacterSize': 200,
    	            'originalStyle': 'originalTextareaInfo',
    	            'warningStyle': 'warningTextareaInfo',
    	            'warningNumber': 40,
    	            'displayFormat': '#input/#max'
    	        };
    	        $('#ctl00_cphAdminBody_txtDescrizione').textareaCount(options3, function(data) {
    	           
    	            $('#showData').html(data.input + " char / " + data.left + " rimanenti  |  parole inserite: "+ data.words );
    	        });
    	    });
		</script>



    <div class="content-box">
        <div class="box-body">
            <div class="box-header clear">
            <ul class="tabs clear">
						<li><a href="#italiano">ITALIANO</a></li>
						<li><a href="#inglese">INGLESE</a></li>
						<li><a href="#tedesco">TEDESCO</a></li>
					</ul>
                <h2>
                    :: Aggiungi/Modifica News</h2>
            </div>
            <div class="box-wrap clear">
                <!-- ***** START DIV MESSAGGI DI ERRORE ***** -->
                <div id="DivSuccess" runat="server" visible="false" class="notification">
                    <a href="#" class="close" title="Close notification">close</a>
                    <p>
                        <strong>articolo ID:
                            <asp:Label ID="News_ID" runat="server" Text=""> inserito con successo</asp:Label></strong>
                    </p>
                </div>
                <div id="DivError" runat="server" visible="false" class="notification note-attention">
                    <a href="#" class="close" title="Close notification">close</a>
                    <p>
                        <strong>
                            <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>
                        </strong>
                    </p>
                </div>
                <!-- ***** END DIV MESSAGGI DI ERRORE ***** -->
                <div id="italiano">
                
                <table class="style1">
                    <thead>
                        <tr>
                            <th>
                                Item
                            </th>
                            <th class="full">
                                Value
                            </th>
                            <th>
                                Edit
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <%--<tr>
                        <th>Tipologia</th>
                        <td><asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="XmlDataSourceNewsTipo"
                                DataTextField="text" DataValueField="value">
                            </asp:DropDownList>
                            <asp:XmlDataSource ID="XmlDataSourceNewsTipo" runat="server" DataFile="~/Admin/ListaTipologiaNews.xml"
                                TransformFile="~/Admin/ListaTipologiaNews.xslt"></asp:XmlDataSource></td>
                        <td></td>
                    </tr>--%>
                        
                          <tr>
                        <th>Homepage</th>
                        <td>
                            <asp:CheckBox ID="chkboxPrjHome" runat="server" Text="inserire la news in homepage?" /> </td>
                        <td></td>
                    </tr>
                        <tr>
                            <th>
                                Titolo <span class="required">*</span>
                            </th>
                            <td class="edit-field long">
                                <asp:TextBox ID="txtTitoloNews" runat="server" CssClass="required fl-space2" MaxLength="100"></asp:TextBox>
                               <br /> <br /><asp:RequiredFieldValidator ID="RequiredFieldValidatorTitolo" runat="server" ControlToValidate="txtTitoloNews"
                                    ErrorMessage="<div style='width:780px'; class='notification note-attention'><span class='icon'></span><p><b>Attenzione: questo campo è obbligatorio.</b> Inserire il Titolo.</p></div>"
                                    Display="Dynamic" >
                                </asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <a href="#">
                                    <img src="images/ico_edit_16.png" alt="" class="icon16 fl" title="quick edit" /></a>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Data <span class="required">*</span>
                            </th>
                            <td class="edit-field">
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtData"
                                    Format="dd/MM/yyyy" CssClass="MyCalendar">
                                </asp:CalendarExtender>
                                <asp:TextBox ID="txtData" runat="server" CssClass="required text fl-space2"></asp:TextBox>
                                <div class="clear">
                                </div>
                               <br /> <asp:RequiredFieldValidator ID="RequiredFieldValidatorData" runat="server" ControlToValidate="txtData"
                                    ErrorMessage="<div style='width:780px'; class='notification note-attention'><span class='icon'></span><p><b>Attenzione: questo campo è obbligatorio.</b> Inserire la Data.</p></div>"
                                    Display="Dynamic"  >
                                </asp:RequiredFieldValidator>
                            </td>
                            <%--<td>
                                <a href="#">
                                <a onclick="javascript:conta();">attiva conto</a>
                                    <img src="images/ico_edit_16.png" alt="" class="icon16 fl" title="quick edit" /></a>
                            </td>--%>
                        </tr>
                        <%--<tr>
                            <th>
                                Autore
                            </th>
                            <td class="edit-field long">
                                <asp:TextBox ID="txtAutore" runat="server" CssClass="required fl-space2" MaxLength="100"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                         
                        <tr>
                            <th>
                                Descrizione <span class="required">*</span>
                            </th>
                            <td class="edit-field long">
                           
                                <asp:TextBox  class="jwysiwyg" ID="txtDescrizione" runat="server" CssClass="required text size-200 fl-space2"
                                    Rows="4" TextMode="MultiLine" MaxLength="270"></asp:TextBox>
                               <div class="clear">
                                </div>
                                <br /> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAutore" runat="server" ControlToValidate="txtDescrizione"
                                    ErrorMessage="<div style='width:780px'; class='notification note-attention'><span class='icon'></span><p><b>Attenzione: questo campo è obbligatorio.</b> Inserire una Descrizione.</p></div>"
                                    Display="Dynamic" >
                                </asp:RequiredFieldValidator>
                                
                                	<%--<div style="width:780px"; class="notification note-info">--%>
                              
                                <span class="icon"></span>
					

                                
                            </td>
                            <td>
                                <a href="#">
                                    <img src="images/ico_edit_16.png" alt="" class="icon16 fl" title="quick edit" /></a>
                            </td>
                        </tr>
                       
                        <tr>
                            <th>
                                Foto
                            </th>
                            <td style="padding-right: 35px;">
                                <asp:FileUpload ID="FileUploadFoto" runat="server" CssClass="fl-space" Width="300px" />
                                <asp:Button CausesValidation="false" ID="ButtonUploadFoto" CssClass="button green" runat="server" Text="Inserisci" OnClick="ButtonUploadFoto_Click" />
                                <a href="#" runat="server" id="previewFoto" title="preview" rel="group1" class="fr-space">
                                    <asp:Image ID="imgFotoArticolo" runat="server" Visible="true" ImageUrl="" CssClass="thumb size64 fr-space" />
                                </a>
                            </td>
                            <td>
                                <asp:ImageButton ID="lnkCancFoto" runat="server" ImageUrl="images/ico_delete_16.png"
                                    CausesValidation="false" Visible="false" OnClientClick="window.confirm('Cancellare la Foto?')"
                                    OnClick="CancellaFoto" CssClass="icon16 fl" ToolTip="Elimina la Foto" />
                            </td>
                        </tr>
                        <tr runat="server" id="trFotoGallery" visible="false">
                            <th>
                                FotoGallery
                            </th>
                            <td style="padding-right: 35px;">
                                <asp:Button ID="btnFotoAlbum" CssClass="button green" runat="server" Text="ASSOCIA FotoAlbum"
                                    OnClick="BtnGalleryArt_Click" />
                                    
                                <asp:TextBox runat="server" ID="txtFotoGallery" CssClass="fr-space" Font-Bold="true"
                                    Text="Nessun FotoAlbum associato" Style="text-align: right;" ReadOnly="true"
                                    BorderStyle="None" BackColor="Transparent" Width="420px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton Visible="false" ID="imgCancFotoG" runat="server" ImageUrl="images/ico_delete_16.png"
                                    CausesValidation="false" OnClientClick="window.confirm('Cancellare il FotoAlbum?')"
                                    OnClick="CancellaFotoGallery" CssClass="icon16 fl" ToolTip="Elimina Album" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Allegato
                            </th>
                            <td style="padding-right: 35px;">
                                <asp:FileUpload ID="FileUploadAllegati" runat="server" CssClass="fl-space" Width="300px" />
                                <asp:Button ID="ButtonUploadAllegati" CssClass="button green" runat="server" Text="Inserisci" OnClick="ButtonUploadAllegati_Click" CausesValidation="false" />
                                <asp:TextBox runat="server" ID="txtNomeFile" CssClass="fr-space" Font-Bold="true"
                                    Text="Nessun file allegato" Style="max-width: 400px; text-align: right;" ReadOnly="true"
                                    BorderStyle="None" BackColor="Transparent" Width="400px"></asp:TextBox>
                                <%--<asp:Label Font-Bold="true" ID="lblpathFileAll" runat="server" Text="Nessun file allegato"
                                    CssClass="fr-space" Style="max-width: 420px;"></asp:Label>--%>
                            </td>
                            <td>
                                <asp:ImageButton ID="lnkCancAllegato" runat="server" ImageUrl="images/ico_delete_16.png"
                                    CausesValidation="false" OnClientClick="window.confirm('Cancellare il file Allegato?')"
                                    OnClick="CancellaAllegato" CssClass="icon16 fl" ToolTip="Elimina Allegato" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Testo <span class="required">*</span>
                            </th>
                            <td class="edit-field long">
                                <FCKeditorV2:FCKeditor Height="400px" Width="785px" EnableViewState="false" ID="FCKeditor1"
                                    runat="server" BasePath="~/FKeditor/" ToolbarSet="NewsTerminator" >
                                </FCKeditorV2:FCKeditor>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </div>
                
                <div id="inglese">
                
                 <table class="style1">
                    <thead>
                        <tr>
                            <th>
                                Item
                            </th>
                            <th class="full">
                                Value
                            </th>
                            <th>
                                Edit
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <%--<tr>
                        <th>Tipologia</th>
                        <td><asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="XmlDataSourceNewsTipo"
                                DataTextField="text" DataValueField="value">
                            </asp:DropDownList>
                            <asp:XmlDataSource ID="XmlDataSourceNewsTipo" runat="server" DataFile="~/Admin/ListaTipologiaNews.xml"
                                TransformFile="~/Admin/ListaTipologiaNews.xslt"></asp:XmlDataSource></td>
                        <td></td>
                    </tr>--%>
                        <tr>
                            <th>
                                Titolo 
                            </th>
                            <td class="edit-field long">
                                <asp:TextBox ID="TextBoxTitoloENG" runat="server" CssClass="required fl-space2" MaxLength="100"></asp:TextBox>
                               <br /> <br /><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxTitoloENG"
                                    ErrorMessage="<div style='width:780px'; class='notification note-attention'><span class='icon'></span><p><b>Attenzione: questo campo è obbligatorio.</b> Inserire il Titolo.</p></div>"
                                    Display="Dynamic" >
                                </asp:RequiredFieldValidator>--%>
                            </td>
                            <td>
                                <a href="#">
                                    <img src="images/ico_edit_16.png" alt="" class="icon16 fl" title="quick edit" /></a>
                            </td>
                        </tr>
                        
                     
                        <%--<tr>
                            <th>
                                Fonte
                            </th>
                            <td class="edit-field long">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="required fl-space2" MaxLength="100"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                        <tr>
                            <th>
                                Descrizione
                            </th>
                            <td class="edit-field long">
                                <asp:TextBox ID="TextBoxDescrizioneENG" runat="server" CssClass="required text size-200 fl-space2"
                                    Rows="4" TextMode="MultiLine" ></asp:TextBox>
                               
                            
                                	<div style="width:780px"; class="notification note-info">
                              
                                <span class="icon"></span>
					<p id="P1">0 char / 200 rimanenti | parole inserite: 0</p>

                                </div>
                            </td>
                            <td>
                                <a href="#">
                                    <img src="images/ico_edit_16.png" alt="" class="icon16 fl" title="quick edit" /></a>
                            </td>
                        </tr>
                     
                   
                    
                        <tr>
                            <th>
                                Testo 
                            </th>
                            <td class="edit-field long">
                                <FCKeditorV2:FCKeditor Height="400px" Width="785px" EnableViewState="false" ID="FCKeditor2"
                                    runat="server" BasePath="~/FKeditor/" ToolbarSet="NewsTerminator">
                                </FCKeditorV2:FCKeditor>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </div>
                
                
                
                
                      <div id="tedesco">
                
                 <table class="style1">
                    <thead>
                        <tr>
                            <th>
                                Item
                            </th>
                            <th class="full">
                                Value
                            </th>
                            <th>
                                Edit
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <%--<tr>
                        <th>Tipologia</th>
                        <td><asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="XmlDataSourceNewsTipo"
                                DataTextField="text" DataValueField="value">
                            </asp:DropDownList>
                            <asp:XmlDataSource ID="XmlDataSourceNewsTipo" runat="server" DataFile="~/Admin/ListaTipologiaNews.xml"
                                TransformFile="~/Admin/ListaTipologiaNews.xslt"></asp:XmlDataSource></td>
                        <td></td>
                    </tr>--%>
                        <tr>
                            <th>
                                Titolo 
                            </th>
                            <td class="edit-field long">
                                <asp:TextBox ID="TextBoxTitoloTED" runat="server" CssClass="required fl-space2" MaxLTEDth="100"></asp:TextBox>
                               <br /> <br /><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxTitoloTED"
                                    ErrorMessage="<div style='width:780px'; class='notification note-attention'><span class='icon'></span><p><b>Attenzione: questo campo è obbligatorio.</b> Inserire il Titolo.</p></div>"
                                    Display="Dynamic" >
                                </asp:RequiredFieldValidator>--%>
                            </td>
                            <td>
                                <a href="#">
                                    <img src="images/ico_edit_16.png" alt="" class="icon16 fl" title="quick edit" /></a>
                            </td>
                        </tr>
                        
                     
                        <%--<tr>
                            <th>
                                Fonte
                            </th>
                            <td class="edit-field long">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="required fl-space2" MaxLTEDth="100"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                        <tr>
                            <th>
                                Descrizione
                            </th>
                            <td class="edit-field long">
                                <asp:TextBox ID="TextBoxDescrizioneTED" runat="server" CssClass="required text size-200 fl-space2"
                                    Rows="4" TextMode="MultiLine" ></asp:TextBox>
                               
                            
                                	<div style="width:780px"; class="notification note-info">
                              
                                <span class="icon"></span>
					<p id="P2">0 char / 200 rimanenti | parole inserite: 0</p>

                                </div>
                            </td>
                            <td>
                                <a href="#">
                                    <img src="images/ico_edit_16.png" alt="" class="icon16 fl" title="quick edit" /></a>
                            </td>
                        </tr>
                     
                   
                    
                        <tr>
                            <th>
                                Testo 
                            </th>
                            <td class="edit-field long">
                                <FCKeditorV2:FCKeditor Height="400px" Width="785px" EnableViewState="false" ID="FCKeditor3"
                                    runat="server" BasePath="~/FKeditor/" ToolbarSet="NewsTerminator">
                                </FCKeditorV2:FCKeditor>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </div>
                
                
                <div class="rule2">
                </div>
                <div class="form-field clear">
                    <asp:Button CausesValidation="false" ID="ButtonAnnulla" CssClass="button blue fr"
                        runat="server" Text="Annulla" OnClick="ButtonAnnulla_Click" Style="margin-left: 10px;" />
                    <asp:Button ID="ButtonInsert" CssClass="button green fr" runat="server" Text="INSERISCI"
                        OnClick="ButtonInsert_Click" />
                    <asp:Button ID="ButtonAgg" CssClass="button green fr" runat="server" Text="AGGIORNA"
                        OnClick="ButtonAgg_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
