namespace StoicDreams.BlazorUI.Data;

public class MemoryStorage : Dictionary<string, object>, IMemoryStorage
{
	public new IEnumerable<string> Keys => base.Keys.ToArray();

	public new ValueTask<bool> ContainsKey(string key)
	{
		return ValueTask.FromResult(base.ContainsKey(key));
	}

	public async ValueTask<TResult<TValue>> TryGetValue<TValue>(string key)
	{
		TResult<TValue> result = new();
		bool hasKey = await ContainsKey(key);
		if (hasKey)
		{
			result.Result = await GetValue<TValue>(key);
			result.Status = result.Result != null ? TResultStatus.Success : TResultStatus.Exception;
		}
		return result;
	}

	public new ValueTask<bool> Remove(string key)
	{
		return ValueTask.FromResult(base.Remove(key));
	}

	public ValueTask SetValue(string key, object value)
	{
		base[key] = value;
		return ValueTask.CompletedTask;
	}

	public ValueTask<TValue?> GetValue<TValue>(string name)
	{
		if (base.TryGetValue(name, out object? stored) && stored is TValue result)
		{
			return ValueTask.FromResult<TValue?>(result);
		}
		return ValueTask.FromResult<TValue?>(default);
	}

	public async ValueTask CopyFrom(IStorage storage)
	{
		foreach (string key in storage.Keys)
		{
			object? value = await storage.GetValue<object>(key);
			if (value == null) { continue; }
			base[key] = value;
		}
	}

	public void Dispose()
	{
		Clear();
	}
}
