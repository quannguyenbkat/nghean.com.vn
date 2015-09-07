<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Banner.ascx.cs" Inherits="Controls_Adv_Banner" %>
<%= Include.NivoSlider()%>
<link href='<%=Page.ResolveUrl("~/Controls/Adv/Adv.css")%>' rel="stylesheet" type="text/css" />
<div id="baner" class="nivoSlider" >
    <asp:ListView ID="dlSliderList" runat="server">
        <ItemTemplate>
            <%#Eval("URL").ToString().Trim()==""?"":"<a href='"+Eval("URL")+"' target='"+Eval("Target").ToString().Trim()+"'>" %>
                <span class="nivo-imageLink">
                    <%#Eval("Description")%>
                </span>
            <%#Eval("URL").ToString().Trim()==""?"":"</a>" %>
        </ItemTemplate>
    </asp:ListView>
</div>
<script type="text/javascript">

    $(window).load(function () {
        var th = "_thumb.";
        var ch = ".";
        $("img").attr("src").replace(th, ch);
        if ($('.nivo-imageLink').length > 1)
        {
            $('#baner').nivoSlider({
                effect: "random",
                pauseTime: 3000,
                controlNavThumbs: false,
                manualAdvance: false,
                directionNav: false,
                controlNav: true
            });
        } else {
            $('#baner').nivoSlider({
                effect: "random",
                pauseTime: 5000,
                controlNavThumbs: false,
                manualAdvance: false,
                directionNav: false,
                controlNav: false
            });
        }
    });

</script>