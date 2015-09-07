<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" MaintainScrollPositionOnPostback="false" AutoEventWireup="true" CodeFile="Searching.aspx.cs" Inherits="Searching" %>

<%@ Register Src="~/Controls/Search/SearchingResult.ascx" TagPrefix="uc1" TagName="SearchingResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <uc1:SearchingResult runat="server" ID="SearchingResult" />
</asp:Content>

