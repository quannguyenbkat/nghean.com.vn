(function ($) {
    $.fn.Floating = function () {
        var obj = $(this);
        var fh = $(this).height();
        var limit = $(".mainFrame").height() - 10;
        $(document).ready(function () {
            var stop = $(window).scrollTop();
            var padd = stop - obj.offset().top + 10;
            if (padd >= 0) {
                if (fh + padd <= limit) {
                    obj.stop().animate({ "padding-top": padd }, 500);
                } else {
                    obj.stop().animate({ "padding-top": limit - fh }, 500);
                }
            } else {
                obj.stop().animate({ "padding-top": 0 }, 500);
            }
        });
        $(window).scroll(function () {
            var stop = $(this).scrollTop();
            var padd = stop - obj.offset().top + 10;
            if (padd >= 0) {
                if (fh + padd <= limit) {
                    obj.stop().animate({ "padding-top": padd }, 500);
                } else {
                    obj.stop().animate({ "padding-top": limit - fh }, 500);
                }
            } else {
                obj.stop().animate({ "padding-top": 0 }, 500);
            }
        });
    };
})(jQuery);
