self.addEventListener('install', event => event.waitUntil(onInstall(event)));
self.addEventListener('activate', event => event.waitUntil(onActivate(event)));
self.addEventListener('fetch', event => event.respondWith(onFetch(event)));
function get_uuid() {
	try {
		return crypto.randomUUID();
	} catch (ex) {
		return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
			let r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
			return v.toString(16);
		});
	}
}
const currentVersion = location.host.substring(0, 9) === 'localhost' ? `${get_uuid()}` : 'webui_0.6.38';
const cacheNamePrefix = 'offline-cache-';
const cacheName = `${cacheNamePrefix}${currentVersion}`;
const offlineAssetsInclude = [/\.wasm/, /\.html/, /\.js$/, /\.json$/, /\.css$/, /\.woff$/, /\.png$/, /\.jpe?g$/, /\.gif$/, /\.ico$/];
const offlineAssetsExclude = [/^service-worker\.js$/];

async function onInstall(event) {
	console.info(`Service worker: Install ${cacheName}`);
	self.skipWaiting();
}

async function onActivate(event) {
	console.info(`Service worker: Activate ${cacheName}`);

	// Delete unused caches
	const cacheKeys = await caches.keys();
	await Promise.all(cacheKeys
		.filter(key => key.startsWith(cacheNamePrefix) && key !== cacheName)
		.map(key => caches.delete(key)));
}

async function onFetch(event) {
	let cachedResponse = null;
	if (allowCache(event.request)) {
		const cache = await caches.open(cacheName);
		cachedResponse = await cache.match(event.request);
	}

	return cachedResponse || fetch(event.request);
}

function allowCache(request) {
	// Only allow caching for GET requests
	if (request.method !== 'GET') { return false; }
	// Exclude caching for navigation requests to ensure the latest site updates are loaded asap
	if (request.mode === 'navigate') { return false; }
	// All other GET requests allow navigation
	return true;
}
