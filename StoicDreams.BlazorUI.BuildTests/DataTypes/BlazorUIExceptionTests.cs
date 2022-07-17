namespace StoicDreams.BlazorUI.DataTypes;

public class BlazorUIExceptionTests : TestFramework
{
	[Fact]
	public void Verify_Exceptions()
	{
		IActions actions = ArrangeUnitTest(() => 0);

		actions.ActThrowsException(() => BlazorUIException.Throw<BlazorUIExceptionTests>("Hello World"));

		actions.Assert((BlazorUIException<BlazorUIExceptionTests>? ex) => ex.IsNotNull().Message.Should().Be("StoicDreams.BlazorUI.DataTypes.BlazorUIExceptionTests Exception: Hello World"));

		actions.ActThrowsException(() =>
		{
			try
			{
				BlazorUIException.Throw<BlazorUIExceptionTests>("Rethrow me!");
			}
			catch (Exception ex)
			{
				BlazorUIException.ReThrow("Rethrown", ex);
			}
		});

		actions.Assert((BlazorUIException<Exception>? ex) => ex.IsNotNull().Message.Should().Be("System.Exception Exception: Rethrown StoicDreams.BlazorUI.DataTypes.BlazorUIExceptionTests Exception: Rethrow me!"));
	}
}
