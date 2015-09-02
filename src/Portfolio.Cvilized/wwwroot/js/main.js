
(function($) {

	$(document).ready( function() {

		/*-----------------------------------/
		/* NAVIGATION
		/*----------------------------------*/
		
		// init scroll-to effect navigation, adjust the scroll speed in milliseconds
		$('#main-nav').localScroll(1000);
		$('#header').localScroll(1000);


		/*-----------------------------------/
		/* SKILLS
		/*----------------------------------*/

		var chart = $('.pie-chart');

		if($('.pie-chart').length > 0) {
			chart.easyPieChart({
				size: 180,
				barColor: '#cf5037',
				trackColor: '#545454',
				scaleColor: false,
				lineWidth: 3,
				lineCap: "square",
				animate: 2000
			});
		}


		/*-----------------------------------/
		/* GOOGLE MAPS
		/*----------------------------------*/

		if( $('.map-canvas').length > 0) {
			
			var geocoder = new google.maps.Geocoder();
			var address = 'Irvine, CA, USA';
			var contentString = '<div class="map-detail"><strong>Currently Located:</strong><p>' + address + '</p></div>';
			var mapOptions = {
			    draggable: false,
			    scrollwheel: false,
			    disableDoubleClickZoom: true,
			    zoomControl: false
			};
			geocoder.geocode({'address': address }, function(results, status) {
				if(status == google.maps.GeocoderStatus.OK) { 
					var latitude = results[0].geometry.location.lat();
					var longitude = results[0].geometry.location.lng();

					jQuery('.map-canvas').gmap().bind('init', function(ev, map) {
						jQuery('.map-canvas').gmap('addMarker', {'position': latitude+','+longitude, 'bounds': true}).click(function() {
							jQuery('.map-canvas').gmap('openInfoWindow', {'content': contentString}, this);
						});
						jQuery('.map-canvas').gmap('option', 'zoom', 8);
						//jQuery('.map-canvas').gmap('option', 'zoom', 8);
						map.setOptions(mapOptions);
					});
				}else { alert('Google Maps had some trouble finding the address. Status: ' + status); }
			});
		}
	});

})(jQuery);