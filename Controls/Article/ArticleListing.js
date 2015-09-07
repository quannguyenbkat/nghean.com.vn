$(document).ready(function () {
    var pageSize = 5;
    var pageIndex = 0;
    searchArticle(pageSize, pageIndex);
    $(document).ready(function () {
        window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
        function endRequestHandler(sender, args) {
            searchArticle(pageSize, pageIndex);
        }
    });
    // Check Search
    $(".check_box").children().click(function () {
        searchArticle(pageSize, pageIndex);
    });

    $('.bottomPagerBlock').ajaxComplete(function () {
        $('.bottomPagerBlock a.num').each(function () {
            if ($(this).attr('id') == $.trim($('.bottomPagerBlock').attr('id')))
                $(this).addClass('select');
        });

        if ($('.bottomPagerBlock').hasClass('0')) {
            $('.bottomPagerBlock a.num').removeClass('select');
            $('.bottomPagerBlock a.num:first').addClass('select');
        }

        $('.bottomPagerBlock a.num').click(function () {
            $('.bottomPagerBlock a.num').removeClass('select');
            $('.bottomPagerBlock').removeClass('0').attr('id', $(this).attr('id'));
            searchArticle(pageSize, parseInt($(this).attr('id')) - 1);
            return false;
        });
        $('.bottomPagerBlock a.prev-page').click(function () {
            $(this).attr('id', $(this).parent().find('a.select').attr('id'));
            $('.bottomPagerBlock a.num').removeClass('select');
            $('.bottomPagerBlock').removeClass('0').attr('id', parseInt($(this).attr('id')) - 1);
            searchArticle(pageSize, parseInt($(this).attr('id')) - 2);
            return false;
        });
        $('.bottomPagerBlock a.next-page').click(function () {
            $(this).attr('id', $(this).parent().find('a.select').attr('id'));
            $('.bottomPagerBlock a.num').removeClass('select');
            $('.bottomPagerBlock').removeClass('0').attr('id', parseInt($(this).attr('id')) + 1);
            searchArticle(pageSize, parseInt($(this).attr('id')));
            return false;
        });
        $('.bottomPagerBlock a.first-page').click(function () {
            $('.bottomPagerBlock').addClass('0');
            $('.bottomPagerBlock a.num').removeClass('select');
            searchArticle(pageSize, 0);
            return false;
        });
        $('.bottomPagerBlock a.last-page').click(function () {
            $('.bottomPagerBlock a.num').removeClass('select');
            $('.bottomPagerBlock').removeClass('0').attr('id', $(this).attr('id'));
            searchArticle(pageSize, parseInt($(this).attr('id')) - 1);
            return false;
        });
    });
});
function searchArticle(pageSize, pageIndex) {
    $('#ArticleListing').empty();
    $('.bottomPagerBlock').empty();
    var img = "<div class='loading1'><img src='/Styles/img/tn_loading.gif' ></div>";
    $('#ArticleListing').html(img);
    $.ajax({
        type: "POST",
        url: '/WebService/Article/ArticleListing.ashx?pageSize=' + pageSize + '&pageIndex=' + pageIndex,
        success: function (mess) {
            $("#ArticleListing").empty();
            $(".bottomPagerBlock").empty();
            if (eval(mess) != '') {
                var result = eval(mess);
                var lenght = result.length - 1;
                var page = result[0].TotalPage;
                var count = result[0].Count;
                var _index = parseInt(result[0].PageIndex);
                var temp = "";
                var pager = "";
                if (page > 1) {
                    pager += "<span class='label-page'></span>";
                    if (_index >= 9 && _index <= (page - 5)) {
                        pager += "<a class='first-page' href='javascript:void(0);'><span>Đầu</span></a>";
                        pager += "<a id='" + _index + "' class='prev-page' title='Quay lại trang trước' href='javascript:void(0);'><span><</span></a>";
                        pager += "...";
                        for (var j = (_index - 5) ; j < (_index + 5) ; j++) {
                            if (j * pageSize < count) {
                                pager += "<a id='" + (j + 1) + "' class='num' href='javascript:void(0);'><span>" + (j + 1) + "</span></a>";
                            }
                        }
                        if (_index < page - 1) {
                            pager += "<a id='next-page' class='next-page' title='Sang trang tiếp theo' href='javascript:void(0);'><span>></span></a>";
                            pager += "<a id='" + page + "' class='last-page' href='javascript:void(0);'><span>Cuối</span></a>";
                        }
                    }
                    else if (_index < 9) {
                        if (_index > 0) {
                            pager += "<a class='first-page' href='javascript:void(0);'><span>Đầu</span></a>";
                            pager += "<a id='" + _index + "' class='prev-page' title='Quay lại trang trước' href='javascript:void(0);'><span><</span></a>";
                        }
                        for (var j = 0; j < 10; j++) {
                            if (j * pageSize < count) {
                                pager += "<a id='" + (j + 1) + "' class='num' href='javascript:void(0);'><span>" + (j + 1) + "</span></a>";
                            }
                        }
                        if (_index < page - 1) {
                            pager += "<a id='next-page' class='next-page' title='Sang trang tiếp theo' href='javascript:void(0);'><span>></span></a>";
                            pager += "<a id='" + page + "' class='last-page' href='javascript:void(0);'><span>Cuối</span></a>";
                        }
                    }
                    else if (_index > (page - 5)) {
                        pager += "<a class='first-page' href='javascript:void(0);'><span>Đầu</span></a>";
                        pager += "<a id='" + _index + "' title'Quay lại trang trước' class='prev-page' href='javascript:void(0);'><span><</span></a>";
                        pager += "...";
                        for (var j = (page - 9) ; j < page; j++) {
                            if (j * pageSize < count) {
                                pager += "<a id='" + (j + 1) + "' class='num' href='javascript:void(0);'><span>" + (j + 1) + "</span></a>";
                            }
                        }
                        if (_index < page - 1) {
                            pager += "<a id='next-page' class='next-page' title'Sang trang tiếp theo' href='javascript:void(0);'><span>></span></a>";
                            pager += "<a id='" + page + "' class='last-page' href='javascript:void(0);'><span>Cuối</span></a>";
                        }
                    }
                }
                for (var i = 0; i <= lenght; i++) {
                    temp += "<div class='item'>";
                    temp += "<div class='border_img'>";
                    temp += "<a class='aliimg' href='" + result[i].Url + "'>";
                    temp += "<img src='" + result[i].ImageUrl + "' />";
                    temp += "</a>";
                    temp += "</div>";
                    temp += "<div class='content'>";
                    temp += "<a href='" + result[i].Url + "' title='" + result[i].Title + "' class='title' target='" + result[i].Target + "'>";
                    temp += formatText(result[i].Title,70) + "  " + result[i].NewsIcon + "</a>";
                    temp += "<div class='Description'>";
                    temp += formatText(result[i].BriefDescription,240);
                    temp += "</div>";
                    temp += "<div class='viewDetail'>";
                    temp += "<a href='" + result[i].Url + "' target='" + result[i].Target + "'>Xem thêm</a>";
                    temp += "</div>";
                    temp += "</div>";
                    temp += "</div>";
                }
                $(".bottomPagerBlock").html(pager);
                $("#ArticleListing").html(temp);
            } else {
            }
        },
        error: function () {
        }
    });
};


function formatText(str, lenght) {
    if (str.length >= lenght) {
        return str.toString().substr(0, lenght) + ' ...';
    }
    return str;
}