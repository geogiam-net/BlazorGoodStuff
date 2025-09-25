using DataObjects;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorWeb.Pages;

public class CallCustomerWebApiBase : ComponentBase
{
    [Inject(Key = "CustomerWebApi")]
    protected HttpClient httpClient { get; set; } = default!;

    protected IEnumerable<Customer>? customers;

    protected override async Task OnParametersSetAsync()
    {
        customers = await httpClient.GetFromJsonAsync<Customer[]>("/api/customer/RetrieveAllAsync");
    }
}