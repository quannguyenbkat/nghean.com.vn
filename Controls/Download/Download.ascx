<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Download.ascx.cs" Inherits="Controls_Download_Download" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="../Navigate/NavigatePath.ascx" TagName="NavigatePath" TagPrefix="uc2" %>
<%= Include.Download()%>

<div class="clear"></div>
<div class="resulttext">
    <asp:Label ID="lblSearch" runat="server"></asp:Label>
</div>
<div class="download">
    <div class="contentFrame">
        <div class="content-bg">
            <div class="downloadHeader">
                <div class="leftCol">
                    <%=BicResource.GetValue("OrderNo")%>
                </div>
                <div class="centerCol">
                    <%--<%=BicResource.GetValue("SupportSearch")%>--%>
                     <%--<bic:MenuRecursion ID="ddlDocumentTypeID" CssClass="input-select" TypeOfControl="docs" runat="server" />--%>
                    <asp:DropDownList runat="server" ID="ddlMenuUser" CssClass="dropDownList hidden" DataValueField="MenuUserID" DataTextField="Name" AutoPostBack="true" OnSelectedIndexChanged="ddlMenuUser_SelectedIndexChanged" />
                    
                    <div class="inputMark">
                        <asp:TextBox runat="server" CssClass="textBox" ID="txtDownloadSearch" ClientIDMode="Static" />
                        <label for="txtDownloadSearch" style="display: none;">
                            <%=BicResource.GetValue("SearchEnterKeyword")%></label>
                    </div>
                    <div class="btnSearch">
                        <asp:LinkButton ID="btnSearch" ClientIDMode="Static" runat="server" Text='<%$Resources:Resource,Search%>' OnClick="btnSearch_Click" />
                    </div>
                    <script>
                        function clickButton(e, buttonid) {
                            var evt = e ? e : window.event;
                            var bt = document.getElementById(buttonid);
                            if (bt) {
                                if (evt.keyCode == 13) {
                                    bt.click();
                                    return false;
                                }
                            }
                        }
            </script>
                </div>
                <div class="rightCol">
                    <%=BicResource.GetValue("Download")%>
                </div>
            </div>
            <div class="downloadContent">
                <asp:ListView ID="dlDownload" runat="server" OnItemCommand="dlDownload_ItemCommand">
                    <ItemTemplate>
                        <div class='<%# (Container.DataItemIndex +1)%2== 0?"item":"item odd" %>'>
                            <div class="leftCol">
                                <%#(Container.DataItemIndex + 1) + PageSize %>
                            </div>
                            <div class="centerCol">
                                <p>
                                    <span class="docNo">
                                        <%#Eval("DisplayName")%></span><%# !string.IsNullOrEmpty(Convert.ToString(Eval("DocumentNo")))? " - ":""%>
                                    <%#Eval("BriefDescription")%>  <asp:Image runat="server" ID="imgIsNew" Visible='<%#Eval("IsNew").ToString() == "True"? true:false %>' ImageUrl="~/Styles/icon/newicon.gif" />
                                </p>
                            </div>
                            <div class="rightCol">
                                <div class="downloadButton">
                                    <asp:ImageButton ID="btnDownload" runat="server" ImageUrl="~/Controls/Download/img/btn_download.png" CommandName="Download" CommandArgument='<%#Eval("DocumentID")%>' />
                                </div>
                                <div class="downloadNo">
                                    (<%#Eval("ViewNo") %>)
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <div style="clear: both; height: 20px;">
                </div>
                <div id="divPage" runat="server">
                    <bic:PagerUI ID="pager" SelectedCssClass="pager_selected" runat="server" PagerUIStep="10" OnPageIndexChanged="pager_PageIndexChanged" Next="" Previous="" />
                </div>
            </div>
        </div>
    </div>
</div>
