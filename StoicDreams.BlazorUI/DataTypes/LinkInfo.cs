using System.Runtime.InteropServices;

namespace StoicDreams.BlazorUI.DataTypes;

public class LinkInfo
{
	public string Href { get; set; } = string.Empty;

	public string Detail { get; set; } = string.Empty;

	public static LinkInfo Create(string href, string detail) => new() { Href = href, Detail = detail };
	public static implicit operator LinkInfo((string Href, string Detail) input) => new() { Href = input.Href, Detail = input.Detail };
}
