<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Like.ascx.cs" Inherits="Controls_Social_Like" %>

    <div class="DivbtLike">
        <div class="bttw"><a class="twitter-share-button" href='<%= Request.Url.ToString() %>'>Tweet</a></div>
        <div class="btgg">
            <div class="g-plusone" data-size="medium" data-href='<%= Request.Url.ToString() %>'></div>
        </div>
        <div class="btfbs">
            <div class="fb-share-button" data-href='<%= Request.Url.ToString() %>' data-layout="button_count"></div>
        </div>
        <div class="btfbl">
            <div class="fb-like" data-href='<%= Request.Url.ToString() %>' data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div>
        </div>
    </div>


<div style="clear: both;"></div>
<div class="likegoogle">
    <script type="text/javascript">
        window.twttr = (function (d, s, id) { var t, js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) { return } js = d.createElement(s); js.id = id; js.src = "https://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); return window.twttr || (t = { _e: [], ready: function (f) { t._e.push(f) } }) }(document, "script", "twitter-wjs"));
    </script>
    <script type="text/javascript">

        window.___gcfg = { lang: 'vi' };
        (function () {

            var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;

            po.src = 'https://apis.google.com/js/plusone.js';

            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);

        })();

    </script>
    <div id="fb-root"></div>
    <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.0";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
</div>
