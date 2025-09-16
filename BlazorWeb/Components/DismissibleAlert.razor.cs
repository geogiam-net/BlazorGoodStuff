using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Components;

public partial class DismissibleAlert
{
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public EventCallback<bool> ShowChanged { get; set; }

    private async Task UpdateShow(bool value)
    {
        if (value != Show)
        {
            await ShowChanged.InvokeAsync(value);
        }
    }

    public async Task Dismiss() => await UpdateShow(false);
}