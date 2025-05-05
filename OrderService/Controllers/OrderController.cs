using Microsoft.AspNetCore.Mvc;
using OrderService.Entity;
using static CartService.Entity.CartItem;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private static readonly ILogger<OrderController> _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<OrderController>();

    [HttpPost("place")]
    public IActionResult PlaceOrder([FromBody] Order order)
    {
        try
        {
            var allAvailable = order.orderItem.All(item => item.InStock);

            var success = allAvailable && MockPayment();

            var status = success ? "Confirmed" : "Cancelled";
            _logger.LogInformation("Order placed successfully.", status);
            return Ok(new { Status = status });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }




    private bool MockPayment()
    {
        return true;
    }

}

