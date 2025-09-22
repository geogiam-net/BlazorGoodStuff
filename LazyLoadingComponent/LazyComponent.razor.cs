using Microsoft.AspNetCore.Components;

namespace LazyLoadingComponent;

public class LazyLoadingBase : ComponentBase
{
    protected int diceResult;

    protected override void OnInitialized()
    {
        Random rnd = new Random();
        diceResult = rnd.Next(1, 7);
    }

}