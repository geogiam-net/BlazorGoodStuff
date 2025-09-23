using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.Metrics;

namespace BlazorWeb.Pages;

// in a real project, all interop muss be in a service to separate both logic layers
public class InteroperabilityBase : ComponentBase
{
    [Inject]
    public IJSRuntime jsRuntime { get; set; } = default!;

    private Lazy<Task<IJSObjectReference>> moduleTask = default!;

    protected string csharpResult = "";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import",
                "./scripts/tryInterop.js").AsTask());

            DotNetObjectReference<InteroperabilityBase> objRef = DotNetObjectReference.Create(this);
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("putBlazorInstance", objRef);
        }
    }

    protected async void InvokeJavascript()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("showMessage", "Hello coming from #_#");
    }

    [JSInvokable]
    public void InvokeCSharp()
    {
        csharpResult = "Hello coming from J_J";
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}