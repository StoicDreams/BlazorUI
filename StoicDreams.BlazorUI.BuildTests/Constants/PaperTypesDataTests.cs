namespace StoicDreams.BlazorUI.Constants;

public class PaperTypesDataTests : TestFramework
{
	[Theory]
	[InlineData("d-flex flex-row", PaperTypes.Flex | PaperTypes.FlexRow)]
	[InlineData("d-flex justify-end flex-wrap", PaperTypes.JustifyEnd | PaperTypes.Wrap)]
	public void Verify_Class_Creation_From_PaperTypes(string expectedClasses, PaperTypes paperTypes)
	{
		Assert.Equal(expectedClasses, paperTypes.GetClasses());
	}
}
