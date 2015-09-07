<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductGroupListing.aspx.cs" Inherits="ProductGroupListing" %>

<%@ Register Src="~/Controls/Product/ProductGroup.ascx" TagPrefix="uc1" TagName="ProductGroup" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <uc1:ProductGroup runat="server" ID="ProductGroup" />
</asp:Content>
