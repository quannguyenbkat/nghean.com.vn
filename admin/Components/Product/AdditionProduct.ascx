<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionProduct.ascx.cs"
    Inherits="Admin_Components_Product_AdditionProduct" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="../ImageGallery/ImageSelectMulti.ascx" TagName="ImageSelectMulti"
    TagPrefix="uc1" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelector.ascx" TagName="ImageSelector"
    TagPrefix="bic" %>
<%@ Register Src="~/admin/Components/Video/VideoSelector.ascx" TagName="VideoSelector"
    TagPrefix="bic" %>
<%@ Register Src="RelatedProduct.ascx" TagName="relatedproduct" TagPrefix="uc2" %>
<%@ Register TagPrefix="bic" TagName="RelatedArticle" Src="~/admin/Components/Article/RelatedArticle.ascx" %>

<telerik:RadCodeBlock runat="server" ID="radCode">
    <script src='<%= Page.ResolveUrl("~/admin/Scripts/jquery.autocomplete.min.js") %>'
        type="text/javascript"> </script>
    <link href='<%= Page.ResolveUrl("~/admin/Scripts/jquery.autocomplete/jquery.autocomplete.css") %>'
        rel="stylesheet" type="text/css" />
    <div class="form-tool product">
        <bic:ToolBar ID="tbTop" runat="server" />
        <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save"
            CommandName="AddNew" ValidationGroup="btnSave">
            <telerik:RadCodeBlock ID="RadCodeBlock41" runat="server">
                <%=BicResource.GetValue("Admin","Admin_Save") %>
            </telerik:RadCodeBlock>
        </asp:LinkButton>
    </div>
    <div class="form-caption">
        <%= BicMessage.InsertTitle %>
        <span class="note"><em>*</em>
            <%= BicMessage.RequireTitle %></span>
    </div>
