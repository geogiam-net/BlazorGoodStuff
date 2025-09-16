using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Pages;

public class TwoWayBindingBase : ComponentBase
{
    protected bool ShowAlert { get; set; } = true;
}