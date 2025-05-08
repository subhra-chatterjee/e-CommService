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
            var isPayment = true;//defualt set true.
            var success = allAvailable && MockPayment(isPayment);

            var status = success ? "Confirmed" : "Cancelled";
            _logger.LogInformation("Order Placed Successfully Done.Order status: {status}", status);
            return Ok(new { Status = status });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }




    private bool MockPayment(bool ispayment)
    {
        if(ispayment)
        {
            _logger.LogInformation("Payment successfully done. Payment status: {IsPayment}", ispayment);

            return true;
        }
        else
        {
            _logger.LogError("Payment Decline . Payment status: {IsPayment}", ispayment);
            return false;
        }
            
    }

}

