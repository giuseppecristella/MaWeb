<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shop.Web.Mvp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
   

    <div class="container" ng-app="app" ng-controller="scCatalogCtrl" >
        <div ng-controller="scCatalogCtrl">
            mamt
            <div ng-repeat="product in catalog">
                aaaa{{product.name}}
            </div>
        </div>
    </div>
</asp:Content>
