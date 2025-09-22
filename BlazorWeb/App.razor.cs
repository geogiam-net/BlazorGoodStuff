using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using System.Reflection;

namespace BlazorWeb;

// more examples at https://ilovedotnet.org/blogs/blazor-wasm-lazy-loading/
/*
    DI is inmutable after app initialization
    If we need to lazy load a service, one needs to implement a factory, it is explained in chapter 10 of book
*/
public class AppBase : ComponentBase
{
    [Inject]
    protected LazyAssemblyLoader lazyAssemblyLoader { get; set; } = default!;

    protected List<Assembly> additionalAssemblies = [];

    protected async Task NavigateAsync(NavigationContext context)
    {
        if (context.Path.Contains("TryLazyLoading", StringComparison.OrdinalIgnoreCase))
        {
            var assemblies = await lazyAssemblyLoader.LoadAssembliesAsync(["LazyLoadingComponent.wasm"]);
            additionalAssemblies.AddRange(assemblies);
        }
    }
}