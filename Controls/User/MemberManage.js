


function loadLoginBox() {	// To Load the Popupbox

    var w = document.body.clientWidth;
    var l = (w - 400) / 2;

    $("#login-form").css({ // this is just for style
        left: l
    });
    $('#login-form').fadeIn("slow");
    /*$("#wrapper").css({ // this is just for style
    "opacity": "0.3"
    });*/
    //$('.background-opacity').css('display', 'block');
}
function loadRegisBox() {	// To Load the Popupbox
    var w = document.body.clientWidth;
    var l = (w - 500) / 2;

    $("#regis-form").css({ // this is just for style
        left: l
    });
    $('#regis-form').fadeIn("slow");

}

function checkRegexp(o, regexp, n) {
    if (!(regexp.test(o))) {
        //o.addClass("ui-state-error");
        //updateTips(n);
        return false;
    } else {
        return true;
    }
}
//không cho gõ ký tự
function keypress(e) {
    var keypressed = null;
    if (window.event) {
        keypressed = window.event.keyCode; //IE
    }
    else {

        keypressed = e.which; //NON-IE, Standard
    }
    if (keypressed < 48 || keypressed > 57) {
        if (keypressed == 8 || keypressed == 127) {
            return;
        }
        return false;
    }
}
//không cho gõ phím cách
function SpacePress(e) {
    var keypressed = null;
    if (window.event) {
        keypressed = window.event.keyCode; //IE
    }
    else {

        keypressed = e.which; //NON-IE, Standard
    }
    if (keypressed < 48 || keypressed > 57) {
        if (keypressed == 32) {
            return false;
        }
        return true;
    }

}
/*$(document).keydown(function (e) {
alert(e.which);
});*/
function checkRegexp(value, regexp) {
    if (!(regexp.test(value))) {
        //updateTips(n
        return false;
    } else {
        return true;
    }
}

function locdau(str) {
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    //str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-");
    /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
    //str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1- 
    //str = str.replace(/^\-+|\-+$/g, "");
    //cắt bỏ ký tự - ở đầu và cuối chuỗi  
    return str;
}
function pageLoad() {
    /*/ $('#go_top').click(function (event) {
    $('body,html').animate({ scrollTop: 0 }, 400);
    event.preventDefault();
    });*/
    var w = document.body.clientWidth;
    var l = (w - 400) / 2;

    window.onresize = function (event) {
        $(".background-opacity").width("100%");
        $(".background-opacity").height("100%");
        //$(".background-opacity").height($("#wrapper").height());
    }

    $(".background-opacity").width("100%");
    //$(".background-opacity").height($("#wrapper").height());
    $(".background-opacity").height("100%");

    $("#login-form").css({ // this is just for style
        left: l
    });

    var l2 = (w - 435) / 2;

    $("#forgotpass-form").css({ // this is just for style
        left: l2
    });

    var l3 = (w - 500) / 2;

    $("#regis-form").css({ // this is just for style
        left: l3
    });

}
function unloadRegisBox() {	// TO Unload the Popupbox
    $('#regis-form').fadeOut("slow");

}
function unloadPopupBox() {	// TO Unload the Popupbox
    //$('#login-form').fadeOut("slow");
}
