using DataObjects;
using ServicesInterfaces;

namespace Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetProducts()
        {
            yield return new Product
            {
                Name = "Isabelle's Homemade Marmelade",
                Description = "...",
                Price = 1.99M
            };

            yield return new Product
            {
                Name = "Liesbeth's Applecake",
                Description = "...",
                Price = 3.99M
            };
        }
    }
}
