<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.ascx.cs" Inherits="Controls_User_ChangePassword" %>
<%=Include.UserProfile() %>
<%@ Import Namespace="BIC.Utils" %>
<div class="accInfoBlock">
    <asp:ChangePassword ID="ChangePassword1" runat="server" ChangePasswordFailureText='<%#BicResource.GetValue("Change_Pass_Old_Pass_Not_Valid") %>' ContinueDestinationPageUrl="~/default.aspx"
        SuccessText='<%#BicResource.GetValue("Change_Pass_Succ") %>' CssClass="errorText">
        <ChangePasswordTemplate>
            <asp:Panel ID="Panel1" runat="server" DefaultButton="ChangePasswordPushButton">
                <div class="captionImage">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Styles/User/img/change_password_caption.png" /></div>
                <div class="labelCol">
                    <label>
                        <%=BicResource.GetValue("Change_Pass_OldPass")%></label>
                    <label>
                        <%=BicResource.GetValue("Change_Pass_NewPass")%></label>
                    <label>
                        <%=BicResource.GetValue("Change_Pass_Confirm")%></label>
                </div>
                <div class="controlCol">
                    <div>
                        <bic:RequiredValue ID="CurrentPassword" TextMode="Password" runat="server" CssClass="textBox" /></div>
                    <div>
                        <bic:RequiredValue ID="NewPassword" TextMode="Password" runat="server" CssClass="textBox" /></div>
                    <div>
                        <bic:RequiredValue ID="txtConfirmNewPassword" TextMode="Password" runat="server" CssClass="textBox" /></div>
                    <div class="button">
                        <asp:ImageButton ImageUrl="~/Styles/User/img/update_btn.png" ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" ValidationGroup="ctl00$ChangePassword1" />
                    </div>
                    <div class="errorBlock">
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </div>
                    <div class="errorBlockSpan">
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="txtConfirmNewPassword" Display="Dynamic"
                            ErrorMessage="Mật khẩu xác nhận không khớp." ValidationGroup="ctl00$ChangePassword1"></asp:CompareValidator>
                    </div>
                </div>
            </asp:Panel>
            <div class="guide">
                <%=BicResource.GetValue("Register_Change_Profile_Guide")%></div>
        </ChangePasswordTemplate>
        <SuccessTemplate>
            <div class="succTemplate">
                <div class="succMsg">
                    <%=BicResource.GetValue("Change_Pass_Succ") %><br />
                </div>
            </div>
        </SuccessTemplate>
    </asp:ChangePassword>
</div>
<script type="text/javascript">
    function closeWindow() {
        window.close();
    }
</script>