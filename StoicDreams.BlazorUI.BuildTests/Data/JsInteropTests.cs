using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;

namespace StoicDreams.BlazorUI.Data;

public class JsInteropTests : TestFramework
{
	[Theory]
	[InlineData("mock file")]
	public void Verify_AddJSFile(string file)
	{
		(IActions<IJsInterop> actions, Mock<IJSObjectReference> mockJsObjectReference) = ArrangeJsInteropTest(mock =>
		{
			mock.Setup(m => m.InvokeAsync<IJSVoidResult>("AddJSFile", IsAny<object?[]?>())).Verifiable();
		});

		actions.Act(a => a.Service.AddJSFile(file));

		actions.Assert(a => mockJsObjectReference.Verify());
	}

	[Theory]
	[InlineData("mock file")]
	public void Verify_AddCSSFile(string file)
	{
		(IActions<IJsInterop> actions, Mock<IJSObjectReference> mockJsObjectReference) = ArrangeJsInteropTest(mock =>
		{
			mock.Setup(m => m.InvokeAsync<IJSVoidResult>("AddCSSFile", IsAny<object?[]?>())).Verifiable();
		});

		actions.Act(a => a.Service.AddCSSFile(file));

		actions.Assert(a => mockJsObjectReference.Verify());
	}

	[Fact]
	public void Verify_AddElementToHead()
	{
		(IActions<IJsInterop> actions, Mock<IJSObjectReference> mockJsObjectReference) = ArrangeJsInteropTest(mock =>
		{
			mock.Setup(m => m.InvokeAsync<IJSVoidResult>("AddElementToHead", IsAny<object?[]?>())).Verifiable();
		});

		actions.Act(a => a.Service.AddElementToHead("script", new Dictionary<string, string>()));

		actions.Assert(a => mockJsObjectReference.Verify());
	}

	[Fact]
	public void Verify_AddElementToBody()
	{
		(IActions<IJsInterop> actions, Mock<IJSObjectReference> mockJsObjectReference) = ArrangeJsInteropTest(mock =>
		{
			mock.Setup(m => m.InvokeAsync<IJSVoidResult>("AddElementToBody", IsAny<object?[]?>())).Verifiable();
		});

		actions.Act(a => a.Service.AddElementToBody("script", new Dictionary<string, string>()));

		actions.Assert(a => mockJsObjectReference.Verify());
	}

	[Fact]
	public void Verify_UpdateTitle()
	{
		(IActions<IJsInterop> actions, Mock<IJSObjectReference> mockJsObjectReference) = ArrangeJsInteropTest(mock =>
		{
			mock.Setup(m => m.InvokeAsync<IJSVoidResult>("UpdateTitle", new object?[] { "Hello World" })).Verifiable();
		});

		actions.Act(a => a.Service.UpdateTitle("Hello World"));

		actions.Assert(a => mockJsObjectReference.Verify());

		actions.Act(async a => await ((JsInterop)a.Service).DisposeAsync());
	}

	private (IActions<IJsInterop> actions, Mock<IJSObjectReference> mockJsObjectReference) ArrangeJsInteropTest(Action<Mock<IJSObjectReference>> setupHandler)
	{
		Mock<IJSObjectReference> mockJsObjectReference= Mock(setupHandler);
		IActions<IJsInterop> actions = ArrangeUnitTest<IJsInterop, JsInterop>(options =>
		{
			options.GetMock<IJSRuntime>(mock => mock.Setup(m => m.InvokeAsync<IJSObjectReference>("import", new object?[] { JsInterop.InteropFilePath }))
				.Returns(() => ValueTask.FromResult(mockJsObjectReference.Object)));
		});
		return (actions, mockJsObjectReference);
	}
}
