using CartService.Entity;
using static CartService.Entity.CartItem;

namespace OrderService.Entity
{
    public class Order
    {
        public List<CartItem?>? orderItem { get; set; }

    }
}
