namespace StoicDreams.SampleWebsite.Data;

public static class NavData
{
	public static List<NavDetail> SiteNav { get; } = new()
	{
		NavDetail.Create("Home", Icons.Material.TwoTone.Home, "/"),
		NavDetail.Create("Docs", Icons.Material.TwoTone.LibraryBooks, "/start"),
	};
}
