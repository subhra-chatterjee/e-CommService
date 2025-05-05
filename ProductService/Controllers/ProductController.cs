using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Entity;
using ProductService.Repos;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{   //using repository pattern
    private  readonly IproductRepo? _productRepo;
    private static readonly ILogger<ProductController> _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<ProductController>();
    public ProductController(IproductRepo? productRepo)
    {
        this._productRepo = productRepo;
    }

    [HttpGet("search")]
    public IActionResult Search(string? name, string? category)
    {
        try
        {
            var results = _productRepo?.GetProducts(name, category);
            _logger.LogInformation("Successfully get the product.", name, category);
            return Ok(results);
        }
        catch (Exception ex) 
        { 
            _logger.LogError(ex.Message, ex);
            return BadRequest(ex.Message);
        }
    }
}

