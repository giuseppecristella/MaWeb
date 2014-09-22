<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="DefaultOutlet.aspx.cs" Inherits="DefaultOutlet" Title="materarredamenti.it" %>
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
						<li><a  href="InsertUpdateOutlet.aspx">Inserisci Scheda Outlet</a></li>
						<li><a class="current" href="DefaultOutlet.aspx">Lista prodotti</a></li>
						<li><a href="DefaultUtentiOutlet.aspx">Lista utenti</a></li>
					</ul>
				</li>
				
			 
				 
				
				 
				
			</ul> <!-- End #main-nav -->
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	
	
	
				<div class="content-box-header">
					
					<h3>:: Elenco prodotti vetrina Outlet</h3>
					
					 
					
					<div class="clear"></div>
					
				</div> <!-- End .content-box-header -->
				
				<div class="content-box-content">
					
					
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceOutlet" 
                       OnSelectedIndexChanged="GridView1_SelectedIndexChanged"   PageSize="10"
                            OnRowDataBound="GridView1_RowDataBound"  OnRowCommand="RunCommandButton" 
                            GridLines="None"  AllowPaging="True" AllowSorting="True" BorderStyle="None">
                        <Columns>
                        <asp:ButtonField CommandName="CancellaArticolo" Text="Cancella" ButtonType="Image"
                    ImageUrl="resources/images/icons/cross.png" />
                <asp:CommandField ShowSelectButton="True" AccessibleHeaderText="modifica" ButtonType="Image"
                    SelectImageUrl="resources/images/icons/pencil.png" />
                          
                            <asp:BoundField  DataField="ProdottoID" HeaderText="ID" InsertVisible="False" 
                                ReadOnly="True" SortExpression="ProdottoID" />
                                 <asp:TemplateField>
                                 <ItemTemplate>
                                 <a href="../<%# Eval("ProdottoFoto") %> ">
                                 <img  src="../<%# Eval("ProdottoFoto") %>"  height="50px" alt="foto prodotto"  /></a>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                            <asp:BoundField DataField="ProdottoNome" HeaderText="Prodotto" 
                                 SortExpression="ProdottoNome" />
                            <asp:BoundField DataField="ProdottoDescHome" HeaderText="Desc. Home" 
                                SortExpression="ProdottoDescHome" />
                            <asp:BoundField DataField="ProdottoDescScheda" HeaderText="Desc. Scheda" 
                                SortExpression="ProdottoDescScheda" />
                             <asp:BoundField DataField="ProdottoPrezzo" HeaderText="Listino" 
                                 SortExpression="ProdottoPrezzo" />
                             <asp:BoundField DataField="ProdottoPrezzoSconto" 
                                 HeaderText="Sconto" SortExpression="ProdottoPrezzoSconto" />
                           
                                 
                             <asp:BoundField DataField="ProdottoFoto" HeaderText="Path Foto" 
                                 SortExpression="ProdottoFoto" />
                        </Columns>
                    </asp:GridView>
					 
					 
					 <%--devo sostiture la griglia con una listview per cercare di risolvere il problema paginazione--%>
					 
                            <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSourceOutlet" >
                             <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
             
            </ItemTemplate>
                            </asp:ListView>
                            
                         <%--        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="5">
                                    <Fields>
                                        <peppPager:FollowingPagerField ButtonCount="5" />
                                    </Fields>
                                </asp:DataPager>
					 
                         <asp:DataPager ID="DataPager1" PagedControlID="ListView1" runat="server">
                            </asp:DataPager>--%>
					
					 
						
						<asp:ObjectDataSource ID="ObjectDataSourceOutlet" runat="server" 
                            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="GetProdotti" 
                            TypeName="DataSetMateraArredamentiTableAdapters.OutletTableAdapter" 
                            UpdateMethod="Update">
                            <UpdateParameters>
                                <asp:Parameter Name="ProdottoNome" Type="String" />
                                <asp:Parameter Name="ProdottoDescHome" Type="String" />
                                <asp:Parameter Name="ProdottoDescScheda" Type="String" />
                                <asp:Parameter Name="ProdottoPrezzo" Type="Decimal" />
                                <asp:Parameter Name="ProdottoPrezzoSconto" Type="Decimal" />
                                <asp:Parameter Name="ProdottoInVetrina" Type="Boolean" />
                                <asp:Parameter Name="ProdottoFoto" Type="String" />
                                <asp:Parameter Name="Original_ProdottoID" Type="Int32" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="ProdottoNome" Type="String" />
                                <asp:Parameter Name="ProdottoDescHome" Type="String" />
                                <asp:Parameter Name="ProdottoDescScheda" Type="String" />
                                <asp:Parameter Name="ProdottoPrezzo" Type="Decimal" />
                                <asp:Parameter Name="ProdottoPrezzoSconto" Type="Decimal" />
                                <asp:Parameter Name="ProdottoInVetrina" Type="Boolean" />
                                <asp:Parameter Name="ProdottoFoto" Type="String" />
                            </InsertParameters>
                        </asp:ObjectDataSource>
					 
						
		
						
					</div> <!-- End #tab1 -->
					
				
</asp:Content>

