# Stoic Dreams Blazor UI
###### GitHub: [GitHub.com/StoicDreams/BlazorUI](https://github.com/StoicDreams/BlazorUI)
###### Nuget: [NuGet.org/StoicDreams/BlazorUI](https://nuget.org/StoicDreams/BlazorUI)

UI Framework and component library for Blazor based Websites and Maui projects.

> ## **Notice:** This project is very early in development!
> This project should technically have all the functionality to build a complete website, but at this stage there is a lot of experimental work being done and breaking changes could be introduced with each update.

If you do decide to use it please provide us feedback on our website at [www.stoicdreams.com](https://www.stoicdreams.com).

## MudBlazor - [www.MudBlazor.com](https://www.mudblazor.com)
###### Library Docs - [MudBlazor.com/docs/overview](https://mudblazor.com/docs/overview)

Due to its sheer awesomeness we have decided to use MudBlazor as a base for our component library. We will do our best to update this project to keep it up to date with MudBlazor updates. And we'll do our best to make sure our integrations and components do not conflict with expected behavior from MudBlazor components.

Not only is it hands down the best component framework we've see or tried in any language, but it's also free. It has a focus on being rooted in Material design, and their components, documentation, and templates are much more developer friendly in our opinion than most other design frameworks we've seen or tried.

## Project Goals

This Blazor UI framework is targeting a developer experience that will allow developers to be able to develop websites and Maui Blazor app (Desktop & Mobile) without needing to know or touch any html, css, or javascript.

Where component frameworks such as MudBlazor typically give you a bunch of smaller components that need to be stitched together with countless options for doing so, Blazor UI's goal is to get rid of boilerplate coding such as index.html files, and package together these smaller components into larger components, including the `MUIApp` which replaces the normal `App` component that a developer would normally have to create and manage for each new app.

As an example here is the `Program.cs` contenxt taken from our Sample Website:
```csharp
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StoicDreams.SampleWebsite.Shared;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<BUIApp>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddStoicDreamsBlazorUI(options =>
{
	options.AppName = "Stoic Dreams Blazor UI Sample App";
	options.CssFiles.Add("css/app.css");
	options.CssFiles.Add("StoicDreams.SampleWebsite.styles.css");
	options.HeadElements.Add(ElementDetail.Create("link", ("rel", "manifest")));
	options.HeadElements.Add(ElementDetail.Create("link", ("rel", "apple-touch-icon"), ("sizes", "512x512"), ("href", "icon-512.png")));
	options.HeadElements.Add(ElementDetail.Create("link", ("rel", "apple-touch-icon"), ("sizes", "192x192"), ("href", "icon-192.png")));
	options.BodyElements.Add(ElementDetail.Create("script", ("body", "navigator.serviceWorker.register('service-worker.js');"), ("type", "text/javascript")));
});

And while our DefaultLayout is being designed to provide a ton of flexability through simple config changes, we recognize some developers will want to do layouts that follow their own standards, so we allow a simple mechanism to set your own layout.

```csharp
builder.Services.AddStoicDreamsBlazorUI(options =>
{
	options.AppName = "Stoic Dreams Blazor UI Sample App";
	options.SetLayout<MainLayout>();
	...
});

```

await builder.Build().RunAsync();

```

While this project will take some inspiration from and is expected to share some features from design frameworks such as Material and Fluent design systems, it is not in our interest to strictly follow any other frameworks or design patterns. We like a lot of what they do and provide, but we also thing they do some things wrong.

We have developed and are evolving our own design patterns, and those will be reflected in this UI framework.

## Restrictions

Blazor UI is currently being designed to target Maui Blazor and Wasm focused projects. Specifically projects that use an index.html file, which Blazor UI is including from its collection of static files. Server-side Blazor projects are not expected to work.

## Project Setup

See the [Blazor UI Sample Website](https://github.com/StoicDreams/BlazorUI/tree/main/StoicDreams.SampleWebsite) for details on how to setup a new website project.

A Maui Blazor sample project will be added later after that framework and toolchain has become generally available for production use.


## Author

**[Erik Gassler](https://www.erikgassler.com/home) - [Stoic Dreams](https://www.stoicdreams.com/home)** - Just a simpleton who likes making stuff with bits and bytes.

**Support** - Visit [Stoic Dreams' Patreon page](https://www.patreon.com/stoicdreams) if you would like to provide support to Stoic Dreams.
Also make sure to share your support to the team at [MudBlazor](https://github.com/sponsors/MudBlazor) for the awesome work they're doing.


**Software Development Standards** - Check out my [Simple-Holistic-Agile Software Engineering Standards](https://www.softwarestandards.dev/home) website to see my standards for developing software.
