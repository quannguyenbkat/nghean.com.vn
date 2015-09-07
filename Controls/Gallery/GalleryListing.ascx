<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryListing.ascx.cs"
    Inherits="Controls_Gallery_GalleryListing" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="../Navigate/NavigatePath.ascx" TagName="NavigatePath" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Social/ShareSocial.ascx" TagPrefix="uc2" TagName="ShareSocial" %>
<%= Include.Gallery()%>
<%--<div class="cap1"><div class="bgrightTitle"><div class="caption"><bic:MenuCaption ID="mncap" runat="server"></bic:MenuCaption></div></div></div>--%>
<div class="gallery_listing">
    <div class="list">
        <bic:ArticleListViewTopPager Prefix="gd" runat="server" ExtensionLink="HTML" ID="articleGallery" SelectFields="ImageName" GroupItemCount="3">
            <LayoutTemplate>
                <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <GroupTemplate>
                <div class="groupitem">
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </div>
            </GroupTemplate>
            <ItemTemplate>
                <div class='<%# (Container.DataItemIndex)%3==0 ? "item firts":"item" %>'>
                    <div class="imageviewer">
                        <bic:Image CssClass="item-image" ID="Image2" runat="server" ImageName='<%# Eval("ImageName") %>'
                            Link='<%# Eval("Url") %>' Target='<%# Eval("Target") %>' Alt='<%# Eval("Title") %>' />
                        <div class="name">
                            <a class="title" href='<%#Eval("Url")%>' target='<%#Eval("Target")%>'>
                                <%# BicString.TrimText(Eval("Title").ToString(),100) %>
                            </a>
                        </div>
                    </div>

                </div>
            </ItemTemplate>
        </bic:ArticleListViewTopPager>
        <div class="clear"></div>
    </div>
    <div id="divPage" class="divPage bottom" runat="server">
        <bic:PagerUI ID="pager" CssClass="pager" SelectedCssClass="pager_selected" Label='' runat="server" PagerUIStep="5" OnPageIndexChanged="pager_PageIndexChanged" />
    </div>
</div>
