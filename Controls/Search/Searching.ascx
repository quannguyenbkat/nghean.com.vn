<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Searching.ascx.cs" Inherits="Controls_Search_Searching" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="searchBlock" id="searchform">
    <div class="search-text">
             <asp:Panel ID="Panel1" runat="server" DefaultButton="ibtSearch">
        <input type="text" runat="server" id="txtSearch" clientidmode="Static" class="input-text" />
        <asp:HiddenField ID="hdKeyword" runat="server" ClientIDMode="Static" />
        <asp:Button ID="ibtSearch" runat="server" CssClass="search-button" Text='<%$Resources:Resource,Search%>' ClientIDMode="Static" OnClick="ibtSearch_Click" />
                 </asp:Panel>
    </div>
</div>

<script type="text/javascript">
    function clickButton1(e, buttonid) {
        var evt = e ? e : window.event;
        var bt = document.getElementById(buttonid);
        if (bt) {
            if (evt.keyCode == 13) {
                bt.click();
                return false;
            }
        }
    }
    $(document).ready(function () {
        var keywords = $("#txtSearch").attr("val");
        var defaultvalue = '<% = BicResource.GetValue("Keyword") %>';

       
        $('.searchBlock .remove').live("click", function (e) {
            $("#txtSearch").focus().val('');
            $('.searchBlock .remove').hide();
        });

        $("#txtSearch").live("focusin focusout change keyup keydown keypress", function (e) {
            if (e.type == "focusin") {
                if ($(this).val() == defaultvalue) {
                    $(this).val("");
                } else {
                    $('.searchBlock .remove').show();
                }
            }
            if (e.type == "focusout") {
                if ($(this).val() == "")
                    $(this).val(defaultvalue);
                $(".searchBlock").live("mouseout", function () {
                    $('.searchBlock .remove').hide();
                });
            }
            if (e.type == 'change' || e.type == 'keyup' || e.type == 'keydown' || e.type == 'keypress') {
                if (e.keyCode == 27) {
                   
                    $(this).blur();
                    return;
                }
                if ($(this).val() != '') {
                    $('.searchBlock .remove').show();
                } else {
                    $('.searchBlock .remove').hide();
                }
            }
        });
                <%-- Sử dụng Autocomplete ---%>
                <%-- 
        $("#txtSearch").autocomplete('<%= Page.ResolveUrl(string.Format("~/Controls/Search/AutoComplete.ashx?lang={0}&qcl={1}",
                                                      BicLanguage.CurrentLanguage, BicResource.GetValue("QuickLink"))) %>');
         --%>
    })
</script>
