using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace BlazorWeb.Pages;

public class UrlParametersBase : ComponentBase
{
    [Parameter]
    public int CurrentCount { get; set; } = default;

    [Inject]
    protected NavigationManager navigationManager { get; set; } = default!;

    [SupplyParameterFromQuery(Name = "StartFrom")]
    private string? QueryStringStartFrom { get; set; }

    public int StartFrom = 25;

    protected override void OnInitialized()
    {
        if (Int32.TryParse(QueryStringStartFrom, out int StartFromParsed)) {
            StartFrom = StartFromParsed;
        }
    }

    protected void IncrementCount()
    {
        CurrentCount++;
    }

    protected void StartFromX()
    {
        navigationManager.NavigateTo($"/UrlParameters/{StartFrom}");
    }

    /*
     On can intercept navigation with the following methods:
    ConfirmExternalNavigation
    OnBeforeInternalNavigation
     */
}