namespace StoicDreams.BlazorUI.Data;

public interface IJsInterop
{
	ValueTask CallMethod(string method, params object[] args);

	ValueTask<TResult?> CallMethod<TResult>(string method, params object[] args);

	ValueTask AddJSFile(string filePath);

	ValueTask AddCSSFile(string filePath);

	ValueTask AddElementToHead(string tag, IDictionary<string, string> attributes);

	ValueTask AddElementToBody(string tag, IDictionary<string, string> attributes);
	
	ValueTask UpdateTitle(string title);
}