</telerik:RadCodeBlock>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_AdminLanguege_Language") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" Width="200px" CssClass="input-select"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
                </bic:Language>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Product_List") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                    <script type="text/javascript">                        function ClientNodeChecked(sender, eventArgs) { var node = eventArgs.get_node(); if (node.get_checked()) { var list1 = $("#hdTreeMenu").val(); var arr1 = list1.split(','); var count = 0; for (var i = 0; i < arr1.length; i++) { if (arr1[i] == node.get_value()) count++; }; if (count == 0) $("#hdTreeMenu").val($("#hdTreeMenu").val() + ',' + node.get_value()); } else { var list2 = $("#hdTreeMenu").val(); var arr2 = list2.split(','); var menuid = ""; for (var j = 0; j < arr2.length; j++) { if (arr2[j] != node.get_value()) { menuid = menuid + "," + arr2[j]; } }; $("#hdTreeMenu").val(menuid.replace(",,", ",")); }; $.ajax({ type: "POST", url: getBaseURL() + 'admin/Service/ListMenu.ashx?menuid=' + $("#hdTreeMenu").val(), success: function (mess) { $(".menuchoice").html(""); $(".menuchoice").html(mess); }, error: function (errormessage) { alert("Chắc năng này đang được nâng cấp"); } }); $(".menuchoice").ajaxComplete(function (event, request, settings) { $("#MenuDrop li").hover(function () { $("#MenuDrop li").removeClass("hovermenu"); $(this).addClass("hovermenu"); }, function () { $("#MenuDrop li").removeClass("hovermenu"); }); $("#MenuDrop").sortable({ revert: true, stop: function (event, ui) { var s = ""; $("#MenuDrop li").each(function () { s += "," + $.trim($(this).attr("id")); }); $("#hdTreeMenu").val(s); } }); }); }</script>
                </telerik:RadScriptBlock>
                <asp:HiddenField ID="hdTreeMenu" runat="server" ClientIDMode="Static" />
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <div class="cot-tree">
                        <telerik:RadTreeView runat="server" Skin="Outlook" Width="250px" OnClientNodeChecked="ClientNodeChecked"
                            CheckBoxes="true" ID="tvMenuUser" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                            CollapseAnimation-Duration="0" ExpandAnimation-Duration="0" ExpandAnimation-Type="none"
                            OnNodeCheck="tvMenuUser_OnNodeCheck">
                        </telerik:RadTreeView>
                    </div>
                    <div class="cot-tree">
                        <telerik:RadTreeView runat="server" Skin="Outlook" Width="250px" OnClientNodeChecked="ClientNodeChecked"
                            CheckBoxes="true" ID="RadTreeView1" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                            CollapseAnimation-Duration="0" ExpandAnimation-Duration="0" ExpandAnimation-Type="none"
                            OnNodeCheck="tvMenuUser_OnNodeCheck">
                        </telerik:RadTreeView>
                    </div>
                    <div class="cot-tree">
                        <telerik:RadTreeView runat="server" Skin="Outlook" Width="250px" OnClientNodeChecked="ClientNodeChecked"
                            CheckBoxes="true" ID="RadTreeView2" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                            CollapseAnimation-Duration="0" ExpandAnimation-Duration="0" ExpandAnimation-Type="none"
                            OnNodeCheck="tvMenuUser_OnNodeCheck">
                        </telerik:RadTreeView>
                    </div>
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Product_ListOfSelected") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <div class="menuchoice">
                    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Product_NoItemsSelected") %>
                    </telerik:RadCodeBlock>
                </div>
            </div>
        </div>
    </div>
    <div class="frow ">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Product_Title2") %>
                </telerik:RadCodeBlock>
                <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input-text" MaxLength="180" Width="85%" />
                (Max 180)
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                    <%=BicResource.GetValue("Admin","System_OtherInformation") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input group-item">
                <div class="col first selector-image">
                    <div class="title arrow">
                        <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">
                            <%=BicResource.GetValue("Admin","Admin_Product_ImageDescription") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <bic:ImageSelector ID="isImageId" runat="server" />
                </div>
                <div class="col c1">
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock19" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Product_Order") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <%--       <asp:DropDownList runat="server" ID="ddlPosition" />--%>
                            <telerik:RadNumericTextBox ShowSpinButtons="true" IncrementSettings-InterceptArrowKeys="true"
                                IncrementSettings-InterceptMouseWheel="true" Value="1" LabelWidth="" runat="server"
                                ID="ntxPosition" Width="70px" DataType="System.Int64" MinValue="1">
                                <NumberFormat ZeroPattern="n" AllowRounding="False"></NumberFormat>
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                    <asp:Label runat="server" ID="lblPriority" Visible="false" />
                    <telerik:RadCodeBlock ID="RadCodeBlock42" runat="server">
                        <div class="line  <%=BicXML.ToBoolean("EnableComment","SettingProduct") == false? "hidden" : "" %>">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock8" runat="server">
                                    <%=BicResource.GetValue("Admin","Admin_Product_AppearComment") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:CheckBox runat="server" ID="chkCommentEnable" />
                            </div>
                        </div>
                    </telerik:RadCodeBlock>
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock9" runat="server">
                                <%=BicResource.GetValue("Admin","System_New") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkNew" />
                        </div>
                    </div>
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock10" runat="server">
                                <%=BicResource.GetValue("Admin","System_Browse") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" Enable="<%# Approved %>" ID="chkIsActive" />
                        </div>
                    </div>
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock11" runat="server">
                                <%=BicResource.GetValue("Admin","System_FullScreen") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsFull" />
                        </div>
                    </div>

                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock16" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Product_NewsFocus") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:DropDownList ID="ddlTintieudiem" runat="server" Width="120" />
                        </div>
                    </div>
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock17" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Product_TypeOfNews") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:DropDownList ID="ddlTypeproducts" runat="server" Width="120" ClientIDMode="Static" />
                        </div>
                    </div>
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock18" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Product_Votes") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtVote" CssClass="input-text" Width="108px"></asp:TextBox>
                        </div>
                    </div>


                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock20" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Product_Home") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsHome" />
                        </div>
                    </div>
                </div>
                <div class="col c2">
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock12" runat="server">
                                <%=BicResource.GetValue("Admin","System_Target") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <bic:Target runat="server" ID="cbTarget" CssClass="input-select">
                            </bic:Target>
                        </div>
                    </div>
                    <telerik:RadCodeBlock ID="RadCodeBlock13" runat="server">
                        <div class="line <%=BicXML.ToBoolean("EnableView","SettingProduct") == false? "hidden" : "" %>">
                            <div class="label arrow">
                                <%=BicResource.GetValue("Admin","Admin_Product_Views2") %>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtViewCount" CssClass="input-text" Width="116px"
                                    Text="1" />
                            </div>
                        </div>
                    </telerik:RadCodeBlock>
                    
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock15" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Product_Link") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtLink" CssClass="input-text" Width="108px" />
                        </div>
                    </div>
                    
                </div>

            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock61" runat="server">
                  Giá 
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtPrice1" CssClass="input-text" Width="116px" onkeypress="return keypress(event);" />
            </div>
        </div>
    </div>
      <div class="frow none">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock62" runat="server">
                   Giá online
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtPriceOnline" CssClass="input-text" Width="116px" onkeypress="return keypress(event);" />
            </div>
        </div>
    </div>
    <telerik:RadCodeBlock ID="RadCodeBlock59" runat="server">
        <div class="frow  <%=BicXML.ToBoolean("EnableProperty","SettingProduct") == false? "hidden" : "" %>">
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock21" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Product_Property") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input group-item">
                     <div class="col c1">
                         <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock34" runat="server">
                                    <%=BicResource.GetValue("Admin","System_Manufacture") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtManufactory" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                         <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock48" runat="server">
                                    <%=BicResource.GetValue("Admin","Admin_Product_Traffic") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtThanhPhan" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock53" runat="server">
                                    Áp suất
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtThuongHieu" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                         <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock69" runat="server">
                                    Tiêu chuẩn áp dụng
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtTieuChuan" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                         </div>
                    <div class="col c2">
                        <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock22" runat="server">
                                    
                                    Model
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtCode" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line hidden">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock23" runat="server">
                                    <%=BicResource.GetValue("Admin","Admin_Product_Price") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtPrice" CssClass="input-text" Width="116px" onkeypress="return keypress(event);" />
                            </div>
                        </div>
                        <div class="line hidden">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock24" runat="server">
                                    <%=BicResource.GetValue("Admin","Admin_Product_OldPrice") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtOldPrice" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line hidden">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock31" runat="server">
                                    <%=BicResource.GetValue("Admin","Admin_Product_InStock") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:CheckBox runat="server" Checked="true" ID="chkOutOfStock" />
                            </div>
                        </div>
                        <div class="line hidden">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock45" runat="server">
                                    <%=BicResource.GetValue("Admin","Product_MauSac") %>

                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtMauSac" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        
                        <div class="line ">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock55" runat="server">
                                    <%=BicResource.GetValue("Admin","Admin_Product_Transmission") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtTheLoai" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock54" runat="server">
                                    <%=BicResource.GetValue("Admin","Admin_Product_Materials") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtDuongVienCoAo" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                         <telerik:RadCodeBlock ID="RadCodeBlock14" runat="server">
                        <div class="line ">
                            <div class="label arrow">
                                Cấp bảo vệ
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtApsuat" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                    </telerik:RadCodeBlock>
                    </div>
                    <div class="col c3 ">
                       
                        <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock33" runat="server">
                                    Công suất
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtCongSuat" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        
                        <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock35" runat="server">
                                   Hiệu điện thế
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtHieuDienThe" CssClass="input-text" Width="116px" />
                            </div>
                        </div>

                        <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock49" runat="server">
                                    Dòng điện định mức
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtDongDienDinhMuc" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock50" runat="server">
                                    Dòng ngắn mạch
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtDongNganMach" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line hidden">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock51" runat="server">
                                    <%=BicResource.GetValue("Admin","Product_CatGiam") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtCatGiam" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line hidden">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock52" runat="server">
                                    <%=BicResource.GetValue("Admin","Product_LichHen") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtLichHen" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line hidden">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock57" runat="server">
                                    <%=BicResource.GetValue("Admin","Product_GioiTinh") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtGioiTinh" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line hidden">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock56" runat="server">
                                    <%=BicResource.GetValue("Admin","Product_Mua") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtMua" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="RadCodeBlock60" runat="server">
        <div id="ArrayImage" class="frow <%=BicXML.ToBoolean("EnableArrayImage","SettingProduct") == false? "hidden" : "" %>">
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock36" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Product_Images") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input group-item">
                    <div>
                        <uc1:ImageSelectMulti ID="ismImageId" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>
    <script type="text/javascript">
        $(document).ready(function () { $("#ddlTypeproducts").live("change", function () { if ($(this).val() == 2) { $("#ArrayImage").show(); $("#Video").hide(); } if ($(this).val() == 3) { $("#Video").show(); $("#ArrayImage").hide(); } if ($(this).val() == 1 || $(this).val() == 4) { $("#Video").hide(); $("#ArrayImage").hide(); } }); });
    </script>
    <div class="frow hidden" id="Video">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock37" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Product_Video") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input group-item">
                <div class="col first video-image">
                    <bic:VideoSelector ID="isVideoID" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock38" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Product_ShortDescription") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Editor Height="200px" Skin="Office2007" Width="98%" ID="reBriefDescription"
                    ToolbarMode="ShowOnFocus" ToolsFile="~/admin/XMLData/Editor/SmallSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="All" />
            </div>
        </div>
    </div>

    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock39" runat="server">
                    Nội dung
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadCodeBlock runat="server" ID="radCode2">
                    <%= IncludeAdmin.RadEditor() %>
                </telerik:RadCodeBlock>
                <bic:Editor Height="500px" ID="reBody" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBarShowOnFocus" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock63" runat="server">
                    Nguyên liệu
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadCodeBlock runat="server" ID="RadCodeBlock64">
                    <%= IncludeAdmin.RadEditor() %>
                </telerik:RadCodeBlock>
                <bic:Editor Height="500px" ID="reThongso" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBarShowOnFocus" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock65" runat="server">
                    Thao tác chế biến
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadCodeBlock runat="server" ID="RadCodeBlock66">
                    <%= IncludeAdmin.RadEditor() %>
                </telerik:RadCodeBlock>
                <bic:Editor Height="500px" ID="reBanve" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBarShowOnFocus" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock67" runat="server">
                    Hình ảnh
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadCodeBlock runat="server" ID="RadCodeBlock68">
                    <%= IncludeAdmin.RadEditor() %>
                </telerik:RadCodeBlock>
                <bic:Editor Height="500px" ID="rePhamvi" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBarShowOnFocus" Skin="Office2007" />
            </div>
        </div>
    </div>

    <telerik:RadCodeBlock ID="RadCodeBlock43" runat="server">
        <div class="frow  <%=BicXML.ToBoolean("EnableRelatedProduct","SettingProduct") == false? "hidden" : "" %>">
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock25" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Product_RelatedProducts") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <telerik:RadCodeBlock ID="RadCodeBlock46" runat="server">
                        <telerik:RadAjaxPanel runat="server" ID="radAjax">
                            <uc2:relatedproduct ID="RelatedProduct1" runat="server" />
                        </telerik:RadAjaxPanel>
                    </telerik:RadCodeBlock>
                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="RadCodeBlock44" runat="server">
        <div class="frow  <%=BicXML.ToBoolean("EnableRelatedNews","SettingProduct") == false? "hidden" : "" %>">
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock40" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Product_RelatedNews") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <telerik:RadCodeBlock ID="RadCodeBlock47" runat="server">
                        <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel3">
                            <bic:RelatedArticle runat="server" ID="RelatedArticle" />
                        </telerik:RadAjaxPanel>
                    </telerik:RadCodeBlock>
                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>

    <asp:TextBox runat="server" ID="txtAllowUser" CssClass="input-text hidden" />
    <telerik:RadCodeBlock ID="RadCodeBlock58" runat="server">
        <div class="frow  <%=BicXML.ToBoolean("EnableTags","SettingProduct") == false? "hidden" : "" %>">
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock26" runat="server">
                        <%=BicResource.GetValue("Admin","System_Tags") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <asp:TextBox runat="server" ID="txtTag" MaxLength="200" CssClass="input-text" Width="85%" />
                    (Max 200)
                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>


    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock28" runat="server">
                    <%=BicResource.GetValue("Admin","System_UrlSEO") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtSeoTitle" MaxLength="100" CssClass="input-text" Width="85%" />
                (Max 100)
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock27" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Product_PageTitle") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtPageTitle" MaxLength="100" CssClass="input-text" Width="85%" />
                (Max 100)
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock29" runat="server">
                    <%=BicResource.GetValue("Admin","System_MetaDescription") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtMetaDescription" MaxLength="170" CssClass="input-text" Width="85%" />
                (Max 170)
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock30" runat="server">
                    <%=BicResource.GetValue("Admin","System_MetaKeyword") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtMetaKeyword" MaxLength="170" CssClass="input-text" Width="85%" />
                (Max 170)
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="AddNew" ValidationGroup="btnSave">
        <telerik:RadCodeBlock ID="RadCodeBlock32" runat="server">
            <%=BicResource.GetValue("Admin","Admin_Save") %>
        </telerik:RadCodeBlock>
    </asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rim1" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhTitle" EmptyMessage="<%$Resources:Admin,System_InputTitle%>" Validation-IsRequired="true"
        Validation-ValidationGroup="btnSave">
        <TargetControls>
            <telerik:TargetInput ControlID="txtTitle" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewCount" Type="Number" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewCount" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Outlook" ID="RadAjaxLoadingPanel1"
    BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
<%--Nút lên đầu--%>
<a href="#" class="toTop" style="opacity: 0; filter: alpha(opacity=0)"></a>
<script type="text/javascript">
    $(".toTop").live("click", function (event) {
        $(this).stop().animate({ opacity: 0 });
    });
    $(window).load(function () {
        var n = $(this).scrollTop();
        n = n > 300 ? 300 : n;
        $(".toTop").stop().animate({ opacity: n / 300 }, { duration: n });
    });
    $(window).scroll(function () {
        var n = $(this).scrollTop();
        n = n > 300 ? 300 : n;
        $(".toTop").stop().animate({ opacity: n / 300 }, { duration: n });
    });
</script>
<style type="text/css">
    .c3 .line .label {
        width: 106px !important;
    }
</style>
