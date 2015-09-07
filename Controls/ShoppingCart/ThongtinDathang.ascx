<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThongtinDathang.ascx.cs" Inherits="Controls_Article_ThongtinDathang" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/User/MemberManage.ascx" TagPrefix="uc1" TagName="MemberManage" %>
<%@ Register Src="~/Controls/ShoppingCart/ProductBasket.ascx" TagPrefix="uc1" TagName="ProductBasket" %>
<%@ Register Src="~/Controls/Adv/Adv.ascx" TagPrefix="uc1" TagName="Adv" %>


<div class="autohide_account">
    <h2><%=BicResource.GetValue("ShoppingCart","DangNhapTruoc") %></h2>
    <div class="box_login">
        <uc1:MemberManage runat="server" ID="MemberManage1" />
    </div>
</div>
<div style="position: relative; float: left">
    <div class="overlay_shop"></div>
    <h2><%=BicResource.GetValue("ShoppingCart","NhapThongTin") %></h2>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="ralpContact">
            <div class="wr_dathanginfo">
                <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                    <div class="dathanginfo">
                        <div class="title_box_home">
                            <div class="text_title">1 - <%=BicResource.GetValue("ShoppingCart","NguoiDatHang") %></div>
                        </div>
                        <div class="border dathang">
                            <div class="container-dathang">
                                <div class="content-dathang">
                                    <div class="col1">
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","FullName") %><span class="star">*</span></div>
                                        <asp:TextBox ID="txtFullname" runat="server" ClientIDMode="Static" class="input" MaxLength="255"></asp:TextBox>

                                        <div class="label hidden"><%=BicResource.GetValue("ShoppingCart","Adres") %><span class="star">*</span></div>
                                        <asp:TextBox ID="txtCompany" runat="server" class="input hidden" MaxLength="255"></asp:TextBox>
                                        <div class="label hidden"><%=BicResource.GetValue("ShoppingCart","Nip") %></div>
                                        <asp:TextBox ID="txtNip" ClientIDMode="Static" runat="server" class="input hidden" MaxLength="255"></asp:TextBox>

                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","AdresNguoiGui") %><span class="star">*</span></div>
                                        <asp:TextBox ID="txtAddressNguoiGui" ClientIDMode="Static" runat="server" class="input" MaxLength="255"></asp:TextBox>
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","City") %><span class="star">*</span></div>
                                        <asp:DropDownList runat="server" ID="ddlCity" ClientIDMode="Static" OnSelectedIndexChanged="ddlCity_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="col2">
                                        <%--<div class="label"><%=BicResource.GetValue("ShoppingCart","AdresOrder") %></div>
                                        <asp:TextBox ID="txtAddOrderReceived" ClientIDMode="Static" runat="server" class="input" MaxLength="255"></asp:TextBox>--%>
                                        <%--<div class="label"><%=BicResource.GetValue("ShoppingCart","City") %></div>
                                        <asp:TextBox ID="txtCity" runat="server" class="input" MaxLength="255"></asp:TextBox>--%>
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","Email") %><span class="star">*</span></div>
                                        <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" class="input" MaxLength="255"></asp:TextBox>
                                        <%--<div class="label"><%=BicResource.GetValue("ShoppingCart","NgheNghiep") %></div>
                                        <asp:TextBox ID="txtNgheNghiep" runat="server" class="input" MaxLength="255"></asp:TextBox>--%>
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","Phone") %></div>
                                        <asp:TextBox ID="txtTel" ClientIDMode="Static" runat="server" class="input" MaxLength="255"></asp:TextBox>
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","District") %><span class="star">*</span></div>
                                        <asp:DropDownList runat="server" ID="ddlDistrict" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                    <div>
                                        <div class="label note"><%=BicResource.GetValue("ShoppingCart","Notes") %></div>
                                        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" class="textarea" MaxLength="255"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="ttnn">
                        <div class="ttTrungNhau">
                            <asp:CheckBox ID="chkTT" runat="server" Text="<%$Resources:ShoppingCart, ThongTinTrungNhau%>" OnCheckedChanged="chkTT_Change" AutoPostBack="True" ClientIDMode="Static" />
                        </div>
                        <div class="title_box_home">
                            <div class="text_title">2 - <%=BicResource.GetValue("ShoppingCart","NguoiNhanHang") %></div>
                        </div>
                        <div class="border dathang">
                            <div class="container-dathang">
                                <div class="content-dathang">
                                    <div class="col1">
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","FullName") %><span class="star">*</span></div>
                                        <asp:TextBox ID="txtFullname2" runat="server" ClientIDMode="Static" class="input" MaxLength="255"></asp:TextBox>

                                        <div class="label hidden"><%=BicResource.GetValue("ShoppingCart","Adres") %></div>
                                        <asp:TextBox ID="txtCompany2" runat="server" class="input hidden" MaxLength="255"></asp:TextBox>
                                        <div class="label hidden"><%=BicResource.GetValue("ShoppingCart","Nip") %></div>
                                        <asp:TextBox ID="txtNip2" ClientIDMode="Static" runat="server" class="input hidden" MaxLength="255"></asp:TextBox>

                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","AdresShipping") %><span class="star">*</span></div>
                                        <asp:TextBox ID="txtAdresShipping" ClientIDMode="Static" runat="server" class="input" MaxLength="255"></asp:TextBox>
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","City") %><span class="star">*</span></div>
                                        <asp:DropDownList runat="server" ID="ddlCity2" ClientIDMode="Static" OnSelectedIndexChanged="ddlCity2_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="col2">
                                        <%--<div class="label"><%=BicResource.GetValue("ShoppingCart","City") %></div>
                                        <asp:TextBox ID="txtCity2" runat="server" class="input" MaxLength="255"></asp:TextBox>--%>
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","Email") %><span class="star">*</span></div>
                                        <asp:TextBox ID="txtEmail2" runat="server" ClientIDMode="Static" class="input" MaxLength="255"></asp:TextBox>
                                        <%--<div class="label"><%=BicResource.GetValue("ShoppingCart","NgheNghiep") %></div>
                                        <asp:TextBox ID="txtNgheNghiep2" runat="server" class="input" MaxLength="255"></asp:TextBox>--%>
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","Phone") %></div>
                                        <asp:TextBox ID="txtTel2" ClientIDMode="Static" runat="server" class="input" MaxLength="255"></asp:TextBox>
                                        <div class="label"><%=BicResource.GetValue("ShoppingCart","District") %><span class="star">*</span></div>
                                        <asp:DropDownList runat="server" ID="ddlDistrict2" ClientIDMode="Static" OnSelectedIndexChanged="ddlDistrict2_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="label note"><%=BicResource.GetValue("ShoppingCart","Notes") %></div>
                                    <asp:TextBox ID="txtNotes2" runat="server" TextMode="MultiLine" class="textarea" MaxLength="255"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both;"></div>
                    <h2 style="margin-top: 0;" class="hidden"><%=BicResource.GetValue("ShoppingCart","AddressRecervedOrder") %></h2>
                    <div class="box_thanhtoan hidden">
                        <div style="line-height: 30px; margin-bottom: 10px">
                            <span style=""><%=BicResource.GetValue("ShoppingCart","AddressRecervedOrder") %> </span><span style="color: red; width: 2px">*</span>
                            <asp:TextBox ID="txtAddOrderReceived" Style="width: 300px; border: 1px solid #E6E6E6; height: 29px; border-radius: 5px; padding-left: 10px" runat="server" ClientIDMode="Static" class="input"></asp:TextBox>
                        </div>
                    </div>
                    <div style="clear: both"></div>
                    <uc1:ProductBasket runat="server" ID="ProductBasket" />
                    <div style="clear: both"></div>
                    <h2><%=BicResource.GetValue("ShoppingCart","ThanhToanVaChuyenHang") %></h2>
                    <div class="box_thanhtoan">
                        <div class="box-leftTT">
                            <%--<asp:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                            <ContentTemplate>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                            <div class="select">
                                <span><%=BicResource.GetValue("ShoppingCart","PhuongThucThanhToan") %> </span>
                                <asp:DropDownList runat="server" ID="ddlPayMethod" OnSelectedIndexChanged="ddlPayMethod_OnSelectedIndexChanged" ClientIDMode="Static" AutoPostBack="True" /><span style="color: red; width: 2px; float: right;">*</span>
                                <%--<asp:RadioButton ID="RadioButton1" Checked="True" runat="server" Text="<%$Resources:ShoppingCart, ThanhToanTienMat%>" />--%>
                            </div>
                            <div id="bankinfo" runat="server" clientidmode="Static" visible="False">
                                <uc1:Adv runat="server" ID="Adv" TypeOfAdv="4" />
                            </div>
                            <div class="select">
                                <span><%=BicResource.GetValue("ShoppingCart","HinhThucVanChuyen") %></span>
                                <asp:DropDownList runat="server" ID="ddlShippingMethod" ClientIDMode="Static" OnSelectedIndexChanged="ddlShippingMethod_OnSelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList><span style="color: red; width: 2px; float: right;">*</span>
                                <%-- <asp:RadioButton ID="RadioButton2" Checked="True" runat="server" Text="<%$Resources:ShoppingCart, DenNguoiNhan%>" />--%>
                            </div>
                            <div id="divShipingType" class="select" runat="server" visible="False">
                                <span><%=BicResource.GetValue("ShoppingCart","ShippingType") %></span>
                                <asp:RadioButtonList ID="tblShippingType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="tblShippingType_OnSelectedIndexChanged" AutoPostBack="True" Style="float: left;">
                                    <asp:ListItem Text="Chuyển phát nhanh" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Tiết kiệm" Value="1" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="select">
                                <span><%=BicResource.GetValue("ShoppingCart","UsePoint") %></span>
                                <asp:CheckBox runat="server" ID="IsUsePoint" ClientIDMode="Static" Checked="False" OnCheckedChanged="IsUsePoint_OnCheckedChanged" AutoPostBack="True"></asp:CheckBox><br />
                                <asp:HiddenField runat="server" ID="SavePoint"></asp:HiddenField>
                                <asp:HiddenField runat="server" ID="Total"></asp:HiddenField>
                                <asp:HiddenField runat="server" ID="TempShippingFee"></asp:HiddenField>
                                <asp:HiddenField runat="server" ID="MaxUsePoint" ClientIDMode="Static" />
                                <%--<telerik:RadNumericTextBox runat="server" ID="UsePoint" ClientIDMode="Static" NumberFormat-DecimalSeparator="," MinValue="0" CssClass="hidden"></telerik:RadNumericTextBox>--%>
                            </div>
                            <div class="select" runat="server" id="divPoint" clientidmode="Static">
                                <span>Điểm khả dụng :</span>
                                <asp:TextBox runat="server" ID="CurPoint" ReadOnly="True" Enabled="False" Style="width: 125px;"></asp:TextBox>
                                <span>Điểm sử dụng :</span>
                                <telerik:RadNumericTextBox runat="server" ID="UsePoint" ClientIDMode="Static" ShowSpinButtons="True" MinValue="0" IncrementSettings-Step="1000" Width="125px" NumberFormat-DecimalDigits="0" OnTextChanged="UsePoint_OnTextChanged" AutoPostBack="True"></telerik:RadNumericTextBox>
                            </div>
                        </div>
                        <div class="box-rightTT">
                            <table class="tbThanhToan">
                                <tr>
                                    <td class="control-text">
                                        <div class="text">Phí vận chuyển</div>
                                    </td>
                                    <td class="control-input">
                                        <asp:Label runat="server" ID="lbPhiVanChuyen"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="control-text">Sử dụng điểm tích lũy</td>
                                    <td class="control-input">
                                        <asp:Label runat="server" ID="lbUsePoint"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="control-text">Tổng tiền cần thanh toán (VNĐ)</td>
                                    <td class="control-input">
                                        <asp:Label runat="server" ID="lblTotalPay"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <br />
                    <div class="wr_btnNext">
                        <a class="submit_btnNext" onclick="CheckTT()"><%=BicResource.GetValue("ShoppingCart","Next") %></a>
                        <asp:LinkButton ID="lbtNext" CssClass="submit_btnNext" OnClick="lbtNext_OnClick" ClientIDMode="Static" Style="display: none;" runat="server"></asp:LinkButton>
                        <asp:LinkButton ID="lbtBack" Text='<%$Resources:ShoppingCart, Back%>' CssClass="submit_btnBack" OnClick="lbtBack_OnClick" ClientIDMode="Static" runat="server"></asp:LinkButton>
                    </div>
                </telerik:RadCodeBlock>
            </div>
        </telerik:RadAjaxPanel>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="ralpContact" BackgroundPosition="Center" EnableSkinTransparency="true">
    </telerik:RadAjaxLoadingPanel>
