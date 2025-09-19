using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Pages;

// every method is called at lesat once even if not used
public class LifeCycleBase : ComponentBase
{
    // never do async things in the setters
    protected string Text { get; set; }
    protected int Counter { get; set; } = default!;

    public LifeCycleBase()
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Inside LifeCycle constructor");

        Text = "Set by constructor";
        Console.WriteLine($"Counter value = {Counter}");
    }

    // parameters and cascading parameters are set here
    public override Task SetParametersAsync(ParameterView parameters)
    {
        Console.WriteLine("Inside LifeCycle SetParametersAsync");
        Console.WriteLine($"Counter value = {Counter}");
        return base.SetParametersAsync(parameters);
        // return base.SetParametersAsync(ParameterView.Empty);

    }
    // OnInitialized
    protected override async Task OnInitializedAsync()
    {
        Console.WriteLine($"Begin LifeCycle OnInitializedAsync");
        Console.WriteLine($"Counter value = {Counter}");
        await Task.CompletedTask;
    }

    // these 2 methods are called after a parameters bound is changed and the components triggers a new life cycle
    // OnParametersSet
    protected override async Task OnParametersSetAsync()
    {
        Console.WriteLine($"Inside LifeCycle OnParametersSetAsync");
        Console.WriteLine($"Counter value = {Counter}");
        await Task.CompletedTask;
    }

    // OnAfterRender
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        Console.WriteLine($"LifeCycle Demo Rendered - FirstRender = {firstRender}");
        return Task.CompletedTask;
    }

    // dependency injecction will call Dispose for the injected params automatically
    public void Dispose()
    {
        Console.WriteLine("Inside LifeCycle Dispose");
    }

    public async ValueTask DisposeAsync()
    {
        Console.WriteLine("Inside LifeCycle DisposeAsync");
        await ValueTask.CompletedTask;
    }

    public async Task ClickAsync()
    {
        Console.WriteLine("ClickAsync");
        Counter += 1;
        Console.WriteLine($"Counter value = {Counter}");
    }
}