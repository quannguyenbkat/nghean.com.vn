if ($("#hdPollID").val() != "") {
    Votting($("#hdPollID").val(), 0, '', 'Tổng', 'lượt', 'showPoll');
}
else {
    $("#pnlvote").html("");
    $("#btnVote,#btnResult").hide();
}
$("#btnVote").click(function () {
    
    if ($('input[name=rdoVote]:radio:checked').val() == "105") {
        alert('Bạn chưa chọn bức ảnh nào, hãy chọn bức ảnh mà bạn thấy ấn tượng nhất.');
    }
    else {
        Votting($("#hdPollID").val(), $('input[name=rdoVote]:radio:checked').val(), '', 'Tổng', 'lượt', 'UpdatePollCount');
        $("#vote").css("padding-bottom", "0");
        $("#btnVote,#btnResult,.btnVote").hide();
    }
});
$("#btnResult").click(function () {
    if ($("#btnResult").val() =="Quay lại bình chọn")
        ViewResult($("#hdPollID").val(), 1, '', 'Tổng', 'lượt', 1, 'showResult');
    else
        ViewResult($("#hdPollID").val(), 0, '', 'Tổng', 'lượt', 0, 'showResult');
        
    
});
function Votting(pID, cID, votted, TotalText, voteText, _function) {
    $.ajax({
        type: "POST",
        url: getBaseURL() + 'WebService/Poll.asmx/' + _function,
        data: "{'pID':'" + pID + "','cID':'" + cID + "','votted':'" + votted + "','TotalText':'" + TotalText + "','voteText':'" + voteText + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (message) {
            if (message.d != "") {
                $("#pnlvote").html(message.d).css("padding-top", "10px");
                animal();
            }
            else {
                $("#btnVote,#btnResult").hide();
                $("#pnlvote").html("");
            }
        },
        error: function (errormessage) {
            //$("#test").html(errormessage.responseText);
        }
    });
};

function ViewResult(pID, cID, votted, TotalText, voteText,loadPoll, _function) {
    $.ajax({
        type: "POST",
        url: getBaseURL() + 'WebService/Poll.asmx/' + _function,
        data: "{'pID':'" + pID + "','cID':'" + cID + "','votted':'" + votted + "','TotalText':'" + TotalText + "','voteText':'" + voteText + "','loadPoll':'" + loadPoll + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (message) {
            if (loadPoll == "0") {
                $("#pnlvote").html(message.d).css("padding-top", "10px");
                $("#btnVote").hide();
                $("#btnResult").val("Quay lại bình chọn");
            }
            else {
                $("#pnlvote").html(message.d).css("padding-top", "10px");
                $("#btnVote").show();
                $("#btnResult").val("Xem kết quả");
            }

        },
        error: function (errormessage) {
            //$("#test").html(errormessage.responseText);
        }
    });
};

function animal() {
    $("div#effect").each(function () {
        $("#divVotingBlock div.img,#divVotingBlock .btnVote").remove();
        var percentage = $(this).next("span.resul-tvote").text().trim();
        $(this).delay(100).animate({ width: percentage }, 2000);
    });
    if ($("div#effect").attr("id") != undefined) {
        $("#divVotingBlock").attr("style", "padding-bottom: 56px");
    }
};
