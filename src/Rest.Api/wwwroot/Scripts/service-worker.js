'use strict';

var cacheVersion = 1;
var currentCache = {
    offline: 'offline-cache' + cacheVersion
};
const offlineUrl = '/offline';

this.addEventListener('install', event => {
    event.waitUntil(
      caches.open(currentCache.offline).then(function (cache) {
          return cache.addAll([
              './img/offline.svg',
              offlineUrl
          ]);
      })
    );
});