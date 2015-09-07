<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<%@ Register Src="~/Controls/Product/ProductDetail.ascx" TagPrefix="uc1" TagName="ProductDetail" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <uc1:ProductDetail runat="server" id="UcProductDetail" />
</asp:Content>
