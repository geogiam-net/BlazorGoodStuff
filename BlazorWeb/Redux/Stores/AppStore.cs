using BlazorWeb.Redux.Records;

namespace BlazorWeb.Redux.Stores;

public record AppStore(
    bool IsSubmitting,
    CustomerRecord? NewCustomer
    );

