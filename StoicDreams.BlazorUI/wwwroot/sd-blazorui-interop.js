// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}

export function AddJSFile(filePath) {
	AddElement('script', {}, document.body);
}

export function AddCSSFile(filePath) {
	AddElement('link', { rel: 'stylesheet', href: filePath }, document.head);
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
