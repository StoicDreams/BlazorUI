namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	protected string Title { get; set; } = string.Empty;

	protected List<PageSegment> PageSegments { get; set; } = new();

	protected void SetPageContent(params PageSegment[] segments)
	{
		PageSegments = segments.ToList();
		StateHasChanged();
	}

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
	protected abstract ValueTask InitializePage();

	protected override async Task OnInitializedAsync()
	{
		await InitializePage();
		await base.OnInitializedAsync();
	}
}
