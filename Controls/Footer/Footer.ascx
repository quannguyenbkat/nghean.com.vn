<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="Controls_footer" %>
<%@ Register Src="~/Controls/Menu/HorizontalBottomPrimary.ascx" TagPrefix="uc1" TagName="HorizontalBottomPrimary" %>
<%@ Register Src="~/Controls/Adv/Adv.ascx" TagPrefix="uc1" TagName="Adv" %>


<div id="footer">
    <div class="nav-bottom">
        <uc1:HorizontalBottomPrimary runat="server" ID="HorizontalBottomPrimary" TypeID="4" />
    </div>
    <div class="footer-info">
        <uc1:Adv runat="server" ID="Adv" TypeOfAdv="6" />
    </div>
</div>
