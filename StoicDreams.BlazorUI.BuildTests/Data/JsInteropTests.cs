using Microsoft.JSInterop;

namespace StoicDreams.BlazorUI.Data;

public class JsInteropTests : TestFramework
{
	[Theory]
	[InlineData("mock file")]
	public void Verify_AddJSFile(string file)
	{
		IActions<IJsInterop> actions = ArrangeUnitTest<IJsInterop, JsInterop>(options =>
		{
			options.GetMock<IJSRuntime>(mock => mock.Setup(m => m.InvokeAsync<It.IsAnyType>(IsAny<string>(), IsAny<object?[]?>())).Verifiable());
		});

		actions.Act(a => a.Service.AddJSFile(file));

		actions.Assert(a => a.GetMock<IJSRuntime>().Verify());
	}

	[Theory]
	[InlineData("mock file")]
	public void Verify_AddCSSFile(string file)
	{
		IActions<IJsInterop> actions = ArrangeUnitTest<IJsInterop, JsInterop>(options =>
		{
			options.GetMock<IJSRuntime>(mock => mock.Setup(m => m.InvokeAsync<It.IsAnyType>(IsAny<string>(), IsAny<object?[]?>())).Verifiable());
		});

		actions.Act(a => a.Service.AddCSSFile(file));

		actions.Assert(a => a.GetMock<IJSRuntime>().Verify());
	}

	[Fact]
	public void Verify_AddElementToHead()
	{
		IActions<IJsInterop> actions = ArrangeUnitTest<IJsInterop, JsInterop>(options =>
		{
			options.GetMock<IJSRuntime>(mock => mock.Setup(m => m.InvokeAsync<It.IsAnyType>(IsAny<string>(), IsAny<object?[]?>())).Verifiable());
		});

		actions.Act(a => a.Service.AddElementToHead("script", new Dictionary<string, string>()));

		actions.Assert(a => a.GetMock<IJSRuntime>().Verify());
	}

	[Fact]
	public void Verify_AddElementToBody()
	{
		IActions<IJsInterop> actions = ArrangeUnitTest<IJsInterop, JsInterop>(options =>
		{
			options.GetMock<IJSRuntime>(mock => mock.Setup(m => m.InvokeAsync<It.IsAnyType>(IsAny<string>(), IsAny<object?[]?>())).Verifiable());
		});

		actions.Act(a => a.Service.AddElementToBody("script", new Dictionary<string, string>()));

		actions.Assert(a => a.GetMock<IJSRuntime>().Verify());
	}
}
