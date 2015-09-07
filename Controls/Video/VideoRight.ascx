<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoRight.ascx.cs"
    Inherits="Controls_Video_HiLiArticleVideo" %>
<%@ Import Namespace="BIC.Utils" %>
<%=Include.Jwplayer() %>
<%=Include.Video() %>

    <div id="VideoRight" class="menu fl ">
        <div class="skew-bar3">
             <bic:MenuCaption runat="server" ID="mncap"></bic:MenuCaption>
        </div>
        <div class="list">
            <div class="divcontent nbicontent">
                <bic:ArticleListViewTop runat="server" ID="lvArticleVideo" Prefix="vd" ExtensionLink="HTML" PageSize="3">
                    <LayoutTemplate>
                        <div class="articlelist loading16">
                            <div class="avVideo">
                                <div id="avView">
                                </div>
                            </div>
                            <div class="scrollVd">
                                <asp:PlaceHolder runat="server" ID="GroupPlaceHolder"></asp:PlaceHolder>
                            </div>
                        </div>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <ul class="avList" style="display: none">
                            <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                        </ul>
                    </GroupTemplate>
                    <ItemTemplate>
                       <%# Container.DataItemIndex  == 0 ? "<div class='avItem" + Eval("FileType")+"'> <a val='"+Eval("VideoUrl")+"' image='"+Page.ResolveUrl("~/"+Eval("ImageThumb"))+"' target='"+Eval("Target")+"'></a></div><div class='active_video'> <a onclick=\"PlayVideo('"+ Eval("VideoUrl") +"',this); return false;\" val='"+ Eval("VideoUrl") +"' title='"+Eval("Title") +"'>"+ BicString.TrimText(Eval("Title"),90) +"</a> </div>" : "<div class='link-video'> <a onclick=\"PlayVideo('"+ Eval("VideoUrl") +"',this); return false;\" val='"+ Eval("VideoUrl") +"' title='"+Eval("Title") +"'>"+ BicString.TrimText(Eval("Title"),90)  + "</a></div> " %>
                    </ItemTemplate>
                </bic:ArticleListViewTop>
            </div>
        </div>
    </div>
<script type="text/javascript">
    $(document).ready(function () {
        $("#VideoRight .avList").VideoList("avView", 267, 230);
        $(".alimgView #mediahere").VideoView($(".alimgView #mediahere").attr("val"), 267, 230, false);
    });
</script>

