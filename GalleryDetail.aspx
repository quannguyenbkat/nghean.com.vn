<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" MaintainScrollPositionOnPostback="false" AutoEventWireup="true" CodeFile="GalleryDetail.aspx.cs" Inherits="GalleryDetail" %>

<%@ Register Src="Controls/Gallery/GalleryDetail.ascx" TagName="GalleryDetail" TagPrefix="uc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
        <uc1:GalleryDetail ID="GalleryDetail1" runat="server" />
</asp:Content>