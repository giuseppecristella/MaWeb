<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_MA_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- Reset Stylesheet -->
<link rel="stylesheet" href="login_Css/reset.css" type="text/css" media="screen" />
<!-- Main Stylesheet -->
<link rel="stylesheet" href="login_Css/style.css" type="text/css" media="screen" />
<!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
<link rel="stylesheet" href="login_Css/invalid.css" type="text/css" media="screen" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body id="login">
    <form id="form1" runat="server">
    <div id="login-wrapper" class="png_bg">
        <div id="login-top">
            <h1>
                Simpla Admin</h1>
            <!-- Logo (221px width) -->
            <img style="background: #fff; padding: 5px; border: 5px solid #d0d0d0" id="logo"
                src="img/logo.png" alt="Matera Admin logo">
        </div>
        <!-- End #logn-top -->
        <div id="login-content">
            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Admin_MA/Default.aspx">
                <LayoutTemplate>
                    <div class="notification information png_bg">
                        <div>
                            Inserire le credenziali per accedere.
                        </div>
                    </div>
                    <p>
                        <label>
                            Username</label>
                        <%--<input class="text-input" type="text">--%>
                        <asp:TextBox ID="UserName" runat="server" CssClass="text-input"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                    </p>
                    <div class="clear">
                    </div>
                    <p>
                        <label>
                            Password</label>
                        <asp:TextBox ID="Password" CssClass="text-input" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                    </p>
                    <div class="clear">
                    </div>
                    <p id="remember-password">
                        <asp:CheckBox Style="float: right;" ID="RememberMe" runat="server" />Memorizza password
                        &nbsp;
                    </p>
                    <div class="notification error png_bg">
                        <div>
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <p>
                        <asp:Button CssClass="button" ID="LoginButton" runat="server" CommandName="Login"
                            Text="Accedi" ValidationGroup="Login1" />
                    </p>
                    <!-- End #login-content -->
                </LayoutTemplate>
            </asp:Login>
        </div>
    </div>
    </form>
</body>
</html>
