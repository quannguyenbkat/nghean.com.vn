<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserManageChangePassTab.ascx.cs" Inherits="Controls_User_UserManageChangePassTab" %>
<%@ Import Namespace="BIC.Utils" %>

<asp:Panel runat="server">
    <div class="accountBlock">    
        <div class="changePassBlock">    
            <asp:Panel ID="pnlChangePass" runat="server" DefaultButton="btnChangePass">                               
                <div class="guide">
                    <%= BicResource.GetValue("Register_Change_Password_Guide") %>
                </div>

                <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtCurrentPassword" TextMode="Password" runat="server" CssClass="textBox" ClientIDMode="Static" />
                                <span>*</span>                                                
                        </div>       
                        <label class="labelCol">
                            <%=BicResource.GetValue("Change_Pass_OldPass") %>
                        </label> 
                </div>

                <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" CssClass="textBox"  ClientIDMode="Static"/>
                                <span>*</span>
                                <div class="errMsg" id="err_too_short_pass">
                                    <%=BicResource.GetValue("Password_Is_Sort") %>
                                </div>                        
                        </div>       
                        <label class="labelCol">
                            <%=BicResource.GetValue("Change_Pass_NewPass") %>
                        </label> 
                </div>

                <div class="row">
                        <div class="controlCol">
                            <asp:TextBox ID="txtConfirmNewPassword" TextMode="Password" runat="server" CssClass="textBox"  ClientIDMode="Static"/>
                                <span>*</span>
                                <div class="errMsg" id="err_not_match_pass"><%=BicResource.GetValue("Message", "REGISTER_ERR_NOT_MATCH_PASS") %></div>
                        </div>       
                        <label class="labelCol">
                            <%=BicResource.GetValue("Change_Pass_Confirm") %>
                        </label> 
                </div>
                
                <div class="clear"></div>

                <div class="btnUpdate">
                    <asp:Button ID="btnChangePass" runat="server" ClientIDMode="Static" onclick="btnChangePass_Click" Text="Cập nhật">
                    </asp:Button>
                </div>    
                <div class="clear"></div>
            </asp:Panel>        
        </div>
    </div>
</asp:Panel>    