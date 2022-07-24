namespace StoicDreams.BlazorUI.DataTypes;

public class ColorDataTests : TestFramework
{
	[Theory]
	[InlineData("#ffffff", "255,255,255", "0,0.00,1.00")]
	[InlineData("#000000", "0,0,0", "0,0.00,0.00")]
	[InlineData("#2f8e25", "47,142,37", "114,0.59,0.35")]
	[InlineData("#58324d", "88,50,77", "317,0.28,0.27")]
	public void Verify_Color_Translations(string hexInput, string rgbValue, string hslValue)
	{
		IActions<ColorData> actions = ArrangeUnitTest<ColorData>();

		actions.Act(a => a.Service.HexValue = hexInput);

		actions.Assert(a =>
		{
			Assert.Equal(rgbValue, a.Service.RgbValue);
			Assert.Equal(hslValue, a.Service.HslValue);
		});
	}

	[Theory]
	[InlineData("#ffffff", "255,255,255", "0,0.00,1.00")]
	[InlineData("#000000", "0,0,0", "0,0.00,0.00")]
	[InlineData("#2f8e25", "47,142,37", "114,0.59,0.35")]
	[InlineData("#58324d", "88,50,77", "317,0.28,0.27")]
	public void Verify_Color_Translations_From_Implicit_Conversions(string hexInput, string rgbValue, string hslValue)
	{
		ColorData color = hexInput;

		Assert.Equal(rgbValue, color.RgbValue);
		Assert.Equal(hslValue, color.HslValue);
	}
}
