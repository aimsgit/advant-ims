<%@ Page Language="VB" AutoEventWireup="false" CodeFile="googlemap.aspx.vb" Inherits="googlemap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html >
<META HTTP-EQUIV="refresh" CONTENT="25"/>
<head runat="server">
<title>Google Map</title>
<style type="text/css">
html { height: 100% }
body { height: 100%; margin: 0; padding: 0 }
#map_canvas { height: 100% }
</style>
<script type="text/javascript" src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyBwvdduC9q6bXL3ctfHtilg13z_-9n1WYo&sensor=true">
</script>
<script type="text/javascript">
function initialize() {
var markers = JSON.parse('<%=ConvertDataTabletoString() %>');
var mapOptions = {
center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
zoom: 15,
mapTypeId: google.maps.MapTypeId.ROADMAP
//  marker:true
};
var infoWindow = new google.maps.InfoWindow();
var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
for (i = 0; i < markers.length; i++) {
var data = markers[i]
var myLatlng = new google.maps.LatLng(data.lat, data.lng);
var marker = new google.maps.Marker({
position: myLatlng,
map: map,
title: data.title
});
(function(marker, data) {

// Attaching a click event to the current marker
google.maps.event.addListener(marker, "click", function(e) {
infoWindow.setContent(data.description);
infoWindow.open(map, marker);
});
})(marker, data);
}
}
</script>
</head>
<body onload="initialize()">
<center>
<form id="form1" runat="server">
<div id="map_canvas" style="width: 850px; height: 650px"></div>
</form>
</center>
</body>
</html>
