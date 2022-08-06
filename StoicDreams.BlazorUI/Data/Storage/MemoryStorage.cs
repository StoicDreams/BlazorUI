namespace StoicDreams.BlazorUI.Data;

public class MemoryStorage : Dictionary<string, object>, IMemoryStorage
{
	public bool TryGetValue<TValue>(string name, out TValue? value)
	{
		value = default;
		if(!base.TryGetValue(name, out object? stored)) { return false; }
		if (stored is TValue result)
		{
			value = result;
			return true;
		}
		return false;
	}

	public void CopyFrom(IStorage storage)
	{

	}
}
