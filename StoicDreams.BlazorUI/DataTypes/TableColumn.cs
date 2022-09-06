namespace StoicDreams.BlazorUI.DataTypes;

public class TableColumn<TItem>
{
	public RenderFragment Title { get; set; } = null!;
	public RenderFragment<TItem> Cell { get; set; } = null!;
}
