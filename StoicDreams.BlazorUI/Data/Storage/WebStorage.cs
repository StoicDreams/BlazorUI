namespace StoicDreams.BlazorUI.Data;

public class WebStorage : IWebStorage
{
	public WebStorage(
		IJsonConvert jsonConvert,
		IJsInterop jsInterop,
		IAppState appState,
		IMemoryStorage memory
		)
	{
		JsonConvert = jsonConvert;
		JsInterop = jsInterop;
		AppState = appState;
		Memory = memory;
	}

	public object this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public bool Remove(string key)
	{
		throw new NotImplementedException();
	}

	public bool TryGetValue<TValue>(string name, out TValue? value)
	{
		throw new NotImplementedException();
	}

	public void CopyFrom(IStorage storage)
	{

	}


	private StoragePermissions Permission => AppState.GetData<StoragePermissions>(AppStateDataTags.StoragePermission);
	private IMemoryStorage Memory { get; }
	private IAppState AppState { get; }
	private IJsonConvert JsonConvert { get; }
	private IJsInterop JsInterop { get; }
}
