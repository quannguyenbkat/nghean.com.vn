<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GoogleMaps.ascx.cs" Inherits="Controls_GoogleMap_GoogleMaps" %>

<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&language=vi">
</script>
<script type="text/javascript">
    window.onload = function () {
        var title = $("#hdTitle").val() != "" ? $.trim($("#hdTitle").val()) : "";
        var lat = $("#hdLat").val() != "" ? $.trim($("#hdLat").val()) : "";
        var lng = $("#hdLog").val() != "" ? $.trim($("#hdLog").val()) : "";
        var description = $("#hdDescription").val() != "" ? $.trim($("#hdDescription").val()) : "";
        var zoom = $("#hdZoom").val() != "" ? $.trim($("#hdZoom").val()) : "12";
        var mapOptions = {
            center: new google.maps.LatLng(lat, lng),
            zoom: parseInt(zoom),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById("dvMap1"), mapOptions);

        var myLatlng = new google.maps.LatLng(lat, lng);
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: title,
            icon: "/favicon_32x32.ico"
        });
        (function (marker) {
            google.maps.event.addListener(marker, "click", function (e) {
                infoWindow.setContent(description);
                infoWindow.open(map, marker);
            });
        })
        (marker);
    };
</script>
<div id="dvMap1" style="width: 770px; height: 530px; margin-top: 20px">
</div>
<asp:HiddenField ID="hdLat" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdLog" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdTitle" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdDescription" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdZoom" runat="server" ClientIDMode="Static" />
