<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleReference.ascx.cs" Inherits="Controls_Article_ArticleReference" %>
<%@ Import Namespace="BIC.Utils" %>





<div class="refProduct">
    <div class="mncap">
        <h2><%=BicResource.GetValue("Article_Other") %></h2>
    </div>
    <bic:ArticleListViewRef runat="server" GroupItemCount="5" ID="lvReference" SelectFields="CreatedDate" ExtensionLink="HTML">
        <GroupTemplate>
            <ul>
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </ul>
        </GroupTemplate>
        <ItemTemplate>
            <li class="item">
                <span><%#BicDateTime.FormatDDMMYYYY(DateTime.Parse(Eval("CreatedDate").ToString())) %> &nbsp;-</span>
                <a href="<%# Eval("Url") %>" class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>' title='<%#Eval("Title") %>'>
                    <%# BicString.TrimText(Eval("Title").ToString(),120) %> <%#Eval("NewsIcon") %>
                </a>
            </li>
        </ItemTemplate>
    </bic:ArticleListViewRef>
</div>

