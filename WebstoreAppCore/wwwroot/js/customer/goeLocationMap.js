
window.addEventListener('load', function () {

            mymap = document.querySelector('.mymap');
            details = document.querySelector('.details');
            information  = document.querySelector('.info');
            latinput = document.querySelector('input[name=lat]');
            longinput = document.querySelector('input[name=long]');
            accinput = document.querySelector('input[name=accurecy]');
            timestampinput = document.querySelector('input[name=time]');

			getmylocationfun();

});

        function getmylocationfun()
        {
            details.style.display = 'none';
            mymap.style.display = 'block';

            if(navigator.geolocation)
            {

                navigator.geolocation.getCurrentPosition(getposition, errorhandeler);
            }
            else {
                mymap.innerText = "Update And Try Again !";
            }
        }
        function getposition(position) {
            lat = position.coords.latitude;
            lon = position.coords.longitude;
            acc = position.coords.accuracy;
            timestmp = position.timestamp;

            var mylocation = new google.maps.LatLng(lat, lon);


            var myspecs = { zoom: 16, center: mylocation };

            var myimg = new Image();

            myimg.src = new google.maps.Map(mymap, myspecs);
            var marker = new google.maps.Marker({
                position:mylocation
            })
            marker.setMap(new google.maps.Map(mymap, myspecs));
            mymap.appendChild(myimg);


        }

        function errorhandeler(error) {
            switch (error.code) {
                case error.PERMISSION_DENIED:
                    mymap.innerText = "Permission Denied";
                    break;
                case error.POSITION_UNAVAILABLE:
                    mymap.innerText = "POSITION_UNAVAILABLE";
                    break;
                case error.TIMEOUT:
                    mymap.innerText = "TIMEOUT";
                    break;
                case error.UNKOWN_ERROR:
                    mymap.innerText = "UNKOWN_ERROR";
                    break;
                default:

            }

        }

        function DetailsFunction(){
            details.style.display='block';
            latinput.value = lat;
            longinput.value = lon;
            accinput.value = acc;
            timestampinput.value = timestmp;
        }