</div>

<telerik:RadCodeBlock runat="server">
    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(function () {
                $("#IsUsePoint").on("change", function () {
                    if (this.checked) {
                        $("#inputPoint").removeClass("hidden");
                    } else {
                        $("#inputPoint").addClass("hidden");
                    }
                });
            });
        });
    </script>
</telerik:RadCodeBlock>
<telerik:RadCodeBlock runat="server" ID="RadCodeBlock123">
    <script>
        var check = 1;
        function CheckTT() {

            if ($('#txtFullname').val().length == 0) {
                $('#txtFullname').addClass("error");
                $('#txtFullname').focus();
                check = 0;
                return false;
            } else {
                $('#txtFullname').removeClass("error");
                check = 1;
            }
            var checkEmail = checkRegexp($('#txtEmail').val(), /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Email không đúng định dạng.");
            if (checkEmail == false) {
                $('#txtEmail').addClass("error");
                $('#txtEmail').focus();
                check = 0;
                return false;
            } else {
                $('#txtEmail').removeClass("error");
                check = 1;
            }
            if ($('#txtAddressNguoiGui').val().length == 0) {
                $('#txtAddressNguoiGui').addClass("error");
                $('#txtAddressNguoiGui').focus();
                check = 0;
                return false;
            } else {
                $('#txtAddressNguoiGui').removeClass("error");
                check = 1;
            }
            if ($('#ddlCity').find(":selected").val() == '0') {
                $('#ddlCity').addClass("error");
                $('#ddlCity').focus();
                check = 0;
                return false;
            } else {
                $('#ddlCity').removeClass("error");
                check = 1;
            }
           
            if ($('#txtFullname2').val().length == 0) {
                $('#txtFullname2').addClass("error");
                $('#txtFullname2').focus();
                check = 0;
                return false;
            } else {
                $('#txtFullname2').removeClass("error");
                check = 1;
            }
           
            var checkEmail = checkRegexp($('#txtEmail2').val(), /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Email không đúng định dạng.");
            if (checkEmail == false) {
                $('#txtEmail2').addClass("error");
                $('#txtEmail2').focus();
                check = 0;
                return false;
            } else {
                $('#txtEmail2').removeClass("error");
                check = 1;
            }
            if ($('#txtAdresShipping').val().length == 0) {
                $('#txtAdresShipping').addClass("error");
                $('#txtAdresShipping').focus();
                check = 0;
                return false;
            } else {
                $('#txtAdresShipping').removeClass("error");
                check = 1;
            }
            if ($('#ddlCity2').find(":selected").val() == 0) {
                $('#ddlCity2').addClass("error");
                $('#ddlCity2').focus();
                check = 0;
                return false;
            } else {
                $('#ddlCity2').removeClass("error");
                check = 1;
            }
            if ($('#ddlPayMethod').find(":selected").val() == 0) {
                $('#ddlPayMethod').addClass("error");
                $('#ddlPayMethod').focus();
                check = 0;
                return false;
            } else {
                $('#ddlPayMethod').removeClass("error");
                check = 1;
            }
            if ($('#ddlShippingMethod').find(":selected").val() == 0) {
                $('#ddlShippingMethod').addClass("error");
                $('#ddlShippingMethod').focus();
                check = 0;
                return false;
            } else {
                $('#ddlShippingMethod').removeClass("error");
                check = 1;
            }
            if (check == 1) {
                __doPostBack('<%=lbtNext.UniqueID%>', '');
            }
            else {
                return false;
            }

        }
        $(function () {
            $(".overlay_shop").css("display", "none");
            var accname = '<%= BicMemberShip.CurrentUserName%>';
            if (accname != "") {
                $(".autohide_account").hide();
            }
            $("#IsUsePoint").on("change", function () {
                if (this.checked) {
                    $("#inputPoint").removeClass("hidden");
                } else {
                    $("#inputPoint").addClass("hidden");
                }
            });
        });
    </script>
</telerik:RadCodeBlock>
