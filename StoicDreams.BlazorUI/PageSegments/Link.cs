namespace StoicDreams.BlazorUI.Components.Content;

public abstract partial class BUIDynamicContent
{
	/// <summary>
	/// Create a new external link button page segment.
	/// </summary>
	/// <param name="text"></param>
	/// <param name="href"></param>
	/// <param name="tooltip">defaults to href if null or empty</param>
	/// <returns></returns>
	public static PageSegment Link(string text, string href, string? tooltip = null)
	{
		Dictionary<string, object> parameters = new()
		{
			{ nameof(MudLink.ChildContent), text.ConvertToRenderFragment() },
			{ nameof(MudLink.Href), href },
			{ nameof(MudLink.Target), "_blank" }
		};
		return PageSegment.Create<MudTooltip>((nameof(MudTooltip.Text), string.IsNullOrWhiteSpace(tooltip) ? href.Replace("https://", "") : tooltip))
			.AddChild(PageSegment.Create<MudLink>(parameters));
	}
}
