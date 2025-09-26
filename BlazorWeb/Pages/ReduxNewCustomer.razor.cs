using BlazorWeb.Classes;
using BlazorWeb.Redux.Stores;
using BlazorWeb.Redux.Actions;
using DataObjects;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWeb.Pages;

public class ReduxNewCustomerBase : Fluxor.Blazor.Web.Components.FluxorComponent
{
    [Inject]
    public required IState<AppStore> state { get; set; }

    [Inject]
    public required IDispatcher dispatcher { get; set; }

    public AppStore AppStore => state.Value;

    protected EditContext? editContext;

    protected Customer customer { get; set; } = default!;
    private Timer timer { get; set; } = default!;

    // OnInitialized
    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (AppStore.NewCustomer is not null)
        {
            customer = new Customer
            {
                CompanyName = AppStore.NewCustomer.CompanyName,
                Address = AppStore.NewCustomer.Address,
                City = AppStore.NewCustomer.City,
                PostalCode = AppStore.NewCustomer.PostalCode,
                Country = AppStore.NewCustomer.Country,
                Phone = AppStore.NewCustomer.Phone
            };
        }
        else {
            customer = new Customer
            {
                CompanyName = string.Empty,
                Address = string.Empty,
                City = string.Empty,
                PostalCode = string.Empty,
                Country = string.Empty,
                Phone = string.Empty,
            };
        }

        editContext = new(customer);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private void HandleFieldChanged(object? _, FieldChangedEventArgs e)
    {
        switch (e.FieldIdentifier.FieldName) { 

            case nameof(Customer.CompanyName):
                dispatcher.Dispatch(new SetCompanyNameAction(customer.CompanyName));
                break;

            case nameof(Customer.Address):
                dispatcher.Dispatch(new SetAddressAction(customer.Address ?? string.Empty));
                break;

            case nameof(Customer.City):
                dispatcher.Dispatch(new SetCityAction(customer.City ?? string.Empty));
                break;

            case nameof(Customer.PostalCode):
                dispatcher.Dispatch(new SetPostalCodeAction(customer.PostalCode ?? string.Empty));
                break;

            case nameof(Customer.Country):
                dispatcher.Dispatch(new SetCountryAction(customer.Country ?? string.Empty));
                break;

            case nameof(Customer.Phone):
                dispatcher.Dispatch(new SetPhoneAction(customer.Phone ?? string.Empty));
                break;
        }
    }

    public void Submit()
    {
        dispatcher.Dispatch(new SetSubmittingAction(true));

        timer = new(
            callback:  (_) => {    
                Console.WriteLine(customer.ToJson());

                customer.CompanyName = string.Empty;
                customer.Address = string.Empty;
                customer.City = string.Empty;
                customer.PostalCode = string.Empty;
                customer.Country = string.Empty;
                customer.Phone = string.Empty;

                editContext?.MarkAsUnmodified();

                dispatcher.Dispatch(new ResetNewCustonerForm());

                this.StateHasChanged();
            },
            state: null,
            dueTime: 4000,
            period: Timeout.Infinite);
    }

    public void Dispose() => timer.Dispose();
}