namespace StoicDreams.BlazorUI.Constants;

public class AttributesTests : TestFramework
{
	[Theory]
	[InlineData("Hello", MockEnum.One)]
	[InlineData("World", MockEnum.Two)]
	[InlineData("Three", MockEnum.Three)]
	public void Verify_Enum_Display_Attribute(string expectedDisplay, MockEnum input)
	{
		Assert.Equal(expectedDisplay, input.GetDisplay());
	}

	[Fact]
	public void Verify_Class_Display_Attribute()
	{
		MockClass instance = new();
		Assert.Equal("Hello", instance.GetDisplay(nameof(MockClass.TestOne)));
		Assert.Equal("Mock Class", instance.GetDisplay());
		Assert.Equal("World", instance.GetDisplay(nameof(MockClass.TestTwo)));
		Assert.Equal("TestThree", instance.GetDisplay(nameof(MockClass.TestThree)));
		Assert.Equal("Fourth", instance.GetDisplay(nameof(MockClass.TestFour)));
	}

	public enum MockEnum
	{
		[Display("Hello")]
		One,
		[Display("World")]
		Two,
		Three,
	}

	[Display("Mock Class")]
	public class MockClass
	{
		[Display("Hello")]
		public string TestOne { get; set; } = string.Empty;
		[Display("World")]
		public int TestTwo = 2;
		public MockEnum TestThree = MockEnum.One;
		[Display("Fourth")]
		public MockEnum TestFour = MockEnum.One;
	}
}
