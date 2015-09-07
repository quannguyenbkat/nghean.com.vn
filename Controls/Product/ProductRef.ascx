<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductRef.ascx.cs" Inherits="Controls_Product_ProductRef" %>
<%@ Import Namespace="BIC.Utils" %>
<%= Include.CarouFredSel() %>

<div class="fl clear related-pro">
    <div class="skew-bar5">
        <h2><%=BicResource.GetValue("RelatedProducts") %></h2>
    </div>
    <div class="sp-lq">
        <ul>
            <bic:ProductListViewRef runat="server" ID="lvProdRef" ExtensionLink="HTML" ClientIDMode="Static" SelectFields="ImageName" EnableAroundUp="true">
                <ItemTemplate>
                    <li>
                        <a href='<%# Eval("Url") %>' title='<%# Eval("Title") %>' class="roll"></a>
                        <bic:Image runat="server" ID="avatar" CssClass="imgAva" ImageName='<%# Eval("ImageName") %>' Target='<%# Eval("Target") %>' Title='<%# Eval("Title") %>' Alt='<%# Eval("Title") %>' Link='<%# Eval("Url") %>'></bic:Image>
                        <a class="title" href='<%# Eval("Url") %>' title='<%# Eval("Title") %>'><%#Eval("Title") %></a>
                    </li>
                </ItemTemplate>
            </bic:ProductListViewRef>
        </ul>
    </div>
</div>

<script type="text/javascript">
    if ($('.related-pro .sp-lq ul li').length > 4)
        $(".related-pro .sp-lq ul").carouFredSel({
            auto: true,
            items: 4,
            direction: "right",
            scroll: {
                items: 1,
                duration: 1000,
                pauseDuration: 3000,
                pauseOnHover: "immediate"
            },
            prev: ".btNext",
            next: ".btPrev",
            width: 810,
            height:200

        });

</script>
