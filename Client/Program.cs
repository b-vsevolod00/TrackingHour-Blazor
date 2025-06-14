using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using TrackHourBlazor.Client;
using Microsoft.JSInterop;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "TrackHourBlazorTheme";
    options.Duration = TimeSpan.FromDays(365);
});
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<TrackHourBlazor.Client.moodle_vsamkService>();
builder.Services.AddLocalization();
var host = builder.Build();
var jsRuntime = host.Services.GetRequiredService<Microsoft.JSInterop.IJSRuntime>();
var culture = await jsRuntime.InvokeAsync<string>("Radzen.getCulture");
if (!string.IsNullOrEmpty(culture))
{
    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);
}

await host.RunAsync();