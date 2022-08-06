namespace StoicDreams.BlazorUI.Data;

public interface IJsonConvert
{
	ValueTask<T> Deserialize<T>(string json, Func<T> defaultIfMissing);
	ValueTask<string> Serialize(object data, bool tabbed = false);
}
