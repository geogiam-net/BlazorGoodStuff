namespace BlazorWeb.Redux.Actions;

public record SetSubmittingAction(bool isSubmitting);

public record SetCompanyNameAction(string companyName);

public record SetAddressAction(string address);

public record SetCityAction(string city);

public record SetPostalCodeAction(string postalCode);

public record SetCountryAction(string country);

public record SetPhoneAction(string phone);

public record ResetNewCustonerForm();