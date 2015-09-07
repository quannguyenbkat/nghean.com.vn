<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Language.ascx.cs" Inherits="Controls_Language" %>
<div id="language">
    <asp:LinkButton runat="server" CssClass="vi" ID="btnVI" Text="Tiếng Việt" OnCommand="LanguageCommand" CommandName="vi" />
    <asp:LinkButton runat="server" CssClass="en" ID="btnEN" Text="English" OnCommand="LanguageCommand" CommandName="en" />
</div>
