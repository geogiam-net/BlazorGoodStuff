using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Pages;

public class ContadorBase : ComponentBase
{
    protected int currentCount = 0;

    protected void IncrementCount()
    {
        currentCount++;
    }
}