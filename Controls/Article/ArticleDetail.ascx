<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleDetail.ascx.cs" Inherits="Controls_Article_ArticleDetail" %>
<%@ Register Src="ArticleReference.ascx" TagName="ArticleReference" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/Article/Tools/BottomToolbar.ascx" TagPrefix="uc1" TagName="BottomToolbar" %>
<%@ Register Src="~/Controls/Article/Tools/TopToolbar.ascx" TagPrefix="uc1" TagName="TopToolbar" %>

<div class="article_detail">
    <h1 id="h1title" runat="server">
        <asp:Label runat="server" ID="ltlTitle" CssClass="title_article"></asp:Label>
    </h1>
    <div id="fixtoolbar" runat="server">
        <uc1:TopToolbar runat="server" ID="TopToolbar" />
    </div>
    <div id="divDetailContent">
        <asp:Literal runat="server" ID="ltlDescription"></asp:Literal>
    </div>
    <div class="clear"></div>
    <div id="fixtoolbar2" runat="server">
        <uc1:BottomToolbar runat="server" ID="BottomToolbar" />
    </div>
    <div class="clear"></div>
    <uc3:ArticleReference ID="articleReference" runat="server" />
</div>

