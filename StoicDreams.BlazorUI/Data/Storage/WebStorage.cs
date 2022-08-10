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

	public async ValueTask<TValue?> GetValue<TValue>(string name)
	{
		if (StorageCache.ContainsKey(name))
		{
			TValue? cached = await FromJson<TValue>(StorageCache[name]);
			if (cached != null)
			{
				await Memory.SetValue(name, cached);
				StorageCache.Remove(name);
			}
		}
		return await Memory.GetValue<TValue>(name);
	}

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
		StoragePermissions permission = await GetStorageItem<StoragePermissions>("localStorage", AppStateDataTags.StoragePermission.AsName());
		if (permission == StoragePermissions.None)
		{
			permission = await GetStorageItem<StoragePermissions>("sessionStorage", AppStateDataTags.StoragePermission.AsName());
		}
		if (permission != StoragePermissions.None)
		{
			AppState.SetData(AppStateDataTags.StoragePermission, permission);
			string container = permission == StoragePermissions.LongTerm ? "localStorage" : "sessionStorage";
			//await Memory.SetValue(AppStateDataTags.StoragePermission.AsName(), permission);
			string[] keys = await JsInterop.RunInlineScript<string[]>($"(()=>Object.keys({container}))()") ?? Array.Empty<string>();
			foreach (string key in keys)
			{
				string? json = await GetStorageJson(container, key);
				if (json == null) { continue; }
				StorageCache[key] = json;
			}
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
		string? json = await GetStorageJson(container, key);
		if (string.IsNullOrWhiteSpace(json)) { return default; }
		return await FromJson<TResult>(json);
	}

	private async ValueTask<string?> GetStorageJson(string container, string key)
	{
		return await JsInterop.CallMethod<string>($"{container}.getItem", nameof(AppStateDataTags.StoragePermission));
	}

	private ValueTask<string> ToJson(object input) => JsonConvert.SerializeAsync(input);
	private ValueTask<TInstance?> FromJson<TInstance>(string json) => JsonConvert.DeserializeAsync<TInstance?>(json, () => default);

	private ValueTask CallMethod(string method, params object[] args) => JsInterop.CallMethod(method, args);
	private ValueTask<TResult?> CallMethod<TResult>(string method, params object[] args) => JsInterop.CallMethod<TResult>(method, args);


	private StoragePermissions GetPermission => AppState.GetData<StoragePermissions>(AppStateDataTags.StoragePermission);
	private IMemoryStorage Memory { get; }
	private Dictionary<string, string> StorageCache { get; } = new();
	private IAppState AppState { get; }
	private IJsonConvert JsonConvert { get; }
	private IJsInterop JsInterop { get; }
}
