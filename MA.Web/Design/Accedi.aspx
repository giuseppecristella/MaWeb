<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Default_r.master" AutoEventWireup="true"
    CodeFile="Accedi.aspx.cs" Inherits="shop_Accedi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div style="margin-top: 20px;" class="one">
        <div style="width: 305px; min-height: 580px;" class="one-third">
            <h4>
                Accedi</h4>
            <asp:Login  CssClass="table_reset" ID="Login1" runat="server"
                OnLoggedIn="btnLogin_Click">
                <LayoutTemplate>
                    <fieldset>
                        <label style="border: none;">
                            Nome Utente
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                ErrorMessage="<span class='required'> * inserire Nome Utente</span>" ToolTip="inserire Nome Utente"
                                ValidationGroup="Login1"></asp:RequiredFieldValidator>
                        </label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="text"></asp:TextBox>
                    </fieldset>
                    <fieldset>
                        <label for="password">
                            Password
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                ErrorMessage="<span class='required'> * inserire Password</span>" ToolTip="inserire Password"
                                ValidationGroup="Login1"></asp:RequiredFieldValidator></label>
                        <asp:TextBox ID="Password" CssClass="text" runat="server" TextMode="Password"></asp:TextBox>
                    </fieldset>
                    <br />
                    <fieldset>
                        <asp:Button CssClass="fancy-button green small" ID="LoginButton" runat="server" CommandName="Login"
                            Text="Accedi" ValidationGroup="Login1" />
                    </fieldset>
                </LayoutTemplate>
            </asp:Login>
        </div>
        <div style="width: 305px;" class="one-third">
            <h4>
                Registrati</h4>
            <label>
                Nome<asp:RequiredFieldValidator ID="rqrtxtFirstName" runat="server" ControlToValidate="txtFirstName"
                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1" />
            </label>
            <asp:TextBox runat="server" ID="txtFirstName" class="text medium-size" />
            <label>
                Cognome<asp:RequiredFieldValidator ID="rqrtxtLastName" runat="server" ControlToValidate="txtLastName"
                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1" />
            </label>
            <asp:TextBox runat="server" ID="txtLastName" class="text medium-size" />
            <label>
                Indirizzo<asp:RequiredFieldValidator ID="rqrtxtAddress" runat="server" ControlToValidate="txtAddress"
                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1" />
            </label>
            <asp:TextBox runat="server" ID="txtAddress" class="text" />
            <label>
                CAP<asp:RequiredFieldValidator ID="rqrtxtCap" runat="server" ControlToValidate="txtCap"
                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1" />
            </label>
            <asp:TextBox runat="server" ID="txtCap" class="text" />
            <label class="grid_4 alpha" style="margin-right: 0">
                Città<asp:RequiredFieldValidator ID="rqrtxtCity" runat="server" ControlToValidate="txtCity"
                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1" />
            </label>
            <asp:TextBox runat="server" ID="txtCity" class="text" />
            <label class="grid_4 alpha" style="margin-right: 0">
                Provincia<asp:RequiredFieldValidator ID="rqrtxtRegion" runat="server" ControlToValidate="txtRegion"
                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1" />
            </label>
            <asp:TextBox runat="server" ID="txtRegion" class="text" />
            <label>
                Tel<asp:RequiredFieldValidator ID="rqrtxtTel" runat="server" ControlToValidate="txtTel"
                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1" />
            </label>
            <asp:TextBox runat="server" ID="txtTel" class="text" />
        </div>
        <div style="width: 305px;" class="one-third last">
            <div style="display: block; height: 53px;">
            </div>
            <asp:CreateUserWizard LoginCreatedUser="True" DuplicateUserNameErrorMessage="utente già presente"
                DuplicateEmailErrorMessage="email già presente" ID="CreateUserWizard1" runat="server"
                OnCreatedUser="CreateMagentoUser" CompleteSuccessText="Registrazione effettuata con successo."
                ContinueButtonText="Continua lo shopping" ContinueButtonType="Link" ContinueDestinationPageUrl="~/Design/Catalogo.html"
                FinishDestinationPageUrl="~/Contatti.aspx">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        <ContentTemplate>
                            <label>
                                Nome Utente<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1"> </asp:RequiredFieldValidator></label>
                            <asp:TextBox runat="server" CssClass="text medium-size" ID="UserName" />
                            <label>
                                E-Mail<asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                    ErrorMessage=" * campo obbligatorio" ToolTip="Il valore Posta elettronica è obbligatorio."
                                    Display="Dynamic" ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="EmailValidator" runat="server" ControlToValidate="Email" ErrorMessage=" * formato email non corretto."
                                        ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
                                        Display="Dynamic" ValidationGroup="CreateUserWizard1"></asp:RegularExpressionValidator></label>
                            <asp:TextBox runat="server" CssClass="text" ID="Email" />
                            <label>
                                Password<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1"> </asp:RequiredFieldValidator></label>
                            <asp:TextBox runat="server" TextMode="Password" class="text" ID="Password" />
                            <fieldset>
                                <label>
                                    Conferma Password
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="le passwords non coincidono"
                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1"> </asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox runat="server" TextMode="Password" class="text" ID="ConfirmPassword" />
                            </fieldset>
                            <br />
                            <fieldset>
                                <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Registrati"
                                    ValidationGroup="CreateUserWizard1" CssClass="fancy-button red small" /></fieldset>
                            <fieldset>
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </fieldset>
                        </ContentTemplate>
                        <CustomNavigationTemplate>
                        </CustomNavigationTemplate>
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep runat="server">
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </div>
        <div class="one">
            <div class="clear-line">
            </div>
            <div runat="server" id="divErr" visible="false" class="simple-error">
                <div>
                    <asp:Literal ID="lblErr" runat="server" Text=""></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
