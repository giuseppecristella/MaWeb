<%@ Page Language="C#" MasterPageFile="~/Admin_MA/Admin.master" AutoEventWireup="true"
    CodeFile="DefaultUtentiOutlet.aspx.cs" Inherits="DefaultUtentiOutlet" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentNavigoss" runat="Server">
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
						<li><a  href="InsertUpdateOutlet.aspx">Inserisci Scheda Outlet</a></li>
						<li><a  href="DefaultOutlet.aspx">Lista prodotti</a></li>
						<li><a class="current" href="DefaultUtentiOutlet.aspx">Lista utenti</a></li>
					</ul>
				</li>
				
			 
				 
				
				 
				
			</ul> <!-- End #main-nav -->
    <!-- End #main-nav -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-box-header">
        <h3>
            :: Elenco utenti Outlet</h3>
        <div class="clear">
        </div>
    </div>
    <!-- End .content-box-header -->
    <div class="content-box-content">
        <%--<div class="tab-content default-tab" id="tab1">--%>
        <!-- This is the target div. id must match the href of this div's tab -->
        <%--<div class="notification attention png_bg">
							<a href="#" class="close"><img src="resources/images/icons/cross_grey_small.png" title="Close this notification" alt="close" /></a>
							<div>
								This is a Content Box. You can put whatever you want in it. By the way, you can close this notification with the top-right cross.
							</div>
						</div>--%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceUtentiOutlet"
            GridLines="None" AllowPaging="True" AllowSorting="True" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="ID_UtenteOutlet" HeaderText="ID_UtenteOutlet" InsertVisible="False"
                    ReadOnly="True" SortExpression="ID_UtenteOutlet" />
                <asp:BoundField DataField="Nome_UtenteOutlet" HeaderText="Nome_UtenteOutlet" SortExpression="Nome_UtenteOutlet" />
                <asp:BoundField DataField="Cognome_UtenteOutlet" HeaderText="Cognome_UtenteOutlet"
                    SortExpression="Cognome_UtenteOutlet" />
                <asp:BoundField DataField="Email_UtenteOutlet" HeaderText="Email_UtenteOutlet" SortExpression="Email_UtenteOutlet" />
                <asp:BoundField DataField="Tel_UtenteOutlet" HeaderText="Tel_UtenteOutlet" SortExpression="Tel_UtenteOutlet" />
                <%--  <asp:CheckBoxField DataField="ProdottoInVetrina" HeaderText="ProdottoInVetrina" 
                                 SortExpression="ProdottoInVetrina" />--%>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceUtentiOutlet" runat="server" InsertMethod="Insert"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetUtentiOutlet"
            TypeName="DataSetMateraArredamentiTableAdapters.UtentiOutletTableAdapter">
            <InsertParameters>
                <asp:Parameter Name="Nome_UtenteOutlet" Type="String" />
                <asp:Parameter Name="Cognome_UtenteOutlet" Type="String" />
                <asp:Parameter Name="Email_UtenteOutlet" Type="String" />
                <asp:Parameter Name="Tel_UtenteOutlet" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </div>
    <!-- End #tab1 -->
</asp:Content>
