using CartService.Entity;
using Microsoft.AspNetCore.Mvc;
using static CartService.Entity.CartItem;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private static readonly List<CartItem> Cart = new();
    private static readonly ILogger<CartController> _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<CartController>();

    [HttpPost("add")]
    public IActionResult AddToCart([FromBody] CartItem item)
    {
        try
        {
            Cart.Add(item);
            _logger.LogInformation("Product added to cart.",item.ProductName);
            return Ok("Product added to cart.");
        }
        catch (Exception ex)
        { 
            _logger.LogError(ex.Message, ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetCart()
    {
        return Ok(Cart);
    }
}


