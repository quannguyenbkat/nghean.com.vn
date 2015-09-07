<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserManage.ascx.cs" Inherits="Controls_User_UserManage" %>

<%@ Register Src="UserManageProfileTab.ascx" TagName="UserManageProfileTab" TagPrefix="uc2" %>
<%@ Register Src="UserManageChangePassTab.ascx" TagName="UserManageChangePassTab" TagPrefix="uc3" %>

<div class="UserManageBlock">
    <telerik:RadTabStrip runat="server" ID="rtsUserManage" Orientation="HorizontalTop" MultiPageID="radMultiPage">
        <Tabs>
            <telerik:RadTab runat="server" ID="radTabAdv" Text="<%$ Resources:UserManager,AccountInfomation %>" ClientIDMode="Static" />
            <telerik:RadTab runat="server" ID="radTabProfile" Text="<%$ Resources:UserManager,ChangePassword %>" ClientIDMode="Static" />
            <telerik:RadTab runat="server" ID="radTabTask" Text="Quản lý đơn hàng" ClientIDMode="Static" />
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="radMultiPage" CssClass="multiPage">
        <telerik:RadPageView runat="server" ID="pvwAdv" CssClass="corporatePageView" ClientIDMode="Static">
            <uc2:UserManageProfileTab ID="UserManageProfileTab1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="pvwProfile" CssClass="corporatePageView" ClientIDMode="Static">
            <uc3:UserManageChangePassTab ID="UserManageChangePassTab1" runat="server" />
        </telerik:RadPageView>
    </telerik:RadMultiPage>

</div>
