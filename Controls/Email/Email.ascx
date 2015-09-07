<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Email.ascx.cs" Inherits="Controls_Email_Email" %>

<div class="subscribe">
        <div class="textbox">
            <asp:TextBox ID="txtsend" CssClass="inp-email" ClientIDMode="Static" runat="server" placeholder="<%$Resources:Resource,EmailAddress%>" Text="" ValidationGroup="email"></asp:TextBox>
            <asp:Button ID="lnkSend" CssClass="btn-sendmail" runat="server" OnClick="ibtSend_Click" Text=" " ValidationGroup="email"></asp:Button>
        </div>
        <div class="text-subscribe">Đăng kí nhận tin</div>
</div>
