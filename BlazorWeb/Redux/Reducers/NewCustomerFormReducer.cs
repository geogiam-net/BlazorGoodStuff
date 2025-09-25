using BlazorWeb.Redux.Stores;
using Fluxor;

namespace BlazorApp.WithRedux.Components.Pages.Counter;

public static class NewCustomerFormReducer
{
    [ReducerMethod]
    public static AppStore ReduceSetSubmittingAction(AppStore state, SetSubmittingAction action)
        => state with { IsSubmitting = action.isSubmitting };

    [ReducerMethod]
    public static AppStore ReduceSetCompanyNameAction(AppStore state, SetCompanyNameAction action)
    {
        if (state.NewCustomer is null)
        {
            return state;
        }
        return state with { NewCustomer = state.NewCustomer with { CompanyName = action.companyName } };
    }

    [ReducerMethod]
    public static AppStore ReduceSetAddressAction(AppStore state, SetAddressAction action)
    {
        if (state.NewCustomer is null)
        {
            return state;
        }
        return state with { NewCustomer = state.NewCustomer with { Address = action.address } };
    }

    [ReducerMethod]
    public static AppStore ReduceSetCityAction(AppStore state, SetCityAction action)
    {
        if (state.NewCustomer is null)
        {
            return state;
        }
        return state with { NewCustomer = state.NewCustomer with { City = action.city } };
    }

    [ReducerMethod]
    public static AppStore ReduceSetPostalCodeAction(AppStore state, SetPostalCodeAction action)
    {
        if (state.NewCustomer is null)
        {
            return state;
        }
        return state with { NewCustomer = state.NewCustomer with { PostalCode = action.postalCode } };
    }

    [ReducerMethod]
    public static AppStore ReduceSetCountryAction(AppStore state, SetCountryAction action)
    {
        if (state.NewCustomer is null)
        {
            return state;
        }
        return state with { NewCustomer = state.NewCustomer with { Country = action.country } };
    }

    [ReducerMethod]
    public static AppStore ReduceSetPhoneAction(AppStore state, SetPhoneAction action)
    {
        if (state.NewCustomer is null) {
            return state;
        }
        return state with { NewCustomer = state.NewCustomer with { Phone = action.phone } };
    }

    [ReducerMethod]
    public static AppStore ReduceResetNewCustonerAction(AppStore state, ResetNewCustonerAction action)
        => state with { NewCustomer = null };
}
