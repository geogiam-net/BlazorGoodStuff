using BlazorWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Services;
using ServicesInterfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddSingleton<IProductService, ProductService>();

//HardCodedProductsService hardCodedProductsService = new();
//builder.Services.AddSingleton<IProductsService>(hardCodedProductsService);
//builder.Services.AddTransient<IProductService, ProductService>();
// builder.Services.AddScoped<IProductsService, HardCodedProductsService>();
//builder.Services.AddKeyedSingleton<IProductService, ProductService>(serviceKey: "serv name");


// --------------------------------------------------------------------------------------------------------------
WebAssemblyHost host = builder.Build();
// --------------------------------------------------------------------------------------------------------------

ILogger<Program> logger = host.Services
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("This is can be read in the output from VS and in a default temp file that is created");





// --------------------------------------------------------------------------------------------------------------
await host.RunAsync();
