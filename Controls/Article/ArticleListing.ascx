<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListing.ascx.cs"  Inherits="Controls_Article_ArticleListing" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="articlelisting">
        <bic:ArticleListViewTopPager ID="ArticleList" PageSize="6" ExtensionLink="HTML" runat="server" ShowTodayCss="True" SelectFields="ImageName,BriefDescription" EnableAutoRedirect="True">
            <ItemTemplate>
                <div class="item">
                        <bic:Image CssClass="aliimg fl hot" ID="Image1"  runat="server"  WidthOfImage="187" HeightOfImage="122" LoadThumbnail="True" ImageName='<%# Eval("ImageName") %>'
                            Link='<%# Eval("Url") %>' Target='<%# Eval("Target") %>' Alt='<%# Eval("Title") %>' />
                        <a href="<%# Eval("Url") %>" title='<%# Eval("Title") %>' class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                        <%# Eval("Title") %> <span><%#Eval("NewsIcon")%></span></a>
                        <p>
                            <%# BicString.TrimText(Eval("BriefDescription").ToString(),350) %>
                        </p>
                </div>
            </ItemTemplate>
        </bic:ArticleListViewTopPager>
    <div class="page">
        <bic:PagerUI ID="pager" PageSize="12" CssClass="pager"  SelectedCssClass="current" Label='' runat="server" PagerUIStep="11" OnPageIndexChanged="pager_PageIndexChanged" />
    </div>
    </div>


