using System;

namespace eCommerce.ApplicationLayer.Carts.Dtos
{
    public class CartProductDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}