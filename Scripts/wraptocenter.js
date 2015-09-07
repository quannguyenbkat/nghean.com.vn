/*
PECORA 1/6/2012
*/
(function ($) {
    $.fn.WrapToCenter = function () {
        var a = $(this);
        var b = a.children();
        var c = $("<span />");
        a.attr("style", "display:block!important;vertical-align:middle!important;text-align:center!important");
        c.attr("style", "display:inline-block!important;width:0!important;height:100%!important;line-height:100%!important;margin-left:-4px!important;verticle-align:middle!important;");
        b.attr("style", "display:inline-block!important;").before(c);
    };
    $.fn.WrapperCenter = function () {
        var b = $(this);
        var a = $(this).parent();
        var c = $("<span />");
        a.attr("style", "display:block!important;vertical-align:middle!important;text-align:center!important");
        c.attr("style", "display:inline-block!important;width:0!important;height:100%!important;line-height:100%!important;margin-left:-4px!important;verticle-align:middle!important;");
        b.attr("style", "display:inline-block!important;").before(c);
    };
    $.fn.WrapperCenterWithCss = function (option) {
        option = $.extend($.WTCdefaultValue, {}, option);
        $(this).addClass(option.wrapper).children().addClass(option.object).before("<span class='" + option.span + "'></span>");
    };
    $.WTCdefaultValue = {
        wrapper: 'Wrapper',
        span: 'SpanSupport',
        object: 'ObjectCenter'
    };
})(jQuery);