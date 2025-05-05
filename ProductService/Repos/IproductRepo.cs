using ProductService.Entity;

namespace ProductService.Repos
{
    public interface IproductRepo
    {
        public List<Product> GetProducts(string? name,string? category);
    }
}
