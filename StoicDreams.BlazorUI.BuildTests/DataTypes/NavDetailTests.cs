namespace StoicDreams.BlazorUI.DataTypes;

public class NavDetailTests : TestFramework
{
	[Theory]
	[InlineData("Name", "icon", "href")]
	public void Verify_Create_And_OnClick(string name, string icon, string href)
	{
		IActions<NavDetail> actions = ArrangeUnitTest<NavDetail>();

		actions.Act(a => NavDetail.Create(name, icon, href, 0, navDetail =>
		{
			navDetail.Name = "Changed Name";
			navDetail.Icon = "Changed Icon";
			navDetail.Href = "Changed Href";
		}));

		actions.Assert(a =>
		{
			NavDetail navDetail = a.GetResult<NavDetail>().IsNotNull();
			navDetail.Name.Should().Be(name);
			navDetail.Icon.Should().Be(icon);
			navDetail.Href.Should().Be(href);
		});

		actions.Act(a =>
		{
			NavDetail navDetail = a.GetResult<NavDetail>().IsNotNull();
			navDetail.OnClick.IsNotNull().Invoke(navDetail);
			return navDetail;
		});

		actions.Assert(a =>
		{
			NavDetail navDetail = a.GetResult<NavDetail>().IsNotNull();
			navDetail.Name.Should().Be("Changed Name");
			navDetail.Icon.Should().Be("Changed Icon");
			navDetail.Href.Should().Be("Changed Href");
		});
	}
}
