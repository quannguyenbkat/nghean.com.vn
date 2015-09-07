function FloatInterval() {
    var a = $(".MAHot .menuCatSub a");
    var b = a.parent().children(".selecttab");
    var c = b.index() >= a.length - 1 ? a.eq(0) : b.next();
    b.removeClass("selecttab");
    c.addClass("selecttab");
    $(".MAContent .inbl").stop().animate({ marginLeft: -100 * c.index() + '%' });
    
}
function intervalFloat(bb) {
    var ia = $(bb).parent().children("a");
    var ib = ia.parent().children(".select");
    var ic = ib.index() >= ia.length - 1 ? ia.eq(0) : ib.next();
    if (ic.attr("class") == undefined) ic = ic.next();
    var id = ia.parent().parent().parent();
    var ie = id.attr("id");
    ib.removeClass("select");
    ic.addClass("select");
    $("#" + ie + " .floatable").stop().animate({ marginLeft: -100 * (ia.index(ic) / (ic.prev().attr("class") == undefined ? 2 : 1)) + '%' });
   
}
$(document).ready(function () {
    var t = setInterval("FloatInterval()", 15000);
    $(".MAHot .menuCatSub a").live("click", function () {
        if (!$(this).hasClass("selecttab")) {
            $(".MAHot .menuCatSub a.selecttab").removeClass("selecttab");
            $(this).addClass("selecttab");
            if ($(this).hasClass("news")) {
                $(".MAContent .inbl").stop().animate({ marginLeft: 0 });
            }
            if ($(this).hasClass("common")) {
                $(".MAContent .inbl").stop().animate({ marginLeft: -100 + '%' });
            }

        }
    }); $(".MAHot").live("mouseover mouseout", function (event) {
        if (event.type == "mouseover") {
            t = clearInterval(t);
        }
        if (event.type == "mouseout") {
            t = setInterval("FloatInterval()", 15000);
        }
    });
    var interval1 = setInterval(function (){ intervalFloat("#HighLightStream a.menuitem"); }, 15000);
    var interval2 = setInterval(function () {
        intervalFloat("#summary #ctl00_cphRight_SummaryArticle2_summary .sNav .sNavFilter a");
    }, 15000);
    var interval3 = setInterval(function () {
        intervalFloat("#summary #ctl00_cphRight_SummaryArticle1_summary .sNav .sNavFilter a");
    }, 15000);
    $("#HighLightStream a.menuitem").floatable();
    $("#summary .sNav .sNavFilter a").floatable();
    $("#HighLightStream").live("mouseover mouseout", function (event) {
        if (event.type == "mouseover") {
            interval1 = clearInterval(interval1);
        }
        if (event.type == "mouseout") {
            interval1 = setInterval(function (){ intervalFloat("#HighLightStream a.menuitem"); }, 15000);
        }
    });
    $("#ctl00_cphRight_SummaryArticle1_summary").live("mouseover mouseout", function (event) {
        if (event.type == "mouseover") {
            interval3 = clearInterval(interval3);
        }
        if (event.type == "mouseout") {
            interval3 = setInterval(function () {
                intervalFloat("#summary #ctl00_cphRight_SummaryArticle1_summary .sNav .sNavFilter a");
            }, 15000);
        }
    });
    $("#ctl00_cphRight_SummaryArticle2_summary").live("mouseover mouseout", function (event) {
        if (event.type == "mouseover") {
            interval2 = clearInterval(interval2);
        }
        if (event.type == "mouseout") {
            interval2 = setInterval(function () {
                intervalFloat("#summary #ctl00_cphRight_SummaryArticle2_summary .sNav .sNavFilter a");
            }, 15000);
        }
    });
    $('a.vote5star:not(.voted)').live("click", function () {
        var a = $(this);
        $.ajax({
            url: getBaseURL() + StringFormat("WebService/ArticleReview.ashx?id={0}&vote={1}&d={2}", $(this).attr("value"), 5, 0),
            success: function (message) {
                eval(message);
                if (eval(success)) {
                    a.addClass("voted");
                    a.html(a.html().replace(eval(votecount) - 1, eval(votecount)));
                } else {
                    alert("Bạn đã tham gia đánh giá bài viết");
                }
            },
            error: function () {

            }
        });
    });
});
(function ($) {
    $.fn.floatable = function () {
        $(this).live("click", function (event) {
            var a = $(this).parent().children("a");
            var b = $(this).parent();
            while (b.attr("id") == undefined) {
                b = b.parent();
            }
            var c = b.attr("id");
            var d = a.index($(this)) / ($(this).prev().attr("class") == undefined ? 2 : 1);
            b = $("#" + c + " a.viewmore");
            if (b.attr("href") != undefined)
                b.attr("href", b.attr("href").replace(".nal" + a.index(a.parent().children(".select")) + ".", ".view" + d + "."));
            
            event.preventDefault();
            a.removeClass("select");
            $(this).addClass("select");
           
            $("#" + c + " .floatable").stop().animate({ marginLeft: -100 * d + '%' });
            
        });
    };
})(jQuery);
