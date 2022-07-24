namespace StoicDreams.BlazorUI.DataTypes;

public class ListWatcherTests : TestFramework
{
	[Fact]
	public void Verify_List_Watch_Updates_Fire_Event()
	{
		int updateCount = 0;
		ListWatcher<int> list = new(() => ++updateCount);
		updateCount.Should().Be(0);
		list.Add(1);
		updateCount.Should().Be(1);
		list.AddRange(new[] { 1, 2 });
		updateCount.Should().Be(2);
		list.Remove(2);
		updateCount.Should().Be(3);
		list.RemoveRange(0, 2);
		updateCount.Should().Be(4);
	}
}
