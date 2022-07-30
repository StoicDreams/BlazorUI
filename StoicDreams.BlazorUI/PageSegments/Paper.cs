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
	public static PageSegment Paper(PaperTypes paperType, string? classes = null, int elevation = 0)
	{
		return PageSegment.Create<MudPaper>(
			("Class", $"{paperType.GetClasses()} {classes ?? string.Empty}".Trim()),
			("Elevation", elevation)
			);
	}

}
