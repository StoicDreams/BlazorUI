using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StoicDreams.BlazorUI.Data;

public class JsonConvert : IJsonConvert
{
	public ValueTask<T> Deserialize<T>(string json, Func<T> defaultIfMissing)
	{
		try
		{
			return ValueTask.FromResult(JsonSerializer.Deserialize<T>(json, JsonOptionsCompact) ?? defaultIfMissing());
		}
		catch
		{
			return ValueTask.FromResult(defaultIfMissing());
		}
	}

	public ValueTask<string> Serialize(object data, bool tabbed = false)
	{
		if (tabbed) { return ValueTask.FromResult(JsonSerializer.Serialize(data, JsonOptionsReadable)); }
		return ValueTask.FromResult(JsonSerializer.Serialize(data, JsonOptionsCompact));
	}

	private JsonSerializerOptions JsonOptionsCompact => new()
	{
		AllowTrailingCommas = true,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
		IncludeFields = true,
		NumberHandling = JsonNumberHandling.AllowReadingFromString,
		PropertyNameCaseInsensitive = true,
		ReadCommentHandling = JsonCommentHandling.Skip,
		WriteIndented = false,
		Encoder = JavaScriptEncoder.Default
	};

	private JsonSerializerOptions JsonOptionsReadable => new()
	{
		AllowTrailingCommas = true,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
		IncludeFields = true,
		NumberHandling = JsonNumberHandling.AllowReadingFromString,
		PropertyNameCaseInsensitive = true,
		ReadCommentHandling = JsonCommentHandling.Skip,
		WriteIndented = true,
		Encoder = JavaScriptEncoder.Default
	};
}
