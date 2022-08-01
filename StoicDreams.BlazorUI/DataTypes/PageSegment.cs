namespace StoicDreams.BlazorUI.DataTypes;

public class PageSegment 
{
	/// <summary>
	/// Content type of this segment
	/// </summary>
	public Type Content { get; init; } = typeof(MudSpacer);

	/// <summary>
	/// Parameters to pass to component when Content contains a Type Value.
	/// </summary>
	public Dictionary<string, object> Parameters { get; init; } = new();

	/// <summary>
	/// Children to render inside of component when Content contains a Type Value.
	/// </summary>
	public List<PageSegment> Children { get; init; } = new();

	public PageSegment AddParameter(string name, object value)
	{
		Parameters[name] = value;
		return this;
	}

	public PageSegment AddChild(PageSegment child)
	{
		Children.Add(child);
		return this;
	}

	public PageSegment AddChild<T>(string text)
	{
		Children.Add(Create<T>().AddParameter("ChildContent", text.ConvertToRenderFragment()));
		return this;
	}

	public PageSegment AddChild<T>(params (string name, object value)[] parameters)
	{
		Children.Add(Create<T>(parameters));
		return this;
	}

	/// <summary>
	/// Create a paragraph page segment consisting.
	/// Pass in an empty string to display a MudSpacer component instead of a paragraph element.
	/// </summary>
	/// <param name="markdown"></param>
	public static PageSegment Create(string content) => string.IsNullOrWhiteSpace(content) ? Create<MudSpacer>() : Create<BUIInline>(("ChildContent", content.ConvertToRenderFragment()));

	/// <summary>
	/// Create a component consisting of the specified component Type.
	/// Type needs to be a Type derived from ComponentBase.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="content"></param>
	/// <param name="parameters"></param>
	/// <returns></returns>
	public static PageSegment Create<T>(Dictionary<string, object> parameters, IEnumerable<PageSegment>? children = null) => new()
	{
		Content = typeof(T),
		Parameters = parameters,
		Children = children?.ToList() ?? new()
	};

	/// <summary>
	/// Create a component consisting of the specified component Type.
	/// Type needs to be a Type derived from ComponentBase.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="content"></param>
	/// <param name="parameters"></param>
	/// <returns></returns>
	public static PageSegment Create<T>(params (string name, object value)[] parameters) => new()
	{
		Content = typeof(T),
		Parameters = parameters.ToDictionary(n => n.name, v => v.value)
	};

	/// <summary>
	/// Implicitly create a PageSegment from a markdown string.
	/// An empty string will convert to a MudSpacer component.
	/// </summary>
	/// <param name="markdown"></param>
	public static implicit operator PageSegment(string markdown) => Create(markdown);
}
