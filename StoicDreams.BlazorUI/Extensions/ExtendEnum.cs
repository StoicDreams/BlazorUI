namespace StoicDreams.BlazorUI.Extensions;

public static class ExtendEnum
{
	/// <summary>
	/// Explicit callout to get value type (e.g. int, byte, etc) from enum instance.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumValue"></param>
	/// <returns></returns>
	public static object AsValue<T>(this T enumValue)
		where T : Enum
	{
		return Convert.ChangeType(enumValue, enumValue.GetTypeCode());
	}

	/// <summary>
	/// Explicit callout to get value type (e.g. int, byte, etc) as a string from enum instance.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumValue"></param>
	/// <returns></returns>
	public static string AsValueString<T>(this T enumValue)
		where T : Enum
	{
		return $"{enumValue.AsValue()}";
	}

	/// <summary>
	/// Explicit callout to get the Name representing the current value from the current enum instance.
	/// </summary>
	/// <param name="enumValue"></param>
	/// <returns></returns>
	public static string AsName(this Enum enumValue)
	{
		return Enum.GetName(enumValue.GetType(), enumValue) ?? $"{enumValue}";
	}
}
