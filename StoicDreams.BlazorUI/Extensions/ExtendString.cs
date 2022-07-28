using System.Text;

namespace StoicDreams.BlazorUI.Extensions;

public static class ExtendString
{
	/// <summary>
	/// Translate a pascal cased string (e.g. "ThisIsSomeText") to a string delimited with spaces between capitalizations (e.g. "This Is Some Text").
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public static string PascalToSpaced(this string input)
	{
		StringBuilder result = new();
		char last = ' ';
		foreach (char c in input)
		{
			if (char.IsUpper(c) && last != ' ')
			{
				result.Append(' ');
			}
			last = c;
			result.Append(c);
		}
		return result.ToString(); ;
	}

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
}
