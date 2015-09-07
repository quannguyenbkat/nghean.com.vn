<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckOrder.ascx.cs" Inherits="Controls_ShoppingCart_CheckOrder" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/ShoppingCart/ProductBasket.ascx" TagPrefix="uc1" TagName="ProductBasket" %>

<uc1:ProductBasket runat="server" ID="ProductBasket" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="loading_contact">
                    <img src="<%=Page.ResolveUrl("~")%>Controls/ShoppingCart/img/loading.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="break_module"></div>
        <div class="temp_3">
            <div class="title">
                <div class="fl"></div>
                <div class="fc"><span><%=BicResource.GetValue("ShoppingCart","NguoiDatHang") %></span></div>
                <div class="fr"></div>
                <div class="fe"><a href="<%=ResolveUrl("~")+BicLanguage.CurrentLanguage %>/shopping-cart.sc2.html" class="payment_step_2_link_edit"><%=BicResource.GetValue("ShoppingCart","Change") %></a></div>
            </div>
            <div class="content payment_step_2">
                <table cellspacing="0" cellpadding="0" class="order_information">
                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","TenNguoiDat") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrTen"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Phone") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrPhone"></asp:Literal></td>
                    </tr>
                    <tr class="hidden">
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Nip") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrNip"></asp:Literal></td>
                    </tr>

                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","AdresNguoiGui") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrAddress"></asp:Literal></td>
                    </tr>
                    <%-- <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","City") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrCity"></asp:Literal></td>
                    </tr>--%>
                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Email") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrEmail"></asp:Literal></td>
                    </tr>

                    <tr class="hidden">
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Adres") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrNgheNghiep"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="name"><%=BicResource.GetValue("ShoppingCart","Notes2") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrNotes"></asp:Literal></td>
                    </tr>
                </table>
            </div>
            <div class="bottom">
                <div class="fl"></div>
                <div class="fr"></div>
            </div>
        </div>
        <div class="break_module"></div>
        <div class="temp_3">
            <div class="title">
                <div class="fl"></div>
                <div class="fc"><span><%=BicResource.GetValue("ShoppingCart","NguoiNhanHang") %></span></div>
                <div class="fr"></div>
                <div class="fe"><a href="<%=ResolveUrl("~")+BicLanguage.CurrentLanguage %>/shopping-cart.sc2.html" class="payment_step_2_link_edit"><%=BicResource.GetValue("ShoppingCart","Change") %></a></div>
            </div>
            <div class="content payment_step_2">
                <table cellspacing="0" cellpadding="0" class="order_information">
                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","TenNguoiNhan") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrTen2"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Phone") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrPhone2"></asp:Literal></td>
                    </tr>
                    <tr class="hidden">
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Nip") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrNip2"></asp:Literal></td>
                    </tr>

                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","AdresShipping") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrAddress2"></asp:Literal></td>
                    </tr>
                    <%--  <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","City") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrCity2"></asp:Literal></td>
                    </tr>--%>
                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Email") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrEmail2"></asp:Literal></td>
                    </tr>

                    <tr class="hidden">
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Adres") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrNgheNghiep2"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="name"><%=BicResource.GetValue("ShoppingCart","Notes2") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrNotes2"></asp:Literal></td>
                    </tr>
                </table>
            </div>
            <div class="bottom">
                <div class="fl"></div>
                <div class="fr"></div>
            </div>
        </div>
        <div class="break_module"></div>
        <div class="temp_3 hidden">
            <div class="title">
                <div class="fl"></div>
                <div class="fc"><span><%=BicResource.GetValue("ShoppingCart","AddressRecervedOrder") %></span></div>
                <div class="fr"></div>
                <div class="fe"><a href="<%=ResolveUrl("~")+BicLanguage.CurrentLanguage %>/shopping-cart.sc2.html" class="payment_step_2_link_edit"><%=BicResource.GetValue("ShoppingCart","Change") %></a></div>
            </div>
            <div class="content payment_step_2">
                <table cellspacing="0" cellpadding="0" class="order_information">
                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","AddressRecervedOrder") %> : </td>
                        <td>
                            <asp:Literal runat="server" ID="lblAddressRecervedOrder"></asp:Literal></td>
                    </tr>
                </table>
            </div>
            <div class="bottom">
                <div class="fl"></div>
                <div class="fr"></div>
            </div>
        </div>
        <div class="break_module"></div>
        <div class="temp_3">
            <div class="title">
                <div class="fl"></div>
                <div class="fc"><span><%=BicResource.GetValue("ShoppingCart","ThanhToanVaChuyenHang") %></span></div>
                <div class="fr"></div>
                <div class="fe"><a href="<%=ResolveUrl("~")+BicLanguage.CurrentLanguage %>/shopping-cart.sc2.html" class="payment_step_2_link_edit"><%=BicResource.GetValue("ShoppingCart","Change") %></a></div>
            </div>
            <div class="content payment_step_2">
                <table cellspacing="0" cellpadding="0" class="order_information">
                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","PhuongThucThanhToan") %></td>
                        <td class="value">
                            <%--<%=BicResource.GetValue("ShoppingCart","ThanhToanTienMat")%>--%>
                            <asp:Literal runat="server" ID="ltPayMethod"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","HinhThucVanChuyen") %></td>
                        <td class="value">
                            <%--<%=BicResource.GetValue("ShoppingCart","DenNguoiNhan")%>--%>
                            <asp:Literal runat="server" ID="ltShippingMethod"></asp:Literal>
                        </td>
                    </tr>
                    <%--  <tr>
                        <td class="name"><%=BicResource.GetValue("ShoppingCart","ThoiGianNhanHang") %></td>
                        <td class="value">
                            <asp:Literal runat="server" ID="ltrTime"></asp:Literal></td>
                    </tr>--%>
                </table>
            </div>
            <div class="bottom">
                <div class="fl"></div>
                <div class="fr"></div>
            </div>
        </div>
        <div class="break_module"></div>
        <div class="wr_btnNext">
            <asp:LinkButton ID="lbtSend" CssClass="btlContinute" OnClick="lbtSend_OnClick" ClientIDMode="Static" Text='<%$Resources:ShoppingCart, Bt_Send%>' runat="server"></asp:LinkButton>
            <asp:LinkButton ID="lbtBack" Text='<%$Resources:ShoppingCart, Back%>' CssClass="submit_btnBack" OnClick="lbtBack_OnClick" ClientIDMode="Static" runat="server"></asp:LinkButton>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<style type="text/css">
    .btntool .submit_btnNext {
        display: none;
    }

    .wr_btnNext .btlContinute {
        margin-left: 20px;
    }
</style>
<script type="text/javascript">
    $(".loading_contact").css('height', $("body").height() + 30 + "px");
</script>
