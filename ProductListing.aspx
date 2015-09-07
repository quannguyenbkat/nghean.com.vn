<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeFile="ProductListing.aspx.cs" Inherits="ProductListing" MaintainScrollPositionOnPostback="false" %>

<%@ Register Src="~/Controls/Product/ProductListing.ascx" TagPrefix="uc1" TagName="ProductListing" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <uc1:ProductListing runat="server" ID="UcProductListing" />
</asp:Content>
