using BlazorWeb.State;
using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Pages;

public class CascadingParamBase : ComponentBase
{
    // Root Level Cascading Value from program.cs
    [CascadingParameter]
    public required UserInfo UserInfo { get; set; }
}