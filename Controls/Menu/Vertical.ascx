<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Vertical.ascx.cs" Inherits="Controls_Menu_Vertical" %>
<link href='<%=Page.ResolveUrl("~/BICSkins/Menu/Vertical/Vertical.css")%>' rel="stylesheet" type="text/css" /> 
<div class="Vertical <%=_CssClass%>">
   <%-- <div class="title_box">
        <asp:Label runat="server" ID="lbltext"></asp:Label>
    </div>--%>
    <telerik:RadMenu runat="server" ID="rpbMenu2" Skin="Left" EnableEmbeddedSkins="false" PersistLoadOnDemandItems="true"  Flow="Vertical">
    </telerik:RadMenu>
</div>
<script type="text/javascript">
    $(function() {
        var local = window.location.pathname;
        $(".Vertical  ul.rmVertical li a").each(function () {
            var href = $(this).attr("href");
           // var ind = local.indexOf(href);
            if (href == local) {
                $(".Vertical ul li a").removeClass(".activemenu");
                $(this).parent().addClass("activeli");
                $(this).children().addClass("activemenu");
            }
        });
    });
</script>