namespace StoicDreams.BlazorUI.DataTypes;

public class ElementDetailTests : TestFramework
{
	[Theory]
	[MemberData(nameof(VerifyCreationInput))]
	public void Verify_Creation(string tagName, params (string, string)[] attributes)
	{
		ElementDetail detail = ElementDetail.Create(tagName, attributes);
		detail.TagName.Should().Be(tagName);
		foreach (var attr in attributes)
		{
			detail.Attributes[attr.Item1].Should().Be(attr.Item2);
		}
	}

	public static IEnumerable<object[]> VerifyCreationInput()
	{
		yield return new object[] { "link", ("src", "test") };
		yield return new object[] { "script", ("href", "test"), ("type", "text/javascript") };
	}
}
