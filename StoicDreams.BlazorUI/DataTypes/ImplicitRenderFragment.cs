namespace StoicDreams.BlazorUI.DataTypes;

public class ImplicitRenderFragment
{
	public RenderFragment Render { get; set; } = "".ConvertToRenderFragment();

	public static implicit operator RenderFragment(ImplicitRenderFragment input) => input.Render;
	public static implicit operator ImplicitRenderFragment(string input) => new() { Render = input.ConvertToRenderFragment() };
	public static implicit operator ImplicitRenderFragment(RenderFragment input) => new() { Render = input };
}
