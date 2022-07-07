namespace StoicDreams.BlazorUI.Data;

public class AppStateTests : TestFramework
{
	[Theory]
	[InlineData("Hello")]
	[InlineData(23409)]
	public void Verify_State_Management<T>(T data)
	{
		Guid subscriberId = Guid.NewGuid();
		int changeCounter = 0;
		IActions<IAppState> actions = ArrangeUnitTest<IAppState, AppState>();

		actions.Act(a => a.Service.GetData<T>("test"));

		actions.Assert(a => a.Service.GetData<T>("test").Should().Be(default(T)));

		actions.Act(a => a.Service.SetData("test", data));

		actions.Assert(a =>
		{
			a.Service.GetData<T>("test").Should().Be(data);
			// getting by improper type will return requested type default.
			a.Service.GetData<Guid>("test").Should().Be(Guid.Empty);
			// invalid get will not corrupt actual stored data.
			a.Service.GetData<T>("test").Should().Be(data);
		});

		actions.Act(a => a.Service.SetData<object?>("test", null));

		actions.Assert(a => a.Service.GetData<object?>("test").Should().Be(null));

		actions.Act(a => a.Service.SubscribeToDataChanges(subscriberId, keys =>
		{
			++changeCounter;
		}));

		actions.Assert(a =>
		{
			a.Service.TriggerChange("unused");
			changeCounter.Should().Be(1);
		});

		actions.Act(a =>
		{
			a.Service.ApplyChanges(() =>
			{
				a.Service.SetData("test", subscriberId);
				return ValueTask.CompletedTask;
			});
		});

		actions.Assert(a =>
		{
			changeCounter.Should().Be(2);
			a.Service.GetData<Guid>("test").Should().Be(subscriberId);
		});

		actions.Act(a =>
		{
			a.Service.UnsubscribeToDataChanges(subscriberId);
			a.Service.ApplyChanges(() =>
			{
				return ValueTask.CompletedTask;
			});
		});

		actions.Assert(a =>
		{
			changeCounter.Should().Be(2);
		});
	}
}
