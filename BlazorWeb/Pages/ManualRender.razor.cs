using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Pages;

public class ManualRenderBase : ComponentBase
{
    protected int currentCount = 0;

    protected void IncrementCount()
    {
        Timer timer = new(
            callback: (_) =>
            {
                // changes need to be done on the correct thread

                this.InvokeAsync(
                    () =>
                    {
                        currentCount++;
                        StateHasChanged();
                    }
                    );
            },
            state: null,
            dueTime: TimeSpan.FromSeconds(1),
            period: TimeSpan.FromSeconds(1)
            );
    }
}