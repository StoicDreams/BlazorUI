namespace StoicDreams.BlazorUI;
using Microsoft.JSInterop.Infrastructure;

public class JsInterop : IJsInterop, IAsyncDisposable
{
	public JsInterop(IJSRuntime jsRuntime)
	{
		InteropModule = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
			"import", "./sd-blazorui-interop.1.0.0.js").AsTask());
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
	public async ValueTask UpdateTitle(string title)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("UpdateTitle", title);
	}

	private Lazy<Task<IJSObjectReference>> InteropModule { get; }


	public async ValueTask DisposeAsync()
	{
		if (InteropModule.IsValueCreated)
		{
			IJSObjectReference module = await InteropModule.Value;
			await module.DisposeAsync();
		}
	}
}