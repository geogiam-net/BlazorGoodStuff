using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Components;

public partial class PersonDataBase : ComponentBase
{
    [Parameter]
    public string Name { get; set; }

    [Parameter]
    public int Age { get; set; }

    [Parameter]
    public string Address { get; set; }
}
