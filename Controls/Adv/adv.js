$(document).ready(function () {
    $(".slider-logo .item").live("click", function () {
        $.ajax({
            url: '/WebService/AdvViewCount.ashx?id=' + $(this).attr("value"),
            success: function (response) {

            },
            error: function () {

            }
        });
    });
});