namespace StoicDreams.BlazorUI.DataTypes;

public class ElementDetail
{
	/// <summary>
	/// Tag name of element.
	/// e.g. "div", "section", "link", "script".
	/// </summary>
	public string TagName { get; set; } = string.Empty;

	/// <summary>
	/// Attribute keys and values of element.
	/// </summary>
	public IDictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

	/// <summary>
	/// Create new ElementDetail instance.
	/// Use "body" attribute to set element body content - e.g. ("body", "body content goes here").
	/// </summary>
	/// <param name="tagName">Tag name of element to create.</param>
	/// <param name="attributes">(Key, Value) pairs of attributes to set for element.</param>
	/// <returns></returns>
	public static ElementDetail Create(string tagName, params (string, string)[] attributes)
	{
		ElementDetail elementDetail = new() { TagName = tagName };
		foreach ((string key, string value) in attributes)
		{
			elementDetail.Attributes.Add(key, value);
		}
		return elementDetail;
	}
}
