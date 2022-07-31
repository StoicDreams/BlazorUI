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
	public static PageSegment Skeleton(SkeletonType skeleton, string width = "100%", string height = "100%", Animation animation = Animation.Wave)
	{
		return PageSegment.Create<MudSkeleton>(
			("SkeletonType", skeleton),
			("Width", width),
			("Height", height),
			("Animation", animation)
			);
	}

}
