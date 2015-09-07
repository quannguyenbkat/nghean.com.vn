(function ($) {
    $.fn.FullScreenShow = function () {
        var a = $("#" + $(this).attr("id") + " .aiaItem");
        var b = $("#" + $(this).attr("id") + " .aiaItem:not(.disabled)");
        var c = $("#" + $(this).attr("id") + " .aiaItem.disabled");
        var _stylemax = StringFormat("max-width:{0}px;max-height:{1}px;", $(window).width(), $(window).height());
        var current = 0;
        a.unbind("click").bind("click", function (event) {
            event.preventDefault();
            if ($(this).hasClass("disabled")) return;
            createDiv();
            var d = $(".navigator .bound .slide");
            d.width(b.length * 41);
            if (d.width() > d.parent().width()) {
                $(".bnZoom .bnZoommain .navigator .next").css("display", "block");
            } else {
                d.css("margin", "0 auto");
            }
            if (!$(this).hasClass("disabled")) {
                b.clone().appendTo(d);
                b.each(function () {
                    createImg("precache", $(this).attr("href"), _stylemax);
                });
                var h = $(".view-div div");
                var ff = $(".bnZoom .bnZoommain .navigator .aiaItem");
                ff.each(function() {
                    $(this).onselect = function () { return false; };
                });

                var e = $(".bnZoom .bnZoommain .navigator .aiaItem img");
                var m = $(this).index() + $(this).parent().index() * $(this).parent().children("a").length;
                current = m;
                var g = ff.eq(m);
                h.eq(m).stop().animate({ opacity: 1 }).addClass("isView");
                g.addClass("viewing");
                var offset = d.width() - d.parent().width();
                ff.unbind("click").bind("click", function (event2) {
                    event2.preventDefault();
                    $(".viewing").removeClass("viewing");
                    $(this).addClass("viewing");
                    $(".isView").removeClass("isView").stop().animate({ opacity: 0 });
                    var img = h.eq($(this).index());
                    img.addClass("isView").stop().animate({ opacity: 1 });
                    var i = $(this).position().left + 7;
                    if (i + $(this).width() > $(this).parent().parent().width()) {
                        $(this).parent().stop().animate({ marginLeft: '-=' + (-$(this).parent().parent().width() + i) });
                    }
                    if (i - 47 < 0) {
                        $(this).parent().stop().animate({ marginLeft: '-=' + (i - 47) });
                    }
                    var currentpos = -parseInt(d.css("margin-left").replace("px", ""));
                    if (offset != currentpos && offset > 0) {
                        $(".bnZoom .bnZoommain .navigator .next").show();
                    } else {
                        $(".bnZoom .bnZoommain .navigator .next").hide();
                    }
                    if (currentpos != 0 && offset > 0) {
                        $(".bnZoom .bnZoommain .navigator .prev").show();
                    } else {
                        $(".bnZoom .bnZoommain .navigator .prev").hide();
                    }
                });
            }
        });


        $(".bnZoom .bnZoommain .navigator .nav").live("click", function (event) {
            var offset = $(".bnZoom .bound .slide").width() - $(".bnZoom .bound").width();
            if (offset < 0) {
                $(".bnZoom .bnZoommain .navigator .nav").hide(); return;
            }

            var currentpos = -parseInt($(".bnZoom .bound .slide").css("margin-left").replace("px", ""));
            var j = 4;
            var k = j * 41;
            if ($(this).hasClass("next")) {
                k = k + currentpos > offset ? offset - currentpos : k;
                $(".bnZoom .bound .slide").stop().animate({ marginLeft: '-=' + k });
                if (k == offset - currentpos) {
                    $(this).hide();
                }
                if (k > 0) {
                    $(".bnZoom .bnZoommain .navigator .prev").show();
                }
            }
            if ($(this).hasClass("prev")) {
                k = currentpos > k ? k : currentpos;
                $(".bnZoom .bound .slide").stop().animate({ marginLeft: '+=' + k });
                if (k == currentpos) {
                    $(this).hide();
                }
                if (currentpos - k < offset) {
                    $(".bnZoom .bnZoommain .navigator .next").show();
                }
            }
        });
        $("html").unbind("keyup").bind("keyup", function (event) {
            var h = $(".view-div div");
            var e;
            switch (event.keyCode) {
                case 27:
                    event.preventDefault();
                    $(".bnZoom").remove();
                    break;
                case 37:
                    event.preventDefault();
                    showNav();
                    e = $(".viewing").is(".bnZoom .bnZoommain .navigator .aiaItem:first") ? $(".bnZoom .bnZoommain .navigator .aiaItem:last") : $(".viewing").prev();
                    $(".viewing").removeClass("viewing");
                    e.addClass("viewing");

                    $(".isView").removeClass("isView").stop().animate({ opacity: 0 });
                    h.eq(e.index()).addClass("isView").stop().animate({ opacity: 1 });
                    t = setTimeout(function () {
                        hideNav();
                    }, 5000);
                    break;
                case 39:
                    event.preventDefault();
                    showNav();
                    e = $(".viewing").is(".bnZoom .bnZoommain .navigator .aiaItem:last") ? $(".bnZoom .bnZoommain .navigator .aiaItem:first") : $(".viewing").next();
                    $(".viewing").removeClass("viewing");
                    e.addClass("viewing");
                    $(".isView").removeClass("isView").stop().animate({ opacity: 0 });
                    h.eq(e.index()).addClass("isView").stop().animate({ opacity: 1 });
                    t = setTimeout(function () {
                        hideNav();
                    }, 5000);
                    break;

            }
        });
        $(".bnZoomback").unbind("click").live("click", function () {
            $(this).parent().remove();
        });
        $(".bnZoommain .panel").live("mouseover mouseout", function (event) {
            if (event.type == "mouseover" && !$(this).hasClass("show")) {
                $(this).addClass("show").stop().animate({ opacity: 1 }, 200);
                if ($(this).hasClass("right")) {
                    $(this).children().stop().animate({ right: 0 });
                }else
                    $(this).children().stop().animate({ left: 0 });
            }
            if (event.type == "mouseout") {
                $(this).removeClass("show").stop().animate({ opacity: 0 });
                if ($(this).hasClass("right")) {
                    $(this).children().stop().animate({ right: "-63px" });
                }else
                    $(this).children().stop().animate({ left: "-63px" });
            }
        });
        $(".bnZoommain .panel a").live("click", function (event) {
            event.preventDefault();

            var e = $(this).hasClass("next") ? 1 : -1;
            var f = ($(".viewing").index() + e + b.length) % b.length;
            var g = $(".viewing").parent().children();
            $(".viewing").removeClass("viewing");
            g.eq(f).addClass("viewing");
            $(".isView").removeClass("isView").stop().animate({ opacity: 0 });
            $(".view-div div").eq(f).addClass("isView").stop().animate({ opacity: 1 });
            event.preventBubble();
            event.stopImmediatePropagation();
        });
        $.defaultOption = { allowfullwidth: true };
        var t = setTimeout(function () {
            hideNav();
        }, 7000);
        $(".navigator .bound").live("mouseover mouseout", function (event) {
            if (event.type == "mouseover") {
                showNav();
            }
            if (event.type == "mouseout") {
                t = setTimeout(function () {
                    hideNav();
                }, 5000);
            }
        });
        function hideNav() {
            $(".navigator .bound").stop().animate({ opacity: 0.2 });
            clearTimeout(t);
        }
        function showNav() {
            $(".navigator .bound").stop().animate({ opacity: 1 });
            clearTimeout(t);
        }
    };

    function createImg(_class, _src, _style) {
        var img = $("<div />");
        img.addClass(_class).css("background-image", StringFormat("url({0})", _src)).appendTo($(".bnZoom .view-div"));

        var image = new Image();
        image.onload = function () {
            if (image.width > img.width || image.height > img.height()) {
                img.css("background-size", "contain");
            }
        };
        image.src = _src;
    }
    function createDiv() {
        $("<div />").addClass("bnZoom").appendTo($("body"));
        $("<div />").addClass("bnZoomback").appendTo($(".bnZoom"));
        $("<div />").addClass("bnZoommain").appendTo($(".bnZoom"));
        $("<div />").addClass("navigator").appendTo($(".bnZoommain"));
        $("<div />").addClass("view-div loading").appendTo($(".bnZoommain"));
        $("<div />").addClass("bound").appendTo($(".navigator"));
        $("<div />").addClass("slide").appendTo($(".navigator .bound"));
        $("<div />").addClass("panel").appendTo($(".bnZoommain")).clone().addClass("right").appendTo($(".bnZoommain"));
        $("<a />").addClass("nav next").appendTo($(".navigator")).clone().appendTo($(".bnZoommain .panel.right"));
        $("<a />").addClass("nav prev").appendTo($(".navigator")).clone().appendTo($(".bnZoommain .panel:not(.right)"));
        $("<a />").addClass("btnClose").attr("title", "Đóng cửa sổ").bind("click", function () {
            $(".bnZoomback").click();
        }).appendTo(".bnZoommain");

    }
})(jQuery);

