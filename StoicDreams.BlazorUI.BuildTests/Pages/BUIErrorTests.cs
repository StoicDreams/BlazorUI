namespace StoicDreams.BlazorUI.Pages;

public class BUIErrorTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render_Without_Exception()
	{
		IRenderActions<BUIError> actions = ArrangeRenderTest<BUIError>(options =>
		{

		});

		actions.Act();

		actions.Assert(a => a.Render.Markup.Should().Contain("An unexpected error occurred handling your request."));
	}

	[Fact]
	public void Verify_Render_With_Exception()
	{
		IRenderActions<BUIError> actions = ArrangeRenderTest<BUIError>(options =>
		{
			options.Parameters.Add("Exception", new Exception("This is a test error message"));
		});

		actions.Act();

		actions.Assert(a => a.Render.Markup.Should().Contain("This is a test error message"));
	}
}
