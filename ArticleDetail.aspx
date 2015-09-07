<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ArticleDetail.aspx.cs" Inherits="ArticleDetail" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controls/Article/ArticleDetail.ascx" TagPrefix="uc1" TagName="ArticleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <uc1:ArticleDetail runat="server" ID="UcArticleDetail" />
</asp:Content>
