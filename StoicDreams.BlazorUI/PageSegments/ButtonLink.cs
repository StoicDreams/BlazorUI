namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	/// <summary>
	/// Create a new external link button page segment.
	/// </summary>
	/// <param name="text"></param>
	/// <param name="href"></param>
	/// <param name="startIcon"></param>
	/// <param name="tooltip">defaults to href if null or empty</param>
	/// <returns></returns>
	public static PageSegment ButtonLink(string text, string href, string? startIcon = null, string? tooltip = null)
	{
		Dictionary<string, object> parameters = new()
		{
			{ "Variant", Variant.Filled },
			{ "ChildContent", text.ConvertToRenderFragment() },
			{ "Href", href },
			{ "Size", Size.Small },
			{ "Color", Color.Info },
			{ "Target", "_blank" },
			{ "EndIcon", Icons.Material.TwoTone.OpenInNew }
		};
		if (!string.IsNullOrWhiteSpace(startIcon)) { parameters.Add("StartIcon", startIcon); }
		return PageSegment.Create<MudTooltip>(("Text", string.IsNullOrWhiteSpace(tooltip) ? href.Replace("https://", "") : tooltip))
			.AddChild(PageSegment.Create<MudButton>(parameters));
	}
}
