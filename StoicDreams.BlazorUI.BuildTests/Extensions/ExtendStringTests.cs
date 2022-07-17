namespace StoicDreams.BlazorUI;

public class ExtendStringTests : TestFramework
{
	[Theory]
	[InlineData("", "")]
	[InlineData("This Is A Phrase", "ThisIsAPhrase")]
	public void Verify_PascalToSpaced(string expectedResult, string input)
	{
		IActions actions = ArrangeUnitTest(() => input);

		actions.Act((string value) => value.PascalToSpaced());

		actions.Assert((string? result) => result.IsNotNull().Should().Be(expectedResult));
	}
}