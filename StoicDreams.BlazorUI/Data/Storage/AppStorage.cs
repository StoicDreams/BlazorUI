namespace StoicDreams.BlazorUI.Data;

public class AppStorage : IAppStorage
{
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
}
