using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Pages;

public class OneWayUpBindingBase : ComponentBase
{
    public bool ShowAlert { get; set; } = false;

    public void ToggleAlert()
    {
        ShowAlert = !ShowAlert;
    }
}