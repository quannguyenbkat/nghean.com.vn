<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleVideoListing.ascx.cs" Inherits="Controls_Video_ArticleVideoListing" %>
<%@ Import Namespace="BIC.Utils" %>
<%= Include.Video() %>
<div class="wr_content_detail">
    <div class='article_listing'>
        <div class="list">
            <bic:ArticleListViewTopPager ID="ArticleList" runat="server" ShowTodayCss="True" SelectFields="ViewCount,CreatedDate,ImageName,BriefDescription" PageSize="5" EnableAutoRedirect="True">
                <ItemTemplate>
                    <div class="item_video">
                        <div class="img_video">
                            <bic:Image ID="Image2" runat="server" ImageName='<%# Eval("ImageName") %>'
                                Link='<%# Eval("Url") %>' Target='<%# Eval("Target") %>' Alt=' <%# Eval("Title").ToString() %>' />
                        </div>
                        <a href="<%# Eval("Url") %>" title='<%# Eval("Title") %>' class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                            <%#Eval("Title") %></a>
                    </div>
                </ItemTemplate>
            </bic:ArticleListViewTopPager>
            <%-- <div class="item_video">
                <div class="img_video">
                    <a href="#">
                        <img src="/Controls/Video/img/img_test.png" />
                    </a>
                </div>
                <a href="#">Thông báo đến thủ tướng Nga</a>
            </div>
            <div class="item_video">
                <div class="img_video">
                    <a href="#">
                        <img src="/Controls/Video/img/img_test.png" />
                    </a>
                </div>
                <a href="#">Thông báo đến thủ tướng Nga</a>
            </div>
            <div class="item_video">
                <div class="img_video">
                    <a href="#">
                        <img src="/Controls/Video/img/img_test.png" />
                    </a>
                </div>
                <a href="#">Thông báo đến thủ tướng Nga</a>
            </div>
            <div class="item_video">
                <div class="img_video">
                    <a href="#">
                        <img src="/Controls/Video/img/img_test.png" />
                    </a>
                </div>
                <a href="#">Thông báo đến thủ tướng Nga</a>
            </div>
            <div class="item_video">
                <div class="img_video">
                    <a href="#">
                        <img src="/Controls/Video/img/img_test.png" />
                    </a>
                </div>
                <a href="#">Thông báo đến thủ tướng Nga</a>
            </div>--%>
            <%-- <bic:ArticleListViewTopPager ID="ArticleList" runat="server" ShowTodayCss="True" SelectFields="ViewCount,CreatedDate,ImageName,BriefDescription" EnableAutoRedirect="True">
                <ItemTemplate>
                    <div class='item'>
                        <div class="border_img">
                            <bic:Image CssClass="aliimg" ID="Image1" runat="server" ImageName='<%# Eval("ImageName") %>'
                                Link='<%# Eval("Url") %>' Target='<%# Eval("Target") %>' Alt=' <%# Eval("Title").ToString() %>' />
                        </div>
                        <div class="content">
                            <div class="content-text">
                                <a href="<%# Eval("Url") %>" title='<%# Eval("Title") %>' class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                                    <%#Eval("Title") %> 
                                </a>
                                <div class="Description">
                                    <%# BicString.TrimText(Eval("BriefDescription").ToString(), 200) %>
                                </div>
                            </div>
                            <div class="viewDetail">
                                <a href="<%# Eval("Url") %>" target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>Xem tiếp </a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </bic:ArticleListViewTopPager>--%>
        </div>
        <div style="margin: 10px; display: table;">
            <bic:PagerUI ID="pager" CssClass="pager" SelectedCssClass="pager_selected" Label='' runat="server" PagerUIStep="5" OnPageIndexChanged="pager_PageIndexChanged" />

        </div>
        <%-- <div class="article_list_pager_search <%=ArticleList.TotalItem==0?"hidden":""%>">
           
        </div>--%>
    </div>
</div>
