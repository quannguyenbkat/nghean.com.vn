﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionRoom.ascx.cs" Inherits="Admin_Components_Room_EditionRoom" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelector.ascx" TagName="ImageSelector" TagPrefix="bic" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelectMulti.ascx" TagName="ImageSelectorMulti" TagPrefix="bic" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" ValidationGroup="admin" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.EditTitle%>
    <span class="note"><em>*</em>
        <%= BicMessage.RequireTitle%>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ngôn ngữ
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" Width="200px" CssClass="input-select" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
                </bic:Language>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Điểm đến
            </div>
            <div class="input">
                <telerik:RadTreeView runat="server" Skin="Outlook" Width="500px" CheckBoxes="true" ID="tvMenuUser" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                    CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" ExpandAnimation-Type="InQuart" SingleExpandPath="False" OnNodeExpand="tvMenuUser_NodeExpand">
                </telerik:RadTreeView>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tên điểm đến<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtRoomName" CssClass="input-text" Width="95%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Điện thoại
            </div>
            <div class="input">
                <asp:TextBox ID="txtPrice" CssClass="input-text" Width="200px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ảnh đại diện
            </div>
            <div class="input">
                <bic:ImageSelector ID="isImageID" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Các ảnh khác
            </div>
            <div class="input">
                <bic:ImageSelectorMulti ID="ismImageArray" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Giờ mở cửa
            </div>
            <div class="input">
                <asp:TextBox ID="txtGioMoCua" CssClass="input-text" Width="200px" runat="server" />
            </div>
            <%--<bic:Editor Height="300px" Skin="Office2007" Width="98%" ID="reBriefDescription" ToolbarMode="ShowOnFocus" ToolsFile="~/admin/XMLData/Editor/SmallSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="All" />--%>
        </div>
    </div>
</div>
<div class="frow">
    <div class="frow-wrapp">
        <div class="label">
            Giới thiệu chung
        </div>
        <div class="input">
            <%=IncludeAdmin.RadEditor() %>
            <bic:Editor Height="600px" ID="reBody" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml" ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                ToolbarMode="RibbonBar" Skin="Office2007" />
        </div>
    </div>
</div>
<div class="frow">
    <div class="frow-wrapp">
        <div class="label">
            Địa chỉ
        </div>
        <div class="input">
            <asp:TextBox ID="txtLink" CssClass="input-text" Width="200" runat="server" />
        </div>
    </div>
</div>
<div id="Div1" class="frow" runat="server" visible="True">
    <div class="frow-wrapp">
        <div class="label">
            Link bản đồ
        </div>
        <div class="input">
            <asp:TextBox runat="server" ID="txtTag" CssClass="input-text" Width="95%" />
        </div>
    </div>
</div>
<div id="Div2" class="frow" runat="server">
    <div class="frow-wrapp">
        <div class="label">
            Website
        </div>
        <div class="input">
            <asp:TextBox runat="server" ID="txtWebsite" CssClass="input-text" Width="95%" />
        </div>
    </div>
</div>
<div class="frow">
    <div class="frow-wrapp">
        <div class="label">
            Lượt
        </div>
        <div class="input">
            <asp:TextBox ID="txtViewed" CssClass="input-text" Width="100" runat="server" />
        </div>
    </div>
</div>
<div class="frow">
    <div class="frow-wrapp">
        <div class="label">
            Duyệt
        </div>
        <div class="input">
            <asp:CheckBox runat="server" Enable="<%#Approved%>" ID="chkIsActive" />
        </div>
    </div>
</div>
<div class="frow">
    <div class="frow-wrapp">
        <div class="label">
            Trang chủ
        </div>
        <div class="input">
            <asp:CheckBox runat="server" ID="chkHome" />
        </div>
    </div>
</div>
<div class="frow">
    <div class="frow-wrapp">
        <div class="label">
            Thứ tự
        </div>
        <div class="input">
            <asp:DropDownList runat="server" ID="ddlPosition" />
        </div>
    </div>
</div>

<asp:TextBox runat="server" ID="TextBox1" CssClass="input-text hidden" />
<div class="frow">
    <div class="frow-wrapp">
        <div class="label">
            Tiêu đề SEO
        </div>
        <div class="input">
            <asp:TextBox runat="server" ID="txtSeoTitle" CssClass="input-text" Width="95%" />
        </div>
    </div>
</div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhRoomName" EmptyMessage="Nhập tên phòng" Validation-ValidationGroup="admin" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtRoomName" />
        </TargetControls>
    </telerik:TextBoxSetting>
</telerik:RadInputManager>
