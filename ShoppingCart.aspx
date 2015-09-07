<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="false" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<%@ Register TagPrefix="uc1" TagName="MemberManage" Src="~/Controls/User/MemberManage.ascx" %>
<%@ Register Src="~/Controls/Adv/Adv.ascx" TagPrefix="uc1" TagName="Adv" %>


<%@ Import Namespace="BIC.Utils" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%#ResolveUrl("~")%>Controls/ShoppingCart/ShoppingCart.css" rel="stylesheet" />
    <link href="<%#ResolveUrl("~")%>BICSkins/Menu/Top/MenuTop.css" rel="stylesheet" />
    <script src="<%#ResolveUrl("~")%>Scripts/jquery-1.7.1.min.js"></script>
</head>
<body style="margin: 0">
    <form id="form1" runat="server">
        <%-- <div class="background-opacity">
            </div>--%>
        <telerik:RadScriptManager runat="server" ID="rcm1" />

        <%--<div class="top_login">
            <div style="width: 979px; margin: 0 auto; text-align: right">
                <uc1:MemberManage runat="server" ID="MemberManage" />
            </div>
        </div>--%>
        <div id="wrapper">

            <div class="header">
                <div id="header_frame">
                    <%--<div id="top_menu">
                        <uc1:HorizontalTopPrimary runat="server" ID="HorizontalTopPrimary" />
                    </div>--%>
                </div>
                <div class="logo">
                    <a href="<%= BicApplication.URLRoot %>">
                        <img src="<%=Page.ResolveUrl("~/Styles/img/logo.png") %>" />
                    </a>
                </div>
                <div class="step progress">
                    <div class="step_1"><%=BicResource.GetValue("ShoppingCart", "GioHangStep") %></div>
                    <div class="step_2"><%=BicResource.GetValue("ShoppingCart", "TTDatHang") %></div>
                    <div class="step_3"><%=BicResource.GetValue("ShoppingCart", "XacNhanDonHang") %></div>
                    <div class="clear"></div>
                    <div class="grid_17 progress_line_container">
                        <div class="grid_17 gray_line "></div>
                        <div id="orange_line"></div>
                    </div>
                    <img id="progress_icon" alt="progress icon" src="<%=ResolveUrl("~")%>Styles/img/progress_icon.png" />
                </div>
            </div>
            <div class="container">
                <div class="shop-cart">
                    <div class="cap">
                        <div class="cap_left">
                        </div>
                        <div class="cap_center">
                            <div class="nav">
                                <asp:LinkButton runat="server" ID="lbtTitle"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="cap_right"></div>
                    </div>
                    <div class="border shop-content">
                        <asp:PlaceHolder runat="server" ID="phCart"></asp:PlaceHolder>
                    </div>
                </div>
                <%--<uc1:Adv runat="server" ID="Adv" TypeOfAdv="9" />--%>
            </div>
            <div class="guide"></div>
            <div class="footer"></div>
        </div>
        <style>
            .adv .item {
                margin-bottom: 20px;
            }
            .adv .item img {
                width: 1000px;
                height: auto;
            }
            #box_user {
                width: 900px;
                float: left;
            }
            #box_user ul {
                float: left;
                width: 100%;
                margin: 0;
                padding: 0;
            }
            #box_user ul li {
                float: right;
                margin-right: 5px;
            }
            #Login {
                width: 1000px;
                float: left;
            }
            #Login ul {
                margin: 0;
                padding: 0;
                float: left;
            }
            #Login ul li {
                float: left;
                margin: 0 5px;
            }
        </style>
    </form>
</body>
</html>
<script type="text/javascript">
    var id = '<%=id%>';
    $(".current").removeClass("current");
    $(".step_" + id).addClass("current");
    $("#progress_icon").removeClass().addClass("step_" + id + "_icon");
    $("#orange_line").removeClass().addClass("step_" + id + "_line");
</script>
