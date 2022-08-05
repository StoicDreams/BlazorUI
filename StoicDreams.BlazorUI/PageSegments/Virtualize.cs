namespace StoicDreams.BlazorUI.Components.Content;

public abstract partial class BUIDynamicContent
{
	/// <summary>
	/// Create a page segment that uses MudVirtualize to dynamically render enumerable content based on what is currently in view to reduce rendering costs by not rendering content that is outside of the users view.
	/// </summary>
	/// <typeparam name="TItem"></typeparam>
	/// <param name="items"></param>
	/// <param name="childContent"></param>
	/// <returns></returns>
	public static PageSegment Virtualize<TItem>(IEnumerable<TItem> items, Func<TItem, PageSegment> childContent)
	{
		RenderFragment<TItem> handler = item => __builder =>
		{
			__builder.AddContent(0, GetRenderFragment<BUIPageContentSegmentRender>((nameof(BUIPageContentSegmentRender.Segment), childContent.Invoke(item))));
		};
		return PageSegment.Create<MudVirtualize<TItem>>(
			(nameof(MudVirtualize<TItem>.Items), items),
			(nameof(MudVirtualize<TItem>.ChildContent), handler)
			);
	}
}
