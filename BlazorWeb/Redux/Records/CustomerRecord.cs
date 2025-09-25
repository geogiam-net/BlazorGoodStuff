namespace BlazorWeb.Redux.Records
{
    public record class CustomerRecord
    {
        public string CompanyName { get; init; } = string.Empty;

        public string Address { get; init; } = string.Empty;

        public string City { get; init; } = string.Empty;

        public string PostalCode { get; init; } = string.Empty;

        public string Country { get; init; } = string.Empty;

        public string Phone { get; init; } = string.Empty;
    }
}
