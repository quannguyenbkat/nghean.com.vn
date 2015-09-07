<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>
<%@ Register src="Controls/Download/Download.ascx" tagname="Download" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <uc1:Download ID="Download1" runat="server" />
</asp:Content>