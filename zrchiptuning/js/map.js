﻿      function initialize() {
          var mapCanvas = document.getElementById('map');
          var mapOptions = {
              center: new google.maps.LatLng(45.3985108, 20.4070781),
              zoom: 15,
              mapTypeId: google.maps.MapTypeId.ROADMAP
          }
          var map = new google.maps.Map(mapCanvas, mapOptions)
          var place = new google.maps.Marker({
              position: new google.maps.LatLng(45.398899, 20.410361),
              map: map
          })
      }
google.maps.event.addDomListener(window, 'load', initialize);