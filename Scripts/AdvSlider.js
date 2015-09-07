$(window).load(function () {
    $(".nivoSlider br").remove();
    $("#advSlider1").nivoSlider({
        effect: 'fade',
        animSpeed: 500,
        pauseTime: 5000,
        directionNav: false,
        directionNavHide: true,
        keyboardNav: false
    });
    $("#advSlider101").nivoSlider({
        effect: 'fade',
        animSpeed: 500,
        pauseTime: 5000,
        directionNav: false,
        directionNavHide: true,
        keyboardNav: false
    });
    $("#advSlider101 .nivo-link,#advSlider1 .nivo-link").live("mouseover", function () {
        var image = $(this).parent().children(".nivo-imageLink:visible");
        if (image.attr("href") != undefined)
            $(this).attr("href", image.attr("href"));
        if (image.attr("target")) {
            $(this).attr("target", image.attr("target"));
        }
    });
});