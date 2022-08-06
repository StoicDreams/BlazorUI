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
		_ = SyncMemoryFromStorage();
	}

	public IEnumerable<string> Keys => Memory.Keys;

	public async ValueTask<bool> Remove(string key)
	{
		bool result = await Memory.Remove(key);
		if (result)
		{
			await SyncMemoryToStorage();
		}
		return result;
	}

	public ValueTask<TValue?> GetValue<TValue>(string name) => Memory.GetValue<TValue>(name);

	public async ValueTask CopyFrom(IStorage storage)
	{
		foreach (string key in storage.Keys)
		{
			await Memory.SetValue(key, storage.GetValue<object?>(key));
		}
		await SyncMemoryToStorage();
	}

	public void Dispose()
	{
		Memory.Dispose();
	}

	public async ValueTask SetValue(string key, object value)
	{
		await Memory.SetValue(key, value);
		if (key == nameof(AppStateDataTags.StoragePermission) && value is StoragePermissions permission)
		{
			AppState.SetData(AppStateDataTags.StoragePermission, permission);
		}
		await SyncMemoryToStorage();
	}

	private async ValueTask SyncMemoryFromStorage()
	{
		StoragePermissions permission = await GetStorageItem<StoragePermissions>("localStorage", nameof(AppStateDataTags.StoragePermission));
		if (permission == StoragePermissions.None)
		{
			permission = await GetStorageItem<StoragePermissions>("sessionStorage", nameof(AppStateDataTags.StoragePermission));
		}
		if (permission != StoragePermissions.None)
		{
			AppState.SetData(AppStateDataTags.StoragePermission, permission);
		}
	}

	private async ValueTask SyncMemoryToStorage()
	{
		await CallMethod("localStorage.clear");
		await CallMethod("sessionStorage.clear");
		StoragePermissions permissions = GetPermission;
		if (permissions == StoragePermissions.None)
		{
			return;
		}

		string storageContainer = permissions == StoragePermissions.LongTerm ? "localStorage" : "sessionStorage";
		foreach(string key in Memory.Keys)
		{
			await SaveStorageItem(storageContainer, key, await Memory.GetValue<object>(key));
		}
	}

	private async ValueTask SaveStorageItem<TInstance>(string container, string key, TInstance item)
	{
		if (item == null)
		{
			await CallMethod($"{container}.removeItem", key);
			return;
		}
		string json = await ToJson(item);
		await CallMethod($"{container}.setItem", key, json);
	}

	private async ValueTask<TResult?> GetStorageItem<TResult>(string container, string key)
	{
		string? stored = await JsInterop.CallMethod<string>($"{container}.getItem", nameof(AppStateDataTags.StoragePermission));
		if (string.IsNullOrWhiteSpace(stored)) { return default; }
		return await FromJson<TResult>(stored);
	}

	private ValueTask<string> ToJson(object input) => JsonConvert.Serialize(input);
	private ValueTask<TInstance?> FromJson<TInstance>(string json) => JsonConvert.Deserialize<TInstance?>(json, () => default);

	private ValueTask CallMethod(string method, params object[] args) => JsInterop.CallMethod(method, args);
	private ValueTask<TResult?> CallMethod<TResult>(string method, params object[] args) => JsInterop.CallMethod<TResult>(method, args);


	private StoragePermissions GetPermission => AppState.GetData<StoragePermissions>(AppStateDataTags.StoragePermission);
	private IMemoryStorage Memory { get; }
	private IAppState AppState { get; }
	private IJsonConvert JsonConvert { get; }
	private IJsInterop JsInterop { get; }
}
