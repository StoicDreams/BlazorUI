namespace StoicDreams.BlazorUI.Components.Content;

public abstract partial class BUIDynamicContent
{
	/// <summary>
	/// Create a new paragraph page segment.
	/// Expected children parameter can consist of string values for text you want and PageSegment instances.
	/// Page segment instances should be for components that make sense within the body of a paragraph, such as Link segments.
	/// </summary>
	/// <param name="children"></param>
	/// <returns></returns>
	public static PageSegment Paragraph(params object[] children)
	{
		PageSegment paragraph = PageSegment.Create<BUIParagraph>();
		int count = 0;
		foreach (object item in children)
		{
			switch (item)
			{
				case string text:
					paragraph.Children.Add(Text($"{(count > 0 ? " " : "")}{text} "));
					break;
				case PageSegment segment:
					paragraph.Children.Add(segment);
					break;
			}
			++count;
		}
		return paragraph;
	}
}
