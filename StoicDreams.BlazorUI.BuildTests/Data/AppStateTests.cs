using StoicDreams.BlazorUI.Components.Displays;

namespace StoicDreams.BlazorUI.Data;

public class AppStateTests : TestFramework
{
	[Theory]
	[InlineData("Hello")]
	[InlineData(23409)]
	[InlineData(typeof(BUITitleBar))]
	public void Verify_State_Management<T>(T data)
	{
		Guid subscriberId = Guid.NewGuid();
		int changeCounter = 0;
		IActions<IAppState> actions = ArrangeTest<IAppState>(options =>
		{
			AppOptions appOptions = new();
			options.AddService<IAppOptions>(() => appOptions);
			options.AddService<IMemoryStorage, MemoryStorage>();
			options.AddService<IAppState, AppState>();
		});

		actions.Act(async a => await a.Service.GetDataAsync<T>("test"));

		actions.Assert(async a => (await a.Service.GetDataAsync<T>("test")).Should().Be(default(T)));

		actions.Act(async a => await a.Service.SetDataAsync("test", data));

		actions.Assert(async a =>
		{
			(await a.Service.GetDataAsync<T>("test")).Should().Be(data);
			// getting by improper type will return requested type default.
			(await a.Service.GetDataAsync<Guid>("test")).Should().Be(Guid.Empty);
			// invalid get will not corrupt actual stored data.
			(await a.Service.GetDataAsync<T>("test")).Should().Be(data);
		});

		actions.Act(async a => await a.Service.SetDataAsync<object?>("test", null));

		actions.Assert(async a => (await a.Service.GetDataAsync<object?>("test")).Should().Be(null));

		actions.Act(a => a.Service.SubscribeToDataChanges(subscriberId, keys =>
		{
			++changeCounter;
		}));

		actions.Assert(a =>
		{
			a.Service.TriggerChangeAsync("unused");
			changeCounter.Should().Be(1);
		});

		actions.Act(a =>
		{
			a.Service.ApplyChangesAsync(async () =>
			{
				await a.Service.SetDataAsync("test", subscriberId);
			});
		});

		actions.Assert(async a =>
		{
			changeCounter.Should().Be(2);
			(await a.Service.GetDataAsync<Guid>("test")).Should().Be(subscriberId);
		});

		actions.Act(a =>
		{
			a.Service.UnsubscribeToDataChanges(subscriberId);
			a.Service.ApplyChanges(() =>
			{
			});
		});

		actions.Assert(a =>
		{
			changeCounter.Should().Be(2);
		});
	}
}
