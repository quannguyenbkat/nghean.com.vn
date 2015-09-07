<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MessageSuccess.ascx.cs" Inherits="Controls_ShoppingCart_MessageSuccess" %>
<%@ Import Namespace="BIC.Utils" %>
<div>
    <img style="float: right;" src="<%=ResolveUrl("~") %>Controls/ShoppingCart/img/loading-ajax.gif" />
</div>
<div class="successMsg">
    <span>
        <%=BicResource.GetValue("ShoppingCart","Success") %>
    </span>
</div>
<%--<div class="redirecting">
    <asp:Button ID="btRedirect" runat="server" Text='<%$Resources:ShoppingCart, Redirecting%>' OnClick="btRedirect_Click" />
     <img src="<%=ResolveUrl("~") %>Controls/ShoppingCart/img/loading-ajax.gif" />
</div>--%>
<div class="order-success">
    <a href='<%= Common.GetSiteUrl() %>' class="btn-bg">Trở về trang chủ</a>
    <asp:LinkButton runat="server" ID="btnGoToOrder" Text="Tới trang quản lý đơn hàng" OnClick="btRedirect_Click" CssClass="btn-bg"></asp:LinkButton>
</div>
