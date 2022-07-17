namespace StoicDreams.BlazorUI;

public class ExtendStringTests : TestFramework
{
	[Theory]
	[InlineData("", "")]
	[InlineData("This Is A Phrase", "ThisIsAPhrase")]
	public void Verify_PascalToSpaced(string expectedResult, string input)
	{
		IActions actions = ArrangeUnitTest(() => input);

		actions.Act(value => ((string)value).PascalToSpaced());

		actions.Assert(result => result.Should().Be(expectedResult));
	}
}