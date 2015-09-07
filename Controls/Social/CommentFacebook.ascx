<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentFacebook.ascx.cs" Inherits="Controls_Social_CommentFacebook" %>

<div class="fb-comments" data-href='<%= Request.Url.ToString()%>' data-width="680px" data-numposts="5" data-colorscheme="light"></div>
            <div id="fb-root"></div>
            <script>
                (function (d, s, id) {
                    var js, fjs = d.getElementsByTagName(s)[0];
                    if (d.getElementById(id)) return;
                    js = d.createElement(s); js.id = id;
                    js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&appId=912672588749004&version=v2.0";
                    fjs.parentNode.insertBefore(js, fjs);
                }(document, 'script', 'facebook-jssdk'));
            </script>