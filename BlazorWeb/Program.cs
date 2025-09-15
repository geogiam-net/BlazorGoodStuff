using BlazorWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });






// --------------------------------------------------------------------------------------------------------------
WebAssemblyHost host = builder.Build();
// --------------------------------------------------------------------------------------------------------------

ILogger<Program> logger = host.Services
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("This is can be read in the output from VS and in a default temp file that is created");





// --------------------------------------------------------------------------------------------------------------
await host.RunAsync();
