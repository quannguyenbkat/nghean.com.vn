$(document).ready(function () {
    $('#txtUsername').blur(function () {
        CheckUser(this);
    });
    $('#txtEmail').blur(function () {
        CheckEmail(this);
    });

    $('#txtEmailConfirm').blur(function () {
        CheckEmailConfirm(this);
    });

    $('#txtPassword1').blur(function () {
        CheckPassword(this);
    });

    $('#txtPasswordConfirm').blur(function () {
        CheckPasswordConfirm(this);
    });

    $('#txtCity').blur(function () {
        CheckCity(this);
    });

    $('#txtPhone').blur(function () {
        CheckPhone(this);
    });

    $(".btnRegister").attr("disabled", "disabled");
    $(".lblCaptcha").hide();
    if ($(".txtCaptcha").val() == "")
        $(".lblCaptcha").show();
    $(".txtCaptcha").focus(function () {
        $(".lblCaptcha").hide();
    });
    $(".txtCaptcha").blur(function () {
        if ($(".txtCaptcha").val() == "")
            $(".lblCaptcha").show();
    });
    $("input#chkTermAgree").removeAttr("checked");
    $("input#chkTermAgree").change(function () {
        if ($("input#chkTermAgree").is(":checked"))
            $(".btnRegister").removeAttr("disabled");
        else
            $(".btnRegister").attr("disabled", "disabled");
    });
    $(".registerBlock .row .chk").live("click", function () {
        $(".registerBlock .row .chk.selected").removeClass("selected");
        $(this).addClass("selected");
        if ($(this).hasClass("isMale"))
            $("#chkSex").attr("checked", "checked");
        else $("#chkSex").removeAttr("checked");
    });

});

//-------------- Check username valid format and existance --------------
function CheckUser(txt) {
    var value = $(txt).val();
    $('#err_exist_username').hide();
    $('#err_format_username').hide();
    $('#succ_username').hide();
    if (isUserName(value)) {
        $.ajax({
            type: "POST",
            data: "{username: '" + value + "' }",
            contentType: "application/json; charset=utf-8",
            url: getBaseURL() + "WebService/Register.asmx/user_validation",
            dataType: "json",
            success: function (data) {
                if (data.d == 0) {
                    $('#err_exist_username').hide();
                    $('#err_format_username').hide();
                    $('#succ_username').show();
                } else {
                    $('#err_exist_username').show();
                    $('#err_format_username').hide();
                    $('#succ_username').hide();
                }
            }
        })
    } else {
        $('#err_exist_username').hide();
        $('#err_format_username').show();
        $('#succ_username').hide();
    }
}

//-------------- Check email valid format and existance --------------
function CheckEmail(txt) {
    var value = $(txt).val();
    $('#err_exist_email').hide();
    $('#err_format_email').hide();
    $('#succ_email').hide();
    if (validateEmail(value)) {
        $.ajax({
            type: "POST",
            data: "{email: '" + value + "' }",
            contentType: "application/json; charset=utf-8",
            url: getBaseURL() + "WebService/Register.asmx/email_validation",
            dataType: "json",
            success: function (data) {
                if (data.d == 1) {
                    $('#err_format_email').hide();
                    $('#err_exist_email').show();
                    $('#succ_email').hide();
                } else {
                    $('#err_format_email').hide();
                    $('#err_exist_email').hide();
                    $('#succ_email').show();
                }
            }
        })
    } else {
        $('#err_format_email').show();
        $('#err_exist_email').hide();
        $('#succ_email').hide();
    }
}

function validateEmail(elementValue) {
    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    return emailPattern.test(elementValue);
}
function getBaseURL() {
    var url = window.location.href;  
    var baseUrl = url.substring(0, url.indexOf('/', 14));
    var host = window.location.host;
    var indexadmin = window.location.pathname.split("/");
    if (baseUrl.indexOf('http://'+host) != -1 && indexadmin[2] =="admin") {
        var pathname = location.pathname;  
        var index1 = url.indexOf(pathname);
        var index2 = url.indexOf("/", index1 + 1);
        var baseLocalUrl = url.substr(0, index2);
        return baseLocalUrl + "/";
    }
    else {
        return baseUrl + "/";
    }
}
//-------------- Check password length --------------
function CheckPassword(txt) {
    var value = $(txt).val();
    $('#err_too_short_pass').hide();
    $('#succ_pass').hide();
    $.ajax({
        type: "POST",
        data: "{pass: '" + value + "' }",
        contentType: "application/json; charset=utf-8",
        url: getBaseURL() + "WebService/Register.asmx/pass_validation",
        dataType: "json",
        success: function (data) {
            if (data.d == 0) {
                $('#err_too_short_pass').hide();
                $('#succ_pass').show();
            } else {
                $('#err_too_short_pass').show();
                $('#succ_pass').hide();
            }
        }
    })
}

//-------------- Check email confirmation --------------
function CheckEmailConfirm(txt) {
    var value = $(txt).val();
    var compareValue = $('#txtEmail').val();
    $('#err_not_match_email').hide();
    $('#succ_email_confirm').hide();
    if (compareValue != '') {
        if (value != compareValue) {
            $('#err_not_match_email').show();
            $('#succ_email_confirm').hide();
        } else {
            $('#err_not_match_email').hide();
            $('#succ_email_confirm').show();
        }
    }
}

//-------------- Check password confirmation --------------
function CheckPasswordConfirm(txt) {
    var value = $(txt).val();
    var compareValue = $('#txtPassword1').val();
    $('#err_not_match_pass').hide();
    $('#succ_pass_confirm').hide();
    if (compareValue != '') {
        if (value != compareValue) {
            $('#err_not_match_pass').show();
            $('#succ_pass_confirm').hide();
        } else {
            $('#err_not_match_pass').hide();
            $('#succ_pass_confirm').show();
        }
    }
}

//-------------- Check city info empty or not --------------
function CheckCity(txt) {
    var value = $(txt).val();
    $('#err_city').hide();
    if (value != '') {
        $('#err_city').hide();
    } else {
        $('#err_city').show();
    }
}

//-------------- Check phone info empty or not --------------
function CheckPhone(txt) {
    var value = $(txt).val();
    $('#err_phone').hide();
    if (value != '') {
        $('#err_phone').hide();
    } else {
        $('#err_phone').show();
    }
}