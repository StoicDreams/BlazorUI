namespace StoicDreams.BlazorUI.Data;

public interface IJsonConvert
{
	T Deserialize<T>(string json, Func<T> defaultIfMissing);
	string Serialize(object data, bool tabbed = false);
}
