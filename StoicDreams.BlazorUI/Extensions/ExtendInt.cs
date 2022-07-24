using System.Text;

namespace StoicDreams.BlazorUI.Extensions;

public static class ExtendInt
{
	public static string ToBaseEncode(this int input, int baseValue = 16, int pad = 0)
	{
		if (baseValue < 2 || baseValue > GetBaseKeys.Length) { throw new Exception($"Base {baseValue} is not supported for encoding."); }
		bool isNegative = input < 0;
		int currentValue = isNegative ? int.MaxValue + input : input;
		StringBuilder result = new();
		int remainder;
		do
		{
			remainder = currentValue % baseValue;
			currentValue /= baseValue;
			result.Append(GetBaseKeys[remainder]);
		}
		while (currentValue > 0);
		string encoded = isNegative ? string.Join("", result.ToString().Reverse()) : string.Join("", result.ToString().Reverse());
		char[] padding = new char[Math.Max(0, (pad + 1) - encoded.Length)];
		Array.Fill(padding, '0');
		return $"{string.Join("", padding)}{encoded}";
	}

	private static string? BaseKeysCache;
	public static string GetBaseKeys
	{
		get
		{
			BaseKeysCache ??= BuildBaseKeys;
			return BaseKeysCache;
		}
	}

	public static string BuildBaseKeys
	{
		get
		{
			StringBuilder keys = new();

			// Start with 0 to cover numbers
			int number = 48;
			while (keys.Length < 1024)
			{
				keys.Append((char)number++);
				// after numbers switch to lowercase letters
				if (number == 58) { number = 97; continue; }
				// after lowercase letters switch to uppercase letters
				if (number == 123) { number = 65; continue; }
				// after uppercase letters switch to unicode letters/characters
				if (number == 91) { number = 191; keys.Append("-_"); }
			}
			return keys.ToString();
		}
	}
}
