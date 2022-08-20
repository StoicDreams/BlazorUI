namespace StoicDreams.BlazorUI.Extensions;

public static class ExtendString
{
	/// <summary>
	/// Convert a string into a RenderFragment instance that can be passed into .razor syntax output.
	/// By default input string can be markup (html) - set isMarkup to false to disable and output text explicity as is.
	/// </summary>
	/// <param name="input"></param>
	/// <param name="isMarkup"></param>
	/// <returns></returns>
	public static RenderFragment ConvertToRenderFragment(this string input, bool isMarkup = true) => __builder =>
	{
		if (isMarkup)
		{
			__builder.AddMarkupContent(0, input);
		}
		else
		{
			__builder.AddContent(0, input);
		}
	};

	public static RenderFragment[] ToRenderFragmentArray(this string input, char delimiter = '\n', StringSplitOptions options = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
	{
		List<RenderFragment> list = new();
		foreach (string item in input.ToStringArray(delimiter, options))
		{
			list.Add(item.ConvertToRenderFragment());
		}
		return list.ToArray();
	}
}
