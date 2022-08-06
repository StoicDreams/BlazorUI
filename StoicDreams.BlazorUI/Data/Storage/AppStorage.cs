namespace StoicDreams.BlazorUI.Data;

public class AppStorage : IAppStorage
{
	public AppStorage(
		IJsonConvert jsonConvert,
		IAppState appState,
		IMemoryStorage memory
		)
	{
		JsonConvert = jsonConvert;
		AppState = appState;
		Memory = memory;
		SyncMemoryFromStorage();
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
			object? value = await storage.GetValue<object>(key);
			if (value == null) { continue; }
			await Memory.SetValue(key, value);
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
		await SyncMemoryToStorage();
	}

	private ValueTask SyncMemoryFromStorage()
	{
		// Load data from HD
		return ValueTask.CompletedTask;
	}

	private ValueTask SyncMemoryToStorage()
	{
		StoragePermissions permission = GetPermission;
		switch (permission)
		{
			case StoragePermissions.LongTerm:
				// Store data to HD
				break;
			default:
				// Only store data in memory
				break;
		}
		return ValueTask.CompletedTask;
	}


	private StoragePermissions GetPermission => AppState.GetData<StoragePermissions>(AppStateDataTags.StoragePermission);
	private IMemoryStorage Memory { get; }
	private IAppState AppState { get; }
	private IJsonConvert JsonConvert { get; }
}
