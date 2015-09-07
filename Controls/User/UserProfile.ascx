<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserProfile.ascx.cs" Inherits="Controls_User_UserProfile" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="round5px w657 borderd1 contact">
    <div class="contactTitle">
        <span id="lbTitle">Quản lý thông tin tài khoản</span>
        <div class="Toolbar">
        </div>
    </div>
    <div class="registerBlock">
        <div class="row">
            <span class="info">Thông tin cá nhân</span>
        </div>
        <div class="row">
            <div class="controlCol">
                <asp:TextBox ID="txtFullName" CssClass="textBox" runat="server" ClientIDMode="Static" />
            </div>
            <label class="labelCol">
                <%=BicResource.GetValue("Register_FullName") %></label>
        </div>
        <div class='row'>
            <div class="controlCol">
                <asp:CheckBox runat="server" ID="chkSex" class="hidden" Checked="True" ClientIDMode="Static" />
                <a class="chk isMale selected">Nam</a><a class="chk">Nữ</a>
            </div>
            <label class="labelCol">
                Giới tính
            </label>
        </div>
        <div class="row">
            <div class="controlCol">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="textBox" ClientIDMode="Static" />
                <span>*</span>
                <div class="errMsg" id="err_phone">
                    <%=BicResource.GetValue("Message", "REGISTER_ERR_PHONE") %>
                </div>
            </div>
            <label class="labelCol">
                <%=BicResource.GetValue("Register_Phone") %></label>
        </div>
        <div class="row">
            <div class="controlCol">
                <asp:TextBox ID="txtCity" runat="server" CssClass="textBox" ClientIDMode="Static" />
                <span>*</span>
                <div class="errMsg" id="err_city">
                    <%=BicResource.GetValue("Message", "REGISTER_ERR_CITY") %>
                </div>
            </div>
            <label class="labelCol">
                <%=BicResource.GetValue("Register_City") %></label>
        </div>
        <div class="row">
            <div class="controlCol">
                <asp:TextBox ID="txtWorkPlace" runat="server" CssClass="textBox" ClientIDMode="Static" />
            </div>
            <label class="labelCol">
                Nơi làm việc</label>
        </div>
    </div>
    <div class="sep10">
    </div>
    <div class="sep10">
    </div>
    <div class="sep5">
    </div>
    <div class="break dotgray">
    </div>
    <div class="registerBlock">
        <div class="row">
            <span class="info">Thông tin tài khoản</span>
        </div>
        <div class="row">
            <div class="controlCol">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="textBox" autocomplete="off" ClientIDMode="Static" />
                <span>*</span>
                <div class="errMsg" id="err_exist_username">
                    <%=BicResource.GetValue("Message", "REGISTER_ERR_EXIST_USERNAME") %>
                </div>
                <div class="errMsg" id="err_format_username">
                    <%=BicResource.GetValue("Message", "REGISTER_ERR_FORMAT_USERNAME") %>
                </div>
                <div class="succMsg" id="succ_username">
                    <%=BicResource.GetValue("Message", "REGISTER_SUCC_USERNAME") %>
                </div>
            </div>
            <label class="labelCol">
                <%=BicResource.GetValue("Register_Username") %></label>
        </div>
        <div class="row">
            <div class="controlCol">
                <asp:TextBox ID="txtPassword1" runat="server" CssClass="textBox" autocomplete="off" TextMode="Password"
                    ClientIDMode="Static" />
                <span>*</span>
                <div class="errMsg" id="err_too_short_pass">
                    <%=BicResource.GetValue("Message", "REGISTER_ERR_TOO_SHORT_PASS") %>
                </div>
                <div class="succMsg" id="succ_pass">
                    <%=BicResource.GetValue("Message", "REGISTER_SUCC_PASS") %>
                </div>
            </div>
            <label class="labelCol">
                <%=BicResource.GetValue("Register_Password") %> mới</label>
        </div>
        <div class="row">
            <div class="controlCol">
                <asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="textBox" autocomplete="off" TextMode="Password"
                    ClientIDMode="Static" />
                <span>*</span>
                <div class="errMsg" id="err_not_match_pass">
                    <%=BicResource.GetValue("Message", "REGISTER_ERR_NOT_MATCH_PASS") %>
                </div>
                <div class="succMsg" id="succ_pass_confirm">
                    <%=BicResource.GetValue("Message", "REGISTER_SUCC_PASS_CONFIRM") %>
                </div>
            </div>
            <label class="labelCol">
                <%=BicResource.GetValue("Register_Password_Confirm") %></label>
        </div>
    </div>
    <div class="sep10">
    </div>
    <div class="sep10">
    </div>
    <div class="sep5">
    </div>
    <div class="break dotgray">
    </div>
    <div class="registerBlock">
        <div class="row">
            <div class="controlCol">
                <asp:TextBox ID="txtPass" runat="server" CssClass="textBox" autocomplete="off" TextMode="Password"
                    ClientIDMode="Static" />
                <span>*</span>

            </div>
            <label class="labelCol">
                <%=BicResource.GetValue("Register_Password") %></label>
        </div>
        <div class="row">
            <div class="captraBlock controlCol">
                <telerik:RadCodeBlock runat="server" ID="radCodeBlock2">
                    <telerik:RadCaptcha runat="server" ID="capComment" CaptchaImage-TextLength="3" EnableRefreshImage="true"
                        CaptchaLinkButtonText="Ảnh khác" CaptchaTextBoxLabel="Nhập mã xác nhận" CaptchaTextBoxCssClass="txtCaptcha"
                        CaptchaTextBoxLabelCssClass="lblCaptcha">
                    </telerik:RadCaptcha>
                    <div class="errMsg captcha" runat="server" visible="false" id="err_captcha">
                        <%=BicResource.GetValue("Message", "REGISTER_ERR_CAPTCHA") %>
                    </div>
                </telerik:RadCodeBlock>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="row" style="padding-bottom: 20px">
            <div class="controlCol">
                <div class="checkBox" style="text-align: right;">

                    <a style="padding: 0;">Để thay đổi thông tin bạn hãy sửa thông tin ở mục cần sửa sau đó nhập mật khẩu và lưu lại thông tin</a>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="controlCol">
                <div class="registerBtn">
                    <asp:LinkButton ID="btnRegister" CssClass="btnRegister update" ToolTip="Bạn cần đồng ý với các điều khoản của website"
                        runat="server" />
                </div>
            </div>
        </div>
        <div class="sep10">
        </div>
    </div>
    <telerik:RadCodeBlock runat="server" ID="radCodeBlock3">
        <telerik:RadAjaxLoadingPanel runat="server" ID="ral1">
            <div class="loadingImage">
                <asp:Image ID="Image2" runat="server" AlternateText="Loadding..." BorderWidth="0px"
                    ImageUrl="~/Styles/icon/ajax_loader.gif" />
            </div>
        </telerik:RadAjaxLoadingPanel>
    </telerik:RadCodeBlock>
</div>
<div class="sep10">
</div>
