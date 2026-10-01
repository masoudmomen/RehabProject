// "Use My Location" in the mega menu's United States tab.
//
//   <button data-locate-state="#id">   asks the browser for the visitor's position and
//                                      opens the page of the nearest state
//   #id [data-lat][data-lng] a[href]   state entries carrying their approximate centre
//   [data-locate-status]               optional element (next to the button) for messages
//
// Nearest-centre matching is approximate near state borders.
(function () {
    function setStatus(button, text) {
        var status = button.parentElement.querySelector('[data-locate-status]');
        if (!status) return;
        status.textContent = text;
        status.hidden = !text;
    }

    function distance(lat1, lng1, lat2, lng2) {
        // Equirectangular approximation - plenty for picking the closest centre.
        var x = (lng2 - lng1) * Math.cos(((lat1 + lat2) / 2) * Math.PI / 180);
        var y = lat2 - lat1;
        return x * x + y * y;
    }

    document.addEventListener('click', function (e) {
        var button = e.target.closest && e.target.closest('[data-locate-state]');
        if (!button) return;

        var container = document.querySelector(button.getAttribute('data-locate-state'));
        if (!container) return;

        if (!navigator.geolocation) {
            setStatus(button, 'Location is not available in this browser. Please pick your state below.');
            return;
        }

        button.disabled = true;
        setStatus(button, 'Finding your location...');

        navigator.geolocation.getCurrentPosition(function (pos) {
            var lat = pos.coords.latitude, lng = pos.coords.longitude;
            var best = null, bestDist = Infinity;

            container.querySelectorAll('[data-lat][data-lng]').forEach(function (item) {
                var d = distance(lat, lng, parseFloat(item.getAttribute('data-lat')), parseFloat(item.getAttribute('data-lng')));
                if (d < bestDist) { bestDist = d; best = item; }
            });

            button.disabled = false;
            var link = best && (best.matches('a[href]') ? best : best.querySelector('a[href]'));
            if (link) {
                setStatus(button, '');
                window.location.href = link.getAttribute('href');
            } else {
                setStatus(button, 'We couldn\'t match your location. Please pick your state below.');
            }
        }, function () {
            button.disabled = false;
            setStatus(button, 'We couldn\'t get your location. Please pick your state below.');
        }, { timeout: 10000, maximumAge: 600000 });
    });
})();
