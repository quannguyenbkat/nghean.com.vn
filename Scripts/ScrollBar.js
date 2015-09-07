$(document).ready(function () {
    $(".scrollcontent").each(function () {
        if ($(this).height() <= $(this).parent().height()) {
            $(this).prev().remove();
        }
    });
    $(".scrollbar .pointer").attr("pos", 0).draggable({
        axis: "y",
        containment: "parent",
        drag: function (event, ui) {
            var dco = $(this).parent().next();
            var hsc = $(this).parent().height() - 37;
            var hco = dco.height() - hsc - 37;
            var ytop = $(this).position().top;
            ytop = ytop > 0 ? ytop : 0;
            ytop = ytop < hsc ? ytop : hsc;
            $(this).css("top", ytop);
            var scale = (hco) / hsc;
            var dis = (-ytop) * scale;
            $(this).attr("pos", ytop);
            dco.stop().animate({ top: dis }, 100, 'easeOutCirc');
        }
    }).live("mouseup", function () {
        var hsc = $(this).parent().height() - 37;
        var ytop = $(this).position().top % hsc;
        ytop = ytop > 0 ? ytop : 0;
        $(this).css("top", ytop);
    });
    $(".scrollbar").live("click", function (event) {
        var dco = $(this).next();
        var hsc = $(this).height() - 37;
        var hco = dco.height() - hsc - 37;
        var ytop = event.pageY - $(this).offset().top - 18;
        ytop = ytop > 0 ? ytop : 0;
        ytop = ytop < hsc ? ytop : hsc;
        var pointer = $(this).children('.pointer');
        pointer.css("top", ytop);
        var scale = (hco) / hsc;
        var dis = (-ytop) * scale;
        pointer.attr("pos", ytop);
        dco.stop().animate({ top: dis }, 100, 'easeOutCirc');
    });

});