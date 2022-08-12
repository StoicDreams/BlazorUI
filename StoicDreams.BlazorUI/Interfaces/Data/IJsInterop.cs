namespace StoicDreams.BlazorUI.Data;

public interface IJsInterop
{
	/// <summary>
	/// Call a global javascript method.
	/// Use RunInlineScript if needing to run an adhoc javascript script.
	/// </summary>
	/// <param name="method"></param>
	/// <param name="args"></param>
	/// <returns></returns>
	ValueTask CallMethod(string method, params object[] args);

	/// <summary>
	/// Call a global javascript method and return the result.
	/// Use RunInlineScript if needing to run an adhoc javascript script.
	/// </summary>
	/// <param name="method"></param>
	/// <param name="args"></param>
	/// <returns></returns>
	ValueTask<TResult?> CallMethod<TResult>(string method, params object[] args);

	/// <summary>
	/// Run an inline javascript command.
	/// Use CallMethod if you need to run a global method with parameters.
	/// </summary>
	/// <param name="script"></param>
	/// <returns></returns>
	ValueTask RunInlineScript(string script);

	/// <summary>
	/// Run an inline javascript command and return its result.
	/// Use CallMethod if you need to run a global method with parameters.
	/// </summary>
	/// <param name="script"></param>
	/// <returns></returns>
	ValueTask<TResult?> RunInlineScript<TResult>(string script);

	/// <summary>
	/// Add a script tag with filePath as the path
	/// </summary>
	/// <param name="filePath"></param>
	/// <returns></returns>
	ValueTask AddJSFile(string filePath);

	/// <summary>
	/// Remove a script element by path
	/// </summary>
	/// <param name="filePath"></param>
	/// <returns></returns>
	ValueTask RemoveJSFile(string filePath);

	ValueTask AddCSSFile(string filePath);

	ValueTask AddElementToHead(string tag, IDictionary<string, string> attributes);

	ValueTask AddElementToBody(string tag, IDictionary<string, string> attributes);
	
	ValueTask UpdateTitle(string title);
}
