<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuLeft2.ascx.cs" Inherits="Controls_Menu_MenuLeft2" %>
<%@ Import Namespace="BIC.Utils" %>


<div class="menu fl">
    <bic:MenuListView ID="menuParent" runat="server" SelectFields="ParentId" OnItemDataBound="MenuParentItemDataBound">
        <LayoutTemplate>
           <ul class="fl">
                <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
             </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li class="li <%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? "active":"" %>" >
                <a class="li1 <%#Container.DataItemIndex %>" href='<%# Eval("Url") %>'><%# Eval("Name") %></a>
                <ul class="lc2 <%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? "":"hidden" %>">
                <bic:MenuListView runat="server" ID="menuChild" SelectFields="ParentId">
                    <ItemTemplate>
                        <li class="lic2 <%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? "active":"" %>" >
                            <a href='<%#Eval("Url")  %>' class="namec2"><%# Eval("Name") %></a>
                        </li>
                    </ItemTemplate>
                </bic:MenuListView>
                </ul>
            </li>
        </ItemTemplate>
    </bic:MenuListView>
</div>

<script type="text/javascript">
    $('.menu ul.fl li').last().addClass("last");
</script>
