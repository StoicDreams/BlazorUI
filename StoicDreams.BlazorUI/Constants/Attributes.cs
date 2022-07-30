using System.Formats.Asn1;

namespace StoicDreams.BlazorUI.Constants;

public static class Attributes
{
	/// <summary>
	/// Get value from Display attribute from a Class's definition or Enum instance
	/// Returns class name if Display attribute is missing.
	/// </summary>
	/// <typeparam name="TClass"></typeparam>
	/// <param name="instance"></param>
	/// <returns></returns>
	public static string GetDisplay<TClass>(this TClass instance)
	{
		if (instance is Enum enumValue)
		{
			DisplayAttribute[] displayAttributes = instance.GetAttributeFromEnum<DisplayAttribute, TClass>();
			if (displayAttributes.Length > 0) { return displayAttributes[0].Display; }
			return enumValue.AsName();
		}
		Type type = typeof(TClass);
		Attribute[] attributes = System.Attribute.GetCustomAttributes(type);
		foreach (Attribute attribute in attributes)
		{
			if (attribute is DisplayAttribute found)
			{
				return found.Display;
			}
		}
		return type.Name;
	}

	/// <summary>
	/// Get value from Display attribute from a Class's field.
	/// Returns field name if Display attribute is missing.
	/// </summary>
	/// <typeparam name="TClass"></typeparam>
	/// <param name="instance"></param>
	/// <param name="fieldName"></param>
	/// <returns></returns>
	public static string GetDisplay<TClass>(this TClass instance, string fieldName)
	{
		DisplayAttribute[] attributes = GetAttributesFromFieldName<DisplayAttribute, TClass>(fieldName);
		if (attributes.Length == 0) { return fieldName; }
		return attributes[0].Display;
	}

	public static string GetData<TClass>(this TClass instance)
	{
		if (instance is Enum enumValue)
		{
			DataAttribute[] displayAttributes = instance.GetAttributeFromEnum<DataAttribute, TClass>();
			if (displayAttributes.Length == 0)
			{
				return string.Empty;
			}
			string[] data = displayAttributes.Select(item => item.Data).ToArray();
			return string.Join(' ', data);
		}
		Type type = typeof(TClass);
		Attribute[] attributes = System.Attribute.GetCustomAttributes(type);
		foreach (Attribute attribute in attributes)
		{
			if (attribute is DisplayAttribute found)
			{
				return found.Display;
			}
		}
		return type.Name;
	}

	/// <summary>
	/// Get array of TAttribute attributes found for given class's field name
	/// </summary>
	/// <typeparam name="TAttribute"></typeparam>
	/// <typeparam name="TClass"></typeparam>
	/// <param name="fieldName"></param>
	/// <returns></returns>
	public static TAttribute[] GetAttributesFromFieldName<TAttribute, TClass>(string fieldName)
		where TAttribute : Attribute
	{
		MemberInfo[] members = typeof(TClass).GetMembers();
		foreach(MemberInfo info in members)
		{
			if (info.Name != fieldName) { continue; }
			List<TAttribute> results = new();
			IEnumerable<TAttribute> attributes = info.GetCustomAttributes<TAttribute>();
			return attributes.ToArray();
		}
		return Array.Empty<TAttribute>();
	}

	/// <summary>
	/// Get array of TAttribute attributes instances from provided TEnum enum value
	/// </summary>
	/// <typeparam name="TAttribute"></typeparam>
	/// <typeparam name="TEnum"></typeparam>
	/// <param name="value"></param>
	/// <returns></returns>
	public static TAttribute[] GetAttributeFromEnum<TAttribute, TEnum>(this TEnum value)
		where TAttribute : Attribute
		//where TEnum : Enum
	{
		string? valueString = value?.ToString();
		if (valueString == null) return Array.Empty<TAttribute>();
		Type type = typeof(TEnum);
		MemberInfo[] infoList = type.GetMember(valueString);
		MemberInfo? info = infoList.FirstOrDefault(item => item.DeclaringType == type);
		if (info == null) { return Array.Empty<TAttribute>(); }
		object[] valueAttributes = info.GetCustomAttributes(typeof(TAttribute), false);
		if (valueAttributes.Length == 0) { Array.Empty<TAttribute>(); }
		TAttribute[] result = new TAttribute[valueAttributes.Length];
		Array.Copy(valueAttributes, result, result.Length);
		return result;
	}
}

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
public class DisplayAttribute : Attribute
{
	public string Display { get; set; }
	public DisplayAttribute(string displayName)
	{
		this.Display = displayName;
	}
}

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class DataAttribute : Attribute
{
	public string Data { get; set; }
	public DataAttribute(string displayName)
	{
		this.Data = displayName;
	}
}
