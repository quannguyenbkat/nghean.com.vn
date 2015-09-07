<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ArticleListing.aspx.cs" Inherits="ArticleListing" MaintainScrollPositionOnPostback="false" %>

<%@ Register Src="~/Controls/Article/ArticleListing.ascx" TagPrefix="uc1" TagName="ArticleListing" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <uc1:ArticleListing runat="server" ID="UcArticleListing" />
</asp:Content>
