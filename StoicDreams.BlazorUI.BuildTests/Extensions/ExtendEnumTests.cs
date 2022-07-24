namespace StoicDreams.BlazorUI.Extensions;

public class ExtendEnumTests : TestFramework
{
	[Theory]
	[InlineData(0, MockEnum.One)]
	[InlineData(1, MockEnum.Two)]
	[InlineData(2, MockEnum.Three)]
	[InlineData(3, MockEnum.Four)]
	[InlineData(4, MockEnum.Five)]
	public void Verify_Enum_AsValue(byte expectedResult, MockEnum input)
	{
		Assert.Equal(expectedResult, input.AsValue());
	}

	[Theory]
	[InlineData("0", MockEnum.One)]
	[InlineData("1", MockEnum.Two)]
	[InlineData("2", MockEnum.Three)]
	[InlineData("3", MockEnum.Four)]
	[InlineData("4", MockEnum.Five)]
	public void Verify_Enum_AsValueString(string expectedResult, MockEnum input)
	{
		Assert.Equal(expectedResult, input.AsValueString());
	}

	[Theory]
	[InlineData("One", MockEnum.One)]
	[InlineData("Two", MockEnum.Two)]
	[InlineData("Three", MockEnum.Three)]
	[InlineData("Four", MockEnum.Four)]
	[InlineData("Five", MockEnum.Five)]
	public void Verify_Enum_AsName(string expectedResult, MockEnum input)
	{
		Assert.Equal(expectedResult, input.AsName());
	}

	public enum MockEnum : byte
	{
		One,
		Two,
		Three,
		Four,
		Five
	}
}
