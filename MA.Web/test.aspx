<%@ Page Title="" Language="C#" MasterPageFile="~/test.master" AutoEventWireup="true"
    CodeFile="test.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="shadowbox-3.0.3/shadowbox.css">

    <script type="text/javascript" src="shadowbox-3.0.3/shadowbox.js"></script>

    <script type="text/javascript">
        Shadowbox.init({
            // let's skip the automatic setup because we don't have any
            // properly configured link elements on the page
            skipSetup: true
        });
    </script>

    <script type="text/javascript">
        function giveFocus() {
            alert("ciao pepp");
        }
        window.onload = giveFocus;
    </script>

    <script type="text/javascript">


        jQuery(document).ready(function($) {

            alert("ciao");

        });

     
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
</asp:Content>
