(function AppStartup() {
	"use strict"
	function AddJSFile(filePath) {
		let element = document.createElement('script');
		element.setAttribute('src', filePath);
		element.setAttribute('type', 'text/javascript');
		document.body.appendChild(element);
	}

	AddJSFile('_framework/blazor.webassembly.js');
	AddJSFile('_content/MudBlazor/MudBlazor.min.js');
	AddJSFile('js/mermaid.js');
	AddJSFile('js/prism.js');
	function InitializeMermaid() {
		mermaid.initialize({
			'securityLevel': 'loose',
			'theme': 'base',
			'themeVariables': {
				'darkMode': true,
				'background': '#2626A8',
				'primaryColor': '#1f910d'
			}
		});
		(function WatchForMermaidUpdates() {
			'use strict';
			document.querySelectorAll('.mermaid:not([data-processed])').forEach(e => {
				mermaid.init({ 'theme': 'base', 'themeVariables': { 'darkMode': true } }, e);
			});
			setTimeout(WatchForMermaidUpdates, 1000);
		})();
		(function WatchForPrismUpdates() {
			'use strict';
			document.querySelectorAll('pre:not([class*=language]) > code[class*=language]').forEach(e => {
				e.parentElement.setAttribute('languagetag', e.className.split('-').pop());
				Prism.highlightElement(e);
			});
			setTimeout(WatchForPrismUpdates, 1000);
		})();
	}
	(function startAfterLoaded() {
		if (!window.mermaid) {
			setTimeout(startAfterLoaded, 100);
			return;
		}
		InitializeMermaid();
	})();
	function ApplyWindowDimensionInformation() {
		let main = document.querySelector('main');
		if (!main) {
			setTimeout(ApplyWindowDimensionInformation, 100);
			return;
		}
		DotNet.invokeMethodAsync('StoicDreams.BlazorUI', 'UpdateWindowDimensions', { WindowHeight: document.body.clientHeight, WindowWidth: document.body.clientWidth, MainHeight: main.clientHeight, MainWidth: main.clientWidth });
	}
	window.onresize = ApplyWindowDimensionInformation;
	window.addEventListener('resize', ApplyWindowDimensionInformation);
})();
