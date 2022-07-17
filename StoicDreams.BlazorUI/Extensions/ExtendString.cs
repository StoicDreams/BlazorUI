using System.Text;

namespace StoicDreams.BlazorUI.Extensions;

public static class ExtendString
{
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
}
