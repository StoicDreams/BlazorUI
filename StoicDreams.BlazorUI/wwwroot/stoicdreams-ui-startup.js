(function AppStartup() {
	"use strict"
	function AddJSFile(filePath) {
		let element = document.createElement('script');
		element.setAttribute('src', filePath);
		document.body.appendChild(element);
	}

	AddJSFile('_framework/blazor.webassembly.js');
})();
