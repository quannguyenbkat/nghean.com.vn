<%@ Control Language="C#" AutoEventWireup="true" CodeFile="facebook.ascx.cs" Inherits="Controls_Comment_facebook" %>
<div class="fb-comments" data-href='<%= Url %>' data-num-posts="<%=PostCount %>" data-width='<%= Width %>'></div>

<div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = '//connect.facebook.net/vi_VN/all.js#xfbml=1<%= AppId %>';
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

<div id="Div1"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = '//connect.facebook.net/vi_VN/all.js#xfbml=1<%= AppId %>';
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>