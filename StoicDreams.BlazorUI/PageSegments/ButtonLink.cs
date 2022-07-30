namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	/// <summary>
	/// Create a new external link button page segment.
	/// </summary>
	/// <param name="text"></param>
	/// <param name="href"></param>
	/// <param name="startIcon"></param>
	/// <returns></returns>
	public static PageSegment ButtonLink(string text, string href, string? startIcon = null)
	{
		Dictionary<string, object> parameters = new()
		{
			{ "Variant", Variant.Filled },
			{ "ChildContent", text.ConvertToRenderFragment() },
			{ "Href", href },
			{ "Size", Size.Small },
			{ "Color", Color.Info },
			{ "Target", "_blank" },
			{ "EndIcon", Icons.Material.TwoTone.OpenInNew },
			{ "title", href.Replace("https://", "") }
		};
		if (!string.IsNullOrWhiteSpace(startIcon)) { parameters.Add("StartIcon", startIcon); }
		return PageSegment.Create<MudButton>(parameters);
	}
}
