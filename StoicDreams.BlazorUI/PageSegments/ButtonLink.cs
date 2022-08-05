namespace StoicDreams.BlazorUI.Components.Content;

public abstract partial class BUIDynamicContent
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
			{ nameof(MudButton.Variant), Variant.Filled },
			{ nameof(MudButton.ChildContent), text.ConvertToRenderFragment() },
			{ nameof(MudButton.Href), href },
			{ nameof(MudButton.Size), Size.Small },
			{ nameof(MudButton.Color), Color.Info },
			{ nameof(MudButton.Target), "_blank" },
			{ nameof(MudButton.EndIcon), Icons.Material.TwoTone.OpenInNew }
		};
		if (!string.IsNullOrWhiteSpace(startIcon)) { parameters.Add(nameof(MudButton.StartIcon), startIcon); }
		return PageSegment.Create<MudTooltip>((nameof(MudTooltip.Text), string.IsNullOrWhiteSpace(tooltip) ? href.Replace("https://", "") : tooltip))
			.AddChild(PageSegment.Create<MudButton>(parameters));
	}
}
