<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SliderLogo.ascx.cs" Inherits="Controls_Adv_Adv" %>
<%=Include.CssAdd("~/Controls/Adv/Adv.css") %>
    <div class="slide_partner">
        <div class="mncap">
            <asp:Literal runat="server" ID="ltrName"></asp:Literal>
        </div>
        <div class="slider-logo2">
            <asp:ListView ID="dlSliderList" runat="server">
                <ItemTemplate>
                    <div class="item">
                       <div class="image">
                        <%#Eval("Description")%>
                    </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
<script type="text/javascript">
    $(window).load(function () {
        $('.slider-logo2').carouFredSel({
            scroll: {
                items: 1,
                duration: 5000,
                queue: true,
                timeoutDuration: 0,
                easing: "linear",
                pauseOnHover: "immediate-resume",
                fx: "scroll"
            },
            items: 4,
            width:366
        });
    });
</script>
