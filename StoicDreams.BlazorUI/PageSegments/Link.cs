namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
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
			{ "ChildContent", text.ConvertToRenderFragment() },
			{ "Href", href },
			{ "Target", "_blank" }
		};
		return PageSegment.Create<MudTooltip>(("Text", string.IsNullOrWhiteSpace(tooltip) ? href.Replace("https://", "") : tooltip))
			.AddChild(PageSegment.Create<MudLink>(parameters));
	}
}
