using Microsoft.AspNetCore.Components.Rendering;

namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	/// <summary>
	/// Create a new paper page segment.
	/// Expected base classes are built from PaperTypes value.
	/// </summary>
	/// <param name="paperType"></param>
	/// <param name="classes"></param>
	/// <param name="elevation"></param>
	/// <returns></returns>
	public static PageSegment Virtualize<TItem>(IEnumerable<TItem> items, Func<TItem, PageSegment> childContent)
	{
		RenderFragment<TItem> handler = item => __builder =>
		{
			__builder.AddContent(0, GetRenderFragment<BUIPageContentSegmentRender>(("Segment", childContent.Invoke(item))));
		};
		return PageSegment.Create<MudVirtualize<TItem>>(
			("Items", items),
			("ChildContent", handler)
			);
	}
}
