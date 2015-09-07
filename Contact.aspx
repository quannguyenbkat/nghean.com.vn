<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" MaintainScrollPositionOnPostback="false" %>

<%@ Import Namespace="BIC.Utils" %>

<%@ Register Src="~/Controls/Contact/Contact.ascx" TagPrefix="uc1" TagName="Contact" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
        <uc1:Contact runat="server" ID="Contact2" />
</asp:Content>


