function Cookie_Add(Name, Value) {
    $.jcookie.settings = {
        path: "/",
        domain: "baonga.com"
    };
    var cookie = $.jcookie(Name);
    if (cookie == undefined || cookie == null) {
        cookie = "";
        $.jcookie(Name, "nothing");
    }
    var cookies = cookie.split("||");

    if (cookies.indexOf(Value) == -1) {
        cookie += "||" + Value;
    }
    $.jcookie(Name, cookie);

}
function Cookie_Remove(Name, Value) {
    var cookie = $.jcookie(Name);
    if (cookie == undefined || cookie == null) {
        return;
    }
    var cookies = cookie.split("||");
    var strbld = '';
    for (var i = 0; i < cookies.length; i++) {
        if (cookies[i] != Value && cookies[i] != '') {
            strbld += "||" + cookies[i];
        }
    }
    $.jcookie(Name, strbld);
}
function Cookie_RemoveIndex(Name, Index) {
    var cookie = $.jcookie(Name);
    if (cookie == undefined || cookie == null) {
        return;
    }
    var cookies = cookie.split("||");
    var strbld = '';
    for (var i = 0; i < cookies.length; i++) {
        if (i == Index || cookies[i] == ''){ i++ };
        strbld += "||" + cookies[i];
    }
    $.jcookie(Name, strbld);
}

function Cookie_GetValue(Name, Name2, Value) {
    var cookie = $.jcookie(Name);
    var cookie2 = $.jcookie(Name2);
    if (cookie == undefined || cookie == null || cookie2 == undefined || cookie2 == null) {
        $.jcookie(Name, null); $.jcookie(Name2, null); return null;
    }
    else {
        var cookies = cookie.split('||');
        var cookies2 = cookie2.split('||');
        return cookies2[cookies.indexOf(Value)];
    }
}
function Cookie_IndexOf(Name, Value) {
    var cookie = $.jcookie(Name);
    if (cookie == undefined || cookie == null) {
        return -1;
    }
    var cookies = cookie.split("||");
    return cookies.indexOf(Value);
}
function Cookie_ValueOf(Name, Index) {
    var cookie = $.jcookie(Name);
    if (Index == -1 || cookie == undefined || cookie == null) {
        return null;
    }
    var cookies = cookie.split("||");
    return cookies[Index];
}
function Cookie_ChangeValue(Name, oldValue, newValue) {
    var cookie = $.jcookie(Name);
    if (cookie == undefined || cookie == null) {
        return;
    }
    var cookies = cookie.split("||");
    cookies[cookies.indexOf(oldValue)] = newValue;
    var strbld = '';
    for (var i = 0; i < cookies.length; i++) {
        if (cookies[i] != '') {
            strbld += "||" + cookies[i];
        }
    }
    $.jcookie(Name, strbld);
}
function Cookie_ChangeIndex(Name, Index, newValue) {
    var cookie = $.jcookie(Name);
    if (cookie == undefined || cookie == null) {
        return;
    }
    var cookies = cookie.split("||");
    cookies[Index] = newValue;
    var strbld = '';
    for (var i = 0; i < cookies.length; i++) {
        if (cookies[i] != '') { strbld += "||" + cookies[i]; }
    }
    $.jcookie(Name, strbld);
}
function Cookie_HasCookie(Name, Value) {
    return (Cookie_IndexOf(Name, Value) >= 0);
}