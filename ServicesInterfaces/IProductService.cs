using DataObjects;

namespace ServicesInterfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}
