using StoicDreams.BlazorUI.Components.Surfaces;

namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	/// <summary>
	/// Create a section title page segment.
	/// </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	public static PageSegment StandardSection()
	{
		return PageSegment.Create<BUIStandardSection>();
	}
}
