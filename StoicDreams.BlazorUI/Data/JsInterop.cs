namespace StoicDreams.BlazorUI;

public class JsInterop : IJsInterop, IAsyncDisposable
{
	public JsInterop(IJSRuntime jsRuntime)
	{
		InteropModule = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
			"import", "./stoicdreams-ui-interop.js").AsTask());
	}

	public async ValueTask AddJSFile(string filePath)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("AddJSFile", filePath);
	}

	public async ValueTask AddCSSFile(string filePath)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("AddCSSFile", filePath);
	}

	public async ValueTask AddElementToHead(string tag, IDictionary<string, string> attributes)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("AddElementToHead", tag, attributes);
	}

	public async ValueTask AddElementToBody(string tag, IDictionary<string, string> attributes)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("AddElementToBody", tag, attributes);
	}

	private Lazy<Task<IJSObjectReference>> InteropModule { get; }


	public async ValueTask<string> Prompt(string message)
	{
		IJSObjectReference module = await InteropModule.Value;
		return await module.InvokeAsync<string>("showPrompt", message);
	}

	public async ValueTask DisposeAsync()
	{
		if (InteropModule.IsValueCreated)
		{
			var module = await InteropModule.Value;
			await module.DisposeAsync();
		}
	}
}