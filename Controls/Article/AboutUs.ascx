<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AboutUs.ascx.cs" Inherits="Controls_Article_Base_AboutUs" ViewStateMode="Disabled" %>

<div class="about_us margin_right_22px">
    <bic:Image CssClass="image" ID="imgAboutUs" runat="server" LoadThumbnail="False" ImageName='<%# Eval("ImageName") %>' HeightOfImage="172" WidthOfImage="295" />
    <div class="title">
        <a runat="server" id="aAboutUs1">
            <asp:Literal runat="server" ID="ltrTitleAboutUs"></asp:Literal></a>
    </div>
    <div class="content">
        <asp:Literal runat="server" ID="ltlBriefDescription" />
    </div>
    <div class="btn_detail">
        <a runat="server" id="aAboutUs2">
            <asp:Literal ID="ltlDetail" runat="server" /></a>
    </div>
</div>
