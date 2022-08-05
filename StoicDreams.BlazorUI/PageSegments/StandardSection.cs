namespace StoicDreams.BlazorUI.Components.Content;

public abstract partial class BUIDynamicContent
{
	/// <summary>
	/// Create a standard page section.
	/// Children parameter is expecting mix of string values for text, with each value representing a paragraph section, and PageSegment instances.
	/// </summary>
	/// <param name="children"></param>
	/// <returns></returns>
	public static PageSegment StandardSection(params object[] children)
	{
		PageSegment section = PageSegment.Create<BUIStandardSection>();
		foreach (object item in children)
		{
			switch (item)
			{
				case string text:
					section.Children.Add(Paragraph(text));
					break;
				case PageSegment segment:
					section.Children.Add(segment);
					break;
			}
		}
		return section;
	}
}
