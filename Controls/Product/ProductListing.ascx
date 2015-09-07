<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductListing.ascx.cs" Inherits="Controls_Product_ProductListing" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Navigate/NavigatePath.ascx" TagPrefix="uc1" TagName="NavigatePath" %>
<div class="productListing">
    <bic:ProductListViewTopPager runat="server" ID="ProductList" EnableAutoRedirect="True" ExtensionLink="HTML" SelectFields="ImageName" GroupItemCount="4">
        <GroupTemplate>
            <ul>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
            </ul>
        </GroupTemplate>
        <ItemTemplate>
             <li>
                        <a href='<%# Eval("Url") %>' title='<%# Eval("Title") %>' class="roll"></a>
                        <bic:Image runat="server" ID="avatar" CssClass="imgAva" ImageName='<%# Eval("ImageName") %>' Target='<%# Eval("Target") %>' Title='<%# Eval("Title") %>' Alt='<%# Eval("Title") %>' Link='<%# Eval("Url") %>'></bic:Image>
                        <a class="title" href='<%# Eval("Url") %>' title='<%# Eval("Title") %>'><%#Eval("Title") %> <%#Eval("NewsIcon")%></a>
                    </li>
        </ItemTemplate>
    </bic:ProductListViewTopPager>
    <div class="clear"></div>
    <div id="divPage" style="<%=count > 0?"": "display: none;"%> " class="product-navi clear fl">
        <bic:PagerUI ID="pager" SelectedCssClass="pager_selected" Label='' runat="server" Next=">>" Previous="<<" EnableNextPrev="True" PagerUIStep="10" OnPageIndexChanged="pager_PageIndexChanged" />
    </div>
</div>
