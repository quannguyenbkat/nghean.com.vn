﻿$(document).ready(function() {var a = $("#Addon");var b = $("#mediaspace");var videoheight = a.attr("width") * 3 / 4 + 25;if (a.width() > 0) {a.fadeIn();} else a.remove();var vifi = b.attr("url");var timeflash = '0';$("#Addon .textscr *").live("click", function() {if (vifi.match(".swf")) {var time = setTimeout(function() { $("#Addon").animate({ height: 30 }, timeflash, function() {$("#Addon .textscr").css("margin-left", "10px");$("#Addon .control").hide();$("#Addon .minimize").addClass("maximum").attr("title", "Phóng to cửa sổ");clearTimeout(time);}); }, timeflash);}if ($("#Addon .minimize").hasClass("maximum")) {$("#Addon").css({ 'height': videoheight });$("#Addon .control").show();$("#Addon .minimize").removeClass("maximum");$("#Addon .textscr").css("margin-left", "60px");}});$("#Addon .textscr,#Addon .pause").live("click", function() { jwplayer("mediaspace").play(); });$("#Addon .over").live("click", function() { $("#Addon .minimize").click(); });$("#Addon .minimize").live("click", function() {if (vifi.match(".swf")) {var time = setTimeout(function() { $("#Addon").animate({ height: 30 }, timeflash, function() {$("#Addon .textscr").css("margin-left", "10px");$("#Addon .control").hide();$("#Addon .minimize").addClass("maximum").attr("title", "Phóng to cửa sổ");clearTimeout(time);}); }, timeflash);}if (!$(this).hasClass("maximum")) {$("#Addon").css({ "height": 30 });$("#Addon .control").hide();$("#Addon .textscr").css("margin-left", "10px");$(this).addClass("maximum").attr("title", "Phóng to cửa sổ");$("#Addon .pause").removeClass("play");jwplayer("mediaspace").stop();Cookie_ChangeIndex('cnv', Cookie_IndexOf('vid', vifi.ToBase64()), 'm0');$('.toTop').stop().animate({ bottom: '40' });} else {$("#Addon").css({ "height": videoheight });$("#Addon .control").show();$("#Addon .textscr").css("margin-left", "60px");$(this).removeClass("maximum").attr("title", "Thu nhỏ cửa sổ");jwplayer("mediaspace").play();$('.toTop').stop().animate({ bottom: '265' });}});$("#Addon .close").live("click", function() { $("#Addon").stop().animate({ height: 0 }, function() {$("#Addon").remove();Cookie_ChangeIndex('cnv', Cookie_IndexOf('vid', vifi.ToBase64()), 'c0');$('.toTop').stop().animate({ bottom: '10' });}); });$("#Addon .pause").live("click", function() { if ($(this).hasClass("play")) {$(this).removeClass("play").attr("title", "Tạm dừng");} else {$(this).addClass("play").attr("title", "Tiếp tục");} });$("#Addon .sound").live("click", function() {jwplayer("mediaspace").setMute();if ($(this).hasClass("mute")) {$(this).removeClass("mute").attr("title", "Tắt tiếng");Cookie_ChangeIndex('vnc', Cookie_IndexOf('vid', vifi.ToBase64()), 'nothing');} else {$(this).addClass("mute").attr("title", "Bật tiếng");Cookie_ChangeIndex('vnc', Cookie_IndexOf('vid', vifi.ToBase64()), 'v0');}});if (videoheight != 0) {GetAdv(b.attr("url"), b.attr('type'), b.attr('title'), b.attr('link'), b.attr('target'), timeflash);} else {$("#Addon").remove();}});

function embed_Video(File) { jwplayer("mediaspace").setup({'file': File,'flashplayer': ResolveUrl('~/Scripts/jwplayer/player.swf'),'controlbar': 'none','autostart': 'false','repeat': 'none','stretching': 'exactfit','icons': 'false','volume': 60,'height': 225,'width': 300,'mute': false,events: {onComplete: function() {$("#Addon").animate({ height: 30 });$("#Addon .control").hide();$("#Addon .textscr").css("margin-left", "10px");$("#Addon .minimize").addClass("maximum").attr("title", "Phóng to cửa sổ");$("#Addon .pause").removeClass("play");}}}); }
function embedFlash(File) { $("#mediaspace").html("<embed src='" + File + "' width='300' height='225' type='application/x-shockwave-flash' />"); }
function GetAdv(File, Type, Title, Link, Target, _timeflash) {if (!Cookie_HasCookie('vid', File.ToBase64())) {Cookie_Add('vid', File.ToBase64());Cookie_Add('vnc', 'nothing');Cookie_Add('cnv', 'nothing');}var Index = Cookie_IndexOf('vid', File.ToBase64());var vnc = Cookie_ValueOf('vnc', Index);var cnv = Cookie_ValueOf('cnv', Index);if (cnv != undefined && cnv == 'c0') {$('#Addon').remove();$('.toTop').css("bottom", "10px");return;}if (cnv != undefined && cnv == 'm0') {$("#Addon").height(30);$("#Addon .textscr").css("margin-left", "10px");$("#Addon .control").hide();$("#Addon .minimize").addClass("maximum").attr("title", "Phóng to cửa sổ");$('.toTop').css("bottom", "40px");} else {$("#Addon").height(255);$("#Addon .control").show();$('.toTop').css("bottom", "265px");$("#Addon .textscr").css("margin-left", "60px");}if (Link != "") $('#Addon .flash-video .over').attr({ "href": Link, "target": Target });$("<span />").html(Title).appendTo($(".textscr .marquee"));$(".textscr .marquee").Marquee({ scrollspeed: 3, offset: 80 });var ext = ".mp4|.flv|.wmv|.avi";var match = "youtube";if ((ext.match(Type) != '' && ext.match(Type) != null) || (File.match(match) != '' && File.match(match) != null)) {embed_Video(File);$("#Addon .hide").removeClass("hide");if (vnc != undefined && vnc == "v0") {jwplayer("mediaspace").setMute();$("#Addon .sound").addClass("mute").attr("title", "Bật tiếng");}if (cnv != undefined && cnv == 'm0') {return;}jwplayer("mediaspace").play();Cookie_ChangeIndex('cnv', Index, 'm0');} else {embedFlash(File);$("#Addon .hide").removeClass("hide");if (cnv != undefined && cnv == 'm0') {return;}Cookie_ChangeIndex('cnv', Index, 'm0');var time = setTimeout(function() { $("#Addon").animate({ height: 30 }, _timeflash, function() {$("#Addon .textscr").css("margin-left", "10px");$("#Addon .control").hide();$("#Addon .minimize").addClass("maximum").attr("title", "Phóng to cửa sổ");clearTimeout(time);}); }, _timeflash);}}

(function($) {$.fn.Marquee = function(options) {options = $.extend({ }, $.MarqueeDefault, options);var div = $(this);var span = $(this).children("span");span.clone().appendTo(div);span = $(this).children("span");
function scroll(a) {var obj = span.eq(a);var obj2 = obj.index() == span.length - 1 ? span.eq(a + 1) : span.eq(0);var offsetFloat = obj.width() - div.width();var duration = obj.width() * 100 / options.scrollspeed;if (offsetFloat > 0) {obj.stop().animate({ marginLeft: -obj.width() - options.offset }, duration, 'linear', function() {obj.appendTo(div).removeAttr("style");scroll(obj2.index());});}}
    scroll(0);};$.MarqueeDefault = { scrollspeed: 1, offset: 10 };})(jQuery);