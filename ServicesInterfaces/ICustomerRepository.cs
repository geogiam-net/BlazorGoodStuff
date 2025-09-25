using DataObjects;

namespace ServicesInterfaces
{
    public interface ICustomerRepository
    {
        Task<Customer[]> RetrieveAllAsync();
        Task<Customer?> UpdateAsync(Customer c);
        Task<bool> DeleteAsync(string id);
    }
}
