<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserManageProfileTab.ascx.cs" Inherits="Controls_User_UserProfile" %>

<%@ Import Namespace="BIC.Utils" %>
<telerik:RadCodeBlock runat="server">
    <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="ralpContact">
        <asp:Panel runat="server">
            <div class="accountBlock">
                <div class="infoBlock">
                    <div class="guide">
                        <telerik:RadCodeBlock runat="server">
                            <%= BicResource.GetValue("Register_Change_Profile_Guide") %>
                            <hr />
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="textBox readOnly" ClientIDMode="Static" ReadOnly="true" />
                            <div class="errMsg" id="err_exist_username">
                                <telerik:RadCodeBlock runat="server">
                                    <%=BicResource.GetValue("Message", "REGISTER_ERR_EXIST_USERNAME") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="errMsg" id="err_format_username">
                                <telerik:RadCodeBlock runat="server">
                                    <%=BicResource.GetValue("Message", "REGISTER_ERR_FORMAT_USERNAME") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="succMsg" id="succ_username">
                                <telerik:RadCodeBlock runat="server">
                                    <%=BicResource.GetValue("Message", "REGISTER_SUCC_USERNAME") %>
                                </telerik:RadCodeBlock>
                            </div>
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Username") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox" ClientIDMode="Static" />
                            <div class="errMsg" id="err_exist_email">
                                <telerik:RadCodeBlock runat="server">
                                    <%=BicResource.GetValue("Message", "REGISTER_ERR_EXIST_EMAIL") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="errMsg" id="err_format_email">
                                <telerik:RadCodeBlock runat="server">
                                    <%=BicResource.GetValue("Message", "REGISTER_ERR_FORMAT_EMAIL") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="succMsg" id="succ_email">
                                <telerik:RadCodeBlock runat="server">
                                    <%=BicResource.GetValue("Message", "REGISTER_SUCC_EMAIL") %>
                                </telerik:RadCodeBlock>
                            </div>
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Email") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtFullName" CssClass="textBox" runat="server" ClientIDMode="Static"  />
                            <span>*</span>
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_FullName") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="textBox" ClientIDMode="Static" />
                            <span>*</span>
                            <div class="errMsg" id="err_phone">
                                <telerik:RadCodeBlock runat="server">
                                    <%=BicResource.GetValue("Message", "REGISTER_ERR_PHONE") %>
                                </telerik:RadCodeBlock>
                            </div>
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Phone") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="row hidden">
                        <div class="controlCol">
                            <asp:TextBox ID="txtDOB" runat="server" CssClass="textBox" ClientIDMode="Static" />
                            <span>*</span>
                            <div class="errMsg" id="err_dob">
                                <telerik:RadCodeBlock runat="server">
                                    <%=BicResource.GetValue("Message", "REGISTER_ERR_DOB") %>
                                </telerik:RadCodeBlock>
                            </div>
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_DOB") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtDateOfBirth" CssClass="textBox readonly" runat="server" ReadOnly="True" />
                            <span>*</span>
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("UserManager","DateOfBirth") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtCompany" runat="server" CssClass="textBox" ClientIDMode="Static" />
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Company") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtAddress" CssClass="textBox" runat="server" />
                            <span>*</span>
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Address") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="row">
                        <div class="controlCol">
                            <%--<asp:TextBox ID="txtCity" CssClass="textBox" runat="server" ReadOnly="True" />--%>
                            <asp:DropDownList runat="server" ID="ddlCity" OnSelectedIndexChanged="ddlCity_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_City") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="row">
                        <div class="controlCol">
                            <%--<asp:TextBox ID="txtDistrict" CssClass="textBox" runat="server" ReadOnly="True" />--%>
                            <asp:DropDownList runat="server" ID="ddlDistrict"></asp:DropDownList>
                        </div>
                        <label class="labelCol">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_District") %>
                            </telerik:RadCodeBlock>
                        </label>
                    </div>
                    <div class="clear"></div>
                    <div class="btnChange">
                        <asp:Button ID="btnChange" runat="server" OnClick="btnChange_OnClick" Text="Cập nhật"></asp:Button>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="infoBlock1">
                    <div class="row1">
                        <span>Điểm tích lũy</span>
                        <hr />
                    </div>
                    <div class="row1">
                        <label class="labelCol1">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Point") %>
                            </telerik:RadCodeBlock>
                        </label>
                        <div class="controlCol1">
                            <asp:Label ID="txtPoint" runat="server" CssClass="text-point"></asp:Label>
                        </div>
                    </div>
                    <div class="row1">
                        <label class="labelCol1">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Current_Point") %>
                            </telerik:RadCodeBlock>
                        </label>
                        <div class="controlCol1">
                            <asp:Label ID="txtCurPoint" runat="server" CssClass="text-point"></asp:Label>
                        </div>
                    </div>
                    <div class="row1">
                        <label class="labelCol1">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Used_Point") %>
                            </telerik:RadCodeBlock>
                        </label>
                        <div class="controlCol1">
                            <asp:Label ID="txtUsedPoint" runat="server" CssClass="text-point"></asp:Label>
                        </div>
                    </div>
                    <div class="row1">
                        <label class="labelCol1">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Gift_Point") %>
                            </telerik:RadCodeBlock>
                        </label>
                        <div class="controlCol1">
                            <asp:Label ID="txtGiftPoint" runat="server" CssClass="text-point"></asp:Label>
                        </div>
                    </div>
                    <div class="row1">
                        <label class="labelCol1">
                            <telerik:RadCodeBlock runat="server">
                                <%=BicResource.GetValue("Register_Point_Note") %>
                            </telerik:RadCodeBlock>
                        </label>
                        <asp:TextBox ID="txtPointNote" CssClass="textboxMultiline" runat="server" ClientIDMode="Static" ReadOnly="True" TextMode="MultiLine" />
                    </div>
                    <div class="row1">
                        <span>Lưu ý: Điểm tích lũy chỉ được tính khi đơn hàng đã thanh toán và đã giao hàng!</span>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
        </asp:Panel>
    </telerik:RadAjaxPanel>
