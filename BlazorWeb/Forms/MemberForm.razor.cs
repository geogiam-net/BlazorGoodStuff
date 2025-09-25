using Microsoft.AspNetCore.Components;
using BlazorWeb.Forms;
using BlazorWeb.Classes;

namespace BlazorWeb.Forms;

public class MemberFormBase : ComponentBase
{
    [Parameter]
    [EditorRequired]
    public required Member member { get; set; }

    public void Submit()
    {
        Console.WriteLine(member.ToJson());
    }
}