<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="InsertUpdateOutlet.aspx.cs"
    Inherits="InsertUpdateOutlet" Title="materarredamenti.it" %>

<asp:Content ID="ContentNav" ContentPlaceHolderID="ContentNavigoss" runat="server"> 
<ul id="main-nav">  <!-- Accordion Menu -->
				
				<li>
					<a href="../Admin/ManageNews.aspx" class="nav-top-item no-submenu"> <!-- Add the class "no-submenu" to menu items with no sub menu -->
						Nuovo Pannello Admin
					</a>       
				</li>
				
				 
				
				<li>
					<a href="#" class="nav-top-item current"  >
						Outlet
					</a>
					<ul>
						<li><a class="current"  href="InsertUpdateOutlet.aspx">Inserisci Scheda Outlet</a></li>
						<li><a href="DefaultOutlet.aspx">Lista prodotti</a></li>
						<li><a href="DefaultUtentiOutlet.aspx">Lista utenti</a></li>
					</ul>
				</li>
				
			 
				 
				
				 
				
			</ul> <!-- End #main-nav -->
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-box">
        <!-- Start Content Box -->
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab2">
                <fieldset>
                    <div runat="server" id="artSucc" visible="false" class="notification success png_bg">
                        <a href="#" class="close">
                            <img src="resources/images/icons/cross_grey_small.png" title="Close this notification"
                                alt="close" /></a>
                        <div >
                            articolo ID:
                            <asp:Label ID="News_ID" runat="server" Text="">&nbsp; inserito con successo</asp:Label>
                        </div>
                    </div>
                    
                     <div runat="server" id="artErr" visible="false" class="notification error png_bg">
                        <a href="#" class="close">
                            <img src="resources/images/icons/cross_grey_small.png" title="Close this notification"
                                alt="close" /></a>
                        <div >
                            
                            <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <!-- Set class to "column-left" or "column-right" on fieldsets to divide the form into columns -->
                    <p>
                        <label>
                            Prodotto</label>
                        <asp:TextBox ID="txtProdotto" MaxLength="30" runat="server" CssClass="text-input small-input" ></asp:TextBox>
                        <asp:RequiredFieldValidator class="input-notification error png_bg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProdotto"
                            ErrorMessage="Inserisci il nome del prodotto" ></asp:RequiredFieldValidator>
                         
                        <!-- Classes for input-notification: success, error, information, attention -->
                        <br />
                        <small>Inserisci il nome del prodotto <b style="color:#bf0000;">lunghezza max consentita 30 caratteri</b></small>
                    </p>
                    <p>
                        <label>
                            Descrizione Home:</label>
                        <asp:TextBox ID="txtProdottoDesc" Text="" MaxLength="40" runat="server" CssClass="text-input small-input"></asp:TextBox>
                        <asp:RequiredFieldValidator   class="input-notification error png_bg" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProdottoDesc"
                            ErrorMessage="Inserisci descrizione" ></asp:RequiredFieldValidator>
                          <br />
                        <small>Inserisci una breve descrizione del prodotto <b style="color:#bf0000;">lunghezza max consentita 40 caratteri</b></small>
                        <!-- Classes for input-notification: success, error, information, attention -->
                       <%-- <br />
                        <small style="color:#bf0000;">Attenzione: questa descrizione compare in Home e non deve superare i <b>50 caratteri</b></small>--%>
                    </p>
                    <p>
                        <label>
                            Descrizione Scheda:</label>
                        <asp:TextBox ID="txtProdottoDescS" Text="" TextMode="MultiLine"   runat="server" CssClass="text-input small-input"></asp:TextBox>
                        <asp:RequiredFieldValidator  class="input-notification error png_bg" ID="RequiredFieldValidators" runat="server" ControlToValidate="txtProdottoDescS"
                            ErrorMessage="Inserisci descrizione scheda" ></asp:RequiredFieldValidator>
                         
                        <!-- Classes for input-notification: success, error, information, attention -->
                        <br />
                    </p>
                    <p>
                        <label>
                            Prezzo:</label>
                        <asp:TextBox ID="txtProdottoPrezzo" Text="" runat="server" CssClass="text-input small-input"></asp:TextBox>
                        <asp:RequiredFieldValidator  class="input-notification error png_bg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProdottoPrezzo"
                            ErrorMessage="Inserisci prezzo di listino" ></asp:RequiredFieldValidator>
                        
                        <!-- Classes for input-notification: success, error, information, attention -->
                        <br />
                        <small>Prezzo di listino del prodotto</small>
                    </p>
                    <p>
                        <label>
                            Prezzo Scontato:</label>
                        <asp:TextBox ID="txtProdottoPrezzoSconto" Text="" runat="server" CssClass="text-input small-input"></asp:TextBox>
                        <asp:RequiredFieldValidator class="input-notification error png_bg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProdottoPrezzoSconto"
                            ErrorMessage="Inserisci il prezzo scontato" ></asp:RequiredFieldValidator>
                         
                        <!-- Classes for input-notification: success, error, information, attention -->
                        <br />
                        <small>Prezzo del prodotto scontato</small>
                    </p>
                    <%--<p>
                    <label>
                        Autore</label>
                        
                        
                    <input class="text-input medium-input datepicker" type="text" id="medium-input" name="medium-input" />
                    <span class="input-notification error png_bg">Error message</span>
                </p>--%>
                    <p>
                        <label>
                            <b>Inserisci immagine descrittiva prodotto Outlet:</b></label>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <br />
                                </b>
                                <asp:FileUpload CssClass="text-input" ID="FileUpload1" runat="server" />
                                &nbsp;
                                <asp:Button ID="ButtonUpload" CssClass="button" Style="text-align: center" runat="server"
                                    Text="Ok" OnClick="ButtonUpload_Click" /></center>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="ButtonUpload" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <%--<asp:Button ID="cmdOk" CssClass="button" Style="text-align: center" runat="server"
                            Text="Chiudi" />--%>
                    </p>
                    <p> 
                        <asp:Image ID="imgProdotto" 
                            ImageUrl="~/resources/images/icons/bullet_black.png" runat="server" /><br />
                    <label>
                            Path immagine prodotto inserita:</label>
                    <asp:TextBox ID="txtProdottoFoto" Enabled="false" Text="" runat="server" CssClass="text-input small-input"></asp:TextBox>
                    <span runat="server" id="errNoImg" visible="false" class="input-notification error png_bg">è necessario inserire un immagine</span>
                    </p>
                    <p>
                        <asp:Button ID="ButtonInsert" CssClass="button" runat="server" Text="Inserisci Prodotto in vetrina Outlet" OnClick="ButtonInsert_Click1" />
                        <asp:Button ID="ButtonAgg" CssClass="button" runat="server" Text="Aggiorna Prodotto in vetrina Outlet" OnClick="ButtonAgg_Click" />
                    </p>
                </fieldset>
                <div class="clear">
                </div>
                <!-- End .clear -->
            </div>
            <!-- End #tab2 -->
        </div>
    </div>
</asp:Content>
