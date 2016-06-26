'use strict';

var cacheVersion = 1;
var currentCache = {
    offline: 'offline-cache' + cacheVersion
};
const offlineUrl = '/offline';

this.addEventListener('install', event => {
    event.waitUntil(
      caches.open(currentCache.offline).then(function (cache) {
          console.log("adding: " + offlineUrl + " to the cache");
          return cache.addAll([
              offlineUrl
          ]);
      })
    );
});

this.addEventListener('fetch', event => {
    // request.mode = navigate isn't supported in all browsers
    // so include a check for Accept: text/html header.
    if (event.request.mode === 'navigate' || (event.request.method === 'GET' && event.request.headers.get('accept').includes('text/html'))) {
        console.log("we're offline, to the cache!");
        event.respondWith(
          fetch(event.request.url).catch(error => {
              // Return the offline page
              return caches.match(offlineUrl);
          })
    );
    }
    else {
        console.log("we're online, so serve the page");
        // Respond with everything else if we can
        event.respondWith(caches.match(event.request)
                        .then(function (response) {
                            return response || fetch(event.request);
                        })
            );
    }
});