$(document).ready(function () {
    $(".inputMark label").hide();
    $("#btnSearch").attr("disabled", "disabled");
    if ($(".inputMark #txtDownloadSearch").val() == "")
        $(".inputMark label").show();
    $(".inputMark #txtDownloadSearch").focus(function () {
        $(".inputMark label").hide();
    });
    $(".inputMark #txtDownloadSearch").blur(function () {
        if ($(".inputMark #txtDownloadSearch").val() == "")
            $(".inputMark label").show();
    });
    $(".inputMark #txtDownloadSearch").keypress(function (e) {
        if ($(".inputMark #txtDownloadSearch").val() != defaultvalue && $(".inputMark #txtDownloadSearch").val() != "") {
            $("#btnSearch").removeAttr("disabled");
            if (e.which == 13) {
                $("#btnSearch").click();
            }
        }
        else
            $("#btnSearch").attr("disabled", "disabled");
    });
    $(".downloadContent .item .centerCol").each(function () {
        $(this).find("p").css("margin-top", (parseInt($(this).css("height")) - parseInt($(this).find("p").css("height"))) / 2 + "px");
    });
});