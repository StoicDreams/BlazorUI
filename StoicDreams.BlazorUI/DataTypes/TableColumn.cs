namespace StoicDreams.BlazorUI.DataTypes;

public class TableColumn<TItem>
{
	public ImplicitRenderFragment Title { get; set; } = string.Empty;
	public RenderFragment<TItem> Cell { get; set; } = null!;
}
