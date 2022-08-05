namespace StoicDreams.BlazorUI.Components.Content;

public abstract partial class BUIDynamicContent
{
	/// <summary>
	/// Create a new paragraph page segment.
	/// </summary>
	/// <param name="children"></param>
	/// <returns></returns>
	public static PageSegment Text(string text)
	{
		return PageSegment.Create<BUIInline>((nameof(BUIInline.ChildContent), text.ConvertToRenderFragment()));
	}
}
