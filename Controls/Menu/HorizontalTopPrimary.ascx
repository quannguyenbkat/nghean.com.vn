<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HorizontalTopPrimary.ascx.cs" Inherits="Controls_Menu_HorizontalTopPrimary" %>
<%= Include.CssAdd("~/BICSkins/Menu/Top/MenuTop.css") %>
<bic:Menu ID="mnMenu" Skin="Top" PersistLoadOnDemandItems="true" EnableEmbeddedScripts="True" EnableEmbeddedSkins="false" TypeId="1" Level="0" Flow="Horizontal" runat="server" />
<script type="text/javascript">
    $(document).ready(function () {
        $('.rmSlide .rmItem:first-child').removeClass('rmFirst');
        //$(".rmSlide").addClass("hidden");
        //$(".rmRootGroup > li:gt(3)").addClass("pull-right");
        //$(".rmRootGroup > li:lt(4)").addClass("pull-left");
    })

</script>
