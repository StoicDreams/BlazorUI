namespace StoicDreams.BlazorUI.Extensions;

public class ExtendIntTests : TestFramework
{
	[Theory]
	[InlineData("0", 0)]
	[InlineData("00", 0, 1)]
	[InlineData("ff", 255, 1)]
	public void Verify_Int_To_Base16(string expectedBase64, int input, int pad = 0)
	{
		Assert.Equal(expectedBase64, input.ToBaseEncode(16, pad));
	}
}
