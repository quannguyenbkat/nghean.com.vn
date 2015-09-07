<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OtherGalleryType.ascx.cs"
    Inherits="Controls_GalleryType" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="othergallery">
    <div class="cap-b">
        <div class="caption_other">
            <a class="prev-pro"></a>
            <span class="label"><%= BicResource.GetValue("Gallery_Orther") %></span>
            <a class="next-pro"></a>
        </div>
    </div>
    <div class="list" id="album-scroll">
        <bic:ArticleListViewTopPager runat="server" ExtensionLink="HTML" ID="galleryRef" SelectFields="ImageName">
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
    </div>
    <div class="clear">
        <div id="divPage" class="divPage bottom" runat="server">
        <bic:PagerUI ID="pager" CssClass="pager" SelectedCssClass="pager_selected" Label='' runat="server" PagerUIStep="5" OnPageIndexChanged="pager_PageIndexChanged" />
    </div>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $(".othergallery .list").carouFredSel({
            auto: true,
            items: 3,
            scroll: {
                items: 1,
                duration: 1000,
                pauseDuration: 3000,
                pauseOnHover: "immediate"
            },
            prev: ".next-pro",
            next: ".prev-pro"
        });
    });
</script>
