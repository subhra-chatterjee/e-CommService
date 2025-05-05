using System.Xml.Linq;
using ProductService.Entity;

namespace ProductService.Repos
{
    public class ProductRepo:IproductRepo
    {
        private  List<Product> Products = new()
    {
        new Product { ProductId = 1, Name = "Laptop", Category = "Electronics", Price = 50000, Stock = 10 },
        new Product { ProductId = 2, Name = "Phone", Category = "Electronics", Price = 20000, Stock = 5 },
    };

        public List<Product> GetProducts(string? name, string? category)
        {
            try
            {
                var result = Products.Where(p =>
                            (string.IsNullOrEmpty(name) || p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
                            (string.IsNullOrEmpty(category) || p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)) &&
                             p.Stock > 0).ToList();
                return result;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);            
            }
        }
    }
}
