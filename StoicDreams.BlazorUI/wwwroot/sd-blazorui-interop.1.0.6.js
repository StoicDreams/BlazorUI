// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function CallMethod(method, args) {
	try {
		let instance = window;
		let last = window;
		method.split('.').forEach(s => {
			last = instance;
			instance = instance[s]
		});
		if (last != instance) {
			return instance.bind(last)(...args);
		}
		return instance(...args);
	} catch (ex) {
		console.error(`Failed calling ${method}`, ex, ...args);
	}
	return null;
}

export function RunInlineScript(script) {
	return eval(script);
}

export function AddJSFile(filePath) {
	AddElement('script', { src: filePath, type: 'text/javascript' }, document.body);
}

export function RemoveJSFile(filePath) {
	document.querySelectorAll(`script[src="${filePath}"`).forEach(element => element.remove());
}

export function RemoveSelector(selector) {
	document.querySelectorAll(selector).forEach(element => element.remove());
}

export function AddCSSFile(filePath) {
	AddElement('link', { rel: 'stylesheet', href: filePath }, document.body);
}

export function AddElementToHead(tag, attributes) {
	AddElement(tag, attributes, document.head);
}

export function AddElementToBody(tag, attributes) {
	AddElement(tag, attributes, document.body);
}

export function UpdateTitle(title) {
	document.title = title;
}

function AddElement(tag, attributes, parent) {
	let element = document.createElement(tag);
	Object.keys(attributes).forEach(key => {
		if (key == 'body') {
			element.body = attributes[key];
			return;
		}
		element.setAttribute(key, attributes[key]);
	});
	parent.appendChild(element);
}
