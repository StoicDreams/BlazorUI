namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	protected string Title { get; set; } = string.Empty;

	protected List<PageSegment> PageMarkup { get; set; } = new();

	protected bool FlipState { get; set; }

	protected PageSegment CreatePageSegment<T>(string text)
	{
		return PageSegment.Create<T>().AddParameter("ChildContent", text.ConvertToRenderFragment());
	}

	protected PageSegment CreatePageSegment<T>(params (string name, object value)[] parameters)
	{
		return PageSegment.Create<T>(parameters);
	}

	/// <summary>
	/// Place your page initialization code here.
	/// Make sure to set this.Title within this method.
	/// </summary>
	/// <returns></returns>
	protected abstract Task InitializePage();

	protected override async Task OnInitializedAsync()
	{
		await InitializePage();
		await base.OnInitializedAsync();
	}
}
