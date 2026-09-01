using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Markdig;
using ProfileWeb;
using ProfileWeb.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Markdown rendering for /blogs and /pages content.
builder.Services.AddSingleton(new MarkdownPipelineBuilder()
    .UseAdvancedExtensions()   // tables, task lists, footnotes, auto-ids, emphasis extras…
    .UseYamlFrontMatter()      // strip the `--- … ---` metadata block from the output
    .UseAutoLinks()
    .Build());
builder.Services.AddScoped<ContentService>();

await builder.Build().RunAsync();
