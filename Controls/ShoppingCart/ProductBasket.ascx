<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductBasket.ascx.cs" Inherits="Controls_Product_Basket" %>
<%@ Import Namespace="BIC.Utils" %>

<telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="ralpContact">
    <telerik:RadCodeBlock runat="server">
        <asp:Label ID="lblNumber" runat="server" CssClass="number"></asp:Label>
        <table class="show_cart_table">
            <tr class="text_title">
                <td style="text-align: left; padding-left: 20px; width: 240px"><%=BicResource.GetValue("ShoppingCart", "TenSP")%></td>
                <td width="150px"><%=BicResource.GetValue("ShoppingCart", "ProductCode")%></td>
                <td width="100px"><%=BicResource.GetValue("ShoppingCart", "Images")%></td>
                <td width="100px"><%=BicResource.GetValue("ShoppingCart", "Gia")%></td>
                <td width="100px"><%=BicResource.GetValue("ShoppingCart", "points")%></td>
                <td width="100px" runat="server" ID="headerrQuantity"><%=BicResource.GetValue("ShoppingCart", "SoLuong")%></td>
                <td width="100px"><%=BicResource.GetValue("ShoppingCart", "ThanhTien")%></td>
                <td runat="server" id="Actionheader" width="100px"><%=BicResource.GetValue("ShoppingCart", "Delete")%></td>
            </tr>
            <asp:ListView ID="lvShoppingCart" OnItemDataBound="ShoppingCart_ItemDataBound" runat="server" OnItemCommand="lvShoppingCart_ItemCommand" OnItemDeleting="lvShoppingCart_ItemDeleting">
                <ItemTemplate>
                    <tr class="product_item">
                        <td>
                            <div class="tensach">
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("proID")%>' Visible="False"></asp:Label>
                                <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                    <a class="books-name" target="_blank" runat="server" id="productLink">
                                        <%#Eval("proName")%>
                                    </a>
                                </telerik:RadCodeBlock>
                            </div>
                        </td>
                        <td style="text-align: center; font-weight: bold">
                            <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                            </telerik:RadCodeBlock>
                        </td>
                        <td class="avatar">
                            <bic:ImageViewer Target="_blank" runat="server" ID="ivArticle" ViewType="Fix" ImageId='<%#Eval("ImageId")%>' />
                            <bic:ImageViewer runat="server" ID="imghover" CssClass="imagehover" ImageId='<%#Eval("ImageId")%>' />
                        </td>
                        <td style="text-align: center; color: #f15a22; font-weight: bold">
                            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                <%#string.Format("{0:N0}{1}", BicConvert.ToDouble(Eval("Price").ToString().Replace(" ", "").Replace(",", "")), "&nbsp")%>
                            </telerik:RadCodeBlock>
                        </td>
                        <td style="text-align: center; color: #f15a22; font-weight: bold">
                            <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">
                                <asp:Label runat='server' ID="lblSavePoint" Text='<%#string.Format("{0:N0}", BicConvert.ToDouble(Eval("ProductVat").ToString().Replace(" ", "").Replace(",", "")))%>'></asp:Label>
                            </telerik:RadCodeBlock>
                        </td>
                        <td class="inputnumber" runat="server" ID="bodyQuantity">
                            <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                                <telerik:RadNumericTextBox runat="server" ID="txtSoluong" OnTextChanged="OnNumber1Changed" AutoPostBack="True" Type="Number" Width="50px" Value='<%#BicConvert.ToInt32(Eval("Quantity"))%>' ShowSpinButtons="True" NumberFormat-DecimalDigits="0" MinValue="1">
                                    <IncrementSettings />
                                </telerik:RadNumericTextBox>
                            </telerik:RadCodeBlock>
                        </td>
                        <td style="text-align: center; font-weight: bold">
                            <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                                <asp:Label ID="lblTotal" runat="server" Text='<%#string.Format("{0:N0}", BicConvert.ToDouble(Eval("Total")))%>'></asp:Label>
                            </telerik:RadCodeBlock>
                        </td>
                        <td runat="server" id="Action" style="text-align: center">
                            <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                                <asp:LinkButton ID='btlDelete' class="lbtDelete" CommandArgument='<%#Eval("proID")%>' CommandName="Delete" runat="server" />
                            </telerik:RadCodeBlock>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td class="empty" colspan="10"><%=BicResource.GetValue("ShoppingCart", "Noproduct")%></td>
                    </tr>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <tr>
                        <td class="empty" colspan="10"><%=BicResource.GetValue("ShoppingCart", "Noproduct")%></td>
                    </tr>
                </EmptyItemTemplate>
            </asp:ListView>
            <tr runat="server" class="totalrows" visible="False" id="shpFee">
                <td colspan="6" class="totalmoney"><%=BicResource.GetValue("ShoppingCart", "ShippingFeeHeader")%></td>
                <td class="total" colspan="2">
                    <asp:Label class="money" ID="lblShippingFee" runat="server"><%# Eval("ShippingFee") %></asp:Label>
                </td>
            </tr>
            <tr class="totalrows" runat="server" visible="False" id="UPoint">
                <td colspan="6" class="totalmoney"><%=BicResource.GetValue("ShoppingCart", "UsePoint_Header")%></td>
                <td class="total" colspan="2">
                    <asp:Label class="money" ID="lblUsePoint" runat="server"><%# Eval("UsePoint") %></asp:Label>
                </td>
            </tr>
            <tr class="totalrows" runat="server" ID="TotalPayment">
                <td colspan="6" class="totalmoney">
                    <%=BicResource.GetValue("ShoppingCart", "TongTien")%>
                </td>
                <%--<td style="text-align: center">
                    <asp:Label class="money" ID="lblOrderSubTotal" runat="server"> </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" CssClass="money" ID="lblFullVat"></asp:Label><span style="color: #000"> </span>
                </td>--%>
                <td colspan="2" class="total">
                    <asp:Label class="money" ID="lblMoneyTotal" runat="server">
                        <%--<%=Session["TotalCart"] != null ? string.Format("{0:N0} ", Convert.ToDecimal(Session["TotalCart"])) : "0"%> --%>
                    </asp:Label>
                </td>
            </tr>
        </table>

        <%-- <table class="show_cart_table" id="showCartTable" runat="server" clientidmode="Static">
            <tr>
                <td colspan="4" style="padding: 5px 8px">
                    <span style="text-transform: uppercase; font-weight: bold; color: #034987"><%= BicResource.GetValue("ShoppingCart","Promotion") %></span>
                </td>
            </tr>
            <tr class="text_title">
                <td style="text-align: center; padding-left: 20px"><%=BicResource.GetValue("ShoppingCart","Product_PhanTram") %></td>
                <td width="200px"><%=BicResource.GetValue("ShoppingCart","Product_ChietKhau") %></td>
                <td width="200px"><%=BicResource.GetValue("ShoppingCart","Product_TongTien") %></td>
                <td width="260px"><%=BicResource.GetValue("ShoppingCart","Product_TongTienSauCung") %></td>
            </tr>
            <tr>
                <td style="text-align: center; font-weight: bold">
                    <asp:Label runat="server" ID="lblPhanTram"></asp:Label>
                    </td>
                <td style="text-align: center; font-weight: bold">
                    <asp:Label runat="server" ID="lblSoTienChietKhau"></asp:Label>
                    </td>
                <td style="text-align: center; font-weight: bold">
                    <asp:Label runat="server" ID="lblTongTien"></asp:Label></td>

                <td style="text-align: center; background-color: #f2f461; color: #f15a22; font-weight: bold">
                    <asp:Label runat="server" ID="lblTongTienSauChietKhau"></asp:Label>
                    </td>
            </tr>
        </table>--%>
    </telerik:RadCodeBlock>
</telerik:RadAjaxPanel>
<div class="btntool" runat="server" ID="divBtnTools">
    <div class="wr_btnNext">
        <asp:LinkButton ClientIDMode="Static" ID="btnBuy" OnClick="btnBuy_click" CssClass="submit_btnNext" Text='<%$Resources:ShoppingCart, titleThanhtoan%>' runat="server"></asp:LinkButton>
        <asp:LinkButton ID='btlContinute' CssClass="btlContinute" OnClick="btlContinute_click" Text='<%$Resources:ShoppingCart, Continues%>' runat="server" />

    </div>
</div>
<%--<uc1:MemberManage runat="server" ID="MemberManage" />--%>