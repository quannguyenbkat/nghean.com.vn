<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDetail.ascx.cs" Inherits="Controls_Product_ProductDetail" %>
<%@ Import Namespace="BIC.Utils" %>

<%@ Register Src="~/Controls/Product/ProductRef.ascx" TagPrefix="uc1" TagName="ProductRef" %>
<%@ Register Src="~/Controls/Product/Tools/TopToolbar.ascx" TagPrefix="uc1" TagName="TopToolbar" %>
<%@ Register Src="~/Controls/Product/Tools/BottomToolbar.ascx" TagPrefix="uc1" TagName="BottomToolbar" %>





<%= Include.ColorBox() %>
<div class="product_detail">
    <h1 class="title">
        <asp:Label runat="server" ID="lblNamePro"></asp:Label>
    </h1>
    <div class="clear"></div>
    <uc1:TopToolbar runat="server" ID="TopToolbar" />
    <div class="clear"></div>
    <div id="divDetailContent">
        <asp:Literal runat="server" ID="ltrBody"></asp:Literal>
    </div>
    <div class="clear"></div>
    <uc1:BottomToolbar runat="server" ID="BottomToolbar" />
    <div class="clear"></div>
    <uc1:ProductRef runat="server" ID="ProductRef" />
</div>
<script type="text/javascript">
    $('#divDetailContent img').each(function () {
        var urlImg = $(this).attr('src');
        var wImg = $(this).width();
        var hImg = $(this).height();
        $(this).wrap('<a class="colorbox" style="width:' + wImg + 'px ; height:' + 84 + 'px" href="' + urlImg + '" rel="groupthumb"></a>');
    });
    $("colorbox").click(function (e) {
        e.preventDefault();
    });

    $("a.colorbox").colorbox();
</script>
