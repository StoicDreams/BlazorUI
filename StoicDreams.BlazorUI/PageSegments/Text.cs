namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	/// <summary>
	/// Create a new paragraph page segment.
	/// </summary>
	/// <param name="children"></param>
	/// <returns></returns>
	public static PageSegment Text(string text)
	{
		return PageSegment.Create<BUIInline>(("ChildContent", text.ConvertToRenderFragment()));
	}
}
