using static CartService.Entity.CartItemcs;

namespace OrderService.Entity
{
    public class Order
    {
        public List<CartItem> CartItems { get; set; }

    }
}
