<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" %>
<%@ Register Src="~/Controls/User/UserManage.ascx" TagPrefix="uc1" TagName="UserManage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
        <uc1:UserManage runat="server" ID="UserManage" />
</asp:Content>
