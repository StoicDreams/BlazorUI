namespace StoicDreams.BlazorUI.Data;

public interface IJsInterop
{
	ValueTask AddJSFile(string filePath);

	ValueTask AddCSSFile(string filePath);

	ValueTask AddElementToHead(string tag, IDictionary<string, string> attributes);

	ValueTask AddElementToBody(string tag, IDictionary<string, string> attributes);
}
