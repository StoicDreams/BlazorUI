namespace StoicDreams.BlazorUI.DataTypes;

public class PageSegment
{
	public PageSegmentTypes SegmentType { get; set; } = PageSegmentTypes.Markdown;

	public string Content { get; set; } = string.Empty;

	public static PageSegment Create(string content, PageSegmentTypes segmentType = PageSegmentTypes.Markdown) => new PageSegment()
	{
		SegmentType = segmentType,
		Content = content
	};

	public static implicit operator PageSegment(string markdown) => Create(markdown, string.IsNullOrWhiteSpace(markdown) ? PageSegmentTypes.Spacer : PageSegmentTypes.Markdown);
}
