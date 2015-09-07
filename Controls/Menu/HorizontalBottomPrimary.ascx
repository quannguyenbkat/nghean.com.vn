<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HorizontalBottomPrimary.ascx.cs" Inherits="Controls_Menu_HorizontalBottomPrimary" %>
<%=Include.CssAdd("~/BICSkins/Menu/Bottom/Bottom.css") %>
<bic:Menu ID="mnMenu" Skin="Bottom" PersistLoadOnDemandItems="true" EnableEmbeddedScripts="True" EnableEmbeddedSkins="false" TypeId="1" Flow="Horizontal"  runat="server" />
<script type="text/javascript">
    $(document).ready(function() {
        $(".rmLast span.rmText").css("padding-right", "0");
        $(".rmLast span.rmText .fix_right").css("background", "none");
    });
</script>