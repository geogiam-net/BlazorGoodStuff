using BlazorWeb.Classes;
using BlazorWeb.Forms;
using BlazorWeb.SampleData;
using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Pages;

public class FormBase : ComponentBase
{
    protected Member member { get; set; } = new Member
        {
            Name = "Peter",
            Email = string.Empty,
            Password = string.Empty,
            Country = "be",
            Message = "I ❤️ Blazor!",
            Gender = Gender.Male,
            Subscriber = true
        };
}