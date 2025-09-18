using Microsoft.AspNetCore.Components;
using ServicesInterfaces;

namespace BlazorWeb.Pages;

public class InjectProductListBase : ComponentBase
{
    [Inject]
    // [Inject(Key = "serv name")]
    protected IProductService productsService { get; set; } = default!;
}