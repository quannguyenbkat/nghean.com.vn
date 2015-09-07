<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contact.ascx.cs" Inherits="Controls_Contact_Contact" %>
<%@ Register Src="~/Controls/Adv/Adv.ascx" TagPrefix="uc1" TagName="Adv" %>
<%@ Register Src="~/Controls/GoogleMap/Maps.ascx" TagPrefix="uc1" TagName="Maps" %>

<%@ Import Namespace="BIC.Utils" %>
<%= Include.Contact()%>
<div class="fr cttin">
    <div class="dssp">
        <div id="uc_contact">
            <div class="content_company">
                <div class="contact_info">
                    <uc1:Adv runat="server" ID="Adv" TypeOfAdv="9" />
                </div>
            </div>
            <div class="contactForm">
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="RadAjaxLoadingPanel1">
                        <div class="labelsColumn">
                            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                <label>
                                    <%=BicResource.GetValue("FullName")%></label>
                                <label>
                                    <%=BicResource.GetValue("Address")%></label>
                                <label>
                                    <%=BicResource.GetValue("Email")%></label>
                                <label>
                                    <%=BicResource.GetValue("Phone")%></label>
                                <label>
                                    <%=BicResource.GetValue("Content")%></label>
                                <!--<label class="capcha">Mã xác thực</label>-->
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="textBoxsColumn">
                            <asp:TextBox runat="server" class="textbox" ID="txtFullName" />
                            <asp:TextBox runat="server" class="textbox" ID="txtAdress" />
                            <asp:TextBox runat="server" class="textbox" ID="txtEmail" />
                            <asp:TextBox runat="server" class="textbox" ID="txtPhone" />
                            <asp:TextBox runat="server" ID="txtContent" CssClass="textboxMultiline" TextMode="MultiLine" />
                            <div class="clear"></div>
                            <div class="capt-cha" style="display: none">
                                <telerik:RadCaptcha runat="server" ID="radCapcha" ValidationGroup="contact" CaptchaImage-ImageCssClass="imgcapcha" CaptchaTextBoxLabel=" " EnableRefreshImage="True" CaptchaLinkButtonText="Mã khác"></telerik:RadCaptcha>
                            </div>
                        </div>

                        <div class="clear"></div>
                        <div class="btncontact">
                            <div class="bgButton">
                                <asp:LinkButton runat="server" Text="<%$Resources:Resource,ContactSendCss%>" ID="ibtSend" OnCommand="FeedBack" ValidationGroup="contact" CommandName="Send" />
                            </div>
                            <div class="bghuy">
                                <asp:LinkButton runat="server" Text="<%$Resources:Resource,ContactCancelCss%>" ID="ibtReset" OnCommand="FeedBack" CommandName="Cancel" CssClass="cancel" />
                            </div>
                        </div>
                        <div class="imgLoader">
                            <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1">
                                <asp:Image ID="Image1" CssClass="imgLoading" runat="server" AlternateText="Loadding..." ImageUrl="~/Controls/Contact/img/loading.gif" />
                            </telerik:RadAjaxLoadingPanel>
                        </div>
                    </telerik:RadAjaxPanel>
                </telerik:RadCodeBlock>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</div>
<telerik:RadInputManager runat="server" ID="rim1">
    <telerik:TextBoxSetting BehaviorID="bhFullName" ErrorMessage='<%$Resources:Resource,Required %>' Validation-IsRequired="true" Validation-ValidationGroup="contact">
        <TargetControls>
            <telerik:TargetInput ControlID="txtFullName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:RegExpTextBoxSetting BehaviorID="bhEmail" Validation-IsRequired="true" Validation-ValidationGroup="contact" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage='<%$Resources:Resource,NotMatch %>'>
        <TargetControls>
            <telerik:TargetInput ControlID="txtEmail" />
        </TargetControls>
    </telerik:RegExpTextBoxSetting>
    <telerik:RegExpTextBoxSetting BehaviorID="bhPhone" Validation-IsRequired="False" ValidationExpression="^(?!\s*$).+" ErrorMessage='<%$Resources:Resource,NotMatch %>'>
        <TargetControls>
            <telerik:TargetInput ControlID="txtPhone" />
        </TargetControls>
    </telerik:RegExpTextBoxSetting>
    <telerik:TextBoxSetting BehaviorID="bhSubject" ErrorMessage='<%$Resources:Resource,Required %>' Validation-IsRequired="true" Validation-ValidationGroup="contact">
        <TargetControls>
            <telerik:TargetInput ControlID="txtSubject" />
        </TargetControls>
    </telerik:TextBoxSetting>
</telerik:RadInputManager>

