using DataObjects;
using Microsoft.AspNetCore.Mvc;
using ServicesInterfaces;

namespace CustomerWebApi.Controllers
{
    // https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-9.0

    [ApiController]
    [Route("api/customer/")]
    public class CustomerRepositoryController : ControllerBase, ICustomerRepository
    {
        private readonly ILogger<CustomerRepositoryController> _logger;

        private static List<Customer> customers = new();

        public CustomerRepositoryController(ILogger<CustomerRepositoryController> logger)
        {
            _logger = logger;

            if (customers == null || customers.Count == 0)
            {
                customers = GenerateData().ToList();
            }
        }

        private IEnumerable<Customer> GenerateData()
        {
            yield return new Customer
            {
                CustomerId = "qwert",
                ContactName = "Pedro",
                CompanyName = "Barresola",
                City = "Chiha gho",
            };

            yield return new Customer
            {
                CustomerId = "12345",
                ContactName = "Alexander",
                CompanyName = "Adidas",
                City = "Oxford",
            };

            yield return new Customer
            {
                CustomerId = "44rbz",
                ContactName = "Luiso",
                CompanyName = "Vell dia",
                City = "Portobello",
            };

            yield return new Customer
            {
                CustomerId = "mmuhg",
                ContactName = "Jordano",
                CompanyName = "Explosivos S.A.",
                City = "New Gate Town",
            };

            yield return new Customer
            {
                CustomerId = "yxcrt",
                ContactName = "Maximilian",
                CompanyName = "Bevola",
                City = "Aalen",
            };
        }


        [HttpGet("RetrieveAllAsync")]
        public Task<Customer[]> RetrieveAllAsync()
        {
            return Task.FromResult(customers.ToArray());
        }

        [HttpPut("UpdateAsync")]
        public Task<Customer?> UpdateAsync(Customer customer)
        {
            Task<Customer?> task = Task<Customer?>.Factory.StartNew(() => {

                var foundCustomer = customers.FirstOrDefault(p => p.CustomerId == customer.CustomerId);
                if (foundCustomer is null)
                {
                    return null;
                }

                customers.Remove(foundCustomer);
                customers.Add(customer);
                return customer;
            });

            return task;
        }

        [HttpDelete("DeleteAsync/{id}")]
        public Task<bool> DeleteAsync(string id)
        {
            Task<bool> task = Task<bool>.Factory.StartNew(() => {

                var customer = customers.FirstOrDefault(p => p.CustomerId == id);
                if (customer is null) {
                    return false;               
                }

                customers.Remove(customer);
                return true;
            });

            return task;
        }

    }
}
