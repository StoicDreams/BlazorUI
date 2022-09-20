using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<BUIApp>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.WebStartup();

await builder.Build().RunAsync();
