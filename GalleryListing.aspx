<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" MaintainScrollPositionOnPostback="false" AutoEventWireup="true" CodeFile="GalleryListing.aspx.cs" Inherits="GalleryListing" %>

<%@ Register Src="Controls/Gallery/GalleryListing.ascx" TagName="GalleryListing" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
        <uc1:GalleryListing ID="GalleryListing1" runat="server" />
</asp:Content>
