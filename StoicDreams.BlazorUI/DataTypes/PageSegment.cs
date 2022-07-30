﻿namespace StoicDreams.BlazorUI.DataTypes;

public class PageSegment 
{
	/// <summary>
	/// Specifies the segment type.
	/// </summary>
	public PageSegmentTypes SegmentType { get; init; } = PageSegmentTypes.Component;

	/// <summary>
	/// Content type of this segment
	/// </summary>
	public IPageSegmentType? Content { get; init; }

	/// <summary>
	/// Parameters to pass to component when Content contains a Type Value.
	/// </summary>
	public Dictionary<string, object> Parameters { get; init; } = new();

	/// <summary>
	/// Children to render inside of component when Content contains a Type Value.
	/// </summary>
	public List<PageSegment> Children { get; init; } = new();

	/// <summary>
	/// Create a page segment consisting of markdown to be translated to HTML.
	/// Pass in an empty string to display a MudSpacer component instead of Markdown content.
	/// </summary>
	/// <param name="markdown"></param>
	public static PageSegment Create(string content) => new()
	{
		SegmentType = string.IsNullOrEmpty(content) ? PageSegmentTypes.Spacer : PageSegmentTypes.Markdown,
		Content = content
	};

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
		SegmentType = PageSegmentTypes.Component,
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
		SegmentType = PageSegmentTypes.Component,
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

#region Setup for Implicit Conversions form string|Type to PageSegment
public abstract class IPageSegmentType
{
	public static implicit operator IPageSegmentType(string markdown) => new PageSegmentMarkdown() { Value = markdown };
	public static implicit operator IPageSegmentType(Type markdown) => new PageSegmentType() { Value = markdown };
}

public class PageSegmentMarkdown : IPageSegmentType
{
	public string Value { get; set; } = string.Empty;
	public static implicit operator PageSegmentMarkdown(string markdown) => new() { Value = markdown };
}

public class PageSegmentType : IPageSegmentType
{
	public Type Value { get; set; } = typeof(MudSpacer);
	public static implicit operator PageSegmentType(Type markdown) => new() { Value = markdown };
}
#endregion
