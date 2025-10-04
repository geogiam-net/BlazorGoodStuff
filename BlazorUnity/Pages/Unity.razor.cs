using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorUnity;

// probably we could lazy load   buildUrl + "/build.loader.js";
// workaround, remember to rename /build2.data to /build2.data.json so it gets delivered by kestrel
public class UnityBase : ComponentBase
{
    [Inject]
    public IJSRuntime jsRuntime { get; set; } = default!;

    private Lazy<Task<IJSObjectReference>> moduleTask = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import",
                "./scripts/unityHandler.js").AsTask());

            DotNetObjectReference<UnityBase> objRef = DotNetObjectReference.Create(this);
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("loadUnity", objRef);
        }
    }

    protected async void InvokeJavascript()
    {
        var module = await moduleTask.Value;
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