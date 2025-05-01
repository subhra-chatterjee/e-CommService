using Microsoft.AspNetCore.Mvc;
using ProductService.Entity;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product { ProductId = 1, Name = "Laptop", Category = "Electronics", Price = 50000, Stock = 10 },
        new Product { ProductId = 2, Name = "Phone", Category = "Electronics", Price = 20000, Stock = 5 },
    };

    [HttpGet("search")]
    public IActionResult Search(string? name, string? category)
    {
        var results = Products.Where(p =>
            (string.IsNullOrEmpty(name) || p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(category) || p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)) &&
            p.Stock > 0
        );
        return Ok(results);
    }
}

