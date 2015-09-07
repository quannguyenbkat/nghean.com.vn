$(window).load(function () {
    $('.articlelist .slider-wrapper .linkitem,.articlelist .relateview .imageitem').remove();
    $('.articlelist .slider-wrapper,.articlelist .relateview').show();
    $('.articlelist').removeClass("loading16");
    $('#slider').nivoSlider({ effect: 'fade', animSpeed: 500, pauseTime: 8000, slices: 15 });
    $('#slider2').nivoSlider({ effect: 'fade', animSpeed: 500, pauseTime: 8000, slices: 15 });
    
});

$(document).ready(function () {
    $(".aiAlbum .floatable").ImagePaging(657);
    $(".mhlAlbum .floatable").ImagePaging(235);
    /*$(".mhlAlbum .floatable img").ImageView($("#ArticleListing.ArticleImage .mosthighlight .alimgView"));*/
});
(function ($) {
    $.fn.ImagePaging = function (w) {
        var a = $(this).children(".aiabound");
        if (a.length == 0) return;
        var b = $(this);
        $(".ainavigate .prev").addClass("disable").attr("value", 0);
        $(".ainavigate .next").attr("value", 1);
        if ($(".ainavigate .next").attr("value") == a.length)
            $(".ainavigate .next").addClass("disable");
        else
            $(".ainavigate .next").removeClass("disable");
        $(this).css("width", w * a.length + "px");
        $(".ainavigate a").live("click", function (event) {
            event.preventDefault();
            if ($(this).hasClass("disable")) return;
            var e = 1;
            if ($(this).hasClass("prev")) {
                b.stop().animate({ marginLeft: -w * ($(this).attr("value") - e) + "px" });
                e = -e;
            } else
                b.stop().animate({ marginLeft: -w * ($(this).attr("value")) + "px" });
            $(this).parent().children().each(function () {
                $(this).attr("value", $(this).attr("value") + e);
            });
            if ($(".ainavigate .prev").attr("value") == 0) {
                $(".ainavigate .prev").addClass("disable");
            } else $(".ainavigate .prev").removeClass("disable");
            if ($(".ainavigate .next").attr("value") == a.length)
                $(".ainavigate .next").addClass("disable");
            else
                $(".ainavigate .next").removeClass("disable");
        });
        b.FullScreenShow();
        $("html").live("keyup", function (event) {
            switch (event.keyCode) {
                case 37:
                    event.preventDefault();
                    break;
                case 38:
                    event.preventDefault();
                    break;
                case 39:
                    event.preventDefault();
                    break;
                case 40:
                    event.preventDefault();
                    break;
            }
        });
    };
    $.fn.ImageView = function (view) {
        $(this).live("click", function (event) {
            event.preventDefault();
            view.css("position", "relative").children("img").attr("style", "position:absolute;top:1px;left:1px;z-index:10;").addClass("old");
            var old = view.children(".old");
            if ($(this).is("a")) {
                $("<img/>").attr("src", $(this).attr("href")).attr("style", "position:absolute;top:1px;left:1px;z-index:5;").appendTo(view);
            }
            if ($(this).is("img")) {
                $("<img/>").attr("src", $(this).attr("src").replace("&thumbnail=true", "")).attr("style", "position:absolute;top:1px;left:1px;z-index:5;").appendTo(view);
            }
            old.stop().animate({ opacity: 0 }, 1000, function () {
                old.remove();
                view.children().css("z-index", "10");
            });
        });
    };
    $.fn.ImageHover = function (option) {
        option = $.extend("", $.ImageHoverOptions, option);

        var c = $("<div />").attr("style", StringFormat("background:url({0});width:100%;height:100%;top:0;left:0;position:absolute;z-index:100;", option.ImagePath));
        $(this).each(function () {
            var a = $(this).parent();
            var as = a.attr("style");
            as = as == undefined ? "" : as;
            var b = $(this);
            var bs = b.attr("style");
            bs = bs == undefined ? "" : bs;
            $(this).bind("mouseover mouseout", function (event) {
                if (event.type == "mouseover") {
                    a.css({ "position": "relative" }).append(c);
                    b.css({ "position": "absolute", "top": "0px", "left": "0px", "z-index": "0" });
                }
                if (event.type == "mouseout") {
                    a.attr("style", as);
                    b.attr("style", bs);
                }
            });
        });
    };
    $.ImageHoverOptions = { ImagePath: ResolveUrl("~/Styles/img/grid.png") };
})(jQuery);

