using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<BUIApp>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddStoicDreamsBlazorUI(options =>
{
	options.AppName = "Stoic Dreams Blazor UI";
	options.CssFiles.Add("css/app.css");
	options.CssFiles.Add("StoicDreams.SampleWebsite.styles.css");
	options.HeadElements.Add(ElementDetail.Create("link", ("rel", "manifest")));
	options.HeadElements.Add(ElementDetail.Create("link", ("rel", "apple-touch-icon"), ("sizes", "512x512"), ("href", "icon-512.png")));
	options.HeadElements.Add(ElementDetail.Create("link", ("rel", "apple-touch-icon"), ("sizes", "192x192"), ("href", "icon-192.png")));
	options.BodyElements.Add(ElementDetail.Create("script", ("body", "navigator.serviceWorker.register('service-worker.js');"), ("type", "text/javascript")));
	options.TitleBarPosition = TitleBarPosition.Top;
	options.LeftDrawerVariant = DrawerVariant.Mini;
});

await builder.Build().RunAsync();
