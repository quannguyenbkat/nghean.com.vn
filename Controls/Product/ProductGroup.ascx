<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductGroup.ascx.cs" Inherits="Controls_Product_ProductGroup" %>
<%@ Import Namespace="BIC.Utils" %>



<%= Include.Product()%>

<div class="productGroup">
    <div class="title">
        <h1 style="font-weight: normal"><bic:MenuCaption runat="server" CssClass="mncap" ID="mncap"></bic:MenuCaption></h1>
    </div>
    <div class="list">
        <asp:ListView ID="ProductListgroup2" runat="server" GroupItemCount="4" OnItemDataBound="MenuParentItemDataBound">
            <GroupTemplate>
                <ul class='groupitem'>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </ul>
            </GroupTemplate>
            <ItemTemplate>
                <li>
                        <bic:Image CssClass="item-image  sp" ID="Image1" runat="server" WidthOfImage="205" HeightOfImage="144" ImageName='<%# Eval("ImageName")%>'
                            Link='<%# Page.ResolveUrl(_Getlink(Eval("URL").ToString(),Eval("UrlName").ToString()))  %>' Target='<%#BicConvert.ToString(Eval("Target"))%>' Alt='<%# Eval("Name")%>' />
                        <a href='<%# Page.ResolveUrl(_Getlink(Eval("URL").ToString(),Eval("UrlName").ToString()))  %>' target='<%#BicConvert.ToString(Eval("Target"))%>' title='<%#Eval("Name")%>'>
                            <%# Eval("Name")%> 
                        </a>
                </li>
            </ItemTemplate>
        </asp:ListView>
        
    </div>
    <div class="page">
        <bic:PagerUI ID="pager" CssClass="pager" Previous="<<" Next=">>" SelectedCssClass="pager_selected" EnableNextPrev="True" runat="server" PagerUIStep="10" OnPageIndexChanged="pager_PageIndexChanged" />
    </div>
</div>










