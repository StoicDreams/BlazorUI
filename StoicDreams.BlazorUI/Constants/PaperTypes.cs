namespace StoicDreams.BlazorUI.Constants;

public enum PaperTypes
{
	None = 0,
	[Data("d-flex")]
	Flex = 1,
	[Data("d-flex flex-column")]
	FlexColumn = 2,
	[Data("d-flex flex-row")]
	FlexRow = 4,
	[Data("flex-grow-1")]
	Grow = 8,
	[Data("d-flex justify-end")]
	JustifyEnd = 16,
	[Data("d-flex flex-wrap")]
	Wrap = 32
}

public static class ExtendPaperTypes
{
	public static string GetClasses(this PaperTypes values)
	{
		Dictionary<string, bool> classes = new();
		foreach (PaperTypes value in Enum.GetValues(typeof(PaperTypes)))
		{
			if ((value & values) == 0) { continue; }
			string[] enumData = value.GetData().Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			foreach (string enumValue in enumData)
			{
				classes[enumValue] = true;
			}
		}
		return string.Join(' ', classes.Keys.ToArray());
	}
}
