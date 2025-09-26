using BlazorWeb.Redux.Stores;
using BlazorWeb.Redux.Actions;
using Fluxor;

namespace BlazorWeb.Redux.Reducers;

public static class NewCustomerFormReducer
{
    [ReducerMethod]
    public static AppStore ReduceSetSubmittingAction(AppStore state, SetSubmittingAction action)
        => state with { IsSubmitting = action.isSubmitting };

    [ReducerMethod]
    public static AppStore ReduceSetCompanyNameAction(AppStore state, SetCompanyNameAction action)
    {
        return state with
        {
            NewCustomer = (state.NewCustomer is null)
            ? new Records.CustomerRecord() { CompanyName = action.companyName }
            : state.NewCustomer with { CompanyName = action.companyName }
        };
    }

    [ReducerMethod]
    public static AppStore ReduceSetAddressAction(AppStore state, SetAddressAction action)
    {
        return state with
        {
            NewCustomer = (state.NewCustomer is null)
            ? new Records.CustomerRecord() { Address = action.address }
            : state.NewCustomer with { Address = action.address }
        };
    }

    [ReducerMethod]
    public static AppStore ReduceSetCityAction(AppStore state, SetCityAction action)
    {
        return state with
        {
            NewCustomer = (state.NewCustomer is null)
            ? new Records.CustomerRecord() { City = action.city }
            : state.NewCustomer with { City = action.city }
        };
    }

    [ReducerMethod]
    public static AppStore ReduceSetPostalCodeAction(AppStore state, SetPostalCodeAction action)
    {
        return state with
        {
            NewCustomer = (state.NewCustomer is null)
            ? new Records.CustomerRecord() { PostalCode = action.postalCode }
            : state.NewCustomer with { PostalCode = action.postalCode }
        };
    }

    [ReducerMethod]
    public static AppStore ReduceSetCountryAction(AppStore state, SetCountryAction action)
    {
        return state with
        {
            NewCustomer = (state.NewCustomer is null)
            ? new Records.CustomerRecord() { Country = action.country }
            : state.NewCustomer with { Country = action.country }
        };
    }

    [ReducerMethod]
    public static AppStore ReduceSetPhoneAction(AppStore state, SetPhoneAction action)
    {
        return state with
        {
            NewCustomer = (state.NewCustomer is null)
            ? new Records.CustomerRecord() { Phone = action.phone }
            : state.NewCustomer with { Phone = action.phone }
        };
    }

    [ReducerMethod]
    public static AppStore ReduceResetNewCustonerAction(AppStore state, ResetNewCustonerForm action)
        => state with { NewCustomer = null, IsSubmitting = false };
}
