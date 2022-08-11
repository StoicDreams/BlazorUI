using Microsoft.AspNetCore.Components;

namespace StoicDreams.BlazorUI;

public class ExtendStringTests : TestFramework
{
	[Fact]
	public void Verify_Conversion_To_RenderFragment()
	{
		RenderFragment renderFragment = "This is a test".ConvertToRenderFragment();

		Assert.NotNull(renderFragment);
	}
}
