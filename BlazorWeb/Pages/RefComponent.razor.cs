using BlazorWeb.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Pages;

public class RefComponentBase : ComponentBase
{
    protected ColorAlert _colorAlert = default!;

    protected void Dismiss()
    {
        _colorAlert.Dismiss();
    }
}