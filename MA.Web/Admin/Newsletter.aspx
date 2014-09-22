<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="Newsletter.aspx.cs" Inherits="Admin_ManageLinks"
   Title="materarredamenti.it Admin Panel" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="ContentMenu" runat="server" ContentPlaceHolderID="cphAdminMenu">
 
    <li ><a href="ManageNews.aspx">Gestione Contenuti</a> </li>
    <li><a href="Albums.aspx">Gallerie | Slider Homepage</a> </li>
    <li class="active"><a href="Newsletter.aspx">Newsletter</a> </li>
    
    
   
</asp:Content>
<asp:Content ID="ContentBody" runat="server" ContentPlaceHolderID="cphAdminBody">

    <script type="text/javascript" language="javascript">
        function DeleteConfirmation() {
            if (!window.confirm('Confirm Delete?')) return false;
        }
    </script>
    <div class="content-box">
        <div class="box-body">
            <div class="box-header clear">
                <h2>:: Users List</h2>
            </div>
            <!-- box-header -->
            <%-- <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="updpnlListaProg">
                <ContentTemplate>--%>
            <div class="box-wrap clear">
                <asp:ObjectDataSource ID="ObjectDataSourceMail" runat="server"
                    OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetListaMailNewsLetter" 
                    TypeName="DataSetVepAdminTableAdapters.NewsLetterTableAdapter" 
                    DeleteMethod="Delete">
                    <DeleteParameters>
                        <asp:Parameter Name="email" Type="String" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
                <asp:ListView ID="ListViewMail" runat="server" DataKeyNames="idUtente" DataSourceID="ObjectDataSourceMail"
                    OnItemCommand="_OnItemCommand" OnItemCreated="_OnCreated">
                    <EmptyDataTemplate>
                        <table class="style1">
                            <tbody>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <br />
                                        <div class="notification note-info">
                                            <p>
                                                <strong>Warning:</strong> No users in archive.
                                            </p>
                                        </div>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <table class="style1 datatable">
                            <thead>
                                        <tr>
                                            
                                            <th>
                                               
                                            </th>
                                            <th>
                                                ID
                                            </th>
                                            <th>
                                                e-mail
                                            </th>
                                             <th>
                                                
                                            </th>
                                             <th>
                                                 
                                            </th>
                                             <th>
                                                 
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
 								<td><asp:Label runat="server" ID="lblRiga" Text=""></asp:Label></td>
								<td><%#Eval("idUtente")%></td>
								<td><%# Eval("email")%></td>
								<td> </td>
								<td>
								
								
	
 									</td>
 									<td>
 									
 									
 									 
 									</td>
 									<td  style="margin-right: 12px; margin-top: 10px;">
 									
 									<asp:LinkButton OnClientClick="return DeleteConfirmation();" CausesValidation="false"
                                                CommandName="cancella" ID="LinkButton2" runat="server" CssClass="button red" style="float:right;"
                                                Text="Delete"></asp:LinkButton>
 									<asp:LinkButton CommandName="modifica" CausesValidation="false" ID="LinkButton3"
                                                runat="server" CssClass="button blue bt-space20" Text="Update" style="float:right;margin-right:10px;"></asp:LinkButton>
 									
                                                </td>
							</tr>
                    
                    
                    
                    
                    
                    
                       
                    </ItemTemplate>
                </asp:ListView>
                <div class="tab-footer clear">
                    <asp:DataPager runat="server" ID="pager" PagedControlID="ListViewMail" PageSize="5">
                        <Fields>
                            <peppPager:FollowingPagerField ButtonCount="5" />
                        </Fields>
                    </asp:DataPager>
                </div>
              
            </div>
            
        </div>
 
        <!-- ***** START DIV MESSAGGI DI ERRORE ***** -->
        <div id="DivSuccess" runat="server" visible="false" class="notification note-success">
            <a href="#" class="close" title="Close notification">close</a>
            <p>
                <strong>
                    <asp:Label ID="LabelSuccess" runat="server" Text=""></asp:Label></strong>
            </p>
        </div>
        <div id="DivError" runat="server" visible="false" class="notification note-error">
            <a href="#" class="close" title="Close notification">close</a>
            <p>
                <strong>
                    <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>
                </strong>
            </p>
        </div>
        <!-- ***** END DIV MESSAGGI DI ERRORE ***** -->
        <asp:HiddenField runat="server" ID="hdnmailID" />
    </div>
    <div class="content-box">
        <div class="box-body">
            <div class="box-header clear">
                <ul class="tabs clear">
                   <%-- <li><a href="#italiano">ITALIANO</a></li>
                    <li><a href="#inglese">INGLESE</a></li>--%>
                </ul>
                <h2>
                    :: e-mail</h2>
            </div>
            <div class="box-wrap clear">
                <div id="italiano">
                    <table class="style1">
                        <thead>
                            <tr>
                                <th>
                                     
                                </th>
                                <th class="full">
                                     
                                </th>
                                <th>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th>
                                    e-mail <span class="required">*</span>
                                </th>
                                <td class="edit-field long" colspan="2">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="required fl-space2" ></asp:TextBox>
                                    <div class="clear"></div>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitolo" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="<div style='width:99.6%; margin-top:5px; margin-bottom:3px;' class='notification note-attention'><p><b>Warning: </b>required field.</p></div>"
                                        Display="Dynamic">
                                   
                                    </asp:RequiredFieldValidator>
                                </td>
                                
                            </tr>
                         
                        </tbody>
                    </table>
                </div>
                
                <div class="rule2">
                </div>
                <div class="form-field clear">
                    <asp:Button CausesValidation="false" ID="ButtonAnnulla" CssClass="button red fr"
                        runat="server" Text="Cancel" OnClick="ButtonAnnulla_Click" Style="margin-left: 10px;" />
                    <asp:Button ID="ButtonInsert" CssClass="button green fr" runat="server" Text="Add e-mail"
                        OnClick="ButtonInsert_Click" />
                    <asp:Button ID="ButtonAgg" Visible="false" CssClass="button blue fr" runat="server"
                        Text="Update" OnClick="ButtonAgg_Click" />
                </div>
            </div>
        </div>
    </div>
    
    
     <div class="content-box">
        <div class="box-body">
            <div class="box-header clear">
                <ul class="tabs clear">
                    
                </ul>
                <h2>
                    :: Edit NewsLetter</h2>
            </div>
            <div class="box-wrap clear">
                <div id="Div1">
                    <table class="style1">
                        <thead>
                            <tr>
                                <th>
                                     
                                </th>
                                <th class="full">
                                     
                                </th>
                                <th>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th>
                                    Newsletter <span class="required">*</span>
                                </th>
                               <td class="edit-field long" colspan="2">
                                <FCKeditorV2:FCKeditor Height="400px" EnableViewState="false" ID="FCKeditor1" runat="server"
                                    BasePath="~/FKeditor/" ToolbarSet="NewsInsert">
                                </FCKeditorV2:FCKeditor>
                            </td>
                                
                            </tr>
                         
                        </tbody>
                    </table>
                </div>
                
                <div class="rule2">
                </div>
                <div class="form-field clear">
                    <%--buttons--%><asp:LinkButton CausesValidation="false" CssClass="button blue fl-space2" OnClientClick="return confirm('Confirm?')"  OnClick="ButtonSave_template" ID="lnkbrnSaveTemplate" runat="server">Save Template</asp:LinkButton>
                                <asp:LinkButton CausesValidation="false" CssClass="button" OnClientClick="return confirm('Confirm?')"  OnClick="ButtonInviaNl_Click" ID="lnkbtnSendNL" runat="server">Send NewsLetter</asp:LinkButton>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
