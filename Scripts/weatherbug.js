function getWeather(city) {
    $('.scwBug.weather').children().addClass("loading16").html("");
    $.ajax({
        url: getBaseURL() + 'WebService/weatherbug.ashx?city=' + city,
        success: function (response) {
            $('.scwBug.weather').children().removeClass("loading16").html(response);
        },
        error: function ()
        { $('.scwBug.weather').children().removeClass("loading16").html("Error"); }
    });
}
function getRate() {
    if (!$('.scwBug.rate').children().hasClass("loading16")) $('.scwBug.rate').children().addClass("loading16");
    $('.scwBug.rate').children().html("");
    $.ajax({
        url: getBaseURL() + 'WebService/weatherbug.ashx?rate=usd',
        success: function (response) {
            $('.scwBug.rate').children().removeClass("loading16").html("1 USD = " + response + " RUB");
        },
        error: function ()
        { $('.scwBug.rate').children().removeClass("loading16").html("Error"); }
    });
}

$(window).load(function () {
    getWeather('moscow');
    getRate();
});
$(document).ready(function () {

    $("#ddlswcCity").live("change", function () {
        getWeather($(this).val());
    });
});