</telerik:RadCodeBlock>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="ralpContact" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
<script type="text/javascript">
    $(function () {

        $('#txtEmail').blur(function () {
            CheckEmail(this);
        });

        $('#txtPassword').blur(function () {
            CheckPassword(this);
        });

        $('#txtCity').blur(function () {
            CheckCity(this);
        });

        $('#txtPhone').blur(function () {
            CheckPhone(this);
        });
    });

    //-------------- Check email valid format and existance --------------
    function CheckEmail(txt) {
        var value = $(txt).val();
        $('#err_exist_email').hide();
        $('#err_format_email').hide();
        $('#succ_email').hide();
        if (isEmail(value)) {
            if (value != '<%=BicSession.ToString("CurrentEmail")%>')
                $.ajax({
                    type: "POST",
                    data: "{email: '" + value + "' }",
                    contentType: "application/json; charset=utf-8",
                    url: getBaseURL() + "WebService/Register.asmx/email_validation",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 1) {
                            $('#err_format_email').hide();
                            $('#err_exist_email').show();
                            $('#succ_email').hide();
                        } else {
                            $('#err_format_email').hide();
                            $('#err_exist_email').hide();
                            $('#succ_email').show();
                        }
                    }
                });
            else
                $('#err_format_email').hide();
            $('#err_exist_email').hide();
            $('#succ_email').show();
        } else {
            $('#err_format_email').show();
            $('#err_exist_email').hide();
            $('#succ_email').hide();
        }
    }

    //-------------- Check city info empty or not --------------
    function CheckCity(txt) {
        var value = $(txt).val();
        $('#err_city').hide();
        if (value != '') {
            $('#err_city').hide();
        } else {
            $('#err_city').show();
        }
    }

    //-------------- Check phone info empty or not --------------
    function CheckPhone(txt) {
        var value = $(txt).val();
        $('#err_phone').hide();
        if (value != '') {
            $('#err_phone').hide();
        } else {
            $('#err_phone').show();
        }
    }
</script>
