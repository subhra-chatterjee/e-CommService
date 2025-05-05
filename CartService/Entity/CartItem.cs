﻿namespace CartService.Entity
{
    
    
        public class CartItem
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public string ProductName { get; set; } = "";
            public decimal Price { get; set; }
            public bool InStock { get; set; }
        }

    
}
