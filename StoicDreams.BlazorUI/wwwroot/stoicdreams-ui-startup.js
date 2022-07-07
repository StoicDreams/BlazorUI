(function AppStartup() {
	"use strict"
	function AddJSFile(filePath) {
		let element = document.createElement('script');
		element.setAttribute('src', filePath);
		element.setAttribute('type', 'text/javascript');
		document.body.appendChild(element);
	}

	AddJSFile('_framework/blazor.webassembly.js');
})();
