<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShareHome.ascx.cs" Inherits="Controls_Social_ShareHome" %>

<div id="Share_Home">
    <div class="mncap">FANPAGE</div>
    <div class="content">
        <div id="fb-root"></div>
        <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.3&appId=1561866187404573";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
        <div class="fb-page" data-href="https://www.facebook.com/amthucdoday" data-width="230" data-hide-cover="false" data-show-facepile="true" data-show-posts="false">
            <div class="fb-xfbml-parse-ignore">
                <blockquote cite="https://www.facebook.com/amthucdoday"><a href="https://www.facebook.com/amthucdoday">Ẩm thực hôm nay</a></blockquote>
            </div>
        </div>
    </div>
</div>
