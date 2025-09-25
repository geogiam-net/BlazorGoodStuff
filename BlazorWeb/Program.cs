using BlazorWeb;
using BlazorWeb.State;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Services;
using ServicesInterfaces;
using Fluxor.Blazor.Web.ReduxDevTools;
using BlazorWeb.Redux.Stores;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(AppStore).Assembly);
#if DEBUG
    options.UseReduxDevTools();
#endif
});

builder.Services.AddKeyedScoped(
    "BlazorWeb",
    (sp, key) => new HttpClient { 
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

builder.Services.AddKeyedScoped(
    "CustomerWebApi",
    (sp, key) => new HttpClient { 
        BaseAddress = new Uri("http://localhost:5184/")
    });

// Add DI ------------------------------------------------------------------------------------------------------
builder.Services.AddSingleton<IProductService, ProductService>();
//HardCodedProductsService hardCodedProductsService = new();
//builder.Services.AddSingleton<IProductsService>(hardCodedProductsService);
//builder.Services.AddTransient<IProductService, ProductService>();
// builder.Services.AddScoped<IProductsService, HardCodedProductsService>();
//builder.Services.AddKeyedSingleton<IProductService, ProductService>(serviceKey: "serv name");


// Add Cascading Parameters -------------------------------------------------------------------------------------
// Add a root-level cascading value
builder.Services.AddCascadingValue( _ => new UserInfo { UserName = "Jefke" });

/*
// Add a root-level named cascading value
builder.Services.AddCascadingValue("Named", _ => new UserInfo { UserName = "Peter" });

// Add a root-level non-fixed cascading value
builder.Services.AddCascadingValue("Fixed", _ =>
{
    UserInfo ui = new() { UserName = "Peter" };
    CascadingValueSource<UserInfo> source = new(ui, isFixed: false);
    return source;
});
*/


// --------------------------------------------------------------------------------------------------------------
WebAssemblyHost host = builder.Build();
// --------------------------------------------------------------------------------------------------------------

ILogger<Program> logger = host.Services
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("This is can be read in the output from VS and in a default temp file that is created");


// --------------------------------------------------------------------------------------------------------------
await host.RunAsync();
